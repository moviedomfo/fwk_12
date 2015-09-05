using System;
using System.Configuration;
using System.Collections.Generic;

namespace Fwk.Security.Cryptography.Config
{
    /// <summary>
    /// Sección 'CypherProviderSection' del archivo de configuración App.Config.
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public class CypherProviderSection : ConfigurationSection
    {
        #region <private members>
        CypherProviderElement _ConfigProviderElement;
        #endregion

        #region <constructor>
        /// <summary>
        /// Constructor de ConfigProviderSection.
        /// </summary>
        public CypherProviderSection()
        {
            _ConfigProviderElement = new CypherProviderElement();
          
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
        public CypherProviderCollection Providers
        {
            get
            {
                CypherProviderCollection wProviderCollection = (CypherProviderCollection)base["Providers"];
                return wProviderCollection;
            }
             
        }
        #endregion

        #region <public methods>
        /// <summary>
        /// Retorna un proveedor determinado
        /// </summary>
        /// <param name="name">nombre del proveedor configurado.</param>
        /// <returns>Provider (Rule).</returns>
        public CypherProviderElement GetProvider(string name)
        {
            if (string.IsNullOrEmpty(name))
                return this.DefaultProvider;
            foreach (CypherProviderElement wElement in this.Providers)
            {
                if (name.CompareTo(wElement.Name) ==0)
                {
                    return wElement;
                }

            }
            return null;
        }

        CypherProviderElement _DefaultProvider = null;

        /// <summary>
        /// 
        /// </summary>
        public CypherProviderElement DefaultProvider
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
        public void AddNewProvider(CypherProviderElement newProvider)
        {
            if (this.GetProvider(newProvider.Name) == null)
            {
                this.Providers.Add(newProvider);


            }
        }
        
        #endregion
    }

    
}
