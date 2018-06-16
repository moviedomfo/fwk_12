using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using Fwk.HelperFunctions;
using System.Collections.Generic;
using Fwk.Exceptions;

namespace Fwk.Security.Identity
{
    public class helper
    {
        public static secConfig secConfig = null;
        static helper()
        {
            //return;
            //var currentDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            try
            {

                

                //"secConfig.json"
                string settingName = System.Configuration.ConfigurationManager.AppSettings["secConfig"];  
                //"secConfig.json";//string.Format("apiConfig.{0}.json", env);


                string apiConfigString = FileFunctions.OpenTextFile( settingName);
                secConfig = (secConfig)SerializationFunctions.DeSerializeObjectFromJson(typeof(secConfig), apiConfigString);

         
            }
            catch (Exception ex)
            {
                
            }


            Fwk.HelperFunctions.DateFunctions.BeginningOfTimes = new DateTime(1753, 1, 1);

        }
        

        /// <summary>
        /// Envia mail de acuerdo a las direcciones configuradas.
        /// </summary>
        public static Task SendMailAsynk(string subjet, string body, string from, string to)
        {
            //if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
            //    return null;

            String smtp = Fwk.Configuration.ConfigurationManager.GetProperty("MailSettings", "smtp");
            Int32 port = Convert.ToInt32(Fwk.Configuration.ConfigurationManager.GetProperty("MailSettings", "port"));
            Boolean enableSsl = Convert.ToBoolean(Fwk.Configuration.ConfigurationManager.GetProperty("MailSettings", "enableSsl"));

            String email = Fwk.Configuration.ConfigurationManager.GetProperty("MailSettings", "email");
            String username = Fwk.Configuration.ConfigurationManager.GetProperty("MailSettings", "username");
            String pwd = Fwk.Configuration.ConfigurationManager.GetProperty("MailSettings", "password");

            if (String.IsNullOrEmpty(from))
            {
                from = email;
            }
            //Crea el nuevo correo electronico con el cuerpo del mensaje y el asutno.
            MailMessage wMailMessage = new MailMessage() { Body = body, Subject = subjet };
            wMailMessage.IsBodyHtml = true;

            //Asigna el remitente del mensaje de acuerdo a direccion obtenida en el archivo de configuracion.
            wMailMessage.From = new MailAddress(from);
            //Asigna los destinatarios del mensaje de acuerdo a las direcciones obtenidas en el archivo de configuracion.
            //foreach (string recipient in MailRecipients)
            //{
            wMailMessage.To.Add(new MailAddress(to));
            //}

            SmtpClient smtpClient = new SmtpClient(smtp, port);
            smtpClient.EnableSsl = enableSsl;
            smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            NetworkCredential cred = new NetworkCredential(username, pwd);
            smtpClient.Credentials = cred;


            //Envia el correo electronico.
            //try
            //{

            return smtpClient.SendMailAsync(wMailMessage);
            //}
            //catch (Exception) { }
        }

        public static string GetHash(string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();

            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(input);

            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        internal static string CustomGeneratePasswordResetToken(String userData)
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Encoding.ASCII.GetBytes(userData);
            string token = Convert.ToBase64String(time.Concat(key).ToArray());

            return token;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userData"></param>
        /// <param name="token"></param>
        /// <param name="expirationTime"></param>
        /// <param name="expirationFormat"></param>
        /// <returns></returns>
        internal Boolean CustomValidateToken(String userData, String token, Int32 expirationTime, ExpirationFormat expirationFormat)
        {
            byte[] data = Convert.FromBase64String(token);
            DateTime time = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
            String tokenUserData = BitConverter.ToString(data, 8);
            DateTime dt = DateTime.UtcNow;
            switch (expirationFormat)
            {
                case ExpirationFormat.MINUTES:
                    {
                        dt = dt.AddMinutes(-expirationTime);
                        break;
                    }
                case ExpirationFormat.DAY:
                    {
                        dt = dt.AddMinutes(-expirationTime);
                        break;
                    }
                case ExpirationFormat.SECONDS:
                    {
                        dt = dt.AddSeconds(-expirationTime);
                        break;
                    }
                case ExpirationFormat.HOURS:
                    {
                        dt = dt.AddHours(-expirationTime);
                        break;
                    }
            }
            return (time < DateTime.UtcNow.AddMinutes(-expirationTime) || tokenUserData.CompareTo(userData) != 0);

        }
        public enum ExpirationFormat
        {
            DAY,
            MINUTES,
            SECONDS,
            HOURS
        }
    }


