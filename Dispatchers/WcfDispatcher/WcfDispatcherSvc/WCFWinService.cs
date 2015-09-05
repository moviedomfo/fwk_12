using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;
using WcfDispatcher;
using Fwk.Logging;
using Fwk.Logging.Targets;
using WcfDispatcher.Service;

namespace WcfDispatcherSvc
{
    public partial class WCFWinService : ServiceBase
    {
        ServiceHost fwkServiceHost = null;
        public WCFWinService()
        {
            InitializeComponent();

            Fwk.Bases.ConfigurationsHelper.HostApplicationName = string.Concat("Fwk WCF ", this.ServiceName);
            
        }

        protected override void OnStart(string[] args)
        {
            
            fwkServiceHost = new ServiceHost(typeof(FwkService));
            fwkServiceHost.Faulted += new EventHandler(fwkServiceHost_Faulted);
            fwkServiceHost.Open();

            Fwk.Logging.Event ev = new Event();
            ev.LogType = EventType.Information;
            ev.Machine = Environment.MachineName;
            ev.User = Environment.UserName;
            ev.Message.Text = string.Concat("Servicio de host de WCF ", Fwk.Bases.ConfigurationsHelper.HostApplicationName, " iniciado");
            StaticLogger.Log(TargetType.WindowsEvent, ev, null, null);
        }

        void fwkServiceHost_Faulted(object sender, EventArgs e)
        {
            Fwk.Logging.Event ev = new Event();
            ev.LogType = EventType.Information;
            ev.Machine = Environment.MachineName;
            ev.User = Environment.UserName;
           
          
        }

        protected override void OnStop()
        {
            fwkServiceHost.Faulted -= new EventHandler(fwkServiceHost_Faulted);
            fwkServiceHost.Close();

            Fwk.Logging.Event ev = new Event();
            ev.LogType = EventType.Information;
            ev.Machine = Environment.MachineName;
            ev.User = Environment.UserName;
            ev.Message.Text = string.Concat("Servicio de host de WCF ", Fwk.Bases.ConfigurationsHelper.HostApplicationName, " iniciado");
            StaticLogger.Log(TargetType.WindowsEvent, ev, null, null);
        }
    }
}
