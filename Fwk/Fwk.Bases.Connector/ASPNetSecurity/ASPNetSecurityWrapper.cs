using System;
using Fwk.Bases;
using Fwk.Exceptions;
using System.Collections.Generic;
using Fwk.ConfigSection;
using System.Net;
using Fwk.Bases.ISVC;

namespace Fwk.Bases.Connector
{

	/// <summary>
	/// Wrapper para interfaz de servicio implementada a través de un web service.
	/// </summary>
	/// <date>2011-06-23T00:00:00</date>
	/// <author>moviedo</author>
    public class ASPNetSecurityWrapper : IServiceWrapper
	{
        string _ProviderName = string.Empty;

        /// <summary>
        /// Proveedor del wrapper. Este valor debe coincidir con un proveedor de metadata en el dispatcher
        /// </summary>
        public string ProviderName
        {
            get { return _ProviderName; }
            set { _ProviderName = value; }
        }

        private string _URL = string.Empty;

        /// <summary>
        /// Direccion url del servicio web
        /// </summary>
        public string SourceInfo
        {
            get { return _URL; }
            set { _URL = value; }
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
		#region IServiceInterfaceWrapper Members 
        ICredentials _Credentials;
        /// <summary>
        /// 
        /// </summary>
        public ICredentials Credentials
        {
            get { return _Credentials; }
            set { _Credentials = value; }
        }
        IWebProxy _Proxy;
        /// <summary>
        /// 
        /// </summary>
        public IWebProxy Proxy
        {
            get { return _Proxy; }
            set { _Proxy = value; }
        }
        /// <summary>
        /// Ejecuta un servicio de negocio.
        /// Si se produce el error:
        /// The parameter is incorrect. (Exception from HRESULT: 0x80070057 (E_INVALIDARG))
        /// Se debe a un error que lanza una llamada asincrona en modo debug  
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param> 
		/// <param name="pData">XML con datos de entrada para la  ejecución del servicio.</param>
		/// <returns>XML con datos de salida del servicio.</returns>
		/// <date>2011-08-23T00:00:00</date>
		/// <author>moviedo</author>
        public string ExecuteService( string pServiceName, string pData)
        {
            string wResult = null;

            using (ASPNetSecurity.ASPNet  wService = new ASPNetSecurity.ASPNet())
            {
                
                if (_Proxy != null)
                    wService.Proxy = _Proxy;
                if (_Credentials != null)
                    wService.Credentials = _Credentials;

                wService.Url = _URL;
                wResult = wService.ExecuteService(_ServiceMetadataProviderName, pServiceName, pData);
            }

            return wResult;
        }

     

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pServiceName"></param>
        /// <param name="pData"></param>
        /// <param name="callback"></param>
        public void ExecuteServiceAsynk(string pServiceName, string pData,Delegate callback)
        {
            using (ASPNetSecurity.ASPNet wService = new ASPNetSecurity.ASPNet())
            {
                if (_Proxy != null)
                    wService.Proxy = _Proxy;
                if (_Credentials != null)
                    wService.Credentials = _Credentials;

                wService.Url = _URL;
                wService.ExecuteServiceCompleted += new Fwk.Bases.Connector.ASPNetSecurity.ExecuteServiceCompletedEventHandler(wService_ExecuteServiceCompleted);
            }
        }

        void wService_ExecuteServiceCompleted(object sender, Fwk.Bases.Connector.ASPNetSecurity.ExecuteServiceCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ejecuta un servicio de negocio. (Metodo vigente solo por compatibilidad con versiones anteriores donde se pasaba el 
        /// nombre del servicio como parametro.-
        /// Si se produce el error:
        /// The parameter is incorrect. (Exception from HRESULT: 0x80070057 (E_INVALIDARG))
        /// Se debe a un error que lanza una llamada asincrona en modo debug  
        /// </summary>
        /// <param name="pReq">Clase que implementa IServiceContract con datos de entrada para la  ejecución del servicio.</param>
        /// <returns>Clase que implementa IServiceContract con datos de respuesta del servicio.</returns>
        /// <date>2011-06-23T00:00:00</date>
        /// <author>moviedo</author>
        public TResponse ExecuteService<TRequest, TResponse>( TRequest pReq)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {
            pReq.InitializeHostContextInformation();

            TResponse wResponse = new TResponse();

            try
            {
                pReq.InitializeHostContextInformation();
                string wResult = ExecuteService( pReq.ServiceName, pReq.GetXml());
                //wResponse.SetXml(wResult);
                wResponse = (TResponse)Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(TResponse), wResult);
                //wResponse.InitializeHostContextInformation();
            }
            catch(Exception ex)
            {
                wResponse.Error = ProcessConnectionsException.Process(ex, _URL);
            }

            //wResponse.InitializeHostContextInformation();
            return wResponse;
        }
        
		#endregion





        #region [ServiceConfiguration]


        /// <summary>
        /// Recupera la configuración de todos los servicios de negocio.
        /// </summary>
        /// <returns>Lista de configuraciones de servicios de negocio.</returns>
        /// <date>2010-09-16T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfigurationCollection GetAllServices()
        {
            string xmlServices = null; 

            using (ASPNetSecurity.ASPNet wService = new ASPNetSecurity.ASPNet())
            {
                if (_Proxy != null)
                    wService.Proxy = _Proxy;
                if (_Credentials != null && wService.Credentials == null)
                    wService.Credentials = _Credentials;
             
         
                wService.Url = _URL;
                xmlServices = wService.GetServicesList(_ServiceMetadataProviderName, true);

            }
            
            ServiceConfigurationCollection wServiceConfigurationCollection = (ServiceConfigurationCollection)
                Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(ServiceConfigurationCollection), xmlServices);

            return wServiceConfigurationCollection;
            
        }
        /// <summary>
        /// Recupera la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <returns>configuración del servicio de negocio.</returns>
        /// <date>2011-04-07T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfiguration GetServiceConfiguration(string pServiceName)
        {
            string xmlServices = null;
            
            using (ASPNetSecurity.ASPNet wService = new ASPNetSecurity.ASPNet())
            {
                if (_Proxy != null)
                    wService.Proxy = _Proxy;
                if (_Credentials != null)
                    wService.Credentials = _Credentials;
                wService.Url = _URL;
                xmlServices = wService.GetServiceConfiguration(_ServiceMetadataProviderName, pServiceName);
            }

            return ServiceConfiguration.GetServiceConfigurationFromXml(xmlServices); ;
        }

        /// <summary>
        /// Actualiza la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2010-09-16T00:00:00</date>
        /// <author>moviedo</author>
        public void SetServiceConfiguration(String pServiceName ,ServiceConfiguration pServiceConfiguration)
        {
            throw new TechnicalException("SetServiceConfiguration is not implemented on ASPNET Security service");
        }

     

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2011-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration)
        {
            throw new TechnicalException("AddServiceConfiguration is not implemented on ASPNET Security service");
        
        }

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <date>2011-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void DeleteServiceConfiguration(string pServiceName)
        {
            throw new TechnicalException("DeleteServiceConfiguration is not implemented on ASPNET Security service");
        }

