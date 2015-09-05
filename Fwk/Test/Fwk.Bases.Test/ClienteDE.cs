using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Fwk.Bases;
using helper = Fwk.HelperFunctions;
using System.ComponentModel;

namespace Fwk.Bases.Test
{


    [XmlRoot("ClienteCollectionBE"), SerializableAttribute]
    public class ClienteCollectionBE :Entities<ClienteBE>  
    {
        
    }


    [XmlInclude(typeof(ClienteBE)), Serializable]
    public class ClienteBE:Entity
    {  
       

        #region [Atributes]
        Direccion _Direccion = new Direccion  ();

      
        private int? _IdCliente;
        private DateTime? _FechaNacimiento ;
        private string _Nombre;
        private string _Apellido;
        private int? _Edad;

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
            set
            {
                _FechaNacimiento = value;
            }
        }

        [FwkHistoryAttribute("Nombre")]
        public string Nombre
        {
            get { return _Nombre; }
            set
            {
                _Nombre = value; }
        }


        [FwkHistoryAttribute("Apellido")]
        public string Apellido
        {
            get { return _Apellido; }
            set
            {
               
                _Apellido = value;  }
        }

        [FwkHistoryAttribute("Edad")]
        public int? Edad
        {
            get { return _Edad; }
            set            { _Edad = value;  }
        }


        Fwk.Xml.CData  _Historial;

        [XmlElement("Historial", Type = typeof(Fwk.Xml.CData))]
        public Fwk.Xml.CData Historial
        {
            get { return _Historial; }
            set
            {
                _Historial = value;
            }
        }
        #endregion
        [FwkHistoryAttribute("Direccion")]
        public Direccion Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }


    }
    [XmlInclude(typeof(Direccion)), Serializable]
    public class Direccion : Entity
    {
        string _Calle;

        public string Calle
        {
            get { return _Calle; }
            set { _Calle = value; }
        }
        int _Altura;

        public int Altura
        {
            get { return _Altura; }
            set { _Altura = value; }
        }
    
    }
}
