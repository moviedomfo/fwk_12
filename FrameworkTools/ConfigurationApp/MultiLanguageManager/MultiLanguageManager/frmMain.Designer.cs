namespace MultiLanguageManager
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iRemoveParameter = new System.Windows.Forms.ToolStripMenuItem();
            this.iAddParameter = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl_config = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeSelectedsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView_config = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.ucManageParams1 = new MultiLanguageManager.ucManageParams();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_config)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_config)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iRemoveParameter,
            this.iAddParameter});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(207, 52);
            // 
            // iRemoveParameter
            // 
            this.iRemoveParameter.Name = "iRemoveParameter";
            this.iRemoveParameter.Size = new System.Drawing.Size(206, 24);
            this.iRemoveParameter.Text = "Eliminar parametro";
            // 
            // iAddParameter
            // 
            this.iAddParameter.Name = "iAddParameter";
            this.iAddParameter.Size = new System.Drawing.Size(206, 24);
            this.iAddParameter.Text = "Nuevo parametro";
            // 
            // gridControl_config
            // 
            this.gridControl_config.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl_config.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_config.Location = new System.Drawing.Point(0, 0);
            this.gridControl_config.MainView = this.gridView_config;
            this.gridControl_config.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_config.Name = "gridControl_config";
            this.gridControl_config.Size = new System.Drawing.Size(1176, 701);
            this.gridControl_config.TabIndex = 2;
            this.gridControl_config.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_config});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSelectedsToolStripMenuItem,
            this.addNewKeyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(250, 52);
            // 
            // removeSelectedsToolStripMenuItem
            // 
            this.removeSelectedsToolStripMenuItem.Name = "removeSelectedsToolStripMenuItem";
            this.removeSelectedsToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.removeSelectedsToolStripMenuItem.Text = "Eliminar propiedad";
            this.removeSelectedsToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedsToolStripMenuItem_Click);
            // 
            // addNewKeyToolStripMenuItem
            // 
            this.addNewKeyToolStripMenuItem.Name = "addNewKeyToolStripMenuItem";
            this.addNewKeyToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.addNewKeyToolStripMenuItem.Text = "Agregar nueva propiedad";
            this.addNewKeyToolStripMenuItem.Click += new System.EventHandler(this.addNewKeyToolStripMenuItem_Click);
            // 
            // gridView_config
            // 
            this.gridView_config.GridControl = this.gridControl_config;
            this.gridView_config.GroupRowHeight = 30;
            this.gridView_config.Name = "gridView_config";
            this.gridView_config.OptionsCustomization.AllowColumnMoving = false;
            this.gridView_config.OptionsFind.AlwaysVisible = true;
            this.gridView_config.OptionsSelection.UseIndicatorForSelection = false;
            this.gridView_config.RowHeight = 30;
            this.gridView_config.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView2_CellValueChanged);
            this.gridView_config.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView2_MouseDown);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(3, 5);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1182, 732);
            this.xtraTabControl1.TabIndex = 3;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage2,
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gridControl_config);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.PageVisible = false;
            this.xtraTabPage1.Size = new System.Drawing.Size(1176, 701);
            this.xtraTabPage1.Text = "Configs";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.ucManageParams1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1176, 701);
            this.xtraTabPage2.Text = "Params";
            // 
            // ucManageParams1
            // 
            this.ucManageParams1.AcceptButton = null;
            this.ucManageParams1.CancelButton = null;
            this.ucManageParams1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucManageParams1.Location = new System.Drawing.Point(0, 0);
            this.ucManageParams1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucManageParams1.Name = "ucManageParams1";
            this.ucManageParams1.Size = new System.Drawing.Size(1176, 701);
            this.ucManageParams1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 742);
            this.Controls.Add(this.xtraTabControl1);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Text = "Administrar lenguajes";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_config)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView_config)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_config;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_config;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedsToolStripMenuItem;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.ToolStripMenuItem addNewKeyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem iRemoveParameter;
        private System.Windows.Forms.ToolStripMenuItem iAddParameter;
        private ucManageParams ucManageParams1;

    }
}

