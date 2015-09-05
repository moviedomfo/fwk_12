using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Fwk.Xml
{
    /// <summary>
    /// Manejo de XmlDocument.
    /// </summary>
    /// <Author>moviedo</Author>
    /// <Date>28-12-2005</Date>
    public class Document
    {
        /// <summary>
        /// Crea y retorna un XmlDocument a partir de una definicion xml.
        /// </summary>
        /// <param name="pxmlString">La definicion xml.</param>
        /// <returns>XmlDocument.</returns>
        public static XmlDocument DocumentCreateFromString(string pxmlString)
        {
            XmlDocument wDocument = new XmlDocument();
            try
            {
                wDocument.LoadXml(pxmlString);
                return wDocument;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Crea y retorna un XmlDocument a partir de un archivo xml en disco.
        /// </summary>
        /// <param name="pxmlFilePath">La ubicacion del archivo xml en disco.</param>
        /// <returns>XmlDocument.</returns>
        public static XmlDocument DocumentCreateFromFilePath(string pxmlFilePath)
        {
            XmlDocument wDocument = new XmlDocument();
            try
            {
                wDocument.Load(pxmlFilePath);
                return wDocument;
            }
            catch
            {
                return null;
            }
        }
    }
}
