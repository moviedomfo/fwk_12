using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;

using Fwk.Security.Cryptography;
using System.Data.SqlClient;
using Fwk.Logging;
using Fwk.Logging.Targets;
using Fwk.HelperFunctions;
using System.Net.Mail;
using System.Drawing;
using System.Drawing.Imaging;
using Fwk.Bases;

namespace $safeprojectname$.BE
{
    public class Common
    {
        public const string CnnStringName = "CNN_STRING";
        public static string CnnString_Entities = string.Empty;
        public static string CnnString = string.Empty;

     

        public static ISymetriCypher ISymetriCypher;

        /// <summary>
        /// Change this seed string with your own generated value
        /// </summary>
        public static string SEED_K = "SESshxdRu3p4ik3IOxM6/qAWmmTYUw8N1ZGIh1Pgh2w=$pQgQvA49Cmwn8s7xRUxHmA==";

        static Common()
        {

            if (!WrapperFactory.ProviderSection.DefaultProvider.WrapperProviderType.Equals("LocalWrapper"))
            {
                CnnString = System.Configuration.ConfigurationManager.ConnectionStrings[CnnStringName].ConnectionString;
                CnnString_Entities = System.Configuration.ConfigurationManager.ConnectionStrings["CNN_STRING_Entities"].ConnectionString;
            }
            ISymetriCypher = SymetricCypherFactory.Get<RijndaelManaged>(SEED_K);

            if (System.Configuration.ConfigurationManager.AppSettings["logOnFile"] != null)
                logOnFile = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["logOnFile"]);
        }

        public static bool IsEncrypted(System.Configuration.Configuration config)
        {
            if (config.AppSettings.Settings["crypt"] == null)
                return false;
            else
                return Convert.ToBoolean(config.AppSettings.Settings["crypt"].Value);
        }
        public static bool IsEncrypted()
        {
            if (System.Configuration.ConfigurationManager.AppSettings["crypt"] == null)
                return false;
            else
                return Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["crypt"]);
        }

        public static SqlConnection GetCnn(string cnnName)
        {
            System.Data.SqlClient.SqlConnection cnn = null;
            if (IsEncrypted())
            {
                cnn = new System.Data.SqlClient.SqlConnection(ISymetriCypher.Dencrypt(System.Configuration.ConfigurationManager.ConnectionStrings[cnnName].ConnectionString));
            }
            else
            {
                cnn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[cnnName].ConnectionString);
            }

            return cnn;
        }

        /// <summary>
        /// Crea una entrada en el visor de eventos
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="eventType"></param>
        public static void LogWinEvent(string msg, EventType eventType)
        {

            Event ev = new Event();
            ev.LogType = eventType;
            ev.Source = StaffArrivalServiceName;
            ev.Message.Text = msg;

            try
            {
                if (!logOnWindowsEvent)
                    StaticLogger.Log(TargetType.WindowsEvent, ev, string.Empty, string.Empty);

                Audit(msg);
            }
            catch (System.Security.SecurityException)
            {
                logOnWindowsEvent = false;

            }

        }
        static bool logOnWindowsEvent = true;
        /// <summary>
        /// Crea una entrada en log.xml
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="eventType"></param>
        public static void Audit(string msg)
        {
            if (!logOnFile) return;

            Event ev = new Event();
            ev.LogType = EventType.Audit;
            ev.Source = StaffArrivalServiceName;
            ev.Message.Text = msg;
            //StaticLogger.Log(ev, string.Empty, DateFunctions.Get_Year_Mont_Day_String(DateTime.Now, '-'));

            try
            {
                StaticLogger.Log(ev);
            }
            catch (System.Security.SecurityException)
            {
                logOnFile = false;

            }
        }



        // Hash an input string and return the hash as
        // a 32 character hexadecimal string.
        public static string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public static bool verifyMd5Hash(string input, string hash)
        {
            // Hash the input.
            string hashOfInput = getMd5Hash(input);
            return (hashOfInput.Equals(hash, StringComparison.OrdinalIgnoreCase));

        }

        /// <summary>
        /// Envia mail de acuerdo a las direcciones configuradas.
        /// </summary>
        public static void SendMail(string subjet, string body, string from, string to)
        {
            if (string.IsNullOrEmpty(from) || to.Length == 0)
                return;

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

            //SmtpClient wSmtpClient = new SmtpClient("smtp.gmail.com", 587);
            //wSmtpClient.EnableSsl = true;
            //NetworkCredential cred = new NetworkCredential("marcelo.oviedo", "");
            //wSmtpClient.Credentials = cred;

            //Inicializa un nuevo cliente smtp de acuerdo a las configuraciones 
            //obtenidas en la seccion mailSettings del archivo de configuracion.
            SmtpClient wSmtpClient = new SmtpClient();


            //Envia el correo electronico.
            try
            {

                wSmtpClient.Send(wMailMessage);
            }
            catch (Exception) { }
        }
      
    }
}
