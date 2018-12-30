using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Fwk.Bases;

namespace Fwk.Exceptions
{
    /// <summary>
    /// Clase especializada en procesar erroes producidos en el Wrappper de aplicaciones
    /// cuando un cliente intenta conectarce a un Despachador de servicios.-
    /// </summary>
    public class ProcessConnectionsException
    {
      


        /// <summary>
        /// Procesa la exepcion que se produce al intentar conectarce al cliente y genera un 
        /// ServiceError el cual es insertado al Response.-
        /// </summary>
        /// <param name="pEx">Exepcion</param>
        /// <param name="pURL">Direccion web del servicio web donde esta el despachador de servicio</param>
        /// <returns>ServiceError <see cref="ServiceError"/></returns>
        public static ServiceError Process(Exception pEx, String pURL)
        {

            ServiceError wServiceError = null;
            switch (pEx.GetType().FullName)
            {
                case "System.Net.WebException":
                    {
                        wServiceError = ProcessWebException((System.Net.WebException)pEx, pURL);
                        wServiceError.Assembly = "Fwk.Bases.Connector.dll";
                        wServiceError.Namespace = "Fwk.Bases.Connector";
                        wServiceError.Class = "Wrapper : IServiceInterfaceWrapper";
                        wServiceError.ErrorId = "1000";
                        break;
                    }
                case "Fwk.Exceptions.TechnicalException":
                    {
                        TechnicalException te = (TechnicalException)pEx;
                        wServiceError = ProcessDefaultException(pEx);
                        wServiceError.Assembly = te.Assembly;
                        wServiceError.Namespace = te.Namespace;
                        wServiceError.Class = te.Class;
                        wServiceError.ErrorId = te.ErrorId;
                        wServiceError.Source = te.Source;
                        break;
                    }
                default:
                    { 
                        wServiceError = ProcessDefaultException(pEx);
                        wServiceError.Assembly = "Se desconoce.. examine el error";
                        wServiceError.Namespace = "Se desconoce.. examine el error";
                        wServiceError.Class = "Wrapper : IServiceInterfaceWrapper";
                        break;
                       
                    }
            }


            wServiceError.UserName = Environment.UserName;
            wServiceError.Machine = Environment.MachineName;
            wServiceError.StackTrace = pEx.StackTrace;
            if (string.IsNullOrEmpty(ConfigurationsHelper.HostApplicationName))
                wServiceError.Source = "Cliente " + Environment.MachineName;
            else
                wServiceError.Source = ConfigurationsHelper.HostApplicationName;

            wServiceError.Type = ExceptionHelper.GetFwkExceptionTypesName(pEx);//pEx.GetType().FullName;

            return wServiceError;
        }

        

        /// <summary>
        /// Procesa la exepcion que se produce al intentar conectarce al cliente y genera un 
        /// ServiceError el cual es insertado al Response.-
        /// </summary>
        /// <param name="pEx">Exepcion</param>
        /// <returns>ServiceError <see cref="ServiceError"/></returns>
        public static ServiceError Process(Exception pEx)
        { 
            
            return Process(pEx, String.Empty);
           
        }

        /// <summary>
        /// Procesa las exepciones no detectadas <see cref="System.Web.Services.Protocols.SoapException"/>
        /// </summary>
        /// <param name="pException">Exception por defecto producida <see cref="System.Web.Services.Protocols.SoapException"/></param>
        /// <returns>ServiceError <see cref="ServiceError"/></returns>
        private static ServiceError ProcessDefaultException(Exception pException)
        {
            ServiceError wServiceError = new ServiceError();
            StringBuilder wMessage = new StringBuilder();


            wMessage.AppendLine("Ocurrio un problema al intentar ejecutar un servicio.");
            wMessage.AppendLine();
            wMessage.AppendLine("Mensaje: ");
            wMessage.AppendLine(pException.Message);
            wServiceError.StackTrace = pException.StackTrace;
            wServiceError.Message = wMessage.ToString();
            wServiceError.ErrorId = "6000";
            if (pException.InnerException != null)
                wServiceError.InnerMessageException = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(pException.InnerException); 

            wMessage = null;
          

            return wServiceError;
        }

     
 

  

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pWebException"></param>
        /// <param name="pURL"></param>
        /// <returns>ServiceError <see cref="ServiceError"/></returns>
        private static ServiceError ProcessWebException(WebException pWebException, String pURL)
        {
            ServiceError wServiceError = new ServiceError();
            StringBuilder wMessage = new StringBuilder();

            wMessage.AppendLine("Ocurrio un problema al intentar conectarce al Servicio Web. " + GetGenericStatusCode(pWebException));


            wMessage.AppendLine("Verifique en el archivo de configuración si la direccion url del servicio es correcta");
            wMessage.AppendLine("y de ser asi si el servicio esta activo o el host donde esta alojado el IIS funciona correctamente");
            wMessage.AppendLine("--------------------------------------------------------------------------");
            wMessage.Append("URL : ");
            wMessage.AppendLine(pURL);
            wMessage.AppendLine();

            wMessage.AppendLine(pWebException.Message);

            wMessage.AppendLine("Verifique el código de estado mostrado arriba para revelar ");
            wMessage.AppendLine("la razón exacta por la que una solicitud no se realiza correctamente en el siguiente enlace: ");
            wMessage.AppendLine("http://support.microsoft.com/kb/318380/es");

            wServiceError.Message = wMessage.ToString();
            if (pWebException.InnerException != null)
                wServiceError.InnerMessageException = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(pWebException.InnerException); 

            wMessage = null;

            return wServiceError;
        }

        /// <summary>
        /// Obtiene el menzage general para un grupo de codigos de estados, estos pueden ser:
        /// 3xx - Redirección
        ///       El explorador cliente debe realizar más acciones para cumplir la solicitud. 
        ///       Por ejemplo, puede que el explorador tenga que solicitar una página diferente en el servidor o repetir la solicitud 
        ///       utilizando un servidor proxy.
        /// 4xx - Error del cliente 
        ///       Se produce un error, que parece causado por el cliente. Por ejemplo, el cliente puede solicitar una página que no existe o quizás no proporcione información de autenticación válida.
        /// 5xx - Error del servidor
        ///       El servidor no puede terminar la solicitud porque encuentra un error.
        /// </summary>
        /// <param name="pWebException"></param>
        /// <returns>String </returns>
        private static String GetGenericStatusCode(WebException pWebException)
        {
            String str = String.Empty;

            if (pWebException.Message.Contains("3"))
            {
                str = "El error es de Redirección (estado: ";
            }
            //Se produce un error, que parece causado por el cliente. Por ejemplo, el cliente puede solicitar una página que no existe o quizás no proporcione información de autenticación válida.
            if (pWebException.Message.Contains("4"))
            {
                str = "El error es del lado del cliente (estado: ";
            }
            //El servidor no puede terminar la solicitud porque encuentra un error.
            if (pWebException.Message.Contains("5"))
            {
                str = "El error es del lado del servidor (estado: ";
            }

            if (pWebException.Status == WebExceptionStatus.ConnectFailure && str == String.Empty)
            {
                //Falta de archivo de configuracion 
                str = "El error es del lado del cliente y posiblemente se deba a un problema con el archivo de configuracion .config.";
                str += "Verifique si este existe donde corre el proceso que realiza peticiones al Despachador de servicios";
            }


            return str + pWebException.Status.ToString() + ") ";
        }
    }
}
