using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Fwk.ConfigSection;
using System.Configuration;
using Fwk.Exceptions;
using System.IO;
using Fwk.Logging;

namespace Fwk.ServiceManagement
{
    /// <summary>
    /// Realiza operaciones CRUD y busquedas de la metadata de servicios
    /// </summary>
    public class ServiceMetadata
    {
        static ServiceProviderSection _ProviderSection;

        /// <summary>
        /// Seccion de metadata .-
        /// </summary>
        public static ServiceProviderSection ProviderSection
        {
            get
            {
                return _ProviderSection;
            }
        }

        /// <summary>
        /// Diccionario de providers de metadatas de servicios. Continen lista de <see cref="ServiceConfigurationCollection"/> 
        /// </summary>
        static System.Collections.Generic.Dictionary<string, ServiceConfigurationCollection> _Repository;

        /// <summary>
        /// Constructor estatico . Inicializa la sección FwkServiceMetadata
        /// </summary>
        static ServiceMetadata()
        {
            TechnicalException te;
            try
            {
                _ProviderSection = ConfigurationManager.GetSection("FwkServiceMetadata") as ServiceProviderSection;

                if (_ProviderSection == null)
                {
                    te = new TechnicalException("No se puede cargar el proveedor de configuracion de Metadata de servicios del framework fwk, verifique si existe la seccion [FwkServiceMetadata] en el archivo de configuracion.");
                    te.ErrorId = "7000";
                    te.Namespace = "Fwk.ServiceManagement";
                    te.Class = "Fwk.Configuration.ServiceManagement [static constructor --> ServiceMetadata()]";
                    te.UserName = Environment.UserName;
                    te.Machine = Environment.MachineName;
                    te.Source = ConfigurationsHelper.HostApplicationName;

                    throw te;
                }
            }
            catch (System.Exception ex)
            {
                te = new TechnicalException("No se puede cargar el proveedor de configuracion de Metadata de servicios del framework fwk, verifique si existe la seccion [FwkServiceMetadata] en el archivo de configuracion.",ex);
                te.ErrorId = "7000";
                te.Namespace = "Fwk.ServiceManagement";
                te.Class = "Fwk.Configuration.ServiceManagement [static constructor --> ServiceMetadata()]";
                te.UserName = Environment.UserName;
                te.Machine = Environment.MachineName;
                te.Source = ConfigurationsHelper.HostApplicationName;

                throw te;

            }


            if (_Repository == null)
            {
                _Repository = new Dictionary<string, ServiceConfigurationCollection>();
            }
        }

        /// <summary>
        /// Obtine un servicio del repositorio
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <param name="serviceName">Nombre del servicio</param>
        /// <returns></returns>
        public static ServiceConfiguration GetServiceConfiguration(string providerName, string serviceName)
        {
            ServiceConfiguration svc = null;
            ServiceProviderElement provider = GetProvider(providerName);

            ServiceConfigurationCollection svcList = GetAllServices(provider);
            svc = svcList.GetServiceConfiguration(serviceName, provider.ApplicationId);


            if (svc == null)
            {
                Exceptions.TechnicalException te = new Exceptions.TechnicalException(
                    string.Format("El servicio {0} no se encuentra configurado.\r\nProveedor de Metadata: {1}\r\nApplicationId: {2}\r\n", serviceName,provider.Name, provider.ApplicationId));
                te.ErrorId = "7002";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<ServiceMetadata>(te);
                throw te;
            }

            return svc;

        }
        ///date:2013-03-02 No se utilizara la actualizacion
        //private static FileSystemWatcher watcher;

