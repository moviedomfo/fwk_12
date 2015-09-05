using System;
using System.Configuration;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace Fwk.ConfigSection
{
    /// <summary>
    /// Sección 'ServiceProviderSection' del archivo de configuración App.Config.
    /// </summary>
    /// <date>2010/09/02</date>
    /// <author>moviedo</author>
    public class ServiceProviderSection : ConfigurationSection
    {
        #region <private members>
        ServiceProviderElement _ServiceProviderElement;
        #endregion

        #region <constructor>
        /// <summary>
        /// Constructor de ConfigProviderSection.
        /// </summary>
       public ServiceProviderSection()
        {
            _ServiceProviderElement = new ServiceProviderElement();
          
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
        public ServiceProviderCollection Providers
        {
            get
            {
               return (ServiceProviderCollection)base["Providers"];
            }
        }
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion

        #region <public methods>
        /// <summary>
        /// Retorna un proveedor determinado
        /// </summary>
        /// <param name="name">nombre del proveedor configurado.</param>
        /// <returns>Provider (Rule).</returns>
        public ServiceProviderElement GetProvider(string name)
        {
            if (string.IsNullOrEmpty(name))
                return this.DefaultProvider;
            foreach (ServiceProviderElement wElement in this.Providers)
            {
                if (name.CompareTo(wElement.Name) ==0)
                {
                    return wElement;
                }

            }
            return null;
        }
       

        ServiceProviderElement _DefaultProvider = null;
        /// <summary>
        /// 
        /// </summary>
        public ServiceProviderElement DefaultProvider
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
        /// <param name="name"></param>
        /// <param name="sourceInfo"></param>
        /// <param name="applicationId"></param>
        /// <param name="type"></param>
        public void AddNewProvider(string name, string sourceInfo, string applicationId, ServiceProviderType type)
        {
            
                ServiceProviderElement p = new ServiceProviderElement();
                p.Name = name;
                p.SourceInfo = sourceInfo;
                p.ApplicationId = applicationId;
                p.ProviderType = type;
                this.AddNewProvider(p);
            
        }

        /// <summary>
        /// Agrega un nuevo proveedor si este no existe
        /// </summary>
        /// <param name="newProvider"></param>
        public void AddNewProvider(ServiceProviderElement newProvider)
        {
            if (this.GetProvider(newProvider.Name) == null)
            {
                this.Providers.Add(newProvider);

                //ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                //map.ExeConfigFilename = System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name + ".config";
                //map.ExeConfigFilename = AssemblyDirectory();
                //System.Configuration.Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                //ServiceProviderSection config = (ServiceProviderSection)configuration.Sections["FwkServiceMetadata"];


                //config.Providers.Add(newProvider);
                //configuration.Save(ConfigurationSaveMode.Minimal, true);
                
            }
        }
       public void RemoveProvider(String providerName)
        {
            if (this.GetProvider(providerName) != null)
            {
                this.Providers.Remove(providerName);
            }
        }
        #endregion
    }

    /// <summary>
    /// Enumeracion que defino los tipos de 
    /// </summary>
    public enum ServiceProviderType
    { 
        /// <summary>
        /// Lee de un archivo local, puede ser carpeta compartida en la red.-
        /// </summary>
        xml,
        /// <summary>
        /// Utiliza la configuracion distribuida provista por el framework
        /// </summary>
        sqldatabase
       
    }
}
