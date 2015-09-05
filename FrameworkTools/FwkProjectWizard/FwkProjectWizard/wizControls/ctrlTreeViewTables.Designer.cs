namespace Fwk.Wizard
{
    /// <summary>
    /// Clase helper de Tree View 
    /// </summary>
    partial class ctrlTreeViewTables
    {
        /// <summary> 
        /// marcelo oviedo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlTreeViewTables));
            this.tvwChilds = new System.Windows.Forms.TreeView();
            this.imgImages = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTreeViewSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvwChilds
            // 
            this.tvwChilds.AllowDrop = true;
            this.tvwChilds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvwChilds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvwChilds.CheckBoxes = true;
            this.tvwChilds.FullRowSelect = true;
            this.tvwChilds.ImageIndex = 0;
            this.tvwChilds.ImageList = this.imgImages;
            this.tvwChilds.Location = new System.Drawing.Point(3, 3);
            this.tvwChilds.Name = "tvwChilds";
            this.tvwChilds.SelectedImageIndex = 2;
            this.tvwChilds.Size = new System.Drawing.Size(213, 390);
            this.tvwChilds.TabIndex = 19;
            this.tvwChilds.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwChilds_AfterCheck);
            this.tvwChilds.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwChilds_AfterSelect);
            this.tvwChilds.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwChilds_BeforeCheck);
            // 
            // imgImages
            // 
            this.imgImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgImages.ImageStream")));
            this.imgImages.TransparentColor = System.Drawing.Color.Transparent;
            this.imgImages.Images.SetKeyName(0, "folder-closed_16.png");
            this.imgImages.Images.SetKeyName(1, "folder-open_16.png");
            this.imgImages.Images.SetKeyName(2, "export_16.png");
            this.imgImages.Images.SetKeyName(3, "AcroRd32 45.ico");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTreeViewSelected});
            this.statusStrip1.Location = new System.Drawing.Point(0, 393);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(219, 22);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTreeViewSelected
            // 
            this.lblTreeViewSelected.AutoToolTip = true;
            this.lblTreeViewSelected.BackColor = System.Drawing.Color.White;
            this.lblTreeViewSelected.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblTreeViewSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblTreeViewSelected.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTreeViewSelected.Name = "lblTreeViewSelected";
            this.lblTreeViewSelected.Size = new System.Drawing.Size(69, 17);
            this.lblTreeViewSelected.Text = "Visor de SPs";
            // 
            // ctrlTreeViewTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tvwChilds);
            this.Name = "ctrlTreeViewTables";
            this.Size = new System.Drawing.Size(219, 415);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvwChilds;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ImageList imgImages;
        private System.Windows.Forms.ToolStripStatusLabel lblTreeViewSelected;
    }
}
