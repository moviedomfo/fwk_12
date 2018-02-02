using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Fwk.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace Fwk.Security
{

    public partial class FwkMembership
    {

        /// <summary>
        /// Retorna el GUID de la aplicación busca en la bse de datos configurada por defecto 
        /// </summary>
        /// <param name="pCompanyId">Nombre de la aplicación </param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>GUID de la aplicacion</returns>
        public static string GetApplicationID(String pCompanyId, string providerName)
        {

            String wApplicationId = String.Empty;
           

            try
            {

                using (SqlConnection cnn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[GetProvider_ConnectionStringName(providerName)].ConnectionString))
                using (SqlCommand cmd = new SqlCommand("aspnet_Personalization_GetApplicationId", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ApplicationName", pCompanyId);
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@ApplicationId";
                    param.SqlDbType = SqlDbType.UniqueIdentifier;
                    param.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(param);
                    cnn.Open();

                    cmd.ExecuteNonQuery();

                    wApplicationId = cmd.Parameters["@ApplicationId"].ToString();
                    return wApplicationId;
                }
            
                  
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
        }



        /// <summary>
        /// Obtiene de la bases de datos aspnet y tabla aspnet_Applications el Guid de la Aplicacion
        /// </summary>
        /// <param name="applicationName">Nombre de la aplicacion. Coincide con CompanyId en la arquitectura</param>
        /// <param name="cnnstringName"></param>
        /// <returns></returns>
        public static Guid GetApplication(string applicationName, string cnnstringName)
        {

            Guid wApplicationNameId = new Guid();
            try
            {

                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[cnnstringName].ConnectionString))
                {

                    aspnet_Application app = dc.aspnet_Applications.Where(p => p.LoweredApplicationName.Equals(applicationName.ToLower())).FirstOrDefault<aspnet_Application>();

                    if (app != null)
                        wApplicationNameId = app.ApplicationId;
                    else
                    {
                        TechnicalException te = new TechnicalException(String.Format(Fwk.Security.Properties.Resource.ApplicationName_NotExist, applicationName, cnnstringName));
                        ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                        te.ErrorId = "4002"; 
                        throw te;
                    }
                }
               return wApplicationNameId;
            }
            catch (TechnicalException tx)
            { throw tx; }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000"; throw te;
            }
        }

    }
}

