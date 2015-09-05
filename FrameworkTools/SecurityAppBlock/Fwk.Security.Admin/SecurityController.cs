using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Security;
using Fwk.Security;
using Fwk.Security.BE;
using Fwk.Security.Common;
using Fwk.Bases;
using Fwk.Security.ISVC.CreateRules;
using Fwk.Security.ISVC.CreateRulesCategory;
using Fwk.Security.ISVC.DeleteRulesCategory;
using Fwk.Security.ISVC.SearchAllRulesCategory;
using Fwk.Security.ISVC.UpdateRules;
using Fwk.Security.ISVC.UpdateRulesCategory;
using Fwk.Security.ISVC.CreateRole;
using Fwk.Security.ISVC.CreateUsers;
using Fwk.Security.ISVC.SearchAllRules;
using Fwk.Security.ISVC.SearchAllRoles;
using Fwk.Security.ISVC.DeleteRole;
using Fwk.Security.ISVC.AssignRolesToUser;
using Fwk.Security.ISVC.SearchRolesForUser;
using Fwk.Security.ISVC.SearchAllUsers;
using Fwk.Security.ISVC.UpdateUser;
using Fwk.Security.ISVC.GetUserInfoByParams;
using Fwk.Security.ISVC.AuthenticateUser;
using Fwk.Security.ISVC.SearchDomainsUrls;
using Fwk.Security.ISVC.ResetUserPassword;



namespace Fwk.Security.Admin
{
    public class SecurityController
    {
        static ClientServiceBase _ClientServiceBase;
        static UserList _UserList;
        public static string WrapperSecurityProvider { get; set; }
        
        public static UserList UserList
        {
            get { return _UserList; }
            set { _UserList = value; }
        }
        static RolList _AllRolList;

        public static RolList AllRolList
        {
            get { return SecurityController._AllRolList; }
            set { SecurityController._AllRolList = value; }
        }

        static FwkAuthorizationRuleList _FwkAuthorizationRuleList;

        public static FwkAuthorizationRuleList FwkAuthorizationRuleList
        {
            get { return SecurityController._FwkAuthorizationRuleList; }
            set { SecurityController._FwkAuthorizationRuleList = value; }
        }


        static SecurityController()
        {
            _ClientServiceBase = new ClientServiceBase();

            //_AllRolList = GetAllRoles(string.Empty);
            //_FwkAuthorizationRuleList = SearchAllRules();
            //_UserList = GetAllUsers(null);

        }
        /// <summary>
        /// Actualiza la lista de Roles y Reglas._ 
        /// AllRolList
        /// FwkAuthorizationRuleList
        /// </summary>
        public static void RefreshSecurity()
        {
            _AllRolList = GetAllRoles(string.Empty);
            _FwkAuthorizationRuleList = SearchAllRules();
        }
        public static void RefreshUsers()
        {

            _UserList = GetAllUsers(null);
        }

        #region Users

