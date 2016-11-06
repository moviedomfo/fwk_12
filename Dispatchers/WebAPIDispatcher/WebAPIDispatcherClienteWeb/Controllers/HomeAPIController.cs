using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDispatcherClienteWeb.WebAPIDispatcherSVC;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebAPIDispatcherClienteWeb.Controllers
{
    public class HomeAPIController : ApiController
    {


        [System.Web.Mvc.HttpPost]
        [Route("api/HomeAPI/RegistrarLlamada/")]
        public String RegistrarLlamada(WebAPIDispatcherBE param)
        {
            WebAPIDispatcherReq req = new WebAPIDispatcherReq();
            WebAPIDispatcherRes res = null;
            req.CodigoCampania = param.CodigoCampania;
            req.CodigoOrigen = param.CodigoOrigen;
            req.Fecha = param.Fecha;
            req.Horario = param.Horario;
            req.Telefonos = param.Telefonos;
            req.Texto = param.Texto;
            // http://localhost:16731/WebAPIDispatcherService.svc/RegistrarLlamada
            try
            {
                res = new WebAPIDispatcherRes();
                WebAPIDispatcherServiceClient proxy = new WebAPIDispatcherServiceClient();
                
                 res = proxy.RegistrarLlamada(req);
                if (String.IsNullOrEmpty(res.Error)==false)
                    return res.Error;
                return res.IDLead.ToString();
            }
            catch(Exception ex)
            {
                res = new WebAPIDispatcherRes();
                res.Error = ex.Message;
                return res.Error;

            }
            

        }


        [System.Web.Mvc.HttpPost]
        [Route("api/HomeAPI/RegistrarLlamadaPOST/")]
        public String RegistrarLlamadaPOST(WebAPIDispatcherBE param)
        {
            WebAPIDispatcherReq req = new WebAPIDispatcherReq();
            WebAPIDispatcherRes res = null;
            req.CodigoCampania = param.CodigoCampania;
            req.CodigoOrigen = param.CodigoOrigen;
            req.Fecha = param.Fecha;
            req.Horario = param.Horario;
            req.Telefonos = param.Telefonos;
            req.Texto = param.Texto;
            string jsonReq = Newtonsoft.Json.JsonConvert.SerializeObject(req);

            try
            {
                
                callservice(jsonReq);

                return "0";
            }
            catch (Exception ex)
            {
                res = new WebAPIDispatcherRes();
                res.Error = ex.Message;
                return res.Error;

            }


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
        [System.Web.Mvc.HttpPost]
        [Route("api/HomeAPI/RegistrarLlamadaPOST_webapi/")]
        public String RegistrarLlamadaPOST_webapi(WebAPIDispatcherBE param)
        {
            WebAPIDispatcherReq req = new WebAPIDispatcherReq();
            WebAPIDispatcherRes res = null;
            req.CodigoCampania = param.CodigoCampania;
            req.CodigoOrigen = param.CodigoOrigen;
            req.Fecha = param.Fecha;
            req.Horario = param.Horario;
            req.Telefonos = param.Telefonos;
            req.Texto = param.Texto;
            //Uri baseUri = new Uri("http://localhost:47647/");
            Uri baseUri = new Uri("http://ws2008/miniavatarws/"); ///api/MiniavatarApi/Post/
            string jsonReq = Newtonsoft.Json.JsonConvert.SerializeObject(req);
            try
            {

                RegistrarLlamadaPostAsync(req).Wait();
                return "0";
            }
            catch (Exception ex)
            {
                res = new WebAPIDispatcherRes();
                res.Error = ex.Message;
                return res.Error;

            }


        }
        static async Task<WebAPIDispatcherBE> RegistrarLlamadaPostAsync(WebAPIDispatcherReq req)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:47647/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("api/MiniavatarApi", req);
         


            var r = await response.Content.ReadAsStringAsync();
            
            return response.Content.ReadAsAsync<WebAPIDispatcherBE>().Result;
        }
    }
    

    public class WebAPIDispatcherBE
    {
        /// <summary>
        /// url landing   (campo texto)
        /// </summary>
        public String CodigoOrigen { get; set; }
        public String CodigoCampania { get; set; }
        /// <summary>
        /// Texto que explique de qué landing/campaña viene (campo texto tamaño ?)
        /// </summary>
        public String Texto { get; set; }
        public String Fecha { get; set; }
        /// <summary>
        /// Teléfonos en formato ANI
        /// </summary>
        public String Telefonos { get; set; }
        /// <summary>
        ///dentro de horario, 0 fuera de horario
        /// </summary>
        public bool Horario { get; set; }
    }
}

