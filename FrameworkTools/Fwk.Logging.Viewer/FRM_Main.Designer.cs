namespace Fwk.Logging.Viewer
{
    partial class FRM_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Main));
            this.ctlStatus = new System.Windows.Forms.StatusStrip();
            this.ctlNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctlContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuMostrar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenFromDB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMenu = new System.Windows.Forms.MenuStrip();
            this.fwkMessageViewComponent1 = new Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent(this.components);
            this.ExceptionViewer = new Fwk.Bases.FrontEnd.Controls.FwkExceptionViewComponent(this.components);
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlContextMenu.SuspendLayout();
            this.mnuMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctlStatus
            // 
            this.ctlStatus.Location = new System.Drawing.Point(0, 504);
            this.ctlStatus.Name = "ctlStatus";
            this.ctlStatus.Size = new System.Drawing.Size(623, 22);
            this.ctlStatus.TabIndex = 2;
            this.ctlStatus.Text = "statusStrip1";
            // 
            // ctlNotify
            // 
            this.ctlNotify.ContextMenuStrip = this.ctlContextMenu;
            this.ctlNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("ctlNotify.Icon")));
            this.ctlNotify.Text = "Fwk - Logging Viewer";
            this.ctlNotify.Visible = true;
            this.ctlNotify.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ctlNotify_MouseDoubleClick);
            // 
            // ctlContextMenu
            // 
            this.ctlContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMostrar,
            this.mnuSalir});
            this.ctlContextMenu.Name = "ctlContextMenu";
            this.ctlContextMenu.Size = new System.Drawing.Size(123, 48);
            // 
            // mnuMostrar
            // 
            this.mnuMostrar.Image = ((System.Drawing.Image)(resources.GetObject("mnuMostrar.Image")));
            this.mnuMostrar.Name = "mnuMostrar";
            this.mnuMostrar.Size = new System.Drawing.Size(122, 22);
            this.mnuMostrar.Text = "&Mostrar";
            this.mnuMostrar.Click += new System.EventHandler(this.mnuMostrar_Click);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Image = ((System.Drawing.Image)(resources.GetObject("mnuSalir.Image")));
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(122, 22);
            this.mnuSalir.Text = "&Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.mnuOpenFromDB,
            this.toolStripMenuItem1,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(36, 20);
            this.mnuFile.Text = "Log";
            // 
            // mnuOpen
            // 
            this.mnuOpen.Image = ((System.Drawing.Image)(resources.GetObject("mnuOpen.Image")));
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(184, 22);
            this.mnuOpen.Text = "Open xml log file";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuOpenFromDB
            // 
            this.mnuOpenFromDB.Image = ((System.Drawing.Image)(resources.GetObject("mnuOpenFromDB.Image")));
            this.mnuOpenFromDB.Name = "mnuOpenFromDB";
            this.mnuOpenFromDB.Size = new System.Drawing.Size(184, 22);
            this.mnuOpenFromDB.Text = "Open from database";
            this.mnuOpenFromDB.Click += new System.EventHandler(this.mnuOpenFromDB_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Image = ((System.Drawing.Image)(resources.GetObject("mnuExit.Image")));
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(184, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.Image = global::Fwk.Logging.Viewer.Properties.Resources.Refresh;
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.actionsToolStripMenuItem.Text = "Refresh";
            this.actionsToolStripMenuItem.Click += new System.EventHandler(this.actionsToolStripMenuItem_Click);
            // 
            // mnuMenu
            // 
            this.mnuMenu.AllowDrop = true;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.actionsToolStripMenuItem,
            this.refreshToolStripMenuItem1});
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Size = new System.Drawing.Size(975, 24);
            this.mnuMenu.TabIndex = 2;
            this.mnuMenu.Text = "menuStrip1";
            this.mnuMenu.DragDrop += new System.Windows.Forms.DragEventHandler(this.mnuMenu_DragDrop);
            this.mnuMenu.DragEnter += new System.Windows.Forms.DragEventHandler(this.mnuMenu_DragEnter);
            // 
            // fwkMessageViewComponent1
            // 
            this.fwkMessageViewComponent1.BackColor = System.Drawing.Color.SteelBlue;
            this.fwkMessageViewComponent1.IconSize = Fwk.Bases.FrontEnd.Controls.IconSize.Small;
            this.fwkMessageViewComponent1.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.fwkMessageViewComponent1.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Information;
            this.fwkMessageViewComponent1.TextMessageColor = System.Drawing.Color.SteelBlue;
            this.fwkMessageViewComponent1.TextMessageForeColor = System.Drawing.Color.PaleGoldenrod;
            this.fwkMessageViewComponent1.Title = "Message";
            // 
            // ExceptionViewer
            // 
            this.ExceptionViewer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ExceptionViewer.TextMessageColor = System.Drawing.Color.White;
            this.ExceptionViewer.TextMessageForeColorColor = System.Drawing.SystemColors.WindowText;
            this.ExceptionViewer.Title = "FrmTechnicalMsg";
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Image = global::Fwk.Logging.Viewer.Properties.Resources.Error;
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(53, 20);
            this.refreshToolStripMenuItem1.Text = "Exit";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.refreshToolStripMenuItem1_Click);
            // 
            // FRM_Main
            // 
            this.AllowDrop = true;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(975, 675);
            this.Controls.Add(this.mnuMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "FRM_Main";
            this.ShowInTaskbar = false;
            this.Text = "Fwk Log Viewer ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FRM_Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FRM_Main_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FRM_Main_KeyDown);
            this.ctlContextMenu.ResumeLayout(false);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.StatusStrip ctlStatus;
 
        private System.Windows.Forms.NotifyIcon ctlNotify;
        private System.Windows.Forms.ContextMenuStrip ctlContextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuMostrar;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;

        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenFromDB;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mnuMenu;
        private Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent fwkMessageViewComponent1;
        private Fwk.Bases.FrontEnd.Controls.FwkExceptionViewComponent ExceptionViewer;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;

    }
}

