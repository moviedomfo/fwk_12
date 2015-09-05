using System;
using System.Collections.Generic;
using System.Text;
using Fwk.HelperFunctions;

namespace Fwk.Caching
{
    /// <summary>
    /// Clase Utilizada para Deserializar la configuracion para Cada Servicio Cacheable.
    /// </summary>
    /// <author>moviedo</author>
    /// <date>29/11/2007
    /// </date>
    [Serializable]
    public class CacheSettings
    {
        private Boolean _CacheOnServerSide = false;

        /// <summary>
        /// Bandera que indica si los resultados de la ejecucion del servicio seran primero intentados
        /// otener desde la cache del lado del servidor
        /// </summary>
        /// <example>
        /// <para>
        /// El siguiente ejemplo determina que el servicio se levantara de la cache del 
        /// lado del despachador de servicio.-
        /// </para>
        /// <code>
        /// BuscarPaisesClienteRequest req = new BuscarPaisesRequest();
        /// req.ResponseCacheId = req.ServiceName + "RRHH";
        /// req.CacheOnServerSide = true;
        /// </code>|
        /// </example>
        public Boolean CacheOnServerSide
        {
            get { return _CacheOnServerSide; }
            set { _CacheOnServerSide = value; }
        }
        private Boolean _CacheOnClientSide = false;

        /// <summary>
        /// Bandera que indica si los resultados de la ejecucion del servicio seran primero intentados
        /// otener desde la cache del lado del cliente
        /// </summary>
        /// <example>
        /// <para>
        /// El siguiente ejemplo determina que el servicio se levantara de la cache del 
        /// lado del despachador de servicio.-
        /// </para>
        /// <code>
        /// BuscarPaisesClienteRequest req = new BuscarPaisesRequest();
        /// req.CacheSettings.ResponseCacheId = req.ServiceName + "RRHH";
        /// req.CacheSettings.CacheOnClientSide = true;
        /// </code>
        /// </example>
        public Boolean CacheOnClientSide
        {
            get { return _CacheOnClientSide; }
            set { _CacheOnClientSide = value; }
        }


        private String _ResponseCacheId;

        /// <summary>
        /// Identificador de la cache para el caso de que el servicio este cacheado 
        /// tanto en el lado del cliente como en el servidor.
        /// Puede proporcionarle cualquier identificador de cache. Por ejemplo:
        /// 1- El mismo nombre del servicio
        /// 2 - Nombre de servicio mas fecha
        /// 2 - Nombre de servicio mas Dominio/ Area donde corra el cliente o servidor 
        ///  
        /// Si este valor es = Empty() y alguna de las CacheOnClientSide o CacheOnServerSide estan establecidas en true
        /// se asume el Id de la cache del servicio con el nombre del servicio.-
        /// </summary>
        /// <example>
        /// <para>
        /// El siguiente ejemplo determina que el servicio se levantara de la cache del 
        /// lado del despachador de servicio.-
        /// </para>
        /// <coede>
        /// BuscarPaisesClienteRequest req = new BuscarPaisesRequest();
        /// req.ResponseCacheId = req.ServiceName + "RRHH";
        /// req.CacheOnServerSide = true;
        /// </coede>
        /// </example>
        public String ResponseCacheId
        {
            get { return _ResponseCacheId; }
            set { _ResponseCacheId = value; }
        }
   
        private Int32 _ExpirationTime = 0;
        private Fwk.HelperFunctions.DateFunctions.TimeMeasuresEnum _TimeMeasuresEnum = DateFunctions.TimeMeasuresEnum.FromDays;

        /// <summary>
        /// Medida de tiempo q se usa para reprecentar ExpirationTime 
        /// pueden ser dias, horas, minutos, segundos
        /// Por defecto es FromDays.-
        /// </summary>
        public Fwk.HelperFunctions.DateFunctions.TimeMeasuresEnum TimeMeasures
        {
            get { return _TimeMeasuresEnum; }
            set { _TimeMeasuresEnum = value
; }
        }
        /// <summary>
        /// Valor que indica la cantidad de dias que la cache espera a ser eliminada del cache repository.-
        /// Se pueden utilizar fracciones de dia.-
        /// </summary>
        public Int32 ExpirationTime
        {
            get { return _ExpirationTime; }
            set { _ExpirationTime = value; }
        }



        private String _CacheManagerName;

        /// <summary>
        /// Determina el nombre de la configuracion de la cache
        /// </summary>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///   <cachingConfiguration defaultCacheManager="ConfigurationIsolatedManager">
        ///     <cacheManagers>
        ///         <add expirationPollFrequencyInSeconds="60" 
        ///             maximumElementsInCacheBeforeScavenging="1000"
        ///             numberToRemoveWhenScavenging="60" 
        ///             backingStoreName="NullStorage"
        ///             name="ConfigurationManager" />
        /// ]]>
        /// </code> 
        ///</example>
        public String CacheManagerName
        {
            get { return _CacheManagerName; }
            set { _CacheManagerName = value; }
        }


        

        
        

    }
}