        /// <summary>
        /// Obtiene todos los servicios del proveedor de metadata
        /// </summary>
        /// <param name="provider">Proveedor de la metadata</param>
        /// <returns></returns>
        public static ServiceConfigurationCollection GetAllServices(ServiceProviderElement provider)
        {
            ServiceConfigurationCollection svcList = null;

            //Si no esta cargado el provider en el repositorio
            if (!_Repository.ContainsKey(provider.Name))
            {
                #region xml

                ///date:2013-03-02 No se utilizara la actualizacion
                if (provider.ProviderType == ServiceProviderType.xml)
                //{
                    svcList = XmlServiceConfigurationManager.GetAllServices(provider.SourceInfo);

                //    //Habilito FileSystemWatcher para detectar cualquie cambio sobre la metadata
                //    watcher = new System.IO.FileSystemWatcher();
                //    watcher.Filter = provider.SourceInfo;

                //    watcher.Path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location;
                //    watcher.EnableRaisingEvents = true;

                //    watcher.Changed += new FileSystemEventHandler(watcher_Changed);

                //}
                #endregion

                #region sqldatabase
                if (provider.ProviderType == ServiceProviderType.sqldatabase)
                {
                    svcList = DatabaseServiceConfigurationManager.GetAllServices(provider.ApplicationId, provider.SourceInfo);
                }
                #endregion
                try
                {
                    ///Se agrega try cath debido a que un subproseso pueda intentar agregar un item y aexistente
                    _Repository.Add(provider.Name, svcList);
                }
                catch (Exception )
                { }
            }
            else
                svcList = _Repository[provider.Name];

            return svcList;
        }

        ///date:2013-03-02 No se utilizara la actualizacion
        ///// <summary>
        ///// Si algun cambio ocurre en el archivo de metadata de algun proveedor xml
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //static void watcher_Changed(object sender, FileSystemEventArgs e)
        //{
        //    try
        //    {
        //        //Busco todos los providers que esten asociados al mismo archivo. Esta es una situacion muy rara pero podria darce
        //        foreach (ServiceProviderElement provider in _ProviderSection.Providers)
        //        {
        //            if (e.Name.Equals(provider.SourceInfo) && provider.ProviderType == ServiceProviderType.xml)
        //                ReloadAllServices(provider);
        //        }
        //    }
        //    catch (TechnicalException ex)
        //    {
        //        Fwk.Logging.Event ev = new Event();
        //        ev.LogType = EventType.Error;
        //        ev.Machine = ex.Machine;
        //        ev.User = ex.UserName;
        //        String str = string.Concat(
        //            "Se intento modificar la metadata de servicios y se arrojó el siguiente error \r\n",
        //            Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex),
        //            "\r\n la metadata se encuentra en: \r\n",
        //            e.FullPath);

        //        ev.Message.Text = str;

        //        Fwk.Logging.StaticLogger.Log(Fwk.Logging.Targets.TargetType.WindowsEvent, ev, null, null);

        //    }
        //}

        /// <summary>
        /// Este metodo elimina quita la lista de servicios del provider en el repositorio deservicios y 
        /// los vuelve a cargar desde su origen
        /// </summary>
        /// <param name="provider">Proveedor de metadata</param>
        static void ReloadAllServices(ServiceProviderElement provider)
        {
             ///date:2013-03-02 No se utilizara la actualizacion
            //_Repository.Remove(provider.Name);

            if (provider.ProviderType == ServiceProviderType.xml)
            {
                ServiceConfigurationCollection svcList = XmlServiceConfigurationManager.GetAllServices(provider.SourceInfo);

                //    Habilito FileSystemWatcher para detectar cualquie cambio sobre la metadata
                //watcher = new System.IO.FileSystemWatcher();
                //watcher.Filter = provider.SourceInfo;
                //watcher.Path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                //watcher.EnableRaisingEvents = true;

                //watcher.Changed += new FileSystemEventHandler(watcher_Changed);

            }


        }

        /// <summary>
        /// 
        /// </summary>
        public static void RefreshServices()
        {
            ServiceConfigurationCollection svcList = null;
            foreach (ServiceProviderElement provider in _ProviderSection.Providers)
            {
                _Repository.Remove(provider.Name);
                if (provider.ProviderType == ServiceProviderType.xml)
                {
                    svcList = XmlServiceConfigurationManager.GetAllServices(provider.SourceInfo);
                }
                if (provider.ProviderType == ServiceProviderType.sqldatabase)
                {
                    svcList = DatabaseServiceConfigurationManager.GetAllServices(provider.ApplicationId, provider.SourceInfo);
                }

                try
                {
                    //Se agrega try cath debido a que un subproseso pueda intentar agregar un item y aexistente
                    _Repository.Add(provider.Name, svcList);
                }
                catch (Exception)
                { }
            }


        }
        /// <summary>
        /// Obtiene una lista de metadata de servicios 
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        public static ServiceConfigurationCollection GetAllServices(string providerName)
        {
            ServiceProviderElement provider = GetProvider(providerName);

            return GetAllServices(provider);

        }

