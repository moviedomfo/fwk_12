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
            using (ServiceHost host = new ServiceHost(typeof(FwkService)))
            {
               
                host.Open();
                MetadataHelper.Log_ServiceHost(host);
                Console.ReadLine();
            }
           


        }

        void SetNetTcpBinding(ServiceHost host)
        {

            NetTcpBinding tcpBinding = new NetTcpBinding();
            Uri wUri = new Uri("net.tcp://santana:8001/FwkService1");
            tcpBinding.TransactionFlow = true;
            
            host.AddServiceEndpoint(typeof(IFwkService), tcpBinding, wUri);
            
            host.Open();
        }

    }


}
