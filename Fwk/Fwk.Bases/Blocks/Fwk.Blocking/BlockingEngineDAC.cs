using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using Fwk.Configuration;
using Fwk.Exceptions;
using System.Diagnostics;

namespace Fwk.Blocking
{
    /// <summary>
    /// Clase de acceso a datos para las tablas de blocking.-
    /// </summary>
    internal class BlockingEngineDAC
    {
        static string msz_ConnectionString;
        static BlockingEngineDAC()
        {
            try
            {
                if (ConfigurationManager.GetProperty("BlockingModel", "ConnectionString") != null)
                    msz_ConnectionString = ConfigurationManager.GetProperty("BlockingModel", "ConnectionString");

            }
            catch
            {
                if (String.IsNullOrEmpty(msz_ConnectionString))
                    msz_ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BlockingModel"].ConnectionString;
            }

            if (String.IsNullOrEmpty(msz_ConnectionString))
                msz_ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BlockingModel"].ConnectionString;

            if (String.IsNullOrEmpty(msz_ConnectionString))
                throw new TechnicalException("Falta la ConnectionStrings BlockingModel");
        }

        /// <summary>
        /// Agrega una marca de bloqueo para una instancia de
        /// BlockingMark.
        /// </summary>
        /// <param name="pIBlockingMark">pIBlockingMark que contiene a la BlockingMark.
        /// Se incluye debido a que la tabla BlockingMarks está desnormalizada y
        /// requiere algunos campos de esta Clase.</param>
        /// <param name="pBlockingMark">BlockingMark a crear.</param>
        /// <param name="pCustomParametersToInsert">BlockingMark a crear.</param>
        /// <param name="pBlockingTable">BlockingMark a crear.</param>
        internal static int AddMark(IBlockingMark pIBlockingMark, List<SqlParameter> pCustomParametersToInsert, String pBlockingTable)
        {
            SqlParameter wParam;

            using (SqlConnection wCnn = new SqlConnection(msz_ConnectionString))
            using (SqlCommand wCmd = new SqlCommand(pBlockingTable + "_i", wCnn))
            {
                wCmd.CommandType = CommandType.StoredProcedure;

                if (pCustomParametersToInsert != null)
                    if (pCustomParametersToInsert.Count != 0)
                        wCmd.Parameters.AddRange(pCustomParametersToInsert.ToArray());


                wParam = wCmd.Parameters.Add("@BlockingId", SqlDbType.Int);
                wParam.Direction = ParameterDirection.Output;

                //TableName
                wParam = wCmd.Parameters.Add("@TableName", SqlDbType.VarChar, 100);
                wParam.Value = pIBlockingMark.TableName;

                //Attribute
                wParam = wCmd.Parameters.Add("@Attribute", SqlDbType.VarChar, 100);
                wParam.Value = pIBlockingMark.Attribute;
                //AttValue
                wParam = wCmd.Parameters.Add("@AttValue", SqlDbType.VarChar, 100);
                wParam.Value = pIBlockingMark.AttValue;

                wParam = wCmd.Parameters.Add("@TTL", SqlDbType.Int);
                wParam.Value = pIBlockingMark.TTL;

                wParam = wCmd.Parameters.Add("@UserName", SqlDbType.VarChar, 100);
                wParam.Value = pIBlockingMark.User;

                wParam = wCmd.Parameters.Add("@FwkGuid", SqlDbType.UniqueIdentifier);
                wParam.Value = pIBlockingMark.FwkGuid;

                wParam = wCmd.Parameters.Add("@Process", SqlDbType.VarChar, 100);
                if (String.IsNullOrEmpty(pIBlockingMark.Process))
                    wParam.Value = null;
                else
                    wParam.Value = pIBlockingMark.Process;

                wCnn.Open();
                wCmd.ExecuteNonQuery();

                return int.Parse(wCmd.Parameters["@BlockingId"].Value.ToString());

            }
        }

        /// <summary>
        /// Eliminar marca de blocking.-
        /// </summary>
        internal static void RemoveMark(IBlockingMark pBlockingMark)
        {
            /// Una vez que el Contexto pasó los controles, se procede a la liberación.
            using (SqlConnection wCnn = new SqlConnection(msz_ConnectionString))
            using (SqlCommand wCmd = new SqlCommand(pBlockingMark.TableName + "_d", wCnn))
            {

                wCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter wParam;

                wParam = wCmd.Parameters.Add("@BlockingId", SqlDbType.Int);
                wParam.Value = pBlockingMark.BlockingId;


                wParam = wCmd.Parameters.Add("@FwkGuid", SqlDbType.UniqueIdentifier);
                wParam.Value = pBlockingMark.FwkGuid;

                wCnn.Open();

                wCmd.ExecuteNonQuery();

            }
        }

