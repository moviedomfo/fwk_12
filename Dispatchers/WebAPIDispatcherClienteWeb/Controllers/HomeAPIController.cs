using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fwk.Bases.Blocks.Fwk.BusinessFacades;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Fwk.BusinessFacades;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WebAPIDispatcherClienteWeb.Controllers
{
    public class HomeAPIController : ApiController
    {
        SimpleFacade simpleFacade;
        static HostContext hostContext;
        //[HttpPost]
        //public String Execute(string providerName, string serviceName, string jsonRequets)
        //{
        //    //CreateSimpleFacade();
        //    //return simpleFacade.ExecuteServiceJson(providerName, serviceName, jsonRequets, hostContext);
        //    return providerName;
        //}
  
        [System.Web.Mvc.HttpPost]
        [Route("api/HomeAPI/Execute/")]
        public String Execute(WebApiREQ param)
        {
            CreateSimpleFacade();
            return simpleFacade.ExecuteServiceJson(param.ProviderName, param.ServiceName, param.JsonRequets, hostContext);
           
        }
        private  void  callservice(string jsonReq)
        {
            HttpClient httpClient = new HttpClient();
            string resourceAddress = "http://localhost:16731/WebAPIDispatcherService.svc/RegistrarLlamadaPost";
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var content = new StringContent(jsonReq, Encoding.UTF8, "application/json");
            var result = httpClient.PostAsJsonAsync(resourceAddress, content).Result;
             result.EnsureSuccessStatusCode();


            //HttpResponseMessage response = await httpClient.PostAsJsonAsync("api/MiniavatarApi", req);
           

            // Return the URI of the created resource.
            //return result.Headers.Location;

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
    

    public class WebApiREQ
    {
  
        public String ProviderName { get; set; }
        public String JsonRequets { get; set; }
   
        public String ServiceName { get; set; }
    
    }
}

