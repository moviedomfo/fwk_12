using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Fwk.Bases.FrontEnd.MenuContainer.EncuestaMenu
{
    [Serializable]
    public class MenuItemEncuesta:MenuItem
    {
        private System.Byte[] m_TypeImage;
        [System.Xml.Serialization.XmlElementAttribute("TypeImage", DataType = "base64Binary")]
        public System.Byte[] TypeImage
        {
            get { return m_TypeImage; }
            set { m_TypeImage = value; }
        }
        private int _ID;
        public int ID
        {get { return _ID; }
            set { _ID = value; }}
          private int _ParentID;
        public int ParentID
          {
              get { return _ParentID; }
            set { _ParentID = value; }}
  
    }
    [XmlRoot("MenuItemEncuestaList"), SerializableAttribute]
    public class MenuItemEncuestaList : Entities<MenuItemEncuesta>
    {
        /// <summary>
        /// Metodo estatico que retorna un objeto MenuItemEncuestaList apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>MenuItemEncuestaList</returns>
        public static MenuItemEncuestaList GetMenuItemEncuestaListFromXml(String pXml)
        {
            return (MenuItemEncuestaList)Entity.GetObjectFromXml(typeof(MenuItemEncuestaList), pXml);
        }
    }
}
