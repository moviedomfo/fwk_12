using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;
//using Microsoft.Practices.EnterpriseLibrary.Data;
using Fwk.Security.Cryptography;
using System.Data.SqlClient;
using Fwk.Logging;
using Fwk.Logging.Targets;
using Fwk.HelperFunctions;
using System.Net.Mail;
using System.Drawing;
using System.Drawing.Imaging;

namespace VivaldiSite.DAC
{


    public class CommonDAC
    {
        public const string CnnStringName = "VivaldiSite";
        public static string CnnString = string.Empty; 
       

        internal static string ProcesingFile = "Procesing {0} \r\n InputFile: \r\n {1}";
        static Boolean logOnFile = false;
        internal static string AddressTemplate = "ftp://@{0}/{1}/{2}";
      
        
     

       
        internal static ISymetriCypher ISymetriCypher;
        public static string SEED_K = "SESshxdRu3p4ik3IOxM6/qAWmmTYUw8N1ZGIh1Pgh2w=$pQgQvA49Cmwn8s7xRUxHmA==";//"sec.key";

        static CommonDAC()
        {
            
            //ISymetriCypher = SymetricCypherFactory.Get<RijndaelManaged>(SEED_K);

            //if (System.Configuration.ConfigurationManager.AppSettings["logOnFile"] != null)
            //    logOnFile = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["logOnFile"]);

            //CnnString = System.Configuration.ConfigurationManager.ConnectionStrings[CnnStringName].ConnectionString;
        }

        public static bool IsEncrypted(System.Configuration.Configuration config)
        {
            if (config.AppSettings.Settings["crypt"] == null)
                return false;
            else
                return Convert.ToBoolean(config.AppSettings.Settings["crypt"].Value);
        }
        internal static bool IsEncrypted()
        {
            if (System.Configuration.ConfigurationManager.AppSettings["crypt"] == null)
                return false;
            else
                return Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["crypt"]);
        }

        internal static SqlConnection GetCnn(string cnnName)
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
       public static void SendMail_Me(string subjet, string body, string from)
       {
           if (string.IsNullOrEmpty(from))
               return;
           string commentTo = System.Configuration.ConfigurationManager.AppSettings["commentTo"].ToString();
           //Crea el nuevo correo electronico con el cuerpo del mensaje y el asutno.
           MailMessage wMailMessage = new MailMessage(from, commentTo) { Body = body, Subject = subjet };
           wMailMessage.IsBodyHtml = true;
           
           
           
           SmtpClient wSmtpClient = new SmtpClient();


           //Envia el correo electronico.
           try
           {

               wSmtpClient.Send(wMailMessage);
           }
           catch (Exception ex) {throw ex; }
       }

        /// <summary>
        /// Envia mail de acuerdo a las direcciones configuradas.
        /// </summary>
        public static void SendMail(string subjet, string body, string from, string to,string accountConfig)
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
            //NetworkCredential cred = new NetworkCredential("marcelo.oviedo", "santana668");
            //wSmtpClient.Credentials = cred;

            //Inicializa un nuevo cliente smtp de acuerdo a las configuraciones 
            //obtenidas en la seccion mailSettings del archivo de configuracion.
            SmtpClient wSmtpClient = new SmtpClient(accountConfig);

            
            //Envia el correo electronico.
            try
            {

                wSmtpClient.Send(wMailMessage);
            }
            catch (Exception ) { }
        }



      


        /// <summary>
        /// Este cdigo se encargar� de longitud / anchura en el cambio de tama�o.
        /// </summary>
        /// <param name="originalFile"></param>
        /// <param name="reducedFile"></param>
        /// <param name="lnWidth"></param>
        /// <param name="lnHeight"></param>
        /// <returns></returns>
        public static void ImageReduce(string originalFile, string reducedFile, int newWidth, int newHeight)
        {
            //System.Drawing.Bitmap bmpOut = null;

            using (Bitmap originalBMP = new Bitmap(originalFile))
            {
                ImageFormat originalFormat = originalBMP.RawFormat;
                //decimal lnRatio;
                int wNewWidth = newWidth;
                int wNewHeight = newHeight;
                if (originalBMP.Width <= newWidth && originalBMP.Height <= newHeight)
                {
                    originalBMP.Save(reducedFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return;
                }

                //if (originalBMP.Width > originalBMP.Height)
                //{
                //    lnRatio = (decimal)newWidth / originalBMP.Width;
                //    lnNewWidth = newWidth;
                //    decimal lnTemp = originalBMP.Height * lnRatio;
                //    lnNewHeight = (int)lnTemp;
                //}
                //else
                //{
                //    lnRatio = (decimal)newHeight / originalBMP.Height;
                //    lnNewHeight = newHeight;
                //    decimal lnTemp = originalBMP.Width * lnRatio;
                //    lnNewWidth = (int)lnTemp;
                //}

                using (Bitmap bmpOut = new Bitmap(wNewWidth, wNewHeight))
                {
                    Graphics g = Graphics.FromImage(bmpOut);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    g.FillRectangle(Brushes.White, 0, 0, wNewWidth, wNewHeight);
                    g.DrawImage(originalBMP, 0, 0, wNewWidth, wNewHeight);
                    //loBMP.Dispose();



                    bmpOut.Save(reducedFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }

        
    }


    public class WebUserControlsConstants
    {

        public const int ImgWidth_Small = 210;
        public const int ImgHeight_Small = 190;
        public const int ImgWidth_Medium = 450;
        public const int ImgHeight_Medium = 350;
       


        /// <summary>
        /// {4} id de la imagen coincide c0on el id del div q la contiene
        /// </summary>
        public const string UrlImageTemplate = "<p><img style=\"cursor:pointer;\" width=\"{3}\" height =\"{4}\" onclick=\"javascript:amply(this,'{5}')\" title=\"{0}\" src=\"{1}\" alt=\"{2}\" border=\"0\" /></p>";

        /// <summary>
        /// Obtiene 
        /// </summary>
        public const string ImageDiv = "<div id =\"{0}\" class=\"news_img {1}\">";

        /// <summary>
        /// facebook button Like
        /// {url}
        /// </summary>
        public const string fb_like = "  <fb:like href=\"{0}\" send=\"true\" width=\"450\" show_faces=\"true\" font=\"verdana\"></fb:like>";

        public const string history_line = "<hr class=\"bill_barr\" style =\"width:{0}px\" />";
    }
}
