using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace WebAPIDispatcher.BC
{
    public class WebAPIDispatcherBC
    {
        public static void Insert_llamada(WebAPIDispatcherBE miniAvatarBE)
        {
            SqlParameter param;
            try
            {
                string connectionStr = GetCnnstring_App();

                using (SqlConnection cnn = new SqlConnection(connectionStr))
                using (SqlCommand cmd = new SqlCommand("dbo.contactos_i", cnn) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    param = new SqlParameter("@CodigoCampania", SqlDbType.VarChar, 50);
                    param.Value = miniAvatarBE.CodigoCampania;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CodigoOrigen", SqlDbType.VarChar, 50);
                    param.Value = miniAvatarBE.CodigoOrigen;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fecha", SqlDbType.DateTime);
                    param.Value = System.DateTime.Now;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Horario", SqlDbType.Bit);
                    param.Value = miniAvatarBE.Horario;
                    cmd.Parameters.Add(param);

                    
                    param = new SqlParameter("@Telefonos", SqlDbType.VarChar, 500);
                    param.Value = miniAvatarBE.Telefonos;
                    cmd.Parameters.Add(param);

                    
                    param = new SqlParameter("@Texto", SqlDbType.VarChar, 500);
                    param.Value = miniAvatarBE.Texto;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IDLead", SqlDbType.Int);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    miniAvatarBE.IDLead = Convert.ToInt32(cmd.Parameters["@IDLead"].Value); 
                }

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<WebAPIDispatcherBE> ContactoByNum(String telefono)
        {
            SqlParameter param;
            List<WebAPIDispatcherBE> list = new List<WebAPIDispatcherBE>();
            WebAPIDispatcherBE item = null;
            try
            {
                string connectionStr = GetCnnstring_App();

                using (SqlConnection cnn = new SqlConnection(connectionStr))
                using (SqlCommand cmd = new SqlCommand("dbo.contactos_g", cnn) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                  

                   

                    param = new SqlParameter("@Telefonos", SqlDbType.VarChar, 500);
                    param.Value = telefono;
                    cmd.Parameters.Add(param);





                    cnn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item = new WebAPIDispatcherBE();
                            item.IDLead= Convert.ToInt32( reader["IDLead"]);
                        }
                    }
                    return list;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        /// <summary>
        /// Busca cadenas de conexión en el archivo de configuracion AppSettings
        /// </summary>
        /// <returns></returns>
        protected static string GetCnnstring_App()
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings["WebAPIDispatcher"] != null)
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["WebAPIDispatcher"].ConnectionString;
            }
            return string.Empty;
        }
    }
}