        /// <summary>
        /// Obtiene una lista de todas las aplicaciones configuradas en el origen de datos configurado por el 
        /// proveedor
        /// </summary>
        /// <returns></returns>
        public  List<String> GetAllApplicationsId()
        {
            throw new TechnicalException("GetAllApplicationsId is not implemented on ASPNET Security service");
        }
        /// <summary>
        /// Obtiene info del proveedor de metadata
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        public Fwk.ConfigSection.MetadataProvider GetProviderInfo(string providerName)
        {
            using (ASPNetSecurity.ASPNet wService = new ASPNetSecurity.ASPNet())
            {
                if (_Proxy != null)
                    wService.Proxy = _Proxy;
                if (_Credentials != null)
                    wService.Credentials = _Credentials;
                wService.Url = _URL;
                Fwk.Bases.Connector.ASPNetSecurity.MetadataProvider wMetadataProviderRemoto = wService.GetProviderInfo(providerName);

                string xml = Fwk.HelperFunctions.SerializationFunctions.SerializeToXml(wMetadataProviderRemoto);
               
                Fwk.ConfigSection.MetadataProvider wMetadata = Fwk.ConfigSection.MetadataProvider.GetFromXml<Fwk.ConfigSection.MetadataProvider>(xml);
                wMetadata.Name = wMetadataProviderRemoto.Name;
                wMetadata.ApplicationId = wMetadataProviderRemoto.ApplicationId;
                wMetadata.SourceInfo = wMetadataProviderRemoto.SourceInfo;
                wMetadata.ConfigProviderType = wMetadataProviderRemoto.ConfigProviderType;

                return wMetadata;

            }
        }
      
        #endregion [ServiceConfiguration]




        #region IServiceWrapper Members


        /// <summary>
        /// Chequea la disponibilidad del despachador de servicio
        /// </summary>
        /// <returns>Mensaje en caso de que el servicio no esté disponible</returns>
        /// <summary>
        /// Chequea si un Dispatcher esta activo
        /// </summary>
        /// <returns></returns>
        public DispatcherInfoBE CheckServiceAvailability(bool includeCnnstSrings, bool includeAppSettings, bool includeMetadata)
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


        public DispatcherInfo RetriveDispatcherInfo()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

