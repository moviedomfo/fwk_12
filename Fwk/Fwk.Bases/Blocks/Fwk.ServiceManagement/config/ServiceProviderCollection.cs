using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;


namespace Fwk.ConfigSection
{
    /// <summary>
    /// Colección ServiceProviderElement 
    /// </summary>
    /// <date>2010/09/02</date>
    /// <author>moviedo</author>
    public class ServiceProviderCollection : ConfigurationElementCollection
    {
        #region <constructor>
        /// <summary>
        /// Constructor de ConfigElementCollection.
        /// </summary>
        public ServiceProviderCollection() { }
        #endregion

        #region <protected overrides>
        /// <summary>
        /// Crea un nuevo ServiceProviderElement en la colección.
        /// </summary>
        /// <returns>ConfigurationElement.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new ServiceProviderElement();
        }

        /// <summary>
        /// Obtiene el key de un ServiceProviderElement.
        /// </summary>
        /// <param name="element">ConfigProviderElement del cual se desea conocer su key.</param>
        /// <returns>ConfigProviderElement.</returns>
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((ServiceProviderElement)element).Name;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public  void Add(ConfigurationElement element)
        {
            base.BaseAdd(element,true);
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
        /// Retorna un proveedor de netadata según si índice.
        /// </summary>
        /// <param name="index">índice del proveedor de configuracion que se desea obtener.</param>
        /// <returns>proveedor de configuracion</returns>
        public ServiceProviderElement this[int index]
        {
            get
            {
                return (ServiceProviderElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion

        #region <public methods>
        /// <summary>
        /// Retorna el índice del proveedor de metadata.
        /// </summary>
        /// <param name="configProviderElement">ConfigProviderElement que se desea conocer su </param>
        /// <returns>índice</returns>
        public int IndexOf(ServiceProviderElement configProviderElement)
        {
            return BaseIndexOf(configProviderElement);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void Remove(String name)
        {

            base.RemoveElementName = name;
        }
    }
}
