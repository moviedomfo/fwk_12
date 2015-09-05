namespace Fwk.Bases.FrontEnd.MenuContainer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.treeViewDesingner = new System.Windows.Forms.TreeView();
            this.toolStripAppClientConfig = new System.Windows.Forms.ToolStrip();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.fwkMessageView_Warning = new Fwk.Bases.FrontEnd.UserControls.FwkMessageViewComponent(this.components);
            this.fwkMessageView_Error = new Fwk.Bases.FrontEnd.UserControls.FwkMessageViewComponent(this.components);
            this.lblFileLoad = new System.Windows.Forms.Label();
            this.menuItemEditor1 = new Fwk.Bases.FrontEnd.MenuContainer.MenuItemEditor();
            this.toolStripAppClientConfig.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewDesingner
            // 
            this.treeViewDesingner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewDesingner.Location = new System.Drawing.Point(1, 29);
            this.treeViewDesingner.Name = "treeViewDesingner";
            this.treeViewDesingner.Size = new System.Drawing.Size(344, 537);
            this.treeViewDesingner.TabIndex = 1;
            this.treeViewDesingner.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDesingner_AfterSelect);
            this.treeViewDesingner.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewDesingner_NodeMouseClick);
            // 
            // toolStripAppClientConfig
            // 
            this.toolStripAppClientConfig.BackColor = System.Drawing.Color.Transparent;
            this.toolStripAppClientConfig.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripAppClientConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripButton,
            this.newToolStripButton,
            this.openToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator,
            this.toolStripSeparator1,
            this.refreshToolStripButton});
            this.toolStripAppClientConfig.Location = new System.Drawing.Point(3, 4);
            this.toolStripAppClientConfig.Name = "toolStripAppClientConfig";
            this.toolStripAppClientConfig.Size = new System.Drawing.Size(139, 25);
            this.toolStripAppClientConfig.TabIndex = 11;
            this.toolStripAppClientConfig.Text = "toolStrip1";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.ToolTipText = "Save the selected file";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.ToolTipText = "Create new file";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.ToolTipText = "Open existent file";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "&Print";
            this.printToolStripButton.ToolTipText = "Print selected file";
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
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolStripButton.Image = global::Fwk.Bases.FrontEnd.MenuContainer.Properties.Resources.fwk_Refresh;
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.refreshToolStripButton.Text = "toolStripButton1";
            this.refreshToolStripButton.Click += new System.EventHandler(this.refreshToolStripButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(352, 30);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(628, 51);
            this.flowLayoutPanel1.TabIndex = 40;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Image = global::Fwk.Bases.FrontEnd.MenuContainer.Properties.Resources.add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(69, 44);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEdit.Image = global::Fwk.Bases.FrontEnd.MenuContainer.Properties.Resources.EditInformationHS;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(78, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(69, 44);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Image = global::Fwk.Bases.FrontEnd.MenuContainer.Properties.Resources.fwk_delete_16x;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(153, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(69, 44);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // fwkMessageView_Warning
            // 
            this.fwkMessageView_Warning.BackColor = System.Drawing.Color.SteelBlue;
            this.fwkMessageView_Warning.Icon = Fwk.Bases.FrontEnd.UserControls.MessageBoxIcon.Warning;
            this.fwkMessageView_Warning.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.fwkMessageView_Warning.TextMessageColor = System.Drawing.Color.SteelBlue;
            this.fwkMessageView_Warning.TextMessageForeColorColor = System.Drawing.Color.PaleGoldenrod;
            this.fwkMessageView_Warning.Title = "Menu item editor";
            // 
            // fwkMessageView_Error
            // 
            this.fwkMessageView_Error.BackColor = System.Drawing.Color.SteelBlue;
            this.fwkMessageView_Error.Icon = Fwk.Bases.FrontEnd.UserControls.MessageBoxIcon.Error;
            this.fwkMessageView_Error.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.fwkMessageView_Error.TextMessageColor = System.Drawing.Color.SteelBlue;
            this.fwkMessageView_Error.TextMessageForeColorColor = System.Drawing.Color.PaleGoldenrod;
            this.fwkMessageView_Error.Title = "Message";
            // 
            // lblFileLoad
            // 
            this.lblFileLoad.AutoSize = true;
            this.lblFileLoad.Location = new System.Drawing.Point(166, 9);
            this.lblFileLoad.Name = "lblFileLoad";
            this.lblFileLoad.Size = new System.Drawing.Size(29, 13);
            this.lblFileLoad.TabIndex = 41;
            this.lblFileLoad.Text = "File: ";
            // 
            // menuItemEditor1
            // 
            this.menuItemEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.menuItemEditor1.BackColor = System.Drawing.Color.White;
            this.menuItemEditor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.menuItemEditor1.EntityParam = null;
            this.menuItemEditor1.EntityResult = null;
            this.menuItemEditor1.Location = new System.Drawing.Point(351, 87);
            this.menuItemEditor1.Name = "menuItemEditor1";
            this.menuItemEditor1.ShowAction = Fwk.Bases.FrontEnd.MenuContainer.Action.Query;
            this.menuItemEditor1.Size = new System.Drawing.Size(628, 479);
            this.menuItemEditor1.TabIndex = 12;
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 578);
            this.Controls.Add(this.lblFileLoad);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuItemEditor1);
            this.Controls.Add(this.toolStripAppClientConfig);
            this.Controls.Add(this.treeViewDesingner);
            this.Name = "frmMain";
            this.Text = "Menu item editor";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmMain_DragEnter);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.toolStripAppClientConfig.ResumeLayout(false);
            this.toolStripAppClientConfig.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewDesingner;
        private System.Windows.Forms.ToolStrip toolStripAppClientConfig;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private MenuItemEditor menuItemEditor1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private Fwk.Bases.FrontEnd.UserControls.FwkMessageViewComponent fwkMessageView_Warning;
        private Fwk.Bases.FrontEnd.UserControls.FwkMessageViewComponent fwkMessageView_Error;
        private System.Windows.Forms.Label lblFileLoad;
    }
}

