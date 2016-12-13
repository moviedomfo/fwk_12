
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
using System.Web.Http.Cors;

namespace WebAPIDispatcher.Controllers
{
    //Response to preflight request doesn't pass access control check: No 'Access-Control-Allow-Origin' header is present on the requested resource.
    //[EnableCors(origins: "http://localhost:17854", headers: "*", methods: "*")]
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
        [System.Web.Http.HttpPost]
        //[Route("api/SingleServiceApi/Execute/")]
        public String Execute(String param)
        {
            CreateSimpleFacade();
            return "ccccccccccc"; //simpleFacade.ExecuteServiceJson(param.ProviderName, param.ServiceName, param.JsonRequets, hostContext);

        }

        /// <summary>
        /// http://localhost:47647/api/SingleServiceApi/ping/moviedo
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        //[HttpGet]
        ////[Route("api/SingleServiceApi/Ping/")]
        //public String Ping(string param)
        //{
        //    //CreateSimpleFacade();
        //    return "Hola " + param;
        //}
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
    public class WebApiREQ
    {

        public String ProviderName { get; set; }
        public String JsonRequets { get; set; }

        public String ServiceName { get; set; }

    }
}