using System;
using System.Data.SqlClient;
using System.Runtime.Remoting;
using System.Web.Services.Protocols;
using System.Xml;
using System.Text;
using Fwk.Bases;

namespace Fwk.Exceptions
{
    /// <summary>
    /// Enumeracion que reprecenta los tipos de excepciones de 
    /// </summary>
    public enum FwkExceptionTypes
    {
        /// <summary>
        /// TechnicalException
        /// </summary>
        TechnicalException = 0,
        /// <summary>
        /// FunctionalException
        /// </summary>
        FunctionalException = 1,
        /// <summary>
        /// DispatcherTecnicalExeption
        /// </summary>
        DispatcherTecnicalExeption = 2,
        /// <summary>
        /// WrapperConnectionsException
        /// </summary>
        WrapperConnectionsException = 3,
        /// <summary>
        /// BlockingFunctionalException
        /// </summary>
        BlockingFunctionalException = 4,
        /// <summary>
        /// OtherException
        /// </summary>
        OtherException = 5
    }
    /// <summary>
    /// Clase que procesa excepciones.
    /// </summary>
    /// <Author>moviedo</Author>
    /// <Date>28-12-2005</Date>
    public class ExceptionHelper
    {
        #region --[Public Static Methods]--

        /// <summary>
        /// Realiza el mapeo de una Exception a un ServiceError
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <returns><see cref="ServiceError"/></returns>
        public static ServiceError GetServiceError(Exception ex)
        {
            
            ServiceError wServiceError = new ServiceError();
            wServiceError.Message = ex.Message;
            wServiceError.InnerMessageException = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            wServiceError.Source = ex.Source;
            wServiceError.StackTrace = ex.StackTrace;

            FwkExceptionTypes t = Fwk.Exceptions.ExceptionHelper.GetFwkExceptionTypes(ex);
            wServiceError.Type = Enum.GetName(typeof(FwkExceptionTypes), t);

            switch (t)
            { 
                case FwkExceptionTypes.TechnicalException:
                    {
                        TechnicalException tex =  (TechnicalException)ex;
                        wServiceError.ErrorId = tex.ErrorId;
                        wServiceError.Machine = tex.Machine;
                        wServiceError.UserName =  tex.UserName;
                        wServiceError.Namespace = tex.Namespace;
                        wServiceError.Class =  tex.Class;
                        wServiceError.Assembly = tex.Assembly;
                        
                        break;
                    }
                case FwkExceptionTypes.FunctionalException:
                    {
                        FunctionalException fex = (FunctionalException)ex;
                        wServiceError.ErrorId = fex.ErrorId;
                        wServiceError.Type = ex.GetType().Name;
                        break;
                    }
                case FwkExceptionTypes.OtherException:
                    {
                        
                        
                        wServiceError.Type = ex.GetType().Name;
                        break;
                    }
            }
            return wServiceError;
        }

        /// <summary>
        /// Procesa la excepcion original y la retorna.
        /// </summary>
        /// <param name="pexception">Excepcion original.</param>
        /// <returns>Excepcion procesada.</returns>
        public static Exception ProcessException(Exception pexception)
        {
            return ProcessException(pexception, null);
        }
        /// <summary>
        /// Procesa la excepcion original y la retorna.
        /// </summary>
        /// <param name="err"><see cref="ServiceError"/></param>
        /// <returns></returns>
        public static Exception ProcessException(ServiceError err)
        {
            Exception ex;
            Exception inner=null;
            if (!String.IsNullOrEmpty(err.InnerMessageException))
                inner = new Exception(err.InnerMessageException);
            switch (err.Type)
            {
                case "FunctionalException": case "Fwk.Exceptions.FunctionalException":
                    {
                        
                        if (inner!=null)
                        {
                            
                            if (!String.IsNullOrEmpty(err.ErrorId))
                                ex = new FunctionalException(Convert.ToInt32(err.ErrorId), inner, err.Message);
                            else
                                ex = new FunctionalException(null, inner, err.Message);
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(err.ErrorId))
                                ex = new FunctionalException(Convert.ToInt32(err.ErrorId),  err.Message);
                            else
                                ex = new FunctionalException(err.Message);
                        }
                        
                        ex.Source = err.Source;
                        ((FunctionalException)ex).ErrorId = err.ErrorId;
                        //((FunctionalException)ex).StackTrace = err.StackTrace;
                        break;
                    }
                case "TechnicalException": case "Fwk.Exceptions.TechnicalException":
                    {
                        ex = new TechnicalException(err.Message, inner);
                        ex.Source = err.Source;
                        ((TechnicalException)ex).ErrorId = err.ErrorId;
                        ((TechnicalException)ex).Machine = err.Machine;
                        ((TechnicalException)ex).UserName = err.UserName;
                        ((TechnicalException)ex).Namespace = err.Namespace;
                        ((TechnicalException)ex).Class = err.Class;
                        ((TechnicalException)ex).Assembly = err.Assembly;
                        //((TechnicalException)ex).StackTrace = err.StackTrace;
                        break;
                    }
                default:
                    {
                        ex = new Exception(err.Message  , inner);
                        break;
                    }
            }
           
           

