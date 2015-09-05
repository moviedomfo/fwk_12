using System;
using System.Data;
using System.Web.Security;
using System.Security.Principal;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security.ISVC.AuthenticateUser;
using Fwk.Security.Common;
using Fwk.Security;
using Fwk.Security.BC;


namespace Fwk.Security.SVC
{
    public class AuthenticateUserService : BusinessService<AuthenticateUserReq, AuthenticateUserRes>
    {
        public override AuthenticateUserRes Execute(AuthenticateUserReq pServiceRequest)
        {
            AuthenticateUserRes wRes = new AuthenticateUserRes();
            UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.AppId, pServiceRequest.SecurityProviderName);
            RolList wRolList = new RolList();
            User wUser = new User();

            switch (pServiceRequest.BusinessData.AuthenticationMode)
            {
                case AuthenticationModeEnum.ASPNETMemberShips:
                    {
                        wUserBC.AuthenticateUser(pServiceRequest.BusinessData.UserName,
                                             pServiceRequest.BusinessData.Password,
                                             out wUser);

                        wRolList = FwkMembership.GetRolesForUser(pServiceRequest.BusinessData.UserName, pServiceRequest.SecurityProviderName);
                       
                        break;
                    }
                case AuthenticationModeEnum.LDAP:
                case AuthenticationModeEnum.FingerPrint:
                case AuthenticationModeEnum.Mixed:
                case AuthenticationModeEnum.WindowsIntegrated:
                    {
                        throw new Fwk.Exceptions.FunctionalException("Metodo de autenticacion no soportado por el servicio de autenticacion ASPNETMemberShips");
                    }

            }
            if (wUser.MustChangePassword == null)
            { wUser.MustChangePassword = false; }

            wRes.BusinessData.UserInfo = wUser;
            wRes.BusinessData.UserInfo.Roles = wRolList.GetArrayNames();
            wRes.BusinessData.UserInfo.AuthenticationMode = pServiceRequest.BusinessData.AuthenticationMode;
            return wRes;
        }
    }

    /// <summary>
    /// Servicio de autenticacion de usuarios
    /// El servicio reliza las siguientes actividades:
    ///     Autentica contra LDAP
    ///     Autentica contra Memberships
    ///     Retorna usuario y roles de Membersuips
    ///     En caso de error de autentuicacion  (Bloqueo de usuario inexistencia , dominio inexistente, config no configurados) se rerna la correspondiente 
    ///     exepcion
    /// </summary>
    public class AuthenticateUserService_old : BusinessService<AuthenticateUserReq, AuthenticateUserRes>
    {
        public override AuthenticateUserRes Execute(AuthenticateUserReq pServiceRequest)
        {
            AuthenticateUserRes wRes = new AuthenticateUserRes();
            UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.AppId, pServiceRequest.SecurityProviderName);
            RolList wRolList = new RolList();
            User wUser = new User();

            switch (pServiceRequest.BusinessData.AuthenticationMode)
            {

                case AuthenticationModeEnum.LDAP:
                    //Se debe validar el usuario en LDAP contra el dominio seleccionado
                    //wRes.BusinessData.UserInfo = wUserBC.AuthenticateUser(pServiceRequest.BusinessData.UserName, pServiceRequest.BusinessData.Password, pServiceRequest.BusinessData.Domain, pServiceRequest.BusinessData.SiteName);

                    if (wUserBC.AuthenticateUser_AD(pServiceRequest.BusinessData.UserName,
                                              pServiceRequest.BusinessData.Password,
                                              pServiceRequest.BusinessData.Domain)
                              == Fwk.Security.ActiveDirectory.LoginResult.LOGIN_OK)
                    {
                        wUserBC.GetUserByParams(pServiceRequest.BusinessData.UserName, out wUser, out wRolList);
                    }

                    // Cuando es autenticación de windows, nunca debe pedir que cambie el password 
                    wRes.BusinessData.UserInfo.MustChangePassword = false;
                    break;

                case AuthenticationModeEnum.Mixed:
                    //utiliza autenticación mixta. Valida contra el usuario de memberships
                    ///wRes.BusinessData.UserInfo = wUserBC.AuthenticateUser(pServiceRequest.BusinessData.UserName, pServiceRequest.BusinessData.Password, pServiceRequest.BusinessData.SiteName);

                    //utiliza autenticación mixta. Valida contra el usuario de bigbang
                    wUserBC.AuthenticateUser(pServiceRequest.BusinessData.UserName,
                                             pServiceRequest.BusinessData.Password,
                                             out wUser);

                    wRolList = FwkMembership.GetRolesForUser(pServiceRequest.BusinessData.UserName, pServiceRequest.SecurityProviderName);

                    break;

                case AuthenticationModeEnum.WindowsIntegrated:
                    // el modo de autenticación es integrada de windows (usuario por defecto o validación LDAP)
                    if (pServiceRequest.BusinessData.IsEnvironmentUser)
                    {

                        // el usuario se toma por defecto del environment por tanto se recupera el user info sin necesidad de validar
                        // El usuario se toma por defecto del environment por tanto se recupera el user info sin necesidad de validar
                        wUserBC.GetUserByParams(pServiceRequest.BusinessData.UserName, out wUser, out wRolList);
                    }
                    else
                    {
                        //Se debe validar el usuario en LDAP contra el dominio seleccionado
                        //wRes.BusinessData.UserInfo = wUserBC.AuthenticateUser(pServiceRequest.BusinessData.UserName, pServiceRequest.BusinessData.Password, pServiceRequest.BusinessData.Domain, pServiceRequest.BusinessData.SiteName);
                        if (wUserBC.AuthenticateUser_AD(pServiceRequest.BusinessData.UserName,
                                                pServiceRequest.BusinessData.Password,
                                                pServiceRequest.BusinessData.Domain)
                                == Fwk.Security.ActiveDirectory.LoginResult.LOGIN_OK)
                        {
                            wUserBC.GetUserByParams(pServiceRequest.BusinessData.UserName, out wUser, out wRolList);
                        }
                    }
                    // Cuando es autenticación de windows, nunca debe pedir que cambie el password de las memberships
                    wRes.BusinessData.UserInfo.MustChangePassword = false;
                    break;

                default:
                    throw new NotImplementedException("Modo de autenticación no implementado");
            }
            if (wUser.MustChangePassword == null)
            { wUser.MustChangePassword = false; }
            wRes.BusinessData.UserInfo = wUser;
            wRes.BusinessData.UserInfo.Roles = wRolList.GetArrayNames();
            wRes.BusinessData.UserInfo.AuthenticationMode = pServiceRequest.BusinessData.AuthenticationMode;
            return wRes;
        }
    }
}