        internal static User GetUserInfoByName(string pName)
        {

            GetUserInfoByParamsReq req = new GetUserInfoByParamsReq();
            req.BusinessData.UserName = pName;

            GetUserInfoByParamsRes res = _ClientServiceBase.ExecuteService<GetUserInfoByParamsReq, GetUserInfoByParamsRes>(WrapperSecurityProvider,req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            return res.BusinessData.UserInfo;
        }

        /// <summary>
        /// Crea un nuevo usuario. Se le saco el static para poder hacer referencia a this.
        /// </summary>
        /// <param name="pUser">Usuario</param>
        /// <param name="pPassword">Password</param>
        /// <param name="pMail">Mail del usuario</param>
        internal static void CreateUser(User pUser, RolList pRolList)
        {

            CreateUserReq req = new CreateUserReq();


            req.BusinessData.User = pUser;
            req.BusinessData.User.Roles = pRolList.GetArrayNames();

            CreateUserRes res = _ClientServiceBase.ExecuteService<CreateUserReq, CreateUserRes>(WrapperSecurityProvider,req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            //pUser.UserId = response.BusinessData.NewUserId;
        }



        /// <summary>
        /// Actualiza un usuario
        /// </summary>
        /// <param name="pUser">User</param>
        internal static void UpdateUser(User pUser, RolList pRolList)
        {
            UpdateUserReq req = new UpdateUserReq();

            req.BusinessData.UsersBE = pUser;
            req.BusinessData.RolList = pRolList;
            req.BusinessData.PasswordOnly = false;
            if (!string.IsNullOrEmpty(pUser.Password))
            {
                req.BusinessData.ChangePassword = new ChangePassword();
                req.BusinessData.ChangePassword.New = pUser.Password;
                req.BusinessData.ChangePassword.Old = string.Empty;
            }
            UpdateUserRes res = req.ExecuteService<UpdateUserReq, UpdateUserRes>(WrapperSecurityProvider,req);

            if (res.Error != null)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
            }

        }

        /// <summary>
        /// Cambiar el password de un usuario
        /// </summary>
        /// <param name="pUserName">Nombre de usuario</param>
        /// <param name="pPassword">Password viejo</param>
        /// <param name="pNewPassword">Password Nuevo</param>
        internal static void UserChangePassword(String pUserName, String pPassword, String pNewPassword)
        {

            UpdateUserReq req = new UpdateUserReq();
            req.BusinessData.PasswordOnly = true;
            req.BusinessData.UsersBE = new User();
            req.BusinessData.UsersBE.UserName = pUserName;
            req.BusinessData.RolList = null;
            req.BusinessData.ChangePassword = new ChangePassword();
            req.BusinessData.ChangePassword.New = pNewPassword;
            req.BusinessData.ChangePassword.Old = pPassword;
            UpdateUserRes res = req.ExecuteService<UpdateUserReq, UpdateUserRes>(WrapperSecurityProvider,req);

            if (res.Error != null)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
            }

        }
        /// <summary>
        /// Cambiar el password de un usuario
        /// </summary>
        /// <param name="pUserName">Nombre de usuario</param>
        /// <param name="pNewPassword">Password Nuevo</param>
        internal static void UserResetPassword(String pUserName, String pPassword)
        {

            ResetUserPasswordReq req = new ResetUserPasswordReq();
   
            req.BusinessData.UserName = pUserName;

            req.BusinessData.NewPassword = pPassword;
            ResetUserPasswordRes res = req.ExecuteService<ResetUserPasswordReq, ResetUserPasswordRes>(WrapperSecurityProvider, req);

            if (res.Error != null)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
            }

        }
        /// <summary>
        /// Obtiene todos los usuarios
        /// </summary>
        /// <returns>UserList</returns>
        internal static UserList GetAllUsers(bool? pActiveflag)
        {
            SearchAllUsersReq req = new SearchAllUsersReq();

            //req.BusinessData.Activeflag = pActiveflag;
            SearchAllUsersRes res = req.ExecuteService<SearchAllUsersReq, SearchAllUsersRes>(WrapperSecurityProvider, req);

            if (res.Error != null)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
            }
            return res.BusinessData.UserList;
        }

        /// <summary>
        /// Approve or Unapprove a User
        /// </summary>
        /// <param name="pUserName">Nombre de Usuario</param>
        /// <param name="pUserApprove">Approbe or unapprobe</param>
        internal static void UserApprove(string pUserName, bool pUserApprove)
        {
            try
            {
                //TODO: No usa servicios SecurityController
                //if (pUserApprove)
                //    FwkMembership.ApproveUser(pUserName);
                //else
                //    FwkMembership.UnApproveUser(pUserName);

                //UserActiveFlag(pUserName, pUserApprove);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// pone activeFlag = false
        /// </summary>
        /// <param name="pUserName"></param>
        internal static void DeleteUser(string pUserName)
        {

        }






        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pPassword"></param>
        /// <param name="pAuthenticationMode"></param>
        /// <param name="pDomain"></param>
        /// <param name="pIsEnvironmentUser"></param>
        /// <returns></returns>
        internal static User AuthenticateUser(String pName, String pPassword, AuthenticationModeEnum pAuthenticationMode, String pDomain, Boolean pIsEnvironmentUser)
        {
            AuthenticateUserReq req = new AuthenticateUserReq();

            req.BusinessData.IsEnvironmentUser = pIsEnvironmentUser;
            req.BusinessData.UserName = pName;
            req.BusinessData.Password = pPassword;
            req.BusinessData.Domain = pDomain;
            req.BusinessData.AuthenticationMode = pAuthenticationMode;

            AuthenticateUserRes res = _ClientServiceBase.ExecuteService<AuthenticateUserReq, AuthenticateUserRes>(WrapperSecurityProvider,req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
            ///TODO: arreglar AuthenticateUserRes
            return  res.BusinessData.UserInfo;
        }


        #endregion

        #region Roles

        /// <summary>
        /// Crear un rol
        /// </summary>
        /// <param name="pRoleName">Nombre del rol a crear</param>
        public static void CreateRole(string pRoleName)
        {
            CreateRoleReq req = new CreateRoleReq();
            req.BusinessData.Rol = new Rol(pRoleName);

            CreateRoleRes res = req.ExecuteService<CreateRoleReq, CreateRoleRes>(WrapperSecurityProvider,req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

        }

        /// <summary>
        /// Elimina un rol.
        /// El rol no puede tener usuarios asociados.
        /// </summary>
        /// <param name="pRoleName">Nombre del Rol</param>
        public static void DeleteRole(String pRoleName)
        {
            DeleteRoleReq req = new DeleteRoleReq();

            req.BusinessData.RolName = pRoleName;


            DeleteRoleRes res = req.ExecuteService<DeleteRoleReq, DeleteRoleRes>(WrapperSecurityProvider,req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

        }

        /// <summary>
        /// Obtiene una lista de roles
        /// </summary>
        /// <param name="userName">Si se pasa userName = string.empty se traen todos los roles existentes</param>
        /// <returns></returns>
        public static RolList GetAllRoles(string userName)
        {
            SearchAllRolesReq req = new SearchAllRolesReq();

            req.BusinessData.UserName = userName;
            SearchAllRolesRes res = req.ExecuteService<SearchAllRolesReq, SearchAllRolesRes>(WrapperSecurityProvider,req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            return res.BusinessData.RolList;
        }


        /// <summary>
        /// Asigna una lista de roles a un usuario
        /// </summary>
        /// <param name="pRolList">Lista de roles que se desea asignar</param>
        /// <param name="pUserName">nombre de usuario</param>
        public static void CreateRolesToUser(RolList pRolList, string pUserName)
        {
            AssignRolesToUserReq req = new AssignRolesToUserReq();


            req.BusinessData.Username = pUserName;
            req.BusinessData.RolList = pRolList;
            AssignRolesToUserRes res = req.ExecuteService<AssignRolesToUserReq, AssignRolesToUserRes>(WrapperSecurityProvider,req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
        }

        /// <summary>
        /// Obtiene los roles de un usuario
        /// </summary>
        /// <param name="pUserName">Nombre de usuario</param>
        /// <returns>Lista de roles</returns>
        public static RolList GetRolesForUser(string pUserName)
        {
            SearchRolesForUserReq req = new SearchRolesForUserReq();

            req.BusinessData.Username = pUserName;

            SearchRolesForUserRes res = req.ExecuteService<SearchRolesForUserReq, SearchRolesForUserRes>(WrapperSecurityProvider,req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            return res.BusinessData.RolList;
        }
        #endregion

        #region Categorias

        public static FwkCategoryList SearchAllRulesCategory()
        {
            SearchAllRulesCategoryReq req = new SearchAllRulesCategoryReq();

            SearchAllRulesCategoryRes res = req.ExecuteService<SearchAllRulesCategoryReq, SearchAllRulesCategoryRes>(WrapperSecurityProvider,req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            return res.BusinessData;
        }

        #endregion

        #region [Rules]

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static FwkAuthorizationRuleList SearchAllRules()
        {
            SearchAllRulesReq req = new SearchAllRulesReq();

            req.CacheSettings.CacheOnClientSide = false;
            SearchAllRulesRes res = req.ExecuteService<SearchAllRulesReq, SearchAllRulesRes>(WrapperSecurityProvider,req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            return res.BusinessData;
        }


        #region [--- UPDATE RULES ---]


        /// <summary>
        /// Asocia un rol a determinadas reglas
        /// </summary>
        /// <param name="pRol"></param>
        /// <param name="pRulesList">Lista de reglas que queda asociada al nuevo rol</param>
        /// <param name="pPerformRemoveRoles"></param>
        public static void RulesUpdateService(Rol pRol, FwkAuthorizationRuleList pRulesList, bool pPerformRemoveRoles)
        {
            if (pPerformRemoveRoles)
                RulesRemoveRol(pRol, pRulesList);
            else
                RulesApendRol(pRol, pRulesList);

            UpdateRulesReq req = new UpdateRulesReq();


            req.BusinessData.FwkAuthorizationRuleList = pRulesList;

            UpdateRulesRes res = req.ExecuteService<UpdateRulesReq, UpdateRulesRes>(WrapperSecurityProvider,req);

            if (res.Error != null)
                Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
        }

        //TODO: usar scripts
        static void RulesApendRol(Rol pRol, FwkAuthorizationRuleList pRulesList)
        {
            RolList rollistAux = new RolList();
            UserList userListAux = new UserList(); ;
            foreach (FwkAuthorizationRule rule in pRulesList)
            {
                rollistAux.Clear();
                userListAux.Clear();

                Fwk.Security.FwkMembership.BuildRolesAndUsers_FromRuleExpression(rule.Expression, out rollistAux, out userListAux);

                ///Agregar el rol a la regla
                rollistAux.Add(pRol);

                rule.Expression = Fwk.Security.FwkMembership.BuildRuleExpression(rollistAux, userListAux);
            }
        }
        //TODO: usar scripts
        static void RulesRemoveRol(Rol pRol, FwkAuthorizationRuleList pRulesList)
        {
            RolList rollistAux = new RolList();
            UserList userListAux = new UserList();
            foreach (FwkAuthorizationRule rule in pRulesList)
            {
                rollistAux.Clear();
                userListAux.Clear();

                Fwk.Security.FwkMembership.BuildRolesAndUsers_FromRuleExpression(rule.Expression, out rollistAux, out userListAux);

                ///Agregar el rol a la regla
                if (rollistAux.Any<Rol>(r => r.RolName.Equals(pRol.RolName)))
                {
                    rollistAux.Remove(rollistAux.First<Rol>(r => r.RolName.Equals(pRol.RolName)));
                    rule.Expression = Fwk.Security.FwkMembership.BuildRuleExpression(rollistAux, userListAux);
                }
            }
        }

        #endregion

        #endregion







        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal static List<String> SearchDomainsUrl()
        {
            SearchDomainsUrlsRequest req = new SearchDomainsUrlsRequest();

            SearchDomainsUrlsResponse res = new SearchDomainsUrlsResponse();

            res = _ClientServiceBase.ExecuteService<SearchDomainsUrlsRequest, SearchDomainsUrlsResponse>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            return res.BusinessData.DomainsNameList;
        }
    }
}