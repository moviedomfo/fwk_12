using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Fwk.Xml
{
    /// <summary>
    /// Manejo de CData.
    /// </summary>
    /// <Author>moviedo</Author>
    /// <Date>28-12-2005</Date>
    [Serializable]
    public class CData : IXmlSerializable,ICloneable
    {

        private string text;
        /// <summary>
        /// 
        /// </summary>
        public CData()

        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public CData(string text)
        {

            this.text = text;

        }

        /// <summary>
        /// 
        /// </summary>
        public string Text
        {

            get { return text; }
             set {  text = value; }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        XmlSchema IXmlSerializable.GetSchema()
        {

            return null;

        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {

            this.text = reader.ReadString();
            reader.Read();
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {

            writer.WriteCData(this.text);

        }

        #region Statics

        /// <summary>
        /// Crea y agrega una seccion CDATA en un nodo.
        /// </summary>
        /// <param name="pnode">El nodo al que se le agregara la seccion CDATA.</param>
        public static void CDATASectionCreateAndAdd(XmlNode pnode)
        {
            CDATASectionCreateAndAdd(pnode, "");
        }

        /// <summary>
        /// Crea y agrega una seccion CDATA en un nodo.
        /// </summary>
        /// <param name="pnode">El nodo al que se le agregara la seccion CDATA.</param>
        /// <param name="pCDATASectionValue">El contenido de la seccion CDATA.</param>
        public static void CDATASectionCreateAndAdd(XmlNode pnode, string pCDATASectionValue)
        {
            XmlCDataSection wNewCDataSection = pnode.OwnerDocument.CreateCDataSection(pCDATASectionValue);
            pnode.AppendChild(wNewCDataSection);
        }
        #endregion


        #region ICloneable Members

        /// <summary>
        /// REaliza operacion clone
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new CData(this.text);
            
        }

        #endregion

        /// <summary>
        /// Sobreescrive tostring
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.text;
        }
    }

}
