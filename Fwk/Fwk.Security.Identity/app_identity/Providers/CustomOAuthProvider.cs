using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Fwk.Security.Identity;
using System.Net.Http;
using System.Web;
using System;
using System.Linq;

namespace Fwk.Security.Identity.Providers
{

    /// <summary>
    /// Meddleware que autentica
    /// </summary>
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;
            SecurityClient client = null;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                //Remove the comments from the below line context.SetError, and invalidate context 
                //if you want to force sending clientId/secrects once obtain access tokens. 
                //context.Validated();
                context.SetError("invalid_clientId", "Debe enviar el client_id");
                return Task.FromResult<object>(null);
            }

            //TODO: Fwk.Security.Identity revisar sec_prvider  OAuthAuthorizationServerProvider 
            client = SecurityManager.ClientFind(context.ClientId, "");
            
           

            if (client == null)
            {
                context.SetError("invalid_clientId", string.Format("Client '{0}' is not registered in the system.", context.ClientId));
                return Task.FromResult<object>(null);
            }

            if (client.ApplicationType == (int)ApplicationTypes.NativeConfidential)
            {
                if (string.IsNullOrWhiteSpace(clientSecret))
                {
                    context.SetError("invalid_clientId", "Client secret should be sent.");
                    return Task.FromResult<object>(null);
                }
                else
                {
                    if (client.Secret != helper.GetHash(clientSecret))
                    {
                        context.SetError("invalid_clientId", "Client secret is invalid.");
                        return Task.FromResult<object>(null);
                    }
                }
            }

            if (!client.Active)
            {
                context.SetError("invalid_clientId", "Client is inactive.");
                return Task.FromResult<object>(null);
            }

            context.OwinContext.Set<string>("as:clientAllowedOrigin", client.AllowedOrigin);
            context.OwinContext.Set<string>("as:clientRefreshTokenLifeTime", client.RefreshTokenLifeTime.ToString());

            context.Validated();
            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Called when a request to the Token endpoint arrives with a "grant_type" of "password".
        /// el usuario provee user & password y client_id + client_secret
        /// Para emitir el access_token se debe llamar al metodo context.Validated,  con un nuevo ticket que contenga los claims
        /// sobre el propietario del recurso que debería estar asociado con el token de acceso
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
          

            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");

            if (allowedOrigin == null) allowedOrigin = "*";
           

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            #region auth


            //var signInManager = context.OwinContext.Get<ApplicationSignInManager>();

            // This dosn't count login failures towards lockout only two factor authentication
            // To enable password failures to trigger lockout, change to shouldLockout: true
            //var result = signInManager.PasswordSignIn<ApplicationUser, Guid>(context.UserName, context.Password, false, shouldLockout: false);
            //TODO: Fwk.Security.Identity revisar sec_prvider  OAuthAuthorizationServerProvider 
            LoginResult res = SecurityManager.User_Authenticate(context.UserName, context.Password, "");
            //context.SetError("invalid_grant", "LockedOut");

            SignInStatus s = (SignInStatus)Enum.Parse(typeof(SignInStatus), res.Status) ;
            switch (s)
            {
                case SignInStatus.Success:
                    {
                        res.Status = "Success";
                        break;
                    }
                default:
                    {
                        context.SetError(res.Status, res.Message);
                        return;                     
                    }


            }
            #endregion

            #region generamos los claims para este usuario
            ClaimsIdentity oAuthIdentity = SecurityManager.GenerateClaimsIdentity(res.User);

            List<string> roles =null;
            if (res.User.SecurityRoles.Count != 0)
            {
                roles = new List<String>();
                res.User.SecurityRoles.ToList().ForEach(r => {
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
            props.Dictionary.Add("userId", res.User.Id.ToString());
            props.Dictionary.Add("lastLogInDate", res.User.LastLogInDate.ToString());
            if(!string.IsNullOrEmpty(res.User.Email))
                props.Dictionary.Add("email", res.User.Email);
            if (roles!=null)
                props.Dictionary.Add("roles", Fwk.HelperFunctions.FormatFunctions.GetStringBuilderWhitSeparator(roles, ',').ToString());
            props.Dictionary.Add("Status", res.Status);
            #endregion
            //Construccion de ticket
            var ticket = new AuthenticationTicket(oAuthIdentity, props);
            
            //Codigo antes de implementar refresh-token
            // ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, "JWT");
            //var ticket = new AuthenticationTicket(oAuthIdentity, null);
            // con el ticket aqui se generará el access-token
            context.Validated(ticket);

        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }


        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Se invoca cuando llega una solicitud del Token con un "grant_type" = "refresh_token"
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClient = context.Ticket.Properties.Dictionary["client_id"];
            var currentClient = context.ClientId;

            if (originalClient != currentClient)
            {
                context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");
                return Task.FromResult<object>(null);
            }

            // Change auth ticket for refresh token requests
            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
            newIdentity.AddClaim(new Claim("newClaim", "newValue"));

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            //Luego de esto se va al método RefreshTokenProvider.CreateAsynck 
            return Task.FromResult<object>(null);
        }
    }
}