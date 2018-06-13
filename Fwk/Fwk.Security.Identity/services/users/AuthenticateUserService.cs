using System;
using Fwk.Bases;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Thinktecture.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Owin.Security;
using System.IdentityModel.Tokens;
using Fwk.HelperFunctions;
using Fwk.Security.Identity.ISVC.AuthenticateUser;
using Fwk.Security.Identity;

namespace Fwk.Security.Identity.SVC
{
    public class AuthenticateUserService : BusinessService<AuthenticateUserReq, AuthenticateUserRes>
    {
        public override AuthenticateUserRes Execute(AuthenticateUserReq req)
        {
            AuthenticateUserRes wRes = new AuthenticateUserRes();
            var context = req.BusinessData;
            #region ValidateClientAuthentication

            if (String.IsNullOrEmpty (context.ClientId))
            {
                throw new Fwk.Exceptions.FunctionalException("Debe enviar el client_id");
               
            }
            var client = SecurityManager.ClientFind(context.ClientId);

            if (client == null)
            {
                //context.SetError("invalid_clientId",);
                throw new Fwk.Exceptions.FunctionalException(string.Format("Client '{0}' is not registered in the system.", context.ClientId));
            }
            if (client.ApplicationType == (int)ApplicationTypes.NativeConfidential)
            {
                if (string.IsNullOrWhiteSpace(req.BusinessData.ClientSecret))
                {
                    //context.SetError("invalid_clientId", "Client secret should be sent.");
                    throw new Fwk.Exceptions.FunctionalException("Client secret should be sent");
                }
                else
                {
                    if (client.Secret != helper.GetHash(req.BusinessData.ClientSecret))
                    {
                        throw new Fwk.Exceptions.FunctionalException("Client secret is invalid");
                    }
                }
            }

            #endregion

            #region GrantResourceOwnerCredentials

            LoginResult loginResult = SecurityManager.User_Authenticate(context.UserName, context.Password);
            //context.SetError("invalid_grant", "LockedOut");

            SignInStatus s = (SignInStatus)Enum.Parse(typeof(SignInStatus), loginResult.Status);
            switch (s)
            {
                case SignInStatus.Success:
                    {
                        wRes.BusinessData = new Result();
                        wRes.BusinessData.Ticket = new AuthenticationTicketResult();
                        wRes.BusinessData.Ticket.userId= loginResult.User.Id;
                        wRes.BusinessData.Ticket.userName = loginResult.User.UserName;
                        wRes.BusinessData.Ticket.LastLogInDate = loginResult.User.LastLogInDate;
                        wRes.BusinessData.Ticket.email = loginResult.User.Email;
                        wRes.BusinessData.Ticket.roles = FormatFunctions.GetStringBuilderWhitSeparator(loginResult.User.SecurityRoles.ToList(), ',', "Name").ToString();




                        break;
                    }
                default:
                    {
                        throw new Fwk.Exceptions.FunctionalException(loginResult.Message);
                        //                        context.SetError(res.Status, res.Message);

                    }


            }
            #region generamos los claims para este usuario
            ClaimsIdentity oAuthIdentity = SecurityManager.GenerateClaimsIdentity(loginResult.User);

            List<string> roles = null;
            if (loginResult.User.SecurityRoles.Count != 0)
            {
                roles = new List<String>();
                loginResult.User.SecurityRoles.ToList().ForEach(r =>
                {
                    roles.Add(r.Name);
                });
            }

            var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                        "client_id", (context.ClientId == null) ? string.Empty : context.ClientId
                    }
                });

            props.Dictionary.Add("userName", context.UserName);
            props.Dictionary.Add("userId", loginResult.User.Id.ToString());
            props.Dictionary.Add("lastLogInDate", loginResult.User.LastLogInDate.ToString());
            if (!string.IsNullOrEmpty(loginResult.User.Email))
                props.Dictionary.Add("email", loginResult.User.Email);
            if (roles != null)
                props.Dictionary.Add("roles", Fwk.HelperFunctions.FormatFunctions.GetStringBuilderWhitSeparator(roles, ',').ToString());
            props.Dictionary.Add("Status", loginResult.Status);
            #endregion
            //Construccion de ticket
            var ticket = new AuthenticationTicket(oAuthIdentity, props);

            #endregion


            #region  JWT generate Protecttion
            //Aqui por ahora coinciden el nombre del proveedor de Metadata con el nombre del proveedor de seguridad
            //bajo este esquema se hace mapeo uno a uno entre MetadataDeservicios y --> porveedor de seguridad 
            //req.BusinessData.SecurityProviderName
            var sec_provider = helper.secConfig.GetByName(req.ContextInformation.ProviderName);

            string _issuer = sec_provider.issuer;
            string audienceId = sec_provider.audienceId;// ConfigurationManager.AppSettings["audienceId"];
            string symmetricKeyAsBase64 = sec_provider.audienceSecret;// ConfigurationManager.AppSettings["audienceSecret"];

            var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);
            var signingKey = new HmacSigningCredentials(keyByteArray);
            var issued = ticket.Properties.IssuedUtc = System.DateTime.Now;
            var expires = ticket.Properties.ExpiresUtc= System.DateTime.Now.AddHours(1);

            var token = new JwtSecurityToken(_issuer, audienceId, ticket.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingKey);

            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.WriteToken(token);
            wRes.BusinessData.Ticket.access_token = jwt;
            wRes.BusinessData.Ticket.token_type = "jwt";
            wRes.BusinessData.Ticket.client_id = context.ClientId;
            wRes.BusinessData.Ticket.expires = expires.Value.UtcDateTime;
            //wRes.BusinessData.Ticket.expires_in = expires.Value.UtcDateTime;
            wRes.BusinessData.Ticket.Status = loginResult.Status;
            wRes.BusinessData.Ticket.issued = issued.Value.UtcDateTime;


            #endregion
            return wRes;
        }
    }

 

}
