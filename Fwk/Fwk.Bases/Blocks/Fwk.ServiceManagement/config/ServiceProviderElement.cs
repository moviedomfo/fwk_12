using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Fwk.Logging.Targets;
using System.Xml.Serialization;
using Fwk.Bases;

namespace Fwk.ConfigSection
{
    /// <summary>
    /// ConfigProvider . 
    /// </summary>
    /// <date>2010/09/02</date>
    /// <author>moviedo</author>
    public class ServiceProviderElement : ConfigurationElement
    {
        #region <constructor>
        /// <summary>
        /// 
        /// </summary>
        public ServiceProviderElement() { }
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
        /// Determina el tipo de origen de la metadata de sercvicios
        /// </summary>
        [ConfigurationProperty("type", IsRequired = true, IsKey = false)]
        public ServiceProviderType ProviderType
        {
            get
            {
                return (ServiceProviderType)this["type"];
            }
            set { this["type"] = value; }
        }



        /// <summary>
        /// Archivo contenedor de la configuracion
        ///  
        /// </summary>
        [ConfigurationProperty("sourceinfo", IsRequired = true, IsKey = false), StringValidator(InvalidCharacters = @"~!@#$%^&*[]{};'""|")]
        public string SourceInfo
        {
            get
            {
                return (string)this["sourceinfo"];
            }
            set { this["sourceinfo"] = value; }
        }

        /// <summary>
        /// Identificador de aplicacion para buscarlo en la base de datos
        /// </summary>
        [ConfigurationProperty("appid", IsRequired = true, IsKey = false), StringValidator(InvalidCharacters = @"~!@#$%^&*[]{};'""|")]
        public string ApplicationId
        {
            get
            {
                return (string)this["appid"];
            }
            set { this["appid"] = value; }
        }

        /// <summary>
        /// Proveedor de seguridad de usuarios reglas y roles, con la que ocorreran los servicios
        /// </summary>
        [ConfigurationProperty("securityProviderName", IsRequired = false, IsKey = false), StringValidator(InvalidCharacters = @"~!@#$%^&*[]{};'""|")]
        public string SecurityProviderName
        {
            get
            {
                return (string)this["securityProviderName"];
            }
            set { this["securityProviderName"] = value; }
        }


        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
    }

    /// <summary>
    /// entidad serializable auxiliar de ServiceProviderElement para uso de herramientas 
    /// </summary>
    [XmlInclude(typeof(MetadataProvider)), Serializable]
    public class MetadataProvider : BaseEntity
    {
        string _ApplicationId;

        /// <summary>
        /// 
        /// </summary>
        public string ApplicationId
        {
            get { return _ApplicationId; }
            set { _ApplicationId = value; }
        }
        string _Name;

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        string _ConfigProviderType;

        /// <summary>
        /// 
        /// </summary>
        public string ConfigProviderType
        {
            get { return _ConfigProviderType; }
            set { _ConfigProviderType = value; }
        }
        string _SecurityProviderName;

        /// <summary>
        /// 
        /// </summary>
        public string SecurityProviderName
        {
            get { return _SecurityProviderName; }
            set { _SecurityProviderName = value; }
        }
        string _SourceInfo;

        /// <summary>
        /// 
        /// </summary>
        public string SourceInfo
        {
            get { return _SourceInfo; }
            set { _SourceInfo = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public MetadataProvider()
        { }
        string _DefaultCulture = string.Empty;


        /// <summary>
        /// Reprecenta la cultura con la que trabajara el proveedor de configurador de servicios .- Este valor es utilizado y esta disponible 
        /// en cada servicio desde la capa SVC hacia abajo 
        /// 
        /// Estas son las formas de poder obtenerlo en las capas BackEnd:
        /// 
        /// string cultura = Fwk.ServiceManagement.ServiceMetadata.ProviderSection.GetProvider(providerName).DefaultCulture;
        /// string cultura = pServiceRequest.ContextInformation.DefaultCulture;
        /// 
        /// </summary>
        public string DefaultCulture { get { return _DefaultCulture; } }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        public MetadataProvider(ServiceProviderElement provider)
        {
            _ApplicationId = provider.ApplicationId;
            _ConfigProviderType = provider.ProviderType.ToString();
            _Name = provider.Name;
            _SourceInfo = provider.SourceInfo;
            _SecurityProviderName = provider.SecurityProviderName;
            //_DefaultCulture = provider.DefaultCulture;
        }
    }

    /// <summary>
    /// Información configurada en un dispatcher
    /// </summary>
    [XmlInclude(typeof(DispatcherInfo)), Serializable]
    public class DispatcherInfo : BaseEntity
    {
        /// <summary>
        /// Constructor. Inicializa diccionarios
        /// </summary>
        public DispatcherInfo()
        {
            MetadataProviders = new List<MetadataProvider>();
            AppSettings = new Fwk.ConfigSection.DictionarySettingList();
            CnnStringSettings = new Fwk.ConfigSection.DictionarySettingList();

        }
        /// <summary>
        /// Service Metadata Providers  configurados
        /// </summary>
        public List<MetadataProvider> MetadataProviders { get; set; }


        /// <summary>
        /// Todos los AppSettings configurados
        /// </summary>
        //[XmlArrayItem("AppSetting")]
        //[XmlArray("AppSettings")]
        public DictionarySettingList AppSettings
        {
            get;
            set;
        }
        /// <summary>
        /// Lista de cadenas de conección
        /// </summary>
        // [XmlArray("CnnStringSettings")]
        //[XmlArrayItem("CnnStringSetting")]
        public DictionarySettingList CnnStringSettings
        {
            get;
            set;
        }

        /// <summary>
        /// Cadena de coneccion que posee el dispatcher para obtener su entorno de configuracion. 
        /// spesifica donde esta registrada la instancia del dispatcher
        /// </summary>
        public string ServiceDispatcherConnection { get; set; }

        /// <summary>
        /// Nombre de instancia del dispatcher
        /// </summary>
        public string ServiceDispatcherName { get; set; }

        /// <summary>
        /// Ip donde esta correindo el servicio
        /// </summary>
        public string MachineIp { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class DictionarySettingList : List<DictionarySetting>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, string value)
        {
            this.Add(new DictionarySetting(key, value));
        }
    }

    [Serializable]
    public class DictionarySetting //: Fwk.Bases.BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public DictionarySetting(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public DictionarySetting()
        { }
        /// <summary>
        /// 
        /// </summary>
        public String Key { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String Value { get; set; }
    }

}