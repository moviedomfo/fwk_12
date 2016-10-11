using System;
using System.Collections;
using Fwk.Configuration.Common;
using Fwk.Bases.Properties;
using Fwk.ConfigSection;
using Fwk.Exceptions;
using Fwk.Bases;

namespace Fwk.Configuration
{
	/// <summary>
	/// Clase principal que se utiliza para obtener cualquier configuracion tanto local como remota contenida
	/// en los archivos de configuracion.
	/// <remarks>Los parametros necesarios para su correcto funcionamiento son los que se
    /// allan en el App.Config que utilize el ConfigurationManager tales como:
    /// BaseConfigFile
    /// RemotingConfigFile : indica el archivo de configuracion necesario para la configuracion  del servicio remoto.
    /// IsLocal: determina si el ambito de configuracion es atravez del servicio remoto (Configuration Provider) 
    /// o es local (sin servicio alguno)
    /// </remarks>
	/// </summary>
    /// <Author>Marcelo Oviedo</Author>
	public class ConfigurationManager
	{

        static ConfigProviderSection _ConfigProvider;

        /// <summary>
        /// 
        /// </summary>
        public static ConfigProviderSection ConfigProvider
        {
            get { return _ConfigProvider; }
           
        }
        static ConfigProviderElement _DefaultProvider;

        /// <summary>
        /// Proveedor configurado como por defecto
        /// </summary>
        public static ConfigProviderElement DefaultProvider
        {
            get { return _DefaultProvider; }
            
        }

        /// <summary>
        /// Constructor estatico del bloque de configuracion del framework
        /// </summary>
        static ConfigurationManager()
        {
            TechnicalException te;
            try
            {
                _ConfigProvider = System.Configuration.ConfigurationManager.GetSection("FwkConfigProvider") as ConfigProviderSection;
                if (_ConfigProvider == null)
                {
                    te = new TechnicalException("No se puede cargar el proveedor de configuracion del framework fwk, verifique si existe la seccion [FwkConfigProvider] en el archivo de configuracion.");
                    te.ErrorId = "8000";
                    te.Namespace = "Fwk.Configuration";
                    te.Class = "Fwk.Configuration.ConfigurationManager [static constructor --> ConfigurationManager()]";
                    te.UserName = Environment.UserName;
                    te.Machine = Environment.MachineName;
              
                    if (string.IsNullOrEmpty(ConfigurationsHelper.HostApplicationName))
                        te.Source = "Sistema de Configuration del framework en ";
                    else
                        te.Source = ConfigurationsHelper.HostApplicationName;

                    throw te;
                }
            }
            catch (System.Exception ex)
            {
                te = new TechnicalException("No se puede cargar el proveedor de configuracion del framework fwk, verifique si existe la seccion [FwkConfigProvider] en el archivo de configuracion. \r\n", ex);
                te.ErrorId = "8000";
                te.Namespace = "Fwk.Configuration";
                te.Class = "Fwk.Configuration.ConfigurationManager [static constructor --> ConfigurationManager()]";
                te.UserName = Environment.UserName;
                te.Machine = Environment.MachineName;

                if (string.IsNullOrEmpty(ConfigurationsHelper.HostApplicationName))
                    te.Source = "Sistema de Configuration del framework en ";
                else
                    te.Source = ConfigurationsHelper.HostApplicationName;

                throw te;

            }

            _DefaultProvider = _ConfigProvider.DefaultProvider;

        }

        /// <summary>
        /// Permite establecer el proveedor de configuración por defecto sin importar al proveedor por defecto configurado en el app config
        /// </summary>
        /// <param name="providerName"></param>
        public static void ChangeDefaultProvider(string providerName)
        {
            _DefaultProvider = _ConfigProvider.GetProvider(providerName);
        }
 
        
        /// <summary>
        /// Obtiene una propiedad determinada de un archivo de configuracion Usa proveedor de confuiguraciones establecido por defecto.-
        /// </summary>
        /// <param name="pGroupName">Nombre del grupo donde se encuentra la propiedad</param>
        /// <param name="pPropertyName">Nombre de la propiedad a obtener</param>
        /// <returns>String con la propiedad</returns>
        /// <Author>Marcelo Oviedo</Author>
        public static string GetProperty(string pGroupName, string pPropertyName)
        {
            return GetProperty(string.Empty, pGroupName, pPropertyName);
        } 
        