        /// <summary>
        /// Limpia las marcas de dicho usuario
        /// </summary>
        /// <param name="pBlockingTable"></param>
        /// <param name="pUserName"></param>
        internal static void ClearBlockingMarksByUserName(String pBlockingTable, String pUserName)
        {
            /// Declaro conexión y comando
            using (SqlConnection wCnn = new SqlConnection(msz_ConnectionString))
            using (SqlCommand wCmd = new SqlCommand(pBlockingTable + "_d_ByUserName", wCnn))
            {

                wCmd.CommandType = CommandType.StoredProcedure;

                /// Se setean los parámetros.
                SqlParameter wParam;

                wParam = wCmd.Parameters.Add("@UserName", SqlDbType.VarChar, 32);
                wParam.Value = pUserName;

                /// Se abre la conexión y se ejecuta el comando.
                wCnn.Open();
                wCmd.ExecuteNonQuery();

            }
        }

        /// <summary>
        /// Limpia todas las marcas para las cuales se cumplió el TTL.
        /// Este método se ejecuta desde un servicio.
        /// </summary>
        /// <param name="pBlockingTable">Nombre de la tabla de marcas de bloqueo.-</param>
        /// <returns>Retorna la cantidad de marcas borradas.</returns>
        internal static int ClearBlockingMarks(String pBlockingTable)
        {
            /// Declaro conexión y comando
            using (SqlConnection wCnn = new SqlConnection(msz_ConnectionString))
            using (SqlCommand wCmd = new SqlCommand(pBlockingTable + "_d_clear", wCnn))
            {

                wCmd.CommandType = CommandType.StoredProcedure;

                /// Se setean los parámetros.
                SqlParameter wParam;

                wParam = wCmd.Parameters.Add("@Count", SqlDbType.Int);
                wParam.Value = 0;
                wParam.Direction = ParameterDirection.Output;

                /// Se abre la conexión y se ejecuta el comando.
                wCnn.Open();
                wCmd.ExecuteNonQuery();

                /// Se retorna la cantidad de marcas borradas.
                return int.Parse(wCmd.Parameters["@Count"].Value.ToString());

            }
        }

        /// <summary>
        /// Verifica si existe marcas. Si exite alguna marca retorna el registro.
        /// </summary>
        /// <param name="pIBlockingMark">Marca</param>
        /// <param name="pBlockingTable">Nombre de la tabla de Blocking</param>
        /// <returns>Registro blocking</returns>
        internal static bool Exists(IBlockingMark pIBlockingMark, String pBlockingTable)
        {
            SqlParameter wParam;
            using (SqlConnection wCnn = new SqlConnection(msz_ConnectionString))
            using (SqlCommand wCmd = new SqlCommand(pBlockingTable + "_g_Exist", wCnn))
            {
                Boolean wExist;

                wCmd.CommandType = CommandType.StoredProcedure;

                wParam = wCmd.Parameters.Add("@Exist", SqlDbType.Bit);
                wParam.Direction = ParameterDirection.Output;

                if (pIBlockingMark.FwkGuid != null)
                {
                    wParam = wCmd.Parameters.Add("@FwkGuid", SqlDbType.UniqueIdentifier);
                    wParam.Value = pIBlockingMark.FwkGuid;
                }

                //BlockingId
                if (pIBlockingMark.BlockingId != null)
                {
                    wParam = wCmd.Parameters.Add("@BlockingId", SqlDbType.Int);
                    wParam.Value = pIBlockingMark.BlockingId;
                }

                wCnn.Open();
                wCmd.ExecuteNonQuery();
                wExist = Boolean.Parse(wCmd.Parameters["@Exist"].Value.ToString());

                return wExist;

            }
        }

