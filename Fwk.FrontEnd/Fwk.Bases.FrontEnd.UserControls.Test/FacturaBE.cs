using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;
using Fwk.Bases.FrontEnd.Controls.FwkGrid;
namespace Fwk.Bases.FrontEnd.Controls.Test
{
    [XmlRoot("FacturaBECollection"), SerializableAttribute]
    public class FacturaBECollection : Entities<FacturaBE>
    {
        #region [Methods]
        /// <summary>
        /// Metodo estatico que retorna un objeto FacturaBECollection apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>FacturaBECollection</returns>
        public static FacturaBECollection GetFacturaBECollectionFromXml(String pXml)
        {
            return FacturaBECollection.GetFromXml<FacturaBECollection>( pXml);
        }
        #endregion
    }

    [XmlInclude(typeof(FacturaBE)), Serializable]
    public class FacturaBE : Entity
    {
        #region [Private Members]
        private int? m_IdFactura;
        private int? m_IdCliente;
        private DateTime? m_FechaFatura;
        private ClienteBE _ClienteBE;
       

      

        public FacturaBE()
        {
            _ClienteBE = new ClienteBE();
           
            
           
            
        }
        public ClienteBE ClienteBE
        {
            get { return _ClienteBE; }
            set { _ClienteBE = value; }
        }
        #endregion

        #region [Properties]

        #region [IdFactura]
        [XmlElement(ElementName = "IdFactura", DataType = "int")]
        public int? IdFactura
        {
            get { return m_IdFactura; }
            set { m_IdFactura = value; }
        }
        #endregion
        #region [IdCliente]
        [XmlElement(ElementName = "IdCliente", DataType = "int")]
        public int? IdCliente
        {
            get { return m_IdCliente; }
            set { m_IdCliente = value; }
        }
        #endregion
        #region [FechaFatura]
        [XmlElement(ElementName = "FechaFatura", DataType = "dateTime")]
        public DateTime? FechaFatura
        {
            get { return m_FechaFatura; }
            set { m_FechaFatura = value; }
        }
        #endregion
        #endregion

        #region [Methods]
        /// <summary>
        /// Metodo estatico que retorna un objeto FacturaBE apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>FacturaBE</returns>
        public static FacturaBE GetFacturaBEFromXml(String pXml)
        {
            return FacturaBE.GetFromXml < FacturaBE>(pXml);
        }
        #endregion
    }

}