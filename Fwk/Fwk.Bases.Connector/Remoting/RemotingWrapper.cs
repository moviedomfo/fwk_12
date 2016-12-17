using System;
using System.Collections.Generic;
using System.Text;
using Fwk.Bases;
using Fwk.Exceptions;
using System.Runtime.Remoting;
using Fwk.Remoting;
using Fwk.BusinessFacades.Utils;
using Fwk.ConfigSection;
using Fwk.Bases.ISVC;
using System.Xml;

namespace Fwk.Bases.Connector
{
    /// <summary>
    /// Wrapper espesializado para una conexión a travez de RemotingConfiguration
    /// </summary>
    [Serializable]
    public class RemotingWrapper :IServiceWrapper
    {
        string remotingUrl;
        internal string RemotingUrl { get {return  remotingUrl; } }
        string _ProviderName;

        /// <summary>
        /// Proveedor del wrapper. Este valor debe coincidir con un proveedor de metadata en el dispatcher
        /// </summary>
        public string ProviderName
        {
            get { return _ProviderName; }
            set { _ProviderName = value; }
        }
        string _SourceInfo;

        /// <summary>
        /// Archivo de configuracion de remoting
        /// </summary>
        public string SourceInfo
        {
            get { return _SourceInfo; }
            set { _SourceInfo = value; }
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
            throw new Exception("The method or operation is not implemented in remoting execution. It's obsolete");
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

            FwkRemoteObject wFwkRemoteObject = CreateRemoteObject();
            TResponse response ;
            try
            {
                req.InitializeHostContextInformation();
                response = (TResponse)wFwkRemoteObject.ExecuteService(_ServiceMetadataProviderName, req);
                response.InitializeHostContextInformation();
            }
            catch (Exception ex)
            {
                
                    response  = new TResponse();
                response.Error = ProcessConnectionsException.Process(ex, "");
            }


            return response;


        }

        ///// <summary>
        ///// Ejecucion del servicio
        ///// </summary>
        ///// <typeparam name="TRequest"></typeparam>
        ///// <typeparam name="TResponse"></typeparam>
        ///// <param name="pReq"></param>
        ///// <returns></returns>
        //public TResponse ExecuteService<TRequest, TResponse>(TRequest pReq)
        //    where TRequest : IServiceContract
        //    where TResponse : IServiceContract, new()
        //{
        //    FwkRemoteObject wFwkRemoteObject = CreateRemoteObject();

        //    pReq.InitializeHostContextInformation();
        //    TResponse response = (TResponse)wFwkRemoteObject.ExecuteService(_ProviderName, pReq);
        //    response.InitializeHostContextInformation();

        //    return response;
        //}



