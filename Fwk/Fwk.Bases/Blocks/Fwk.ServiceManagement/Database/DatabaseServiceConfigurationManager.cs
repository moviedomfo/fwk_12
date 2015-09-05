using System;
using System.Collections.Generic;
using System.Text;

using Fwk.Transaction;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Fwk.Bases;
using System.Data;
using Fwk.Exceptions;
using System.Data.SqlClient;


namespace Fwk.ServiceManagement
{
	/// <summary>
    /// Manejador de configuración de servicios que trabaja con una base de datos relacional como repositorio de configuración.
	/// </summary>
	/// <remarks>
	/// La base de datos que sirve de repositorio puede estar creada en cualquier producto que sea accesible por los componentes de acceso a datos de Microsoft Enterprise Library.
	/// </remarks>
	/// <date>2008-04-07T00:00:00</date>
	/// <author>moviedo</author>
    internal sealed class DatabaseServiceConfigurationManager
	{



        /// <summary>
        /// Devuelve la configuración de un servicio buscóndolo en la base de datos de configuracón.
        /// </summary>
        /// <param name="serviceName">Nombre del servicio</param>
        /// <param name="applicationId">Identificador de aplicacion a la que pertenece el servicio</param>
        /// <param name="cnnString">Nombre de cadena de conexion</param>
	    /// <returns></returns>
        internal static ServiceConfiguration GetServiceConfiguration(string serviceName, string applicationId, string cnnString)
        {
            ServiceConfiguration wServiceConfiguration = null; ;

          
            try
            {
                Database wBPConfig = DatabaseFactory.CreateDatabase(cnnString);
                System.Data.Common.DbCommand dbCommand = wBPConfig.GetStoredProcCommand("fwk_Service_g_Name");
                wBPConfig.AddInParameter(dbCommand, "Name", System.Data.DbType.String, serviceName);
                if (!string.IsNullOrEmpty(applicationId))
                    wBPConfig.AddInParameter(dbCommand, "ApplicationId", System.Data.DbType.String, applicationId);


                using (IDataReader dataReader = wBPConfig.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        wServiceConfiguration = GetServiceConfigurationFromRow(dataReader);
                    }


                    if (wServiceConfiguration == null)
                    {
                        throw new Fwk.Exceptions.TechnicalException(string.Concat("El servicio " , serviceName , " no se encuentra configurado."));
                    }

                }
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.ServiceManagement  al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseServiceConfigurationManager>(te);
                te.ErrorId = "7200";
                throw te;

            }
            return wServiceConfiguration;
        }