    public class secConfig
    {
        public List<provider> providers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerName"></param>
        /// <returns></returns>
        public provider GetByName(string providerName)
        {
            if (string.IsNullOrEmpty(providerName))
                return this.providers.First();
            else
                return this.providers.Where(p => p.name.Equals(providerName)).FirstOrDefault();
            
        }

        /// <summary>
        /// retorna el nombre de una cadena de conexion configurada .-
        /// </summary>
        /// <param name="providerName"></param>
        /// <returns></returns>
        public string Getcnnstring(string providerName)
        {
            TechnicalException te = null;
            var prov = GetByName(providerName);
            if(prov==null)
            {
                
                if (string.IsNullOrEmpty(providerName))
                    te = new TechnicalException("Fwk.Security.Identity error : No se puede obtener el proveedor de seguridad por defecto");
                else
                 te = new TechnicalException("Fwk.Security.Identity error : No se puede obtener el proveedor de seguridad " + providerName);

                ExceptionHelper.SetTechnicalException<SecurityManager>(te);
                te.ErrorId = "4500";
                throw te;
            }

            if (string.IsNullOrEmpty(prov.securityModelContext))
            {
                te = new TechnicalException("Fwk.Security.Identity error : el proveedor " +  providerName + " no tiene un nombre de cadena de conexión configurada");

                ExceptionHelper.SetTechnicalException<SecurityManager>(te);
                te.ErrorId = "4501";
                throw te;
            }
            return prov.securityModelContext;
        }
    }


    public class provider
    {
        public string name { get; set; }
        public string audienceId { get; set; }
        public string issuer { get; set; }
        public string audienceSecret { get; set; }
        public string securityModelContext { get; set; }

    }

    //public static class JwtManager
    //{


    //    /// <summary>
    //    /// Use the below code to generate symmetric Secret Key
    //    ///     var hmac = new HMACSHA256();
    //    ///     var key = Convert.ToBase64String(hmac.Key);
    //    /// </summary>
    //    public const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

    //    public static string GenerateToken(LoginModel loginUser, int expireMinutes = 2)
    //    {
    //        var symmetricKey = Convert.FromBase64String(Secret);
    //        var tokenHandler = new JwtSecurityTokenHandler();

    //        var now = DateTime.UtcNow;
    //        var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
    //        {
    //            Subject = new ClaimsIdentity(new[]
    //                    {
    //                        new Claim(ClaimTypes.Name, loginUser.userName),
    //                        new Claim(ClaimTypes.Email, loginUser.email)

    //                    }),

    //            Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),

    //            SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
    //                new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(symmetricKey),
    //            Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
    //        };

    //        var stoken = tokenHandler.CreateToken(tokenDescriptor);
    //        var token = tokenHandler.WriteToken(stoken);

    //        return token;
    //    }

    //    public static ClaimsPrincipal GetPrincipal(string token)
    //    {
    //        try
    //        {
    //            var tokenHandler = new JwtSecurityTokenHandler();
    //            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

    //            if (jwtToken == null)
    //                return null;

    //            var symmetricKey = Convert.FromBase64String(Secret);

    //            var validationParameters = new TokenValidationParameters()
    //            {
    //                RequireExpirationTime = true,
    //                ValidateIssuer = false,
    //                ValidateAudience = false,
    //                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(symmetricKey)
    //            };

    //            Microsoft.IdentityModel.Tokens.SecurityToken securityToken;
    //            var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

    //            return principal;
    //        }

    //        catch (Exception)
    //        {
    //            return null;
    //        }
    //    }
    //}
}