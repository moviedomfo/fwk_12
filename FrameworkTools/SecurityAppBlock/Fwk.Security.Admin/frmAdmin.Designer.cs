using Fwk.Security.Common;
namespace Fwk.Security.Admin
{
    partial class frmAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdmin));
            this.button1 = new System.Windows.Forms.Button();
            this.lbltitle = new System.Windows.Forms.Label();
            this.fwkMessageViewInfo = new Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent(this.components);
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup_Users = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem_UserCreate = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_AssingRoles = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup_Groups = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem_RoleCreate = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup_Rules = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem_CreateRule = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_Check_Rule = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_CategoryCreate = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem_Encrypt = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_CreateUser = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_AddRoles = new DevExpress.XtraNavBar.NavBarItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.userAdmin1 = new Fwk.Security.Admin.Controls.UserAdmin();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProviders = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.btnRefreshConnection = new DevExpress.XtraEditors.SimpleButton();
            this.lblCnnString = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProviders.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(764, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lbltitle
            // 
            this.lbltitle.BackColor = System.Drawing.Color.White;
            this.lbltitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbltitle.Location = new System.Drawing.Point(0, 0);
            this.lbltitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(1313, 118);
            this.lbltitle.TabIndex = 2;
            this.lbltitle.Text = "Security admin";
            this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkMessageViewInfo
            // 
            this.fwkMessageViewInfo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.fwkMessageViewInfo.IconSize = Fwk.Bases.FrontEnd.Controls.IconSize.Small;
            this.fwkMessageViewInfo.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.fwkMessageViewInfo.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Information;
            this.fwkMessageViewInfo.TextMessageColor = System.Drawing.Color.White;
            this.fwkMessageViewInfo.TextMessageForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.fwkMessageViewInfo.Title = "Security admin";
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup_Users;
            this.navBarControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.navBarControl1.ContentButtonHint = null;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup_Users,
            this.navBarGroup_Groups,
            this.navBarGroup_Rules,
            this.navBarGroup1});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem_CreateUser,
            this.navBarItem_AddRoles,
            this.navBarItem_UserCreate,
            this.navBarItem2,
            this.navBarItem_RoleCreate,
            this.navBarItem_CreateRule,
            this.navBarItem_CategoryCreate,
            this.navBarItem_AssingRoles,
            this.navBarItem_Check_Rule,
            this.navBarItem_Encrypt});
            this.navBarControl1.Location = new System.Drawing.Point(9, 124);
            this.navBarControl1.Margin = new System.Windows.Forms.Padding(4);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 177;
            this.navBarControl1.Size = new System.Drawing.Size(236, 651);
            this.navBarControl1.TabIndex = 4;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinExplorerBarViewInfoRegistrator("Money Twins");
            this.navBarControl1.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarControl1_LinkClicked);
            // 
            // navBarGroup_Users
            // 
            this.navBarGroup_Users.Caption = "Users";
            this.navBarGroup_Users.Expanded = true;
            this.navBarGroup_Users.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup_Users.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_UserCreate),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_AssingRoles)});
            this.navBarGroup_Users.LargeImage = global::Fwk.Security.Admin.Properties.Resources.User;
            this.navBarGroup_Users.Name = "navBarGroup_Users";
            // 
            // navBarItem_UserCreate
            // 
            this.navBarItem_UserCreate.Caption = "Add new";
            this.navBarItem_UserCreate.LargeImage = global::Fwk.Security.Admin.Properties.Resources.file_new_32;
            this.navBarItem_UserCreate.Name = "navBarItem_UserCreate";
            this.navBarItem_UserCreate.SmallImage = global::Fwk.Security.Admin.Properties.Resources.file_add_16;
            this.navBarItem_UserCreate.Tag = "Fwk.Security.Admin.Controls.UserCretate, Fwk.Security.Admin";
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "Find/Edit";
            this.navBarItem2.LargeImage = global::Fwk.Security.Admin.Properties.Resources.file_edit_32;
            this.navBarItem2.Name = "navBarItem2";
            this.navBarItem2.SmallImage = global::Fwk.Security.Admin.Properties.Resources.file_edit_16;
            this.navBarItem2.Tag = "Fwk.Security.Admin.Controls.UserAdmin, Fwk.Security.Admin";
            // 
            // navBarItem_AssingRoles
            // 
            this.navBarItem_AssingRoles.Caption = "Assing roles";
            this.navBarItem_AssingRoles.LargeImage = global::Fwk.Security.Admin.Properties.Resources.impt_24;
            this.navBarItem_AssingRoles.Name = "navBarItem_AssingRoles";
            this.navBarItem_AssingRoles.SmallImage = global::Fwk.Security.Admin.Properties.Resources.impt_24;
            this.navBarItem_AssingRoles.Tag = "Fwk.Security.Admin.Controls.UserAssingRoles, Fwk.Security.Admin";
            // 
            // navBarGroup_Groups
            // 
            this.navBarGroup_Groups.Caption = "Roles";
            this.navBarGroup_Groups.Expanded = true;
            this.navBarGroup_Groups.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.navBarGroup_Groups.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_RoleCreate)});
            this.navBarGroup_Groups.LargeImage = global::Fwk.Security.Admin.Properties.Resources.Users;
            this.navBarGroup_Groups.Name = "navBarGroup_Groups";
            this.navBarGroup_Groups.SmallImage = global::Fwk.Security.Admin.Properties.Resources.Users;
            // 
            // navBarItem_RoleCreate
            // 
            this.navBarItem_RoleCreate.Caption = "Add new";
            this.navBarItem_RoleCreate.LargeImage = global::Fwk.Security.Admin.Properties.Resources.file_new_32;
            this.navBarItem_RoleCreate.Name = "navBarItem_RoleCreate";
            this.navBarItem_RoleCreate.SmallImage = global::Fwk.Security.Admin.Properties.Resources.file_add_16;
            this.navBarItem_RoleCreate.Tag = "Fwk.Security.Admin.Controls.RolesCreate,Fwk.Security.Admin";
            // 
            // navBarGroup_Rules
            // 
            this.navBarGroup_Rules.Caption = "Rules & categories ";
            this.navBarGroup_Rules.Expanded = true;
            this.navBarGroup_Rules.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup_Rules.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_CreateRule),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_Check_Rule),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_CategoryCreate)});
            this.navBarGroup_Rules.LargeImage = global::Fwk.Security.Admin.Properties.Resources.admin_24;
            this.navBarGroup_Rules.Name = "navBarGroup_Rules";
            this.navBarGroup_Rules.SmallImage = global::Fwk.Security.Admin.Properties.Resources.admin_16;
            // 
            // navBarItem_CreateRule
            // 
            this.navBarItem_CreateRule.Caption = "Create rule";
            this.navBarItem_CreateRule.LargeImage = global::Fwk.Security.Admin.Properties.Resources.application_list_add_32;
            this.navBarItem_CreateRule.Name = "navBarItem_CreateRule";
            this.navBarItem_CreateRule.Tag = "Fwk.Security.Admin.Controls.RulesAssingControl, Fwk.Security.Admin";
            // 
            // navBarItem_Check_Rule
            // 
            this.navBarItem_Check_Rule.Caption = "Check rule";
            this.navBarItem_Check_Rule.LargeImage = global::Fwk.Security.Admin.Properties.Resources.access_control_ok_32;
            this.navBarItem_Check_Rule.Name = "navBarItem_Check_Rule";
            this.navBarItem_Check_Rule.Tag = "Fwk.Security.Admin.Controls.RulesCheckControl, Fwk.Security.Admin";
            // 
            // navBarItem_CategoryCreate
            // 
            this.navBarItem_CategoryCreate.Caption = "Organize rules";
            this.navBarItem_CategoryCreate.LargeImage = global::Fwk.Security.Admin.Properties.Resources.map_32;
            this.navBarItem_CategoryCreate.Name = "navBarItem_CategoryCreate";
            this.navBarItem_CategoryCreate.SmallImage = global::Fwk.Security.Admin.Properties.Resources.map_16;
            this.navBarItem_CategoryCreate.Tag = "Fwk.Security.Admin.Controls.RulesEditControl, Fwk.Security.Admin";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Connections";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_Encrypt)});
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarGroup1.SmallImage = global::Fwk.Security.Admin.Properties.Resources.dbs;
            // 
            // navBarItem_Encrypt
            // 
            this.navBarItem_Encrypt.Caption = "Encrypt";
            this.navBarItem_Encrypt.Name = "navBarItem_Encrypt";
            this.navBarItem_Encrypt.SmallImage = global::Fwk.Security.Admin.Properties.Resources.admin_16;
            this.navBarItem_Encrypt.Tag = "Fwk.Security.Admin.Controls.ConnectionStringsCrypt,Fwk.Security.Admin";
            // 
            // navBarItem_CreateUser
            // 
            this.navBarItem_CreateUser.Caption = "Crear";
            this.navBarItem_CreateUser.LargeImage = global::Fwk.Security.Admin.Properties.Resources.User;
            this.navBarItem_CreateUser.Name = "navBarItem_CreateUser";
            // 
            // navBarItem_AddRoles
            // 
            this.navBarItem_AddRoles.Caption = "Asignar roles";
            this.navBarItem_AddRoles.LargeImage = global::Fwk.Security.Admin.Properties.Resources.roles_32;
            this.navBarItem_AddRoles.Name = "navBarItem_AddRoles";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.AutoSize = true;
            this.panelControl1.Controls.Add(this.userAdmin1);
            this.panelControl1.Location = new System.Drawing.Point(253, 122);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1044, 653);
            this.panelControl1.TabIndex = 5;
            // 
            // userAdmin1
            // 
            this.userAdmin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userAdmin1.Location = new System.Drawing.Point(2, 2);
            this.userAdmin1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.userAdmin1.Name = "userAdmin1";
            this.userAdmin1.Size = new System.Drawing.Size(1040, 649);
            this.userAdmin1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(13, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Security provide";
            // 
            // cmbProviders
            // 
            this.cmbProviders.Location = new System.Drawing.Point(144, 13);
            this.cmbProviders.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProviders.Name = "cmbProviders";
            this.cmbProviders.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProviders.Size = new System.Drawing.Size(231, 22);
            this.cmbProviders.TabIndex = 20;
            this.cmbProviders.EditValueChanged += new System.EventHandler(this.cmbProviders_EditValueChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(13, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Server";
            // 
            // lblServer
            // 
            this.lblServer.BackColor = System.Drawing.Color.White;
            this.lblServer.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServer.ForeColor = System.Drawing.Color.DimGray;
            this.lblServer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblServer.Location = new System.Drawing.Point(93, 78);
            this.lblServer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(189, 20);
            this.lblServer.TabIndex = 22;
            this.lblServer.Text = "Server";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(13, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Database";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblDatabase
            // 
            this.lblDatabase.BackColor = System.Drawing.Color.White;
            this.lblDatabase.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabase.ForeColor = System.Drawing.Color.DimGray;
            this.lblDatabase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDatabase.Location = new System.Drawing.Point(93, 98);
            this.lblDatabase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(72, 20);
            this.lblDatabase.TabIndex = 24;
            this.lblDatabase.Text = "Database";
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.BackColor = System.Drawing.Color.White;
            this.lblConnectionStatus.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionStatus.ForeColor = System.Drawing.Color.Tomato;
            this.lblConnectionStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblConnectionStatus.Location = new System.Drawing.Point(141, 39);
            this.lblConnectionStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(108, 20);
            this.lblConnectionStatus.TabIndex = 25;
            this.lblConnectionStatus.Text = "Disconnected";
            // 
            // btnRefreshConnection
            // 
            this.btnRefreshConnection.Image = global::Fwk.Security.Admin.Properties.Resources.Connection_Warning;
            this.btnRefreshConnection.Location = new System.Drawing.Point(413, 12);
            this.btnRefreshConnection.Name = "btnRefreshConnection";
            this.btnRefreshConnection.Size = new System.Drawing.Size(154, 31);
            this.btnRefreshConnection.TabIndex = 26;
            this.btnRefreshConnection.Text = "Try connect";
            this.btnRefreshConnection.Click += new System.EventHandler(this.btnRefreshConnection_Click);
            // 
            // lblCnnString
            // 
            this.lblCnnString.AutoSize = true;
            this.lblCnnString.BackColor = System.Drawing.Color.White;
            this.lblCnnString.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCnnString.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblCnnString.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCnnString.Location = new System.Drawing.Point(457, 99);
            this.lblCnnString.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCnnString.Name = "lblCnnString";
            this.lblCnnString.Size = new System.Drawing.Size(71, 17);
            this.lblCnnString.TabIndex = 27;
            this.lblCnnString.Text = "Cnn string";
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 801);
            this.Controls.Add(this.lblCnnString);
            this.Controls.Add(this.btnRefreshConnection);
            this.Controls.Add(this.lblConnectionStatus);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProviders);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmAdmin";
            this.Text = "Security admin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbProviders.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbltitle;
        private Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent fwkMessageViewInfo;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup_Users;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup_Groups;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup_Rules;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_CreateUser;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_AddRoles;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_UserCreate;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_RoleCreate;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_CreateRule;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_CategoryCreate;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_AssingRoles;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_Check_Rule;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit cmbProviders;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_Encrypt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Label lblConnectionStatus;
        private Controls.UserAdmin userAdmin1;
        private DevExpress.XtraEditors.SimpleButton btnRefreshConnection;
        private System.Windows.Forms.Label lblCnnString;
    }
}

