using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Claims;

using Microsoft.Owin.Security;
using Fwk.Security.Identity.Providers;
using System.IdentityModel.Tokens;
using Newtonsoft.Json;

using System.IdentityModel.Tokens.Jwt;
using System.ServiceModel.Security.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;

namespace Fwk.Security.Identity.Test
{
    public partial class frmSecurityJWT : Form
    {
        jwtSecurityProvider sec_provider;
        Guid userId;
        List<string> issuers;
        public frmSecurityJWT()
        {
            InitializeComponent();
            sec_provider = helper.get_secConfig().GetByName("test");
             userId = Guid.NewGuid();
             issuers = new List<string>()
                {
                    "pelsoft",
                    "issuerA",
                    "issuerB",
                     "http://localhost:63251"
                };

        }

        private void btnKey_Click(object sender, EventArgs e)
        {
            var key = new byte[32];
            RNGCryptoServiceProvider.Create().GetBytes(key);

            txtAudienseHased.Text = TextEncodings.Base64Url.Encode(key);





        }

        private void btnGenerateToken1_Click(object sender, EventArgs e)
        {
            #region create claims & AuthenticationTicket
            ClaimsIdentity claims = GenerateClaims();

            var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                        "company", "CELAM"
                    }
                });
            //props.Dictionary.Add("userName", userName);
            //props.Dictionary.Add("userId", userId.ToString());
            //props.Dictionary.Add("lastLogInDate", res.User.LastLogInDate.ToString());
            //if (!string.IsNullOrEmpty(email))
            //    props.Dictionary.Add("email", email);
           var ticket = new AuthenticationTicket(claims, null);
            ticket.Properties.ExpiresUtc = System.DateTime.UtcNow.AddDays(10);  
            ticket.Properties.IssuedUtc = System.DateTime.UtcNow;
            #endregion


            CustomJwtFormat c = new CustomJwtFormat("test");

            var jwt = c.Protect(ticket);

            txtToken.Text = jwt;
        }

       

        string generateJWT_2()

        {

            ClaimsIdentity claims = GenerateClaims();

            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(sec_provider.audienceSecret));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);

            // Generamos el Token
            var token = new JwtSecurityToken
            (
                issuer: sec_provider.issuer,
                audience: sec_provider.audienceId,
                claims: claims.Claims,
                expires: DateTime.UtcNow.AddSeconds(10),
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
            );

       
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        

            return jwt;
        }

        private void btnGenerateToken_Click(object sender, EventArgs e)
        {

            txtToken2.Text = generateJWT_2();

        }

      

        private void btnValidateToken_Click(object sender, EventArgs e)
        {
            Microsoft.IdentityModel.Tokens.SecurityToken validatedToken;
        
            StringBuilder s = new StringBuilder();
            ClaimsPrincipal principal;
            // Generamos el Token
            var handler = new JwtSecurityTokenHandler();
            string symmetricKeyAsBase64 = sec_provider.audienceSecret;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(sec_provider.audienceSecret));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);



            var validationParams = new TokenValidationParameters()
            {

                ValidAudience = sec_provider.audienceId,
                ValidIssuers = issuers,
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                RequireSignedTokens = true,
                RequireExpirationTime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero,
                //IssuerSigningKeys = DefaultX509Key_Public_2048
                IssuerSigningKey = signingCredentials.Key
            };
    
            try
            {
                 principal = handler.ValidateToken(txtToken2.Text, validationParams, out validatedToken);

                #region print claims
                s.Append(GetAuthenticationTicketString(principal));

                #endregion

            }
            catch(Exception ex)
            {
                if(ex.Message.Contains("Base64"))
                    s.AppendLine("Token con formato no válido");
                if(ex.Message.Contains("IDX10223"))
                    s.AppendLine("Token Expiro");

                s.AppendLine(ex.Message);
            }

           
           
            txtAutenticatedValues2.Text = s.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            CustomJwtFormat jwtFormat = new CustomJwtFormat("test");
            AuthenticationTicket ticket = jwtFormat.Unprotect(txtToken.Text);


            var jwt = jwtFormat.Protect(ticket);
        

           
        
            txtAutenticatedValues.Text = GetAuthenticationTicketString(ticket);

        }
        private void frmSecurityJWT_Load(object sender, EventArgs e)
        {

        }


        ClaimsIdentity GenerateClaims()
        {
            var email = "moviedo@gmail.com";
            var userName = "moviedo";
            var userId = Guid.NewGuid().ToString();
            ClaimsIdentity claims = new ClaimsIdentity("ExternalBearer");
            claims.AddClaim(new Claim(ClaimTypes.Name, userName));
            if (!String.IsNullOrEmpty(email))
                claims.AddClaim(new Claim(ClaimTypes.Email, email));
            claims.AddClaim(new Claim("userId", userId));

            //    var claims = new[]
            //{
            //    new Claims("userName", JsonConvert.SerializeObject(userName)),
            //    new Claims("email", JsonConvert.SerializeObject(email)),
            //    new Claims("userId", JsonConvert.SerializeObject(userId))
            //};
            //}
            return claims;
        }


        string GetAuthenticationTicketString(AuthenticationTicket ticket)
        {
            StringBuilder s = new StringBuilder();

            var principal = ticket.Identity;
            s.AppendLine(" ----------------Claims--------------------- ");
            foreach (var item in principal.Claims)
            {
                s.AppendLine(item.Type + " " + item.Value);

            }
            s.AppendLine(" ------------------------------------- ");
            s.AppendLine("Identity IsAuthenticated " + principal.IsAuthenticated);
            s.AppendLine("Identity Name " + principal.Name);

            return s.ToString();
        }

        string GetAuthenticationTicketString(ClaimsPrincipal principal)
        {
            StringBuilder s = new StringBuilder();

         
            s.AppendLine(" ----------------Claims--------------------- ");
            foreach (var item in principal.Claims)
            {
                s.AppendLine(item.Type + " " + item.Value);

            }
            s.AppendLine(" ------------------------------------- ");
            s.AppendLine("Identity IsAuthenticated " + principal.Identity.IsAuthenticated);
            s.AppendLine("Identity Name " + principal.Identity.Name);

            return s.ToString();
        }


    }
}
