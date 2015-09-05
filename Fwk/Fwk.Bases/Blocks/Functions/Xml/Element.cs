using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Fwk.Xml
{
    /// <summary>
    /// Manejo de XmlElement.
    /// </summary>
    /// <Author>moviedo</Author>
    /// <Date>28-12-2005</Date>
    public class Element
    {
        /// <summary>
        /// Crea un XmlElement.
        /// </summary>
        /// <param name="pdoc">XmlDocument que contendra el XmlElement.</param>
        /// <param name="pname">Nombre del XmlElement.</param>
        /// <param name="pvalue">Valor del XmlElement.</param>
        /// <returns>XmlElement</returns>
        public static XmlElement ElementCreateAndAdd(XmlDocument pdoc, string pname, string pvalue)
        {
            XmlElement elem = pdoc.CreateElement(pname);
            XmlCDataSection cdata = pdoc.CreateCDataSection(pvalue);
            elem.AppendChild(cdata);
            return (XmlElement) pdoc.AppendChild(elem);
        }

        /// <summary>
        /// Crea un XmlElement.
        /// </summary>
        /// <param name="pdoc">XmlDocument que contendra el XmlElement.</param>
        /// <param name="pname">Nombre del XmlElement.</param>
        /// <returns>XmlElement</returns>
        public static XmlElement ElementCreateAndAdd(XmlDocument pdoc, string pname)
        {
            XmlElement elem = pdoc.CreateElement(pname);
            return (XmlElement)pdoc.AppendChild(elem);
        }
    }
}
