using System;
using System.Collections.Generic;
using System.Text;
using Fwk.Bases;
using Fwk.BusinessFacades;
using Fwk.Exceptions;
using Fwk.ConfigSection;
using Fwk.Bases.ISVC;

namespace Fwk.Bases.Connector
{
    /// <summary>
    /// Rapper que realiza la ejecucion de servicios de forma local. Llama directamente al la facada de servicios
    /// </summary>
    public class LocalWrapper : IServiceWrapper
    {
        #region properties
        SimpleFacade _SimpleFacade;

        string _ProviderName;

        /// <summary>
        /// Proveedor del wrapper. Este valor debe coincidir con un proveedor de metadata en el dispatcher
        /// </summary>
        public string ProviderName
        {
            get { return _ProviderName; }
            set { _ProviderName = value; }
        }
        //string _SourceInfo;

        /// <summary>
        /// No se utiliza en un wrapper local
        /// </summary>
        public string SourceInfo
        {
            get { return null; }
            set {  }
        }
        string _ServiceMetadataProviderName = string.Empty;

        /// <summary>
        /// Proveedor del metadatos en el despachador de servicios
        /// </summary>
        public string ServiceMetadataProviderName
        {
            get { return _ServiceMetadataProviderName; }
            set { _ServiceMetadataProviderName = value; }
        }

        string _AppId = string.Empty;

        /// <summary>
        /// Identificador de empresa
        /// </summary>
        public string AppId
        {
            get { return _AppId; }
            set { _AppId = value; }
        }
        string _DefaultCulture = string.Empty;

        /// <summary>
        /// DefaultCulture de empresa
        /// </summary>
        public string ConfigProviderNameWithCultureInfo
        {
            get { return _DefaultCulture; }
            set { _DefaultCulture = value; }
        }
        #endregion 

        /// <summary>
        /// Implementa la llamada al backend atravez de la ejecucion de la SimpleFacade. 
        /// Al llamar directamente a la SimpleFacade funciona como un despachador de servicios, esto lo hace
        /// debido  a aque se trata de un wrapper local.
        /// </summary>
        /// <param name="pReq">Clase request que implementa IServiceContract. No nececita pasarce el representativo xml de tal
        /// objeto, esto es para evitar serializacion innecesaria</param>
        /// <returns>Response con los resultados del servicio</returns>
        private IServiceContract ExecuteService(IServiceContract pReq)
        {
            if (_SimpleFacade == null)
                _SimpleFacade = CreateSimpleFacade();

            pReq.InitializeHostContextInformation();
            IServiceContract wResponse = _SimpleFacade.ExecuteService(_ServiceMetadataProviderName, pReq);
            //wResponse.InitializeHostContextInformation();

            return wResponse;
        }

        /// <summary>
        /// Ejecuta un servicio de negocio.
        /// Si se produce el error:
        /// The parameter is incorrect. (Exception from HRESULT: 0x80070057 (E_INVALIDARG))
        /// Se debe a un error que lanza una llamada asincrona en modo debug  
        /// </summary>
        /// <param name="pReq">Clase que implementa IServiceContract con datos de entrada para la  ejecución del servicio.</param>
        /// <returns>Clase que implementa IServiceContract con datos de respuesta del servicio.</returns>
        /// <date>2007-06-23T00:00:00</date>
        /// <author>moviedo</author>
        public TResponse ExecuteService<TRequest, TResponse>( TRequest pReq)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {

            TResponse wResponse = (TResponse)this.ExecuteService(pReq);
            return wResponse;
        }

        /// <summary>
        /// Ejecuta un servicio de negocio.
        /// </summary>
        /// <param name="pReq">Clase que implementa IServiceContract con datos de entrada para la  ejecución del servicio.</param>
        /// <returns>Clase que implementa IServiceContract con datos de respuesta del servicio.</returns>
        /// <date>2007-06-23T00:00:00</date>
        /// <author>moviedo</author>
        ////////public TResponse ExecuteService<TRequest, TResponse>(TRequest pReq)
        ////////    where TRequest : IServiceContract
        ////////    where TResponse : IServiceContract, new()
        ////////{
        ////////   return (TResponse)this.ExecuteService(pReq);
        ////////}

