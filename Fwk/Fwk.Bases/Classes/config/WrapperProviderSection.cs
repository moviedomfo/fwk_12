using System;
using System.Configuration;
using System.Collections.Generic;

namespace Fwk.ConfigSection
{
    /// <summary>
    /// Sección 'WrapperProviderSection' del archivo de configuración App.Config.
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public class WrapperProviderSection : ConfigurationSection
    {
        #region <private members>
        WrapperProviderElement _WrapperProviderElement;
        #endregion

        #region <constructor>
        /// <summary>
        /// Constructor de ConfigProviderSection.
        /// </summary>
        public WrapperProviderSection()
        {
            _WrapperProviderElement = new WrapperProviderElement();
          
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
        public WrapperProviderCollection Providers
        {
            get
            {
                return (WrapperProviderCollection)base["Providers"];
                
            }
        }
        #endregion

        #region <public methods>
        /// <summary>
        /// Retorna un proveedor determinado
        /// </summary>
        /// <param name="name">nombre del proveedor configurado.</param>
        /// <returns>Provider (Rule).</returns>
        public WrapperProviderElement GetProvider(string name)
        {
            if (string.IsNullOrEmpty(name))
                return this.DefaultProvider;
            foreach (WrapperProviderElement wElement in this.Providers)
            {
                if (name.CompareTo(wElement.Name) ==0)
                {
                    return wElement;
                }

            }
            return null;
        }

        WrapperProviderElement _DefaultProvider = null;

        /// <summary>
        /// 
        /// </summary>
        public WrapperProviderElement DefaultProvider
        {
            get
            {
                if (_DefaultProvider == null)
                    _DefaultProvider = this.GetProvider((string)base["defaultProviderName"]);
                return _DefaultProvider;
            }

        }

        #endregion
    }

 
}
