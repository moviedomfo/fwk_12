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
            try
            {
                ServiceHost host = new ServiceHost(typeof(FwkService));
                host.Faulted += new EventHandler(host_Faulted);
                host.Open();
                MetadataHelper.Log_ServiceHost(host);
            }
            catch (System.ServiceModel.AddressAccessDeniedException)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Debe ejecutar el servicio como Administrador");
            }
            catch (System.ServiceModel.CommunicationException exc)

            {
                //"Error de TCP (10013: Intento de acceso a un socket no permitido por sus permisos de acceso) al escuchar en el extremo IP=10.200.1.197:8001."
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(exc.Message);
                //Console.WriteLine("Debe ejecutar el servicio como Administrador");
            }
            catch (Exception ex)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(ex.Message);
            }
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

            //NetTcpBinding tcpBinding = new NetTcpBinding();
            //Uri wUri = new Uri("net.tcp://localhost:8001/FwkService1");
            //tcpBinding.TransactionFlow = true;

            //host.AddServiceEndpoint(typeof(IFwkService), tcpBinding, wUri);

            //host.Open();
        }

    }


}
