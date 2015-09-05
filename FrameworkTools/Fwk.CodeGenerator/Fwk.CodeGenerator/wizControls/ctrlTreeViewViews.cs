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
    
    public partial class ctrlTreeViewViews : UserControl
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
        private Microsoft.SqlServer.Management.Smo.ViewCollection _Views;
        private Microsoft.SqlServer.Management.Smo.View _SelectedView = null;

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
        public Microsoft.SqlServer.Management.Smo.View SelectedView
        {
            get { return _SelectedView; }
       
        }
        /// <summary>
        /// Indica la tabla seleccionada en el arbol .-
        /// </summary>
        [Browsable(false)]
        public List<Microsoft.SqlServer.Management.Smo.View> CheckedViews
        {
            get { return GetCheckedViews(); }
       
        }
       

        
        /// <summary>
        /// 
        /// </summary>
        public ctrlTreeViewViews()
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

          
            
            if (_Views == null)
            {
                this.tvwChilds.Nodes.Clear();
              
                return;
            }
            if (_Views.Count == 0)
            {
                this.tvwChilds.Nodes.Clear();
                
                return;
            }

            TreeViewHelper.LoadTreeView(this.tvwChilds, _Views);

            _SelectedView = _Views[0];
      


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
                db.Views.Refresh();
               _Views = db.Views;
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
        List<Microsoft.SqlServer.Management.Smo.View> GetCheckedViews()
        {
            if (_Views == null) return null;

            List<Microsoft.SqlServer.Management.Smo.View> wTablesSelected = new List<Microsoft.SqlServer.Management.Smo.View>();
            foreach (TreeNode node in tvwChilds.Nodes)
            {
                if (node.Checked)
                    wTablesSelected.Add((Microsoft.SqlServer.Management.Smo.View)node.Tag);

            }

            return wTablesSelected;
        }


      

    

        #region [Events]

        private void tvwChilds_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node.Level == 0)
            {
                Microsoft.SqlServer.Management.Smo.View wTable = (Microsoft.SqlServer.Management.Smo.View)e.Node.Tag;
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
                if (e.Node.Parent.Text != _SelectedView.Name)
                {
                    
                    _SelectedView = (Microsoft.SqlServer.Management.Smo.View)e.Node.Parent.Tag;

                    lblTreeViewSelected.Text = _SelectedView.Name;
                    OnSelectObjectEvent();

                }

            }
        }

       

        private void tvwChilds_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (this.tvwChilds.SelectedNode == null) return;

            if (this.tvwChilds.SelectedNode.Level == 0)
            {
          
                _SelectedView = (Microsoft.SqlServer.Management.Smo.View )this.tvwChilds.SelectedNode.Tag;
                lblTreeViewSelected.Text = _SelectedView.Name;
              
                if (e.Node.Nodes.Count == 0)
                {
                    TreeViewHelper.LoadColumnsNodes(this.tvwChilds.SelectedNode, _SelectedView);
                    OnSelectObjectEvent();
                }

               
            }

            if (this.tvwChilds.SelectedNode.Level == 1)
            {
                lblTreeViewSelected.Text = _SelectedView.Name; //+ "." + this.tvwChilds.SelectedNode.Text.Substring(0, this.tvwChilds.SelectedNode.Text.IndexOf(" "));
            }
        }

      

       
        #endregion

       
    }
}