            return    ex;
        }

        /// <summary>
        /// Procesa la excepcion original y la retorna.
        /// Si es SqlException Number >= 50000 retorna --> FunctionalException
        /// Si la excepcion es FunctionalException, o TechnicalException directamente las retorna
        /// Si es cualquier otro tipo de Excepcion, retorna una TechnicalException
        /// </summary>
        /// <param name="exception">Excepcion original.</param>
        /// <param name="sourceObject">Origen.</param>
        /// <returns>Excepcion procesada.</returns>
        public static Exception ProcessException(Exception exception, object sourceObject)
        {
            // Si la excepcion es de SQL Server evalua si debe retornar
            // una FunctionalException o una TechnicalException.
            if (exception is SqlException && ((SqlException)exception).Number >= 50000)
            {
                string[] wParams;
                string wMsgId = ProcessRaiseErrorMsg(exception.Message, out wParams);
                return new FunctionalException(null, wMsgId, wParams);
            }

            // Si la excepcion es FunctionalException, o TechnicalException,
            // simplemente la retorna.
            else if (exception is FunctionalException || exception is TechnicalException)
            {
                return exception;
            }

            // Si es cualquier otro tipo de Excepcion, retorna una
            // TechnicalException.
            else
            {
                if (sourceObject == null)
                {
                    return new TechnicalException(exception.Message, exception.InnerException);
                }
                else
                {
                    return new TechnicalException(sourceObject.GetType().AssemblyQualifiedName
                        , sourceObject.GetType().Namespace
                        , sourceObject.GetType().Name
                        , Environment.MachineName
                        , Environment.UserName
                        , exception);
                }
            }
        }

        /// <summary>
        /// <para>Transforma una excepción funcional en una SoapException,
        /// para poder serializarla a través de Soap.</para>
        /// </summary>
        /// <param name="pfex"></param>
        /// <param name="pabosoluteURI"></param>
        /// <returns></returns>
        public static SoapException ToSoapException(FunctionalException pfex, string pabosoluteURI)
        {
            return GetSoapException(pfex, pabosoluteURI);
        }

