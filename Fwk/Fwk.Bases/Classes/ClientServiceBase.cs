using System;
using System.Collections.Generic;
using System.Text;
using Fwk.Exceptions;

using Fwk.HelperFunctions;
using Fwk.Blocking;
using Fwk.Bases;
using Fwk.Caching;

namespace Fwk.Bases
{
    /// <summary>
    /// 
    /// </summary>
    public class ClientServiceBase
    {


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="providerName">Nombre del proveedor de la metadata de servicio</param>
        /// <param name="pRequest">Request con datos de entrada para la  ejecución del servicio.</param>
        /// <returns></returns>
        public TResponse ExecuteService<TRequest, TResponse>(string providerName, TRequest pRequest)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {

            return WrapperFactory.ExecuteService<TRequest, TResponse>(providerName, pRequest);


        }

        /// <summary>
        /// Ejecuta un servicio de negocio.
        /// </summary>
        /// <param name="pRequest">Request con datos de entrada para la  ejecución del servicio.</param>
        /// <returns>Dataset con datos de respuesta del servicio.</returns>
        /// <date>2007-08-24T00:00:00</date>
        /// <author>moviedo</author>
        public TResponse ExecuteService<TRequest, TResponse>(TRequest pRequest)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {
            return this.ExecuteService<TRequest, TResponse>(string.Empty, pRequest);
        }



        #region [ServiceConfiguration]
        /// <summary>
        /// Recupera la configuración de todos los servicios de negocio.
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de la metadata de servicio</param>
        /// <returns>Lista de configuraciones de servicios de negocio.</returns>
        /// <date>2006-02-10T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfigurationCollection GetAllServices(string providerName)
        {
            if (String.IsNullOrEmpty(providerName)) providerName = string.Empty;
            WrapperFactory.InitWrapper(providerName);

            return WrapperFactory._WraperPepository[providerName].GetAllServices();

        }
        /// <summary>
        /// Recupera la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de la metadata de servicio</param>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <returns>configuración del servicio de negocio.</returns>
        /// <date>2006-02-07T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfiguration GetServiceConfiguration(string providerName, string pServiceName)
        {
            if (String.IsNullOrEmpty(providerName)) providerName = string.Empty;
            WrapperFactory.InitWrapper(providerName);
            return WrapperFactory._WraperPepository[providerName].GetServiceConfiguration(pServiceName);
        }
        /// <summary>
        /// Actualiza la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de la metadata de servicio</param>
        /// <param name="pServiceName">Nombre del servicio de negocio.</param>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2006-02-10T00:00:00</date>
        /// <author>moviedo</author>
        public void SetServiceConfiguration(string providerName, String pServiceName, ServiceConfiguration pServiceConfiguration)
        {
            if (String.IsNullOrEmpty(providerName)) providerName = string.Empty;
            WrapperFactory.InitWrapper(providerName);
            WrapperFactory._WraperPepository[providerName].SetServiceConfiguration(pServiceName, pServiceConfiguration);
        }

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de la metadata de servicio</param>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2006-02-13T00:00:00</date>
        /// <author>moviedo</author>
        public void AddServiceConfiguration(string providerName, ServiceConfiguration pServiceConfiguration)
        {
            if (String.IsNullOrEmpty(providerName)) providerName = string.Empty;
            WrapperFactory.InitWrapper(providerName);
            WrapperFactory._WraperPepository[providerName].AddServiceConfiguration(pServiceConfiguration);
        }

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de la metadata de servicio</param>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <date>2006-02-13T00:00:00</date>
        /// <author>moviedo</author>
        public void DeleteServiceConfiguration(string providerName, string pServiceName)
        {
            if (String.IsNullOrEmpty(providerName)) providerName = string.Empty;
            WrapperFactory.InitWrapper(providerName);

            WrapperFactory._WraperPepository[providerName].DeleteServiceConfiguration(pServiceName);
        }

        /// <summary>
        /// Obtiene una lista de todas las aplicaciones configuradas en el origen de datos configurado por el 
        /// proveedor
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        public List<String> GetAllApplicationsId(string providerName)
        {
            if (String.IsNullOrEmpty(providerName)) providerName = string.Empty;
            WrapperFactory.InitWrapper(providerName);

            return WrapperFactory._WraperPepository[providerName].GetAllApplicationsId();
        }


        /// <summary>
        /// Obtiene info del proveedor de metadata
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        public Fwk.ConfigSection.MetadataProvider GetProviderInfo(string providerName)
        {
            if (String.IsNullOrEmpty(providerName)) providerName = string.Empty;
            WrapperFactory.InitWrapper(providerName);
            return WrapperFactory._WraperPepository[providerName].GetProviderInfo(providerName);
        }
        #endregion [ServiceConfiguration]
    }
}
