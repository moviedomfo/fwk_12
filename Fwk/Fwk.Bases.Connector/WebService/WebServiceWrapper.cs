using System;
using Fwk.Bases;
using Fwk.Exceptions;
using System.Collections.Generic;
using Fwk.ConfigSection;
using System.Net;
using System.Data;
using Fwk.Bases.ISVC;

namespace Fwk.Bases.Connector
{

	/// <summary>
	/// Wrapper para interfaz de servicio implementada a través de un web service.
	/// </summary>
	/// <date>2007-06-23T00:00:00</date>
	/// <author>moviedo</author>
	public class WebServiceWrapper : IServiceWrapper
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
		/// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param> 
		/// <param name="pData">XML con datos de entrada para la  ejecución del servicio.</param>
		/// <returns>XML con datos de salida del servicio.</returns>
		/// <date>2007-08-23T00:00:00</date>
		/// <author>moviedo</author>
        public string ExecuteService( string pServiceName, string pData)
        {
            string wResult = null;

            using (Singleservice.SingleService wService = new Singleservice.SingleService())
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
        public void ExecuteService_OneWay(string pServiceName, string pData)
        {
            using (Singleservice.SingleService wService = new Singleservice.SingleService())
            {
                if (_Proxy != null)
                    wService.Proxy = _Proxy;
                if (_Credentials != null)
                    wService.Credentials = _Credentials;
                wService.Url = _URL;
                wService.ExecuteService_OneWay(_ServiceMetadataProviderName, pServiceName, pData);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pServiceName"></param>
        /// <param name="pData"></param>
        /// <param name="callback"></param>
        public void ExecuteServiceAsynk(string pServiceName, string pData,Delegate callback)
        {
            using (Singleservice.SingleService wService = new Singleservice.SingleService())
            {
                if (_Proxy != null)
                    wService.Proxy = _Proxy;
                if (_Credentials != null)
                    wService.Credentials = _Credentials;
                
                wService.Url = _URL;
                wService.ExecuteServiceCompleted += new Fwk.Bases.Connector.Singleservice.ExecuteServiceCompletedEventHandler(wService_ExecuteServiceCompleted);
            }
        }

        void wService_ExecuteServiceCompleted(object sender, Fwk.Bases.Connector.Singleservice.ExecuteServiceCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ejecuta un servicio de negocio. (Metodo vigente solo por compatibilidad con versiones anteriores donde se pasaba el 
        /// nombre del servicio como parametro.-
        /// </summary>
        /// <param name="pReq">Clase que implementa IServiceContract con datos de entrada para la  ejecución del servicio.</param>
        /// <returns>Clase que implementa IServiceContract con datos de respuesta del servicio.</returns>
        /// <date>2007-06-23T00:00:00</date>
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
                //16/05/2012 Se deja esta serializacion se comenta la anterior
                //Motivo: Cuando el Response implementaba un BussinesData escalar o entidad no List y se retornaba Null (en BussinesData)
                //No se podia hace un SetXml
                wResponse = (TResponse)Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(TResponse),wResult);
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


        #region [ServiceConfiguration]


        /// <summary>
        /// Recupera la configuración de todos los servicios de negocio.
        /// </summary>
        /// <returns>Lista de configuraciones de servicios de negocio.</returns>
        /// <date>2008-04-10T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfigurationCollection GetAllServices()
        {
            string xmlServices = null; 

            using (Singleservice.SingleService wService = new Singleservice.SingleService())
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
        /// <date>2008-04-07T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfiguration GetServiceConfiguration(string pServiceName)
        {
            string xmlServices = null;

            using (Singleservice.SingleService wService = new Singleservice.SingleService())
            {
                if (_Proxy != null)
                    wService.Proxy = _Proxy;
                if (_Credentials != null)
                    wService.Credentials = _Credentials;
                wService.Url = _URL;
                xmlServices = wService.GetServiceConfiguration(_ServiceMetadataProviderName, pServiceName);
            }
            try
            {
                return ServiceConfiguration.GetServiceConfigurationFromXml(xmlServices);
            }
            catch (Exception ex)
            {
                throw ex;// .Error = ProcessConnectionsException.Process(ex, _URL);
            }

        }

        /// <summary>
        /// Actualiza la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2008-04-10T00:00:00</date>
        /// <author>moviedo</author>
        public void SetServiceConfiguration(String pServiceName ,ServiceConfiguration pServiceConfiguration)
        {
            Fwk.Bases.Connector.Singleservice.ServiceConfiguration wServiceConfigurationProxy = 
                GetServiceConfigurationProxy(pServiceConfiguration);
            
            using (Singleservice.SingleService wService = new Singleservice.SingleService())
            {
                if (_Proxy != null)
                    wService.Proxy = _Proxy;
                if (_Credentials != null)
                    wService.Credentials = _Credentials;
                wService.Url = _URL;
                wService.SetServiceConfiguration(_ServiceMetadataProviderName, pServiceName, wServiceConfigurationProxy);

            }
        }

     

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration)
        {
            Fwk.Bases.Connector.Singleservice.ServiceConfiguration wServiceConfigurationProxy = 
                GetServiceConfigurationProxy(pServiceConfiguration);

            using (Singleservice.SingleService wService = new Singleservice.SingleService())
            {
                if (_Proxy != null)
                    wService.Proxy = _Proxy;
                if (_Credentials != null)
                    wService.Credentials = _Credentials;
                wService.Url = _URL;
                wService.AddServiceConfiguration(_ServiceMetadataProviderName, wServiceConfigurationProxy);

            }
        
        }

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void DeleteServiceConfiguration(string pServiceName)
        {
            using (Singleservice.SingleService wService = new Singleservice.SingleService())
            {
                if (_Proxy != null)
                    wService.Proxy = _Proxy;
                if (_Credentials != null)
                    wService.Credentials = _Credentials;
                wService.Url = _URL;
                wService.DeleteServiceConfiguration(_ServiceMetadataProviderName, pServiceName);
            }
        }

        /// <summary>
        /// Obtiene una lista de todas las aplicaciones configuradas en el origen de datos configurado por el 
        /// proveedor
        /// </summary>
        /// <returns></returns>
        public  List<String> GetAllApplicationsId()
        {
            using (Singleservice.SingleService wService = new Singleservice.SingleService())
            {
                if (_Proxy != null)
                    wService.Proxy = _Proxy;
                if (_Credentials != null)
                    wService.Credentials = _Credentials;
                wService.Url = _URL;
                string[] wArraylist = wService.GetAllApplicationsId(_ServiceMetadataProviderName);
                return new List<string>(wArraylist);
            }
        }
        /// <summary>
        /// Obtiene info del proveedor de metadata
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        public Fwk.ConfigSection.MetadataProvider GetProviderInfo(string providerName)
        {
            using (Singleservice.SingleService wService = new Singleservice.SingleService())
            {
                if (_Proxy != null)
                    wService.Proxy = _Proxy;
                if (_Credentials != null)
                    wService.Credentials = _Credentials;
                wService.Url = _URL;
                Fwk.Bases.Connector.Singleservice.MetadataProvider wMetadataProviderRemoto = wService.GetProviderInfo(providerName);

                string xml = Fwk.HelperFunctions.SerializationFunctions.SerializeToXml(wMetadataProviderRemoto);
               
                Fwk.ConfigSection.MetadataProvider wMetadata = Fwk.ConfigSection.MetadataProvider.GetFromXml<Fwk.ConfigSection.MetadataProvider>(xml);
                wMetadata.Name = wMetadataProviderRemoto.Name;
                wMetadata.ApplicationId = wMetadataProviderRemoto.ApplicationId;
                wMetadata.SourceInfo = wMetadataProviderRemoto.SourceInfo;
                wMetadata.ConfigProviderType = wMetadataProviderRemoto.ConfigProviderType;

                return wMetadata;

            }
        }

        /// <summary>
        /// Retorna uyn alista de Service Metadata providers configurados en el Web Service Dispatcher
        /// </summary>
        /// <returns></returns>
        public DispatcherInfo RetriveDispatcherInfo()
        {
            using (Singleservice.SingleService wService = new Singleservice.SingleService())
            {
                if (_Proxy != null)
                    wService.Proxy = _Proxy;
                if (_Credentials != null)
                    wService.Credentials = _Credentials;
                wService.Url = _URL;

              Fwk.Bases.Connector.Singleservice.DispatcherInfo  wsDispatcherInfo = wService.RetriveDispatcherInfo();
                DispatcherInfo wDispatcherInfo = new DispatcherInfo();


                wDispatcherInfo.ServiceDispatcherConnection = wsDispatcherInfo.ServiceDispatcherConnection;
                wDispatcherInfo.MachineIp = wsDispatcherInfo.MachineIp;
                wDispatcherInfo.ServiceDispatcherName = wsDispatcherInfo.ServiceDispatcherName;
                List<Fwk.ConfigSection.MetadataProvider> providers = new List<MetadataProvider>();
                MetadataProvider provider = null;
                foreach (var p in wsDispatcherInfo.MetadataProviders)
                {
                    provider = new MetadataProvider();
                    provider.ApplicationId = p.ApplicationId;
                    provider.ConfigProviderType = p.ConfigProviderType;
                    //provider.DefaultCulture = p.DefaultCulture;
                    provider.Name = p.Name;
                    provider.SecurityProviderName = p.SecurityProviderName;
                    provider.SourceInfo = p.SourceInfo;
                    wDispatcherInfo.MetadataProviders.Add(provider);
                }
                foreach (var p in wsDispatcherInfo.AppSettings)
                {
                    wDispatcherInfo.AppSettings.Add(new DictionarySetting(p.Key,p.Value));
                }
                foreach (var p in wsDispatcherInfo.CnnStringSettings)
                {
                    wDispatcherInfo.CnnStringSettings.Add(new DictionarySetting(p.Key, p.Value));
                }
              
               return wDispatcherInfo;
            }
        }

        /// <summary>
        /// Mapeta  Fwk.Bases.ServiceConfiguration a Fwk.Bases.Connector.SingleService.ServiceConfiguration 
        /// </summary>
        /// <param name="pServiceConfiguration"></param>
        /// <returns></returns>
        private static Fwk.Bases.Connector.Singleservice.ServiceConfiguration GetServiceConfigurationProxy(ServiceConfiguration pServiceConfiguration)
        {
            Fwk.Bases.Connector.Singleservice.ServiceConfiguration wServiceConfigurationProxy = null;

            wServiceConfigurationProxy = new Fwk.Bases.Connector.Singleservice.ServiceConfiguration();
            wServiceConfigurationProxy.Audit = pServiceConfiguration.Audit;
            wServiceConfigurationProxy.name = pServiceConfiguration.Name;
            wServiceConfigurationProxy.Handler = pServiceConfiguration.Handler;
            wServiceConfigurationProxy.Request = pServiceConfiguration.Request;
            wServiceConfigurationProxy.Response = pServiceConfiguration.Response;
            wServiceConfigurationProxy.CreatedDateTime = pServiceConfiguration.CreatedDateTime;
            wServiceConfigurationProxy.ApplicationId = pServiceConfiguration.ApplicationId;
            wServiceConfigurationProxy.Available = pServiceConfiguration.Available;
            wServiceConfigurationProxy.Description = pServiceConfiguration.Description;
            wServiceConfigurationProxy.Audit = pServiceConfiguration.Audit;
            wServiceConfigurationProxy.CreatedUserName = pServiceConfiguration.CreatedUserName;
            String name = Enum.GetName(typeof(Fwk.Transaction.IsolationLevel), pServiceConfiguration.IsolationLevel);
            wServiceConfigurationProxy.IsolationLevel = (Fwk.Bases.Connector.Singleservice.IsolationLevel)
                Enum.Parse(typeof(Fwk.Bases.Connector.Singleservice.IsolationLevel), pServiceConfiguration.IsolationLevel.ToString());

            wServiceConfigurationProxy.TransactionalBehaviour = (Fwk.Bases.Connector.Singleservice.TransactionalBehaviour)
                Enum.Parse(typeof(Fwk.Bases.Connector.Singleservice.TransactionalBehaviour), pServiceConfiguration.TransactionalBehaviour.ToString());
           

            return wServiceConfigurationProxy;
        }
        #endregion [ServiceConfiguration]


        
    }
}

