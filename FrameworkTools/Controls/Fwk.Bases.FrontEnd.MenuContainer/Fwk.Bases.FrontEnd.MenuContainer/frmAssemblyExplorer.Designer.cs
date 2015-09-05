namespace Fwk.Bases.FrontEnd.MenuContainer
{
    partial class frmAssemblyExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssemblyExplorer));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuItemListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSearAssemblie = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblServiceName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.menuItemListBindingSource, "AssemblyInfo", true));
            this.listBox1.DataSource = this.menuItemListBindingSource;
            this.listBox1.DisplayMember = "AssemblyInfo";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 70);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(609, 290);
            this.listBox1.TabIndex = 77;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // menuItemListBindingSource
            // 
            this.menuItemListBindingSource.DataSource = typeof(Fwk.Bases.FrontEnd.MenuContainer.MenuItemList);
            // 
            // btnSearAssemblie
            // 
            this.btnSearAssemblie.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearAssemblie.Image = ((System.Drawing.Image)(resources.GetObject("btnSearAssemblie.Image")));
            this.btnSearAssemblie.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearAssemblie.Location = new System.Drawing.Point(561, 18);
            this.btnSearAssemblie.Name = "btnSearAssemblie";
            this.btnSearAssemblie.Size = new System.Drawing.Size(28, 23);
            this.btnSearAssemblie.TabIndex = 79;
            this.btnSearAssemblie.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearAssemblie.UseVisualStyleBackColor = true;
            this.btnSearAssemblie.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "AddTableHS.png");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 80;
            this.label2.Text = "Forms list";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(555, 370);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(66, 23);
            this.btnOk.TabIndex = 81;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 82;
            this.label1.Text = "File:";
            // 
            // lblFileName
            // 
            this.lblFileName.BackColor = System.Drawing.Color.White;
            this.lblFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFileName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblFileName.Location = new System.Drawing.Point(49, 22);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(506, 15);
            this.lblFileName.TabIndex = 83;
            this.lblFileName.Text = "..";
            // 
            // lblServiceName
            // 
            this.lblServiceName.AutoSize = true;
            this.lblServiceName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblServiceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceName.ForeColor = System.Drawing.Color.CadetBlue;
            this.lblServiceName.Location = new System.Drawing.Point(88, 54);
            this.lblServiceName.Name = "lblServiceName";
            this.lblServiceName.Size = new System.Drawing.Size(0, 13);
            this.lblServiceName.TabIndex = 84;
            // 
            // frmAssemblyExplorer
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(633, 400);
            this.Controls.Add(this.lblServiceName);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearAssemblie);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAssemblyExplorer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form Explorer";
            ((System.ComponentModel.ISupportInitialize)(this.menuItemListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnSearAssemblie;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label lblServiceName;
        private System.Windows.Forms.BindingSource menuItemListBindingSource;
    }
}