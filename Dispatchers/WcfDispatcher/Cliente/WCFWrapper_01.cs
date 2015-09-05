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
using Newtonsoft.Json;


namespace Fwk.Bases.Connector
{
    /// <summary>
    /// Wrapper espesializado para una conexión a travez de RemotingConfiguration
    /// </summary>
    [Serializable]
    public class WCFWrapper_01 : IServiceWrapper
    {
        NetTcpBinding binding = null;
        EndpointAddress address = null;
        FwkServiceClient svcProxy = null;
        JsonSerializerSettings settings = null;
        string _ProviderName;

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
            InitHost();
            req.InitializeHostContextInformation();
            ExecuteServiceRequest wcfReq = new ExecuteServiceRequest();
            ExecuteServiceResponse wcfRes = null;

            wcfReq.serviceName = req.ServiceName;
            wcfReq.providerName = _ServiceMetadataProviderName;
            wcfReq.jsonRequets = Newtonsoft.Json.JsonConvert.SerializeObject(req, Formatting.None);


            if (svcProxy == null)
            {
                svcProxy = new WCFServiceReference.FwkServiceClient(binding, address);
                svcProxy.Open();
                settings = new JsonSerializerSettings();
                settings.Formatting = Formatting.None;
            }

            wcfRes = svcProxy.ExecuteService(wcfReq);

            TResponse response = Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(wcfRes.ExecuteServiceResult, settings);
            response.InitializeHostContextInformation();
            return response;
        }



        #endregion

        
        #region [ServiceConfiguration]


        /// <summary>
        /// Recupera la configuración de todos los servicios de negocio.
        /// </summary>
        /// <returns>Lista de configuraciones de servicios de negocio.</returns>
        /// <date>2008-04-10T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfigurationCollection GetAllServices()
        {

            throw new NotImplementedException();
            //return wFwkRemoteObject.GetServicesList(_ServiceMetadataProviderName);

        }

        /// <summary>
        /// Recupera la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <returns>configuración del servicio de negocio.</returns>
        /// <date>2008-04-07T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfiguration GetServiceConfiguration(String pServiceName)
        {
            throw new NotImplementedException();
            //return wFwkRemoteObject.GetServiceConfiguration(_ServiceMetadataProviderName, pServiceName);

        }

        /// <summary>
        /// Actualiza la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2008-04-10T00:00:00</date>
        /// <author>moviedo</author>
        public void SetServiceConfiguration(string pServiceName, ServiceConfiguration pServiceConfiguration)
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
        public void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration)
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
            throw new NotImplementedException();
            //return wFwkRemoteObject.GetAllApplicationsId(_ServiceMetadataProviderName);

        }
        /// <summary>
        /// Obtiene info del proveedor de metadata
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        public Fwk.ConfigSection.MetadataProvider GetProviderInfo(string providerName)
        {
            throw new NotImplementedException();
            //return wFwkRemoteObject.GetProviderInfo(providerName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DispatcherInfo RetriveDispatcherInfo()
        {
            throw new NotImplementedException();
            //return wFwkRemoteObject.RetriveDispatcherInfo();

        }
        #endregion [ServiceConfiguration]

        const int factorSize = 5;
        void InitHost()
        {
            if (binding == null)
            {
                //El tamaño de los mensajes que se pueden recibir durante la conexión a los servicios mediante BasicHttpBinding
                this.binding = new NetTcpBinding();

                binding.Name = "tcp";
                binding.MaxReceivedMessageSize *= factorSize;
                binding.MaxBufferSize *= factorSize;
                binding.MaxBufferPoolSize *= factorSize;
                binding.ReaderQuotas.MaxStringContentLength = 2147483647;
                binding.ReaderQuotas.MaxArrayLength = 2147483647;
                binding.ReaderQuotas.MaxBytesPerRead = 2147483647;
                address = new EndpointAddress(_URL);
            }
        }



        public string CheckServiceAvailability()
        {
            throw new NotImplementedException();
        }
    }
}
