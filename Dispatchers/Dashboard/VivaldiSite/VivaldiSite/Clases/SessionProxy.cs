//using System;
//using System.Web.SessionState;


//using System.Security.Principal;
//using Microsoft.Practices.EnterpriseLibrary.Security;
//using Health.BE;
//using Health.Back;
//using System.Web;
//using System.Collections.Generic;
//using System.Web.UI;
//using Fwk.Security.BE;
//using Fwk.Security.Common;
//using Fwk.Security;
//using System.Web.Security;


//namespace Health
//{
//    public static class SessionMannager
//    {
       

//        static SessionMannager()
//        {
//            //ImageMapPath = HttpContext.Current.Server.MapPath("/store");
//        }

//        public static SessionProxy _SessionProxy;

//        public static SessionProxy Session(HttpSessionState pageSession,HttpApplicationState appState)
//        {
            
//            if(_SessionProxy == null)
//                _SessionProxy = new SessionProxy(pageSession,appState);
//            if (_SessionProxy.CurrentSession == null)
//                _SessionProxy.SetHttpSessionState(pageSession);
//            return _SessionProxy;
//        }



       
//    }
//    /// <summary>
//    /// 
//    /// http://geeks.ms/blogs/etomas/archive/2010/12/16/asp-net-obtener-el-id-del-usuario-actual.aspx
//    /// </summary>
//    public class SessionProxy
//    {
//        private HttpSessionState _CurrentSession;

//        private HttpApplicationState _App;

//        public SessionProxy(HttpSessionState pageSession, HttpApplicationState appState)
//        {
//            if (pageSession!=null)
//                _CurrentSession = pageSession;

//            _App = appState;
//        }
//        public SessionProxy(HttpSessionState pageSession)
//        {
//            if (pageSession != null)
//                _CurrentSession = pageSession;

         
//        }
//        /// <summary>
//        /// Limpia el ProxySession
//        /// </summary>
//        public void Clear()
//        {
//            if (_CurrentSession != null)
//            {
//                _CurrentSession = null;
//            }

//        }

      

//        public Exception Error
//        {
//            get { return (Exception)_CurrentSession["Error"]; }
//            set
//            {
//                if (value != null)
//                    _CurrentSession["Error"] = value;
//            }
//        }


//        public HttpSessionState CurrentSession
//        {
//            get { return _CurrentSession; }
//        }


//        public IAuthorizationProvider RuleProvider
//        {
//            get { return (IAuthorizationProvider)_App["RuleProvider"]; }
//            set
//            {
//                if (_App["RuleProvider"] != null)
//                    _App["RuleProvider"] = value;
//            }
//        }

  

//        public string GetServerRootPath(UserControl pUserControl)
//        {

//            if (_CurrentSession["ServerRootPath"] == null)
//            {
//                _CurrentSession["ServerRootPath"] = ConstructServerRootPath(pUserControl);
//            }

//            return _CurrentSession["ServerRootPath"].ToString();


//        }

//        static string ConstructServerRootPath(UserControl pUserControl)
//        {

//            string completePath = pUserControl.Server.MapPath(pUserControl.Request.ApplicationPath).Replace("/", "\\");
//            string applicationPath = pUserControl.Request.ApplicationPath.Replace("/", "\\");
//            string rootPath = completePath.Replace(applicationPath, string.Empty);
//            // rootPath == "C:\Inetpub\wwwroot"

//            return rootPath;


//        }

//        /// <summary>
//        /// Inicializa: 
//        ///     IAuthorizationProvider cargandole las reglas por medio de un servicio.-
//        ///     IndentityUserInfo (servicio)
//        ///     Genera el Principal (local) <see>GetGenericPrincipal</see>
//        /// </summary>
//        /// <param name="msgError">Mensage de error en caso de que se produzca alguno</param>
//        public void InitAuthorizationFactory(out string pMsgError)
//        {
//            pMsgError = string.Empty;

//            try
//            {
//                FwkAuthorizationRuleList wFwkAuthorizationRuleList = Fwk.Security.FwkMembership.GetRulesAuxList("sec");
//                _App["RuleProvider"] = new FwkAuthorizationRuleProvider(wFwkAuthorizationRuleList);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        IPrincipal Get_IPrincipal()
//        {

//            if (_CurrentSession["FwkPrincipal"] == null)
//            {
                
//                FwkIdentity ci = new FwkIdentity(HttpContext.Current.User.Identity.Name);
//                _CurrentSession["FwkPrincipal"] = ci;// new GenericPrincipal(genericIdentity, ci.User.Roles);
//            }
//            return (IPrincipal)((FwkIdentity)_CurrentSession["FwkPrincipal"]).Principal;
//        }
//        FwkIdentity Get_FwkIdentity()
//        {

//            if (_CurrentSession["FwkPrincipal"] == null)
//            {

//                FwkIdentity ci = new FwkIdentity(HttpContext.Current.User.Identity.Name);
//                _CurrentSession["FwkPrincipal"] = ci;// new GenericPrincipal(genericIdentity, ci.User.Roles);
//            }
//            return (FwkIdentity)_CurrentSession["FwkPrincipal"];
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        public Profesional_FullViewBE Get_Profesional()
//        {

//            if (_CurrentSession["Profesional_FullViewBE"] == null)
//            {
//                FwkIdentity wFwkIdentity = Get_FwkIdentity();
//                 _CurrentSession["Profesional_FullViewBE"] = ProfesionalesDAC.Get_FullView_ByName(wFwkIdentity.User.UserName);
//            }
//            return (Profesional_FullViewBE)_CurrentSession["Profesional_FullViewBE"];
//        }

      
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="pAuthorizationRuleName"></param>
//        /// <returns></returns>
//        public bool CheckRule(string pAuthorizationRuleName)
//        {
//            bool wResult = false;
//            if (string.IsNullOrEmpty(pAuthorizationRuleName))
//                return true;
//            try
//            {
//                IPrincipal principal = Get_IPrincipal();
//                wResult = this.RuleProvider.Authorize(principal, pAuthorizationRuleName);
//            }
//            catch (Exception ex)
//            {
//                Helper.ProcessWebException(ex);
//            }
//            return wResult;
//        }

//        internal void SetHttpSessionState(HttpSessionState pageSession)
//        {
//            _CurrentSession = pageSession;
//        }
//    }

//    class FwkIdentity : IIdentity
//    {
//        public Fwk.Security.Common.User User;
//        public GenericPrincipal Principal;
//        public FwkIdentity(string usrName)
//        {
//            IsAuthenticated = true;
//            Name = usrName;
//            AuthenticationType = "Forms";
//            User = Fwk.Security.FwkMembership.GetUserAnRoles(HttpContext.Current.User.Identity.Name.Trim(), "sec");

//            GenericIdentity identity = new GenericIdentity(HttpContext.Current.User.Identity.Name);
//            Principal = new GenericPrincipal(identity, User.Roles);


//        }

//        public string AuthenticationType { get; private set; }
//        public bool IsAuthenticated { get; private set; }
//        public string Name { get; private set; }

//    }

//}
