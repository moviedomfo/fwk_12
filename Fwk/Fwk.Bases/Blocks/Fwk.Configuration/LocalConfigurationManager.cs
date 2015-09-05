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

namespace Fwk.Configuration
{    
    /// <summary>
    /// Clase que permite obtener informacion de un archivo de configuracion ubicado localmente donde la aplicacion
    /// esta corriendo sin nececidad de configurar y tener disponible los servicios de configuracion :
    /// <Configuration Provider (Win Service que hostea la clase remota ConfigurationHolder<see cref="ConfigurationHolder"/>)
    /// Configuration Service (Web Service)
    /// <remarks>
    /// Es necesario para que funcione la configuracion local tener en la aplicacion cliente un archivo de configuracion valido en disco
    /// y en la ruta donde esta corriendo la aplicacion. 
    /// </remarks>
    /// </summary>
    /// <Author>Marcelo Oviedo</Author>
    class LocalFileConfigurationManager
    {
        static ConfigurationRepository _Repository;

        static LocalFileConfigurationManager()
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

            //if (!wConfigurationFile.BaseConfigFile)
            //{
            //    TechnicalException te = new TechnicalException("El archivo solicitado no es un archivo de configuración válido.");
            //    te.ErrorId = "8005";
            //    Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(LocalFileConfigurationManager));
            //    throw te;
            //}

            Group wGroup = wConfigurationFile.Groups.GetFirstByName(pGroupName);
            if (wGroup == null)
            {
                TechnicalException te = new TechnicalException(string.Concat(new String[] { "No se encuentra el grupo ", pGroupName, " en el archivo de configuración: ", wBaseConfigFile }));
                te.ErrorId = "8006";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(LocalFileConfigurationManager));
                throw te;
            }
            Key wKey = wGroup.Keys.GetFirstByName(pPropertyName);
            if (wKey == null)
            {
                TechnicalException te = new TechnicalException(string.Concat(new String[] { "No se encuentra la propiedad ", pPropertyName, " en el grupo de propiedades: ", pGroupName, " del archivo de configuración: ", wBaseConfigFile }));
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

            //if (!wConfigurationFile.BaseConfigFile)
            //{
            //    TechnicalException te = new TechnicalException("El archivo solicitado no es un archivo de configuración válido.");
            //    te.ErrorId = "8005";
            //    Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
            //    throw te;
            //}

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
        /// Obtiene un String con el contenido del archivo xml de configuracion. 
        /// Si este metodo es accedido desde el servicio web extrae la informacion de estado del archivo:
        /// Encrypt
        /// TTL
        /// ForceUpdate
        /// CurrentVersion
        /// BaseConfigFile
        /// Cacheable
        /// </summary>
        /// <param name="provider">Proveedor de configuración.</param>
        /// <Author>Marcelo Oviedo</Author>
        static ConfigurationFile SetConfigurationFile(ConfigProviderElement provider)
        {
            ConfigurationFile wConfigurationFile = new ConfigurationFile();


            string wFullFileName;
            if (System.IO.File.Exists(provider.BaseConfigFile))
            {
                wFullFileName = provider.BaseConfigFile;
            }
            else
            {
                //Application.StartupPath
                wFullFileName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), provider.BaseConfigFile);
            }

