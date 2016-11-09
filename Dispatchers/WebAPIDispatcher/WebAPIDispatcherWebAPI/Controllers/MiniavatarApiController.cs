
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebAPIDispatcher.Controllers
{
    public class MiniavatarApiController : ApiController
    {
        [HttpGet]
        public WebAPIDispatcherRes Get(int id)
        {
            WebAPIDispatcherRes res = new WebAPIDispatcherRes();
            res.Error = "Test desde " + Environment.MachineName;
            res.IDLead = 123122;
            return res;
        }
        //Para test levantar un fidler 
        //hacer POST -->
        //        User-Agent: Fiddler
        //Host: localhost:47647
        //Content-type: application/json
        //Content-Length: 159

            //        http://localhost:47647/api/MiniavatarApi/Post/
            //
            //Body Req = {"CodigoCampania":"ALLUS-98","CodigoOrigen":"0012.","Fecha":"2016-10-05T13:50:13.461Z","Horario":true,"Telefonos":"0351-1548788","Texto":"Hola gente de allus"}
        public WebAPIDispatcherRes Post(WebAPIDispatcherReq req)
        {
            WebAPIDispatcherRes res = new WebAPIDispatcherRes();

            if (req == null)
            {
                res.Error = "Falta el parametro req";
            }

           

            return res;

        }

      



    }


 
  
}
