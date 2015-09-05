using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Bases
{
    /// <summary>
    /// este atributo se le establece las propiedades que implementan el patron undo redo.-
    ///<example>
    /// <para>El siguiente ejemplo muestra como utilizar el atributo HistoryAttribute :</para>
    /// <code>
    /// <![CDATA[
    ///    [XmlInclude(typeof(Cliente)), Serializable]
    ///    public class Cliente : Entity
    ///    {
    ///        #region [Private Members]
    ///        private System.Int32? _IdCliente;
    ///        private System.Int64? _CUIT;
    ///        private System.String _RazonSocial;
    ///        #endregion
    ///        #region [Properties]
    ///
    ///        #region [IdCliente]
    ///        [XmlElement(ElementName = "IdCliente", DataType = "int")]
    ///        public int? IdCliente
    ///        {
    ///            get { return _IdCliente; }
    ///            set { _IdCliente = value; }
    ///        }
    ///        #endregion
    ///
    ///        #region [CUIT]
    ///
    ///        public Int64? CUIT
    ///        {
    ///            get { return _CUIT; }
    ///            set { _CUIT = value; }
    ///        }
    ///        #endregion
    ///
    ///        #region [RazonSocial]
    ///        [XmlElement(ElementName = "RazonSocial", DataType = "string")]
    ///        public String RazonSocial
    ///        {
    ///            get { return _RazonSocial; }
    ///            set { _RazonSocial = value; }
    ///        }
    ///        #endregion
    ///
    ///        #region [NombreFantasia]
    ///        [HistoryAttribute("NombreFantasia")]
    ///        [XmlElement(ElementName = "NombreFantasia", DataType = "string")]
    ///        public String NombreFantasia
    ///        {
    ///            get { return _NombreFantasia; }
    ///            set { _NombreFantasia = value; }
    ///        }
    ///        #endregion
    ///
    ///        #endregion
    ///
    ///       #region [Methods]
    ///        /// <summary>
    ///        /// Metodo estatico que retorna un objeto Cliente apartir de un xml.-
    ///        /// </summary>
    ///        /// <param name="pXml">String con el xml</param>
    ///        /// <returns>Clientes</returns>
    ///        public static Cliente GetClientesFromXml(String pXml)
    ///        {
    ///            return (Cliente)Entity.GetObjectFromXml(typeof(Cliente), pXml);
    ///        }
    ///        #endregion
    ///    }
    ///    #endregion
    /// }
    /// ]]>
    /// </code> 
    ///</example>
    /// <Author>Marcelo .F. Oviedo</Author>  
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Property,Inherited=true)]
    public class HistoryAttribute : System.Attribute
    {
        #region  History
        

        //Entity _Parent;
        string _Name = string.Empty;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public HistoryAttribute(string pName)
        {
            object x = this.TypeId;
         
            _Name = pName;
           
        }

        #endregion
    }

   
}
