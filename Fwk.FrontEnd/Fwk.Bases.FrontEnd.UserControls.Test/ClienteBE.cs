using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;
namespace Fwk.Bases.FrontEnd.Controls.Test
{
    [XmlRoot("ClienteBECollection"), SerializableAttribute]
    public class ClienteBECollection : Entities<ClienteBE>
    {
        #region [Methods]
        /// <summary>
        /// Metodo estatico que retorna un objeto ClienteBECollection apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>ClienteBECollection</returns>
        public static ClienteBECollection GetClienteBECollectionFromXml(String pXml)
        {
            return ClienteBECollection.GetFromXml<ClienteBECollection>( pXml);
        }
        #endregion
    }

    [XmlInclude(typeof(ClienteBE)), Serializable]
    public class ClienteBE : Entity
    {
        #region [Private Members]
        private int? m_IdCliente;
        private String m_Nombre = String.Empty;
        private String m_Apellido;
        private int m_IdTipoCliente;

        
        #endregion

        #region [Properties]

        #region [IdCliente]
        [XmlElement(ElementName = "IdCliente", DataType = "int")]
        public int? IdCliente
        {
            get { return m_IdCliente; }
            set { m_IdCliente = value; }
        }
        #endregion
        #region [Nombre]
        [XmlElement(ElementName = "Nombre", DataType = "string")]
        public String Nombre
        {
            get { return m_Nombre; }
            set { m_Nombre = value; }
        }
        #endregion
        #region [Apellido]
        [XmlElement(ElementName = "Apellido", DataType = "string")]
        public String Apellido
        {
            get { return m_Apellido; }
            set { m_Apellido = value; }
        }
        #endregion

        public int IdTipoCliente
        {
            get { return m_IdTipoCliente; }
            set { m_IdTipoCliente = value; }
        }
        #endregion

        #region [Methods]
        /// <summary>
        /// Metodo estatico que retorna un objeto ClienteBE apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>ClienteBE</returns>
        public static ClienteBE GetClienteBEFromXml(String pXml)
        {
            return ClienteBE.GetFromXml<ClienteBE>(pXml);
        }

        public override string ToString()
        {
            return m_Nombre;
        }
        #endregion
    }

}