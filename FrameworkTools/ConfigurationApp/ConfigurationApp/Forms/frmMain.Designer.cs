namespace ConfigurationApp
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dockPanelConfigManager1 = new ConfigurationApp.Forms.dockPanelConfigManager();
            this.clienteDeDespachadorDeServicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuNewAppClientConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuLoadAppClientConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemSaveAllFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemRefreshAllFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAppClientConfig = new System.Windows.Forms.ToolStrip();
            this.tsButtonRefreshAll = new System.Windows.Forms.ToolStripButton();
            this.btnNewProvider = new System.Windows.Forms.ToolStripButton();
            this.btnQuitProvider = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.btnExportXmlToBd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripAppClientConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 60);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dockPanelConfigManager1);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(1632, 621);
            this.splitContainer1.SplitterDistance = 395;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // dockPanelConfigManager1
            // 
            this.dockPanelConfigManager1.AllowDrop = true;
            this.dockPanelConfigManager1.BackColor = System.Drawing.Color.GhostWhite;
            this.dockPanelConfigManager1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanelConfigManager1.Location = new System.Drawing.Point(0, 0);
            this.dockPanelConfigManager1.Margin = new System.Windows.Forms.Padding(4);
            this.dockPanelConfigManager1.Name = "dockPanelConfigManager1";
            this.dockPanelConfigManager1.Panel = null;
            this.dockPanelConfigManager1.Size = new System.Drawing.Size(395, 621);
            this.dockPanelConfigManager1.TabIndex = 0;
            // 
            // clienteDeDespachadorDeServicioToolStripMenuItem
            // 
            this.clienteDeDespachadorDeServicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuNewAppClientConfig,
            this.tsMenuLoadAppClientConfig});
            this.clienteDeDespachadorDeServicioToolStripMenuItem.Name = "clienteDeDespachadorDeServicioToolStripMenuItem";
            this.clienteDeDespachadorDeServicioToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.clienteDeDespachadorDeServicioToolStripMenuItem.Text = "App Config";
            // 
            // tsMenuNewAppClientConfig
            // 
            this.tsMenuNewAppClientConfig.Image = global::ConfigurationApp.Properties.Resources.documents_small;
            this.tsMenuNewAppClientConfig.Name = "tsMenuNewAppClientConfig";
            this.tsMenuNewAppClientConfig.Size = new System.Drawing.Size(114, 24);
            this.tsMenuNewAppClientConfig.Text = "New";
            // 
            // tsMenuLoadAppClientConfig
            // 
            this.tsMenuLoadAppClientConfig.Image = global::ConfigurationApp.Properties.Resources.open_folder_small;
            this.tsMenuLoadAppClientConfig.Name = "tsMenuLoadAppClientConfig";
            this.tsMenuLoadAppClientConfig.Size = new System.Drawing.Size(114, 24);
            this.tsMenuLoadAppClientConfig.Text = "Open";
            // 
            // tsMenuItemSave
            // 
            this.tsMenuItemSave.Image = global::ConfigurationApp.Properties.Resources.save_small;
            this.tsMenuItemSave.Name = "tsMenuItemSave";
            this.tsMenuItemSave.Size = new System.Drawing.Size(145, 22);
            this.tsMenuItemSave.Text = "Save";
            // 
            // tsMenuItemSaveAllFiles
            // 
            this.tsMenuItemSaveAllFiles.Image = global::ConfigurationApp.Properties.Resources.save_as_small;
            this.tsMenuItemSaveAllFiles.Name = "tsMenuItemSaveAllFiles";
            this.tsMenuItemSaveAllFiles.Size = new System.Drawing.Size(145, 22);
            this.tsMenuItemSaveAllFiles.Text = "Save All";
            // 
            // tsMenuItemRefreshAllFiles
            // 
            this.tsMenuItemRefreshAllFiles.Image = global::ConfigurationApp.Properties.Resources.Refresh;
            this.tsMenuItemRefreshAllFiles.Name = "tsMenuItemRefreshAllFiles";
            this.tsMenuItemRefreshAllFiles.Size = new System.Drawing.Size(145, 22);
            this.tsMenuItemRefreshAllFiles.Text = "Refresh all";
            this.tsMenuItemRefreshAllFiles.Click += new System.EventHandler(this.tsMenuItemRefreshAllFiles_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::ConfigurationApp.Properties.Resources.file_add_16;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::ConfigurationApp.Properties.Resources.open_folder_large;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // toolStripAppClientConfig
            // 
            this.toolStripAppClientConfig.BackColor = System.Drawing.Color.Transparent;
            this.toolStripAppClientConfig.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripAppClientConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButtonRefreshAll,
            this.btnNewProvider,
            this.btnQuitProvider,
            this.btnExport,
            this.btnExportXmlToBd,
            this.toolStripSeparator,
            this.toolStripSeparator1,
            this.helpToolStripButton});
            this.toolStripAppClientConfig.Location = new System.Drawing.Point(0, 30);
            this.toolStripAppClientConfig.Name = "toolStripAppClientConfig";
            this.toolStripAppClientConfig.Size = new System.Drawing.Size(139, 25);
            this.toolStripAppClientConfig.TabIndex = 7;
            this.toolStripAppClientConfig.Text = "toolStrip1";
            // 
            // tsButtonRefreshAll
            // 
            this.tsButtonRefreshAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButtonRefreshAll.Image = global::ConfigurationApp.Properties.Resources.Refresh;
            this.tsButtonRefreshAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonRefreshAll.Name = "tsButtonRefreshAll";
            this.tsButtonRefreshAll.Size = new System.Drawing.Size(23, 22);
            this.tsButtonRefreshAll.Text = "Refresh all files";
            this.tsButtonRefreshAll.Click += new System.EventHandler(this.tsButtonRefreshAll_Click);
            // 
            // btnNewProvider
            // 
            this.btnNewProvider.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNewProvider.Image = global::ConfigurationApp.Properties.Resources.documents_small;
            this.btnNewProvider.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewProvider.Name = "btnNewProvider";
            this.btnNewProvider.Size = new System.Drawing.Size(23, 22);
            this.btnNewProvider.Text = "&New";
            this.btnNewProvider.ToolTipText = "Create new file";
            this.btnNewProvider.Click += new System.EventHandler(this.btnNewProvider_Click);
            // 
            // btnQuitProvider
            // 
            this.btnQuitProvider.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnQuitProvider.Image = global::ConfigurationApp.Properties.Resources.file_del_16;
            this.btnQuitProvider.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuitProvider.Name = "btnQuitProvider";
            this.btnQuitProvider.Size = new System.Drawing.Size(23, 22);
            this.btnQuitProvider.Text = "Quit";
            this.btnQuitProvider.ToolTipText = "Quit the selected file";
            // 
            // btnExport
            // 
            this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExport.Image = global::ConfigurationApp.Properties.Resources.export_16;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(23, 22);
            this.btnExport.Text = "Export";
            this.btnExport.ToolTipText = "Print selected file";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExportXmlToBd
            // 
            this.btnExportXmlToBd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportXmlToBd.Image = ((System.Drawing.Image)(resources.GetObject("btnExportXmlToBd.Image")));
            this.btnExportXmlToBd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportXmlToBd.Name = "btnExportXmlToBd";
            this.btnExportXmlToBd.Size = new System.Drawing.Size(23, 22);
            this.btnExportXmlToBd.Text = "toolStripButton1";
            this.btnExportXmlToBd.Click += new System.EventHandler(this.btnExportXmlToBd_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            this.helpToolStripButton.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(157, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(904, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Para agregar  un nuevo ConfigManager debe editar el archivo .config de esta aplic" +
    "acion agregando un nuevo proveedor.-";
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1682, 701);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStripAppClientConfig);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmMain";
            this.Text = "Fwk libraries configuration";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStripAppClientConfig.ResumeLayout(false);
            this.toolStripAppClientConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        
        
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteDeDespachadorDeServicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsMenuNewAppClientConfig;
        private System.Windows.Forms.ToolStripMenuItem tsMenuLoadAppClientConfig;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemSaveAllFiles;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemRefreshAllFiles;

        private System.Windows.Forms.ToolStrip toolStripAppClientConfig;
        private System.Windows.Forms.ToolStripButton tsButtonRefreshAll;
        private System.Windows.Forms.ToolStripButton btnNewProvider;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton btnQuitProvider;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton btnExportXmlToBd;
        private Forms.dockPanelConfigManager dockPanelConfigManager1;
    }
}

