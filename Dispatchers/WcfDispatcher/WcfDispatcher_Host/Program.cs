using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using WcfDispatcher;
using WcfDispatcher.Service;

namespace WcfDispatcher_Host
{
    //WcfSvcHost.exe /service:D:\Projects\Allus\Bigbang\trunk\tools\WcfDispatcher\WcfDispatcher_Host\bin\Debug\WcfDispatcher.dll /config:D:\Projects\Allus\Bigbang\trunk\tools\WcfDispatcher\WcfDispatcher_Host\App.config
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(FwkService));
            host.Faulted += new EventHandler(host_Faulted);
            host.Open();
            MetadataHelper.Log_ServiceHost(host);

            //ServiceHost FileTRansferHost = new ServiceHost(typeof(FwkFileTransferService));
            //MetadataHelper.Log_ServiceHost(FileTRansferHost);
            //FileTRansferHost.Open();
       
            Console.ReadLine();
        }

        private static void host_Faulted(object sender, EventArgs e)
        {

            Console.Write("FwkService host_Faulted");
        }

        void SetNetTcpBinding(ServiceHost host)
        {

            NetTcpBinding tcpBinding = new NetTcpBinding();
            Uri wUri = new Uri("net.tcp://localhost:8001/FwkService1");
            tcpBinding.TransactionFlow = true;
            
            host.AddServiceEndpoint(typeof(IFwkService), tcpBinding, wUri);
            
            host.Open();
        }

    }


}
