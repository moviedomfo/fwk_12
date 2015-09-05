using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Bases.FrontEnd.MenuContainer
{
    public class TreeViewEngine
    {

        public static void Load(System.Windows.Forms.TreeView pTreeView, RootMenu pMenuItemRoot)
        {
            TreeNode wTreeNodeRoot = pTreeView.Nodes.Add(pMenuItemRoot.MenuItem.DisplayName);
            wTreeNodeRoot.Tag = pMenuItemRoot.MenuItem;
            LoadRecursive(wTreeNodeRoot, pMenuItemRoot.MenuItem.MenuItemList);
        }
        private static void  Load(System.Windows.Forms.TreeView pTreeView, MenuItem pMenuItemRoot)
        {
           TreeNode wTreeNodeRoot = pTreeView.Nodes.Add(pMenuItemRoot.DisplayName);
           wTreeNodeRoot.Tag = pMenuItemRoot;
           LoadRecursive(wTreeNodeRoot, pMenuItemRoot.MenuItemList);
        }

        static void LoadRecursive(TreeNode pTreeNodeRoot, MenuItemList pMenuItemChilds)
        {
            TreeNode wTreeNodeChild = null;
            foreach (MenuItem wMenuItem in pMenuItemChilds)
            {
                wTreeNodeChild = new TreeNode(wMenuItem.DisplayName);
                wTreeNodeChild.Tag = wMenuItem;

                pTreeNodeRoot.Nodes.Add(wTreeNodeChild);

                LoadRecursive(wTreeNodeChild, wMenuItem.MenuItemList);
            }
        }

        public static void SaveMenuToFile(String pFullFileName ,RootMenu pMenuItemRoot)
        {
            if (String.IsNullOrEmpty(pFullFileName)) return;
            Fwk.HelperFunctions.FileFunctions.SaveTextFile(pFullFileName, pMenuItemRoot.GetXml(),false);
        }

        public static RootMenu LoadMenuFromFile(String pFullFileName)
        {
            if (String.IsNullOrEmpty(pFullFileName)) return null;
            
            String xml = Fwk.HelperFunctions.FileFunctions.OpenTextFile(pFullFileName);

            return RootMenu.GetRootMenuFromXml(xml);


        }



        public static void Update(TreeNode pTreeNode, MenuItem pMenuItem)
        {
            pTreeNode.Tag = pMenuItem;
            pTreeNode.Text = pMenuItem.DisplayName;
        }
        public static void Create(TreeNode pTreeNodeParent, MenuItem pMenuItemParent, MenuItem pMenuItem)
        {
            pMenuItemParent.AddChild(pMenuItem);

            TreeNode wTreeNodeChild = new TreeNode(pMenuItem.DisplayName);
            wTreeNodeChild.Tag = pMenuItem;
            pTreeNodeParent.Nodes.Add(wTreeNodeChild);
        }
    }
}
