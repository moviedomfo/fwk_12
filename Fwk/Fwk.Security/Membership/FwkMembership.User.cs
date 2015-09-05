using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Web.Security;
using Fwk.Security.Common;
using System.Data;
using Fwk.Exceptions;
using Fwk.Security.Properties;
using Fwk.Security.Membership;

namespace Fwk.Security
{
    public partial class FwkMembership
    {
        #region [Users]


        /// <summary>
        /// Verifican que usuario y password sean validos
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static Boolean ValidateUser(string userName, string password, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
           
           bool isValid = wProvider.ValidateUser(userName, password);

           if (!isValid)
           {
               MembershipUser user = wProvider.GetUser(userName,true);
               if (user != null)
               {
                   //User exists
                   if (!user.IsApproved)
                   {
                       //Account Unapproved
                       throw new TechnicalException("Your account is not approved.");
                   }
                   else if (user.IsLockedOut)
                   {
                       //Account Locked
                 
                       throw new TechnicalException("Your account is locked.");
                   }
                   else
                   {
                       //Invalid username or password
                       
                       throw new TechnicalException("Invalid username or password.");
                   }
               }
               else
               {
                    throw new TechnicalException("Invalid username or password.");
               }
           }
           return isValid;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="providerName"></param>
        /// <returns></returns>
        public static MembershipEnums CheckUserStatus(string userName, string password, string providerName)
        {
            MembershipEnums status = MembershipEnums.AccountUsernameAndPassword_IS_OK;
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);

            bool isValid = wProvider.ValidateUser(userName, password);

            if (!isValid)
            {
                MembershipUser user = wProvider.GetUser(userName, true);
                if (user != null)
                {
                    //User exists
                    if (!user.IsApproved)
                    {
                        //Account Unapproved
                        status = MembershipEnums.AccountIsNotApproved;
                    }
                    else if (user.IsLockedOut)
                    {
                        //Account Locked
                        status = MembershipEnums.AccountIsLockedOut;
                        
                    }
                    else
                    {
                        //Invalid username or password
                        status = MembershipEnums.InvalidUsernameOrPassword;
                        
                    }
                }
                else
                {
                    status = MembershipEnums.InvalidUsernameOrPassword;
                }
            }
            return status;

        }
        /// <summary>
        /// Crea un usuario
        /// Si el usuario existe lanza una (System.Web.Security.MembershipCreateUserException ex) 
        /// </summary>
        /// <param name="userName">Usuario</param>
        /// <param name="password">Clave</param>
        /// <param name="email">Email</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void CreateUser(string userName, string password, string email, string providerName)
        {
            
          
            MembershipCreateStatus status;
            //wProvider.CreateUser(userName, password, email, string.Empty, string.Empty, true, status);
            FwkMembership.CreateUser(userName, password, email, null, null, true, out  status, providerName);
            if (status != MembershipCreateStatus.Success)
            {
                Fwk.Exceptions.TechnicalException te = new TechnicalException(string.Concat("Fwk Membership error", GetErrorMessage(status)));
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4005";
                throw te;
            }
        }

        /// <summary>
        /// Crea un usuario
        /// Si el usuario existe lanza una (System.Web.Security.MembershipCreateUserException ex) 
        /// </summary>
        /// <param name="userName">Usuario</param>
        /// <param name="password">Clave</param>   
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void CreateUser(string userName, string password, string providerName)
        {
                        
            MembershipCreateStatus status;
            CreateUser(userName, password, string.Empty, null, null, true, out status, providerName);
            if (status != MembershipCreateStatus.Success)
            {
                Fwk.Exceptions.TechnicalException te = new TechnicalException(string.Concat("Fwk Membership error", GetErrorMessage(status)));
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4005";
                throw te;
            }
          
        }


        /// <summary>
        /// Crea un usuario
        /// </summary>
        /// <param name="userName">Nombre de usuario, nombre de logging</param>
        /// <param name="password">Clave</param>
        /// <param name="email">Correo electronico</param>
        /// <param name="passwordQuestion">Pregunta secreta</param>
        /// <param name="passwordAnswer">Respuesta secreta</param>
        /// <param name="isApproved">True si esta aprovado </param>
        /// <param name="pStatus"><see cref="MembershipCreateStatus"/></param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns><see cref="User"/></returns>
        public static User CreateUser(string userName,
            string password,
            string email,
            string passwordQuestion,
            string passwordAnswer,
            Boolean isApproved,
            out System.Web.Security.MembershipCreateStatus pStatus,
            string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);

            User wUsuario = null;
            System.Web.Security.MembershipUser newUser = wProvider.CreateUser(userName, password, email, passwordQuestion, passwordAnswer, isApproved, Guid.NewGuid(), out pStatus);


