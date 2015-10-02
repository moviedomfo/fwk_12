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
        
        //private LdapWrapper _LdapWrapper;
        private DomainUrlInfo _DomainUrlInfo;
        private DomainController _DomainController;
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

        /// <summary>
        /// Aqui se cargan por unica vez los Domain Controllers y DomainUrlInfoList
        /// </summary>
        //void LoadControllersFromDatabase(string pConnString)
        //{
        ///TODO: Aqui se debera agregar la utilizacion de un diccionario para mentener los valores por cada cadena de conexion
        /// hay que usar _DomainControllerDictionary y _DomainUrlInfoDictionary
        /// 
        ///Se comenta por que en teoria no se usaria mas.. directamente se obtendra _DomainUrlInfo necesario
        //if (_DomainUrlInfoList == null)
        //{
        //    _DomainUrlInfoList = DomainsUrl_GetList2(System.Configuration.ConfigurationManager.ConnectionStrings[pConnString].ConnectionString);

        //    if (_DomainUrlInfoList == null)

        //        throw new Fwk.Exceptions.TechnicalException("Error al intentar obtener la lista de dominios: La lista se encuentra vacía.");

        //}
        //if (_DomainControllers == null)
        //{
        //    _DomainControllers = GetDomainControllersByDomainId(System.Configuration.ConfigurationManager.ConnectionStrings[pConnString].ConnectionString, _DomainUrlInfo.Id);
        //    if (_DomainControllers == null || _DomainControllers.Count == 0)
        //        throw new Fwk.Exceptions.TechnicalException("No se encuentra configurado ningún controlador de dominio para el sitio especificado.");
        //}

        //}
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
                int ret = GetLastError();//int ret = Marshal.GetLastWin32Error();
                win32Error = new Win32Exception();
                logError = new Fwk.Exceptions.TechnicalException(win32Error.Message);
                LDAPHelper.SetError(logError);
                logError.ErrorId = "15004";
                logError.Source = string.Concat(logError.Source, Environment.NewLine, win32Error.Source);

                #region old code
                //switch (ret)
                //{
                //    case (126):

                //        return LoginResult.LOGIN_USER_OR_PASSWORD_INCORRECT;


                //    case (1314):
                //        return LoginResult.LOGIN_OK;

                //    case (1326):
                //        return LoginResult.LOGIN_USER_OR_PASSWORD_INCORRECT;

                //    default:
                //        throw new Exception(
                //                "Unexpected Logon Failure. Contact Administrator");
                //}

                //throw new System.ComponentModel.Win32Exception(ret);
                #endregion
            }

            #region old code
            //using (safeTokenHandle)
            //{
            //    err = string.Concat("Did LogonUser Succeed? " + (returnValue ? "Yes" : "No"));
            //    err = string.Concat("Value of Windows NT token: " + safeTokenHandle);

            // Check the identity.
            ///////Console.WriteLine("Before impersonation: "        + WindowsIdentity.GetCurrent().Name);
            // Use the token handle returned by LogonUser.
            //WindowsIdentity newId = new WindowsIdentity(safeTokenHandle.DangerousGetHandle());
            //using (WindowsImpersonationContext impersonatedUser = newId.Impersonate())
            //{

            //    // Check the identity.
            //    Console.WriteLine("After impersonation: " + WindowsIdentity.GetCurrent().Name);
            //}
            // Releasing the context object stops the impersonation
            // Check the identity.
            //Console.WriteLine("After closing the context: " + WindowsIdentity.GetCurrent().Name);
            //}
            #endregion

            return wLoginResult;


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
                Exception te1 = ADHelper.ProcessActiveDirectoryException(e);
                TechnicalException te = new TechnicalException(string.Format(Resource.AD_Impersonation_Error, te1.Message), te1.InnerException);
                ExceptionHelper.SetTechnicalException<ADHelper>(te);
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
            SearchResult result = ADHelper.User_Get_Result(userName, searchRoot_DE);

            //Si esl resultado de busqueda en nodes es nulo el usuario no exisate en el dominio
            if (result == null)
            {
                loginResult = LoginResult.LOGIN_USER_DOESNT_EXIST;
                return null;
            }

            //PasswordExpired
            if (ADHelper.GetProperty(result, ADProperties.PWDLASTSET) == "0")
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
                int userAccountControl = Convert.ToInt32(ADHelper.GetProperty(userDirectoryEntry, ADProperties.USERACCOUNTCONTROL));
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

            if (ADHelper.User_IsAccountActive(userDirectoryEntry) == false)
            {
                loginResult = LoginResult.LOGIN_USER_ACCOUNT_INACTIVE;
                return userDirectoryEntry;
            }

            if (ADHelper.User_IsAccountLockout(userDirectoryEntry))
            {
                loginResult = LoginResult.LOGIN_USER_ACCOUNT_LOCKOUT;
                return userDirectoryEntry;
            }


            return userDirectoryEntry;
        
        }


        #endregion
        #region Interface Methods

        /// <summary>
        /// Obtiene un usuario de LDAP por nombre
        /// </summary>
        //public ADUser User_Get_ByName(string pUserName)
        //{
        //    ADUser wADUser;
        //    String wFilter;
        //    String[] wAttributes;
        //    LdapEntryList wResults;

        //    // Parámetros de búsqueda
        //    wFilter = String.Format("(&(objectClass=user)(sAMAccountName={0}))", pUserName);
        //    wAttributes = new String[0]; // array vacío, para que traiga todos los disponibles
        //    wResults = new LdapEntryList();

        //    // Busca y verifica que exista el usuario
        //    if (_LdapWrapper.Search(wFilter, wAttributes, wResults) > 0)
        //    {
        //        wADUser = new ADUser(wResults.First<LdapEntry>());
        //        return wADUser;
        //    }
        //    return null;
        //}

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

        /// <summary>
        /// Obtiene la lista de Grupos de LDAP a los que pertenece el usuario
        /// </summary>
        /// <param name="pUserName">Nombre de usuario</param>
        //public List<ADGroup> User_SearchGroupList(string pUserName)
        //{
        //    List<ADGroup> wGroups = null;
        //    String wFilter;
        //    String[] wAttributes;
        //    LdapEntryList wResults;

        //    ADGroup wADGroup;

        //    // Parámetros de búsqueda
        //    wFilter = String.Format("(&(objectClass=user)(sAMAccountName={0}))", pUserName);
        //    wAttributes = new String[1]; // array vacío, para que traiga todos los disponibles
        //    wAttributes[0] = ADProperties.MEMBEROF;
        //    wResults = new LdapEntryList();

        //    // Busca y verifica que exista el usuario
        //    if (_LdapWrapper.Search(wFilter, wAttributes, wResults) > 0)
        //    {
        //        LdapEntry wUser = wResults.First<LdapEntry>();
        //        if (wUser.ContainsKey(ADProperties.MEMBEROF))
        //        {
        //            foreach (String wGrp in wUser[ADProperties.MEMBEROF])
        //            {
        //                foreach (string wG in GetGroupFromMemberOf(wGrp))
        //                {
        //                    wADGroup = Group_GetByName(wG);
        //                    if (wADGroup != null)
        //                        wGroups.Add(wADGroup);
        //                }                        
        //            }
        //        }
        //    }
        //    return null; 
        //}

        ///// <summary>
        ///// Autentica un usuario
        ///// </summary>
        ///// <param name="pUserName">Nombre de usuario</param>
        ///// <param name="pPassword">Clave</param>
        //public LoginResult User_CheckLogin(string pUserName, string pPassword)
        //{

        //    String wFilter;
        //    String[] wAttributes;
        //    LdapEntryList wResults;

        //    // Parámetros de búsqueda
        //    wFilter = String.Format("(&(objectClass=user)(sAMAccountName={0}))", pUserName);
        //    wAttributes = new String[3];
        //    wAttributes[0] = ADProperties.USERACCOUNTCONTROL;
        //    wAttributes[1] = ADProperties.PWDLASTSET;
        //    wAttributes[2] = "lockoutTime"; // TODO: agregar "lockoutTime" a la clase ADProperties;
        //    wResults = new LdapEntryList();

        //    // Busca y verifica que exista el usuario
        //    if (_LdapWrapper.Search(wFilter, wAttributes, wResults) == 0)
        //    {
        //        return LoginResult.LOGIN_USER_DOESNT_EXIST;
        //    }

        //    // Verifica que la cuenta no esté deshabilitada
        //    Int32 wUserAccountControl = Convert.ToInt32(wResults.First()[ADProperties.USERACCOUNTCONTROL].First());
        //    Int32 wUserAccountControlDisabled = Convert.ToInt32(ADAccountOptions.UF_ACCOUNTDISABLE);
        //    if ((wUserAccountControl & wUserAccountControlDisabled) != 0)
        //    {
        //        return LoginResult.LOGIN_USER_ACCOUNT_INACTIVE;
        //    }

        //    if (wResults.First().ContainsKey("lockoutTime"))
        //    {
        //        Int64 wLockOutTime = Convert.ToInt64(wResults.First()["lockoutTime"].First());
        //        if (wLockOutTime > 0)
        //        {
        //            return LoginResult.LOGIN_USER_ACCOUNT_LOCKOUT;
        //        }
        //    }

        //    // Verifica que no deba cambiar la clave
        //    Int64 wPwdLastSet = Convert.ToInt64(wResults.First()[ADProperties.PWDLASTSET].First());
        //    if (wPwdLastSet == 0)
        //    {
        //        return LoginResult.ERROR_PASSWORD_MUST_CHANGE;
        //    }

        //    // Autentica
        //    try
        //    {
        //        if (!_LdapWrapper.Bind(_DomainController.HostName, _DomainUrlInfo.DomainDN, pUserName, pPassword, false))
        //        {
        //            return LoginResult.LOGIN_USER_OR_PASSWORD_INCORRECT;
        //        }
        //    }
        //    catch (LdapAuthenticationException)
        //    {
        //        return LoginResult.LOGIN_USER_OR_PASSWORD_INCORRECT;                
        //    }

        //    // Pasó hasta acá, login OK
        //    return LoginResult.LOGIN_OK;
        //}

        /// <summary>
        /// Obtiene un Grupo de LDAP, dado un nombre
        /// </summary>
        //public ADGroup Group_GetByName(string pName)
        //{
        //    String wFilter;
        //    String[] wAttributes;
        //    LdapEntryList wResults;

        //    // Parámetros de búsqueda
        //    wFilter = String.Format("(&(objectClass=group)(sAMAccountName={0}))", pName);
        //    wAttributes = new String[0]; // todos lso atributos disponibles
        //    wResults = new LdapEntryList(); // buffer de resultados

        //    // Busca y verifica que exista el usuario
        //    if (_LdapWrapper.Search(wFilter, wAttributes, wResults) == 0)
        //    {
        //        return new ADGroup(wResults.First<LdapEntry>());
        //    }
        //    return null;
        //}

        /// <summary>
        /// Obtiene la lista completa de grupos del LDAP
        /// </summary>
        //public List<ADGroup> Groups_GetAll()
        //{
        //    List<ADGroup> wGroups = null;
        //    String wFilter;
        //    String[] wAttributes;
        //    LdapEntryList wResults;

        //    ADGroup wADGroup;

        //    // Parámetros de búsqueda
        //    wFilter = "(&(objectClass=group))";
        //    wAttributes = new String[0]; // array vacío, para que traiga todos los disponibles
        //    wResults = new LdapEntryList();

        //    // Busca y verifica que exista el usuario
        //    if (_LdapWrapper.Search(wFilter, wAttributes, wResults) > 0)
        //    {
        //        foreach (LdapEntry wGrp in wResults)
        //        {
        //            wADGroup = new ADGroup(wGrp);
        //            if (wADGroup != null)
        //                wGroups.Add(wADGroup);
        //        }
        //    }
        //    return null;
        //}

        /// <summary>
        /// Resetea la clave de un usuario de LDAP
        /// </summary>
        /// <param name="pUserName">Nombre de usuario de la cuenta a la que se resetea la clave</param>
        /// <param name="pNewPwd">Nuevo Password, en caso de ser NULL, no se resetea la cuenta, se realizan el resto de las acciones</param>
        /// <param name="pForceChangeOnFirstLogon">Cuando es true, fuerza al usuario a cambiar la clave especificada en el próximo login</param>
        /// <param name="pUnlockAccount">Cuando es true, desbloquea la cuenta</param>
        //public void ResetPwd(string pUserName, string pNewPwd, bool pForceChangeOnFirstLogon, bool pUnlockAccount)
        //{
        //    String wUserDN = GetUserDN(pUserName);
        //    _LdapWrapper.SetPassword(wUserDN, pNewPwd, pForceChangeOnFirstLogon, pUnlockAccount);
        //}

        #endregion

        #region Métodos Privados

        /// <summary>
        /// Obtiene el nombre distinguido de la entrada de LDAP, para un usuario específico
        /// </summary>
        /// <param name="pUserName">Nombre de Usuario</param>
        //private String GetUserDN(string pUserName)
        //{

        //    String pUserDN;
        //    String wFilter;
        //    String[] wAttributes;
        //    LdapEntryList wResults;

        //    // parámetros de búsqueda
        //    wFilter = String.Format("(&(objectClass=user)(sAMAccountName={0}))", pUserName);
        //    wAttributes = new String[10];
        //    wAttributes[0] = ADProperties.DISTINGUISHEDNAME;
        //    wResults = new LdapEntryList();

        //    if (_LdapWrapper.Search(wFilter, wAttributes, wResults) == 0)
        //    {
        //        throw new TechnicalException("No se encuentra el usuario");
        //    }
        //    pUserDN = wResults.First()[ADProperties.DISTINGUISHEDNAME].First();
        //    return pUserDN;
        //}

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

        /// <summary>
        /// Recibe una lista de controladores de dominio, trata de estaclecer conexión con alguno de ellos. 
        /// Retorna una lista de expceciones de los intentos fallidos
        /// </summary>
        /// <param name="pSecure">Especifica si debe establecer conexion SSL</param>
        /// <param name="wDCList">Lista de controladores de dominio</param>
        //private LdapException GetDomainController(Boolean pSecure, List<DomainController> wDCList)
        //{
        //    LdapException wLastExcept = null;
        //    foreach (DomainController wDC in wDCList)
        //    {
        //        try
        //        {
        //            if (_LdapWrapper.Bind(wDC.HostName, _DomainUrlInfo.DomainDN, _DomainUrlInfo.Usr, _DomainUrlInfo.Pwd, pSecure))
        //            {
        //                _DomainController = wDC;
        //                break;
        //            }
        //        }
        //        catch (LdapAuthenticationException ex)
        //        {
        //            // si no autentica, es porque está mal la info Usr y Pwd
        //            throw ex;
        //        }
        //        catch (LdapException ex)
        //        {
        //            // si entra por acá es porque no pudo conectar, continuo con el siguiente
        //            //throw;
        //            wLastExcept = ex;
        //        }
        //    }
        //    return wLastExcept;
        //}

        #endregion
    }
}
