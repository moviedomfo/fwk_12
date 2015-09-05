using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Fwk.Bases;
using helper = Fwk.HelperFunctions;
using System.ComponentModel;

namespace Fwk.Cache.Test
{


    [XmlRoot("ClienteCollectionBE"), SerializableAttribute]
    public class ClienteCollectionBE :Entities<ClienteBE>  
    {
        /// <summary>
        /// Metodo estatico que retorna on objeto ClienteCollectionBE apartir de un xml.-
        /// </summary>
        /// <param name="pxml">String con el xml</param>
        /// <returns>ClienteCollectionBE</returns>
        public static ClienteCollectionBE GetClienteCollectionBE(String pxml)
        {
            return (ClienteCollectionBE)Entity.GetObjectFromXml(typeof(ClienteCollectionBE), pxml);
        }
    }


    [XmlInclude(typeof(ClienteBE)), Serializable]
    public class ClienteBE:Entity
    {  
       

        #region [Atributes]

        private int? _IdCliente;
        private DateTime? _FechaNacimiento ;
        private string _Nombre ;
        private string _Apellido;
        

        #endregion

        

        #region [Properties]

        public int? IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }

        [FwkHistoryAttribute("FechaNacimiento")]
        public DateTime? FechaNacimiento
        {
            get { return _FechaNacimiento; }
            set { _FechaNacimiento = value;  }
        }

        [FwkHistoryAttribute("Nombre")]
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        [FwkHistoryAttribute("Apellido")]
        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value;  }
        }
        private int? _Edad;
        [FwkHistoryAttribute("Edad")]
        public int? Edad
        {
            get { return _Edad; }
            set { _Edad = value;  }
        }

        #endregion


        /// <summary>
        /// Metodo estatico que retorna on objeto ClienteBE apartir de un xml.-
        /// </summary>
        /// <param name="pxml">String con el xml</param>
        /// <returns>ClienteBE</returns>
        public static ClienteBE GetClienteBE(String pxml)
        {
            return (ClienteBE)Entity.GetObjectFromXml(typeof(ClienteBE), pxml);
        }

    }
}
