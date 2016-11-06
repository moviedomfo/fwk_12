using WebAPIDispatcher.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebAPIDispatcherWS
{
    //
    // NOTE: In order to launch WCF Test Client for testing this service, please select WebAPIDispatcherService.svc or WebAPIDispatcherService.svc.cs 
    //at the Solution Explorer and start debugging.
    public class WebAPIDispatcherService : IWebAPIDispatcherService
    {

        public WebAPIDispatcherRes RegistrarLlamadaPost(WebAPIDispatcherReq req)
        {
            WebAPIDispatcherRes res = new WebAPIDispatcherWS.WebAPIDispatcherRes();

            if (req == null)
            {
                res.Error = "Falta el parametro req";
            }

            WebAPIDispatcherBE be = new WebAPIDispatcherBE();
            be.CodigoCampania = req.CodigoCampania;
            be.CodigoOrigen = req.CodigoOrigen;
            be.Fecha = req.Fecha;
            be.Horario = req.Horario;
            be.Telefonos = req.Telefonos;
            be.Texto = req.Texto;
            try
            {
                var list = WebAPIDispatcherBC.ContactoByNum(be.Telefonos);
                if (list.Count == 0)
                {
                    WebAPIDispatcherBC.Insert_llamada(be);
                    res.IDLead = be.IDLead;
                }
            }
            catch (Exception ex)
            {
                res.Error = ex.Message;
            }

            return res;
        }

        public WebAPIDispatcherRes RegistrarLlamada(WebAPIDispatcherReq req)
        {
            WebAPIDispatcherRes res = new WebAPIDispatcherWS.WebAPIDispatcherRes();

            if (req == null)
            {
                res.Error = "Falta el parametro req";
            }

            WebAPIDispatcherBE be = new WebAPIDispatcherBE();
            be.CodigoCampania = req.CodigoCampania;
            be.CodigoOrigen = req.CodigoOrigen;
            be.Fecha = req.Fecha;
            be.Horario = req.Horario;
            be.Telefonos = req.Telefonos;
            be.Texto = req.Texto;
            try
            {
                 var list = WebAPIDispatcherBC.ContactoByNum(be.Telefonos);
                 if (list.Count == 0)
                 {
                     WebAPIDispatcherBC.Insert_llamada(be);
                     res.IDLead = be.IDLead;
                 }
            }
            catch (Exception ex) {
                res.Error = ex.Message;
            }
            
            return res;
        }




    }
}
