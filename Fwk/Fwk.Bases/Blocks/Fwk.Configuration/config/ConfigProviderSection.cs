using System;
using System.Configuration;
using System.Collections.Generic;

namespace Fwk.ConfigSection
{
    /// <summary>
    /// Sección 'ConfigProvider' del archivo de configuración App.Config.
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public class ConfigProviderSection : ConfigurationSection
    {
        #region <private members>
        ConfigProviderElement _ConfigProviderElement;
        #endregion

        #region <constructor>
        /// <summary>
        /// Constructor de ConfigProviderSection.
        /// </summary>
        public ConfigProviderSection()
        {
            _ConfigProviderElement = new ConfigProviderElement();
          
        }
        #endregion

        #region <public properties>
        [ConfigurationProperty("defaultProviderName", DefaultValue = "defaultProvider")]
        public string DefaultProviderName
        {
            get
            {
                return (string)base["defaultProviderName"];
              
            }
            set
            {
                base["defaultProviderName"] = value;
            }
        }

        /// <summary>
        /// Colección de proveedores de coneccion. 
        /// </summary>
        [ConfigurationProperty("Providers", IsDefaultCollection = false)]
        public ConfigProviderCollection Providers
        {
            get
            {
                ConfigProviderCollection wConfigProviderCollection = (ConfigProviderCollection)base["Providers"];
                return wConfigProviderCollection;
            }
             
        }
        #endregion

        #region <public methods>
        /// <summary>
        /// Retorna un proveedor determinado
        /// </summary>
        /// <param name="name">nombre del proveedor configurado.</param>
        /// <returns>Provider (Rule).</returns>
        public ConfigProviderElement GetProvider(string name)
        {
            if (string.IsNullOrEmpty(name))
                return this.DefaultProvider;
            foreach (ConfigProviderElement wElement in this.Providers)
            {
                if (name.CompareTo(wElement.Name) ==0)
                {
                    return wElement;
                }

            }
            return null;
        }

        ConfigProviderElement _DefaultProvider = null;

        /// <summary>
        /// 
        /// </summary>
        public ConfigProviderElement DefaultProvider
        {
            get
            {
                if (_DefaultProvider == null)
                    _DefaultProvider = this.GetProvider((string)base["defaultProviderName"]);

                return _DefaultProvider;
            }
        }
        /// <summary>
        /// Agrega un nuevo proveedor si este no existe
        /// </summary>
        /// <param name="newProvider"></param>
        public void AddNewProvider(ConfigProviderElement newProvider)
        {
            if (this.GetProvider(newProvider.Name) == null)
            {
                this.Providers.Add(newProvider);


            }
        }
        #endregion
    }

    /// <summary>
    /// Enumeracion que defino los tipos de 
    /// </summary>
    public enum ConfigProviderType
    { 
        /// <summary>
        /// Lee de un archivo local, puede ser carpeta compartida en la red.-
        /// </summary>
        local,
        /// <summary>
        /// Consulta por medio de un servicio del dispatcher del framework
        /// puede ser web service o remoting , depende del wrapper configurado
        /// </summary>
        servicewrapper,
        /// <summary>
        /// Consulta directa,mente a una base de datos
        /// </summary>
        sqldatabase
        
    }
}
