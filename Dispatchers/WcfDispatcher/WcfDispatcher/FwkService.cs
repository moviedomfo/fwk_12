using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Diagnostics;
using Fwk.Bases.Blocks.Fwk.BusinessFacades;
using System.ServiceModel.Channels;
using System.Net;
using Fwk.BusinessFacades;
using Fwk.Bases;

namespace WcfDispatcher.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class FwkService : IFwkService
    {
        String sessionId = string.Empty;
        static Fwk.BusinessFacades.SimpleFacade simpleFacade;
        static HostContext hostContext;
        void CreateSimpleFacade()
        {
            if (simpleFacade == null)
            {
                simpleFacade = new Fwk.BusinessFacades.SimpleFacade();
            
            }
            if (hostContext == null)
            {
                string[] computer_name = null;
                 hostContext = new HostContext();
                OperationContext context = OperationContext.Current;
                MessageProperties prop = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                computer_name = Dns.GetHostEntry(endpoint.Address).HostName.Split(new Char[] { '.' });

                hostContext.HostIp = endpoint.Address;
                if (computer_name.Count() > 0)
                    hostContext.HostName = computer_name[0].ToString();
            }

        }
        /// <summary>
        /// Use json
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="serviceName"></param>
        /// <param name="jsonRequets"></param>
        /// <returns></returns>
        string IFwkService.ExecuteService(String providerName, String serviceName, String jsonRequets)
        {

            Console.WriteLine("Excecuting svc " + serviceName + "  " + DateTime.Now.ToString());
            Console.WriteLine("--------Client IP  " + GetClientIP());
            CreateSimpleFacade();
          
            return simpleFacade.ExecuteServiceJson(providerName, serviceName, jsonRequets, hostContext);

        }
        private string GetClientIP()
        {
            OperationContext context = OperationContext.Current;
            MessageProperties prop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint =
                   prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            string ip = endpoint.Address;
            
            return ip;
        }
        /// <summary>
        /// transport Binary
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="serviceName"></param>
        /// <param name="contract"></param>
        /// <returns></returns>
        WCFResponse IFwkService.ExecuteServiceBin( WCFRequet req)
        {
            Console.WriteLine("Excecuting svc " + req.ServiceName + "  " + DateTime.Now.ToString());
            Console.WriteLine("--------Client IP  " + req.ContextInformation.HostIp + " Client Name" + req.ContextInformation.HostName);
            CreateSimpleFacade();
            //IServiceContract result = simpleFacade.ExecuteService(req.ProviderName, req.BusinessData);

            WCFResponse res = new WCFResponse();
            //res.Contract = result;
            return res;
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public String GetServiceConfiguration(string providerName, string serviceName)
        {
            CreateSimpleFacade();
            return simpleFacade.GetServiceConfiguration(providerName, serviceName);
        }

        /// <summary>
        ///  Lista los servicios configurados
        /// </summary>
        ///<param name="providerName">Proveedor de metadata. Este parametro lo establece el cliente desde su configuracion de wrapper</param>
        /// <param name="ViewAsXml">Permite ver como xml todos los servicios y sus datos.
        /// Si se espesifuca false solo se vera una simple lista</param>
        /// <returns>Lista de servicios configurados</returns>
        public String GetServicesList(string providerName, bool ViewAsXml)
        {
            CreateSimpleFacade();
            return simpleFacade.GetServicesList(providerName, ViewAsXml); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Fwk.ConfigSection.DispatcherInfo RetriveDispatcherInfo()
        {
            Console.WriteLine("Excecuting RetriveDispatcherInfo " + DateTime.Now.ToString());
            Console.WriteLine("--------Client IP  " + GetClientIP());
            CreateSimpleFacade();
            return simpleFacade.RetriveDispatcherInfo();
        }

        /// <summary>
        /// Obtiene una lista de todas las aplicaciones configuradas en el origen de datos configurado por el 
        /// proveedor
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        public List<String> GetAllApplicationsId(string providerName)
        {
            Console.WriteLine("Excecuting GetAllApplicationsId " + DateTime.Now.ToString());
            Console.WriteLine("--------Client IP  " + GetClientIP());
            CreateSimpleFacade();
            return simpleFacade.GetAllApplicationsId(providerName);
        }

        /// <summary>
        /// Obtiene info del proveedor de metadata
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        public Fwk.ConfigSection.MetadataProvider GetProviderInfo(string providerName)
        {
            Console.WriteLine("Excecuting GetProviderInfo " + DateTime.Now.ToString());
            Console.WriteLine("--------Client IP  " + GetClientIP());
            CreateSimpleFacade();
            return simpleFacade.GetProviderInfo(providerName);
        }
    }





}
