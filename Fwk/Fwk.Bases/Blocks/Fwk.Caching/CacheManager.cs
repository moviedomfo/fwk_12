using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using Fwk.HelperFunctions;


namespace Fwk.Caching
{
    /// <summary>
    /// Wrap cahe functionallity
    /// </summary>
    public static class CacheManager 
    {
        // Gets a reference to the default MemoryCache instance. 
        static ObjectCache realCache = MemoryCache.Default;
        
        
        /// <summary>
        /// Returns the number of items currently in the cache.
        /// </summary>
        public static int Count
        {
            get { return realCache.Count(); }
        }

        /// <summary>
        /// Returns true if key refers to item current stored in cache
        /// </summary>
        /// <param name="key">Key of item to check for</param>
        /// <returns>True if item referenced by key is in the cache</returns>
        public static bool Contains(string key)
        {
             
            return realCache.Contains(key);
        }

     

       

        /// <summary>
        /// Agrega un nuevo item a la cache por un tiempo determinado por timeToLive y timeToLiveTimeMesures.
        /// Este metodo agrega el item hasta un tiempo determinado . Concluido ese tiempo el elemento es removido del cache
        /// Si algun elemento existe con ese mismo nombre será eliminado antes de que el nuevo value sea agregado.
        /// </summary>
        /// <param name="key">Identifier for this CacheItem</param>
        /// <param name="value">Value to be stored in cache. May be null.</param>
        /// <param name="timeToLive">Tiempo que dura vivo un objeto en cache. No importa si este es accedido o no</param>
        ///<param name="timeToLiveTimeMesures">Metrica para absoluteTieme</param>
        /// <remarks></remarks>
        /// 
        public static void Add(string key, object value, Int32 timeToLive, DateFunctions.TimeMeasuresEnum timeToLiveTimeMesures)
        {
            CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();



            cacheItemPolicy.Priority = CacheItemPriority.Default;
            #region Set AbsoluteExpiration to cache an object until this time is reached
            switch (timeToLiveTimeMesures)
            {
                case DateFunctions.TimeMeasuresEnum.FromDays:
                    {
                        cacheItemPolicy.AbsoluteExpiration = DateTimeOffset.Now.AddDays(timeToLive);  
                        break;
                    }
                case DateFunctions.TimeMeasuresEnum.FromHours:
                    {
                        cacheItemPolicy.AbsoluteExpiration = DateTimeOffset.Now.AddHours(timeToLive);  
                        break;
                    }
                case DateFunctions.TimeMeasuresEnum.FromMinutes:
                    {
                        cacheItemPolicy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(timeToLive);  
                        break;
                    }
                case DateFunctions.TimeMeasuresEnum.FromSeconds:
                    {
                        cacheItemPolicy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(timeToLive);  
                        break;
                    }
            }


            #endregion 
            if (realCache.Contains(key))
                realCache.Remove(key);
            
            realCache.Add(key, value, cacheItemPolicy);

        }
        /// <summary>
        ///  Agrega un nuevo item a la cache 
        /// Si algun elemento existe con    ese mismo nombre será eliminado antes de que el nuevo value sea agregado.
        /// La expiracion del elemento en cache depende del ultimo momento de uso. 
        /// </summary>
        /// <param name="key">Identifier for this CacheItem</param>
        /// <param name="value">Value to be stored in cache. May be null.</param>
        /// <param name="slidingTime">Cantidad de tiempo (dias minutos segundos) que dura un elemento en cache si no fue accedido en ese tiempo</param>        
        ///<param name="slidingTimeTimeMeasures">Metrica para absoluteTieme</param>
        /// <remarks>Si setrea una expiracion de 20 segundos y el objeto es utilizado dentro de esos 20 segs. el tiempo de expiracion del mismo se prolongara unos 20 seg adicionales
        /// Un ejemplo valido podria ser para cachear sesiones donde se nececita una expiracion dependiendo del ultimo acceso al objeto</remarks>
        public static void Add_WithExpirationTiem(string key, object value, Double slidingTime, Fwk.HelperFunctions.DateFunctions.TimeMeasuresEnum slidingTimeTimeMeasures)
        {
            if (realCache.Contains(key))
                realCache.Remove(key);

            CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
            cacheItemPolicy.Priority = CacheItemPriority.Default;

            #region Set SlidingExpiration
            switch (slidingTimeTimeMeasures)
            {
                case DateFunctions.TimeMeasuresEnum.FromDays:
                    {
                        cacheItemPolicy.SlidingExpiration = TimeSpan.FromDays(slidingTime);
                        break;

                    }
                case DateFunctions.TimeMeasuresEnum.FromHours:
                    {
                        cacheItemPolicy.SlidingExpiration = TimeSpan.FromHours(slidingTime);
                        break;
                    }
                case DateFunctions.TimeMeasuresEnum.FromMinutes:
                    {
                        cacheItemPolicy.SlidingExpiration = TimeSpan.FromMinutes(slidingTime);
                        break;
                    }
                case DateFunctions.TimeMeasuresEnum.FromSeconds:
                    {
                        cacheItemPolicy.SlidingExpiration = TimeSpan.FromSeconds(slidingTime);
                        break;
                    }
            }
            #endregion

            
          
            realCache.Add(key, value, cacheItemPolicy);

        }


        /// <summary>
        /// Removes the given item from the cache. If no item exists with that key, this method does nothing.
        /// </summary>
        /// <param name="key">Key of item to remove from cache.</param>
        /// <exception cref="ArgumentNullException">Provided key is null</exception>
        /// <exception cref="ArgumentException">Provided key is an empty string</exception>
        /// <remarks>The CacheManager can be configured to use different storage mechanisms in which to store the CacheItems.
        /// Each of these storage mechanisms can throw exceptions particular to their own implementations.</remarks>
        public static void Remove(string key)
        {
            realCache.Remove(key);
        }

        /// <summary>
        /// Returns the value associated with the given key.
        /// </summary>
        /// <param name="key">Key of item to return from cache.</param>
        /// <returns>Value stored in cache</returns>
        /// <exception cref="ArgumentNullException">Provided key is null</exception>
        /// <exception cref="ArgumentException">Provided key is an empty string</exception>
        /// <remarks>The CacheManager can be configured to use different storage mechanisms in which to store the CacheItems.
        /// Each of these storage mechanisms can throw exceptions particular to their own implementations.</remarks>
        public static object GetData(string key)
        {
          
           return realCache.Get(key);
        }

        /// <summary>
        /// Removes all items from the cache. If an error occurs during the removal, the cache is left unchanged.
        /// </summary>
        /// <remarks>The CacheManager can be configured to use different storage mechanisms in which to store the CacheItems.
        /// Each of these storage mechanisms can throw exceptions particular to their own implementations.</remarks>
        public static void Flush()
        {
            List<string> cacheKeys = MemoryCache.Default.Select(kvp => kvp.Key).ToList();
            foreach (string cacheKey in cacheKeys)
            {
                MemoryCache.Default.Remove(cacheKey);
            }
        }

        
    }
}
