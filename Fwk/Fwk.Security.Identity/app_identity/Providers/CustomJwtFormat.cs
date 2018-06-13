
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Linq;
using System.Configuration;
using System.IdentityModel.Tokens;
using Thinktecture.IdentityModel.Tokens;
using System.ServiceModel.Security.Tokens;
using System.Collections.Generic;

namespace Fwk.Security.Identity.Providers
{
    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {

        private readonly string _issuer = string.Empty;
        private readonly provider sec_provider = null;
        public CustomJwtFormat(string providerName)
        {
            
            sec_provider = helper.secConfig.GetByName(providerName);
            _issuer = sec_provider.issuer;
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            
            string audienceId = sec_provider.audienceId;//ConfigurationManager.AppSettings["audienceId"];

            string symmetricKeyAsBase64 = sec_provider.audienceSecret;// ConfigurationManager.AppSettings["audienceSecret"];

            var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);

            var signingKey = new HmacSigningCredentials(keyByteArray);
            //var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(keyByteArray);
            //var signingKey = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);

            var issuedAt = data.Properties.IssuedUtc;
            var expires = data.Properties.ExpiresUtc;

            var token = new JwtSecurityToken(_issuer, audienceId, data.Identity.Claims, issuedAt.Value.UtcDateTime, expires.Value.UtcDateTime, signingKey);

            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.WriteToken(token);

            return jwt;
        }





        /// <summary>
        ///  method which is responsible for validation of the JWT and returning and authentication ticket:
        /// </summary>
        /// <param name="protectedText"></param>
        /// <returns></returns>
        public AuthenticationTicket Unprotect(string protectedText)
        {


            if (string.IsNullOrWhiteSpace(protectedText))
            {
                throw new ArgumentNullException("protectedText");
            }
            string audienceId = sec_provider.audienceId;// ConfigurationManager.AppSettings["audienceId"];
            string symmetricKeyAsBase64 = sec_provider.audienceSecret;// ConfigurationManager.AppSettings["audienceSecret"];
            var tokenHandler = new JwtSecurityTokenHandler();
          
            SecurityToken validatedToken;
            

            var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);

            //TODO : CustomJwtFormat Esta lista de issuers debe ser flexible
            ///Establezco los issuers validos
            var issuers = new List<string>()
                {
                    "issuerA",
                    "issuerB",
                     "http://localhost:63251"
                };

            var validationParams = new TokenValidationParameters()
            {

                ValidAudience = audienceId,
                ValidIssuers = issuers,
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                RequireSignedTokens = true,
                RequireExpirationTime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningToken = new BinarySecretSecurityToken(keyByteArray)
            };
            try
            {
                var principal = tokenHandler.ValidateToken(protectedText, validationParams, out validatedToken);


                var identity = principal.Identities;

                // Fill out the authenticationProperties issued and expires times if the equivalent claims are in the JWT
                var authenticationProperties = new AuthenticationProperties();

                //issued 
                if (validatedToken.ValidFrom != DateTime.MinValue)
                {
                    authenticationProperties.IssuedUtc = validatedToken.ValidFrom.ToUniversalTime();
                }
                //expires 
                if (validatedToken.ValidTo != DateTime.MinValue)
                {
                    authenticationProperties.ExpiresUtc = validatedToken.ValidTo.ToUniversalTime();
                }

                return new AuthenticationTicket(identity.First(), authenticationProperties);
            }
            catch (Exception ex)
            {
                
                throw new UnauthorizedAccessException(ex.Message);

            }




        }
    }

}