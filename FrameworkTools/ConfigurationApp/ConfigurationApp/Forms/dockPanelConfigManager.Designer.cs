namespace ConfigurationApp.Forms
{
    partial class dockPanelConfigManager
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Config Manager Files");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dockPanelConfigManager));
            this.mnConfigManagerRoot = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuItemNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemSaveAllFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemQuitAllFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemRefreshAllFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imgImages = new System.Windows.Forms.ImageList(this.components);
            this.mnCnfgManFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuItemSaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemQuitFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemRefreshFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemNewGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnGroupAndKey = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuItemNewKey = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemRemoveGrOrKey = new System.Windows.Forms.ToolStripMenuItem();
            this.mnCnfgManFile_Fail = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewInsertScriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnConfigManagerRoot.SuspendLayout();
            this.mnCnfgManFile.SuspendLayout();
            this.mnGroupAndKey.SuspendLayout();
            this.mnCnfgManFile_Fail.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnConfigManagerRoot
            // 
            this.mnConfigManagerRoot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemNewFile,
            this.tsMenuItemSaveAllFiles,
            this.tsMenuItemQuitAllFiles,
            this.tsMenuItemRefreshAllFiles});
            this.mnConfigManagerRoot.Name = "mnContextConfigManager";
            this.mnConfigManagerRoot.Size = new System.Drawing.Size(131, 92);
            // 
            // tsMenuItemNewFile
            // 
            this.tsMenuItemNewFile.Image = global::ConfigurationApp.Properties.Resources.documents_small;
            this.tsMenuItemNewFile.Name = "tsMenuItemNewFile";
            this.tsMenuItemNewFile.Size = new System.Drawing.Size(130, 22);
            this.tsMenuItemNewFile.Text = "New";
            // 
            // tsMenuItemSaveAllFiles
            // 
            this.tsMenuItemSaveAllFiles.Image = global::ConfigurationApp.Properties.Resources.save_as_small;
            this.tsMenuItemSaveAllFiles.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tsMenuItemSaveAllFiles.Name = "tsMenuItemSaveAllFiles";
            this.tsMenuItemSaveAllFiles.Size = new System.Drawing.Size(130, 22);
            this.tsMenuItemSaveAllFiles.Text = "Save All";
            // 
            // tsMenuItemQuitAllFiles
            // 
            this.tsMenuItemQuitAllFiles.Image = global::ConfigurationApp.Properties.Resources.Delete;
            this.tsMenuItemQuitAllFiles.Name = "tsMenuItemQuitAllFiles";
            this.tsMenuItemQuitAllFiles.Size = new System.Drawing.Size(130, 22);
            this.tsMenuItemQuitAllFiles.Text = "Quit All";
            // 
            // tsMenuItemRefreshAllFiles
            // 
            this.tsMenuItemRefreshAllFiles.Image = global::ConfigurationApp.Properties.Resources.Refresh;
            this.tsMenuItemRefreshAllFiles.Name = "tsMenuItemRefreshAllFiles";
            this.tsMenuItemRefreshAllFiles.Size = new System.Drawing.Size(130, 22);
            this.tsMenuItemRefreshAllFiles.Text = "Refresh All";
            this.tsMenuItemRefreshAllFiles.Click += new System.EventHandler(this.tsMenuItemRefreshAllFiles_Click);
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.FullRowSelect = true;
            this.treeView1.HotTracking = true;
            this.treeView1.ImageKey = "EditInformationHS.png";
            this.treeView1.ImageList = this.imgImages;
            this.treeView1.Location = new System.Drawing.Point(5, 2);
            this.treeView1.Name = "treeView1";
            treeNode1.ContextMenuStrip = this.mnConfigManagerRoot;
            treeNode1.ImageKey = "EditInformationHS.png";
            treeNode1.Name = "Node1";
            treeNode1.SelectedImageKey = "EditInformationHS.png";
            treeNode1.Text = "Config Manager Files";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(266, 485);
            this.treeView1.TabIndex = 1;
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
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
            this.imgImages.Images.SetKeyName(16, "alert.png");
            // 
            // mnCnfgManFile
            // 
            this.mnCnfgManFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemSaveFile,
            this.tsMenuItemQuitFile,
            this.tsMenuItemRefreshFile,
            this.tsMenuItemNewGroup,
            this.exploreToolStripMenuItem,
            this.exportToToolStripMenuItem,
            this.viewInsertScriptsToolStripMenuItem});
            this.mnCnfgManFile.Name = "mnContextConfigManager";
            this.mnCnfgManFile.Size = new System.Drawing.Size(170, 180);
            // 
            // tsMenuItemSaveFile
            // 
            this.tsMenuItemSaveFile.Image = global::ConfigurationApp.Properties.Resources.save_as_small;
            this.tsMenuItemSaveFile.Name = "tsMenuItemSaveFile";
            this.tsMenuItemSaveFile.Size = new System.Drawing.Size(169, 22);
            this.tsMenuItemSaveFile.Text = "Save";
            // 
            // tsMenuItemQuitFile
            // 
            this.tsMenuItemQuitFile.Enabled = false;
            this.tsMenuItemQuitFile.Image = global::ConfigurationApp.Properties.Resources.Delete;
            this.tsMenuItemQuitFile.Name = "tsMenuItemQuitFile";
            this.tsMenuItemQuitFile.Size = new System.Drawing.Size(169, 22);
            this.tsMenuItemQuitFile.Text = "Quit";
            this.tsMenuItemQuitFile.Click += new System.EventHandler(this.tsMenuItemQuitFile_Click);
            // 
            // tsMenuItemRefreshFile
            // 
            this.tsMenuItemRefreshFile.Image = global::ConfigurationApp.Properties.Resources.Refresh;
            this.tsMenuItemRefreshFile.Name = "tsMenuItemRefreshFile";
            this.tsMenuItemRefreshFile.Size = new System.Drawing.Size(169, 22);
            this.tsMenuItemRefreshFile.Text = "Refresh";
            this.tsMenuItemRefreshFile.Click += new System.EventHandler(this.tsMenuItemRefreshFile_Click);
            // 
            // tsMenuItemNewGroup
            // 
            this.tsMenuItemNewGroup.Image = global::ConfigurationApp.Properties.Resources.add;
            this.tsMenuItemNewGroup.Name = "tsMenuItemNewGroup";
            this.tsMenuItemNewGroup.Size = new System.Drawing.Size(169, 22);
            this.tsMenuItemNewGroup.Text = "New Group";
            this.tsMenuItemNewGroup.Click += new System.EventHandler(this.tsMenuItemNewGroup_Click);
            // 
            // exploreToolStripMenuItem
            // 
            this.exploreToolStripMenuItem.Image = global::ConfigurationApp.Properties.Resources.Web_WebConfig;
            this.exploreToolStripMenuItem.Name = "exploreToolStripMenuItem";
            this.exploreToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.exploreToolStripMenuItem.Text = "Explore";
            this.exploreToolStripMenuItem.Click += new System.EventHandler(this.exploreToolStripMenuItem_Click);
            // 
            // exportToToolStripMenuItem
            // 
            this.exportToToolStripMenuItem.Name = "exportToToolStripMenuItem";
            this.exportToToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.exportToToolStripMenuItem.Text = "Export to";
            this.exportToToolStripMenuItem.Click += new System.EventHandler(this.exportToToolStripMenuItem_Click);
            // 
            // mnGroupAndKey
            // 
            this.mnGroupAndKey.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemNewKey,
            this.tsMenuItemRemoveGrOrKey});
            this.mnGroupAndKey.Name = "mnContextConfigManager";
            this.mnGroupAndKey.Size = new System.Drawing.Size(121, 48);
            // 
            // tsMenuItemNewKey
            // 
            this.tsMenuItemNewKey.Image = global::ConfigurationApp.Properties.Resources.add;
            this.tsMenuItemNewKey.Name = "tsMenuItemNewKey";
            this.tsMenuItemNewKey.Size = new System.Drawing.Size(120, 22);
            this.tsMenuItemNewKey.Text = "New Key";
            this.tsMenuItemNewKey.Click += new System.EventHandler(this.tsMenuItemNewKey_Click);
            // 
            // tsMenuItemRemoveGrOrKey
            // 
            this.tsMenuItemRemoveGrOrKey.Image = global::ConfigurationApp.Properties.Resources.Delete;
            this.tsMenuItemRemoveGrOrKey.Name = "tsMenuItemRemoveGrOrKey";
            this.tsMenuItemRemoveGrOrKey.Size = new System.Drawing.Size(120, 22);
            this.tsMenuItemRemoveGrOrKey.Text = "Remove";
            this.tsMenuItemRemoveGrOrKey.Click += new System.EventHandler(this.tsMenuItemRemoveGrOrKey_Click);
            // 
            // mnCnfgManFile_Fail
            // 
            this.mnCnfgManFile_Fail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.mnCnfgManFile_Fail.Name = "mnContextConfigManager";
            this.mnCnfgManFile_Fail.Size = new System.Drawing.Size(114, 48);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::ConfigurationApp.Properties.Resources.Delete;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(113, 22);
            this.toolStripMenuItem2.Text = "Quit";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::ConfigurationApp.Properties.Resources.Refresh;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(113, 22);
            this.toolStripMenuItem3.Text = "Refresh";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // viewInsertScriptsToolStripMenuItem
            // 
            this.viewInsertScriptsToolStripMenuItem.Name = "viewInsertScriptsToolStripMenuItem";
            this.viewInsertScriptsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.viewInsertScriptsToolStripMenuItem.Text = "View Insert Scripts";
            this.viewInsertScriptsToolStripMenuItem.Click += new System.EventHandler(this.viewInsertScriptsToolStripMenuItem_Click);
            // 
            // dockPanelConfigManager
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.treeView1);
            this.Name = "dockPanelConfigManager";
            this.Size = new System.Drawing.Size(274, 488);
            this.mnConfigManagerRoot.ResumeLayout(false);
            this.mnCnfgManFile.ResumeLayout(false);
            this.mnGroupAndKey.ResumeLayout(false);
            this.mnCnfgManFile_Fail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imgImages;
        private System.Windows.Forms.ContextMenuStrip mnCnfgManFile;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemSaveFile;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemQuitFile;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemRefreshFile;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemNewGroup;
        private System.Windows.Forms.ContextMenuStrip mnGroupAndKey;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemNewKey;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemRemoveGrOrKey;
        private System.Windows.Forms.ContextMenuStrip mnConfigManagerRoot;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemNewFile;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemSaveAllFiles;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemQuitAllFiles;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemRefreshAllFiles;
        private System.Windows.Forms.ToolStripMenuItem exploreToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip mnCnfgManFile_Fail;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem exportToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewInsertScriptsToolStripMenuItem;
    }
}