using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Fwk.Bases;
using helper = Fwk.HelperFunctions;



namespace Fwk.Bases.Test
{
    [XmlInclude(typeof(FacturaBE)), Serializable]
    public class FacturaBE : Entity
    {
        #region [Atributes]
        private ItemCollectionBE _ItemCollectionBE = new ItemCollectionBE();

        private DateTime? _FechaFactura;
        private string _NombreCliente;
        private int? _NumeroCliente;

        #endregion

        #region [Properties]
        [XmlElement(ElementName = "ItemCollectionBE")]
        public ItemCollectionBE ItemCollectionBE
        {
            get { return _ItemCollectionBE; }
            set { _ItemCollectionBE = value; }
        }

        [XmlElement(ElementName = "FechaFactura", DataType = "dateTime")]
        public DateTime? FechaFactura
        {
            get { return _FechaFactura; }
            set { _FechaFactura = value; }
        }

        [XmlElement(ElementName = "NombreCliente", DataType = "string")]
        public string NombreCliente
        {
            get { return _NombreCliente; }
            set { _NombreCliente = value; }
        }


        [XmlElement(ElementName = "NumeroCliente", DataType = "int")]
        public int? NumeroCliente
        {
            get { return _NumeroCliente; }
            set { _NumeroCliente = value; }
        }

        #endregion

        
    }

    [XmlRoot("ItemCollectionBE"), SerializableAttribute]
    public class ItemCollectionBE : Entities<ItemBE>
    {
        
    }

    [XmlInclude(typeof(ItemBE)), Serializable]
    public class ItemBE : Entity
    {
        #region [Atributes]

        private string _Descripcion;
        private int? _Cantidad;

        #endregion

        #region [Properties]

        public ItemBE()
        {


        }


        [XmlElement(ElementName = "Descripcion", DataType = "string")]
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }



        [XmlElement(ElementName = "Cantidad", DataType = "int")]
        public int? Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        #endregion

       
    }
}
