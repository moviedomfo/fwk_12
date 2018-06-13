using System;
using System.Collections.Generic;
using System.Text;
using Fwk.BusinessFacades;
using Fwk.Bases;
using System.Diagnostics;
using Fwk.BusinessFacades.Utils;
using System.Web;
using System.Configuration;

namespace Fwk.Remoting
{
    /// <summary>
    /// Clase remota que se ejecuta en el servicio remoting dispatcher
    /// </summary>
    public class FwkRemoteObject : MarshalByRefObject
    {
        SimpleFacade _SimpleFacade = new SimpleFacade();
        /// <summary>
        /// Ejecuta un servicio 
        /// </summary>
        /// <param name="providerName">Proveedor de metadata</param>
        /// <param name="pReq">Interfaz de contrato de servicio.- interfaz que implementan todos los request y responsees</param>
        /// <returns><see cref="IServiceContract"/></returns>
        public IServiceContract ExecuteService(string providerName, IServiceContract pReq)
        {
            
            Console.WriteLine("Executing " + pReq.ServiceName + " " + DateTime.Now.ToString());
            Console.WriteLine("--------Client IP  " + pReq.ContextInformation.HostIp + " Client Name" + pReq.ContextInformation.HostName);
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            IServiceContract wRsponse = wSimpleFacade.ExecuteService(providerName, pReq);
            return wRsponse;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="pReq"></param>
        /// <returns></returns>
        public IServiceContract ExecuteService_AutnToken(string providerName,  IServiceContract pReq)
        {
            Console.WriteLine("Executing " + pReq.ServiceName + " " + DateTime.Now.ToString());
            Console.WriteLine("--------Client IP  " + pReq.ContextInformation.HostIp + " Client Name" + pReq.ContextInformation.HostName);
            

             SimpleFacade wSimpleFacade = CreateSimpleFacade();
            return this.ExecuteService(providerName, pReq);
        }
   

        /// <summary>
        /// Chequea la disponibilidad del despachador de servicio
        /// </summary>
        /// <returns>Mensaje en caso de que el servicio no esté disponible</returns>
        public string CheckServiceAvailability()
        {
            Console.WriteLine("Executing CheckServiceAvailability " + DateTime.Now.ToString());
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            return wSimpleFacade.CheckServiceAvailability();
        }
        /// <summary>
        /// Obtiene la metadata de un servicio 
        /// </summary>
        /// <param name="providerName">Proveedor de metadata</param>
        /// <param name="pServiceName">Nombre del servicio</param>
        /// <returns><see cref="ServiceConfiguration"/></returns>
        public ServiceConfiguration GetServiceConfiguration(string providerName, string pServiceName)
        {
            Console.WriteLine("Executing GetServiceConfiguration " + DateTime.Now.ToString());
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            String xmlServices = _SimpleFacade.GetServiceConfiguration(providerName, pServiceName);
            return ServiceConfiguration.GetServiceConfigurationFromXml(xmlServices);

        }

        /// <summary>
        /// Obtiene una lista de servicios
        /// </summary>
        /// <param name="providerName">Proveedor de metadata</param>
        /// <returns></returns>
        public ServiceConfigurationCollection GetServicesList(string providerName)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();

            String xmlServices = wSimpleFacade.GetServicesList(providerName, true);
            ServiceConfigurationCollection wServiceConfigurationCollection = (ServiceConfigurationCollection)
                Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(ServiceConfigurationCollection), xmlServices);

            return wServiceConfigurationCollection;


        }

        /// <summary>
        /// Actualiza la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="providerName">Proveedor de metadata</param>
        /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2006-02-10T00:00:00</date>
        /// <author>moviedo</author>
        public void SetServiceConfiguration(string providerName, String pServiceName, ServiceConfiguration pServiceConfiguration)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            wSimpleFacade.SetServiceConfiguration(providerName, pServiceName, pServiceConfiguration);
        }

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="providerName">Proveedor de metadata</param>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2006-02-13T00:00:00</date>
        /// <author>moviedo</author>
        public void AddServiceConfiguration(string providerName, ServiceConfiguration pServiceConfiguration)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            wSimpleFacade.AddServiceConfiguration(providerName, pServiceConfiguration);
        }

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="providerName">Proveedor de metadata</param>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <date>2006-02-13T00:00:00</date>
        /// <author>moviedo</author>
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
        /// <returns></returns>
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
        public Fwk.ConfigSection.MetadataProvider GetProviderInfo(string providerName)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            return wSimpleFacade.GetProviderInfo(providerName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
    }
}
