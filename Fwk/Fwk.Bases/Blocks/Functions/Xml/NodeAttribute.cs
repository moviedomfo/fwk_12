using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Fwk.Xml
{
    /// <summary>
    /// Manejo de Attribute.
    /// </summary>
    /// <Author>moviedo</Author>
    /// <Date>28-12-2005</Date>
    public class NodeAttribute
    {
        /// <summary>
        /// Retorna el valor de un atributo en un nodo.
        /// </summary>
        /// <param name="pnode">El nodo padre.</param>
        /// <param name="pxPath">La ubicacion dentro del nodo padre.</param>
        /// <param name="pattributeName">El nombre del atributo.</param>
        /// <returns>El valor del atributo.</returns>
        public static string AttributeGet(XmlNode pnode, string pxPath, string pattributeName)
        {
            if (pnode == null)
            {
                return String.Empty;
            }

            if (pxPath.Trim().Length > 0)
            {
                if (pnode.SelectSingleNode(pxPath) == null)
                {
                    return String.Empty;
                }
                else
                {
                    pnode = pnode.SelectSingleNode(pxPath);
                }
            }
            return AttributeGet(pnode, pattributeName);
        }

        /// <summary>
        /// Retorna el valor de un atributo en un nodo.
        /// </summary>
        /// <param name="pnode">El nodo que posee el atributo.</param>
        /// <param name="pattributeName">El nombre del atributo.</param>
        /// <returns>El valor del atributo.</returns>
        public static string AttributeGet(XmlNode pnode, string pattributeName)
        {
            if (pnode != null)
            {
                if (pnode.Attributes.Count > 0)
                {
                    if (pnode.Attributes.GetNamedItem(pattributeName) != null)
                    {
                        return pnode.Attributes.GetNamedItem(pattributeName).InnerText;
                    }
                }
            }
            return String.Empty;
        }

        /// <summary>
        /// Setea el valor de un atributo en un nodo.
        /// </summary>
        /// <param name="pnode">El nodo padre.</param>
        /// <param name="pxPath">La ubicacion dentro del nodo padre.</param>
        /// <param name="pattributeName">El nombre del atributo.</param>
        /// <param name="pattributeValue">El valor a setear en el atributo.</param>
        public static void AttributeSet(XmlNode pnode, string pxPath, string pattributeName, string pattributeValue)
        {
            if (pnode == null)
            {
                return;
            }

            if (pxPath.Trim().Length > 0)
            {
                if (pnode.SelectSingleNode(pxPath) == null)
                {
                    return;
                }
                else
                {
                    pnode = pnode.SelectSingleNode(pxPath);
                }
            }
            AttributeSet(pnode, pattributeName, pattributeValue);
        }

        /// <summary>
        /// Setea el valor de un atributo en un nodo.
        /// </summary>
        /// <param name="pnode">El nodo que posee el atributo.</param>
        /// <param name="pattributeName">El nombre del atributo.</param>
        /// <param name="pattributeValue">El valor a setear en el atributo.</param>
        public static void AttributeSet(XmlNode pnode, string pattributeName, string pattributeValue)
        {
            if (pnode != null)
            {
                if (pnode.Attributes.Count > 0)
                {
                    if (pnode.Attributes.GetNamedItem(pattributeName) != null)
                    {
                        pnode.Attributes.GetNamedItem(pattributeName).InnerText = pattributeValue;
                    }
                }
            }
        }

        /// <summary>
        /// Crea y setea el valor de un atributo en un nodo.
        /// </summary>
        /// <param name="pdoc">Documento del nodo que recibira el atributo.</param>
        /// <param name="pnode">El nodo que recibira el atributo.</param>
        /// <param name="pxPath">La ubicacion dentro del nodo padre.</param>
        /// <param name="pattributeName">El nombre del atributo.</param>
        /// <param name="pattributeValue">El valor a setear en el atributo.</param>
        public static void AttributeCreateAndSet(XmlDocument pdoc, XmlNode pnode, string pxPath, string pattributeName, string pattributeValue)
        {
            if (pnode != null)
            {
                XmlAttribute wAttribute = pdoc.CreateAttribute(pattributeName);
                wAttribute.Value = pattributeValue;

                if (pxPath.Trim().Length > 0)
                {
                    if (pnode.SelectSingleNode(pxPath) == null)
                    {
                        return;
                    }
                    else
                    {
                        pnode = pnode.SelectSingleNode(pxPath);
                    }
                }
                AttributeCreateAndSet(pdoc, pnode, pattributeName, pattributeValue);
            }
        }

        /// <summary>
        /// Crea y setea el valor de un atributo en un nodo.
        /// </summary>
        /// <param name="pdoc">Documento del nodo que recibira el atributo.</param>
        /// <param name="pnode">El nodo que recibira el atributo.</param>
        /// <param name="pattributeName">El nombre del atributo.</param>
        /// <param name="pattributeValue">El valor a setear en el atributo.</param>
        public static void AttributeCreateAndSet(XmlDocument pdoc, XmlNode pnode, string pattributeName, string pattributeValue)
        {
            if (pnode != null)
            {
                XmlAttribute wAttribute = pdoc.CreateAttribute(pattributeName);
                wAttribute.Value = pattributeValue;
                pnode.Attributes.Append(wAttribute);
            }
        }


    }
}
