using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using Fwk.BusinessFacades;
using Fwk.Bases;
using System.Collections.Generic;
using Fwk.ConfigSection;
using Fwk.BusinessFacades.Utils;
using System.Web.Script.Services;
using Fwk.Bases.Blocks.Fwk.BusinessFacades;
using Health.Svc;



namespace WebServiceDispatcher
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SingleService : System.Web.Services.WebService
    {
        HostContext hostContext = null;
        SimpleFacade _SimpleFacade;
        public SingleService()
        {
            ConfigurationsHelper.HostApplicationName = "Fwk web service";
            //Uncomment the following line if using designed components 
            //InitializeComponent(); 

            String msg_log = String.Format("El servicio {0} se ah detenido ", ConfigurationsHelper.HostApplicationName);
        }

        /// <summary>
        /// Ejecuta un service de negocio.
        /// </summary>
        ///<param name="providerName">Proveedor de metadata. Este parametro lo establece el cliente desde su configuracion de wrapper</param>
        /// <param name="pServiceName">Nombre del service.</param>
        /// <param name="pData">XML con datos de entrada para la ejecución del servicio.</param>
        /// <returns>XML con datos de salida del servicio.</returns>
        [WebMethod]
        public string ExecuteService(string providerName, string pServiceName, string pData)
        {

            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            string wResult = wSimpleFacade.ExecuteService(providerName, pServiceName, pData);
            return wResult;
        }

        [WebMethod]
        public void ExecuteServiceJsonp(string providerName, string serviceName, string jsonRequets, string callback)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();

            string jsonRes = wSimpleFacade.ExecuteServiceJson_newtonjs(providerName, serviceName, jsonRequets, CreateHostContext());
            Context.Response.Write(string.Concat(callback, "(", jsonRes, ")"));
        }

        [WebMethod]
        public void EjecutarTest(string providerName, string serviceName, string jsonRequets, string callback)
        {
            #region solo para test simple
            RetrivePatientsService svc = new RetrivePatientsService();
            Health.Isvc.RetrivePatients.RetrivePatientsRes res = svc.Execute(new Health.Isvc.RetrivePatients.RetrivePatientsReq());
            string jsonRes = Fwk.HelperFunctions.SerializationFunctions.SerializeObjectToJson_Newtonsoft(typeof(Health.Isvc.RetrivePatients.RetrivePatientsReq), res);
         
            Context.Response.Write(string.Concat(callback, "(", jsonRes, ")"));
            #endregion
        }
       

       
       

        /// <summary>
        /// 
        /// </summary>
        ///<param name="providerName">Proveedor de metadata. Este parametro lo establece el cliente desde su configuracion de wrapper</param>
        /// <param name="pServiceName"></param>
        /// <param name="pData"></param>
        [SoapDocumentMethod(OneWay = true)]
        [WebMethod]
        public void ExecuteService_OneWay(string providerName, string pServiceName, string pData)
        {

            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            wSimpleFacade.ExecuteService(providerName, pServiceName, pData);

        }
        /// <summary>
        /// Ejecuta un service de negocio.
        /// </summary>
        ///<param name="providerName">Proveedor de metadata. Este parametro lo establece el cliente desde su configuracion de wrapper</param>
        /// <param name="serviceName">Nombre del service.</param>
        /// <returns>Detalle informativo del servicio.</returns>
        [WebMethod]
        public string GetServiceConfiguration(string providerName, string serviceName)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            return wSimpleFacade.GetServiceConfiguration(providerName, serviceName);
        }

        /// <summary>
        ///  Lista los servicios configurados
        /// </summary>
        ///<param name="providerName">Proveedor de metadata. Este parametro lo establece el cliente desde su configuracion de wrapper</param>
        /// <param name="ViewAsXml">Permite ver como xml todos los servicios y sus datos.
        /// Si se espesifuca false solo se vera una simple lista</param>
        /// <returns>Lista de servicios configurados</returns>
        [WebMethod]
        public string GetServicesList(string providerName, Boolean ViewAsXml)
        {

            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            return wSimpleFacade.GetServicesList(providerName, ViewAsXml);

        }

        /// <summary>
        /// Actualiza la configuración de un servicio de negocio.
        /// </summary>
        ///<param name="providerName">Proveedor de metadata. Este parametro lo establece el cliente desde su configuracion de wrapper</param>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
        /// <date>2006-02-10T00:00:00</date>
        /// <author>moviedo</author>
        [WebMethod]
        public void SetServiceConfiguration(string providerName, String pServiceName, ServiceConfiguration pServiceConfiguration)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            wSimpleFacade.SetServiceConfiguration(providerName, pServiceName, pServiceConfiguration);

        }

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        ///<param name="providerName">Proveedor de metadata. Este parametro lo establece el cliente desde su configuracion de wrapper</param>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2006-02-13T00:00:00</date>
        /// <author>moviedo</author>
        [WebMethod]
        public void AddServiceConfiguration(string providerName, ServiceConfiguration pServiceConfiguration)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            wSimpleFacade.AddServiceConfiguration(providerName, pServiceConfiguration);

        }

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        ///<param name="providerName">Proveedor de metadata. Este parametro lo establece el cliente desde su configuracion de wrapper</param>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <date>2006-02-13T00:00:00</date>
        /// <author>moviedo</author>
        [WebMethod]
        public void DeleteServiceConfiguration(string providerName, string pServiceName)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            wSimpleFacade.DeleteServiceConfiguration(providerName, pServiceName);

        }

        /// <summary>
        /// Obtiene una lista de todas las aplicaciones configuradas en el origen de datos configurado por el 
        /// proveedor
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        [WebMethod]
        public List<String> GetAllApplicationsId(string providerName)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            return wSimpleFacade.GetAllApplicationsId(providerName);

        }

        /// <summary>
        /// Obtiene info del proveedor de metadata
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        [WebMethod]
        public MetadataProvider GetProviderInfo(string providerName)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            return wSimpleFacade.GetProviderInfo(providerName);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public List<MetadataProvider> RetriveProviders()
        {

            return FacadeHelper.RetriveDispatcherInfo().MetadataProviders;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public Fwk.ConfigSection.DispatcherInfo RetriveDispatcherInfo()
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            return wSimpleFacade.RetriveDispatcherInfo();
        }
        /// <summary>
        /// Factory de SimpleFacade
        /// </summary>  
        /// <returns></returns>
        SimpleFacade CreateSimpleFacade()
        {
            if (_SimpleFacade == null)
                _SimpleFacade = new SimpleFacade();

            return _SimpleFacade;
        }

        HostContext CreateHostContext()
        {
            if (hostContext == null)
            {
                hostContext = new HostContext();

                hostContext.HostName = Environment.MachineName;
                hostContext.HostIp = Fwk.HelperFunctions.EnvironmentFunctions.GetMachineIp();
            }
            return  hostContext;
        }
    }

}