            if (newUser != null)
                wUsuario = new User(newUser);
                

            return wUsuario;

        }

        /// <summary>
        /// Elimina un usuario de la Base de Datos
        /// </summary>
        /// <param name="userName">Nombre de Usuario</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void DeleteUser(String userName, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            wProvider.DeleteUser(userName, true);
        }

        
        
        /// <summary>
        /// Actualiza informacion de un usuario. Incluso el nombre
        /// </summary>
        /// <param name="fwkUser">Usuario con los nuevos datos </param>
        /// <param name="userName">Nombre de usuario a modificar. Nombre del usuario actual</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void UpdateUser(User fwkUser, string userName, string providerName)
        {
            #region usa el provider
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);


            MembershipUser wUser = wProvider.GetUser(userName, false);

            wUser.Comment = fwkUser.Comment;
            wUser.Email = fwkUser.Email;
            wUser.IsApproved = fwkUser.IsApproved;

            wProvider.UpdateUser(wUser);
            #endregion

            #region actualizacion personalizada

            StringBuilder str = new StringBuilder(FwkMembershipScripts.User_u);

            Database wDataBase = null;
            DbCommand wCmd = null;


            wDataBase = DatabaseFactory.CreateDatabase(GetProvider_ConnectionStringName(wProvider.Name));
            str.Replace("[newUserName]", fwkUser.UserName);
            str.Replace("[loweredNewUserName]", fwkUser.UserName.ToLower());
            str.Replace("[userName]", userName.ToLower());

            wCmd = wDataBase.GetSqlStringCommand(str.ToString());


            wCmd.CommandType = CommandType.Text;

            wDataBase.ExecuteNonQuery(wCmd);
            str = null;
            #endregion


        }

        /// <summary>
        /// Obtiene una lista de usuarios
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>lista de <see cref="User"/></returns>
        public static List<User> GetAllUsers(string providerName)
        {
            SqlMembershipProvider provider = GetSqlMembershipProvider(providerName);
          
            List<User> wUsersList = new List<User>();
            int pageSize = 10;
            int totalUsers;
            int totalPages;
         

            try
            {
                MembershipUserCollection list = provider.GetAllUsers(0, pageSize, out totalUsers);
                totalPages = ((totalUsers - 1) / pageSize) + 1;
                AddUsers(wUsersList, list);
                for (int currentPage = 1; currentPage < totalPages; currentPage++)
                {
                    list = provider.GetAllUsers(currentPage, pageSize, out totalUsers);
                    AddUsers(wUsersList, list);
                   
                }
            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te = new TechnicalException("Fwk membership user error ",ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }

            return wUsersList;

        }
        
        static  void AddUsers(List<User> usersList, MembershipUserCollection pMembershipUserCollection)
        {
            User wUserByApp;
            foreach (MembershipUser wMembershipUser in pMembershipUserCollection)
            {
                wUserByApp = new User(wMembershipUser);
                usersList.Add(wUserByApp);
            }
        }
        /// <summary>
        /// Obtiene la informacion de un usuario y junto a sus roles
        /// </summary>
        /// <param name="userName">Nombre de usuario</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static User GetUserAnRoles(String userName, string providerName)
        {
            User  wUser = FwkMembership.GetUser(userName, providerName);
            RolList userRoles = FwkMembership.GetRolesForUser(userName, providerName);
            wUser.Roles = userRoles.GetArrayNames();
            return wUser;
        }
        /// <summary>
        /// Obtiene un usuario
        /// </summary>
        /// <param name="userName">Nombre del Usuario que se desea obtener</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
       /// <returns><see cref="User"/></returns>
        public static User GetUser(String userName, string providerName)
       {
           MembershipUser wUser = GetMembershipUser(userName, providerName);
           // block the user
           if (wUser != null)
           {
               return new User(wUser);
           }
           else
           {
               Fwk.Exceptions.TechnicalException te = new TechnicalException(string.Format(Fwk.Security.Properties.Resource.User_NotExist, userName));
               ExceptionHelper.SetTechnicalException<FwkMembership>(te);
               te.ErrorId = "4005";
               throw te;
           }
       }

        /// <summary>
        /// Obtiene un objeto <see cref="MembershipUser"/> por medio del SqlMembershipProvider correspondiente
        /// </summary>
        /// <param name="userName">Nombre de usuario</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        static MembershipUser GetMembershipUser(String userName, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName); 
            MembershipUser wMembershipUser = wProvider.GetUser(userName, false);
            
            // block the user
            if (wMembershipUser != null)
            {
                return wMembershipUser;
            }
            else
            {
                Fwk.Exceptions.TechnicalException te = new TechnicalException(string.Format(Fwk.Security.Properties.Resource.User_NotExist, userName));
                ExceptionHelper.SetTechnicalException<FwkMembership>(te); 
                te.ErrorId = "4005";
                throw te;
            }
        }
        /// <summary>
        /// Determina si existe el usuario para un determinado proveedor de seguridad. 
        /// </summary>
        /// <param name="userName">Nombre de usuario a chequear</param>
        /// <param name="providerName">Proveedor de seguridad configurado</param>
        /// <returns></returns>
        public static Boolean UserExist(String userName, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            MembershipUser wMembershipUser = wProvider.GetUser(userName, false);

            return (wMembershipUser != null);
            
        }
        /// <summary>
        /// Desaprueva un usuario
        /// </summary>
        /// <param name="userName">Nombre del usuario que se desea bloquear</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void UnApproveUser(String userName, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName); 
            MembershipUser wUser = GetMembershipUser(userName, providerName);

            // Updates a users approval status to the specified value
            if (wUser != null)
            {
                wUser.IsApproved = false;
                wProvider.UpdateUser(wUser);
            }
            else
            {
                Fwk.Exceptions.TechnicalException te = new TechnicalException(string.Format(Fwk.Security.Properties.Resource.User_NotExist, userName));
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4005";
                throw te;
            }

        }

        /// <summary>
        ///  Aprueva un usuario
        /// </summary>
        /// <param name="userName">Nombre del usuario a desbloquear</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void ApproveUser(String userName, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName); 
            MembershipUser wUser = GetMembershipUser(userName, providerName);

            // Updates a users approval status to the specified value
            if (wUser != null)
            {
                wUser.IsApproved = true;
                wProvider.UpdateUser(wUser);

            }
            else
            {
                Fwk.Exceptions.TechnicalException te = new TechnicalException(string.Format(Resource.User_NotExist, userName));
                ExceptionHelper.SetTechnicalException<FwkMembership>(te); 
                te.ErrorId = "4005";
                throw te;
            }
        }
        
        /// <summary>
        /// Toma como entrada un nombre de usuario y actualiza el campo en el origen de datos que asigna a la propiedad 
        /// IsLockedOut el valor false. 
        /// El método UnlockUser devuelve true si el registro para el usuario suscripto se actualiza correctamente; de lo contrario, false.
        /// 
        /// The asp.net membership has the mechanism that it locks out a user's account if she tries to authenticate herself with false password five times, 
        /// by default, or within 10 minute window. It is all for possible hacks. And I had no mechanism to unlock the user account.
        /// Because locked user can not login, I needed some way to unlock the user. 
        /// Firstly, I was frustrated since I saw the MembershipUser class's IsLockedOut read only property.
        /// </summary>
        /// <param name="userName">Nombre del usuario a desbloquear</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static bool UnlockUser(String userName, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName); 
            MembershipUser wUser = GetMembershipUser(userName, wProvider.Name);


            // block the user
            if (wUser != null)
            {
                
                return wUser.UnlockUser();
            }
            else
            {
                Fwk.Exceptions.TechnicalException te = new TechnicalException(string.Format(Fwk.Security.Properties.Resource.User_NotExist, userName));
                ExceptionHelper.SetTechnicalException<FwkMembership>(te); 
                te.ErrorId = "4005";
                throw te;
            }

        }

      
        /// <summary>
        /// Resetea el Password de un usuario
        /// </summary>
        /// <param name="userName">Nombre del Usuario</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>Password auto generado</returns>
        public static String ResetUserPassword(String userName, string providerName)
        {
            String wNewPassword;
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName); 
            MembershipUser wUser = GetMembershipUser(userName, wProvider.Name);
            // block the user
            if (wUser != null)
            {
                wNewPassword = wUser.ResetPassword();
            }
            else
            {
                Fwk.Exceptions.TechnicalException te = new TechnicalException(string.Format(Fwk.Security.Properties.Resource.User_NotExist, userName));
                ExceptionHelper.SetTechnicalException<FwkMembership>(te); 
                te.ErrorId = "4005";
                throw te;
            }

            return wNewPassword;
        }

        /// <summary>
        /// Cambia el password de un usuario
        /// </summary>
        /// <param name="userName">Nombre del Usuario</param>
        /// <param name="pOldPassword">Password Viejo</param>
        /// <param name="pNewPassword">Password Nuevo</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>Bool indicando el resultado de la operación</returns>
        public static Boolean ChangeUserPassword(String userName, String pOldPassword, String pNewPassword, string providerName)
        {
            MembershipUser wUser = GetMembershipUser(userName, providerName);

            return wUser.ChangePassword(pOldPassword, pNewPassword);

        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="email">e-mail</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
       /// <returns>Nombre del usuario</returns>
        public static string GetUserNameByEmail(string email, string providerName)
        {
               SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            return wProvider.GetUserNameByEmail(email);
        }

        /// <summary>
        /// Obtiene una lista de usuarios de un determinado rol.- Solo obtiene nombre de usuario
        /// </summary>
        /// <param name="roleName">Nombre del rol</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>lista de <see cref="User"/> </returns>
        public static List<User> GetUsersInRole(String roleName, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName); 

            User wUserByApp;
            List<User> wUsersList = new List<User>();
           
            try
            {
                foreach (string s in Roles.Providers[wProvider.Name].GetUsersInRole(roleName))
                {
                    wUserByApp = new User(s);
                    wUsersList.Add(wUserByApp);
                }

            }
            catch (Exception ex)
            {

                Fwk.Exceptions.TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError,ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }

            return wUsersList;

        }

        /// <summary>
        /// Obtiene una lista de usuarios con sus detalles pertenecientes a un determinado rol
        /// </summary>
        /// <param name="roleName">Nombre del rol</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>lista de <see cref="User"/> </returns>
        public static List<User> GetUsersDetailedInRole(String roleName, string providerName)
        {

            User wUserByApp;
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName); 
            List<User> wUsersList = new List<User>();
            try
            {
                foreach (string userName in Roles.Providers[wProvider.Name].GetUsersInRole(roleName))
                {
                    wUserByApp = FwkMembership.GetUser(userName, providerName);
                    wUsersList.Add(wUserByApp);
                }

            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }

            return wUsersList;

        }
        
        /// <summary>
        /// Asigna roles a un usuario
        /// </summary>
        /// <param name="pRolList">Lista de roles</param>
        /// <param name="userName">Usuario</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void CreateRolesToUser(RolList pRolList, String userName, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName); 
            
            try
            {
                Roles.Providers[wProvider.Name].AddUsersToRoles(new string[] { userName }, pRolList.GetArrayNames());

                //foreach (Rol rol in pRolList)
                //{
                //    if (!Roles.Providers[providerName].IsUserInRole(userName, rol.RolName))
                //    {
                //        //Roles.AddUserToRoles(userName, new string[] { rol.RolName });

                //        Roles.Providers[providerName].AddUsersToRoles(new string[] { userName }, new string[] { rol.RolName });
                //    }
                //}

            }
            catch (Exception ex)
            {
              
                Fwk.Exceptions.TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }

        }
        
        /// <summary>
        /// Quita a un usuario de un rol
        /// </summary>
        /// <param name="userName">Nombre de Usuario</param>
        /// <param name="roleName">Nombre de Rol</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void RemoveUserFromRole(String userName, String roleName, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            try
            {
                if (!String.IsNullOrEmpty(roleName))
                    Roles.Providers[wProvider.Name].RemoveUsersFromRoles(new string[] { userName }, new string[] { roleName });

            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
        }

        /// <summary>
        /// Quita a un usuario de una lista de Roles
        /// </summary>
        /// <param name="userName">Nombre de Usuario</param>
        /// <param name="pRolList">Lista de Nombres de Roles</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void RemoveUserFromRoles(String userName, RolList pRolList, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            try
            {
                foreach (Rol rol in pRolList)
                {
                    if (Roles.Providers[wProvider.Name].IsUserInRole(userName, rol.RolName))
                        //Roles.RemoveUserFromRoles(userName, new string[] { rol.RolName });
                        Roles.Providers[wProvider.Name].RemoveUsersFromRoles(new string[] { userName }, pRolList.GetArrayNames());

                }
            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
        }

        /// <summary>
        /// Quita un array de usuarios de un Rol
        /// </summary>
        /// <param name="pUsersName">Array de usuario</param>
        /// <param name="roleName">Nombre del Rol</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void RemoveUsersFromRole(String[] pUsersName, String roleName, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            try
            {
               // Roles.RemoveUsersFromRole(pUsersName, roleName);
                Roles.Providers[wProvider.Name].RemoveUsersFromRoles(pUsersName, new string[] { roleName });
            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
        }

        /// <summary>
        /// Quita una array de Usuarios de una lista de Roles
        /// </summary>
        /// <param name="pUsersName">Array de Nombres</param>
        /// <param name="pRolList">Lista de Roles</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void RemoveUsersFromRoles(String[] pUsersName, RolList pRolList, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            try
            {
                Roles.Providers[wProvider.Name].RemoveUsersFromRoles(pUsersName, pRolList.GetArrayNames());
                
            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
        }

        
        #endregion


    }
}
