using System;
using System.Text;
using System.Data.Common;
using System.Globalization;
using System.Collections.Generic;
using Fwk.Exceptions;
using System.Data;
using System.Data.SqlClient;
using Fwk.HelperFunctions;

namespace Fwk.Logging.Targets
{
    /// <summary>
    /// Destino de tipo base de datos.
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public class DatabaseTarget : Target
    {
        #region <private members>
        private string _CnnStringName;
        string _ConnectionString;
        #endregion

        #region <constructor>
        /// <summary>
        /// Constructor de DatabaseTarget.
        /// </summary>
        public DatabaseTarget()
        {
            this.Type = TargetType.Database;
        }
        #endregion

        #region <public properties>
        /// <summary>
        /// Nombre de la conexión de la base de datos 
        /// en la cual se escribirá el log del evento.
        /// Esta conexión debe estar configurada en la 
        /// Sección 'connectionStrings' del archivo de
        /// configuración App.Config.
        /// </summary>
        public string CnnStringName
        {
            get { return _CnnStringName; }
            set { _CnnStringName = value; }
        }
        #endregion

        /// <summary>
        /// Cadena de conexión
        /// </summary>
        public string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }

        }
        #region <public overrides>
        /// <summary>
        /// Implementación de la escritura del log del evento
        /// en base de datos.
        /// </summary>
        /// <param name="pEvent">Evento a loguear.</param>
        public override void Write(Event pEvent)
        {


            using (SqlConnection wCnn = new SqlConnection(GetCnnString()))
            using (SqlCommand wCmd = new SqlCommand())
            {
                try
                {
                    wCnn.Open();
                    wCmd.Connection = wCnn;
                    wCmd.CommandType = CommandType.StoredProcedure;
                    wCmd.CommandText = "fwk_Logs_i";
                    SqlParameter wParam = null;

                    wParam = wCmd.Parameters.Add("Id", SqlDbType.UniqueIdentifier);
                    wParam.Value = pEvent.Id;

                    wParam = wCmd.Parameters.Add("Message", SqlDbType.VarChar);
                    //wParam.Value = TypeFunctions.ConvertStringToByteArray(pEvent.Message.Text);
                    wParam.Value = pEvent.Message.Text;

                    wParam = wCmd.Parameters.Add("Source", SqlDbType.VarChar);
                    wParam.Value = pEvent.Source;

                    wParam = wCmd.Parameters.Add("LogType", SqlDbType.VarChar);
                    wParam.Value = pEvent.LogType;

                    wParam = wCmd.Parameters.Add("Machine", SqlDbType.VarChar);
                    wParam.Value = pEvent.Machine;
                   
                    wParam = wCmd.Parameters.Add("LogDate", SqlDbType.DateTime);
                    wParam.Value = pEvent.LogDate;

                    wParam = wCmd.Parameters.Add("UserLoginName", SqlDbType.VarChar);
                    wParam.Value = pEvent.User;

                    wParam = wCmd.Parameters.Add("AppId", SqlDbType.VarChar);
                    wParam.Value = pEvent.AppId;

                    wCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    TechnicalException te = new TechnicalException("Error de Fwk.Logging al intentar insertar log en base de datos", ex);
                    te.ErrorId = "9004";
                    Fwk.Exceptions.ExceptionHelper.SetTechnicalException<DatabaseTarget>(te);
                    throw te;
                }
            }
        }
       

        /// <summary>
        /// SearchByParam
        /// </summary>
        ///<param name="pEvent">Event</param>
        /// <returns>LogsList</returns>
        /// <Date>2010-02-26T10:05:27</Date>
        /// <Author>moviedo</Author>
        public override Events SearchByParam(Event pEvent)
        {
            Events wEventList = new Events();
            Event wEvent;
            using (SqlConnection wCnn = new SqlConnection(GetCnnString()))
            using (SqlCommand wCmd = new SqlCommand())
            {
                try
                {
                    wCnn.Open();
                    wCmd.Connection = wCnn;
                    wCmd.CommandType = CommandType.StoredProcedure;
                    wCmd.CommandText = "fwk_Logs_s";
                    SqlParameter wParam = null;



                    if (!string.IsNullOrEmpty(pEvent.Source))
                    {
                        wParam = wCmd.Parameters.Add("Source", SqlDbType.NVarChar);
                        wParam.Value = string.Concat("%", pEvent.Source, "%");
                    }

                    if (pEvent.LogType != EventType.None)
                    {
                        wParam = wCmd.Parameters.Add("LogType", SqlDbType.NVarChar);
                        wParam.Value = pEvent.LogType;
                    }
                    if (pEvent.LogDate != Fwk.HelperFunctions.DateFunctions.NullDateTime)
                    {
                        wParam = wCmd.Parameters.Add("LogDateDesde", SqlDbType.DateTime);
                        wParam.Value = pEvent.LogDate;
                        
                    }
                  
                    if (!string.IsNullOrEmpty(pEvent.Machine))
                    {
                        wParam = wCmd.Parameters.Add("Machine", SqlDbType.NVarChar);
                        wParam.Value = string.Concat("%", pEvent.Machine, "%");
                    }

                    if (!string.IsNullOrEmpty(pEvent.User))
                    {
                        wParam = wCmd.Parameters.Add("UserLoginName", SqlDbType.NVarChar);
                        wParam.Value = string.Concat("%", pEvent.User, "%");
                    }


                    if (!string.IsNullOrEmpty(pEvent.AppId))
                    {
                        wParam = wCmd.Parameters.Add("AppId", SqlDbType.NVarChar);
                        wParam.Value = string.Concat("%", pEvent.AppId, "%");
                    }




                    using (IDataReader reader = wCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            wEvent = new Event();
                            wEvent.Id = new Guid(reader["Id"].ToString());
                      
                            wEvent.Message.Text = TypeFunctions.ConvertBytesToTextString((Byte[])(reader["Message"]));
                            wEvent.Source = reader["Source"].ToString();
                            wEvent.LogType = (EventType)Enum.Parse(typeof(EventType), reader["LogType"].ToString());
                            wEvent.Machine = reader["Machine"].ToString();
                            wEvent.LogDate = Convert.ToDateTime(reader["LogDate"]);
                            wEvent.User = reader["UserLoginName"].ToString();
                            wEvent.AppId = reader["AppId"].ToString();
                            wEventList.Add(wEvent);
                        }
                    }

                    return wEventList;

                }
                catch (Exception ex)
                {
                    TechnicalException te = new TechnicalException("Error de Fwk.Logging al intentar consultar log en base de datos", ex);
                    te.ErrorId = "9004";
                    Fwk.Exceptions.ExceptionHelper.SetTechnicalException<DatabaseTarget>(te);
                    throw te;
                }
            }
        }

        /// <summary>
        /// SearchByParam
        /// </summary>
        ///<param name="pEvent">Event</param>
        ///<param name="pEndDate">pEndDate</param>
        /// <returns>LogsList</returns>
        /// <Date>2010-02-26T10:05:27</Date>
        /// <Author>moviedo</Author>
        public override  Events SearchByParam(Event pEvent,DateTime pEndDate)
        {
            Events wEventList = new Events();
            Event wEvent;
            using (SqlConnection wCnn = new SqlConnection(GetCnnString()))
            using (SqlCommand wCmd = new SqlCommand())
            {
                try
                {
                    wCnn.Open();
                    wCmd.Connection = wCnn;
                    wCmd.CommandType = CommandType.StoredProcedure;
                    wCmd.CommandText = "fwk_Logs_s";
                    SqlParameter wParam = null;


                    if (!string.IsNullOrEmpty(pEvent.Source))
                    {
                        wParam = wCmd.Parameters.Add("Source", SqlDbType.NVarChar);
                        wParam.Value = string.Concat("%", pEvent.Source, "%");
                    }
             

               
                    if (pEvent.LogType != EventType.None)
                    {
                        wParam = wCmd.Parameters.Add("LogType", SqlDbType.NVarChar);
                        wParam.Value = pEvent.LogType;
                    }
                    if (pEvent.LogDate != Fwk.HelperFunctions.DateFunctions.NullDateTime)
                    {
                        wParam = wCmd.Parameters.Add("LogDateDesde", SqlDbType.DateTime);
                        wParam.Value = pEvent.LogDate;

                    }

                    if (pEndDate != Fwk.HelperFunctions.DateFunctions.NullDateTime)
                    {
                        wParam = wCmd.Parameters.Add("LogDateHasta", SqlDbType.DateTime);
                        wParam.Value = pEndDate;
                    }

                    if (!string.IsNullOrEmpty(pEvent.Machine))
                    {
                        wParam = wCmd.Parameters.Add("Machine", SqlDbType.NVarChar);
                        wParam.Value = string.Concat("%", pEvent.Machine, "%");
                    }

                    if (!string.IsNullOrEmpty(pEvent.User))
                    {
                        wParam = wCmd.Parameters.Add("UserLoginName", SqlDbType.NVarChar);
                        wParam.Value = string.Concat("%", pEvent.User, "%");
                    }

                    if (!string.IsNullOrEmpty(pEvent.AppId))
                    {
                        wParam = wCmd.Parameters.Add("AppId", SqlDbType.NVarChar);
                        wParam.Value = string.Concat("%", pEvent.AppId, "%");
                    }

                    

                    using (IDataReader reader = wCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            wEvent = new Event();
                            wEvent.Id = new Guid(reader["Id"].ToString());
                        
                            wEvent.Message.Text = TypeFunctions.ConvertBytesToTextString((Byte[])(reader["Message"]));
                            wEvent.Source = reader["Source"].ToString();
                            wEvent.LogType = (EventType)Enum.Parse(typeof(EventType), reader["LogType"].ToString());
                            wEvent.Machine = reader["Machine"].ToString();
                            wEvent.LogDate = Convert.ToDateTime(reader["LogDate"]);
                            wEvent.User = reader["UserLoginName"].ToString();
                            wEvent.AppId = reader["AppId"].ToString();
                            wEventList.Add(wEvent);
                        }
                    }

                    return wEventList;

                }
                catch (Exception ex)
                {
                    TechnicalException te = new TechnicalException("Error de Fwk.Logging", ex);
                    te.ErrorId = "9004";
                    Fwk.Exceptions.ExceptionHelper.SetTechnicalException<DatabaseTarget>(te);
                    throw te;
                }
            }

        }
  

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventIdList"></param>
        public override void Remove(List<string> eventIdList)
        {

            using (SqlConnection wCnn = new SqlConnection(GetCnnString()))
            using (SqlCommand wCmd = new SqlCommand())
            {
                try
                {
                    wCnn.Open();
                    wCmd.Connection = wCnn;
                    wCmd.CommandType = CommandType.StoredProcedure;
                    wCmd.CommandText = "fwk_Logs_d";
                    SqlParameter wParam = wCmd.Parameters.Add("Id", SqlDbType.UniqueIdentifier);
                     
                    foreach (string id in eventIdList)
                    {
                        wParam.Value = new Guid(id.ToString());
                        wCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    TechnicalException te = new TechnicalException("Error de Fwk.Logging al intentar elimiar log en base de datos", ex);
                    te.ErrorId = "9004";
                    Fwk.Exceptions.ExceptionHelper.SetTechnicalException<DatabaseTarget>(te);
                    throw te;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventIdList"></param>
        public override void Remove(List<Guid> eventIdList)
        {

            using (SqlConnection wCnn = new SqlConnection(GetCnnString()))
            using (SqlCommand wCmd = new SqlCommand())
            {
                try
                {
                    wCnn.Open();
                    wCmd.Connection = wCnn;
                    wCmd.CommandType = CommandType.StoredProcedure;
                    wCmd.CommandText = "fwk_Logs_d";
                    SqlParameter wParam = wCmd.Parameters.Add("Id", SqlDbType.UniqueIdentifier);
                    foreach (Guid id in eventIdList)
                    {
                        wParam.Value = id;
                        wCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    TechnicalException te = new TechnicalException("Error de Fwk.Logging al intentar elimiar log en base de datos", ex);
                    te.ErrorId = "9004";
                    Fwk.Exceptions.ExceptionHelper.SetTechnicalException<DatabaseTarget>(te);
                    throw te;
                }
            }
        }

        string strDb;
        string GetCnnString()
        {
            if (!String.IsNullOrEmpty(strDb)) return strDb;

            if (!String.IsNullOrEmpty(_CnnStringName))
            {
                strDb = System.Configuration.ConfigurationManager.ConnectionStrings[_CnnStringName].ConnectionString;
            }
            else
            {
                strDb = _ConnectionString;
            }

            if (String.IsNullOrEmpty(strDb))
            {
                TechnicalException te = new TechnicalException("Debe especificar cnnStringName en el archivo de configuración.");
                te.ErrorId = "9003";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<DatabaseTarget>(te);
                throw te;
            }
            return strDb;
        }


        #endregion

       
    }
}
