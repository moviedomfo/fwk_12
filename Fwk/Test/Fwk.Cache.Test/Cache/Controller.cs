using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.HelperFunctions;
using Fwk.Exceptions;
using Fwk.Bases;
using Fwk.Caching;

namespace Fwk.Cache.Test
{
    internal class Controller 
    {

        public static DomainList Dominios;
        public static DomainList Cuentas;
        public static DomainList SubAreas;
        public static DomainList Cargos;
        public static DomainList Sucursales;
        public static DomainList RelatedDomains;
        
        /// <summary>
        /// busca los dominios relacionados al usuario
        /// </summary>
        /// <param name="puserName"></param>
        /// <param name="userId"></param>
        /// <param name="pCache">Determina si se implementa cacheo de datos</param>
        /// <param name="pRefreshData">Determina si se decea eliminar la data del cache</param>
        /// <returns></returns>
        internal static DomainList SearchRelatedDomainsByUser(string puserName,
            bool pRefreshData,string cacheName)
        {


            SearchRelatedDomainsByUserReq req = new SearchRelatedDomainsByUserReq();





            if (pRefreshData)
            {
                CacheManager.Remove(string.Concat(req.ServiceName + puserName));
            }
            //req.CacheSettings.CacheManagerName = cacheName;
            req.CacheSettings.CacheOnClientSide = true;
            
            req.CacheSettings.ResponseCacheId = string.Concat(req.ServiceName + puserName);


         

            SearchRelatedDomainsByUserRes res = ExecuteService<SearchRelatedDomainsByUserReq, SearchRelatedDomainsByUserRes>(req);
          
            




            return res.BusinessData;
        }

        internal static SearchRelatedDomainsByUserRes GetFromCache(string puserName, string cacheName)
        {
            SearchRelatedDomainsByUserReq req = new SearchRelatedDomainsByUserReq();
            req.CacheSettings.ResponseCacheId = string.Concat(req.ServiceName + puserName);
            req.CacheSettings.CacheManagerName = cacheName;
            req.CacheSettings.CacheOnClientSide = true;
            SearchRelatedDomainsByUserRes res = (SearchRelatedDomainsByUserRes)ServiceCacheMannager.Get(req);
            return res;
        }

        /// <summary>
        /// Ejecuta un servicio de negocio.
        /// </summary>
        /// <param name="pRequest">Request con datos de entrada para la  ejecución del servicio.</param>
        /// <returns>Dataset con datos de respuesta del servicio.</returns>
        /// <date>2007-08-24T00:00:00</date>
        /// <author>moviedo</author>
        static TResponse ExecuteService<TRequest, TResponse>(TRequest pRequest)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {
            TResponse wResponse = new TResponse();

            #region fill data
            SearchRelatedDomainsByUserRes wSearchRelatedDomainsByUserRes = new SearchRelatedDomainsByUserRes();
            wSearchRelatedDomainsByUserRes.BusinessData = new DomainList();
            Domain d = new Domain();
            d.DomainId = 111;
            d.Name = "Dominio A";
            wSearchRelatedDomainsByUserRes.BusinessData.Add(d);
            #endregion

            Boolean wExecuteOndispatcher = true;
            //Si no ocurrio algun error
            if (wResponse.Error == null)
            {
                IServiceContract res = null;
                IRequest req = (IRequest)pRequest;
                // Caching del servicio.
                if (req.CacheSettings != null && req.CacheSettings.CacheOnClientSide) //--------------------------------------->>> Implement the cache factory
                {

                    res = ServiceCacheMannager.Get(req);
                    wResponse = (TResponse)res;
                    //Si estaba en la cache no es necesario llamar al despachador de servicio
                    if (wResponse != null)
                        wExecuteOndispatcher = false;



                }


                if (wExecuteOndispatcher)
                {
                    res = (IServiceContract)wSearchRelatedDomainsByUserRes;
                    wResponse = (TResponse)res;
                    //wResponse = _Wrapper.ExecuteService<TRequest, TResponse>(pRequest);

                    //Si aplica cache y se llamo a la ejecucion se debe almacenar en cache para proxima llamada
                    if (req.CacheSettings != null && req.CacheSettings.CacheOnClientSide)
                    {
                        //Es posible que la ejecucion produzca algun error y por lo tanto no se permitira 
                        //su almacen en cache
                        if (wResponse.Error == null)
                            ServiceCacheMannager.Add(req, wResponse);
                    }
                }
            }

            return wResponse;
        }
    }
}
