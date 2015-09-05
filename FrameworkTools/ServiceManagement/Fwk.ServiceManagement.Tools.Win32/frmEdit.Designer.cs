namespace Fwk.ServiceManagement.Tools.Win32
{
	partial class frmEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEdit));
            this.ServiceConfigurationCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearchFile = new System.Windows.Forms.Button();
            this.ctrlService1 = new Fwk.ServiceManagement.Tools.Win32.ctrlService();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceConfigurationCollectionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ServiceConfigurationCollectionBindingSource
            // 
            this.ServiceConfigurationCollectionBindingSource.DataSource = typeof(Fwk.Bases.ServiceConfiguration);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(748, 608);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 28);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(872, 608);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSearchFile
            // 
            this.btnSearchFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchFile.ForeColor = System.Drawing.Color.DimGray;
            this.btnSearchFile.Image = global::Fwk.ServiceManagement.Tools.Win32.Properties.Resources.mostrar;
            this.btnSearchFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchFile.Location = new System.Drawing.Point(276, 0);
            this.btnSearchFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchFile.Name = "btnSearchFile";
            this.btnSearchFile.Size = new System.Drawing.Size(221, 31);
            this.btnSearchFile.TabIndex = 29;
            this.btnSearchFile.Text = "Load from assemby";
            this.btnSearchFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchFile.UseVisualStyleBackColor = true;
            this.btnSearchFile.Click += new System.EventHandler(this.btnSearchFile_Click);
            // 
            // ctrlService1
            // 
            this.ctrlService1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlService1.EntityParam = null;
            this.ctrlService1.EntityResult = null;
            this.ctrlService1.Location = new System.Drawing.Point(0, 0);
            this.ctrlService1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctrlService1.Name = "ctrlService1";
            this.ctrlService1.ShowAction = Fwk.ServiceManagement.Tools.Win32.Action.Query;
            this.ctrlService1.Size = new System.Drawing.Size(991, 598);
            this.ctrlService1.TabIndex = 28;
            // 
            // frmEdit
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(991, 649);
            this.Controls.Add(this.btnSearchFile);
            this.Controls.Add(this.ctrlService1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Service edition";
            ((System.ComponentModel.ISupportInitialize)(this.ServiceConfigurationCollectionBindingSource)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.BindingSource ServiceConfigurationCollectionBindingSource;
        public System.Windows.Forms.Button btnSearchFile;
        public ctrlService ctrlService1;
	}
}