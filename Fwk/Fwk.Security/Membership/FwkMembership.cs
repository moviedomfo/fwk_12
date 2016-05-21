using System;
using System.Collections.Generic;
using System.Web.Security;
using Fwk.Security.Common;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

using System.Text;
using System.Linq;
using System.Web.Configuration;
using System.Configuration;
using Fwk.Security.Properties;
using Fwk.Exceptions;
namespace Fwk.Security
{
    /// <summary>
    /// Esta clase contiene metodos estaticos para interactuar con seguridad basada en memberships de asp_netdb 
    /// 
    /// Permite trabajar con :
    /// Roles
    /// Usuarios
    /// Membership Applications
    /// Reglas
    /// Proveedores de autorizacion
    /// 
    /// 
    /// Este componente require que la base de datos a la que el proveedor de membership apunta contenga las tablas que se definene
    /// en el siguiente script: Fwk_Security.sql
    /// </summary>
    public partial class FwkMembership
    {
       /// <summary>
       /// Dictionary con (providerName,cnnstringName)
       /// </summary>
        static Dictionary<string, string> providerCnnStrings;
      

        //static SecuritySettings _SecuritySettings;
        static MembershipSection _MembershipSection;

        /// <summary>
        /// Constructor estatico de las FwkMembership
        /// Inicia las secciones configuradas securityConfiguration y system.web/membership
        /// </summary>
        static FwkMembership()
        {
            //_SecuritySettings = (SecuritySettings)System.Configuration.ConfigurationManager.GetSection("securityConfiguration");
            _MembershipSection = (MembershipSection)System.Configuration.ConfigurationManager.GetSection("system.web/membership");
            providerCnnStrings = new Dictionary<string, string>();
        }



