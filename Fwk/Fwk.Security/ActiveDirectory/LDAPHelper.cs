using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq;
using System.Collections.Specialized;
using System.DirectoryServices.ActiveDirectory;
using Fwk.Exceptions;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.ComponentModel;
using System.DirectoryServices;
using Fwk.Security.Properties;

namespace Fwk.Security.ActiveDirectory
{
    /// <summary>
    /// 
    /// </summary>
    public class LDAPHelper : DirectoryServicesBase
    {


        private DomainUrlInfo _DomainUrlInfo = null;
        private DomainController _DomainController=null;
        private static List<DomainController> _DomainControllers;


        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domainName"></param>
        /// <param name="pConnString"></param>
        public LDAPHelper(String domainName, String pConnString) : this(domainName, pConnString, false) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="domainName">Nombre corto del dominio, por ej "ALCO"</param>
        /// <param name="connStringName">Nombre de la cadena conexión de la base de datos de la tabla UrlDomains</param>
        /// <param name="pSecure">Especifica si establece una conexión SSL</param>
        public LDAPHelper(String domainName, String connStringName, Boolean pSecure)
        {
            Init(domainName, connStringName, pSecure, true);

        }

        /// <summary>
        /// No realiza busquedas en base de datos de los controladores decominio
        /// </summary>
        /// <param name="domainUrlInfo"></param>
        public LDAPHelper(DomainUrlInfo domainUrlInfo)
        {
            _DomainUrlInfo = domainUrlInfo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="domainName"></param>
        /// <param name="connStringName"></param>
        /// <param name="pSecure"></param>
        /// <param name="chekControllers"></param>
        public LDAPHelper(String domainName, String connStringName, Boolean pSecure, bool chekControllers)
        {

            Init(domainName, connStringName, pSecure, chekControllers);

        }

        void Init(String domainName, String connStringName, Boolean pSecure, bool chekControllers)
        {
            //_LdapWrapper = new LdapWrapper();

            //LoadControllersFromDatabase( pConnString);


            _DomainUrlInfo = DomainsUrl_Get_FromSp(connStringName, domainName);// _DomainUrlInfoList.First<DomainUrlInfo>(p => p.DomainName == domainName);
            if (_DomainUrlInfo == null)
            {
                throw new Fwk.Exceptions.TechnicalException("No se encontró la información del dominio especificado");
            }

            if (chekControllers)
            {
                _DomainControllers = GetDomainControllersByDomainId(System.Configuration.ConfigurationManager.ConnectionStrings[connStringName].ConnectionString, _DomainUrlInfo.Id);
                if (_DomainControllers == null || _DomainControllers.Count == 0)
                    throw new Fwk.Exceptions.TechnicalException("No se encuentra configurado ningún controlador de dominio para el sitio especificado.");


                // Prueba de conectarse a algún controlador de dominio disponible, siempre arranando del primero. debería 
                // TODO: reemplazarse por un sistema de prioridad automática para que no intente conectarse primero a los funcionales conocidos
                //LdapException wLastExcept = GetDomainController(pSecure, _DomainControllers);
                if (_DomainController == null)
                {
                    throw new Fwk.Exceptions.TechnicalException("No se encontró ningún controlador de dominio disponible para el sitio especificado.");//, wLastExcept);
                }
            }
        }

        
        #endregion

        #region Funciones que no usan LDAP en C++

        /// <summary>
        /// Esta funcion utiliza chequea el loging de un usuario contra un dominio
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="logError"></param>
        /// <returns></returns>
        public LoginResult User_Logon(string userName, string password, out Fwk.Exceptions.TechnicalException logError)
        {
            LoginResult wLoginResult = LoginResult.LOGIN_OK;
            Win32Exception win32Error = null;
            logError = null;
            SafeTokenHandle safeTokenHandle;

            #region Busco el usuario con un DirectoryEntry con usuario administrador


            this.User_Get(userName, password, out wLoginResult);

            if (wLoginResult == LoginResult.ERROR_SERVER_IS_NOT_OPERATIONAL)
            {
                win32Error = new Win32Exception();
                logError = new Fwk.Exceptions.TechnicalException(win32Error.Message);
                LDAPHelper.SetError(logError);
                logError.ErrorId = "15004";
                logError.Source = string.Concat(logError.Source, Environment.NewLine, win32Error.Source);
                return wLoginResult;
            }
            #endregion
            if (wLoginResult == LoginResult.LOGIN_OK) return wLoginResult;

            //obtain a handle to an access token.
            bool returnValue = LogonUser(userName, _DomainUrlInfo.DomainName, password,
                (int)LOGON32.LOGON32_LOGON_INTERACTIVE,
                (int)LOGON32.LOGON32_PROVIDER_DEFAULT,
               out safeTokenHandle);




            if (!returnValue)
            {
                int ret = GetLastError();
                win32Error = new Win32Exception();
                logError = new Fwk.Exceptions.TechnicalException(win32Error.Message);
                LDAPHelper.SetError(logError);
                logError.ErrorId = "15004";
                logError.Source = string.Concat(logError.Source, Environment.NewLine, win32Error.Source);


            }



            return wLoginResult;


        }
        /// <summary>
        /// Este metoo autentica elusuario pero no espesifica el error. Tal como lo hace User_Logon retornando LoginResult
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool User_Logon_IsAuthenticated(string username, string pwd)
        {
            return User_Logon_IsAuthenticated(_DomainUrlInfo.LDAPPath, _DomainUrlInfo.DomainName, username, pwd);
        }

       /// <summary>
            ///  Este metoo autentica elusuario pero no espesifica el error. Tal como lo hace User_Logon retornando LoginResult
       /// </summary>
       /// <param name="LDAPPath">url ldap o coneccion ldap perteneciente al dominio</param>
       /// <param name="domainName">Nombre de dominio</param>
       /// <param name="username">Nombre de usuario</param>
       /// <param name="pwd">password</param>
       /// <returns></returns>
        public static bool User_Logon_IsAuthenticated(string LDAPPath, string domainName, string username, string pwd)
        {
            string domainAndUsername = String.Concat(domainName + @"\" + username);
      
            try
            {
                DirectoryEntry Entry = new DirectoryEntry(LDAPPath, username, pwd, AuthenticationTypes.Secure);
                DirectorySearcher searcher = new DirectorySearcher(Entry);
                searcher.SearchScope = SearchScope.OneLevel;


                System.DirectoryServices.SearchResult results = searcher.FindOne();
                if (results != null)
                    return true;
            }
            catch (Exception ex)
            {

                TechnicalException te = new Fwk.Exceptions.TechnicalException(ex.Message);
                LDAPHelper.SetError(te);
                te.ErrorId = "15004";
                throw te;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool IsAuthenticated_test( string username, string pwd)
        {
            string domainAndUsername = String.Concat(_DomainUrlInfo.DomainName + @"\" + username);
            DirectoryEntry entry = new DirectoryEntry(_DomainUrlInfo.LDAPPath, domainAndUsername, pwd);

            try
            {
                //Bind to the native AdsObject to force authentication.
                object obj = entry.NativeObject;

                DirectorySearcher search = new DirectorySearcher(entry);

                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();

                if (null == result)
                {
                    return false;
                }

                //Update the new path to the user in the directory.
                //_path = result.Path;
                //_filterAttribute = (string)result.Properties["cn"][0];
            }
            catch (Exception ex)
            {
                throw new Exception("Error authenticating user. " + ex.Message);
            }

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DirectoryEntry  GetImpersonate_SearchRoot_DE()
        {
            try
            {
                return new DirectoryEntry(_DomainUrlInfo.LDAPPath, _DomainUrlInfo.Usr, _DomainUrlInfo.Pwd, AuthenticationTypes.Secure);
            }
            catch (Exception e)// Cuando el usuario no existe o clave erronea
            {
                Exception te1 = ADWrapper.ProcessActiveDirectoryException(e);
                TechnicalException te = new TechnicalException(string.Format(Resource.AD_Impersonation_Error, te1.Message), te1.InnerException);
                ExceptionHelper.SetTechnicalException<ADWrapper>(te);
                te.ErrorId = "4103";
                throw te;
            }
        }

        /// <summary>
        /// Busca un usuario con autenticacion 
        /// Returna como parametro el resultado de loging
        /// </summary>
        /// <param name="userName">nombre de loging de usuario</param>
        /// <param name="password">password</param>
        /// <param name="loginResult">resultado de loging</param>
        /// <returns>DirectoryEntry</returns>
        DirectoryEntry User_Get(string userName, string password,out LoginResult loginResult)
        {

            DirectoryEntry searchRoot_DE = GetImpersonate_SearchRoot_DE();

            DirectoryEntry userDirectoryEntry = null;
            loginResult = LoginResult.LOGIN_OK;
            SearchResult result = ADWrapper.User_Get_Result(userName, searchRoot_DE);

            //Si esl resultado de busqueda en nodes es nulo el usuario no exisate en el dominio
            if (result == null)
            {
                loginResult = LoginResult.LOGIN_USER_DOESNT_EXIST;
                return null;
            }

            //PasswordExpired
            if (ADWrapper.GetProperty(result, ADProperties.PWDLASTSET) == "0")
            {
                loginResult = LoginResult.ERROR_PASSWORD_MUST_CHANGE;
                return null;
            }




            //string str = EnlistValue(results);
            //si result no es nulo se puede crear una DirectoryEntry
            if (result != null)
                userDirectoryEntry = new DirectoryEntry(result.Path, userName, password);

            //Intenta obtener una propiedad para determinar si el usuario se logueo con clave correcta o no.-
            try
            {
                int userAccountControl = Convert.ToInt32(ADWrapper.GetProperty(userDirectoryEntry, ADProperties.USERACCOUNTCONTROL));
            }
            catch (TechnicalException te)
            {
                if (te.ErrorId == "4101")
                {
                    loginResult = LoginResult.LOGIN_USER_OR_PASSWORD_INCORRECT;
                    return userDirectoryEntry;
                }
                if (te.ErrorId == "4100")
                {
                    loginResult = LoginResult.ERROR_SERVER_IS_NOT_OPERATIONAL;
                    return userDirectoryEntry;
                }
            }

            if (ADWrapper.User_IsAccountActive(userDirectoryEntry) == false)
            {
                loginResult = LoginResult.LOGIN_USER_ACCOUNT_INACTIVE;
                return userDirectoryEntry;
            }

            if (ADWrapper.User_IsAccountLockout(userDirectoryEntry))
            {
                loginResult = LoginResult.LOGIN_USER_ACCOUNT_LOCKOUT;
                return userDirectoryEntry;
            }


            return userDirectoryEntry;
        
        }


        #endregion
        #region Interface Methods

   

        /// <summary>
        /// Devuelve true o false según el usuario especificado exista en LDAP
        /// </summary>
        /// <param name="pUserName">Nombre de usuario</param>
        public bool User_Exists(string pUserName)
        {
            String wFilter;
            Int32 wTotal=0;
            wFilter = String.Format("(&(objectClass=user)(sAMAccountName={0}))", pUserName);
            //wTotal = _LdapWrapper.Search(wFilter, null, null); // attributos y resultado en null.. solo cuenta la cantidad
            return (wTotal == 0);
        }

       

        #endregion

        #region Métodos Privados

       

        /// <summary>
        /// Obtiene la lista de controladores de dominio para un DomainID especificado
        /// </summary>
        private List<DomainController> GetDomainControllersByDomainId(String pConnString, Int32 pDomainId)
        {
            try
            {
                using (SqlDomainControllersDataContext dc = new SqlDomainControllersDataContext(pConnString))
                {
                    IEnumerable<DomainController> list = from s in dc.DomainControllers
                                                         where s.DomainId == pDomainId
                                                          select
                                                          new DomainController
                                                          {
                                                              DomainId = s.DomainId,
                                                              HostName = s.DCHostName,
                                                              Id = s.DCId,
                                                              Ip = s.DCIp
                                                          };
                     return list.ToList<DomainController>();
                }
            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException("Error al intentar obtener la lista de dominios desde la base de datos: ", ex);
                LDAPHelper .SetError(te);
                te.ErrorId = "15004";
                throw te;
            }
        }

       

        #endregion
    }
}
