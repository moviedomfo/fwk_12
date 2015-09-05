using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Fwk.DataBase.DataEntities;
using Fwk.DataBase.CustomControls;

namespace Fwk.DataBase.CustomControls
{

    public partial class TreeViewStoreProcedures : TreeViewBase
    {

        private StoreProcedures _StoreProcedures;
        private StoreProcedure _SelectedStoreProcedure = null;

        /// <summary>
        /// Indica el StoreProcedure seleccionado en el arbol .-
        /// </summary>
        public StoreProcedure SelectedStoreProcedure
        {
            get { return _SelectedStoreProcedure; }
            set { _SelectedStoreProcedure = value; }
        }

        private string _SelectedStoreProcedureName = String.Empty;

        /// <summary>
        /// Indica el nombre de la StoreProcedure seleccionado en el arbol.-
        /// </summary>
        public string SelectedStoreProcedureName
        {
            get { return _SelectedStoreProcedureName; }
            set { _SelectedStoreProcedureName = value; }
        }

        /// <summary>
        /// Conjunto de StoreProcedures en el arbol.-
        /// </summary>
        public StoreProcedures StoreProcedures
        {
            get { return _StoreProcedures; }
            set { _StoreProcedures = value; }
        }
        /// <summary>
        /// Construtor TreeViewStoreProcedures .-
        /// </summary>
        public TreeViewStoreProcedures()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Metodo que permite cargar los StoreProcedures en el arbol.
        /// </summary>
        public void LoadTreeView()
        {
            if (_StoreProcedures == null)
                LoadFromDataBase();

            ProgressBar.Visible = true;
            ProgressBar.Maximum = _StoreProcedures.Count + 1;
            ProgressBar.Value = 0;
            TreeViewHelper.AddElementEvent += new AddElementHandler(TreeViewHelper_AddElementEvent);

            lblTreeViewSelected.Text = "Generando arbol..";
            if (_StoreProcedures == null)
            {
                this.tvwChilds.Nodes.Clear();
                TreeViewHelper.AddElementEvent -= new AddElementHandler(TreeViewHelper_AddElementEvent);
                return;
            }
            if (_StoreProcedures.Count == 0)
            {
                this.tvwChilds.Nodes.Clear();
                TreeViewHelper.AddElementEvent -= new AddElementHandler(TreeViewHelper_AddElementEvent);
                return;
            }

            TreeViewHelper.LoadTreeView(this.tvwChilds, _StoreProcedures);

            _SelectedStoreProcedure = _StoreProcedures[0];
            _SelectedStoreProcedureName = _StoreProcedures[0].Name;


            lblTreeViewSelected.Text = String.Empty;
            ProgressBar.Visible = false;

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
            lblTreeViewSelected.Text = "Cargando StoreProcedure desde la base de datos..";
            ProgressBar.Visible = true;
            ProgressBar.Maximum = 10;

            Fwk.DataBase.Metadata Metadata = new Metadata();
            Metadata.AddElementEvent += new AddElementHandler(Metadata_AddElementEvent);
            Metadata.LoadStoreProcedures();
            this._StoreProcedures = Metadata.StoreProcedures;



            Metadata.AddElementEvent -= new AddElementHandler(Metadata_AddElementEvent);
        }
        /// <summary>
        /// Retorna los StoreProcedures seleccionados en el tree view.-
        /// </summary>
        /// <returns></returns>
        public StoreProcedures GetSelectedStoreProcedures()
        {
            StoreProcedures wStoreProceduresSelected = new StoreProcedures();
            foreach (StoreProcedure wStoreProcedure in _StoreProcedures)
            {

                if (wStoreProcedure.Checked)
                    wStoreProceduresSelected.Add(_StoreProcedures[_StoreProcedures.IndexOf(wStoreProcedure)]);

            }

            return wStoreProceduresSelected;
        }
        #region [Events]
        private void tvwChilds_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node.Level == 0)
            {
                StoreProcedure wStoreProcedure = _StoreProcedures.GetStoreProcedure(e.Node.Text);
                wStoreProcedure.Checked = e.Node.Checked;
                if (wStoreProcedure.IsParametersLoaded == false)
                {
                    TreeViewHelper.FillParameters(e.Node, wStoreProcedure);
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
                SPParameter wSPParameter = _SelectedStoreProcedure.Parameters.GetSPParameter(e.Node.Tag.ToString());
                wSPParameter.Selected = e.Node.Checked;
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
                if (e.Node.Parent.Text != _SelectedStoreProcedureName)
                {
                    _SelectedStoreProcedureName = e.Node.Parent.Text;
                    _SelectedStoreProcedure = _StoreProcedures.GetStoreProcedure(_SelectedStoreProcedureName);
                    lblTreeViewSelected.Text = _SelectedStoreProcedureName;


                    base.OnSelectObjectEvent();
                }
            }
        }

        private void tvwChilds_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (this.tvwChilds.SelectedNode == null) return;

            if (this.tvwChilds.SelectedNode.Level == 0)
            {
                _SelectedStoreProcedureName = this.tvwChilds.SelectedNode.Text;
                _SelectedStoreProcedure = _StoreProcedures.GetStoreProcedure(_SelectedStoreProcedureName);
                lblTreeViewSelected.Text = _SelectedStoreProcedureName;
                if (_SelectedStoreProcedure.IsParametersLoaded == false)
                    TreeViewHelper.FillParameters(this.tvwChilds.SelectedNode, _SelectedStoreProcedure);

                OnSelectObjectEvent();
            }

            if (this.tvwChilds.SelectedNode.Level == 1)
            {
                lblTreeViewSelected.Text = _SelectedStoreProcedureName + "." + this.tvwChilds.SelectedNode.Text.Substring(0, this.tvwChilds.SelectedNode.Text.IndexOf(" "));
            }
        }

        void TreeViewHelper_AddElementEvent()
        {
            if (this.ProgressBar.ProgressBar != null && this.ProgressBar.Value < this.ProgressBar.Maximum)
                this.ProgressBar.Value++;
        }

        void Metadata_AddElementEvent()
        {
            if (this.ProgressBar.ProgressBar == null)
                return;

            if (this.ProgressBar.Value == this.ProgressBar.Maximum - 1)
                this.ProgressBar.Maximum++;

            this.ProgressBar.Value++;

        }
        #endregion



    }
}
