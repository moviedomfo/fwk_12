namespace MultiLanguageManager
{
    partial class ucManageParams
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridControl_Params = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iRemoveParameter = new System.Windows.Forms.ToolStripMenuItem();
            this.iAddParameter = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoTipoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fwkParamBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView_Params = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colParamId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParentId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEnabled = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCulture = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.addNewKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Params)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fwkParamBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Params)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_Params
            // 
            this.gridControl_Params.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl_Params.ContextMenuStrip = this.contextMenuStrip2;
            this.gridControl_Params.DataSource = this.fwkParamBindingSource;
            this.gridControl_Params.Location = new System.Drawing.Point(7, 53);
            this.gridControl_Params.MainView = this.gridView_Params;
            this.gridControl_Params.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_Params.Name = "gridControl_Params";
            this.gridControl_Params.Size = new System.Drawing.Size(1295, 582);
            this.gridControl_Params.TabIndex = 1;
            this.gridControl_Params.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Params});
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iRemoveParameter,
            this.iAddParameter,
            this.nuevoTipoToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(207, 76);
            // 
            // iRemoveParameter
            // 
            this.iRemoveParameter.Name = "iRemoveParameter";
            this.iRemoveParameter.Size = new System.Drawing.Size(206, 24);
            this.iRemoveParameter.Text = "Eliminar parametro";
            this.iRemoveParameter.Click += new System.EventHandler(this.iRemoveParameter_Click);
            // 
            // iAddParameter
            // 
            this.iAddParameter.Name = "iAddParameter";
            this.iAddParameter.Size = new System.Drawing.Size(206, 24);
            this.iAddParameter.Text = "Nuevo parametro";
            this.iAddParameter.Click += new System.EventHandler(this.iAddParameter_Click);
            // 
            // nuevoTipoToolStripMenuItem
            // 
            this.nuevoTipoToolStripMenuItem.Name = "nuevoTipoToolStripMenuItem";
            this.nuevoTipoToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.nuevoTipoToolStripMenuItem.Text = "Nuevo tipo";
            // 
            // fwkParamBindingSource
            // 
            this.fwkParamBindingSource.DataSource = typeof(MultiLanguageManager.fwk_Param);
            // 
            // gridView_Params
            // 
            this.gridView_Params.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridView_Params.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView_Params.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colParamId,
            this.colParentId,
            this.colName,
            this.colDescription,
            this.colEnabled,
            this.colCulture,
            this.colId});
            this.gridView_Params.GridControl = this.gridControl_Params;
            this.gridView_Params.GroupCount = 1;
            this.gridView_Params.Name = "gridView_Params";
            this.gridView_Params.OptionsCustomization.AllowFilter = false;
            this.gridView_Params.OptionsFind.AlwaysVisible = true;
            this.gridView_Params.OptionsMenu.EnableColumnMenu = false;
            this.gridView_Params.OptionsMenu.EnableFooterMenu = false;
            this.gridView_Params.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Standard;
            this.gridView_Params.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colParentId, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView_Params.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_Params_CellValueChanged);
            this.gridView_Params.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView_Params_MouseDown);
            // 
            // colParamId
            // 
            this.colParamId.FieldName = "ParamId";
            this.colParamId.GroupFormat.FormatString = "{0} {1}";
            this.colParamId.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colParamId.Name = "colParamId";
            this.colParamId.OptionsColumn.AllowEdit = false;
            this.colParamId.Visible = true;
            this.colParamId.VisibleIndex = 1;
            this.colParamId.Width = 80;
            // 
            // colParentId
            // 
            this.colParentId.FieldName = "ParentId";
            this.colParentId.Name = "colParentId";
            this.colParentId.OptionsColumn.AllowEdit = false;
            this.colParentId.Visible = true;
            this.colParentId.VisibleIndex = 0;
            this.colParentId.Width = 100;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 260;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 3;
            this.colDescription.Width = 260;
            // 
            // colEnabled
            // 
            this.colEnabled.FieldName = "Enabled";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.OptionsColumn.AllowEdit = false;
            this.colEnabled.Visible = true;
            this.colEnabled.VisibleIndex = 5;
            this.colEnabled.Width = 457;
            // 
            // colCulture
            // 
            this.colCulture.FieldName = "Culture";
            this.colCulture.Name = "colCulture";
            this.colCulture.Visible = true;
            this.colCulture.VisibleIndex = 4;
            this.colCulture.Width = 80;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 41;
            // 
            // addNewKeyToolStripMenuItem
            // 
            this.addNewKeyToolStripMenuItem.Name = "addNewKeyToolStripMenuItem";
            this.addNewKeyToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // ucManageParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl_Params);
            this.Name = "ucManageParams";
            this.Size = new System.Drawing.Size(1305, 639);
            this.Load += new System.EventHandler(this.ucManageParams_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Params)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fwkParamBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Params)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Params;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Params;
        private System.Windows.Forms.BindingSource fwkParamBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colParamId;
        private DevExpress.XtraGrid.Columns.GridColumn colParentId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colEnabled;
        private DevExpress.XtraGrid.Columns.GridColumn colCulture;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem iRemoveParameter;
        private System.Windows.Forms.ToolStripMenuItem iAddParameter;
        private System.Windows.Forms.ToolStripMenuItem addNewKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoTipoToolStripMenuItem;
    }
}
