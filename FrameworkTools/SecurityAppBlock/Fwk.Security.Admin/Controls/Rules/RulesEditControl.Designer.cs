namespace Fwk.Security.Admin.Controls
{
    partial class RulesEditControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RulesEditControl));
            DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition();
            DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition();
            this.colImg = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lbltitle = new System.Windows.Forms.Label();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.contextMenu_Categories = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mAddNewCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.mRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.addRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRootcategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryTreeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grdAllRules = new DevExpress.XtraGrid.GridControl();
            this.contextMenu_Rules = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mDeleteRule = new System.Windows.Forms.ToolStripMenuItem();
            this.mCreateRuele = new System.Windows.Forms.ToolStripMenuItem();
            this.mUpdateRule = new System.Windows.Forms.ToolStripMenuItem();
            this.fwkAuthorizationRuleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView_AllRules = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblCurrentCategory = new DevExpress.XtraEditors.LabelControl();
            this.lblSelectedRule = new DevExpress.XtraEditors.LabelControl();
            this.btnAddNewRule = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.contextMenu_Categories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryTreeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllRules)).BeginInit();
            this.contextMenu_Rules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fwkAuthorizationRuleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_AllRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // colImg
            // 
            this.colImg.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colImg.FieldName = "IsCategory";
            this.colImg.MinWidth = 33;
            this.colImg.Name = "colImg";
            this.colImg.OptionsColumn.AllowEdit = false;
            this.colImg.OptionsColumn.ReadOnly = true;
            this.colImg.Visible = true;
            this.colImg.VisibleIndex = 0;
            this.colImg.Width = 76;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", true, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", false, 3)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.ReadOnly = true;
            this.repositoryItemImageComboBox1.SmallImages = this.imageList1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder-closed_16.png");
            this.imageList1.Images.SetKeyName(1, "folder-open_16.png");
            this.imageList1.Images.SetKeyName(2, "admin_16.png");
            this.imageList1.Images.SetKeyName(3, "del_16.ico");
            // 
            // lbltitle
            // 
            this.lbltitle.BackColor = System.Drawing.Color.White;
            this.lbltitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbltitle.Location = new System.Drawing.Point(0, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(1032, 42);
            this.lbltitle.TabIndex = 20;
            this.lbltitle.Text = "Edit rules";
            this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // treeList1
            // 
            this.treeList1.AllowDrop = true;
            this.treeList1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeList1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.treeList1.Appearance.FocusedCell.Options.UseFont = true;
            this.treeList1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colImg,
            this.colName});
            this.treeList1.ContextMenuStrip = this.contextMenu_Categories;
            this.treeList1.DataSource = this.categoryTreeBindingSource;
            this.treeList1.FixedLineWidth = 1;
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colImg;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = true;
            styleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.DimGray;
            styleFormatCondition2.Appearance.Options.UseForeColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.colImg;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = false;
            this.treeList1.FormatConditions.AddRange(new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2});
            this.treeList1.KeyFieldName = "Id";
            this.treeList1.Location = new System.Drawing.Point(558, 75);
            this.treeList1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsMenu.EnableColumnMenu = false;
            this.treeList1.OptionsMenu.EnableFooterMenu = false;
            this.treeList1.OptionsSelection.UseIndicatorForSelection = true;
            this.treeList1.OptionsView.AutoWidth = false;
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.ParentFieldName = "ParentId";
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.treeList1.RowHeight = 35;
            this.treeList1.Size = new System.Drawing.Size(423, 530);
            this.treeList1.StateImageList = this.imageList1;
            this.treeList1.TabIndex = 30;
            this.treeList1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeList1_DragDrop);
            this.treeList1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeList1_DragOver);
            this.treeList1.DragLeave += new System.EventHandler(this.treeList1_DragLeave);
            this.treeList1.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.treeList1_GiveFeedback);
            this.treeList1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeList1_KeyDown);
            this.treeList1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseClick);
            this.treeList1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseDown);
            this.treeList1.MouseLeave += new System.EventHandler(this.treeList1_MouseLeave);
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 33;
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 221;
            // 
            // contextMenu_Categories
            // 
            this.contextMenu_Categories.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAddNewCategory,
            this.mRemove,
            this.addRuleToolStripMenuItem,
            this.addRootcategoryToolStripMenuItem});
            this.contextMenu_Categories.Name = "contextMenuStrip1";
            this.contextMenu_Categories.Size = new System.Drawing.Size(203, 100);
            // 
            // mAddNewCategory
            // 
            this.mAddNewCategory.Image = global::Fwk.Security.Admin.Properties.Resources.folder_new_16;
            this.mAddNewCategory.Name = "mAddNewCategory";
            this.mAddNewCategory.Size = new System.Drawing.Size(202, 24);
            this.mAddNewCategory.Text = "Add sub-category";
            this.mAddNewCategory.Click += new System.EventHandler(this.mAddNewCategory_Click);
            // 
            // mRemove
            // 
            this.mRemove.Image = global::Fwk.Security.Admin.Properties.Resources.cancel_16;
            this.mRemove.Name = "mRemove";
            this.mRemove.Size = new System.Drawing.Size(202, 24);
            this.mRemove.Text = "Remove";
            this.mRemove.Click += new System.EventHandler(this.mRemove_Click);
            // 
            // addRuleToolStripMenuItem
            // 
            this.addRuleToolStripMenuItem.Image = global::Fwk.Security.Admin.Properties.Resources.admin_24;
            this.addRuleToolStripMenuItem.Name = "addRuleToolStripMenuItem";
            this.addRuleToolStripMenuItem.Size = new System.Drawing.Size(202, 24);
            this.addRuleToolStripMenuItem.Text = "Add rule";
            // 
            // addRootcategoryToolStripMenuItem
            // 
            this.addRootcategoryToolStripMenuItem.Image = global::Fwk.Security.Admin.Properties.Resources.Folder_2_Down;
            this.addRootcategoryToolStripMenuItem.Name = "addRootcategoryToolStripMenuItem";
            this.addRootcategoryToolStripMenuItem.Size = new System.Drawing.Size(202, 24);
            this.addRootcategoryToolStripMenuItem.Text = "Add root-category";
            this.addRootcategoryToolStripMenuItem.Click += new System.EventHandler(this.addRootcategoryToolStripMenuItem_Click);
            // 
            // categoryTreeBindingSource
            // 
            this.categoryTreeBindingSource.DataSource = typeof(Fwk.Security.Admin.CategoryTree);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(558, 46);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(91, 21);
            this.labelControl1.TabIndex = 32;
            this.labelControl1.Text = "Categories";
            // 
            // grdAllRules
            // 
            this.grdAllRules.AllowDrop = true;
            this.grdAllRules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdAllRules.ContextMenuStrip = this.contextMenu_Rules;
            this.grdAllRules.DataSource = this.fwkAuthorizationRuleBindingSource;
            this.grdAllRules.Location = new System.Drawing.Point(5, 75);
            this.grdAllRules.MainView = this.gridView_AllRules;
            this.grdAllRules.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdAllRules.Name = "grdAllRules";
            this.grdAllRules.Size = new System.Drawing.Size(453, 530);
            this.grdAllRules.TabIndex = 37;
            this.grdAllRules.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_AllRules,
            this.gridView4});
            this.grdAllRules.DragOver += new System.Windows.Forms.DragEventHandler(this.grdAllRules_DragOver);
            this.grdAllRules.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView_AllRules_MouseDown);
            this.grdAllRules.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridView_AllRules_MouseMove);
            // 
            // contextMenu_Rules
            // 
            this.contextMenu_Rules.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mDeleteRule,
            this.mCreateRuele,
            this.mUpdateRule});
            this.contextMenu_Rules.Name = "contextMenuStrip1";
            this.contextMenu_Rules.Size = new System.Drawing.Size(234, 76);
            // 
            // mDeleteRule
            // 
            this.mDeleteRule.Image = global::Fwk.Security.Admin.Properties.Resources.cancel_16;
            this.mDeleteRule.Name = "mDeleteRule";
            this.mDeleteRule.Size = new System.Drawing.Size(233, 24);
            this.mDeleteRule.Text = "Remove from database";
            this.mDeleteRule.Click += new System.EventHandler(this.mDeleteRule_Click);
            // 
            // mCreateRuele
            // 
            this.mCreateRuele.Image = global::Fwk.Security.Admin.Properties.Resources.admin_24;
            this.mCreateRuele.Name = "mCreateRuele";
            this.mCreateRuele.Size = new System.Drawing.Size(233, 24);
            this.mCreateRuele.Text = "Create new";
            this.mCreateRuele.Click += new System.EventHandler(this.mCreateRuele_Click);
            // 
            // mUpdateRule
            // 
            this.mUpdateRule.Image = global::Fwk.Security.Admin.Properties.Resources.Folder_2_Down;
            this.mUpdateRule.Name = "mUpdateRule";
            this.mUpdateRule.Size = new System.Drawing.Size(233, 24);
            this.mUpdateRule.Text = "Update";
            this.mUpdateRule.Click += new System.EventHandler(this.mUpdateRule_Click);
            // 
            // fwkAuthorizationRuleBindingSource
            // 
            this.fwkAuthorizationRuleBindingSource.DataSource = typeof(Fwk.Security.FwkAuthorizationRule);
            // 
            // gridView_AllRules
            // 
            this.gridView_AllRules.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3});
            this.gridView_AllRules.GridControl = this.grdAllRules;
            this.gridView_AllRules.Name = "gridView_AllRules";
            this.gridView_AllRules.OptionsFilter.AllowFilterEditor = false;
            this.gridView_AllRules.OptionsFind.AlwaysVisible = true;
            this.gridView_AllRules.OptionsLayout.Columns.AddNewColumns = false;
            this.gridView_AllRules.OptionsMenu.EnableColumnMenu = false;
            this.gridView_AllRules.OptionsMenu.EnableFooterMenu = false;
            this.gridView_AllRules.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView_AllRules.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridView_AllRules.OptionsSelection.InvertSelection = true;
            this.gridView_AllRules.OptionsSelection.UseIndicatorForSelection = false;
            this.gridView_AllRules.OptionsView.ShowColumnHeaders = false;
            this.gridView_AllRules.OptionsView.ShowDetailButtons = false;
            this.gridView_AllRules.OptionsView.ShowGroupPanel = false;
            this.gridView_AllRules.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_AllRules.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn3, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView_AllRules.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView_AllRules_MouseDown);
            this.gridView_AllRules.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridView_AllRules_MouseMove);
            this.gridView_AllRules.DoubleClick += new System.EventHandler(this.gridView_AllRules_DoubleClick);
            // 
            // gridColumn3
            // 
            this.gridColumn3.FieldName = "Name";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.grdAllRules;
            this.gridView4.Name = "gridView4";
            // 
            // lblCurrentCategory
            // 
            this.lblCurrentCategory.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.lblCurrentCategory.Location = new System.Drawing.Point(672, 51);
            this.lblCurrentCategory.Name = "lblCurrentCategory";
            this.lblCurrentCategory.Size = new System.Drawing.Size(8, 16);
            this.lblCurrentCategory.TabIndex = 38;
            this.lblCurrentCategory.Text = "_";
            // 
            // lblSelectedRule
            // 
            this.lblSelectedRule.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.lblSelectedRule.Location = new System.Drawing.Point(5, 50);
            this.lblSelectedRule.Name = "lblSelectedRule";
            this.lblSelectedRule.Size = new System.Drawing.Size(4, 16);
            this.lblSelectedRule.TabIndex = 39;
            this.lblSelectedRule.Text = ".";
            // 
            // btnAddNewRule
            // 
            this.btnAddNewRule.Image = global::Fwk.Security.Admin.Properties.Resources.file_add_16;
            this.btnAddNewRule.Location = new System.Drawing.Point(177, 49);
            this.btnAddNewRule.Name = "btnAddNewRule";
            this.btnAddNewRule.Size = new System.Drawing.Size(105, 26);
            this.btnAddNewRule.TabIndex = 40;
            this.btnAddNewRule.Text = "Add Rule";
            this.btnAddNewRule.Click += new System.EventHandler(this.btnAddNewRule_Click);
            // 
            // RulesEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSelectedRule);
            this.Controls.Add(this.btnAddNewRule);
            this.Controls.Add(this.grdAllRules);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblCurrentCategory);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "RulesEditControl";
            this.Size = new System.Drawing.Size(1032, 623);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.contextMenu_Categories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.categoryTreeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllRules)).EndInit();
            this.contextMenu_Rules.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fwkAuthorizationRuleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_AllRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltitle;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ContextMenuStrip contextMenu_Categories;
        private System.Windows.Forms.ToolStripMenuItem mAddNewCategory;
        private DevExpress.XtraGrid.GridControl grdAllRules;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_AllRules;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private System.Windows.Forms.BindingSource fwkAuthorizationRuleBindingSource;
        private System.Windows.Forms.BindingSource categoryTreeBindingSource;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colImg;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private System.Windows.Forms.ToolStripMenuItem mRemove;
        private System.Windows.Forms.ToolStripMenuItem addRuleToolStripMenuItem;
        private DevExpress.XtraEditors.LabelControl lblCurrentCategory;
        private DevExpress.XtraEditors.LabelControl lblSelectedRule;
        private DevExpress.XtraEditors.SimpleButton btnAddNewRule;
        private System.Windows.Forms.ToolStripMenuItem addRootcategoryToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenu_Rules;
        private System.Windows.Forms.ToolStripMenuItem mDeleteRule;
        private System.Windows.Forms.ToolStripMenuItem mCreateRuele;
        private System.Windows.Forms.ToolStripMenuItem mUpdateRule;
    }
}
