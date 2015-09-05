namespace Fwk.CodeGenerator
{
    partial class ListViewCodeGenerated
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListViewCodeGenerated));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Services", 25, 25);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Data Access Components", 22, 22);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Business Entities", 4, 4);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Store Procedures", 18, 18);
            this.imgImages = new System.Windows.Forms.ImageList(this.components);
            this.trvCodeGenerated = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgImages
            // 
            this.imgImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgImages.ImageStream")));
            this.imgImages.TransparentColor = System.Drawing.Color.Transparent;
            this.imgImages.Images.SetKeyName(0, "Refresh.ico");
            this.imgImages.Images.SetKeyName(1, "Round Edit.ico");
            this.imgImages.Images.SetKeyName(2, "ShowRulelinesHS.bmp");
            this.imgImages.Images.SetKeyName(3, "ActualSizeHS.bmp");
            this.imgImages.Images.SetKeyName(4, "AddTableHS.bmp");
            this.imgImages.Images.SetKeyName(5, "AddToFavoritesHS.bmp");
            this.imgImages.Images.SetKeyName(6, "EditCodeHS.bmp");
            this.imgImages.Images.SetKeyName(7, "NewDocumentHS.BMP");
            this.imgImages.Images.SetKeyName(8, "RefreshDocViewHS.bmp");
            this.imgImages.Images.SetKeyName(9, "vb2005.png");
            this.imgImages.Images.SetKeyName(10, "vcs2005.png");
            this.imgImages.Images.SetKeyName(11, "vcs2005Black.PNG");
            this.imgImages.Images.SetKeyName(12, "261.ico");
            this.imgImages.Images.SetKeyName(13, "TABLE.ICO");
            this.imgImages.Images.SetKeyName(14, "search4files.ico");
            this.imgImages.Images.SetKeyName(15, "Data_Schema.ico");
            this.imgImages.Images.SetKeyName(16, "Web.png");
            this.imgImages.Images.SetKeyName(17, "arrowb.gif");
            this.imgImages.Images.SetKeyName(18, "db.ico");
            this.imgImages.Images.SetKeyName(19, "Copia de Data_Schema.ico");
            this.imgImages.Images.SetKeyName(20, "Web_WebConfig.ico");
            this.imgImages.Images.SetKeyName(21, "WindowsHS.png");
            this.imgImages.Images.SetKeyName(22, "RelationshipsHS.png");
            this.imgImages.Images.SetKeyName(23, "ArrangeWindowsHS.png");
            this.imgImages.Images.SetKeyName(24, "TortoiseInSubVersion.ico");
            this.imgImages.Images.SetKeyName(25, "Asp Page 16.ico");
            // 
            // trvCodeGenerated
            // 
            this.trvCodeGenerated.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trvCodeGenerated.BackColor = System.Drawing.Color.Black;
            this.trvCodeGenerated.ContextMenuStrip = this.contextMenuStrip1;
            this.trvCodeGenerated.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.trvCodeGenerated.HotTracking = true;
            this.trvCodeGenerated.ImageIndex = 3;
            this.trvCodeGenerated.ImageList = this.imgImages;
            this.trvCodeGenerated.LineColor = System.Drawing.Color.LightGray;
            this.trvCodeGenerated.Location = new System.Drawing.Point(3, 3);
            this.trvCodeGenerated.Name = "trvCodeGenerated";
            treeNode1.ImageIndex = 25;
            treeNode1.Name = "SVC";
            treeNode1.SelectedImageIndex = 25;
            treeNode1.Tag = "SVC";
            treeNode1.Text = "Services";
            treeNode2.ImageIndex = 22;
            treeNode2.Name = "DAC";
            treeNode2.SelectedImageIndex = 22;
            treeNode2.Tag = "DAC";
            treeNode2.Text = "Data Access Components";
            treeNode3.ImageIndex = 4;
            treeNode3.Name = "BE";
            treeNode3.SelectedImageIndex = 4;
            treeNode3.Tag = "BE";
            treeNode3.Text = "Business Entities";
            treeNode4.ImageIndex = 18;
            treeNode4.Name = "SP";
            treeNode4.SelectedImageIndex = 18;
            treeNode4.Tag = "SP";
            treeNode4.Text = "Store Procedures";
            this.trvCodeGenerated.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.trvCodeGenerated.SelectedImageIndex = 3;
            this.trvCodeGenerated.Size = new System.Drawing.Size(185, 195);
            this.trvCodeGenerated.TabIndex = 0;
            this.trvCodeGenerated.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvCodeGenerated_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(145, 26);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.saveToolStripMenuItem.Text = "Save all files";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // ListViewCodeGenerated
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trvCodeGenerated);
            this.Name = "ListViewCodeGenerated";
            this.Size = new System.Drawing.Size(191, 201);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgImages;
        private System.Windows.Forms.TreeView trvCodeGenerated;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}