        /// <summary>
        /// Verifica si existe marcas. Si exite alguna marca retorna los usuarios.
        /// </summary>
        /// <param name="pIBlockingMark">Marca</param>
        /// <param name="pCustomParametersExist">Parametros personalizados</param>
        /// <param name="pBlockingTable">Parametros personalizados</param>
        /// <returns></returns>
        internal static List<String> ExistsUsers(IBlockingMark pIBlockingMark, List<SqlParameter> pCustomParametersExist, String pBlockingTable)
        {
            List<string> strUserList = new List<string>();
            SqlParameter wParam;

            using (SqlConnection wCnn = new SqlConnection(msz_ConnectionString))
            using (SqlCommand wCmd = new SqlCommand(pBlockingTable + "_g_ExistUser", wCnn))
            {

                wCmd.CommandType = CommandType.StoredProcedure;
                if (pCustomParametersExist != null)
                    if (pCustomParametersExist.Count != 0)
                        wCmd.Parameters.AddRange(pCustomParametersExist.ToArray());

                if (pIBlockingMark.FwkGuid != null)
                {
                    wParam = wCmd.Parameters.Add("@FwkGuid", SqlDbType.UniqueIdentifier);
                    wParam.Value = pIBlockingMark.FwkGuid;
                }

                //BlockingId
                if (pIBlockingMark.BlockingId != null)
                {
                    wParam = wCmd.Parameters.Add("@BlockingId", SqlDbType.Int);
                    wParam.Value = pIBlockingMark.BlockingId;
                }

                //Attribute
                if (pIBlockingMark.Attribute != null)
                {
                    wParam = wCmd.Parameters.Add("@Attribute", SqlDbType.VarChar, 50);
                    wParam.Value = pIBlockingMark.Attribute;
                }
                //AttValue
                if (pIBlockingMark.AttValue != null)
                {
                    wParam = wCmd.Parameters.Add("@AttValue", SqlDbType.VarChar, 50);
                    wParam.Value = pIBlockingMark.AttValue;
                }

                //Process
                if (pIBlockingMark.Process != null)
                {
                    wParam = wCmd.Parameters.Add("@Process", SqlDbType.VarChar, 50);
                    wParam.Value = pIBlockingMark.Process;
                }

                //TableName
                if (pIBlockingMark.TableName != null)
                {
                    wParam = wCmd.Parameters.Add("@TableName", SqlDbType.VarChar, 50);
                    wParam.Value = pIBlockingMark.TableName;
                }

                wCnn.Open();

                IDataReader reader = wCmd.ExecuteReader();
                while (reader.Read())
                {
                    strUserList.Add(reader["UserName"].ToString());
                }
               return strUserList;
            }
        }

        /// <summary>
        /// Obtiene una o valraias marcas de bloqueo 
        /// </summary>
        /// <param name="pIBlockingMark">Clase que implementa IBlockingMark</param>
        /// <param name="pCustomParametersGetByParam">Parametros para una IBlockingMark personalizada</param>
        /// <returns>Tabla con laas marcas obtenidas.-</returns>
        internal static DataTable GetByParam(IBlockingMark pIBlockingMark, List<SqlParameter> pCustomParametersGetByParam)
        {
            DataSet wDS = new DataSet();
            SqlParameter wParam;
            string wUsuario = string.Empty;

            using (SqlConnection wCnn = new SqlConnection(msz_ConnectionString))
            using (SqlCommand wCmd = new SqlCommand(pIBlockingMark.TableName + "_s", wCnn))
            {

                wCmd.CommandType = CommandType.StoredProcedure;
                if (pCustomParametersGetByParam != null)
                {
                    if (pCustomParametersGetByParam.Count != 0)
                    {
                        wCmd.Parameters.AddRange(pCustomParametersGetByParam.ToArray());
                    }
                }

                //BlockingId
                wParam = wCmd.Parameters.Add("@BlockingId", SqlDbType.Int, 4);
                wParam.Value = pIBlockingMark.BlockingId;

                //TableName
                wParam = wCmd.Parameters.Add("@TableName", SqlDbType.VarChar, 100);
                wParam.Value = pIBlockingMark.TableName;

                //Attribute
                wParam = wCmd.Parameters.Add("@Attribute", SqlDbType.VarChar, 100);
                wParam.Value = pIBlockingMark.Attribute;

                //TTL
                wParam = wCmd.Parameters.Add("@TTL", SqlDbType.Int, 4);
                wParam.Value = pIBlockingMark.TTL;

                //UserName
                wParam = wCmd.Parameters.Add("@UserName", SqlDbType.VarChar, 32);
                wParam.Value = pIBlockingMark.User;

                //FwkGuid
                wParam = wCmd.Parameters.Add("@FwkGuid", SqlDbType.UniqueIdentifier);
                wParam.Value = pIBlockingMark.FwkGuid;

                //DueDate
                wParam = wCmd.Parameters.Add("@DueDate", SqlDbType.DateTime);
                wParam.Value = pIBlockingMark.DueDate;

                //Process
                wParam = wCmd.Parameters.Add("@Process", SqlDbType.VarChar, 50);
                wParam.Value = pIBlockingMark.Process;

                SqlDataAdapter wDA = new SqlDataAdapter(wCmd);

                wDA.Fill(wDS);
                return wDS.Tables[0];

            }
        }

