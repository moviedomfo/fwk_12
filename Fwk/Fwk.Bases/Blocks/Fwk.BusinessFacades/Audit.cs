using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Logging;
using Fwk.Bases;
using Fwk.Exceptions;
using Fwk.ConfigData;
using Fwk.HelperFunctions;
using Fwk.Logging.Targets;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Fwk.BusinessFacades.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class Audit
    {

        /// <summary>
        /// Genera un log de tipo "Warning" cuando se ha intentado ejecutar
        /// un servicio que está deshabilitado.
        /// </summary>
        /// <param name="pConfig">configuración del servicio.</param>
        /// <param name="pServiceError">pServiceError </param> 
        internal static void LogNotAvailableExcecution(ServiceConfiguration pConfig, out ServiceError pServiceError)
        {
             pServiceError = new ServiceError();


            StringBuilder s = new StringBuilder();
     
            s.AppendLine("Se ha intentado ejecutar un servicio que está configurado como no disponible.");
            s.AppendLine("Service :");
            s.AppendLine(pConfig.Handler);
            pServiceError.Type = FwkExceptionTypes.TechnicalException.ToString();
            pServiceError.Message = s.ToString();
            pServiceError.ErrorId = "7006";
            pServiceError.Assembly = "Fwk.BusinessFacades";
            pServiceError.Class = "Audit";
            pServiceError.Namespace = "Fwk.BusinessFacades";
            pServiceError.UserName = Environment.UserName;
            pServiceError.Machine = Environment.MachineName;
            try
            {
                /// TODO: ver prefijo del log
                Event ev = new Event(EventType.Error,Fwk.Bases.ConfigurationsHelper.HostApplicationName, pServiceError.GetXml(), pServiceError.Machine, pServiceError.UserName);
                Fwk.Logging.StaticLogger.Log(ev);
            }
            catch { }
           
        }

        /// <summary>
        /// Log error from dispatcher on xml File
        /// </summary>
        /// <param name="ex"></param>
        internal static TechnicalException LogDispatcherErrorConfig(Exception ex)
        {
            StringBuilder s = new StringBuilder("Se ha intentado levantar el despachador de servicios.");
            s.AppendLine("Verifique que esten correctamente configurados en el .config los AppSettings.");
            s.AppendLine("ServiceDispatcherName y ServiceDispatcherConnection");
            var logType = EventType.Audit;
            if (ex != null)
            {
                s.AppendLine("..................................");
                s.AppendLine("Error Interno:");
                s.AppendLine(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
                logType = EventType.Error;
            }

            TechnicalException te = new TechnicalException(s.ToString());
            te.ErrorId = "7007";
            Fwk.Exceptions.ExceptionHelper.SetTechnicalException<FacadeHelper>(te);
            
            
            try
            {
                // TODO: ver prefijo del log
                Fwk.Logging.Event ev = new Fwk.Logging.Event(logType, 
                    Fwk.Bases.ConfigurationsHelper.HostApplicationName,
                    s.ToString(), Environment.MachineName, Environment.UserName);

                Fwk.Logging.Targets.XmlTarget target = new Logging.Targets.XmlTarget();
                target.FileName = String.Concat(Fwk.HelperFunctions.DateFunctions.Get_Year_Mont_Day_String(DateTime.Now,'-') ,"_", "DispatcherErrorsLog.xml");

                target.Write(ev);
               

            }
            catch { }
            return te;
        }
        /// <summary>
        /// Log error from dispatcher on xml File
        /// </summary>
        /// <param name="ex"></param>
        internal static  void LogDispatcherError(Exception ex)
        {
           
            try
            {
                // TODO: ver prefijo del log
                Fwk.Logging.Event ev = new Fwk.Logging.Event( EventType.Error,
                    Fwk.Bases.ConfigurationsHelper.HostApplicationName,
                    ex.Message, Environment.MachineName, Environment.UserName);

                Fwk.Logging.Targets.XmlTarget target = new Logging.Targets.XmlTarget();
                target.FileName = String.Concat(Fwk.HelperFunctions.DateFunctions.Get_Year_Mont_Day_String(DateTime.Now, '-'), "_", "DispatcherErrorsLog.xml");

                //Fwk.Logging.StaticLogger.Log(
                target.Write(ev);


            }
            catch { }
            
        }
  

        /// <summary>
        /// Genera un log de tipo "Error" cuando se ha producido
        /// un error en la  ejecución del servicio.
        /// </summary>
        /// <param name="pRequest">Request</param>
        /// <param name="wResult">Response</param>
        public static void LogNonSucessfulExecution(IServiceContract pRequest, IServiceContract wResult) //ServiceError pServiceError, ServiceConfiguration pConfig)
        {
           
            fwk_ServiceAudit audit = new fwk_ServiceAudit();

            audit.LogTime = System.DateTime.Now;
            audit.ServiceName = pRequest.ServiceName;
            audit.Send_Time = pRequest.ContextInformation.HostTime;
           
            if (Fwk.HelperFunctions.DateFunctions.IsSqlDateTimeOutOverflow(wResult.ContextInformation.HostTime) == false)
                audit.Resived_Time = wResult.ContextInformation.HostTime;
            else
            {
                audit.Resived_Time = wResult.ContextInformation.HostTime = DateTime.Now;

            }
            audit.Send_UserId = pRequest.ContextInformation.UserId;
            audit.Send_Machine = pRequest.ContextInformation.HostName;

            audit.Dispatcher_Instance_Name = FacadeHelper.ServiceDispatcherConfig.InstanseName;
            audit.ApplicationId = pRequest.ContextInformation.AppId;

            audit.Requets = TypeFunctions.ConvertStringToByteArray(pRequest.GetXml());
            audit.ServiceError = TypeFunctions.ConvertStringToByteArray(wResult.Error.GetXml());
            audit.Message = wResult.Error.Message;
            audit.Logtype = Enum.GetName(typeof(Fwk.Logging.EventType), Fwk.Logging.EventType.Error);
            try
            {
                using (FwkDatacontext context = new FwkDatacontext(System.Configuration.ConfigurationManager.ConnectionStrings[ConfigurationsHelper.ServiceDispatcherConnection].ConnectionString))
                {
                    context.fwk_ServiceAudits.InsertOnSubmit(audit);
                    context.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                TechnicalException te = new TechnicalException("No se pudo insertar la auditoria de la ejecucion de un servicio.-  " + ex.Message.ToString(), ex);
                te.ErrorId = "7010";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(Audit));
                LogDispatcherError(ex);

            }
            
            }
        public static void LogNonSucessfulExecution(fwk_ServiceAudit audit) //ServiceError pServiceError, ServiceConfiguration pConfig)
        {

          
            audit.LogTime = System.DateTime.Now;
            audit.Dispatcher_Instance_Name = FacadeHelper.ServiceDispatcherConfig.InstanseName;

            audit.Logtype = Enum.GetName(typeof(Fwk.Logging.EventType), Fwk.Logging.EventType.Error);

            try
            {
                using (FwkDatacontext context = new FwkDatacontext(System.Configuration.ConfigurationManager.ConnectionStrings[ConfigurationsHelper.ServiceDispatcherConnection].ConnectionString))
                {
                    context.fwk_ServiceAudits.InsertOnSubmit(audit);
                    
                    context.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("No se pudo insertar la auditoria de la ejecucion de un servicio.-  " + ex.Message.ToString(), ex);
                te.ErrorId = "7010";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te,typeof(Audit));
                LogDispatcherError(ex);
            }

        }
        /// <summary>
        /// Almacena informacion de auditoria.- 
        /// Llama a StaticLogger y carga el log auditando los datos del Request de entrada
        /// </summary>
        /// <param name="pRequest">Request</param>
        /// <param name="wResult">Response</param>
        /// <param name="logType">Audit default</param>
        public static void LogSuccessfulExecution(IServiceContract pRequest, IServiceContract wResult, Fwk.Logging.EventType logType = Fwk.Logging.EventType.Audit)
        {
            fwk_ServiceAudit audit = new fwk_ServiceAudit();

            audit.LogTime = System.DateTime.Now;
            audit.ServiceName = pRequest.ServiceName;
            audit.Send_Time = pRequest.ContextInformation.HostTime;
            if(Fwk.HelperFunctions.DateFunctions.IsSqlDateTimeOutOverflow(wResult.ContextInformation.HostTime)==false)
                audit.Resived_Time = wResult.ContextInformation.HostTime;
            else
            {
                audit.Resived_Time = wResult.ContextInformation.HostTime = DateTime.Now;
                
            }
            
            audit.Send_UserId = pRequest.ContextInformation.UserId;
            audit.Send_Machine = pRequest.ContextInformation.HostName;

            audit.Dispatcher_Instance_Name = FacadeHelper.ServiceDispatcherConfig.InstanseName;
            audit.ApplicationId = pRequest.ContextInformation.AppId;

            audit.Requets = TypeFunctions.ConvertStringToByteArray(pRequest.GetXml());
            audit.Response = TypeFunctions.ConvertStringToByteArray(wResult.GetXml());
            audit.Logtype = Enum.GetName(typeof( Fwk.Logging.EventType), logType);
           

            try
            {
                using (FwkDatacontext context = new FwkDatacontext(System.Configuration.ConfigurationManager.ConnectionStrings[ConfigurationsHelper.ServiceDispatcherConnection].ConnectionString))
                {
                    context.fwk_ServiceAudits.InsertOnSubmit(audit);
                    context.SubmitChanges();
                }
    

            }
            catch(Exception ex)
            {
                TechnicalException te = new TechnicalException("No se pudo insertar la auditoria de la ejecucion de un servicio.-  " + ex.Message.ToString(), ex);
                te.ErrorId = "7010";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(Audit));
                LogDispatcherError(te);
                
                LogSuccessfulExecution_Old(pRequest, wResult);
            }
            

        }

        /// <summary>
        /// Almacena informacion de auditoria.- 
        /// Llama a StaticLogger y carga el log auditando los datos del Request de entrada
        /// </summary>
        /// <param name="pRequest">Request</param>
        /// <param name="pResult">Response</param>
        internal static void LogSuccessfulExecution_Old(IServiceContract pRequest, IServiceContract pResult)
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine("<Request>");
            s.AppendLine(pRequest.GetXml());
            s.AppendLine("</Request>");
            s.AppendLine("<Response>");
            s.AppendLine(pResult.GetXml());
            s.AppendLine("</Response>");

            try
            {
                ///TODO: Ver prefijos de logs
                Event ev = new Event(EventType.Audit, Fwk.Bases.ConfigurationsHelper.HostApplicationName, s.ToString(), pRequest.ContextInformation.HostName, pRequest.ContextInformation.UserId);
                Fwk.Logging.StaticLogger.Log(ev);
                    
            }
            catch { }
            finally
            { s = null; }

        }


    }
}
