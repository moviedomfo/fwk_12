using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Fwk.CodeGenerator
{
	internal  class ListViewCodeGen
	{
        /// <summary>
        /// Service[0]
        /// ...Table[1]
        /// .    ....Insert[2]
        /// .    .......Clases[3]
        /// .    ....Update[2]
        /// .    .......Clases[3]
        /// .
        /// </summary>
        /// <param name="pTreeNodeService"></param>
        internal static void ImageToServiceNode(TreeNode pTreeNodeService)
        {
            //[1]
            foreach (TreeNode wTableNode in pTreeNodeService.Nodes)
            {
                wTableNode.ImageIndex = wTableNode.TreeView.ImageList.Images.IndexOfKey("TableHS.png");
                //[2]
                foreach (TreeNode wMethodsNode in wTableNode.Nodes)
                {
                    //[3]
                    wMethodsNode.ImageIndex = wTableNode.TreeView.ImageList.Images.IndexOfKey("TortoiseInSubVersion.ico");
                    foreach (TreeNode wNodeClasss in wMethodsNode.Nodes)
                    {
                        if (wNodeClasss.Text.Substring(wNodeClasss.Text.Length-3,3)== "xsd")
                            wNodeClasss.ImageIndex = wTableNode.TreeView.ImageList.Images.IndexOfKey("Data_Schema.ico");
                        else
                            wNodeClasss.ImageIndex = wTableNode.TreeView.ImageList.Images.IndexOfKey("RefreshDocViewHS.bmp");
                    }
                }
            }

        }

        internal static void ImageToBackend(TreeNode treeNodeDAC)
        {
            //[1]
            foreach (TreeNode wTableNode in treeNodeDAC.Nodes)
            {
                wTableNode.ImageIndex = wTableNode.TreeView.ImageList.Images.IndexOfKey("vcs2005Black.PNG"); ;
            }
        }



        internal static void ImageToBackendSP(TreeNode treeNodeSP)
        {
            foreach (TreeNode wTableNode in treeNodeSP.Nodes)
            {
                wTableNode.ImageIndex = treeNodeSP.TreeView.ImageList.Images.IndexOfKey("TABLE.ICO");
                foreach (TreeNode wMethodNode in wTableNode.Nodes)
                {
                    wMethodNode.ImageIndex = treeNodeSP.TreeView.ImageList.Images.IndexOfKey("ShowRulelinesHS.bmp");

                }
            }
        }
    }
}
