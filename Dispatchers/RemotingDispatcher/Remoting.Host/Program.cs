using Fwk.Bases;
using Fwk.Configuration;
using Fwk.Logging;
using Fwk.Logging.Targets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;

namespace Remoting.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationsHelper.HostApplicationName = string.Concat("Fwk remoting ", Fwk.Bases.ConfigurationsHelper.HostApplicationName);
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            //RemotingHelper.WriteLog("Servicio de host de Remoting iniciado.", EventLogEntryType.Information);
            Fwk.Logging.Event ev = new Event();
            ev.LogType = EventType.Information;
            ev.Machine = Environment.MachineName;
            ev.User = Environment.UserName;
            ev.Message.Text = "Servicio de host de Remoting iniciado.";
       
            Console.WriteLine(ev.Message.Text);
            try
            {
                StaticLogger.Log(TargetType.WindowsEvent, ev, null, null);
            }
            catch
            {}
            Console.ReadLine();
        }
        #region ---[Metodos Privados]---
        private static void Inicializar()
        {
            try
            {
                //Controlar que este configurado en donde obtener las configuraciones
                if (String.IsNullOrEmpty(ConfigurationManager.GetProperty("Config", "RemotingConfig")))
                {
                    RemotingHelper.WriteLog("\r\nNo se encuentra configurado el nombre del archivo" +
                        "en el cual se leen las configuraciones de Remoting.\r\nProbablemente no exista el archivo de " +
                        "configuración.\r\nPresione ENTER para finalizar la ejecución.", EventLogEntryType.Error);

                    throw new Exception("\r\nNo se encuentra configurado el nombre del archivo" +
                        "en el cual se leen las configuraciones de Remoting.\r\nProbablemente no exista el archivo de " +
                        "configuración.\r\nPresione ENTER para finalizar la ejecución.");
                }
                else
                {

                    RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\" + ConfigurationManager.GetProperty("Config", "RemotingConfig").ToString(), false);
                    RemotingHelper.WriteLog("\r\nEl servicio esta preparado para escuchar las peticiones.", EventLogEntryType.Information);
                }
            }
            catch (Exception ex)
            {
                RemotingHelper.WriteLog("\r\nSe produjo una excepción al inicializar el servicio." +
                    "\r\n\r\n" + ex.ToString(),
                    EventLogEntryType.Error);

                throw ex;
            }
        }
        #endregion
    }
    public class RemotingHelper
    {
        public static void WriteLog(string pLog, EventLogEntryType pType)
        {
            Console.WriteLine(pLog);
            //EventLog.WriteEntry("Fwk.RemotingListenerService", pLog, pType);
        }
    }
}
