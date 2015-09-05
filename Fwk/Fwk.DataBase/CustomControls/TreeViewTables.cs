using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Fwk.DataBase.DataEntities;

namespace Fwk.DataBase.CustomControls
{
    public partial class TreeViewTables :  TreeViewBase
    {
        private Tables _Tablas;
        private Table _SelectedTable = null;
        private string _SelectedTableName = String.Empty;

        /// <summary>
        /// Indica la tabla seleccionada en el arbol .-
        /// </summary>
        public Table SelectedTable
        {
            get { return _SelectedTable; }
            set { _SelectedTable = value; }
        }
        
        /// <summary>
        /// Indica el nombre de la tabla seleccionada en el arbol.-
        /// </summary>
        public string SelectedTableName
        {
            get { return _SelectedTableName; }
            set { _SelectedTableName = value; }
        }

        /// <summary>
        /// Conjunto de tablas en el arbol.-
        /// </summary>
        public Tables Tablas
        {
            get { return _Tablas; }
            set { _Tablas = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public TreeViewTables()
        {

            InitializeComponent();
        }



        /// <summary>
        /// Metodo que permite cargar las tablas en el arbol.
        /// </summary>
        public void LoadTreeView()
        {
            if (_Tablas == null)
                LoadFromDataBase();

            ProgressBar.Visible = true;
            ProgressBar.Maximum = _Tablas.Count + 1;
            ProgressBar.Value = 0;
            TreeViewHelper.AddElementEvent += new AddElementHandler(TreeViewHelper_AddElementEvent);

            lblTreeViewSelected.Text = "Generando arbol..";
            if (_Tablas == null)
            {
                this.tvwChilds.Nodes.Clear();
                TreeViewHelper.AddElementEvent -= new AddElementHandler(TreeViewHelper_AddElementEvent);
                return;
            }
            if (_Tablas.Count == 0)
            {
                this.tvwChilds.Nodes.Clear();
                TreeViewHelper.AddElementEvent -= new AddElementHandler(TreeViewHelper_AddElementEvent);
                return;
            }

            TreeViewHelper.LoadTreeView(this.tvwChilds, _Tablas);

            _SelectedTable = _Tablas[0];
            _SelectedTableName = _Tablas[0].Name;


            lblTreeViewSelected.Text = String.Empty;
            ProgressBar.Visible = false;
            TreeViewHelper.AddElementEvent -= new AddElementHandler(TreeViewHelper_AddElementEvent);
            ProgressBar.Value = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            this.tvwChilds.Nodes.Clear();
        
        }

        private void LoadFromDataBase()
        {
            lblTreeViewSelected.Text = "Cargando tables desde la base de datos..";
            ProgressBar.Visible = true;
            ProgressBar.Maximum = 10;

            Fwk.DataBase.Metadata Metadata = new Metadata();
            Metadata.AddElementEvent += new AddElementHandler(Metadata_AddElementEvent);
            Metadata.LoadTables();
            this._Tablas = Metadata.Tables;



            Metadata.AddElementEvent -= new AddElementHandler(Metadata_AddElementEvent);
        }

        /// <summary>
        /// Retorna las tablas seleccionadas en el tree view.-
        /// </summary>
        /// <returns></returns>
        public  Tables GetSelectedTables()
        {
            if (_Tablas == null) return null;

            Tables wTablesSelected = new Tables();
            foreach (Table wTable in _Tablas)
            {
               if(wTable.Checked )
                wTablesSelected.Add (_Tablas[ _Tablas.IndexOf(wTable)]);
                
            }

            return wTablesSelected;
        }


        private void TreeViewTables_Load(object sender, EventArgs e)
        {

        }

    

        #region [Events]

        private void tvwChilds_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node.Level == 0)
            {
                Table wTable = _Tablas.GetTable(e.Node.Text);
                wTable.Checked = e.Node.Checked;
                if (wTable.IsColumnsLoaded == false)
                {
                    TreeViewHelper.FillColumns(e.Node, wTable);
                    base.OnSelectObjectEvent();
                }

                this.tvwChilds.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvwChilds_AfterCheck);
                this.tvwChilds.BeforeCheck -= new TreeViewCancelEventHandler(this.tvwChilds_BeforeCheck);    
                TreeViewHelper.UncheckChildNodes(e.Node);
                this.tvwChilds.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwChilds_AfterCheck);
                this.tvwChilds.BeforeCheck += new TreeViewCancelEventHandler(this.tvwChilds_BeforeCheck);   
            }

            if (e.Node.Level == 1)
            {
                Column wColumn = _SelectedTable.Columns.GetColumn(e.Node.Tag.ToString());
                wColumn.Selected = e.Node.Checked;

                if (!TreeViewHelper.HasSelectedNodes(e.Node.Parent))
                {
                    e.Node.Parent.Checked = false;
                }
            }
        }
        private void tvwChilds_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                if (e.Node.Parent.Text != _SelectedTableName)
                {
                    _SelectedTableName = e.Node.Parent.Text;
                    _SelectedTable = _Tablas.GetTable(_SelectedTableName);
                    
                    lblTreeViewSelected.Text = _SelectedTableName;


                    base.OnSelectObjectEvent();

                }

            }
        }

       

        private void tvwChilds_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (this.tvwChilds.SelectedNode == null) return;

            if (this.tvwChilds.SelectedNode.Level == 0)
            {
                _SelectedTableName = this.tvwChilds.SelectedNode.Text;
                _SelectedTable = _Tablas.GetTable(_SelectedTableName);
                lblTreeViewSelected.Text = _SelectedTableName;
                if (_SelectedTable.IsColumnsLoaded == false)
                    TreeViewHelper.FillColumns(this.tvwChilds.SelectedNode, _SelectedTable);

                base.OnSelectObjectEvent();
            }

            if (this.tvwChilds.SelectedNode.Level == 1)
            {
                lblTreeViewSelected.Text = _SelectedTableName + "." + this.tvwChilds.SelectedNode.Text.Substring(0, this.tvwChilds.SelectedNode.Text.IndexOf(" "));
            }
        }

        void TreeViewHelper_AddElementEvent()
        {
            this.ProgressBar.Value++;
        }

        void Metadata_AddElementEvent()
        {
            if (this.ProgressBar.Value == this.ProgressBar.Maximum - 1)
                this.ProgressBar.Maximum++;

            this.ProgressBar.Value++;

        }
        #endregion

       
    }
}
