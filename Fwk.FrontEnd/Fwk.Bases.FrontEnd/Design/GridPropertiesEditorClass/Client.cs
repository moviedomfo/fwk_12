using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;
namespace Fwk.Bases.FrontEnd.Controls.FwkGrid.Design
{
    [XmlRoot("ClienteCollection"), SerializableAttribute]
    public class ClienteCollection : Entities<Cliente>
    {
        #region [Methods]
        /// <summary>
        /// Metodo estatico que retorna un objeto ClienteBECollection apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>ClienteBECollection</returns>
        public static ClienteCollection GetClienteBECollectionFromXml(String pXml)
        {
            return ClienteCollection.GetFromXml<ClienteCollection>( pXml);
        }
        #endregion
    }

    [XmlInclude(typeof(Cliente)), Serializable]
    public class Cliente : Entity
    {
        #region [Private Members]
        private int? _IdCliente;
        private String _Nombre ;
        private String _Apellido;

        #endregion

        #region [Properties]

        #region [IdCliente]
        [XmlElement(ElementName = "IdCliente", DataType = "int")]
        public int? IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }
        #endregion
        #region [Nombre]
        [XmlElement(ElementName = "Nombre", DataType = "string")]
        public String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        #endregion
        #region [Apellido]
        [XmlElement(ElementName = "Apellido", DataType = "string")]
        public String Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }
        #endregion
        #endregion

        #region [Methods]
       

        public override string ToString()
        {
            return _Nombre;
        }
        #endregion
    }

}