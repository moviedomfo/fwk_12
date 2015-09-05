namespace Fwk.Security.Admin.Controls
{
    partial class RolesCreate
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new DevExpress.XtraEditors.MemoExEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRolName = new DevExpress.XtraEditors.TextEdit();
            this.btnCreateNewRol = new System.Windows.Forms.Button();
            this.grdUsers = new System.Windows.Forms.DataGridView();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdRoles = new System.Windows.Forms.DataGridView();
            this.rolNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblusers = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFindUsers = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRolName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.txtDescription);
            this.groupControl2.Controls.Add(this.label13);
            this.groupControl2.Controls.Add(this.txtRolName);
            this.groupControl2.Controls.Add(this.btnCreateNewRol);
            this.groupControl2.Location = new System.Drawing.Point(3, 4);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(820, 103);
            this.groupControl2.TabIndex = 19;
            this.groupControl2.Text = "Rol properties";
            // 
            // label2
            // 
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(237, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(240, 60);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtDescription.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDescription.Size = new System.Drawing.Size(238, 22);
            this.txtDescription.TabIndex = 16;
            // 
            // label13
            // 
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(7, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 20);
            this.label13.TabIndex = 13;
            this.label13.Text = "Rol name";
            // 
            // txtRolName
            // 
            this.txtRolName.Location = new System.Drawing.Point(5, 60);
            this.txtRolName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRolName.Name = "txtRolName";
            this.txtRolName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtRolName.Properties.Appearance.Options.UseBackColor = true;
            this.txtRolName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtRolName.Size = new System.Drawing.Size(178, 22);
            this.txtRolName.TabIndex = 6;
            this.txtRolName.Validating += new System.ComponentModel.CancelEventHandler(this.txtRolName_Validating);
            // 
            // btnCreateNewRol
            // 
            this.btnCreateNewRol.BackColor = System.Drawing.Color.White;
            this.btnCreateNewRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateNewRol.Image = global::Fwk.Security.Admin.Properties.Resources.save_16;
            this.btnCreateNewRol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateNewRol.Location = new System.Drawing.Point(588, 48);
            this.btnCreateNewRol.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreateNewRol.Name = "btnCreateNewRol";
            this.btnCreateNewRol.Size = new System.Drawing.Size(94, 32);
            this.btnCreateNewRol.TabIndex = 5;
            this.btnCreateNewRol.Text = "Save rol";
            this.btnCreateNewRol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateNewRol.UseVisualStyleBackColor = false;
            this.btnCreateNewRol.Click += new System.EventHandler(this.btnCreateNewRol_Click);
            // 
            // grdUsers
            // 
            this.grdUsers.AllowUserToAddRows = false;
            this.grdUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdUsers.AutoGenerateColumns = false;
            this.grdUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn});
            this.grdUsers.DataSource = this.userBindingSource;
            this.grdUsers.Location = new System.Drawing.Point(385, 148);
            this.grdUsers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdUsers.Name = "grdUsers";
            this.grdUsers.RowTemplate.Height = 24;
            this.grdUsers.Size = new System.Drawing.Size(356, 482);
            this.grdUsers.TabIndex = 22;
            this.grdUsers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdUsers_KeyDown);
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "User name";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(Fwk.Security.Common.User);
            // 
            // grdRoles
            // 
            this.grdRoles.AllowUserToAddRows = false;
            this.grdRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdRoles.AutoGenerateColumns = false;
            this.grdRoles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rolNameDataGridViewTextBoxColumn});
            this.grdRoles.DataSource = this.rolListBindingSource;
            this.grdRoles.Location = new System.Drawing.Point(3, 148);
            this.grdRoles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdRoles.Name = "grdRoles";
            this.grdRoles.RowTemplate.Height = 24;
            this.grdRoles.Size = new System.Drawing.Size(352, 482);
            this.grdRoles.TabIndex = 20;
            this.grdRoles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRoles2_CellClick);
            // 
            // rolNameDataGridViewTextBoxColumn
            // 
            this.rolNameDataGridViewTextBoxColumn.DataPropertyName = "RolName";
            this.rolNameDataGridViewTextBoxColumn.HeaderText = "Rol name";
            this.rolNameDataGridViewTextBoxColumn.Name = "rolNameDataGridViewTextBoxColumn";
            this.rolNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rolListBindingSource
            // 
            this.rolListBindingSource.DataSource = typeof(Fwk.Security.Common.RolList);
            // 
            // lblusers
            // 
            this.lblusers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusers.Image = global::Fwk.Security.Admin.Properties.Resources.User;
            this.lblusers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblusers.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblusers.Location = new System.Drawing.Point(385, 112);
            this.lblusers.Name = "lblusers";
            this.lblusers.Size = new System.Drawing.Size(158, 28);
            this.lblusers.TabIndex = 24;
            this.lblusers.Text = "Asigned users";
            this.lblusers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(10, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 28);
            this.label1.TabIndex = 25;
            this.label1.Text = "Roles";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFindUsers
            // 
            this.btnFindUsers.BackColor = System.Drawing.Color.White;
            this.btnFindUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindUsers.Image = global::Fwk.Security.Admin.Properties.Resources.search_16;
            this.btnFindUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFindUsers.Location = new System.Drawing.Point(551, 117);
            this.btnFindUsers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFindUsers.Name = "btnFindUsers";
            this.btnFindUsers.Size = new System.Drawing.Size(65, 25);
            this.btnFindUsers.TabIndex = 26;
            this.btnFindUsers.Text = "...";
            this.btnFindUsers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFindUsers.UseVisualStyleBackColor = false;
            this.btnFindUsers.Click += new System.EventHandler(this.btnFindUsers_Click);
            // 
            // RolesCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFindUsers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblusers);
            this.Controls.Add(this.grdUsers);
            this.Controls.Add(this.grdRoles);
            this.Controls.Add(this.groupControl2);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "RolesCreate";
            this.Size = new System.Drawing.Size(833, 654);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRolName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.TextEdit txtRolName;
        private System.Windows.Forms.Button btnCreateNewRol;
        private System.Windows.Forms.DataGridView grdUsers;
        private System.Windows.Forms.DataGridView grdRoles;
        private System.Windows.Forms.BindingSource rolListBindingSource;
        private System.Windows.Forms.Label lblusers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.MemoExEdit txtDescription;
        private System.Windows.Forms.Button btnFindUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolNameDataGridViewTextBoxColumn;
    }
}
