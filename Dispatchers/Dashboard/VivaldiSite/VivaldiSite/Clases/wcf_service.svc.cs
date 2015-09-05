using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using VivaldiSite.DAC;
using System.Web;

//namespace VivaldiSite
//{

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class wcf_service : Iwcf_service
    {


        #region Iwcf_service Members

        public void SendMessage(string contactName, string message, string email, string phone, string city, string state)
        {
            //Esta funcion se puede usar porque  AspNetCompatibilityRequirementsMode.Allowed

            string ruta = HttpContext.Current.Server.MapPath("..");
            string file = System.IO.Path.Combine(ruta, "Email_contactenos.htm");
            string txt = Fwk.HelperFunctions.FileFunctions.OpenTextFile(file);
            StringBuilder BODY = new StringBuilder(txt);
            BODY.Replace("$contactName$", contactName);
            BODY.Replace("$email$", email);
            BODY.Replace("$phone$", phone);
            BODY.Replace("$city$", city);
            BODY.Replace("$state$", state);
            BODY.Replace("$message$", message);

            //string body= String.Format(txt, contactName, email, phone, city, state, message);

            CommonDAC.SendMail_Me(string.Concat("Mensaje de contacto de ", contactName), BODY.ToString(), email);
        }
        public String SendMessage2(string contactName, string message)
        {

            return "listo";

        }

        public String ConnectToWebService(string url)
        {
         
            if (DataCoreDAC.Dispatcher_Exist(null, url))
                return "La Url ya se encuentra regiustrada en nuestro sitio";

            Fwk.Bases.Connector.WebServiceWrapper wrapper = new Fwk.Bases.Connector.WebServiceWrapper();
            wrapper.SourceInfo = url;
          
            try
            {
                var ac = wrapper.GetProviderInfo("");

            }
            catch (System.Web.Services.Protocols.SoapException er)
            {
               // throw new Exception("El servicio web no es compatible con un despachador de servicios Fwk V 10.3.0.0", er);
                return String.Concat ("El servicio web no es compatible con un despachador de servicios Fwk V 10.3.0.0\r\n", er.Message);
                
            }
            catch (Exception exception)
            {

                //Response.setStatus(400);
                //Response.getWriter().write(String.Concat("Ocurrieron errores al intentar conectarce al despachador de servicio", exception.getMessage()));
                //throw new Exception("Ocurrieron errores al intentar conectarce al despachador de servicio", exception);
                return exception.Message;
            }
            return String.Empty;
        }

        public String ChekDisponibility(string instanceName)
        {
            if (String.IsNullOrEmpty(instanceName))

                return "Ingrese un valor para el nombre de instancia";
            if (DataCoreDAC.Dispatcher_Exist(instanceName, null))
                return "El nombre de instancia ya fue registrado";

            return string.Empty;
        }
        #endregion
    }
    [ServiceContract(Namespace = "")]
    //[ServiceContract(Namespace = "http://pelsoftit.net")]
    //[ServiceContract] //agrega http://tempuri.org
    public interface Iwcf_service
    {

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Xml)]
        void SendMessage(string contactName, string message, string email, string phone, string city, string state);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Xml)]
        String SendMessage2(string contactName, string message);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        String ConnectToWebService(string url);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        String ChekDisponibility(string instanceName);
    }

//}