        /// <summary>Obtiene una o varias marcas de bloqueo</summary>
        /// <param name="pIBlockingMark">Clase que implementa IBlockingMark</param>
        /// <returns>Tabla con las marcas obtenidas
        /// Datatable con BlockingId,TableName,Attribute,AttValue,TTL,UserName,FwkGuid,DueDate,Process</returns>
        /// <create>hebraida</create>
        /// <date>2010-07-15</date>
        internal static DataTable GetByParam(IBlockingMark pIBlockingMark)
        {
            DataSet wDS = new DataSet();
            SqlParameter wParam;
            string wUsuario = string.Empty;

            using (SqlConnection wCnn = new SqlConnection(msz_ConnectionString))
            using (SqlCommand wCmd = new SqlCommand("BlockingMarks_s", wCnn))
            {

                wCmd.CommandType = CommandType.StoredProcedure;

                //BlockingId
                if (pIBlockingMark.BlockingId != 0)
                {
                    wParam = wCmd.Parameters.Add("@BlockingId", SqlDbType.Int, 4);
                    wParam.Value = pIBlockingMark.BlockingId;
                }

                //TableName
                if (!string.IsNullOrEmpty(pIBlockingMark.TableName))
                {
                    wParam = wCmd.Parameters.Add("@TableName", SqlDbType.VarChar, 100);
                    wParam.Value = pIBlockingMark.TableName;
                }

                //Attribute
                if (!string.IsNullOrEmpty(pIBlockingMark.Attribute))
                {
                    wParam = wCmd.Parameters.Add("@Attribute", SqlDbType.VarChar, 100);
                    wParam.Value = pIBlockingMark.Attribute;
                }

                //AttValue
                if (!string.IsNullOrEmpty(pIBlockingMark.AttValue))
                {
                    wParam = wCmd.Parameters.Add("@AttValue", SqlDbType.VarChar, 100);
                    wParam.Value = pIBlockingMark.AttValue;
                }

                

                //UserName
                if (!string.IsNullOrEmpty(pIBlockingMark.User))
                {
                    wParam = wCmd.Parameters.Add("@UserName", SqlDbType.VarChar, 32);
                    wParam.Value = pIBlockingMark.User;
                }

                //FwkGuid
                if (pIBlockingMark.FwkGuid.HasValue)
                {
                    wParam = wCmd.Parameters.Add("@FwkGuid", SqlDbType.UniqueIdentifier);
                    wParam.Value = pIBlockingMark.FwkGuid;
                }

                //DueDate
                if (pIBlockingMark.DueDate.HasValue)
                {
                    wParam = wCmd.Parameters.Add("@DueDate", SqlDbType.DateTime);
                    wParam.Value = pIBlockingMark.DueDate;
                }

                //Process
                if (!string.IsNullOrEmpty(pIBlockingMark.Process))
                {
                    wParam = wCmd.Parameters.Add("@Process", SqlDbType.VarChar, 50);
                    wParam.Value = pIBlockingMark.Process;
                }

                SqlDataAdapter wDA = new SqlDataAdapter(wCmd);

                wDA.Fill(wDS);
                return wDS.Tables[0];

            }
        }

        /// <summary>
        /// Ejecuta una consulta Sql contra el servidor que esté configurado
        /// para el servicio de bloqueo
        /// </summary>
        /// <param name="pQuery">Consulta a realizar</param>
        /// <returns>DataSet con el resultado de la consulta</returns>
        internal DataSet ExecuteQuery(string pQuery)
        {
            DataSet wDs = new DataSet();
            using (SqlConnection wCnn = new SqlConnection(msz_ConnectionString))
            using (SqlCommand wCmd = new SqlCommand())
            {

                wCmd.CommandType = CommandType.Text;
                wCmd.Connection = wCnn;
                wCmd.CommandText = pQuery;

                wCnn.Open();
                SqlDataAdapter wDa = new SqlDataAdapter(wCmd);

                wDa.Fill(wDs);
                return wDs;

            }
        }
    }
}