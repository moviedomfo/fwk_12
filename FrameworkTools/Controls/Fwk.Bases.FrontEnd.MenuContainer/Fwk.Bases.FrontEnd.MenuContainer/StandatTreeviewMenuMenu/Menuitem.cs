using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using System.Xml.Serialization;
using System.Xml;
using System.Drawing;

namespace Fwk.Bases.FrontEnd.MenuContainer
{



    [XmlInclude(typeof(RootMenu)), Serializable]
    public class RootMenu : Entity
    {
        private MenuImageList _ImageList = new MenuImageList ();

        public MenuImageList MenuImageList
        {
            get { return _ImageList; }
            set { _ImageList = value; }
        }


        public static RootMenu GetRootMenuFromXml(String pXml)
        {
            return (RootMenu)Entity.GetObjectFromXml(typeof(RootMenu), pXml);
        }

        MenuItem _MenuItem = new MenuItem ();

        public MenuItem MenuItem
        {
            get { return _MenuItem; }
            set { _MenuItem = value; }
        }
    }


    [Serializable]
    public class MenuItem : Entity
    {
        private MenuImageList _ImageList = null;

        public MenuImageList MenuImageList
        {
            get { return _ImageList; }
            set { _ImageList = value; }
        }

        #region Declarations

        String _Category;

        public String Category
        {
            get { return _Category; }
            set { _Category = value; }
        }
        Boolean _Enabled = true;

        public Boolean Enabled
        {
            get { return _Enabled; }
            set { _Enabled = value; }
        }

        String _DisplayName;

        public String DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }

        String _AssemblyInfo;

        public String AssemblyInfo
        {
            get { return _AssemblyInfo; }
            set { _AssemblyInfo = value; }
        }


        String _ToolTipInfo;

        public String ToolTipInfo
        {
            get { return _ToolTipInfo; }
            set { _ToolTipInfo = value; }
        }

        String _FormName;

        public String FormName
        {
            get { return _FormName; }
            set { _FormName = value; }
        }

        private System.Byte[] m_NodeImage;
        [System.Xml.Serialization.XmlElementAttribute("NodeImage", DataType = "base64Binary")]
        public System.Byte[] NodeImage
        {
            get { return m_NodeImage; }
            set { m_NodeImage = value; }
        }

        private System.Byte[] m_NodeSelectedImage;
        [System.Xml.Serialization.XmlElementAttribute("NodeSelectedImage", DataType = "base64Binary")]
        public System.Byte[] NodeSelectedImage
        {
            get { return m_NodeSelectedImage; }
            set { m_NodeSelectedImage = value; }
        }
        int m_NodeSelectedImageIndex;
        public int NodeSelectedImageIndex
        {
            get { return m_NodeSelectedImageIndex; }
            set { m_NodeSelectedImageIndex = value; }
        }

        int m_NodeImageIndexImageIndex;
        public int NodeImageIndex
        {
            get { return m_NodeImageIndexImageIndex; }
            set { m_NodeImageIndexImageIndex = value; }
        }

        //String _XmlChilds;

        //public String XmlChilds
        //{
        //    get { return _XmlChilds; }
        //    set
        //    {
        //        _XmlChilds = value;
        //        LoadMenuItemList();
        //    }
        //}
        MenuItemList _MenuItemList = new MenuItemList();

        public MenuItemList MenuItemList
        {
            get { return _MenuItemList; }
            set
            {
                _MenuItemList = value;
            }
        }
        #endregion

        //MenuItemList LoadMenuItemList()
        //{

        //    _MenuItemList = MenuItemList.GetMenuItemListFromXml(GetXmlChilds());

        //    return _MenuItemList;
        //}

        public void AddChild(MenuItem pMenuItemChild)
        {
            SearchEntityArg search = new SearchEntityArg("DisplayName", pMenuItemChild.DisplayName);

            if (_MenuItemList.FindAll(search).Count == 0)
                _MenuItemList.Add(pMenuItemChild);
            else
            {
                _MenuItemList.Remove(_MenuItemList.Find(search));
            }
        }

        //public void SetXmlChilds()
        //{
        //    _XmlChilds = "<![CDATA[" + _MenuItemList.GetXml() + "]]>";
        //}
        //string GetXmlChilds()
        //{
        //    string str;
        //    XmlDocument doc = Fwk.Xml.Document.DocumentCreateFromString("<root>" + _XmlChilds + "</root>");


        //    str = doc.FirstChild.InnerText;
        //    doc = null;
        //    return str;
        //}

        /// <summary>
        /// Metodo estatico que retorna un objeto MenuItem apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>Keys</returns>
        public static MenuItem GetMenuItemFromXml(String pXml)
        {
            return (MenuItem)Entity.GetObjectFromXml(typeof(MenuItem), pXml);
        }

    }

    /// <summary>
    /// Contiene las columnas de un objeto Table .-
    /// </summary>
    [XmlRoot("MenuItemList"), SerializableAttribute]
    public class MenuItemList : Entities<MenuItem>
    {
        /// <summary>
        /// Metodo estatico que retorna un objeto MenuItemList apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>Keys</returns>
        public static MenuItemList GetMenuItemListFromXml(String pXml)
        {
            return (MenuItemList)Entity.GetObjectFromXml(typeof(MenuItemList), pXml);
        }
    }


    [Serializable]
    public class MenuImage : Entity
    {

        int _Index;

        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }

        


        private System.Byte[] m_Image;
        [System.Xml.Serialization.XmlElementAttribute("Image", DataType = "base64Binary")]
        public System.Byte[] Image
        {
            get { return m_Image; }
            set { m_Image = value; }
        }
    }


    /// <summary>
    /// Contiene las imagenes del menu
    /// </summary>
    [XmlRoot("MenuImageList"), SerializableAttribute]
    public class MenuImageList : Entities<MenuImage>
    {
        /// <summary>
        /// Metodo estatico que retorna un objeto MenuImageList apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>Keys</returns>
        public static MenuImageList GetMenuImageListFromXml(String pXml)
        {
            return (MenuImageList)Entity.GetObjectFromXml(typeof(MenuImageList), pXml);
        }
    }

}
