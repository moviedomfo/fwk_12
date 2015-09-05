using Fwk.Bases.FrontEnd.Controls;
namespace Fwk.Security.ActiveDirectory.Test
{
    partial class frmTest
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
            this.lbltitle = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageUsers = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userByAppBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.rolNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblRolesByUser = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtUserFullName = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.domainUsers1 = new Fwk.Security.ActiveDirectory.Test.DomainUsers();
            this.domainGoups2 = new Fwk.Security.ActiveDirectory.Test.DomainGoups();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.btnSearchInDomain = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnUsersList = new System.Windows.Forms.Button();
            this.tabPageRoles = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.txtRolName = new DevExpress.XtraEditors.TextEdit();
            this.lblrolSelected = new System.Windows.Forms.Label();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.btnCrearRol = new System.Windows.Forms.Button();
            this.btnRoles = new System.Windows.Forms.Button();
            this.dataGridViewRoles = new System.Windows.Forms.DataGridView();
            this.tabPageAsingRol = new System.Windows.Forms.TabPage();
            this.lstBoxRoles = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.btnAsignarRoles = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.fwkMessageViewInfo = new FwkMessageViewComponent(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPageUsers.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userByAppBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolListBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPageRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRolName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoles)).BeginInit();
            this.tabPageAsingRol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstBoxRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // lbltitle
            // 
            this.lbltitle.BackColor = System.Drawing.Color.White;
            this.lbltitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbltitle.Location = new System.Drawing.Point(0, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(1103, 48);
            this.lbltitle.TabIndex = 3;
            this.lbltitle.Text = "Security admin";
            this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageUsers);
            this.tabControl1.Controls.Add(this.tabPageRoles);
            this.tabControl1.Controls.Add(this.tabPageAsingRol);
            this.tabControl1.Location = new System.Drawing.Point(3, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1079, 653);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPageUsers
            // 
            this.tabPageUsers.Controls.Add(this.groupBox3);
            this.tabPageUsers.Controls.Add(this.groupBox2);
            this.tabPageUsers.Controls.Add(this.groupBox1);
            this.tabPageUsers.Controls.Add(this.button2);
            this.tabPageUsers.Controls.Add(this.btnUsersList);
            this.tabPageUsers.Location = new System.Drawing.Point(4, 22);
            this.tabPageUsers.Name = "tabPageUsers";
            this.tabPageUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUsers.Size = new System.Drawing.Size(1071, 627);
            this.tabPageUsers.TabIndex = 0;
            this.tabPageUsers.Text = "Users";
            this.tabPageUsers.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Controls.Add(this.lblRolesByUser);
            this.groupBox3.Location = new System.Drawing.Point(344, 192);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(699, 419);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ASP Database";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn,
            this.appNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.userByAppBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(278, 383);
            this.dataGridView1.TabIndex = 2;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "UserName";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            // 
            // appNameDataGridViewTextBoxColumn
            // 
            this.appNameDataGridViewTextBoxColumn.DataPropertyName = "AppName";
            this.appNameDataGridViewTextBoxColumn.HeaderText = "AppName";
            this.appNameDataGridViewTextBoxColumn.Name = "appNameDataGridViewTextBoxColumn";
            // 
            // userByAppBindingSource
            // 
            this.userByAppBindingSource.DataSource = typeof(Fwk.Security.Common.User);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rolNameDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.rolListBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(290, 29);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(290, 384);
            this.dataGridView2.TabIndex = 6;
            // 
            // rolNameDataGridViewTextBoxColumn
            // 
            this.rolNameDataGridViewTextBoxColumn.DataPropertyName = "RolName";
            this.rolNameDataGridViewTextBoxColumn.HeaderText = "RolName";
            this.rolNameDataGridViewTextBoxColumn.Name = "rolNameDataGridViewTextBoxColumn";
            // 
            // rolListBindingSource
            // 
            this.rolListBindingSource.DataSource = typeof(Fwk.Security.Common.RolList);
            // 
            // lblRolesByUser
            // 
            this.lblRolesByUser.Location = new System.Drawing.Point(287, 8);
            this.lblRolesByUser.Name = "lblRolesByUser";
            this.lblRolesByUser.Size = new System.Drawing.Size(238, 18);
            this.lblRolesByUser.TabIndex = 9;
            this.lblRolesByUser.Text = "Roles";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtUserFullName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnCreateUser);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtUserName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Location = new System.Drawing.Point(350, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 148);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Info";
            // 
            // txtUserFullName
            // 
            this.txtUserFullName.Enabled = false;
            this.txtUserFullName.Location = new System.Drawing.Point(126, 19);
            this.txtUserFullName.Name = "txtUserFullName";
            this.txtUserFullName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtUserFullName.Properties.Appearance.Options.UseBackColor = true;
            this.txtUserFullName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtUserFullName.Size = new System.Drawing.Size(153, 22);
            this.txtUserFullName.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(7, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 18);
            this.label5.TabIndex = 21;
            this.label5.Text = "Full Name";
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.BackColor = System.Drawing.Color.White;
            this.btnCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateUser.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCreateUser.Location = new System.Drawing.Point(11, 117);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(96, 23);
            this.btnCreateUser.TabIndex = 1;
            this.btnCreateUser.Text = "Add this user";
            this.btnCreateUser.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnCreateUser.UseVisualStyleBackColor = false;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(8, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "Password";
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Location = new System.Drawing.Point(126, 47);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtUserName.Properties.Appearance.Options.UseBackColor = true;
            this.txtUserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtUserName.Size = new System.Drawing.Size(153, 22);
            this.txtUserName.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(8, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "Name";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(126, 86);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtPassword.Properties.Appearance.Options.UseBackColor = true;
            this.txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtPassword.Size = new System.Drawing.Size(153, 22);
            this.txtPassword.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.domainUsers1);
            this.groupBox1.Controls.Add(this.domainGoups2);
            this.groupBox1.Controls.Add(this.txtDomain);
            this.groupBox1.Controls.Add(this.btnSearchInDomain);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 604);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Domain Info";
            // 
            // domainUsers1
            // 
            this.domainUsers1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.domainUsers1.Location = new System.Drawing.Point(9, 268);
            this.domainUsers1.Name = "domainUsers1";
            this.domainUsers1.Size = new System.Drawing.Size(317, 410);
            this.domainUsers1.TabIndex = 22;
            this.domainUsers1.ObjectDomainChangeEvent += new Fwk.Security.ActiveDirectory.Test.ObjectDomainChangeHandler(this.domainUsers1_ObjectDomainChangeEvent);
            // 
            // domainGoups2
            // 
            this.domainGoups2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.domainGoups2.Location = new System.Drawing.Point(6, 57);
            this.domainGoups2.Name = "domainGoups2";
            this.domainGoups2.Size = new System.Drawing.Size(319, 205);
            this.domainGoups2.TabIndex = 21;
            this.domainGoups2.DomainGroupChangeEvent += new Fwk.Security.ActiveDirectory.Test.DomainGroupChangeHandler(this.domainGoups2_ObjectDomainChangeEvent);
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(15, 20);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(180, 20);
            this.txtDomain.TabIndex = 13;
            this.txtDomain.Text = "Alco";
            // 
            // btnSearchInDomain
            // 
            this.btnSearchInDomain.BackColor = System.Drawing.Color.White;
            this.btnSearchInDomain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchInDomain.Location = new System.Drawing.Point(202, 20);
            this.btnSearchInDomain.Name = "btnSearchInDomain";
            this.btnSearchInDomain.Size = new System.Drawing.Size(36, 20);
            this.btnSearchInDomain.TabIndex = 15;
            this.btnSearchInDomain.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearchInDomain.UseVisualStyleBackColor = false;
            this.btnSearchInDomain.Click += new System.EventHandler(this.btnSearchInDomain_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(784, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 26);
            this.button2.TabIndex = 10;
            this.button2.Text = "Listar grupos usuario";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnUsersList
            // 
            this.btnUsersList.BackColor = System.Drawing.Color.White;
            this.btnUsersList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsersList.Location = new System.Drawing.Point(784, 89);
            this.btnUsersList.Name = "btnUsersList";
            this.btnUsersList.Size = new System.Drawing.Size(154, 26);
            this.btnUsersList.TabIndex = 3;
            this.btnUsersList.Text = "Listar usuarios grupo";
            this.btnUsersList.UseVisualStyleBackColor = false;
            // 
            // tabPageRoles
            // 
            this.tabPageRoles.Controls.Add(this.button1);
            this.tabPageRoles.Controls.Add(this.txtRolName);
            this.tabPageRoles.Controls.Add(this.lblrolSelected);
            this.tabPageRoles.Controls.Add(this.dataGridView4);
            this.tabPageRoles.Controls.Add(this.btnCrearRol);
            this.tabPageRoles.Controls.Add(this.btnRoles);
            this.tabPageRoles.Controls.Add(this.dataGridViewRoles);
            this.tabPageRoles.Location = new System.Drawing.Point(4, 22);
            this.tabPageRoles.Name = "tabPageRoles";
            this.tabPageRoles.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRoles.Size = new System.Drawing.Size(1071, 627);
            this.tabPageRoles.TabIndex = 1;
            this.tabPageRoles.Text = "Roles";
            this.tabPageRoles.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(319, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 26);
            this.button1.TabIndex = 11;
            this.button1.Text = "Listar grupos";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtRolName
            // 
            this.txtRolName.Location = new System.Drawing.Point(706, 114);
            this.txtRolName.Name = "txtRolName";
            this.txtRolName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtRolName.Properties.Appearance.Options.UseBackColor = true;
            this.txtRolName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtRolName.Size = new System.Drawing.Size(153, 22);
            this.txtRolName.TabIndex = 9;
            // 
            // lblrolSelected
            // 
            this.lblrolSelected.Location = new System.Drawing.Point(729, 169);
            this.lblrolSelected.Name = "lblrolSelected";
            this.lblrolSelected.Size = new System.Drawing.Size(238, 18);
            this.lblrolSelected.TabIndex = 8;
            this.lblrolSelected.Text = "label1";
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(732, 191);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(253, 238);
            this.dataGridView4.TabIndex = 7;
            // 
            // btnCrearRol
            // 
            this.btnCrearRol.BackColor = System.Drawing.Color.White;
            this.btnCrearRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearRol.Location = new System.Drawing.Point(453, 118);
            this.btnCrearRol.Name = "btnCrearRol";
            this.btnCrearRol.Size = new System.Drawing.Size(154, 26);
            this.btnCrearRol.TabIndex = 5;
            this.btnCrearRol.Text = "Crear nevo rol en BD";
            this.btnCrearRol.UseVisualStyleBackColor = false;
            // 
            // btnRoles
            // 
            this.btnRoles.BackColor = System.Drawing.Color.White;
            this.btnRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoles.Location = new System.Drawing.Point(453, 162);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(145, 26);
            this.btnRoles.TabIndex = 4;
            this.btnRoles.Text = "Lista de Roles";
            this.btnRoles.UseVisualStyleBackColor = false;
            // 
            // dataGridViewRoles
            // 
            this.dataGridViewRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRoles.Location = new System.Drawing.Point(453, 194);
            this.dataGridViewRoles.Name = "dataGridViewRoles";
            this.dataGridViewRoles.Size = new System.Drawing.Size(213, 199);
            this.dataGridViewRoles.TabIndex = 3;
            // 
            // tabPageAsingRol
            // 
            this.tabPageAsingRol.Controls.Add(this.lstBoxRoles);
            this.tabPageAsingRol.Controls.Add(this.btnAsignarRoles);
            this.tabPageAsingRol.Controls.Add(this.dataGridView3);
            this.tabPageAsingRol.Location = new System.Drawing.Point(4, 22);
            this.tabPageAsingRol.Name = "tabPageAsingRol";
            this.tabPageAsingRol.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAsingRol.Size = new System.Drawing.Size(1071, 627);
            this.tabPageAsingRol.TabIndex = 2;
            this.tabPageAsingRol.Text = "Asignar roles";
            this.tabPageAsingRol.UseVisualStyleBackColor = true;
            // 
            // lstBoxRoles
            // 
            this.lstBoxRoles.Appearance.BackColor = System.Drawing.Color.White;
            this.lstBoxRoles.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lstBoxRoles.Appearance.BorderColor = System.Drawing.Color.White;
            this.lstBoxRoles.Appearance.Options.UseBackColor = true;
            this.lstBoxRoles.Appearance.Options.UseBorderColor = true;
            this.lstBoxRoles.DisplayMember = "RolName";
            this.lstBoxRoles.Location = new System.Drawing.Point(335, 48);
            this.lstBoxRoles.Name = "lstBoxRoles";
            this.lstBoxRoles.Size = new System.Drawing.Size(285, 189);
            this.lstBoxRoles.TabIndex = 7;
            this.lstBoxRoles.ValueMember = "RolName";
            // 
            // btnAsignarRoles
            // 
            this.btnAsignarRoles.BackColor = System.Drawing.Color.White;
            this.btnAsignarRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarRoles.Location = new System.Drawing.Point(6, 322);
            this.btnAsignarRoles.Name = "btnAsignarRoles";
            this.btnAsignarRoles.Size = new System.Drawing.Size(145, 26);
            this.btnAsignarRoles.TabIndex = 6;
            this.btnAsignarRoles.Text = "Asignar Roles";
            this.btnAsignarRoles.UseVisualStyleBackColor = false;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(6, 48);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(253, 199);
            this.dataGridView3.TabIndex = 5;
            // 
            // fwkMessageViewInfo
            // 
            this.fwkMessageViewInfo.BackColor = System.Drawing.Color.SteelBlue;
            this.fwkMessageViewInfo.IconSize = Fwk.Bases.FrontEnd.Controls.IconSize.Small;
            this.fwkMessageViewInfo.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.fwkMessageViewInfo.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Information;
            this.fwkMessageViewInfo.TextMessageColor = System.Drawing.Color.SteelBlue;
            this.fwkMessageViewInfo.TextMessageForeColor = System.Drawing.Color.PaleGoldenrod;
            this.fwkMessageViewInfo.Title = "Message";
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 705);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lbltitle);
            this.Name = "frmTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTest";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tabPageUsers.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userByAppBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolListBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUserFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageRoles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRolName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoles)).EndInit();
            this.tabPageAsingRol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstBoxRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageUsers;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblRolesByUser;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnUsersList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCreateUser;
        private System.Windows.Forms.TabPage tabPageRoles;
        private System.Windows.Forms.Label lblrolSelected;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Button btnCrearRol;
        private System.Windows.Forms.Button btnRoles;
        private System.Windows.Forms.DataGridView dataGridViewRoles;
        private System.Windows.Forms.TabPage tabPageAsingRol;
        private System.Windows.Forms.Button btnAsignarRoles;
        private System.Windows.Forms.DataGridView dataGridView3;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtRolName;
        private DevExpress.XtraEditors.CheckedListBoxControl lstBoxRoles;

        private global::Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent fwkMessageViewInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn appNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource userByAppBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource rolListBindingSource;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Button btnSearchInDomain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.TextEdit txtUserFullName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
      
      
        private System.Windows.Forms.Button button1;

        private DomainGoups domainGoups2;
        private DomainUsers domainUsers1;
    
    }
}