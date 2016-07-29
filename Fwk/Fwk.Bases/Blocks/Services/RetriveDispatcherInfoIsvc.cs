
using Fwk.Bases;
using Fwk.ConfigSection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Fwk.Bases.ISVC
{
    [Serializable]
    public class RetriveDispatcherInfoReq : Request<RetriveDispatcherInfoParams>
    {
        public RetriveDispatcherInfoReq()
        {
            ServiceName = "RetriveDispatcherInfoSvc";
        }
    }
    public class RetriveDispatcherInfoParams : Entity
    {
        public Boolean IncludeAppSettings { get; set; }
        public Boolean IncludeCnnstSrings { get; set; }
        public Boolean IncludeMetadata { get; set; }
    }

    [Serializable]
    public class RetriveDispatcherInfoRes : Response<DispatcherInfoBE>
    {

    }

    public class DispatcherInfoBE : Entity
    {
        public DispatcherInfoBE()
        {
            Cnnstrings = new CnnstringBEList();
        }
        /// <summary>
        /// Lista de cadenas de conección
        /// </summary>
        public CnnstringBEList Cnnstrings { get; set; }
        public String WindowsServiceName { get; set; }
        public DateTime ServiceDate { get; set; }
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
        public string MachineIp { get; set;}

        /// <summary>
        /// Service Metadata Providers  configurados
        /// </summary>
        public List<Fwk.ConfigSection.MetadataProvider> MetadataProviders { get; set; }


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
    }

    public class CnnstringBEList : Entities<CnnstringBE> { }

    public class CnnstringBE : Entity
    {
        public CnnstringBE()
        { }
        public CnnstringBE(ConnectionStringSettings cnn)
        {
            Name = cnn.Name;
            ConnectionString = cnn.ConnectionString;
        }


        public String Name { get; set; }
        public String ConnectionString { get; set; }
    }
}
