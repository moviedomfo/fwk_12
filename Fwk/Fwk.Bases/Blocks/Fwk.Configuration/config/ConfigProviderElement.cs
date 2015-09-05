using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Fwk.Logging.Targets;

namespace Fwk.ConfigSection
{
    /// <summary>
    /// ConfigProvider . 
    /// 
    ///
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public class ConfigProviderElement : ConfigurationElement
    {
        #region <constructor>
        /// <summary>
        /// Constructor de RuleElement.
        /// </summary>
        public ConfigProviderElement() { }
        #endregion

        #region <public properties>
        /// <summary>
        /// Nombre de la regla. Es el identificador de una regla
        /// por lo tanto este nombre no debe repetirse.
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true), StringValidator(InvalidCharacters = @" ~!@#$%^&*()[]{}/;'""|\")]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set { this["name"] = value; }
        }

        /// <summary>
        /// Determina el tipo de origen de configuracion 
        /// </summary>
        [ConfigurationProperty("type", IsRequired = true, IsKey = false)]
        public ConfigProviderType ConfigProviderType
        {
            get
            {
                return (ConfigProviderType)this["type"];
            }
            set { this["type"] = value; }
        }

 

        /// <summary>
        /// Archivo contenedor de la configuracion
        ///  
        /// </summary>
        [ConfigurationProperty("baseConfigFile", IsRequired = true, IsKey = false), 
         StringValidator(InvalidCharacters = @"~!@#$%^&*[]{};'""|")]
        public string BaseConfigFile
        {
            get
            {
                return (string)this["baseConfigFile"];
            }
            set { this["baseConfigFile"] = value; }
        }

        /// <summary>
        /// Nombre de cadena de coneccion
        ///  
        /// </summary>
        [ConfigurationProperty("sourceinfo", IsRequired = false, IsKey = false)]
        public string SourceInfo
        {
            get
            {
                return (string)this["sourceinfo"];
            }
            set { this["sourceinfo"] = value; }
        }


         /// <summary>
         /// Solo se utiliza en caso de typo sqldatabase y acepta 
         /// </summary>
        public Boolean SourceInfoIsConnectionString{get;set;}
       
        #endregion
    }
}
