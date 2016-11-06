using WebAPIDispatcher.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Fwk.BusinessFacades;
using Fwk.Bases;
using Fwk.ConfigSection;
using Fwk.Bases.Blocks.Fwk.BusinessFacades;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace WebAPIDispatcher.Controllers
{
    public class SingleServiceApiController : ApiController
    {
        SimpleFacade simpleFacade;
        static HostContext hostContext;
        /// <summary>
        /// http://localhost:47647/api/SingleServiceApi/Execute/
        /// </summary>
        /// <param name="providerName">Provedor de Metadata: </param>
        /// <param name="pServiceName"></param>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        [HttpGet]
        public String Execute(string providerName, string serviceName, string jsonRequets)
        {
            CreateSimpleFacade();
            return simpleFacade.ExecuteServiceJson(providerName, serviceName, jsonRequets, hostContext);
        }

        /// <summary>
        /// http://localhost:47647/api/SingleServiceApi/ping/moviedo
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public String Ping(string id)
        {
            //CreateSimpleFacade();
            return "Hola " + id;
        }
        /// <summary>
        /// Factory de SimpleFacade
        /// </summary>  
        /// <returns></returns>
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
    }
}