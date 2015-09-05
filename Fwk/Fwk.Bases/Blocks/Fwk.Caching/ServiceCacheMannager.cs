using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
namespace Fwk.Caching
{

    /// <summary>
    /// Componente que permite manipular los objetos IServiceContract en la cache.- 
    /// </summary>
    public static class ServiceCacheMannager
    {
       /// <summary>
       /// Obtiene un response cacheado por medio de su request
       /// </summary>
       /// <param name="pRequest"></param>
       /// <returns></returns>
        public static IServiceContract Get(IRequest pRequest)
        {
            IRequest req = (IRequest)pRequest;
            IServiceContract wResult;
            object wItemInCache = null;
            if (string.IsNullOrEmpty(req.CacheSettings.ResponseCacheId))
                req.CacheSettings.ResponseCacheId = req.ServiceName;

            

            //TODO: Agregar manejo de error para catching
            wItemInCache = CacheManager.GetData(req.CacheSettings.ResponseCacheId);


            if (wItemInCache == null)
            {
                wResult = null;
            }
            else
            {
                wResult = (IServiceContract)wItemInCache;
            }


            return wResult;
        }

        /// <summary>
        /// Almacena un response en cahce
        /// </summary>
        /// <param name="pRequest"></param>
        /// <param name="pResult"></param>
        public static void Add(IServiceContract pRequest, IServiceContract pResult)
        {
            IRequest req = (IRequest)pRequest;

            if (string.IsNullOrEmpty(req.CacheSettings.ResponseCacheId))
                req.CacheSettings.ResponseCacheId = pRequest.ServiceName;

            CacheManager.Add(
                req.CacheSettings.ResponseCacheId,
                pResult,
                req.CacheSettings.ExpirationTime, req.CacheSettings.TimeMeasures);
        }
            
        

        /// <summary>
        /// Limpia todos los resultado de servicios en cache
        /// </summary>
        /// <param name="pCacheMannagerName"></param>
        public static void ClearAll(String pCacheMannagerName)
        {
            CacheManager.Flush();

        }

    }
}
