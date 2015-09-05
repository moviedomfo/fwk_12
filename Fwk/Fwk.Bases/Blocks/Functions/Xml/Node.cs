using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Fwk.Xml
{
    /// <summary>
    /// Manejo de XmlNode.
    /// </summary>
    /// <Author>moviedo</Author>
    /// <Date>28-12-2005</Date>
    public class Node
    {
        /// <summary>
        /// Crea y agrega un nodo a otro nodo.
        /// </summary>
        /// <param name="pnode">El nodo al cual se agregara un nuevo nodo.</param>
        /// <param name="pnewNodeName">El nombre del nuevo nodo.</param>
        /// <returns>El nodo creado.</returns>
        public static XmlNode NodeCreateAndAdd(XmlNode pnode, string pnewNodeName)
        {
            return NodeCreateAndAdd(pnode, pnewNodeName, "");
        }

        /// <summary>
        /// Crea y agrega un nodo a otro nodo.
        /// </summary>
        /// <param name="pnode">El nodo al cual se agregara un nuevo nodo.</param>
        /// <param name="pnewNodeName">El nombre del nuevo nodo.</param>
        /// <param name="pnewNodeValue">El valor del nuevo nodo.</param>
        /// <returns>El nodo creado.</returns>
        public static XmlNode NodeCreateAndAdd(XmlNode pnode, string pnewNodeName, string pnewNodeValue)
        {
            XmlNode wNewNode = pnode.OwnerDocument.CreateNode(XmlNodeType.Element, pnewNodeName, "");
            wNewNode.InnerText = pnewNodeValue;
            return pnode.AppendChild(wNewNode);
        }

        /// <summary>
        /// Crea y agrega un nodo a otro a partir de una definicion xml.
        /// </summary>
        /// <returns>El nodo creado.</returns>
        /// <param name="pnode">El nodo al que se le agregara el nuevo nodo.</param>
        /// <param name="pnewNodeXmlString">La definicion xml para el nuevo nodo.</param>
        public static XmlNode NodeCreateAndAddFromString(XmlNode pnode, string pnewNodeXmlString)
        {
            XmlDocument wDocument = new XmlDocument();
            try
            {
                wDocument.LoadXml(pnewNodeXmlString);
                return pnode.AppendChild(pnode.OwnerDocument.ImportNode(wDocument.DocumentElement, true));
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Crea y agrega un nodo a otro a partir de una definicion xml.
        /// </summary>
        /// <returns>El nodo creado.</returns>
        /// <param name="pnode">El nodo al que se le agregara el nuevo nodo.</param>
        /// <param name="pnewNodeXmlFilePath">La definicion xml para el nuevo nodo.</param>
        public static XmlNode NodeCreateAndAddFromFilePath(XmlNode pnode, string pnewNodeXmlFilePath)
        {
            XmlDocument wDocument = new XmlDocument();
            XmlNode wNode = null;
            try
            {
                wDocument.Load(pnewNodeXmlFilePath);
                wNode = wDocument.DocumentElement.CloneNode(true);
                return pnode.AppendChild(pnode.OwnerDocument.ImportNode(wNode, true));
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Retorna un nodo ubicado en un determinado xpath.
        /// </summary>
        /// <param name="pnode">El nodo padre.</param>
        /// <param name="pxPath">La ubicacion dentro del nodo padre.</param>
        /// <returns>El nodo buscado.</returns>
         public static XmlNode NodeGet(XmlNode pnode, string pxPath)
        {
            if (pxPath.Trim() == "")
            {
                return null;
            }

            if (pnode.SelectSingleNode(pxPath) == null)
            {
                return null;
            }

            return pnode.SelectSingleNode(pxPath);
        }

        /// <summary>
        /// Retorna el contenido de un nodo como texto.
        /// </summary>
        /// <param name="pnode">El nodo padre.</param>
        /// <param name="pxPath">La ubicacion dentro del nodo padre.</param>
        /// <returns>Contenido del nodo en texto.</returns>
        public static string NodeValueGetString(XmlNode pnode, string pxPath)
        {
            if (pnode == null)
            {
                return String.Empty;
            }

            if (pxPath.Trim().Length == 0)
            {
                return pnode.InnerText;
            }

            if (pnode.SelectSingleNode(pxPath) == null)
            {
                return String.Empty;
            }

            return pnode.SelectSingleNode(pxPath).InnerText;
        }

        /// <summary>
        /// Retorna el contenido de un nodo como entero.
        /// </summary>
        /// <param name="pnode">El nodo padre.</param>
        /// <param name="pxPath">La ubicacion dentro del nodo padre.</param>
        /// <returns>Contenido del nodo en entero.</returns>
        public static int NodeValueGetInt(XmlNode pnode, string pxPath)
        {
            string wNodeValue = NodeValueGetString(pnode, pxPath);

            return wNodeValue == "" ? 0 : Convert.ToInt32(wNodeValue);
        }

        /// <summary>
        /// Retorna el contenido de un nodo como double.
        /// </summary>
        /// <param name="pnode">El nodo padre.</param>
        /// <param name="pxPath">La ubicacion dentro del nodo padre.</param>
        /// <returns>Contenido del nodo en double.</returns>
        public static double NodeValueGetDouble(XmlNode pnode, string pxPath)
        {
            string wNodeValue = NodeValueGetString(pnode, pxPath);

            return wNodeValue == "" ? 0 : Convert.ToDouble(wNodeValue);
        }

        /// <summary>
        /// Retorna el contenido de un nodo como DateTime.
        /// </summary>
        /// <param name="pnode">El nodo padre.</param>
        /// <param name="pxPath">La ubicacion dentro del nodo padre.</param>
        /// <returns>Contenido del nodo en DateTime.</returns>
        public static DateTime NodeValueGetDateTime(XmlNode pnode, string pxPath)
        {
            string wNodeValue = NodeValueGetString(pnode, pxPath);

            return Convert.ToDateTime(wNodeValue);
        }

        /// <summary>
        /// Retorna el contenido de un nodo como booleano.
        /// </summary>
        /// <param name="pnode">El nodo padre.</param>
        /// <param name="pxPath">La ubicacion dentro del nodo padre.</param>
        /// <returns>Contenido del nodo en booleano.</returns>
        public static bool NodeValueGetBool(XmlNode pnode, string pxPath)
        {
            string wResult = NodeValueGetString(pnode, pxPath).ToUpper();

            switch (wResult)
            {
                case "TRUE":
                    {
                        return true;
                    }
                case "FALSE":
                    {
                        return false;
                    }
            }
            return Convert.ToBoolean(NodeValueGetInt(pnode, pxPath));
        }

        /// <summary>
        /// Setea el valor de un nodo preexistente.
        /// </summary>
        /// <param name="pnode">El nodo padre.</param>
        /// <param name="pxPath">La ubicacion dentro del nodo padre.</param>
        /// <param name="pnodeValue">El valor a setear.</param>
        public static void NodeValueSet(XmlNode pnode, string pxPath, string pnodeValue)
        {
            if (pnode == null)
            {
                return;
            }

            if (pxPath.Trim().Length == 0)
            {
                pnode.InnerText = pnodeValue;
            }

            if (pnode.SelectSingleNode(pxPath) == null)
            {
                return;
            }

            pnode.SelectSingleNode(pxPath).InnerText = pnodeValue;
        }
    }
}
