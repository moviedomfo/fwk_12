using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using Fwk.Security.Common;
using System.Web.Security;
using Fwk.Exceptions;
using System.Data.SqlClient;

namespace Fwk.Security
{
    public partial class FwkMembership
    {

        #region [Roles]
        public static RolList GetAllRoles_FullInfo(string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);

            return GetAllRoles_FullInfo(wProvider.ApplicationName, GetProvider_ConnectionStringName(wProvider.Name));
        }

        public static RolList GetAllRoles_FullInfo(string applicationName, string connectionStringName)
        {

            RolList wRolList = null;
            Rol wRol = null;
            try
            {
                Guid wApplicationId = GetApplication(applicationName, connectionStringName);
                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
                {
                    var roles = from s in dc.aspnet_Roles where s.ApplicationId == wApplicationId select s;

                    wRolList = new RolList();
                    foreach (aspnet_Role aspnet_rol in roles)
                    {
                        wRol = new Rol();
                        wRol.Description = aspnet_rol.Description;

                        wRol.RolName = aspnet_rol.RoleName;

                        wRolList.Add(wRol);
                    }

                }



                return wRolList;
            }
            catch (TechnicalException tx)
            { throw tx; }
           
            catch (Exception ex)
            {

                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
        }

        /// <summary>
        /// Obtiene todos los Roles
        /// The GetAllRoles method calls the RoleProvider.GetAllRoles method of the  role provider to get a list of all the roles from the data source for an application. 
        /// Only the roles for the application that is specified in the ApplicationName property are retrieved.
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>RolList con todos los roles</returns>
        public static RolList GetAllRoles(string providerName)
        {
            Rol r;
            RolList wRoleList = new RolList();
            if (string.IsNullOrEmpty(providerName))
                providerName = GetSqlMembershipProvider(providerName).Name;


            try
            {
                foreach (string s in GetRoleProvider(providerName).GetAllRoles())
                {
                    r = new Rol(s);
                    wRoleList.Add(r);
                }

            }
            catch (TechnicalException err)
            {
                throw err;
            }
            catch (System.NullReferenceException)
            {
                TechnicalException te = new TechnicalException(string.Format(Fwk.Security.Properties.Resource.RuleProvider_NotExist, providerName));
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
            catch (System.Configuration.Provider.ProviderException pe)
            {
                TechnicalException te = new TechnicalException(
                    String.Format("El proveedor SqlMembership {0} lanzo el siguiente error: {1}", providerName, pe.Message)
                    );
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
            catch (Exception ex)
            {

                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }

            return wRoleList;

        }

        /// <summary>
        /// Obtiene una lista de Roles (RolList) de un usuario
        /// </summary>
        /// <param name="userName">Nombre de Usuario</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>RolList con los roles del usuario</returns>
        public static RolList GetRolesForUser(String userName, string providerName)
        {
            Rol r;
            RolList wRoleList = new RolList();
            if (string.IsNullOrEmpty(providerName))
                providerName = GetSqlMembershipProvider(providerName).Name;

            try
            {
                foreach (string s in GetRoleProvider(providerName).GetRolesForUser(userName))
                {
                    r = new Rol(s);
                    wRoleList.Add(r);
                }

            }
            catch (TechnicalException err)
            {
                throw err;
            }
            catch (System.Configuration.Provider.ProviderException pe)
            {
                TechnicalException te = new TechnicalException(
                    String.Format("El proveedor SqlMembership {0} lanzo el siguiente error: {1}", providerName, pe.Message)
                    );
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }

            return wRoleList;

        }

        /// <summary>
        /// Obtiene una lista de Roles  de un usuario
        /// </summary>
        /// <param name="userName">Nombre de Usuario</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>String[] con los roles del usuario</returns>
        public static String[] GetRolesForUser_StringArray(String userName, string providerName)
        {
            if (string.IsNullOrEmpty(providerName))
                providerName = GetSqlMembershipProvider(providerName).Name;
            try
            {

                return GetRoleProvider(providerName).GetRolesForUser(userName);

            }
            catch (TechnicalException err)
            {
                throw err;
            }
            catch (System.Configuration.Provider.ProviderException pe)
            {
                TechnicalException te = new TechnicalException(
                    String.Format("El proveedor SqlMembership {0} lanzo el siguiente error: {1}", providerName, pe.Message)
                    );
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
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
        ///  Crea un nuevo Rol
        /// </summary>
        /// <param name="roleName">Nombre del rol</param>
        /// <param name="description">Descripcion del rol</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void CreateRole(String roleName, string description, string providerName)
        {
            if (string.IsNullOrEmpty(providerName))
                providerName = GetSqlMembershipProvider(providerName).Name;
            try
            {
                if (!GetRoleProvider(providerName).RoleExists(roleName))
                {
                    Roles.Providers[providerName].CreateRole(roleName);
                    if (!string.IsNullOrEmpty(description))
                        UpdateRole(roleName, description, providerName);
                }
                else
                {
                    TechnicalException te = new TechnicalException(string.Format(Fwk.Security.Properties.Resource.RoleExist, roleName));
                    ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                    te.ErrorId = "4010";
                    throw te;
                }
            }
            catch (TechnicalException err)
            {
                throw err;
            }
            catch (System.Configuration.Provider.ProviderException pe)
            {
                TechnicalException te = new TechnicalException(
                    String.Format("El proveedor SqlMembership {0} lanzo el siguiente error: {1}", providerName, pe.Message)
                    );
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
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
        /// Elimina un Rol.- Lanza exepcion si el rol tiene miembros asociados
        /// </summary>
        /// <param name="roleName">Nombre del Rol</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void DeleteRole(String roleName, string providerName)
        {

            if (string.IsNullOrEmpty(providerName))
                providerName = GetSqlMembershipProvider(providerName).Name;

            try
            {

                if (GetRoleProvider(providerName).GetUsersInRole(roleName).Length == 0)
                    Roles.Providers[providerName].DeleteRole(roleName, true);
                else
                {
                    TechnicalException te = new TechnicalException(string.Format(Fwk.Security.Properties.Resource.Role_NotEmpty, roleName));
                    ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                    te.ErrorId = "4006";
                    throw te;

                }
            }
            catch (TechnicalException err)
            {
                throw err;
            }
            catch (System.Configuration.Provider.ProviderException pe)
            {
                TechnicalException te = new TechnicalException(
                    String.Format("El proveedor SqlMembership {0} lanzo el siguiente error: {1}", providerName, pe.Message)
                    );
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
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
        /// Actualiza un rol
        /// </summary>
        /// <param name="roleName">Nombre del rol</param>
        /// <param name="description">Descripcion del rol</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void UpdateRole(String roleName, string description, string providerName)
        {

            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            StringBuilder str = new StringBuilder("UPDATE aspnet_Roles SET  Description = '[Description]' WHERE (LoweredRoleName = LOWER('[RoleName]')) AND(ApplicationId = CONVERT (UNIQUEIDENTIFIER,'[ApplicationId]') )");

            Guid id = GetApplication(wProvider.ApplicationName, GetProvider_ConnectionStringName(wProvider.Name));

            str.Replace("[ApplicationId]", id.ToString());
            str.Replace("[Description]", description);
            str.Replace("[RoleName]", roleName);

            try
            {


                using (SqlConnection cnn = new SqlConnection(GetProvider_ConnectionString(wProvider.Name)))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(str.ToString(), cnn))
                    {
                        //cmd.CommandText = str.ToString();
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();



                    }
                }
            }
            catch (System.Configuration.Provider.ProviderException pe)
            {
                TechnicalException te = new TechnicalException(
                    String.Format("El proveedor SqlMembership {0} lanzo el siguiente error: {1}", providerName, pe.Message)
                    );
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
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
        /// Asigna usuarios a un determinado rol 
        /// </summary>
        /// <param name="rolName">Nombre del rol</param>
        /// <param name="userList">Lista usuarios</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void CreateUsersToRole(string rolName, List<User> userList, string providerName)
        {
            if (string.IsNullOrEmpty(providerName))
                providerName = GetSqlMembershipProvider(providerName).Name;
            try
            {
                ///var users = from s in userList select s.UserName;
                foreach (User wUser in userList)
                {
                    if (!GetRoleProvider(providerName).IsUserInRole(wUser.UserName, rolName))
                    {
                        Roles.Providers[providerName].AddUsersToRoles(new string[] { wUser.UserName }, new string[] { rolName });
                    }
                }

            }
            catch (TechnicalException err)
            {
                throw err;
            }
            catch (System.Configuration.Provider.ProviderException pe)
            {
                TechnicalException te = new TechnicalException(
                    String.Format("El proveedor SqlMembership {0} lanzo el siguiente error: {1}", providerName, pe.Message)
                    );
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }

        }

        #endregion
    }
}
