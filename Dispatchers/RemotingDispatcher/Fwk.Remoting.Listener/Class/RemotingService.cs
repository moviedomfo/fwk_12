using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Runtime.Remoting;
using Fwk.Configuration;
using System.Runtime.Remoting.Channels;
using Fwk.Logging.Targets;
using Fwk.Logging;
using Fwk.Bases;

namespace Fwk.Remoting.Listener
{
    public partial class RemotingService : ServiceBase
    {

        #region ---[Constructor y Main]---
        public RemotingService()
        {
            InitializeComponent();

        }


        static void Main()
        {
            ServiceBase[] ServicesToRun;

            ServicesToRun = new ServiceBase[] { new RemotingService() };

            ServiceBase.Run(ServicesToRun);
        }
        #endregion

        

        #region ---[OnStart]---
        protected override void OnStart(string[] args)
        {
            Fwk.Logging.Event ev = null;
            //ConfigurationsHelper.HostApplicationName = string.Concat("Fwk remoting ", this.ServiceName);
            try
            {
                RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
                ev = new Event();
                ev.LogType = EventType.Information;
                ev.Machine = Environment.MachineName;
                ev.User = Environment.UserName;
                ev.Message.Text = "Servicio de host de Remoting iniciado.";
            }
            catch (Exception ex)
            {
                //RemotingHelper.WriteLog("\r\nSe produjo una excepción al iniciar el servicio." +
                //    "\r\n\r\n" + ex.ToString(),
                //    EventLogEntryType.Error);
                ev = new Event();
                ev.LogType = EventType.Error;
                ev.Machine = Environment.MachineName;
                ev.User = Environment.UserName;
                ev.Message.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);

            }
            //RemotingHelper.WriteLog("Servicio de host de Remoting iniciado.", EventLogEntryType.Information);

            StaticLogger.Log(TargetType.WindowsEvent, ev, null, null);
        }
        #endregion

        #region ---[OnStop]---
        protected override void OnStop()
        {
            foreach (IChannel wChannel in ChannelServices.RegisteredChannels)
            {
                ChannelServices.UnregisterChannel(wChannel);
            }
            Fwk.Logging.Event ev = new Event();
            ev.LogType = EventType.Information;
            ev.Machine = Environment.MachineName;
            ev.User = Environment.UserName;
            ev.Message.Text = "Servicio de host de Remoting detenido.";
            StaticLogger.Log(TargetType.WindowsEvent, ev, null, null);

        }
        #endregion

    }
}
