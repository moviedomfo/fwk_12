using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Fwk.Configuration.Common;
using Fwk.Bases.Properties;
using Fwk.HelperFunctions;
using Fwk.ConfigSection;
using Fwk.Exceptions;
using Fwk.Configuration.ISVC;

namespace Fwk.Configuration
{
    /// <summary>
    /// Clase que permite obtener informacion de un archivo de configuracion ubicado en un Dispatcher.
    /// Se recomienda utilizar este tipo de configuracion del lado de clientes win 32 o ervicios windows. Los cuales diponen 
    /// una configuracion see<ConfigProviderType></ConfigProviderType> de tipo servicewrapper que apunten a un Wrapper en el mismo .config
    /// Se utiliza el atributo provider SourceInfo del proveedor configurado para localizar un wrapper valido en el ciente que se utilizara para conectarce al Dispatcher
    /// que contiene dicha configuracion remota
    /// <remarks>
    /// NOTA: Es necesario para que funcione la configuracion tipo servicewrapper disponer del lado del servidor o dispatcher una configuracion de tipo Local (xml) o database 
    /// con el mismo nombre de proveedor .-
    /// Y en el cliente una configuracion Wrapper que apunte a dicho servidor o dispatcher.-
    /// </remarks>
    /// </summary>

    /// <Author>Marcelo Oviedo</Author>
    class ServiceConfigurationManager
    {
        /// <![CDATA[<ServiceConfiguration name="GetFwkConfigurationService">
        ///  <CreatedUserName>moviedo</CreatedUserName>
        /// <CreatedDateTime>2012-01-26T16:35:17.7223497-03:00</CreatedDateTime>
        /// <Description></Description>
        /// <Handler>Fwk.Configuration.SVC.GetFwkConfigurationService, Fwk.Bases, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null</Handler>
        /// <Request>Fwk.Configuration.ISVC.GetFwkConfigurationReq, Fwk.Bases, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null</Request>
        /// <Response>Fwk.Configuration.ISVC.GetFwkConfigurationRes, Fwk.Bases, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null</Response>
        /// <Available>true</Available>
        /// <Audit>false</Audit>
        /// <TransactionalBehaviour>Suppres</TransactionalBehaviour>
        /// <IsolationLevel>ReadCommitted</IsolationLevel>
        /// <Timeout>0</Timeout>
        /// <Cacheable>false</Cacheable>
        /// </ServiceConfiguration>]]>
        
        static ConfigurationRepository _Repository;

        static ServiceConfigurationManager()
        {
            if (_Repository == null)
            {
                _Repository = new ConfigurationRepository();
            }
        }



        /// <summary>
        /// Obtiene una propiedad determinada de un archivo de configuracion .-
        /// </summary>
        /// <param name="configProvider">Proveedor de configuuracion</param>
        /// <param name="pGroupName">Nombre del grupo donde se encuentra la propiedad</param>
        /// <param name="pPropertyName">Nombre de la propiedad a obtener</param>
        /// <returns>String con la propiedad</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static string GetProperty(string configProvider, string pGroupName, string pPropertyName)
        {
            string wBaseConfigFile = String.Empty;

            ConfigProviderElement provider = ConfigurationManager.GetProvider(configProvider);


            ConfigurationFile wConfigurationFile = GetConfig(provider);

          
            Group wGroup = wConfigurationFile.Groups.GetFirstByName(pGroupName);
            if (wGroup == null)
            {
                TechnicalException te = new TechnicalException(string.Concat(new String[] { "No se encuentra el grupo ", pGroupName, " en la de configuración: ", wBaseConfigFile }));
                te.ErrorId = "8006";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(LocalFileConfigurationManager));
                throw te;
            }
            Key wKey = wGroup.Keys.GetFirstByName(pPropertyName);
            if (wKey == null)
            {
                TechnicalException te = new TechnicalException(string.Concat(new String[] { "No se encuentra la propiedad ", pPropertyName, " en el grupo de propiedades: ", pGroupName, " en la de configuración: ", wBaseConfigFile }));
                te.ErrorId = "8007";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(LocalFileConfigurationManager));
                throw te;
            }

