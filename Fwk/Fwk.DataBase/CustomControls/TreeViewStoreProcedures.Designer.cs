namespace Fwk.DataBase.CustomControls
{
    /// <summary>
    /// Control que muestra un arbol con los Store Procedures de la base de datos.-
    /// </summary>
    partial class TreeViewStoreProcedures
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeViewStoreProcedures));
            this.tvwChilds = new System.Windows.Forms.TreeView();
            this.imgImages = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
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
            this.tvwChilds.ImageIndex = 5;
            this.tvwChilds.ImageList = this.imgImages;
            this.tvwChilds.Location = new System.Drawing.Point(3, 3);
            this.tvwChilds.Name = "tvwChilds";
            this.tvwChilds.SelectedImageIndex = 2;
            this.tvwChilds.Size = new System.Drawing.Size(228, 447);
            this.tvwChilds.TabIndex = 20;
            this.tvwChilds.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwChilds_AfterCheck);
            this.tvwChilds.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwChilds_BeforeCheck);
            this.tvwChilds.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwChilds_AfterSelect);
            // 
            // imgImages
            // 
            this.imgImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgImages.ImageStream")));
            this.imgImages.TransparentColor = System.Drawing.Color.Transparent;
            this.imgImages.Images.SetKeyName(0, "Round Remove.ico");
            this.imgImages.Images.SetKeyName(1, "152_4.ico");
            this.imgImages.Images.SetKeyName(2, "fldropen.ico");
            this.imgImages.Images.SetKeyName(3, "fldropn2.ico");
            this.imgImages.Images.SetKeyName(4, "fldropn3.ico");
            this.imgImages.Images.SetKeyName(5, "foldergr.ico");
            this.imgImages.Images.SetKeyName(6, "Piezas.ico");
            this.imgImages.Images.SetKeyName(7, "Refresh.ico");
            this.imgImages.Images.SetKeyName(8, "Round Add.ico");
            this.imgImages.Images.SetKeyName(9, "Round Edit.ico");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar,
            this.lblTreeViewSelected});
            this.statusStrip1.Location = new System.Drawing.Point(0, 453);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(234, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ProgressBar
            // 
            this.ProgressBar.BackColor = System.Drawing.Color.White;
            this.ProgressBar.Maximum = 0;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(100, 16);
            this.ProgressBar.Step = 1;
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
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
            this.lblTreeViewSelected.Size = new System.Drawing.Size(83, 17);
            this.lblTreeViewSelected.Text = "Visor de Tablas";
            // 
            // TreeViewStoreProcedures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tvwChilds);
            this.Name = "TreeViewStoreProcedures";
            this.Size = new System.Drawing.Size(234, 475);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvwChilds;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel lblTreeViewSelected;
        private System.Windows.Forms.ImageList imgImages;
    }
}
