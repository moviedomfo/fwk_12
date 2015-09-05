using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using System.IO;
using System.Xml.Serialization;
using System.Xml;



namespace Fwk.GuidPk
{
    public delegate void SelectElementHandler(object e);
    public delegate void AfterCheckHandler();
    /// <summary>
    /// 
    /// </summary>
    public class TreeViewHelper
    {


       

        #region Tables
        /// <summary>
        /// Carga el arbol con todas las tablas .- 
        /// </summary>
        /// <param name="pTreeView">Nodo</param>
        /// <param name="pTables">Tablas</param>
        public static void LoadTreeView(TreeView pTreeView, SchemaCollectionBase pTables)
        {
            TreeNode wTreeNode;
            pTreeView.Nodes.Clear();    
            foreach (TableViewBase wTable in pTables)
            {
                wTreeNode = new TreeNode();
                wTreeNode.Checked = false;
                
                wTreeNode.Text = wTable.Name;
                wTreeNode.Tag = wTable;
                pTreeView.Nodes.Add(wTreeNode);
                //LoadColumnsNodes(wTreeNode, wTable);

                
            }
           
        }

        /// <summary>
        /// Carga las coluimnas al nodo pParentNode.-
        /// </summary>
        /// <param name="pParentNode">Nodo padre </param>
        /// <param name="pTable"></param>
        internal static void LoadColumnsNodes(TreeNode pParentNode, TableViewBase pTable)
        {
            TreeNode wTreeNode;
            foreach (Column wColumn in pTable.Columns)
            {

                String nullable = wColumn.Nullable ? "NULL" : String.Empty;

                wTreeNode = new TreeNode();
         
                wTreeNode.Checked = false;
                wTreeNode.Text = string.Concat(wColumn.Name, " ", wColumn.DataType.Name, " ", nullable);
                //wTreeNode.Tag = wColumn;
                wTreeNode.ImageIndex = 3;
                wTreeNode.SelectedImageIndex = 3;
                pParentNode.Nodes.Add(wTreeNode);
            }
        }

       

        #endregion

        //#region Store Procedures
        ///// <summary>
        ///// Carga el arbol con todas los Store Procedures .- 
        ///// </summary>
        ///// <param name="pTreeView">Nodo</param>
        ///// <param name="pStoreProcedures">StoreProcedures</param>
        //public static void LoadTreeView(TreeView pTreeView, Fwk_DataEntities.StoreProcedures pStoreProcedures)
        //{
        //    pTreeView.Nodes.Clear();
        //    foreach (Fwk_DataEntities.StoreProcedure wStoreProcedure in pStoreProcedures)
        //    {
        //        TreeNode wTreeNode = new TreeNode();
        //        wTreeNode.Checked = false;

        //        wTreeNode.Text = wStoreProcedure.Name;
        //        pTreeView.Nodes.Add(wTreeNode);
        //        LoadParameteresNodes(wTreeNode, wStoreProcedure);

        //        OnAddElementEvent();
        //    }

        //}

        ///// <summary>
        ///// Carga los parametros al nodo pParentNode  (StoreProcedure).-
        ///// </summary>
        ///// <param name="pParentNode">Nodo padre </param>
        ///// <param name="pStoreProcedure">Store Procedure</param>
        //private static void LoadParameteresNodes(TreeNode pParentNode, Fwk_DataEntities.StoreProcedure pStoreProcedure)
        //{

        //    foreach (Fwk_DataEntities.SPParameter wParameter in pStoreProcedure.Parameters)
        //    {
        //        TreeNode wTreeNode = new TreeNode();
        //        wTreeNode.Checked = false;
        //        wTreeNode.Text = wParameter.Type + " " + wParameter.Name;
        //        wTreeNode.Tag = wParameter.Name;
        //        wTreeNode.ImageIndex = 5;
        //        wTreeNode.SelectedImageIndex = 5;
        //        pParentNode.Nodes.Add(wTreeNode);
        //    }
        //}

        //internal static void FillParameters(TreeNode pTreeNodePadre, Fwk.DataBase.DataEntities.StoreProcedure pStoreProcedure)
        //{
        //    if (pStoreProcedure.IsParametersLoaded) return;

        //    Fwk_DataBase.Metadata wMetadata = new Metadata();

        //    wMetadata.StoreProcedures_FillParameters(pStoreProcedure);

        //    LoadParameteresNodes(pTreeNodePadre, pStoreProcedure);

        //}

        //#endregion


    

        /// <summary>
        /// Agrega un nodo a un nodo padre con información sobre una tabla relacionada a la que éste representa.
        /// </summary>
        /// <param name="pParentNode">Nodo padre.</param>
        /// <param name="pText">Texto a mostrar.</param>
        /// <date>2006-04-05T00:00:00</date>
        /// <author>Marcelo Oviedo</author>
        private static TreeNode AddChildNode(TreeNode pParentNode, string pText)
        {
            TreeNode wTreeNode = new TreeNode(pText);

            wTreeNode.Checked = false;
            wTreeNode.Tag = pText;
            pParentNode.Nodes.Add(wTreeNode);

            return wTreeNode;
        }




        /// <summary>
        /// Destilda los nodos hijos de un nodo padre.
        /// </summary>
        /// <param name="pNode">Nodo padre.</param>
        /// <date>2006-04-05T00:00:00</date>
        /// <author>Marcelo Oviedo</author>
        public static void UncheckChildNodes(TreeNode pNode)
        {
            Boolean Checked = pNode.Checked;

            foreach (TreeNode wNode in pNode.Nodes)
            {
                wNode.Checked = pNode.Checked;
                UncheckChildNodes(wNode);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ParentNode"></param>
        /// <returns></returns>
        public static bool HasSelectedNodes(TreeNode ParentNode)
        {
            Boolean wCheck = false;
            foreach (TreeNode child in ParentNode.Nodes)
            {
                if (child.Checked) wCheck = true;
            }

            return wCheck;
        }
    }



 

}