            if (!System.IO.File.Exists(wFullFileName))
            {
                TechnicalException te = new TechnicalException(string.Concat("El archivo de artchivo de configuración ", provider.BaseConfigFile, " no existe. ", Environment.NewLine, "Revisar en el archivo .config de la aplicacion la configuración del proveedor [", provider.Name, "]"));
                te.ErrorId = "8011";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(LocalFileConfigurationManager));
                throw te;

            }

            wConfigurationFile = ConfigurationFile.GetFromXml<ConfigurationFile>(Fwk.HelperFunctions.FileFunctions.OpenTextFile(wFullFileName));



            wConfigurationFile.FileName = wFullFileName;

            if (wConfigurationFile != null)
            {
                wConfigurationFile.TTL = wConfigurationFile.TTL;
                wConfigurationFile.Encrypted = wConfigurationFile.Encrypted;
                wConfigurationFile.ForceUpdate = wConfigurationFile.ForceUpdate;
                wConfigurationFile.CurrentVersion = wConfigurationFile.CurrentVersion;
                wConfigurationFile.ProviderName = provider.Name;

            }

            return wConfigurationFile;

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
            ConfigurationFile wConfigurationFile = GetConfig(provider);
            Group wGroup = wConfigurationFile.Groups.GetFirstByName(groupName);
            wGroup.Keys.Add(key);

            try
            {

                FileFunctions.SaveTextFile(wConfigurationFile.FileName, wConfigurationFile.GetXml(), false);
            }
            catch (System.UnauthorizedAccessException)
            {

                TechnicalException te = new TechnicalException(string.Concat("No tiene permiso para actualizar el archivo ", provider.BaseConfigFile));
                te.ErrorId = "8008";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(LocalFileConfigurationManager));
                throw te;
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="group"></param>
        internal static void AddGroup(ConfigProviderElement provider, Group group)
        {
            ConfigurationFile wConfigurationFile = GetConfig(provider);
            wConfigurationFile.Groups.Add(group);

            try
            {
                FileFunctions.SaveTextFile(wConfigurationFile.FileName, wConfigurationFile.GetXml(), false);
            }
            catch (System.UnauthorizedAccessException)
            {
                TechnicalException te = new TechnicalException(string.Concat("No tiene permiso para actualizar el archivo ", provider.BaseConfigFile));
                te.ErrorId = "8008";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(LocalFileConfigurationManager));
                throw te;
            }

        }

        /// <summary>
        /// Elimina una porpiedad de la cinfuguracion
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="groupName">Gupo al que pertenece la propiedad</param>
        /// <param name="propertyName">Nombre de la propiedad</param>
        internal static void RemoveProperty(ConfigProviderElement provider, string groupName, string propertyName)
        {
            ConfigurationFile wConfigurationFile = GetConfig(provider);
            Group wGroup = wConfigurationFile.Groups.GetFirstByName(groupName);
            Key k = wGroup.Keys.GetFirstByName(propertyName);
            wGroup.Keys.Remove(k);

            try
            {
                FileFunctions.SaveTextFile(wConfigurationFile.FileName, wConfigurationFile.GetXml(), false);
            }
            catch (System.UnauthorizedAccessException)
            {
                TechnicalException te = new TechnicalException(string.Concat("No tiene permiso para actualizar el archivo ", provider.BaseConfigFile));
                te.ErrorId = "8008";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(LocalFileConfigurationManager));
                throw te;

            }
        }

        /// <summary>
        /// Elimina un grupo de la configuracion
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="groupName">Nombre del grupo a eliminar</param>
        internal static void RemoveGroup(ConfigProviderElement provider, string groupName)
        {

            ConfigurationFile wConfigurationFile = GetConfig(provider);
            Group g = wConfigurationFile.Groups.GetFirstByName(groupName);

            wConfigurationFile.Groups.Remove(g);

            try
            {
                FileFunctions.SaveTextFile(wConfigurationFile.FileName, wConfigurationFile.GetXml(), false);
            }
            catch (System.UnauthorizedAccessException)
            {
                TechnicalException te = new TechnicalException(string.Concat("No tiene permiso para actualizar el archivo ", provider.BaseConfigFile));
                te.ErrorId = "8008";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(LocalFileConfigurationManager));
                throw te;
            }
        }




        /// <summary>
        /// Cambia el nombre de un grupo.-
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="groupName">Nombre del grupo</param>
        /// <param name="newGroupName">Nuevo nombre del grupo</param>
        internal static void ChangeGroupName(ConfigProviderElement provider, string groupName, string newGroupName)
        {
            ConfigurationFile wConfigurationFile = GetConfig(provider);
            Group g = wConfigurationFile.Groups.GetFirstByName(groupName);

            g.Name = newGroupName;
            try
            {
                FileFunctions.SaveTextFile(wConfigurationFile.FileName, wConfigurationFile.GetXml(), false);
            }
            catch (System.UnauthorizedAccessException)
            {
                TechnicalException te = new TechnicalException(string.Concat("No tiene permiso para actualizar el archivo ", provider.BaseConfigFile));
                te.ErrorId = "8008";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(LocalFileConfigurationManager));
                throw te;
            }
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
            ConfigurationFile wConfigurationFile = GetConfig(provider);
            Group wGroup = wConfigurationFile.Groups.GetFirstByName(groupName);
            Key k = wGroup.Keys.GetFirstByName(propertyName);

            k.Name = property.Name;
            k.Encrypted = property.Encrypted;
            k.Value.Text = property.Value.Text;

            try
            {
                FileFunctions.SaveTextFile(wConfigurationFile.FileName, wConfigurationFile.GetXml(), false);
            }
            catch (System.UnauthorizedAccessException)
            {

                TechnicalException te = new TechnicalException(string.Concat("No tiene permiso para actualizar el archivo ", provider.BaseConfigFile));
                te.ErrorId = "8008";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(LocalFileConfigurationManager));
                throw te;
            }
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