		/// <summary>
        /// Recupera la configuración de todos los servicios de negocio.
		/// </summary>
        /// <param name="applicationId">Identificador de aplicacion a la que pertenece el servicio</param>
        /// <param name="cnnString">Nombre de cadena de conexion</param>
		/// <returns>Lista de configuraciones de servicios de negocio.</returns>
        internal static ServiceConfigurationCollection GetAllServices(string applicationId, string cnnString)
		{
          
         
			ServiceConfigurationCollection wServiceConfigurationCollection = new ServiceConfigurationCollection();
            
            try
            {
                Database wBPConfig = DatabaseFactory.CreateDatabase(cnnString);
                System.Data.Common.DbCommand dbCommand = wBPConfig.GetStoredProcCommand("fwk_Service_s_All");
                if (!string.IsNullOrEmpty(applicationId))
                    wBPConfig.AddInParameter(dbCommand, "ApplicationId", System.Data.DbType.String, applicationId);

                using (IDataReader dataReader = wBPConfig.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        ServiceConfiguration wServiceConfiguration = GetServiceConfigurationFromRow(dataReader);
                        wServiceConfigurationCollection.Add(wServiceConfiguration);
                    }
                }
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.ServiceManagement  al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseServiceConfigurationManager>(te);
                te.ErrorId = "7200";
                throw te;

            }
			return wServiceConfigurationCollection;
		}

       
		/// <summary>
        /// Almacena la configuración de un servicio de negocio.
		/// </summary>
        /// <param name="serviceName">Nombre del servicio a actualizar.</param>
        /// <param name="pServiceConfiguration">Configuración del servicio de negocio.</param>
        /// <param name="applicationId">Identificador de aplicacion a la que pertenece el servicio</param>
        /// <param name="cnnString">Nombre de cadena de conexion</param>
        internal static void SetServiceConfiguration(String serviceName, ServiceConfiguration pServiceConfiguration, string applicationId, string cnnString)
		{
            
            if (GetServiceConfiguration(serviceName,applicationId,cnnString) == null)
            {
                Fwk.Exceptions.TechnicalException wTex = new Fwk.Exceptions.TechnicalException(string.Concat("El servicio " , pServiceConfiguration.Name , " no se actualizó por que no se encontro configurado en la base de datos."));
                wTex.ErrorId = "7002";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<DatabaseServiceConfigurationManager>(wTex);
                throw wTex;
            }
            try
            {
                Database wBPConfig = DatabaseFactory.CreateDatabase(cnnString);

                using (System.Data.Common.DbCommand wCmd = wBPConfig.GetStoredProcCommand("fwk_Service_u"))
                {

                    wBPConfig.AddInParameter(wCmd, "UpdateServiceName", System.Data.DbType.String, serviceName);
                    wBPConfig.AddInParameter(wCmd, "Name", System.Data.DbType.String, pServiceConfiguration.Name);
                    wBPConfig.AddInParameter(wCmd, "Description", System.Data.DbType.String, pServiceConfiguration.Description);
                    wBPConfig.AddInParameter(wCmd, "Handler", System.Data.DbType.String, pServiceConfiguration.Handler);
                    wBPConfig.AddInParameter(wCmd, "Request", System.Data.DbType.String, pServiceConfiguration.Request);
                    wBPConfig.AddInParameter(wCmd, "Response", System.Data.DbType.String, pServiceConfiguration.Response);
                    wBPConfig.AddInParameter(wCmd, "Available", System.Data.DbType.String, pServiceConfiguration.Available);
                    wBPConfig.AddInParameter(wCmd, "Audit", System.Data.DbType.String, pServiceConfiguration.Audit);
                    wBPConfig.AddInParameter(wCmd, "TransactionalBehaviour", System.Data.DbType.String, Enum.GetName(typeof(TransactionalBehaviour), pServiceConfiguration.TransactionalBehaviour));
                    wBPConfig.AddInParameter(wCmd, "IsolationLevel", System.Data.DbType.String, Enum.GetName(typeof(Fwk.Transaction.IsolationLevel), pServiceConfiguration.IsolationLevel));
                    wBPConfig.AddInParameter(wCmd, "ApplicationId", System.Data.DbType.String, pServiceConfiguration.ApplicationId);
                    wBPConfig.AddInParameter(wCmd, "CreatedUserName", System.Data.DbType.String, pServiceConfiguration.CreatedUserName);


             

                    if (Fwk.HelperFunctions.DateFunctions.IsSqlDateTimeOutOverflow(pServiceConfiguration.CreatedDateTime) == false)
                        wBPConfig.AddInParameter(wCmd, "CreatedDateTime", System.Data.DbType.DateTime, pServiceConfiguration.CreatedDateTime);

                    int wAffected = wBPConfig.ExecuteNonQuery(wCmd);

                    if (wAffected == 0)
                    {
                        Fwk.Exceptions.TechnicalException wTex = new Fwk.Exceptions.TechnicalException("El servicio " + pServiceConfiguration.Name + " no se actualizó por que no se encontro configurado en la base de datos.");
                        wTex.ErrorId = "7002";
                        Fwk.Exceptions.ExceptionHelper.SetTechnicalException<DatabaseServiceConfigurationManager>(wTex);
                        throw wTex;
                    }

                }
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.ServiceManagement  al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseServiceConfigurationManager>(te);
                te.ErrorId = "7200";
                throw te;

            }
		}

		/// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
		/// </summary>
        /// <param name="pServiceConfiguration">Configuración del servicio de negocio.</param>
        /// <param name="applicationId">Identificador de aplicacion a la que pertenece el servicio</param>
        /// <param name="cnnString">Nombre de cadena de conexion</param>
		/// <date>2010-04-13T00:00:00</date>
		/// <author>moviedo</author>
        internal static void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration, string applicationId, string cnnString)
		{

            try
            {
                Database wBPConfig = DatabaseFactory.CreateDatabase(cnnString);

                using (System.Data.Common.DbCommand wCmd = wBPConfig.GetStoredProcCommand("fwk_Service_i"))
                {
                    wBPConfig.AddInParameter(wCmd, "Name", System.Data.DbType.String, pServiceConfiguration.Name);
                    wBPConfig.AddInParameter(wCmd, "Description", System.Data.DbType.String, pServiceConfiguration.Description);
                    wBPConfig.AddInParameter(wCmd, "Handler", System.Data.DbType.String, pServiceConfiguration.Handler);
                    wBPConfig.AddInParameter(wCmd, "Request", System.Data.DbType.String, pServiceConfiguration.Request);
                    wBPConfig.AddInParameter(wCmd, "Response", System.Data.DbType.String, pServiceConfiguration.Response);
                    wBPConfig.AddInParameter(wCmd, "Available", System.Data.DbType.String, pServiceConfiguration.Available);
                    wBPConfig.AddInParameter(wCmd, "Audit", System.Data.DbType.String, pServiceConfiguration.Audit);
                    wBPConfig.AddInParameter(wCmd, "TransactionalBehaviour", System.Data.DbType.String, Enum.GetName(typeof(TransactionalBehaviour), pServiceConfiguration.TransactionalBehaviour));
                    wBPConfig.AddInParameter(wCmd, "IsolationLevel", System.Data.DbType.String, Enum.GetName(typeof(Fwk.Transaction.IsolationLevel), pServiceConfiguration.IsolationLevel));

                    wBPConfig.AddInParameter(wCmd, "ApplicationId", System.Data.DbType.String, pServiceConfiguration.ApplicationId);
                    wBPConfig.AddInParameter(wCmd, "CreatedUserName", System.Data.DbType.String, pServiceConfiguration.CreatedUserName);

                   

                    if (Fwk.HelperFunctions.DateFunctions.IsSqlDateTimeOutOverflow(pServiceConfiguration.CreatedDateTime) == false)
                        wBPConfig.AddInParameter(wCmd, "CreatedDateTime", System.Data.DbType.DateTime, pServiceConfiguration.CreatedDateTime);

                    wBPConfig.ExecuteNonQuery(wCmd);
                }
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.ServiceManagement  al realizar operaciones con la base de datos \r\n", ex);

                ExceptionHelper.SetTechnicalException<DatabaseServiceConfigurationManager>(te);
                if (ex is SqlException && ((SqlException)ex).Number == 2627)
                {
                    te.AddMessage_Top("El servicio ya exiiste. Clave duplicada ");
                }

                
                te.ErrorId = "7200";
                throw te;

            }
		}


		/// <summary>
        /// Elimina la configuración de un servicio de negocio.
		/// </summary>
        /// <param name="serviceName">Nombre del servicio.</param>
		/// <param name="applicationId">Identificador de aplicacion a la que pertenece el servicio</param>
		/// <param name="cnnString">Nombre de cadena de conexion</param>
        internal static void DeleteServiceConfiguration(string serviceName, string applicationId, string cnnString)
        {

            try
            {
                Database wBPConfig = DatabaseFactory.CreateDatabase(cnnString);

                using (System.Data.Common.DbCommand wCmd = wBPConfig.GetStoredProcCommand("fwk_Service_d"))
                {
                    wBPConfig.AddInParameter(wCmd, "Name", System.Data.DbType.String, serviceName);

                    int wAffected = wBPConfig.ExecuteNonQuery(wCmd);

                    if (wAffected == 0)
                    {
                      
                        TechnicalException te = new TechnicalException(string.Concat("El servicio " , serviceName , " no se eliminó por no encontrarse configurado."));
                        ExceptionHelper.SetTechnicalException<DatabaseServiceConfigurationManager>(te);
                        te.ErrorId = "7002";
                        throw te;
                    }
                }
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.ServiceManagement  al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseServiceConfigurationManager>(te);
                te.ErrorId = "7200";
                throw te;

            }
        }

	

		#region < Private methods >

		/// <summary>
        /// Mapea los campos de una datarow a propiedades de una configuración de servicio.
		/// </summary>
		/// <returns>Configuracion de servicio de negocio.</returns>
		/// <date>2008-04-13T00:00:00</date>
		/// <author>moviedo</author>
        static ServiceConfiguration GetServiceConfigurationFromRow(IDataReader pServiceRow)
        {
            ServiceConfiguration wServiceConfiguration = new ServiceConfiguration();

            wServiceConfiguration.Name = Convert.ToString(pServiceRow["name"]).Trim();
            wServiceConfiguration.Description = Convert.ToString(pServiceRow["Description"]).Trim();
            wServiceConfiguration.Handler = Convert.ToString(pServiceRow["Handler"]).Trim();
            wServiceConfiguration.Request = Convert.ToString(pServiceRow["Request"]).Trim();
            wServiceConfiguration.Response = Convert.ToString(pServiceRow["Response"]).Trim();
            wServiceConfiguration.Available = Convert.ToBoolean(pServiceRow["Available"]);
            wServiceConfiguration.Audit = Convert.ToBoolean(pServiceRow["Audit"]);
            wServiceConfiguration.TransactionalBehaviour = (TransactionalBehaviour)Enum.Parse(typeof(TransactionalBehaviour), pServiceRow["TransactionalBehaviour"].ToString());
            wServiceConfiguration.IsolationLevel = (Fwk.Transaction.IsolationLevel)Enum.Parse(typeof(Fwk.Transaction.IsolationLevel), pServiceRow["IsolationLevel"].ToString());
            if (pServiceRow["CreatedUserName"] != DBNull.Value)
                wServiceConfiguration.CreatedUserName = Convert.ToString(pServiceRow["CreatedUserName"]).Trim();

            if (pServiceRow["CreatedDateTime"] != DBNull.Value)
                wServiceConfiguration.CreatedDateTime = Convert.ToDateTime(pServiceRow["CreatedDateTime"]);
            if (pServiceRow["ApplicationId"] != DBNull.Value)
            wServiceConfiguration.ApplicationId = Convert.ToString(pServiceRow["ApplicationId"]).Trim();


            return wServiceConfiguration;

        }
		#endregion






       
       
    }
}