            return wKey.Value.Text;

        }

        /// <summary>
        /// Devuelve el contenido completo de un archivo de configuración
        /// dado el nombre de archivo.
        /// </summary>
        /// <param name="provider">Proveedor de configuración.</param>
        /// <returns>ConfigurationFile</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static ConfigurationFile GetConfigurationFile(ConfigProviderElement provider)
        {
            return GetConfig(provider);
        }



        /// <summary>
        /// Obtiene un grupo determinado en el archivo de configuracion
        /// </summary>
        /// <param name="configProvider">Proveedor de configuuracion</param>
        /// <param name="pGroupName"></param>
        /// <returns>Hashtable con los grupos contenidos en el archivo de configuracion</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static Group GetGroup(string configProvider, string pGroupName)
        {

            string wBaseConfigFile = string.Empty;

            ConfigProviderElement provider = ConfigurationManager.GetProvider(configProvider);


            ConfigurationFile wConfigurationFile = GetConfig(provider);

          

            Group wGroup = wConfigurationFile.Groups.GetFirstByName(pGroupName);
            if (wGroup == null)
            {


                TechnicalException te = new TechnicalException(string.Concat(new String[] { "No se encuentra el grupo [", pGroupName, "] en el archivo de configuración: ", wBaseConfigFile }));
                te.ErrorId = "8006";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(LocalFileConfigurationManager));
                throw te;
            }


            return wGroup;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        internal static void RemoveConfigManager(ConfigProviderElement provider)
        {

            ConfigurationFile wConfigurationFile = _Repository.GetConfigurationFile(provider.BaseConfigFile);
            _Repository.RemoveConfigurationFile(wConfigurationFile);

        }

        internal static bool ExistConfigurationFile(string pFileName)
        {
            return _Repository.ExistConfigurationFile(pFileName);
        }

        #region [Private members]

        /// <summary>
        /// Devuelve el contenido completo de un archivo de configuración
        /// dado el nombre de archivo.
        /// </summary>
        /// <param name="provider">Proveedor de configuración.</param>
        /// <returns>ConfigurationFile</returns>
        /// <Author>Marcelo Oviedo</Author>
        static ConfigurationFile GetConfig(ConfigProviderElement provider)
        {

            ConfigurationFile wConfigurationFile = _Repository.GetConfigurationFile(provider.Name);

            if (wConfigurationFile == null)
            {
                wConfigurationFile = SetConfigurationFile(provider);
                _Repository.AddConfigurationFile(wConfigurationFile);

            }
            return wConfigurationFile;

        }
 

        /// <summary>
        /// Busca la configuracion <see cref="ConfigurationFile"/> atravez de una llamada a un servicio fwk
        /// Este codigo se ejecuta del lado del clientes es decir en el Wrapper
        /// Del lado del servidor (dispatcher) debe existir una configuracion Xml o Database con el mismo nombre de provider que 
        /// realiza la llmada del cliente de tipo Service.
        /// Utiliza provider.SourceInfo para localizar un wrapper valido en el ciente que es e q se utilizara para conectarce al Dispatcher
        /// </summary>
        /// <param name="provider">Proveedor de configuración.</param>
        /// <Author>Marcelo Oviedo</Author>
        static ConfigurationFile SetConfigurationFile(ConfigProviderElement provider)
        {

            GetFwkConfigurationReq req = new GetFwkConfigurationReq();
            req.BusinessData.ConfigProviderName = provider.Name;

            GetFwkConfigurationRes res = req.ExecuteService<GetFwkConfigurationReq, GetFwkConfigurationRes>(provider.SourceInfo,req);


            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
            return res.BusinessData;

        }

     

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="key"></param>
        /// <param name="groupName">Nombre del gruop que contiene las propiedades</param>
        internal static void AddProperty(ConfigProviderElement provider, Key key, string groupName)
        {
            TechnicalException te = new TechnicalException(string.Concat("No esta nimplementada esta funcionalidad de ConfigurationMannager contra servicios ", provider.BaseConfigFile));
            te.ErrorId = "8008";
            Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(LocalFileConfigurationManager));
            throw te;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="group"></param>
        internal static void AddGroup(ConfigProviderElement provider, Group group)
        {
            TechnicalException te = new TechnicalException(string.Concat("No esta nimplementada esta funcionalidad de ConfigurationMannager contra servicios ", provider.BaseConfigFile));
            te.ErrorId = "8008";
            Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(LocalFileConfigurationManager));
            throw te;

        }

        /// <summary>
        /// Elimina una porpiedad de la cinfuguracion
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="groupName">Gupo al que pertenece la propiedad</param>
        /// <param name="propertyName">Nombre de la propiedad</param>
        internal static void RemoveProperty(ConfigProviderElement provider, string groupName, string propertyName)
        {
            
            TechnicalException te = new TechnicalException(string.Concat("No esta nimplementada esta funcionalidad de ConfigurationMannager contra servicios ", provider.BaseConfigFile));
            te.ErrorId = "8008";
            Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(LocalFileConfigurationManager));
            throw te;
        }

        /// <summary>
        /// Elimina un grupo de la configuracion
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="groupName">Nombre del grupo a eliminar</param>
        internal static void RemoveGroup(ConfigProviderElement provider, string groupName)
        {

            TechnicalException te = new TechnicalException(string.Concat("No esta nimplementada esta funcionalidad de ConfigurationMannager contra servicios ", provider.BaseConfigFile));
            te.ErrorId = "8008";
            Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(LocalFileConfigurationManager));
            throw te;
        }




        /// <summary>
        /// Cambia el nombre de un grupo.-
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="groupName">Nombre del grupo</param>
        /// <param name="newGroupName">Nuevo nombre del grupo</param>
        internal static void ChangeGroupName(ConfigProviderElement provider, string groupName, string newGroupName)
        {
            TechnicalException te = new TechnicalException(string.Concat("No esta nimplementada esta funcionalidad de ConfigurationMannager contra servicios ", provider.BaseConfigFile));
            te.ErrorId = "8008";
            Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(LocalFileConfigurationManager));
            throw te;
        }

        /// <summary>
        /// Realiza cambios a una propiedad.-
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="groupName">Nombre del grupo donde se encuentra la propiedad</param>
        /// <param name="property">Propiedad actualizada. Este objeto puede contener todos sus valores modifcados</param>
        /// <param name="propertyName">Nombre de la propiedad que se mofdifico.- Este valor es el original sin modificacion</param>
        internal static void ChangeProperty(ConfigProviderElement provider, string groupName, Key property, string propertyName)
        {
        
            TechnicalException te = new TechnicalException(string.Concat("No esta nimplementada esta funcionalidad de ConfigurationMannager contra servicios ", provider.BaseConfigFile));
            te.ErrorId = "8008";
            Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(LocalFileConfigurationManager));
            throw te;
        }

        /// <summary>
        /// Vuelve a cargar el archivo de configuracion desde el origen de datos
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <returns></returns>
        internal static ConfigurationFile RefreshConfigurationFile(ConfigProviderElement provider)
        {
            ConfigurationFile wConfigurationFile = _Repository.GetConfigurationFile(provider.Name);

            if (wConfigurationFile != null)
            {
                _Repository.RemoveConfigurationFile(wConfigurationFile);
                wConfigurationFile = null;
            }

            wConfigurationFile = SetConfigurationFile(provider);
            _Repository.AddConfigurationFile(wConfigurationFile);

            return wConfigurationFile;
        }
    }



}
