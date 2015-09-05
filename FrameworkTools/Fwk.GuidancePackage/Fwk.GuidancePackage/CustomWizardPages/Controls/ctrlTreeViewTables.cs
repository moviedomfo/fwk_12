using System;
using System.Linq;
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

namespace Fwk.GuidPk
{
   
    public partial class ctrlTreeViewTables : UserControl
    {
        public event AfterCheckHandler AfterCheckEvent;
        public  event SelectElementHandler SelectElementHandler;
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
        private Table _Selected = null;

       
        public void OnSelectObjectEvent(object e)
        {
            if (SelectElementHandler != null)
                SelectElementHandler(e);
        }

        /// <summary>
        /// Indica la tabla seleccionada en el arbol .-
        /// </summary>
        [Browsable(false)]
        public Table SelectedTable
        {
            get { return _Selected; }
            set { _Selected = value; }
       
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

            _Selected = _Tables[0];
      


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
                MessageBox.Show(Fwk.CodeGenerator.HelperFunctions.GetAllMessageException(ex));
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
                    OnSelectObjectEvent(wTable);
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
                if (e.Node.Parent.Text != _Selected.Name)
                {
                    
                    _Selected = (Table)e.Node.Parent.Tag;

                    lblTreeViewSelected.Text = _Selected.Name;
                    OnSelectObjectEvent(_Selected);

                }

            }
        }

       

        private void tvwChilds_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (this.tvwChilds.SelectedNode == null) return;

            if (this.tvwChilds.SelectedNode.Level == 0)
            {
          
                _Selected = (Table)this.tvwChilds.SelectedNode.Tag;
                lblTreeViewSelected.Text = _Selected.Name;
              
                if (e.Node.Nodes.Count == 0)
                {
                    TreeViewHelper.LoadColumnsNodes(this.tvwChilds.SelectedNode, _Selected);
                    OnSelectObjectEvent(_Selected);
                }

               
            }

            if (this.tvwChilds.SelectedNode.Level == 1)
            {
                lblTreeViewSelected.Text = _Selected.Name; //+ "." + this.tvwChilds.SelectedNode.Text.Substring(0, this.tvwChilds.SelectedNode.Text.IndexOf(" "));
            }
        }

      

       
        #endregion

       
    }
}