        /// <summary>
        /// Obtiene una propiedad determinada de un archivo de configuracion .-
        /// </summary>
        /// <param name="configProvider">Nombre del proveedor de configuracion</param>
        /// <param name="pGroupName">Nombre del grupo donde se encuentra la propiedad</param>
        /// <param name="pPropertyName">Nombre de la propiedad a obtener</param>
        /// <returns>String con la propiedad</returns>
        /// <Author>Marcelo Oviedo</Author>
        public static Key GetKey(string configProvider, string pGroupName, string pPropertyName)
        {



            ConfigProviderElement provider = GetProvider(configProvider);
            if (provider == null) return null;


            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        return LocalFileConfigurationManager.GetKey(configProvider, pGroupName, pPropertyName);
                    }

                case ConfigProviderType.sqldatabase:
                    {
                        return DatabaseConfigManager.GetKey(configProvider, pGroupName, pPropertyName);
                    }
                //case ConfigProviderType.servicewrapper:
                //    {
                //        return ServiceConfigurationManager.GetProperty(configProvider, pGroupName, pPropertyName); ;
                //    }
            }
            return null;
        }

        /// <summary>
        /// Obtiene una propiedad determinada de un archivo de configuracion .-
        /// </summary>
        /// <param name="configProvider">Nombre del proveedor de configuracion</param>
        /// <param name="pGroupName">Nombre del grupo donde se encuentra la propiedad</param>
        /// <param name="pPropertyName">Nombre de la propiedad a obtener</param>
        /// <returns>String con la propiedad</returns>
        /// <Author>Marcelo Oviedo</Author>
        public static string GetProperty(string configProvider, string pGroupName, string pPropertyName)
        {



            ConfigProviderElement provider = GetProvider(configProvider);
            if (provider == null) return null;


            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        return LocalFileConfigurationManager.GetProperty(configProvider,pGroupName,pPropertyName);
                    }
             
                case ConfigProviderType.sqldatabase:
                    {
                        return DatabaseConfigManager.GetProperty(configProvider ,pGroupName, pPropertyName);
                    }
                case ConfigProviderType.servicewrapper:
                    {
                        return ServiceConfigurationManager.GetProperty(configProvider ,pGroupName, pPropertyName);;
                    }
            }
            return null;
        }
      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configProvider">Nombre del proveedor configurado</param>
        /// <returns></returns>
        public static ConfigurationFile GetConfigurationFile(string configProvider)
        {
            ConfigProviderElement provider = GetProvider(configProvider);
            if (provider == null) return null;


            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        return LocalFileConfigurationManager.GetConfigurationFile(provider); 
                    }
                case ConfigProviderType.sqldatabase:
                    {
                        return DatabaseConfigManager.GetConfigurationFile(provider); 
                    }
                case ConfigProviderType.servicewrapper:
                    {
                        return ServiceConfigurationManager.GetConfigurationFile(provider); 
                        
                    }
            }
            return null;
        }

        /// <summary>
        /// Obtiene un grupo determinado en el archivo de configuracion
        /// </summary>
        /// <param name="configProvider">Nombre del proveedor de configuracion</param>
        /// <param name="pGroupName">Nombre del grupo a obtener</param>
        /// <returns>Group</returns>
        /// <Author>Marcelo Oviedo</Author>
        public static Group GetGroup(string configProvider, string pGroupName)
        {

            ConfigProviderElement provider = GetProvider(configProvider);
            if (provider == null) return null;
            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        return LocalFileConfigurationManager.GetGroup(configProvider, pGroupName);
                    }
              
                case ConfigProviderType.sqldatabase:
                    {
                        return DatabaseConfigManager.GetGroup(configProvider, pGroupName);
                    }
                case ConfigProviderType.servicewrapper:
                    {
                        return ServiceConfigurationManager.GetGroup(configProvider, pGroupName);
                    }
            }
            return null;
        }

        /// <summary>
        /// Obtiene un grupo determinado en el archivo de configuracion
        /// </summary>
        /// <param name="pGroupName"></param>
        /// <returns>Group </returns>
        /// <Author>Marcelo Oviedo</Author>
        public static Group GetGroup(string pGroupName)
        {
            return GetGroup(string.Empty, pGroupName);
        }

        #region Operaciones validas solo para configuraciones remotas.-

        /// <summary>
        /// Obtiene la vercion de un archivo de configuracion para determinar el estado en el que se
        /// encuentra
        /// </summary>
        /// <param name="pFileName">Nombre del archivo</param>
        /// <param name="pClientVersion">Version del archivo del lado del cliente</param>
        /// <Author>Marcelo Oviedo</Author>
        //public static Helper.FileStatus GetFileVersionStatus(string pFileName, string pClientVersion)
        //{

        //    if (_DefaultProvider.ConfigProviderType == ConfigProviderType.remote)
        //    {
        //        return RemoteConfigurationManager.GetFileVersionStatus(pFileName, pClientVersion);
        //    }
            
        //    else 
        //    {
        //        TechnicalException te = new TechnicalException(string.Concat("Operacion no valida para un proveedor de configuracion del tipo: ", _DefaultProvider.ConfigProviderType.ToString()));
        //        te.ErrorId = "8100";
        //        Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
        //        throw te;
        //    }
        //}
        #endregion 


        #region Metodos privados
       

        /// <summary>
        /// Metodo que lee el en el App.Config la Key = BaseConfigFile para obtener el nombre del archivo de configuracion
        /// utilizado
        /// </summary>
        /// <returns>String con el nombre del archivo</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static string GetBaseConfigFileName()
        {
            return GetBaseConfigFileName(string.Empty);
        }


        /// <summary>
        /// Metodo que lee el en el App.Config la Key = BaseConfigFile para obtener el nombre del archivo de configuracion
        /// utilizado
        /// </summary>
        /// <param name="pProviderName">Nombre del proveedor de configuracion</param>
        /// <returns>String con el nombre del archivo</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static string GetBaseConfigFileName(string pProviderName)
        {
          
           if (_ConfigProvider.GetProvider(pProviderName).BaseConfigFile == string.Empty)
            {
                TechnicalException te = new TechnicalException(string.Concat("Falta el nombre artchivo de configuracion no espesificado en el proveedor de configuracion ", pProviderName, " . Ver archivo .config de la aplicacion"));
                te.ErrorId = "8010";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
                throw te;

            }
            
            return _ConfigProvider.GetProvider(pProviderName).BaseConfigFile;

        }
	    #endregion

        /// <summary>
        /// Obtiene uin configuration provider por su nombre
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de configuracion</param>
        /// <returns></returns>
        internal static ConfigProviderElement GetProvider(string providerName)
        {
           if (string.IsNullOrEmpty(providerName))
                return _DefaultProvider;
            else
                return _ConfigProvider.GetProvider(providerName);
           
        }


        /// <summary>
        /// Crea una propiedad en un grupo determinado
        /// </summary>
        /// <param name="configProvider">Nombre del proveedor de configuracion</param>
        /// <param name="groupName">Nombre del gruop que contiene las propiedades</param>
        /// <param name="key"></param>
        internal static void AddProperty(string configProvider, string groupName,Key key)
        {
            ConfigProviderElement provider = GetProvider(configProvider);
            if (provider == null) return ;
            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        LocalFileConfigurationManager.AddProperty(provider, key, groupName);
                        break;
                    }
                case ConfigProviderType.sqldatabase:
                    {
                        DatabaseConfigManager.AddProperty(provider, key, groupName);
                        break;
                    }
                case ConfigProviderType.servicewrapper:
                    {
                        DatabaseConfigManager.AddProperty(provider, key, groupName); break;
                    }
            }
        }

        /// <summary>
        /// Agrega un grupo al archivo de configuracion.-
        /// Si el grupo existe se retorna una TecnicalExeption 
        /// </summary>
        /// <param name="configProvider">Nombre del proveedor de configuracion</param>
        /// <param name="group">Objeto tipo Grupo que se agregara</param>
        internal static void AddGroup(string configProvider, Group group)
        {
            ConfigProviderElement provider = GetProvider(configProvider);
            if (provider == null) return ;
            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        LocalFileConfigurationManager.AddGroup(provider, group); break;
                    }
               
                case ConfigProviderType.sqldatabase:
                    {
                        DatabaseConfigManager.AddGroup(provider, group); break;
                    }
                case ConfigProviderType.servicewrapper:
                    {
                        ServiceConfigurationManager.AddGroup(provider, group); break;
                    }
            }
        }



        /// <summary>
        /// Elimina una propiedad u objeto key
        /// </summary>
        /// <param name="configProvider">Nombre del proveedor de configuracion</param>
        /// <param name="groupName">Nombre del gruop que contiene las propiedades</param>
        /// <param name="propertyName">Nombre de la propiedad o key.name</param>
        internal static void RemoveProperty(string configProvider, string groupName, string propertyName)
        {
            ConfigProviderElement provider = GetProvider(configProvider);
            if (provider == null) return;
            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        LocalFileConfigurationManager.RemoveProperty(provider, groupName, propertyName); break;
                    }

                case ConfigProviderType.sqldatabase:
                    {
                        DatabaseConfigManager.RemoveProperty(provider, groupName, propertyName); break;
                    }
                case ConfigProviderType.servicewrapper:
                    {
                        ServiceConfigurationManager.RemoveProperty(provider, groupName, propertyName); break; 
                    }
            }
        }

        /// <summary>
        /// Elimina un grupo
        /// </summary>
        /// <param name="configProvider">Nombre del proveedor de configuracion</param>
        /// <param name="groupName">Nombre del gruop que contiene las propiedades</param>
        internal static void RemoveGroup(string configProvider, string groupName)
        {
            ConfigProviderElement provider = GetProvider(configProvider);
            if (provider == null) return;
            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        LocalFileConfigurationManager.RemoveGroup(provider, groupName); break;
                    }
            
                case ConfigProviderType.sqldatabase:
                    {
                        DatabaseConfigManager.RemoveGroup(provider, groupName); break;
                    }
                case ConfigProviderType.servicewrapper:
                    {
                        ServiceConfigurationManager.RemoveGroup(provider, groupName); break;
                    }
            }
        }

        /// <summary>
        /// Cançmbia el nombre de un grupo
        /// </summary>
        /// <param name="configProvider">Nombre del proveedor de configuracion</param>
        /// <param name="groupName">Nombre del gruop que contiene las propiedades</param>
        /// <param name="newGroupName"></param>
        internal static void ChangeGroupName(string configProvider, string groupName, string newGroupName)
        {
            ConfigProviderElement provider = GetProvider(configProvider);
            if (provider == null) return;
            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        LocalFileConfigurationManager.ChangeGroupName(provider, groupName, newGroupName); break;
                    }
             
                case ConfigProviderType.sqldatabase:
                    {
                        DatabaseConfigManager.ChangeGroupName(provider, groupName,newGroupName); break;
                    }
                case ConfigProviderType.servicewrapper:
                    {
                        ServiceConfigurationManager.ChangeGroupName(provider, groupName, newGroupName); break;
                    }
            }
        }

        /// <summary>
        /// Realiza cambios a una propiedad.-
        /// </summary>
        /// <param name="configProvider">Nombre del proveedor de configuracion</param>
        /// <param name="groupName">Nombre del grupo donde se encuentra la propiedad</param>
        /// <param name="property">Propiedad actualizada. Este objeto puede contener todos sus valores modifcados</param>
        /// <param name="propertyName">Nombre de la propiedad que se mofdifico.- Este valor es el original sin modificacion</param>
        internal static void ChangeProperty(string configProvider, string groupName, Key property, string propertyName)
        {
            ConfigProviderElement provider = GetProvider(configProvider);
            if (provider == null) return;
            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        LocalFileConfigurationManager.ChangeProperty(provider, groupName, property, propertyName); break;
                    }
               
                case ConfigProviderType.sqldatabase:
                    {
                        DatabaseConfigManager.ChangeProperty(provider, groupName, property, propertyName); break;
                    }
                case ConfigProviderType.servicewrapper:
                    {
                        ServiceConfigurationManager.ChangeProperty(provider, groupName, property, propertyName); break; 
                    }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceConfigurationFile"></param>
        /// <param name="provider">Destination provider </param>
        public static void Import(ConfigurationFile sourceConfigurationFile, ConfigProviderElement provider)
        {
            
            if (provider == null) return;
            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        throw new NotImplementedException("Funcionalidad de exportacion no impolementada");
                    }
                case ConfigProviderType.sqldatabase:
                    {
                        DatabaseConfigManager.Import(provider, sourceConfigurationFile); break;
                    }
                case ConfigProviderType.servicewrapper:
                    {
                        throw new NotImplementedException("Funcionalidad de exportacion no impolementada");
                    }
            }
           
        }

        /// <summary>
        /// Vuelve a cargar el archivo de configuracion desde el origen de datos
        /// </summary>
        /// <param name="configProvider">Nombre del proveedor configurado</param>
        /// <returns></returns>
        public static ConfigurationFile RefreshConfigurationFile(string configProvider)
        {
            ConfigProviderElement provider = GetProvider(configProvider);
            if (provider == null) return null;
            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        return LocalFileConfigurationManager.RefreshConfigurationFile(provider); 
                    }
                case ConfigProviderType.sqldatabase:
                    {
                        return DatabaseConfigManager.RefreshConfigurationFile(provider); 
                    }
                case ConfigProviderType.servicewrapper:
                    {
                        ServiceConfigurationManager.RefreshConfigurationFile(provider); break;
                    }
            }
            return null;
        }
    }
    

}
