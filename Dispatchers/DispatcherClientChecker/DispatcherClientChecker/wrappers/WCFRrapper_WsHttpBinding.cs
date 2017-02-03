using System;
using System.Collections.Generic;
using System.Text;
using Fwk.Bases;
using Fwk.Exceptions;
using System.Runtime.Remoting;
using Fwk.Remoting;
using Fwk.BusinessFacades.Utils;
using Fwk.ConfigSection;
using System.ServiceModel;
using Fwk.Bases.Connector.WCFServiceReference;
using System.ServiceModel.Channels;



namespace DispatcherClientChecker.wrappers
{

    /// <summary>
    /// Wrapper espesializado para una conexión http a WSHttpBinding
    /// </summary>
    [Serializable]
    public  class WCFWrapper_WsHttpBinding : IServiceWrapper
    {
        #region properties
        protected const int factorSize = 5;
       protected WSHttpBinding binding = null;
       protected EndpointAddress address = null;
        string _ProviderName;

        public WCFWrapper_WsHttpBinding()
        {
            
        }
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
        /// Identificador de aplicacion o de empresa
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
        public virtual void InitilaizeBinding()
        {
            if (binding == null)
            {
                //El tamaño de los mensajes que se pueden recibir durante la conexión a los servicios mediante BasicHttpBinding
                this.binding = new WSHttpBinding();

                //binding.Security.Mode = SecurityMode.Message;
                //binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;


                this.binding.Name = "iis";
                //binding.MaxReceivedMessageSize *= factorSize;

                //Para que no tire error 
                // Error in deserializing body of reply message for operation 'ProcessClientRequest'. 
                // The maximum string content length quota (8192) has been exceeded while reading XML data. 

                binding.MaxReceivedMessageSize *= factorSize;
                binding.MaxBufferPoolSize *= factorSize;
                binding.ReaderQuotas.MaxDepth = System.Int32.MaxValue;
                binding.ReaderQuotas.MaxNameTableCharCount = System.Int32.MaxValue;
                binding.ReaderQuotas.MaxStringContentLength = System.Int32.MaxValue;
                binding.ReaderQuotas.MaxArrayLength = System.Int32.MaxValue;
                binding.ReaderQuotas.MaxBytesPerRead = System.Int32.MaxValue;
                address = new EndpointAddress(_URL);
                //var channelFactory = new ChannelFactory<IFwkService>(binding, address);
                //client = channelFactory.CreateChannel();
            }
        }

        #region IServiceInterfaceWrapper Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pServiceName"></param>
        /// <param name="pData"></param>
        /// <returns></returns>
        public string ExecuteService(string pServiceName, string pData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ejecuta un servicio de negocio.
        /// Si se produce el error:
        /// The parameter is incorrect. (Exception from HRESULT: 0x80070057 (E_INVALIDARG))
        /// Se debe a un error que lanza una llamada asincrona en modo debug  
        /// </summary>
        /// <param name="req">Clase que imlementa la interfaz IServiceContract datos de entrada para la  ejecución del servicio.</param>
        /// <returns>Clase que imlementa la interfaz IServiceContract con datos de respuesta del servicio.</returns>
        /// <returns>response</returns>
        public TResponse ExecuteService<TRequest, TResponse>(TRequest req)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {

            InitilaizeBinding();

            req.InitializeHostContextInformation();

            ExecuteServiceRequest wcfReq = new ExecuteServiceRequest();
            ExecuteServiceResponse wcfRes = null;

            wcfReq.serviceName = req.ServiceName;
            wcfReq.providerName = _ServiceMetadataProviderName;
            wcfReq.jsonRequets = Fwk.HelperFunctions.SerializationFunctions.SerializeObjectToJson<TRequest>(req);


            var channelFactory = new ChannelFactory<IFwkService>(binding, address);

            IFwkService client = null;
            try
            {
                client = channelFactory.CreateChannel();
                client.ExecuteService(wcfReq);
                ((ICommunicationObject)client).Close();
            }
            catch (Exception ex)
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                } throw ex;
            }



            TResponse response = (TResponse)Fwk.HelperFunctions.SerializationFunctions.DeSerializeObjectFromJson<TResponse>(wcfRes.ExecuteServiceResult);

            response.InitializeHostContextInformation();
            return response;
        }



        #endregion
        IFwkService client = null;
        #region [ServiceConfiguration]


        /// <summary>
        /// Recupera la configuración de todos los servicios de negocio.
        /// </summary>
        /// <returns>Lista de configuraciones de servicios de negocio.</returns>
        /// <date>2008-04-10T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfigurationCollection GetAllServices()
        {
            InitilaizeBinding();

            GetServicesListRequest wcfReq = new GetServicesListRequest();
            GetServicesListResponse wcfRes = null;

            wcfReq.providerName = _ServiceMetadataProviderName;
            wcfReq.ViewAsXml = true;

            var channelFactory = new ChannelFactory<IFwkService>(binding, address);
            IFwkService client = null;
            try
            {
                client = channelFactory.CreateChannel();
                wcfRes = client.GetServicesList(wcfReq);
                ((ICommunicationObject)client).Close();
            }
            catch (Exception ex)
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
                throw ex;
            }