        /// <summary>
        /// Obtiene la lista de proovedores membership
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllMembershiproviderNameArray()
        {
            List<string> list = new List<string>();
            foreach (MembershipProvider m in System.Web.Security.Membership.Providers)
            {
                if(!m.Name.Equals("AspNetSqlMembershipProvider"))
                    list.Add(m.Name);
            }

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerName"></param>
        /// <returns></returns>
        public static RoleProvider GetRoleProvider(string providerName)
        {
            try
            {
                RoleProvider rol = Roles.Providers[providerName];
        
                if (rol == null)
                {
                    TechnicalException te = new TechnicalException(string.Format(Resource.ProviderNameNotFound, providerName, "rol"));
                    te.ErrorId = "4001";
                    //te.Source = "FwkMembership block";
                    Fwk.Exceptions.ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                    throw te;

                }
                return rol;
            }
            catch (System.Configuration.Provider.ProviderException pe)
            {
                StringBuilder err = new StringBuilder("El la configuracion RoleProvider lanzo el siguiente error:");
                err.AppendLine( pe.Message);
                err.AppendLine("Revise la configuraciopn del porveedor por defecto que este correcta (cadena de conexion, application Name, etc)" );

                //if (pe.Message.Contains("The connection name") || pe.Message.Contains("was not found in the applications configuration or the connection string is empty."))
                //{
                    
                //}

                TechnicalException te = new TechnicalException(err.ToString());
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
            catch (System.Configuration.ConfigurationException c)
            {
                TechnicalException te = new TechnicalException(Resource.RoleProviderConfigError, c);
                te.ErrorId = "4001";
                //te.Source = "FwkMembership block";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                throw te;
            }
           
          
        }
        /// <summary>
        /// Esta funcion permite encontrar el proveedor Sql configurado por medio de su nombre
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static SqlMembershipProvider GetSqlMembershipProvider(string providerName)
        {
            SqlMembershipProvider wSqlMembershipProvider;

            if (string.IsNullOrEmpty(providerName))
                wSqlMembershipProvider = (SqlMembershipProvider)System.Web.Security.Membership.Provider;
            else
                wSqlMembershipProvider = (SqlMembershipProvider)System.Web.Security.Membership.Providers[providerName];

            if (wSqlMembershipProvider == null)
            {
                TechnicalException te = new TechnicalException(string.Format(Resource.ProviderNameNotFound, providerName, "membership"));
                te.ErrorId = "4001";
                //te.Source = "FwkMembership block";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                throw te;
            }

            return wSqlMembershipProvider;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerName"></param>
        /// <returns></returns>
        public static string GetProvider_ConnectionString(string providerName)
        {
            string cnnStringName  = GetProvider_ConnectionStringName(providerName);
            if (System.Configuration.ConfigurationManager.ConnectionStrings[cnnStringName] != null)
                return System.Configuration.ConfigurationManager.ConnectionStrings[cnnStringName].ConnectionString;
            else
            {
                TechnicalException te = new TechnicalException(string.Format(Resource.ConnectionStringNotExist,cnnStringName, providerName));
                te.ErrorId = "4000";
                //te.Source = "FwkMembership block";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                throw te;
            }
        }
        /// <summary>
        /// Obtiene la cadena de coneccion relacionada al proveedor
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static string GetProvider_ConnectionStringName(string providerName)
        {

            if (string.IsNullOrEmpty(providerName))
            {
                if (providerCnnStrings.ContainsKey(System.Web.Security.Membership.Provider.Name))
                    return providerCnnStrings[System.Web.Security.Membership.Provider.Name];
            }
            else
            {
                if (providerCnnStrings.ContainsKey(providerName))
                    return providerCnnStrings[providerName];
            }

            if (_MembershipSection != null)
            {
                ProviderSettings wProviderSettings;
            
               
                if (string.IsNullOrEmpty(providerName))
                    wProviderSettings = ((ProviderSettings)(_MembershipSection.Providers[System.Web.Security.Membership.Provider.Name]));
                else
                     wProviderSettings = ((ProviderSettings)(_MembershipSection.Providers[providerName]));

                providerCnnStrings.Add(providerName, wProviderSettings.Parameters["connectionStringName"].ToString());

                if (wProviderSettings != null)
                {
                    return providerCnnStrings[providerName]; 
                }
            }
            return string.Empty;
        }


        /// <summary>
        ///  Obtiene el mensaje de error para las constantes<see cref="MembershipCreateStatus"/> (Ingles)
        /// </summary>
        /// <param name="status">MembershipCreateStatus</param>
        /// <returns>Mensaje de error</returns>
        public static string GetErrorMessage(MembershipCreateStatus status)
        {
            switch (status)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Username already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A username for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

        /// <summary>
        /// Construye la lista de usuarios y de roles desde la expresion de la regla.-
        /// </summary>
        /// <param name="assignedRoleList"></param>
        /// <param name="excludeUserList"></param>
        /// <returns></returns>
        public static string BuildRuleExpression(List<Rol> assignedRoleList, List<User> excludeUserList)
        {
            StringBuilder wexpression = new StringBuilder();

            #region included roles
            if (assignedRoleList.Count != 0)
            {
                wexpression.Append("(");
                foreach (Rol rol in assignedRoleList)
                {
                    wexpression.Append("R:");
                    wexpression.Append(rol.RolName);
                    wexpression.AppendLine(" OR ");
                }
                wexpression.Remove(wexpression.Length - 5, 5);
                wexpression.Append(")");
            }
            #endregion

            #region Excluded users
            if (excludeUserList.Count != 0)
            {
                if (assignedRoleList.Count != 0)
                    wexpression.Append(" AND ");

                wexpression.Append("NOT (");
                foreach (User user in excludeUserList)
                {
                    wexpression.Append("I:");
                    wexpression.Append(user.UserName);
                    wexpression.AppendLine(" OR ");
                }
                wexpression.Remove(wexpression.Length - 5, 5);
                wexpression.Append(")");
            }
            #endregion

            return wexpression.ToString();
        }


        /// <summary>
        /// Retorba las lista de usuarios y roles desde la expresion de la regla
        /// </summary>
        /// <param name="wexpression"></param>
        /// <param name="assignedRoleList"></param>
        /// <param name="excludeUserList"></param>
        public static void BuildRolesAndUsers_FromRuleExpression(string wexpression, out RolList assignedRoleList, out UserList excludeUserList)
        {
            Rol wRol;
            User wUser;
            assignedRoleList = new RolList();
            excludeUserList = new UserList();

            StringBuilder exp = new StringBuilder(wexpression);

            exp.Replace("R:", string.Empty);
            exp.Replace("I:", string.Empty);
            exp.Replace("(", string.Empty);
            exp.Replace(")", string.Empty);
            exp.Replace("AND", string.Empty);
            String[] wArray = exp.ToString().Split(new string[] { "NOT" }, StringSplitOptions.RemoveEmptyEntries);

            if (wArray.Length > 0)
            {
                foreach (string str in wArray[0].Split(new string[] { "OR" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    wRol = new Rol(str.Trim());
                    assignedRoleList.Add(wRol);
                }
            }

            if (wArray.Length > 1)
            {
                foreach (string str in wArray[1].Split(new string[] { "OR" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    wUser = new User(str.Trim());
                    excludeUserList.Add(wUser);
                }
            }

        }

       
      
    }
}
