using System;
using System.Text;
using System.Configuration;
using System.Collections.Generic;

using Fwk.Logging.Targets;
using Fwk.ConfigSection;
using Fwk.Exceptions;

namespace Fwk.Logging
{
    /// <summary>
    /// Clase que administra la escritura de logs de eventos (Event) 
    /// en el destino (Target) correspondiente.
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public class Logger
    {
        #region <private members>
        private LoggingSection _LoggingSection = null;
        private string appId; 
        #endregion

        #region <constructor>

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAppId"></param>
        public Logger(string pAppId)
        {
            appId = pAppId;

            try
            {
                _LoggingSection = ConfigurationManager.GetSection("FwkLogging") as LoggingSection;
            }
            catch (System.Configuration.ConfigurationException ex)
            {

                TechnicalException te = new
                    TechnicalException("Hay problemas al intentar cargar la configuracion FwkLogging. \r\n ", ex);
                te.Assembly = "Fwk.Logging";
                te.Class = "LoginSection";
                te.ErrorId = "9002";
                te.Namespace = "Fwk.Logging";
                te.UserName = Environment.UserName;
                te.Machine = Environment.MachineName;
                throw te;
            }
        }
        /// <summary>
        /// Constructor de Logger.
        /// </summary>
        public Logger()
        {
            appId = Fwk.Bases.ConfigurationsHelper.HostApplicationName;
            try
            {
                _LoggingSection = ConfigurationManager.GetSection("FwkLogging") as LoggingSection;
            }
            catch (System.Configuration.ConfigurationException ex)
            {

                TechnicalException te = new
                    TechnicalException("Hay problemas al intentar cargar la configuracion FwkLogging. \r\n ", ex);
                te.Assembly = "Fwk.Logging";
                te.Class = "LoginSection";
                te.ErrorId = "9002";
                te.Namespace = "Fwk.Logging";
                te.UserName = Environment.UserName;
                te.Machine = Environment.MachineName;
                throw te;
            }
        }
        #endregion

        #region <public properties>
       

        /// <summary>
        /// Escribe el log de un evento de tipo 'Information'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>        
        public void Information(string pSource, string pText)
        {
            // Escribe el log.
            WriteLog(EventType.Information, pSource, pText);
        }

        /// <summary>
        /// Escribe el log de un evento de tipo 'Warning'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>        
        public void Warning(string pSource, string pText)
        {
            // Escribe el log.
            WriteLog(EventType.Warning, pSource, pText);
        }
        public void Warning(string providerName, string pSource, string pText)
        {
            WriteLog(providerName,EventType.Warning, pSource, pText);
        }
        /// <summary>
        /// Escribe el log de un evento de tipo 'Error'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>        
        public void Error(string pSource, string pText)
        {
            // Escribe el log.
            Error(String.Empty,  pSource, pText);
        }
        public void Error(string providerName, string pSource, string pText)
        {
            WriteLog(providerName, EventType.Warning, pSource, pText);
        }

        /// <summary>
        /// Escribe el log de un evento de tipo 'audit'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>
        /// <param name="pUserName">Nombre usuario.</param>
        ///  <param name="pMachine">Nombre usuario.</param>
        public void Audit(string pSource, string pText, string pUserName, String pMachine)
        {
            Audit(String.Empty, pSource,pText,pUserName,pMachine);
     
        }
        /// <summary>
        /// Escribe el log de un evento de tipo 'audit'.
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>
        /// <param name="pUserName">Nombre usuario.</param>
        ///  <param name="pMachine">Nombre usuario.</param>
        public void Audit(string providerName,string pSource, string pText, string pUserName, String pMachine)
        {
            // Escribe el log.
            // Crea un nuevo Event.
            Event wEvent = new Event(EventType.Audit, pSource, pText);
            wEvent.User = pUserName;
            wEvent.Machine = pMachine;
            WriteLog(providerName, wEvent);

        }
        #endregion

        #region <private methods>

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEvent"></param>
        private void WriteLog(Event pEvent)
        {
            WriteLog(String.Empty, pEvent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="pEventType"></param>
        /// <param name="pSource"></param>
        /// <param name="pText"></param>
        private void WriteLog( EventType pEventType, string pSource, string pText)
        {
            WriteLog(String.Empty, pEventType,pSource,pText);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="pEventType"></param>
        /// <param name="pSource"></param>
        /// <param name="pText"></param>
        private void WriteLog(String providerName, EventType pEventType, string pSource, string pText)
        {
            // Crea un nuevo Event.
            Event wEvent = new Event(pEventType, pSource, pText);
            wEvent.AppId = appId;
            // Obtiene la Rule asociada al EventType.
            LogProviderElement wRule = _LoggingSection.GetProvider();

            // Escribe el log según la Rule.
            Target wTarget = GetTargetByProviderElement(wRule);
            wTarget.Write(wEvent);  

            // Limpieza.
            wEvent = null;
            wRule = null;
        }
        /// <summary>
        /// Escribe un log
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="pEvent"></param>
        private void WriteLog(string providerName,Event pEvent)
        {

            // Obtiene el provider
            LogProviderElement provider = _LoggingSection.GetProvider(providerName);

            // Escribe el log según la Rule.
            Target wTarget = GetTargetByProviderElement(provider);
            wTarget.Write(pEvent);

            //wRule = null;
            //pEvent = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerElement"></param>
        /// <returns></returns>
        private Target GetTargetByProviderElement(LogProviderElement providerElement)
        {
            switch (providerElement.Target)
            {
               
                case TargetType.Database:
                    {
                        DatabaseTarget wDatabase = new DatabaseTarget();
                        wDatabase.CnnStringName = providerElement.CnnStringName;
                        return wDatabase;
                    }
                case TargetType.File:
                    {
                        FileTarget wFile = new FileTarget();
                        wFile.FileName = providerElement.FileName;
                        return wFile;
                    }
                case TargetType.WindowsEvent:
                    {
                        return new WindowsEventTarget();
                    }
                case TargetType.Xml:
                    {
                        XmlTarget wXml = new XmlTarget();
                        wXml.FileName = providerElement.FileName;
                        return wXml;
                    }
               
                    
            }
            return null;
        }
        #endregion
    }
}
