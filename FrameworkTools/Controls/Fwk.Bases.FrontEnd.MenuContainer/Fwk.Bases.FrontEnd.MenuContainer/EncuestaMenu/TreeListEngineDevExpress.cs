using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DevExpress.XtraTreeList;

namespace Fwk.Bases.FrontEnd.MenuContainer.EncuestaMenu
{
    class TreeListEngineDevExpress
    {
       
        public static void LoadFromFile(TreeList pTreeList, String pFullFileName)
        {
            if (!String.IsNullOrEmpty(pFullFileName))
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(pFullFileName);
                pTreeList.DataSource = dataSet.Tables[0].DefaultView;
                pTreeList.ExpandAll();
            }
        }
       

        public static void SaveMenuToFile(String pFullFileName, IEntity pMenuItemRoot)
        {
            if (String.IsNullOrEmpty(pFullFileName)) return;
            Fwk.HelperFunctions.FileFunctions.SaveTextFile(pFullFileName, pMenuItemRoot.GetXml(), false);
        }

        public static MenuItemEncuestaList LoadMenuFromFile(String pFullFileName)
        {
            //Application.StartupPath
            if (String.IsNullOrEmpty(pFullFileName)) return null;

            String xml = Fwk.HelperFunctions.FileFunctions.OpenTextFile(pFullFileName);

            return MenuItemEncuestaList.GetMenuItemEncuestaListFromXml(xml);

         
        }

       

        
    }
}
