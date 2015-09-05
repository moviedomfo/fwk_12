using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;


namespace Fwk.ConfigSection
{
    /// <summary>
    /// Colección ConfigProvider 
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public class ConfigProviderCollection : ConfigurationElementCollection
    {
        #region <constructor>
        /// <summary>
        /// Constructor de ConfigElementCollection.
        /// </summary>
        public ConfigProviderCollection() { }
        #endregion

        #region <protected overrides>
        /// <summary>
        /// Crea un nuevo ConfigProviderElement en la colección.
        /// </summary>
        /// <returns>ConfigurationElement.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigProviderElement();
        }

        /// <summary>
        /// Obtiene el key de un RuleElement.
        /// </summary>
        /// <param name="element">ConfigProviderElement del cual se desea conocer su key.</param>
        /// <returns>ConfigProviderElement.</returns>
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((ConfigProviderElement)element).Name;
        }
        
        #endregion

        #region <public properties>
        /// <summary>
        /// Cantidad de proveedores de configuracion .
        /// </summary>
        public new int Count
        {

            get { return base.Count; }

        }

        /// <summary>
        /// Retorna un proveedor de configuracion según si índice.
        /// </summary>
        /// <param name="pIndex">índice del proveedor de configuracion que se desea obtener.</param>
        /// <returns>proveedor de configuracion</returns>
        public ConfigProviderElement this[int pIndex]
        {
            get
            {
                return (ConfigProviderElement)BaseGet(pIndex);
            }
        }
        #endregion

        #region <public methods>
        /// <summary>
        /// Elimina un proveedor por indice
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            BaseRemoveAt(index);
        }
  
        /// <summary>
        /// Elimina un proveedor  
        /// </summary>
        /// <param name="configProvider"></param>
        public void Remove(ConfigProviderElement configProvider)
        {
            if (BaseIndexOf(configProvider) >= 0)
                BaseRemove(configProvider.Name);
        }

     
        /// <summary>
        /// Elimina un proveedor por su nombre
        /// </summary>
        /// <param name="name"></param>
        public void Remove(string name)
        {
            BaseRemove(name);
        }
        /// <summary>
        /// Retorna el índice del proveedor de configuracion.
        /// </summary>
        /// <param name="configProvider">configProvider que se desea conocer su </param>
        /// <returns>índice</returns>
        public int IndexOf(ConfigProviderElement configProvider)
        {

            return BaseIndexOf(configProvider);
        }
        /// <summary>
        /// Agrega un nuevo proveedor a la coleccion Providers .-
        /// </summary>
        /// <param name="configProvider"></param>
        public void Add(ConfigProviderElement configProvider)
        {
            base.BaseAdd(configProvider, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
    }
}
