namespace Fwk.ServiceManagement.Tools.Win32
{
	partial class frmServices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServices));
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCnnString = new System.Windows.Forms.ToolStripButton();
            this.lblServerName = new System.Windows.Forms.ToolStripLabel();
            this.lblDatabaseName = new System.Windows.Forms.ToolStripLabel();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.txtSchemPath = new System.Windows.Forms.ToolStripTextBox();
            this.btnSearchXmlFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnNewProvider = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.providersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbProviders = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMetaqadata = new System.Windows.Forms.Label();
            this.ucbServiceGrid1 = new Fwk.ServiceManagement.Tools.Win32.UCBServiceGrid();
            this.ctrlService1 = new Fwk.ServiceManagement.Tools.Win32.ctrlService();
            this.provider1 = new Fwk.ServiceManagement.Tools.Win32.provider();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEdit.Image = global::Fwk.ServiceManagement.Tools.Win32.Properties.Resources.EditService;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(104, 4);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(92, 54);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Image = global::Fwk.ServiceManagement.Tools.Win32.Properties.Resources.AddService;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(4, 4);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 54);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Image = global::Fwk.ServiceManagement.Tools.Win32.Properties.Resources.Delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(204, 4);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 54);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCnnString
            // 
            this.btnCnnString.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCnnString.Image = ((System.Drawing.Image)(resources.GetObject("btnCnnString.Image")));
            this.btnCnnString.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCnnString.Name = "btnCnnString";
            this.btnCnnString.Size = new System.Drawing.Size(23, 22);
            this.btnCnnString.Text = "Connect";
            this.btnCnnString.ToolTipText = "Connect to database";
            // 
            // lblServerName
            // 
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(61, 22);
            this.lblServerName.Text = "Server : ";
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(79, 22);
            this.lblDatabaseName.Text = "Database: ";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.ToolTipText = "Refresh connection";
            // 
            // txtSchemPath
            // 
            this.txtSchemPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSchemPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtSchemPath.Name = "txtSchemPath";
            this.txtSchemPath.Size = new System.Drawing.Size(300, 25);
            // 
            // btnSearchXmlFile
            // 
            this.btnSearchXmlFile.Name = "btnSearchXmlFile";
            this.btnSearchXmlFile.Size = new System.Drawing.Size(23, 22);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCnnString,
            this.lblServerName,
            this.lblDatabaseName,
            this.btnRefresh,
            this.txtSchemPath,
            this.btnSearchXmlFile,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(817, 25);
            this.toolStrip1.TabIndex = 37;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewProvider,
            this.connectToolStripMenuItem,
            this.providersToolStripMenuItem,
            this.cmbProviders,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1620, 32);
            this.menuStrip1.TabIndex = 37;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnNewProvider
            // 
            this.btnNewProvider.Image = global::Fwk.ServiceManagement.Tools.Win32.Properties.Resources.AddService;
            this.btnNewProvider.Name = "btnNewProvider";
            this.btnNewProvider.Size = new System.Drawing.Size(125, 28);
            this.btnNewProvider.Text = "Add provider";
            this.btnNewProvider.Click += new System.EventHandler(this.btnNewProvider_Click);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Image = global::Fwk.ServiceManagement.Tools.Win32.Properties.Resources.langicon;
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(164, 28);
            this.connectToolStripMenuItem.Text = "Connect to services";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // providersToolStripMenuItem
            // 
            this.providersToolStripMenuItem.Name = "providersToolStripMenuItem";
            this.providersToolStripMenuItem.Size = new System.Drawing.Size(82, 28);
            this.providersToolStripMenuItem.Text = "Providers";
            // 
            // cmbProviders
            // 
            this.cmbProviders.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbProviders.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbProviders.ForeColor = System.Drawing.Color.Maroon;
            this.cmbProviders.Name = "cmbProviders";
            this.cmbProviders.Size = new System.Drawing.Size(160, 28);
            this.cmbProviders.ToolTipText = "Select metadata provider";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(64, 28);
            this.toolStripMenuItem1.Text = "Export";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(7, 31);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucbServiceGrid1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ctrlService1);
            this.splitContainer1.Panel2.Controls.Add(this.provider1);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1597, 718);
            this.splitContainer1.SplitterDistance = 709;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(637, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 17);
            this.label4.TabIndex = 46;
            this.label4.Text = "---";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(17, 657);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(820, 63);
            this.flowLayoutPanel1.TabIndex = 39;
            // 
            // lblMetaqadata
            // 
            this.lblMetaqadata.AutoSize = true;
            this.lblMetaqadata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetaqadata.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMetaqadata.Location = new System.Drawing.Point(250, 85);
            this.lblMetaqadata.Name = "lblMetaqadata";
            this.lblMetaqadata.Size = new System.Drawing.Size(109, 13);
            this.lblMetaqadata.TabIndex = 45;
            this.lblMetaqadata.Text = "<<<<<<<<<<<<<<<<<";
            // 
            // ucbServiceGrid1
            // 
            this.ucbServiceGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucbServiceGrid1.Applications = null;
            this.ucbServiceGrid1.CurentServiceConfiguration = null;
            this.ucbServiceGrid1.Location = new System.Drawing.Point(5, 2);
            this.ucbServiceGrid1.Margin = new System.Windows.Forms.Padding(5);
            this.ucbServiceGrid1.Name = "ucbServiceGrid1";
            this.ucbServiceGrid1.Services = null;
            this.ucbServiceGrid1.Size = new System.Drawing.Size(705, 704);
            this.ucbServiceGrid1.TabIndex = 0;
            this.ucbServiceGrid1.OnClickServiceHandler += new Fwk.ServiceManagement.Tools.Win32.OnClickServiceHandler(this.ucbServiceGrid1_OnClickServiceHandler);
            // 
            // ctrlService1
            // 
            this.ctrlService1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlService1.EntityParam = null;
            this.ctrlService1.EntityResult = null;
            this.ctrlService1.Location = new System.Drawing.Point(8, 107);
            this.ctrlService1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctrlService1.Name = "ctrlService1";
            this.ctrlService1.ShowAction = Fwk.ServiceManagement.Tools.Win32.Action.Query;
            this.ctrlService1.Size = new System.Drawing.Size(829, 540);
            this.ctrlService1.TabIndex = 52;
            // 
            // provider1
            // 
            this.provider1.Location = new System.Drawing.Point(12, 2);
            this.provider1.Margin = new System.Windows.Forms.Padding(5);
            this.provider1.Name = "provider1";
            this.provider1.Size = new System.Drawing.Size(851, 107);
            this.provider1.TabIndex = 51;
            // 
            // frmServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1620, 752);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmServices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Services configuration";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ToolStripLabel lblServerName;
        private System.Windows.Forms.ToolStripLabel lblDatabaseName;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripTextBox txtSchemPath;
        private System.Windows.Forms.ToolStripButton btnSearchXmlFile;
        private System.Windows.Forms.ToolStripButton btnCnnString;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
      
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMetaqadata;
        private UCBServiceGrid ucbServiceGrid1;
        private System.Windows.Forms.ToolStripComboBox cmbProviders;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btnNewProvider;
        private System.Windows.Forms.ToolStripMenuItem providersToolStripMenuItem;
        private provider provider1;
        private ctrlService ctrlService1;
       
        
	}
}

