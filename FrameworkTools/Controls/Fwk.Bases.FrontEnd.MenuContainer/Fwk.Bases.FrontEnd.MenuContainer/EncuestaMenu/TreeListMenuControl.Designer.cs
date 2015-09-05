namespace Fwk.Bases.FrontEnd.MenuContainer.EncuestaMenu
{
    partial class TreeListMenuControl
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
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colDisplayName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTypeImage = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.colEnabled = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAssemblyInfo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colToolTipInfo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colFormName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colImage = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSelectedImage = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSelectedImageIndex = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.menuItemEncuestaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemEncuestaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colDisplayName,
            this.colTypeImage,
            this.colEnabled,
            this.colAssemblyInfo,
            this.colToolTipInfo,
            this.colFormName,
            this.colImage,
            this.colSelectedImage,
            this.colSelectedImageIndex});
            this.treeList1.DataSource = this.menuItemEncuestaBindingSource;
            this.treeList1.Location = new System.Drawing.Point(3, 3);
            this.treeList1.Name = "treeList1";
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit1});
            this.treeList1.Size = new System.Drawing.Size(315, 406);
            this.treeList1.TabIndex = 44;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            // 
            // colDisplayName
            // 
            this.colDisplayName.Caption = "DisplayName";
            this.colDisplayName.FieldName = "DisplayName";
            this.colDisplayName.Name = "colDisplayName";
            this.colDisplayName.OptionsColumn.AllowEdit = false;
            this.colDisplayName.OptionsColumn.AllowSort = false;
            this.colDisplayName.OptionsColumn.ReadOnly = true;
            this.colDisplayName.Visible = true;
            this.colDisplayName.VisibleIndex = 0;
            this.colDisplayName.Width = 222;
            // 
            // colTypeImage
            // 
            this.colTypeImage.Caption = "TypeImage";
            this.colTypeImage.ColumnEdit = this.repositoryItemImageEdit1;
            this.colTypeImage.FieldName = "TypeImage";
            this.colTypeImage.Name = "colTypeImage";
            this.colTypeImage.OptionsColumn.ReadOnly = true;
            this.colTypeImage.Visible = true;
            this.colTypeImage.VisibleIndex = 1;
            this.colTypeImage.Width = 223;
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // colEnabled
            // 
            this.colEnabled.Caption = "Enabled";
            this.colEnabled.FieldName = "Enabled";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.Width = 49;
            // 
            // colAssemblyInfo
            // 
            this.colAssemblyInfo.Caption = "AssemblyInfo";
            this.colAssemblyInfo.FieldName = "AssemblyInfo";
            this.colAssemblyInfo.Name = "colAssemblyInfo";
            this.colAssemblyInfo.Width = 49;
            // 
            // colToolTipInfo
            // 
            this.colToolTipInfo.Caption = "ToolTipInfo";
            this.colToolTipInfo.FieldName = "ToolTipInfo";
            this.colToolTipInfo.Name = "colToolTipInfo";
            this.colToolTipInfo.Width = 49;
            // 
            // colFormName
            // 
            this.colFormName.Caption = "FormName";
            this.colFormName.FieldName = "FormName";
            this.colFormName.Name = "colFormName";
            this.colFormName.Width = 50;
            // 
            // colImage
            // 
            this.colImage.Caption = "Image";
            this.colImage.FieldName = "Image";
            this.colImage.Name = "colImage";
            this.colImage.Width = 50;
            // 
            // colSelectedImage
            // 
            this.colSelectedImage.Caption = "SelectedImage";
            this.colSelectedImage.FieldName = "SelectedImage";
            this.colSelectedImage.Name = "colSelectedImage";
            this.colSelectedImage.Width = 50;
            // 
            // colSelectedImageIndex
            // 
            this.colSelectedImageIndex.Caption = "SelectedImageIndex";
            this.colSelectedImageIndex.FieldName = "SelectedImageIndex";
            this.colSelectedImageIndex.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSelectedImageIndex.Name = "colSelectedImageIndex";
            this.colSelectedImageIndex.Width = 50;
            // 
            // menuItemEncuestaBindingSource
            // 
            this.menuItemEncuestaBindingSource.DataSource = typeof(Fwk.Bases.FrontEnd.MenuContainer.EncuestaMenu.MenuItemEncuesta);
            // 
            // TreeListMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList1);
            this.Name = "TreeListMenuControl";
            this.Size = new System.Drawing.Size(319, 414);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemEncuestaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

       

        

        void Init()
        {
            //this.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.TreeListMenu_FocusedNodeChanged);

            //this.colDisplayName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            //this.colTypeImage = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            //this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();

            //this.colEnabled = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            //this.colAssemblyInfo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            //this.colToolTipInfo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            //this.colFormName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            //this.colImage = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            //this.colSelectedImage = new DevExpress.XtraTreeList.Columns.TreeListColumn();

            //this.colSelectedImageIndex = new DevExpress.XtraTreeList.Columns.TreeListColumn();

            //((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();




            //this.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            //this.colDisplayName,
            //this.colTypeImage,
            //this.colEnabled,
            //this.colAssemblyInfo,
            //this.colToolTipInfo,
            //this.colFormName,
            //this.colImage,
            //this.colSelectedImage,
            //this.colSelectedImageIndex});

            //this.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            //this.repositoryItemImageEdit1});



            //// 
            //// colDisplayName
            //// 
            //this.colDisplayName.Caption = "DisplayName";
            //this.colDisplayName.FieldName = "DisplayName";
            //this.colDisplayName.Name = "colDisplayName";
            //this.colDisplayName.Visible = true;
            //this.colDisplayName.VisibleIndex = 0;
            //this.colDisplayName.Width = 222;
            //this.colDisplayName.OptionsColumn.AllowEdit = false;
            //// 
            //// colTypeImage
            //// 
            //this.colTypeImage.Caption = "TypeImage";
            //this.colTypeImage.ColumnEdit = this.repositoryItemImageEdit1;
            //this.colTypeImage.FieldName = "TypeImage";
            //this.colTypeImage.Name = "colTypeImage";
            //this.colTypeImage.Visible = true;
            //this.colTypeImage.VisibleIndex = 1;
            //this.colTypeImage.Width = 223;
            //this.colTypeImage.OptionsColumn.AllowEdit = true;

            //// 
            //// repositoryItemImageEdit1
            //// 
            //this.repositoryItemImageEdit1.AutoHeight = false;
            //this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            //new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            //this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";


            ////_RepositoryItemPickImage

            //// 
            //// colEnabled
            //// 
            //this.colEnabled.Caption = "Enabled";
            //this.colEnabled.FieldName = "Enabled";
            //this.colEnabled.Name = "colEnabled";
            //this.colEnabled.Width = 49;
            //// 
            //// colAssemblyInfo
            //// 
            //this.colAssemblyInfo.Caption = "AssemblyInfo";
            //this.colAssemblyInfo.FieldName = "AssemblyInfo";
            //this.colAssemblyInfo.Name = "colAssemblyInfo";
            //this.colAssemblyInfo.Width = 49;
            //// 
            //// colToolTipInfo
            //// 
            //this.colToolTipInfo.Caption = "ToolTipInfo";
            //this.colToolTipInfo.FieldName = "ToolTipInfo";
            //this.colToolTipInfo.Name = "colToolTipInfo";
            //this.colToolTipInfo.Width = 49;
            //// 
            //// colFormName
            //// 
            //this.colFormName.Caption = "FormName";
            //this.colFormName.FieldName = "FormName";
            //this.colFormName.Name = "colFormName";
            //this.colFormName.Width = 50;
            //// 
            //// colImage
            //// 
            //this.colImage.Caption = "Image";
            //this.colImage.FieldName = "Image";
            //this.colImage.Name = "colImage";
            //this.colImage.Width = 50;
            //// 
            //// colSelectedImage
            //// 
            //this.colSelectedImage.Caption = "SelectedImage";
            //this.colSelectedImage.FieldName = "SelectedImage";
            //this.colSelectedImage.Name = "colSelectedImage";
            //this.colSelectedImage.Width = 50;
            //// 
            //// colSelectedImageIndex
            //// 
            //this.colSelectedImageIndex.Caption = "SelectedImageIndex";
            //this.colSelectedImageIndex.FieldName = "SelectedImageIndex";
            //this.colSelectedImageIndex.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            //this.colSelectedImageIndex.Name = "colSelectedImageIndex";
            //this.colSelectedImageIndex.Width = 50;


            //((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();



        }

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDisplayName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTypeImage;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colEnabled;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAssemblyInfo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colToolTipInfo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFormName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colImage;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSelectedImage;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSelectedImageIndex;
        private System.Windows.Forms.BindingSource menuItemEncuestaBindingSource;

    }
}