        /// <summary>
        /// Determina si una SoapException es de tipo funcional.
        /// </summary>
        /// <param name="psoapEx">SoapException.</param>
        /// <returns>Verdadero si la SoapException es de tipo funcional.</returns>
        public static bool IsFunctionalException(SoapException psoapEx)
        {
            string type = GetExceptionType(psoapEx);
            if (type == typeof(FunctionalException).FullName)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determina si una RemotingException es de tipo funcional.
        /// </summary>
        /// <param name="premEx">RemotingException.</param>
        /// <returns>Verdadero si la RemotingException es de tipo funcional.</returns>
        public static bool IsFunctionalException(RemotingException premEx)
        {
            if (premEx.GetType() == typeof(FunctionalException))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Genera un string con el contenido del InnerException .-
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static String GetAllMessageException(Exception ex)
        {
            StringBuilder wMessage = new StringBuilder();
            wMessage.Append(ex.Message);
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                wMessage.AppendLine(String.Concat("Source: ",ex.Source));
                wMessage.AppendLine();
                wMessage.AppendLine("Message: ");
                wMessage.AppendLine(ex.Message);
            }
            if (!String.IsNullOrEmpty(ex.StackTrace))
            {
                wMessage.AppendLine("\r\n-----------StackTrace------------------\r\n");
                wMessage.AppendLine(ex.StackTrace);
            }
            return wMessage.ToString();
        }

        /// <summary>
        /// Genera un string con el contenido del InnerException .-
        /// </summary>
        /// <param name="pExceptions">Array de excepciones</param>
        /// <returns></returns>
        public static String GetAllMessageException(Exception[] pExceptions)
        {
            StringBuilder wMessage = new StringBuilder();
            Exception inner;
            foreach (Exception ex in pExceptions)
            {
                wMessage.Append(ex.Message);
                while (ex.InnerException != null)
                {
                    inner = ex.InnerException;
                    wMessage.AppendLine(String.Concat("Source: ", inner.Source));

                    wMessage.AppendLine();
                    wMessage.AppendLine("Message: ");
                    wMessage.AppendLine(inner.Message);
                }
            }
            return wMessage.ToString();
        }

        /// <summary>
        /// Retorna el tipo <see cref="FwkExceptionTypes"/> de acuerdo al ex.GetType() de la excepción poasada por parametro
        /// </summary>
        /// <param name="ex">excepción</param>
        /// <returns><see cref="FwkExceptionTypes"/></returns>
        public static FwkExceptionTypes GetFwkExceptionTypes(Exception ex)
        {
            if (ex.GetType() == typeof(FunctionalException))
            {

                return FwkExceptionTypes.FunctionalException;
            }
            if (ex.GetType() == typeof(TechnicalException))
            {
                return FwkExceptionTypes.TechnicalException;
            }

            return FwkExceptionTypes.OtherException;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetFwkExceptionTypesName(Exception ex)
        {
            if (ex.GetType() == typeof(FunctionalException))
            {
                return  FwkExceptionTypes.FunctionalException.ToString();
            }
            if (ex.GetType() == typeof(TechnicalException))
            {
                return  FwkExceptionTypes.TechnicalException.ToString();
            }

            return FwkExceptionTypes.OtherException.ToString();

        }
        /// <summary>
        /// Retorna el error id de la excepción
        /// </summary>
        /// <param name="ex">excepción</param>
        /// <returns>ErrorId de la excepción </returns>
        public static string GetFwkErrorId(Exception ex)
        {
           
            if (GetFwkExceptionTypes(ex) == FwkExceptionTypes.FunctionalException || ex.GetType().BaseType == typeof(FunctionalException)) 
            {
                return ((FunctionalException)ex).ErrorId;
            }
            if (GetFwkExceptionTypes(ex) == FwkExceptionTypes.TechnicalException || ex.GetType().BaseType == typeof(TechnicalException)) 
            {
                return ((TechnicalException)ex).ErrorId;
            }
            return string.Empty;

        }
        /// <summary>
        /// Retorna el tipo de una SoapException.
        /// </summary>
        /// <param name="psoapEx">SoapException</param>
        /// <returns>Tipo de la SoapException.</returns>
        private static string GetExceptionType(SoapException psoapEx)
        {
            XmlElement elem = psoapEx.Detail as XmlElement;
            string type = String.Empty;

            if (elem != null && elem.SelectSingleNode("Type") != null)
                type = elem.SelectSingleNode("Type").InnerText;

            return type;
        }

        #endregion

        #region --[Private Static Methods]--

        /// <summary>
        /// Procesa los de SqlServer con el formato "Identificador_Mensaje;Param1;Param2...".
        /// </summary>
        /// <param name="pSqlEx">Mensaje de error con formato "Identificador_Mensaje;Param1;Param2...".</param>
        /// <param name="pParams">Parametros a reemplazar en el mensaje.</param>
        /// <returns>Mensaje de error.</returns>
        private static string ProcessRaiseErrorMsg(string pSqlEx, out string[] pParams)
        {
            try
            {
                /* Formato RAISEERROR: "Identificador_Mensaje;Param1;Param2 */
                string[] wRaiseErrorMsg = pSqlEx.Split(';');
                int wParamsLenght = wRaiseErrorMsg.Length - 1;

                // Obtiene los parametros;
                pParams = new string[wParamsLenght];
                for (int i = 0; i < wParamsLenght; i++)
                {
                    pParams[i] = wRaiseErrorMsg[i + 1];
                }

                // Retorna el MsgId.
                return wRaiseErrorMsg[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        /// <summary>
        /// Obtiene una SoapException.
        /// </summary>
        /// <param name="ex">Excepcion original.</param>
        /// <param name="pabosoluteURI">URI.</param>
        /// <returns>SoapException.</returns>
        private static SoapException GetSoapException(Exception ex, string pabosoluteURI)
        {
            // Build the detail element of the SOAP fault.
            XmlDocument doc = new XmlDocument();
            XmlNode node = doc.CreateNode(XmlNodeType.Element,
                SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

            XmlElement elem;

            elem = doc.CreateElement("Type");
            elem.InnerText = ex.GetType().FullName;
            node.AppendChild(elem);

            elem = doc.CreateElement("Message");
            elem.InnerText = ex.Message;
            node.AppendChild(elem);

            elem = doc.CreateElement("StackTrace");
            elem.InnerText = ex.StackTrace;
            node.AppendChild(elem);


            // Throw the exception
            return new SoapException("Fault occurred",
                SoapException.ClientFaultCode, pabosoluteURI, node);
        }
      

        #endregion


        /// <summary>
        /// Establece los valores basicos de error producido en el componente ADHelper
        /// </summary>
        /// <param name="te"></param>
        public static void SetTechnicalException<T>(Fwk.Exceptions.TechnicalException te)
        {
            te.Namespace = typeof(T).Namespace;
            te.Assembly = typeof(T).Assembly.FullName;
            te.Class = typeof(T).GetType().Name;
            te.UserName = Environment.UserName;
            te.Machine = Environment.MachineName;
            te.Source = ConfigurationsHelper.HostApplicationName;
        }
         /// <summary>
        /// Establece los valores basicos de error producido en el componente ADHelper
        /// </summary>
        /// <param name="te"></param>
        public static void SetTechnicalException(Fwk.Exceptions.TechnicalException te,Type T)
        {
            te.Namespace = T.Namespace;
            te.Assembly = T.Assembly.FullName;
            te.Class = T.GetType().Name;
            te.UserName = Environment.UserName;
            te.Machine = Environment.MachineName;
            te.Source = ConfigurationsHelper.HostApplicationName;
        }
    
    }
}
