using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Fwk.DataBase;

namespace Fwk.CodeGenerator
{
    public delegate void AfterCheckHandler();
    public partial class ctrlTreeViewTables : UserControl
    {
        public event AfterCheckHandler AfterCheckEvent;
        private void OnAfterCheckHandler()
        {
            if (AfterCheckEvent != null)
                AfterCheckEvent();
        }
        [Browsable(false)]
        public bool CheckBoxes
        {
            get { return this.tvwChilds.CheckBoxes; }
            set { this.tvwChilds.CheckBoxes = value; }
        }
        private TableCollection _Tables;
        private Table _SelectedTable = null;

        public  static event SelectElementHandler SelectElementHandler;
        public void OnSelectObjectEvent()
        {
            if (SelectElementHandler != null)
                SelectElementHandler();
        }

        /// <summary>
        /// Indica la tabla seleccionada en el arbol .-
        /// </summary>
        [Browsable(false)]
        public Table SelectedTable
        {
            get { return _SelectedTable; }
       
        }
        /// <summary>
        /// Indica la tabla seleccionada en el arbol .-
        /// </summary>
        [Browsable(false)]
        public List<Table> CheckedTables
        {
            get { return GetCheckedTables(); }
       
        }
       

        
        /// <summary>
        /// 
        /// </summary>
        public ctrlTreeViewTables()
        {

            InitializeComponent();
        }



        /// <summary>
        /// Metodo que permite cargar las tablas en el arbol.
        /// </summary>
        public void Populate(CnnString pCnn)
        {
            //if (_Tables == null)
                LoadTables(pCnn);

          
            
            if (_Tables == null)
            {
                this.tvwChilds.Nodes.Clear();
              
                return;
            }
            if (_Tables.Count == 0)
            {
                this.tvwChilds.Nodes.Clear();
                
                return;
            }

            TreeViewHelper.LoadTreeView(this.tvwChilds, _Tables);

            _SelectedTable = _Tables[0];
      


            lblTreeViewSelected.Text = String.Empty;

         
        }

       

        private void LoadTables(CnnString cnn)
        {
            SqlConnection sqlConnection = new SqlConnection(cnn.ToString());
            ServerConnection serverConnection = new ServerConnection(sqlConnection);

            try
            {
                Server wServer = new Server(serverConnection);
                Database db = new Database(wServer, cnn.InitialCatalog);
                db.Tables.Refresh();
                _Tables = db.Tables;
            }
            catch (Exception ex)
            {
                MessageBox.Show(HelperFunctions.GetAllMessageException(ex));
            }
        }

        /// <summary>
        /// Retorna las tablas seleccionadas en el tree view.-
        /// </summary>
        /// <returns></returns>
        List<Table> GetCheckedTables()
        {
            if (_Tables == null) return null;

            List<Table> wTablesSelected = new List<Table>();
            foreach (TreeNode node in tvwChilds.Nodes)
            {
                if (node.Checked)
                    wTablesSelected.Add((Table)node.Tag);

            }

            return wTablesSelected;
        }


      

    

        #region [Events]

        private void tvwChilds_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node.Level == 0)
            {
                Table wTable = (Table)e.Node.Tag;
                ///TODO: Ver Checked
                //wTable.Checked = e.Node.Checked;
                //if (wTable.IsColumnsLoaded == false)
                if(e.Node.Nodes.Count ==0)
                {
                    TreeViewHelper.LoadColumnsNodes(e.Node, wTable);
                    OnSelectObjectEvent();
                }

                this.tvwChilds.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvwChilds_AfterCheck);
                this.tvwChilds.BeforeCheck -= new TreeViewCancelEventHandler(this.tvwChilds_BeforeCheck);    
                TreeViewHelper.UncheckChildNodes(e.Node);
                this.tvwChilds.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwChilds_AfterCheck);
                this.tvwChilds.BeforeCheck += new TreeViewCancelEventHandler(this.tvwChilds_BeforeCheck);
                OnAfterCheckHandler();
            }

            if (e.Node.Level == 1)
            {
                Column wColumn = (Column)e.Node.Tag;
                //wColumn.Selected = e.Node.Checked;

                if (!TreeViewHelper.HasSelectedNodes(e.Node.Parent))
                {
                    e.Node.Parent.Checked = false;
                }
            }
           
        }
        private void tvwChilds_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            //Nivel de tablas
            if (e.Node.Level == 1)
            {
                if (e.Node.Parent.Text != _SelectedTable.Name)
                {
                    
                    _SelectedTable = (Table)e.Node.Parent.Tag;

                    lblTreeViewSelected.Text = _SelectedTable.Name;
                    OnSelectObjectEvent();

                }

            }
        }

       

        private void tvwChilds_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (this.tvwChilds.SelectedNode == null) return;

            if (this.tvwChilds.SelectedNode.Level == 0)
            {
          
                _SelectedTable = (Table)this.tvwChilds.SelectedNode.Tag;
                lblTreeViewSelected.Text = _SelectedTable.Name;
              
                if (e.Node.Nodes.Count == 0)
                {
                    TreeViewHelper.LoadColumnsNodes(this.tvwChilds.SelectedNode, _SelectedTable);
                    OnSelectObjectEvent();
                }

               
            }

            if (this.tvwChilds.SelectedNode.Level == 1)
            {
                lblTreeViewSelected.Text = _SelectedTable.Name; //+ "." + this.tvwChilds.SelectedNode.Text.Substring(0, this.tvwChilds.SelectedNode.Text.IndexOf(" "));
            }
        }

      

       
        #endregion

       
    }
}