        /// <summary>
        /// Actualiza la metadata de un servicio <see cref="ServiceConfiguration"/>
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <param name="serviceName">Nombre del servicio</param>
        /// <param name="pServiceConfiguration"><see cref="ServiceConfiguration"/></param>
        public static void SetServiceConfiguration(string providerName, string serviceName, ServiceConfiguration pServiceConfiguration)
        {

            ServiceProviderElement provider = GetProvider(providerName);

            ServiceConfigurationCollection svcList = GetAllServices(provider);
            if (!svcList.Exists(serviceName, provider.ApplicationId))
            {
                Exceptions.TechnicalException te = new Exceptions.TechnicalException(string.Format("El servicio {0} no se encuentra configurado.\r\nProveedor de Metadata: {1}\r\nApplicationId: {2}\r\n",serviceName, provider.Name, provider.ApplicationId));
                te.ErrorId = "7002";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<ServiceMetadata>(te);

                throw te;
            }

            ServiceConfiguration wServiceConfigurationEnMemoria = svcList.GetServiceConfiguration(serviceName, provider.ApplicationId);
            svcList.Remove(wServiceConfigurationEnMemoria);
            svcList.Add(pServiceConfiguration);

            if (provider.ProviderType == ServiceProviderType.xml)
                XmlServiceConfigurationManager.SetServiceConfiguration(provider.SourceInfo, svcList);
            else
                DatabaseServiceConfigurationManager.SetServiceConfiguration(serviceName, pServiceConfiguration, provider.ApplicationId, provider.SourceInfo);
        }

        /// <summary>
        /// Crea un servicio en el origen de datos indicado por el proveedor
        /// El aaplication Id que se utiliza es el del  nuevo servicio. Si el provedor estra configurado para usar uno determinado este se ignora
        /// de esta manera un proveedor puede insertar servicios para diferentes aplicaciones
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <param name="pServiceConfiguration"><see cref="ServiceConfiguration"/></param>
        public static void AddServiceConfiguration(string providerName, ServiceConfiguration pServiceConfiguration)
        {
            ServiceProviderElement provider = GetProvider(providerName);

            ServiceConfigurationCollection svcList = GetAllServices(provider);

            if (svcList.Exists(pServiceConfiguration.Name, pServiceConfiguration.ApplicationId))
            {
                Exceptions.TechnicalException te = new Exceptions.TechnicalException(string.Format("El servicio {0} ya existe.\r\nProveedor de Metadata: {1}\r\nApplicationId: {2}\r\n", pServiceConfiguration.Name, provider.Name, provider.ApplicationId));
                te.ErrorId = "7002";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<ServiceMetadata>(te);
                throw te;
            }



            svcList.Add(pServiceConfiguration);

            if (provider.ProviderType == ServiceProviderType.xml)
                XmlServiceConfigurationManager.AddServiceConfiguration(pServiceConfiguration, provider.SourceInfo, svcList);
            else
                DatabaseServiceConfigurationManager.AddServiceConfiguration(pServiceConfiguration, pServiceConfiguration.ApplicationId, provider.SourceInfo);
        }

        /// <summary>
        /// Elimina un seriovicio del repositorio y del origen de metadata de servicios.-
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <param name="serviceName">Nombre del servicio</param>
        public static void DeleteServiceConfiguration(string providerName, string serviceName)
        {

            ServiceProviderElement provider = GetProvider(providerName);

            ServiceConfigurationCollection svcList = GetAllServices(provider);
            if (!svcList.Exists(serviceName, provider.ApplicationId))
            {
                Exceptions.TechnicalException te = new Exceptions.TechnicalException(string.Format("El servicio {0} no se encuentra configurado.\r\nProveedor de Metadata: {1}\r\nApplicationId: {2}\r\n", serviceName, provider.Name, provider.ApplicationId));
                te.ErrorId = "7002";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<ServiceMetadata>(te);

                throw te;
            }
            ServiceConfiguration wServiceConfigurationEnMemoria = svcList.GetServiceConfiguration(serviceName, provider.ApplicationId);
            svcList.Remove(wServiceConfigurationEnMemoria);

            if (provider.ProviderType == ServiceProviderType.xml)
                XmlServiceConfigurationManager.DeleteServiceConfiguration(provider.SourceInfo, svcList);
            else
                DatabaseServiceConfigurationManager.DeleteServiceConfiguration(serviceName, provider.ApplicationId, provider.SourceInfo);

        }

