namespace Fwk.Security.Admin.Controls
{
    partial class ConnectionStringsCrypt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionStringsCrypt));
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Config Manager Files");
            this.imgImages = new System.Windows.Forms.ImageList(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnFindRoles = new System.Windows.Forms.Button();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.mnGroupAndKey = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuItemRemoveGrOrKey = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.lblSelectedFile = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.mnGroupAndKey.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imgImages
            // 
            this.imgImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgImages.ImageStream")));
            this.imgImages.TransparentColor = System.Drawing.Color.Transparent;
            this.imgImages.Images.SetKeyName(0, "WarningHS.png");
            this.imgImages.Images.SetKeyName(1, "AddTableHS.png");
            this.imgImages.Images.SetKeyName(2, "CascadeWindowsHS.png");
            this.imgImages.Images.SetKeyName(3, "CopyHS.png");
            this.imgImages.Images.SetKeyName(4, "dbs.ico");
            this.imgImages.Images.SetKeyName(5, "DocumentHS.png");
            this.imgImages.Images.SetKeyName(6, "EditInformationHS.png");
            this.imgImages.Images.SetKeyName(7, "EditTableHS.png");
            this.imgImages.Images.SetKeyName(8, "inifile.ico");
            this.imgImages.Images.SetKeyName(9, "item-lista.gif");
            this.imgImages.Images.SetKeyName(10, "POWER04B.ICO");
            this.imgImages.Images.SetKeyName(11, "PushpinHS.png");
            this.imgImages.Images.SetKeyName(12, "RecordHS.png");
            this.imgImages.Images.SetKeyName(13, "ShowAllCommentsHS.png");
            this.imgImages.Images.SetKeyName(14, "TortoiseAdded.ico");
            this.imgImages.Images.SetKeyName(15, "UtilityText.ico");
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.FullRowSelect = true;
            this.treeView1.HotTracking = true;
            this.treeView1.ImageKey = "UtilityText.ico";
            this.treeView1.ImageList = this.imgImages;
            this.treeView1.Location = new System.Drawing.Point(3, 42);
            this.treeView1.Name = "treeView1";
            treeNode2.ImageKey = "EditInformationHS.png";
            treeNode2.Name = "Node1";
            treeNode2.SelectedImageKey = "EditInformationHS.png";
            treeNode2.Text = "Config Manager Files";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeView1.SelectedImageIndex = 7;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(266, 448);
            this.treeView1.TabIndex = 2;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // btnFindRoles
            // 
            this.btnFindRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindRoles.BackColor = System.Drawing.Color.White;
            this.btnFindRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindRoles.Image = global::Fwk.Security.Admin.Properties.Resources.search_16;
            this.btnFindRoles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFindRoles.Location = new System.Drawing.Point(616, 16);
            this.btnFindRoles.Name = "btnFindRoles";
            this.btnFindRoles.Size = new System.Drawing.Size(32, 20);
            this.btnFindRoles.TabIndex = 38;
            this.btnFindRoles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFindRoles.UseVisualStyleBackColor = false;
            this.btnFindRoles.Click += new System.EventHandler(this.btnFindRoles_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(3, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(45, 16);
            this.labelControl3.TabIndex = 37;
            this.labelControl3.Text = "Exe file";
            // 
            // mnGroupAndKey
            // 
            this.mnGroupAndKey.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemRemoveGrOrKey});
            this.mnGroupAndKey.Name = "mnContextConfigManager";
            this.mnGroupAndKey.Size = new System.Drawing.Size(125, 26);
            // 
            // tsMenuItemRemoveGrOrKey
            // 
            this.tsMenuItemRemoveGrOrKey.Image = global::Fwk.Security.Admin.Properties.Resources.Cancel_2_16;
            this.tsMenuItemRemoveGrOrKey.Name = "tsMenuItemRemoveGrOrKey";
            this.tsMenuItemRemoveGrOrKey.Size = new System.Drawing.Size(124, 22);
            this.tsMenuItemRemoveGrOrKey.Text = "Remove";
            this.tsMenuItemRemoveGrOrKey.Click += new System.EventHandler(this.tsMenuItemRemoveGrOrKey_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.BackColor = System.Drawing.Color.White;
            this.btnEncrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncrypt.Image = global::Fwk.Security.Admin.Properties.Resources.admin_16;
            this.btnEncrypt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEncrypt.Location = new System.Drawing.Point(275, 52);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(122, 28);
            this.btnEncrypt.TabIndex = 40;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = false;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // memoEdit1
            // 
            this.memoEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memoEdit1.Location = new System.Drawing.Point(275, 100);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(362, 390);
            this.memoEdit1.TabIndex = 44;
            // 
            // lblSelectedFile
            // 
            this.lblSelectedFile.AutoSize = true;
            this.lblSelectedFile.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblSelectedFile.Location = new System.Drawing.Point(422, 55);
            this.lblSelectedFile.Name = "lblSelectedFile";
            this.lblSelectedFile.Size = new System.Drawing.Size(0, 19);
            this.lblSelectedFile.TabIndex = 45;
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtFileName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.txtFileName.Location = new System.Drawing.Point(60, 13);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(550, 21);
            this.txtFileName.TabIndex = 46;
            // 
            // ConnectionStringsCrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSelectedFile);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnFindRoles);
            this.Name = "ConnectionStringsCrypt";
            this.Size = new System.Drawing.Size(655, 493);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.mnGroupAndKey.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imgImages;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnFindRoles;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.ContextMenuStrip mnGroupAndKey;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemRemoveGrOrKey;
        private System.Windows.Forms.Button btnEncrypt;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private System.Windows.Forms.Label lblSelectedFile;
        private System.Windows.Forms.TextBox txtFileName;
    }
}
