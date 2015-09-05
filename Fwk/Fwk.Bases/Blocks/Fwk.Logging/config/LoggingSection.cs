using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;
using Fwk.Logging;
using Fwk.Exceptions;

namespace Fwk.ConfigSection
{
    /// <summary>
    /// Sección 'Logging' del archivo de configuración App.Config.
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public class LoggingSection : ConfigurationSection
    {
        #region <private members>
        LogProviderElement _LogProviderElement;
        #endregion

        #region <constructor>
        /// <summary>
        /// Constructor de LoggingSection.
        /// </summary>
        public LoggingSection()
        {
            _LogProviderElement = new LogProviderElement();
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
        /// Colección de reglas de logueo. 
        /// </summary>
        [ConfigurationProperty("Providers", IsDefaultCollection = false)]
        public LogProviderCollection Providers
        {
            get
            {
                LogProviderCollection wRuleElementCollection = (LogProviderCollection)base["Providers"];
                return wRuleElementCollection;
            }
        }
        #endregion

        #region <public methods>
        public LogProviderElement GetProvider()
        {
            return GetProvider(this.DefaultProviderName);
        }
        /// <summary>
        /// Retorna un proveedor determinado
        /// </summary>
        /// <param name="name">nombre del proveedor configurado.</param>
        /// <returns>Provider (Rule).</returns>
        public LogProviderElement GetProvider(string name)
        {
            if (string.IsNullOrEmpty(name))
                return this.DefaultProvider;
            foreach (LogProviderElement wElement in this.Providers)
            {
                if (name.CompareTo(wElement.Name) == 0)
                {
                    return wElement;
                }

            }
            return null;
        }

        LogProviderElement _DefaultProvider = null;

        /// <summary>
        /// Retorna la regla (Rule) que corresponde a determinado
        /// tipo de evento.
        /// </summary>
        /// <param name="pEventType">Tipo de evento.</param>
        /// <returns>Regla (Rule).</returns>
        //public LogProviderElement GetRuleByEventType(string providerName)
        //{
        //    LogProviderElement wRule = null;
        //    foreach (LogProviderElement r in this.Providers)
        //    {
        //        if (r.Events.Contains<EventType>(pEventType))
        //            wRule = r;

        //    }
        //    if (wRule == null)
        //    {

        //        TechnicalException te = new TechnicalException(String.Format("No se encuentra configurado el evento {0} en la seccion FwkLogging.", pEventType.ToString()));
        //        te.Assembly = "Fwk.Logging";
        //        te.Class = "LoginSection";
        //        te.ErrorId = "9001";
        //        te.Namespace = "Fwk.Logging";
        //        te.UserName = Environment.UserName;
        //        te.Machine = Environment.MachineName;
        //        throw te;
        //    }
        //    return wRule;
        //}

        /// <summary>
        /// 
        /// </summary>
        public LogProviderElement DefaultProvider
        {
            get
            {
                string s = (string)base["defaultProviderName"];
                if (string.IsNullOrEmpty((string)base["defaultProviderName"]))
                {
                    //base["defaultProviderName"]=  this.Providers[0].Name;
                    if (this.Providers.Count != 0)
                        _DefaultProvider = this.Providers[0];
                    else
                    {
                        TechnicalException te = new TechnicalException(String.Format("No se encuentra configurado ningun Provider en la seccion FwkLogging."));
                        te.Assembly = "Fwk.Logging";
                        te.Class = "LogginSection";
                        te.ErrorId = "9001";
                        te.Namespace = "Fwk.Logging";
                        te.UserName = Environment.UserName;
                        te.Machine = Environment.MachineName;
                        throw te;
                    }
                }


                if (_DefaultProvider == null)
                    _DefaultProvider = this.GetProvider((string)base["defaultProviderName"]);

                return _DefaultProvider;
            }
        }
        #endregion
    }
}