        /// <summary>
        /// Obtiene una lista de todas las aplicaciones configuradas en el origen de datos configurado por el 
        /// proveedor
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        public static List<String> GetAllApplicationsId(string providerName)
        {
            ServiceProviderElement provider = GetProvider(providerName);

            ServiceConfigurationCollection svcList = GetAllServices(provider);

            IEnumerable<string> llist = from s in svcList
                                        where s.ApplicationId != null
                                        group s by s.ApplicationId into g
                                        select g.Key;

            return llist.ToList<string>();

        }

        /// <summary>
        /// Metodo privado que obtioene un proveedor . Si [providerName] es nulo se retornara el proveedor por defecto.-
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        static ServiceProviderElement GetProvider(string providerName)
        {
            ServiceProviderElement provider = _ProviderSection.GetProvider(providerName);

            CheckProvider(providerName,provider);

            if (string.IsNullOrEmpty(provider.SourceInfo))
            {
                System.Text.StringBuilder wMessage = new StringBuilder();
                wMessage.Append("Error al inicializar la metadata de los servicios  \r\n");
                wMessage.Append("El atributo SourceInfo no puede estar vasio.  \r\n");
                wMessage.AppendLine("Verifique el archivo de configuración en la sección FwkServiceMetadata el ");
                wMessage.AppendLine("atributo [type] y [SourceInfo]  posibles :");
                wMessage.AppendLine("Si tipo es XML espesifique nombre de archivo  ");
                wMessage.AppendLine("Si tipo es sqldatabase  espesifique nombre de connetionstring \r\n");


                TechnicalException te = new TechnicalException(wMessage.ToString());
                te.ErrorId = "7004";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<ServiceMetadata>(te);

                throw te;

            }

            return provider;
        }


        /// <summary>
        /// Completa el error del que va dentro del Request con informacion de :
        /// Assembly, Class, Namespace, UserName,  InnerException, etc
        /// </summary>
        /// <param name="pMessage">Mensaje personalizado</param>
        /// <param name="pErrorId">Id del Error</param>
        /// <param name="pException">Alguna Exception que se quiera incluir</param>
        /// <date>2007-08-07T00:00:00</date>
        /// <author>moviedo</author> 
        static TechnicalException GetTechnicalException(String pMessage, String pErrorId, Exception pException)
        {
            TechnicalException te = new TechnicalException(pMessage, pException);

            te.ErrorId = pErrorId;
            te.Assembly = "Fwk.Bases";
            te.Class = "ServiceMetadata";
            te.Namespace = "Fwk.ServiceManagement";

            //te.UserName = Environment.UserName;
            te.Machine = Environment.MachineName;

            if (string.IsNullOrEmpty(ConfigurationsHelper.HostApplicationName))
                te.Source = string.Concat("Despachador de servicios en " , Environment.MachineName);
            else
                te.Source = ConfigurationsHelper.HostApplicationName;

            return te;
        }

        /// <summary>
        /// Determina si el proveedor solicitado existe o no. para lanzar una exepcion en caso de que no exista.
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="provider"></param>
        internal static void CheckProvider(string providerName, ServiceProviderElement provider)
        {
            if (provider == null)
                if (string.IsNullOrEmpty(providerName))
                    throw GetTechnicalException(string.Format(Fwk.Bases.Properties.Resources.ServiceManagement_MetadataProviderNotFound, "por defecto"), "7201", null);
                else
                    throw GetTechnicalException(string.Format(Fwk.Bases.Properties.Resources.ServiceManagement_MetadataProviderNotFound, providerName), "7201", null);

        }
    }
}