        /// <summary>
        /// Este metodo no esta implementado para un wrapper local.-
        /// Su ejecucion producira un error.-
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="pData"></param>
        /// <returns></returns>
        [Obsolete("The method or operation is not implemented on local wraper")]
        public string ExecuteService( string serviceName, string pData)
        {
            throw new Exception("The method or operation is not implemented.");
        }


        #region [ServiceConfiguration]

        /// <summary>
        /// Recupera la configuración de todos los servicios de negocio.
        /// </summary>
        /// <returns>Lista de configuraciones de servicios de negocio.</returns>
        /// <date>2008-04-10T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfigurationCollection GetAllServices()
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();

            String xmlServices = wSimpleFacade.GetServicesList(_ServiceMetadataProviderName ,true);
            ServiceConfigurationCollection wServiceConfigurationCollection = (ServiceConfigurationCollection)
                Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(ServiceConfigurationCollection), xmlServices);

            return wServiceConfigurationCollection;
        }

        /// <summary>
        /// Recupera la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="serviceName">Nombre del servicio.</param>
        /// <returns>configuración del servicio de negocio.</returns>
        /// <date>2008-04-07T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfiguration GetServiceConfiguration(string serviceName)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            String xmlServices = wSimpleFacade.GetServiceConfiguration(_ServiceMetadataProviderName, serviceName);
            return ServiceConfiguration.GetServiceConfigurationFromXml(xmlServices);
           
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="serviceName"></param>
       /// <param name="pServiceConfiguration"></param>
        public void SetServiceConfiguration(String serviceName, ServiceConfiguration pServiceConfiguration)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            wSimpleFacade.SetServiceConfiguration(_ServiceMetadataProviderName, serviceName, pServiceConfiguration);
          
        }

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            wSimpleFacade.AddServiceConfiguration(_ServiceMetadataProviderName, pServiceConfiguration);
           
        }

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="serviceName">Nombre del servicio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void DeleteServiceConfiguration(string serviceName)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            wSimpleFacade.DeleteServiceConfiguration(_ServiceMetadataProviderName, serviceName);
           
        }
        /// <summary>
        /// Obtiene una lista de todas las aplicaciones configuradas en el origen de datos configurado por el 
        /// proveedor
        /// </summary>
        /// <returns></returns>
        public  List<String> GetAllApplicationsId()
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            return wSimpleFacade.GetAllApplicationsId(_ServiceMetadataProviderName);
       
        }



        /// <summary>
        /// Obtiene info del proveedor de metadata
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        public  Fwk.ConfigSection.MetadataProvider GetProviderInfo(string providerName)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            return wSimpleFacade.GetProviderInfo(providerName);
        }

        /// <summary>
        /// Factory de SimpleFacade
        /// </summary>
        /// <returns></returns>
        SimpleFacade CreateSimpleFacade()
        {
            if(_SimpleFacade == null)
                _SimpleFacade = new SimpleFacade();

            return _SimpleFacade;
        }
        #endregion

        #region IServiceWrapper Members

        /// <summary>
        /// Chequea la disponibilidad del despachador de servicio
        /// </summary>
        /// <returns>Mensaje en caso de que el servicio no esté disponible</returns>
        /// <summary>
        /// Chequea si un Dispatcher esta activo
        /// </summary>
        /// <returns></returns>
        public DispatcherInfoBE CheckServiceAvailability(bool includeCnnstSrings = false, bool includeAppSettings = false, bool includeMetadata = false)
        {
            RetriveDispatcherInfoReq req = new RetriveDispatcherInfoReq();
            req.BusinessData.IncludeAppSettings = includeAppSettings;
            req.BusinessData.IncludeCnnstSrings = includeCnnstSrings;
            req.BusinessData.IncludeMetadata = includeMetadata;
            var res = this.ExecuteService<RetriveDispatcherInfoReq, RetriveDispatcherInfoRes>(req);
            if (res.Error != null)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            }

            return res.BusinessData;
        }

        #endregion

        #region IServiceWrapper Members


        public Fwk.ConfigSection.DispatcherInfo RetriveDispatcherInfo()
        {
            if (_SimpleFacade == null)
                _SimpleFacade = CreateSimpleFacade();
            return _SimpleFacade.RetriveDispatcherInfo();
        }

        #endregion
    }
}