            ServiceConfigurationCollection wServiceConfigurationCollection = (ServiceConfigurationCollection)
           Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(ServiceConfigurationCollection), wcfRes.GetServicesListResult);

            return wServiceConfigurationCollection;

        }

        /// <summary>
        /// Recupera la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <returns>configuración del servicio de negocio.</returns>
        /// <date>2008-04-07T00:00:00</date>
        /// <author>moviedo</author>
        public Fwk.Bases.ServiceConfiguration GetServiceConfiguration(String pServiceName)
        {

            InitilaizeBinding();
            GetServiceConfigurationRequest wcfReq = new GetServiceConfigurationRequest();
            GetServiceConfigurationResponse wcfRes = null;

            wcfReq.providerName = _ServiceMetadataProviderName;
            wcfReq.serviceName = pServiceName;

            var channelFactory = new ChannelFactory<IFwkService>(binding, address);
            IFwkService client = null;
            try
            {
                client = channelFactory.CreateChannel();
                wcfRes = client.GetServiceConfiguration(wcfReq);
                ((ICommunicationObject)client).Close();
            }
            catch (Exception ex)
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
                throw ex;
            }

            Fwk.Bases.ServiceConfiguration wServiceConfiguration = (Fwk.Bases.ServiceConfiguration)
         Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(Fwk.Bases.ServiceConfiguration), wcfRes.GetServiceConfigurationResult);

            return wServiceConfiguration;

        }

        /// <summary>
        /// Actualiza la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2008-04-10T00:00:00</date>
        /// <author>moviedo</author>
        public void SetServiceConfiguration(string pServiceName, Fwk.Bases.ServiceConfiguration pServiceConfiguration)
        {
            throw new NotImplementedException();
            //wFwkRemoteObject.SetServiceConfiguration(_ServiceMetadataProviderName, pServiceName, pServiceConfiguration);
        }

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void AddServiceConfiguration(Fwk.Bases.ServiceConfiguration pServiceConfiguration)
        {
            throw new NotImplementedException();
            //wFwkRemoteObject.AddServiceConfiguration(_ServiceMetadataProviderName, pServiceConfiguration);
        }

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void DeleteServiceConfiguration(String pServiceName)
        {
            throw new NotImplementedException();
            //wFwkRemoteObject.DeleteServiceConfiguration(_ServiceMetadataProviderName, pServiceName);
        }

        /// <summary>
        /// Obtiene una lista de todas las aplicaciones configuradas en el origen de datos configurado por el 
        /// proveedor
        /// </summary>
        /// <returns></returns>
        public List<String> GetAllApplicationsId()
        {
            InitilaizeBinding();
            GetAllApplicationsIdRequest wcfReq = new GetAllApplicationsIdRequest();
            GetAllApplicationsIdResponse wcfRes = null;

            wcfReq.providerName = _ServiceMetadataProviderName;

            var channelFactory = new ChannelFactory<IFwkService>(binding, address);

            IFwkService client = null;
            try
            {
                client = channelFactory.CreateChannel();
                wcfRes = client.GetAllApplicationsId(wcfReq);
                ((ICommunicationObject)client).Close();
            }
            catch (Exception ex)
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
                throw ex;
            }

            List<String> list = new List<string>();
            list.AddRange(wcfRes.GetAllApplicationsIdResult);
            return list;
        }
        /// <summary>
        /// Obtiene info del proveedor de metadata
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        public Fwk.ConfigSection.MetadataProvider GetProviderInfo(string providerName)
        {
            InitilaizeBinding();

            GetProviderInfoRequest wcfReq = new GetProviderInfoRequest();
            GetProviderInfoResponse wcfRes = null;

            wcfReq.providerName = providerName;

            var channelFactory = new ChannelFactory<IFwkService>(binding, address);
            IFwkService client = null;
            try
            {
                client = channelFactory.CreateChannel();
                wcfRes = client.GetProviderInfo(wcfReq);
                ((ICommunicationObject)client).Close();
            }
            catch (Exception ex)
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
                throw ex;
            }

            MetadataProvider wMetadataProvider = wcfRes.GetProviderInfoResult;
            return wMetadataProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DispatcherInfo RetriveDispatcherInfo()
        {
            InitilaizeBinding();

            RetriveDispatcherInfoRequest wcfReq = new RetriveDispatcherInfoRequest();
            RetriveDispatcherInfoResponse wcfRes = null;

            var channelFactory = new ChannelFactory<IFwkService>(binding, address);
            IFwkService client = null;
            try
            {
                client = channelFactory.CreateChannel();
                
                wcfRes = client.RetriveDispatcherInfo(wcfReq);
                ((ICommunicationObject)client).Close();
            }
            catch (Exception ex)
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
                throw ex;
            }

            DispatcherInfo wDispatcherInfo = wcfRes.RetriveDispatcherInfoResult;
            return wDispatcherInfo;

        }
        #endregion [ServiceConfiguration]

       
       
   
        
        


        public string CheckServiceAvailability()
        {
            throw new NotImplementedException();
        }




        public Fwk.Bases.ISVC.DispatcherInfoBE CheckServiceAvailability(bool includeCnnstSrings = false, bool includeAppSettings = false, bool includeMetadata = false)
        {
            throw new NotImplementedException();
        }
    }
}