        #endregion
        /// <summary>
        /// Chequea la disponibilidad del despachador de servicio
        /// </summary>
        /// <returns>Mensaje en caso de que el servicio no esté disponible</returns>
        /// <summary>
        /// Chequea si un Dispatcher esta activo
        /// </summary>
        /// <returns></returns>
        public DispatcherInfoBE CheckServiceAvailability(bool includeCnnstSrings=false, bool includeAppSettings=false, bool includeMetadata=false)
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
        /// <summary>
        /// Objeto de interbloqueo concurrente
        /// </summary>
        protected static readonly object singletonLock = new object();
        bool isConfigured = false;
        private  string GetApplicationURL()
        {
            //Seccion protegida por la posibilidad de multiples procesos intentar levantar la configuracion
            lock (singletonLock)
            {
                if (string.IsNullOrEmpty(remotingUrl))
                {
                    string sourceInfoxml = Fwk.HelperFunctions.FileFunctions.OpenTextFile(_SourceInfo);

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(sourceInfoxml);
                    XmlNode element = doc.SelectSingleNode("/configuration/system.runtime.remoting/application/client/wellknown");
                    remotingUrl = element.Attributes["url"].Value;
                }
                if (isConfigured == false)
                {
                    try
                    {
                        RemotingConfiguration.Configure(_SourceInfo, false);
                        isConfigured = true;
                    }
                    catch (System.Runtime.Remoting.RemotingException)//Ya se ha registrado el canal 'tcp'.\r\n   en 
                    {
                        isConfigured = true;
                    }
                }
                WellKnownClientTypeEntry entry = null;

                foreach (WellKnownClientTypeEntry temp in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
                {
                    if (temp.TypeName.Equals(typeof(FwkRemoteObject).FullName) && remotingUrl.CompareTo(remotingUrl)==0)
                    {
                        entry = temp;
                        //if (string.IsNullOrEmpty(remotingUrl))
                        //    remotingUrl = entry.ObjectUrl;
                        break;
                    }
                }

                if (entry == null)
                    throw new ArgumentException(String.Format("No se encuentra el tipo de objeto remoto {0} configurado.", typeof(FwkRemoteObject).FullName));

                return entry.ObjectUrl;

                
            }
        }

        public bool RemotingWrapperExist()
        {
            foreach (var w in WrapperFactory.GetPepository())
            {
                if (w.Value.GetType().Name == typeof(RemotingWrapper).Name)
                {
                    RemotingWrapper rw = (RemotingWrapper)w.Value;
                    if (rw.RemotingUrl == this.remotingUrl)
                        return true;
                }
            }
            return false;


        }


        Boolean checkIfChannelIsConfigured()
        {
            //Si la bandera ya esta en true simplemente retornarla
            if (isConfigured) return isConfigured;
            
            foreach (WellKnownClientTypeEntry temp in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
            {
                if (temp.TypeName.Equals(typeof(FwkRemoteObject).FullName) && temp.ObjectUrl == "OBTENER URL RPOXIMO FIX")
                {
                    isConfigured= true;
                    break;
                }
            }
            return isConfigured;
        }
		

        /// <summary>
        /// Crea en este caso SimpleFacaddeRemoteObject .-
        /// </summary>
        /// <returns>Instancia de SimpleFacaddeRemoteObject</returns>
        private  FwkRemoteObject CreateRemoteObject()
		{
            string url = GetApplicationURL();
            Fwk.Remoting.FwkRemoteObject _remoteInformation = (Fwk.Remoting.FwkRemoteObject)Activator.GetObject(typeof(Fwk.Remoting.FwkRemoteObject), url);
            return _remoteInformation; 
            //Carga la configuracion de remoting en el archivo indicado por RemotingConfigFile en _SourceInfo
            //if (!IsConfigured())
            //{
            //    if (System.IO.File.Exists(_SourceInfo)==false  )
            //        throw new Exception("No existe el archivo de configuración de remoting del lado del cliente.\r\nRevice la configuracion del Wrapper " + _ProviderName);
            //    //Si no se encuentra algun nombre de archivo en el App.config
            //    if (_SourceInfo == string.Empty)
            //    {
            //        throw new Exception("No hay ruta especificada para el archivo de configuración.\r\nRevice la configuracion del Wrapper " + _ProviderName);
            //    }
            //    else
            //    {
            //        RemotingConfiguration.Configure(_SourceInfo, false);
            //    }
            //}

            //FwkRemoteObject wFwkRemoteObject = new FwkRemoteObject();
            //return wFwkRemoteObject;
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
            FwkRemoteObject wFwkRemoteObject = CreateRemoteObject();

            return wFwkRemoteObject.GetServicesList(_ServiceMetadataProviderName);
          
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
            FwkRemoteObject wFwkRemoteObject = CreateRemoteObject();
            return wFwkRemoteObject.GetServiceConfiguration(_ServiceMetadataProviderName, pServiceName);
           
        }

        /// <summary>
        /// Actualiza la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2008-04-10T00:00:00</date>
        /// <author>moviedo</author>
        public void SetServiceConfiguration(string pServiceName,ServiceConfiguration pServiceConfiguration)
        {
            FwkRemoteObject wFwkRemoteObject = CreateRemoteObject();
            wFwkRemoteObject.SetServiceConfiguration(_ServiceMetadataProviderName, pServiceName, pServiceConfiguration);
        }

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration)
        {
            FwkRemoteObject wFwkRemoteObject = CreateRemoteObject();
            wFwkRemoteObject.AddServiceConfiguration(_ServiceMetadataProviderName, pServiceConfiguration);
        }

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void DeleteServiceConfiguration(String pServiceName)
        {
            FwkRemoteObject wFwkRemoteObject = CreateRemoteObject();
            wFwkRemoteObject.DeleteServiceConfiguration(_ServiceMetadataProviderName, pServiceName);
        }
        
        /// <summary>
        /// Obtiene una lista de todas las aplicaciones configuradas en el origen de datos configurado por el 
        /// proveedor
        /// </summary>
        /// <returns></returns>
        public  List<String> GetAllApplicationsId()
        {
            FwkRemoteObject wFwkRemoteObject = CreateRemoteObject();
            return wFwkRemoteObject.GetAllApplicationsId(_ServiceMetadataProviderName);
            
        }
        /// <summary>
        /// Obtiene info del proveedor de metadata
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        public Fwk.ConfigSection.MetadataProvider GetProviderInfo(string providerName)
        {
            FwkRemoteObject wFwkRemoteObject = CreateRemoteObject();
            return wFwkRemoteObject.GetProviderInfo(providerName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DispatcherInfo RetriveDispatcherInfo()
        {
            FwkRemoteObject wFwkRemoteObject = CreateRemoteObject();
            return wFwkRemoteObject.RetriveDispatcherInfo();
           
        }
        #endregion [ServiceConfiguration]

        
    }

//    <configuration>
//  <system.runtime.remoting>
//    <application>
//      <client>
//        <wellknown type="Fwk.Remoting.FwkRemoteObject, Fwk.Bases" url="tcp://localhost:7070/Fwk.Remoting.rem"/>
//      </client>
//      <channels>
//        <channel ref="tcp" port="0">
//          <serverProviders>
//            <provider ref="wsdl" />
//            <formatter ref="soap" typeFilterLevel="Full" />
//            <formatter ref="binary" typeFilterLevel="Full" />
//          </serverProviders>
//        </channel>
//      </channels>
//    </application>
//    <customErrors mode="off" />
//  </system.runtime.remoting>
//</configuration>


    
}
