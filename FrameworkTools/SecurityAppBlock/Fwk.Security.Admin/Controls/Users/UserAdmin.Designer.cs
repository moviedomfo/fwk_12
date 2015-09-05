namespace Fwk.Security.Admin.Controls
{
    partial class UserAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblRolesByUser = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuest = new DevExpress.XtraEditors.TextEdit();
            this.txtAnsw = new DevExpress.XtraEditors.TextEdit();
            this.chkApproved = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.grdRoles1 = new System.Windows.Forms.DataGridView();
            this.rolNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceRoles1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnUsersList = new System.Windows.Forms.Button();
            this.usersGrid1 = new Fwk.Security.Admin.UsersGrid();
            this.label5 = new System.Windows.Forms.Label();
            this.btnchangePwd = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.txtComments = new DevExpress.XtraEditors.MemoEdit();
            this.btnUnlock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnsw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoles1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRoles1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComments.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRolesByUser
            // 
            this.lblRolesByUser.Image = global::Fwk.Security.Admin.Properties.Resources.Users;
            this.lblRolesByUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRolesByUser.Location = new System.Drawing.Point(813, 59);
            this.lblRolesByUser.Name = "lblRolesByUser";
            this.lblRolesByUser.Size = new System.Drawing.Size(135, 20);
            this.lblRolesByUser.TabIndex = 21;
            this.lblRolesByUser.Text = "User roles";
            this.lblRolesByUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.txtQuest);
            this.groupControl1.Controls.Add(this.txtAnsw);
            this.groupControl1.Controls.Add(this.chkApproved);
            this.groupControl1.Controls.Add(this.label10);
            this.groupControl1.Controls.Add(this.txtEmail);
            this.groupControl1.Controls.Add(this.txtUserName);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Location = new System.Drawing.Point(10, 392);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(763, 159);
            this.groupControl1.TabIndex = 22;
            this.groupControl1.Text = "User properties";
            // 
            // label4
            // 
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(258, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "Answer";
            // 
            // label3
            // 
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(258, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "Question";
            // 
            // txtQuest
            // 
            this.txtQuest.Location = new System.Drawing.Point(260, 53);
            this.txtQuest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQuest.Name = "txtQuest";
            this.txtQuest.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtQuest.Properties.Appearance.Options.UseBackColor = true;
            this.txtQuest.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtQuest.Size = new System.Drawing.Size(325, 24);
            this.txtQuest.TabIndex = 26;
            // 
            // txtAnsw
            // 
            this.txtAnsw.Location = new System.Drawing.Point(261, 119);
            this.txtAnsw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAnsw.Name = "txtAnsw";
            this.txtAnsw.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtAnsw.Properties.Appearance.Options.UseBackColor = true;
            this.txtAnsw.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtAnsw.Size = new System.Drawing.Size(324, 24);
            this.txtAnsw.TabIndex = 25;
            // 
            // chkApproved
            // 
            this.chkApproved.AutoSize = true;
            this.chkApproved.Checked = true;
            this.chkApproved.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkApproved.Location = new System.Drawing.Point(572, -79);
            this.chkApproved.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkApproved.Name = "chkApproved";
            this.chkApproved.Size = new System.Drawing.Size(103, 21);
            this.chkApproved.TabIndex = 24;
            this.chkApproved.Text = "Is approved";
            this.chkApproved.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(6, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 20);
            this.label10.TabIndex = 16;
            this.label10.Text = "e-mail";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(5, 106);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtEmail.Properties.Appearance.Options.UseBackColor = true;
            this.txtEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtEmail.Size = new System.Drawing.Size(178, 24);
            this.txtEmail.TabIndex = 15;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(6, 53);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtUserName.Properties.Appearance.Options.UseBackColor = true;
            this.txtUserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtUserName.Size = new System.Drawing.Size(178, 24);
            this.txtUserName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(7, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Username:";
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.White;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Image = global::Fwk.Security.Admin.Properties.Resources.file_del_16;
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(259, 4);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(117, 32);
            this.btnRemove.TabIndex = 17;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Image = global::Fwk.Security.Admin.Properties.Resources.file_edit_16;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnUpdate.Location = new System.Drawing.Point(138, 4);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(115, 32);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Update ";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // grdRoles1
            // 
            this.grdRoles1.AllowDrop = true;
            this.grdRoles1.AllowUserToAddRows = false;
            this.grdRoles1.AllowUserToDeleteRows = false;
            this.grdRoles1.AllowUserToOrderColumns = true;
            this.grdRoles1.AllowUserToResizeColumns = false;
            this.grdRoles1.AllowUserToResizeRows = false;
            this.grdRoles1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdRoles1.AutoGenerateColumns = false;
            this.grdRoles1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdRoles1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdRoles1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRoles1.ColumnHeadersVisible = false;
            this.grdRoles1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rolNameDataGridViewTextBoxColumn});
            this.grdRoles1.DataSource = this.bindingSourceRoles1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdRoles1.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdRoles1.GridColor = System.Drawing.Color.White;
            this.grdRoles1.Location = new System.Drawing.Point(816, 92);
            this.grdRoles1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdRoles1.MultiSelect = false;
            this.grdRoles1.Name = "grdRoles1";
            this.grdRoles1.ReadOnly = true;
            this.grdRoles1.RowHeadersVisible = false;
            this.grdRoles1.RowTemplate.Height = 24;
            this.grdRoles1.Size = new System.Drawing.Size(214, 430);
            this.grdRoles1.TabIndex = 20;
            // 
            // rolNameDataGridViewTextBoxColumn
            // 
            this.rolNameDataGridViewTextBoxColumn.DataPropertyName = "RolName";
            this.rolNameDataGridViewTextBoxColumn.HeaderText = "RolName";
            this.rolNameDataGridViewTextBoxColumn.Name = "rolNameDataGridViewTextBoxColumn";
            this.rolNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingSourceRoles1
            // 
            this.bindingSourceRoles1.DataSource = typeof(Fwk.Security.Common.RolList);
            // 
            // btnUsersList
            // 
            this.btnUsersList.BackColor = System.Drawing.Color.White;
            this.btnUsersList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsersList.Image = global::Fwk.Security.Admin.Properties.Resources.fwk_Refresh;
            this.btnUsersList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsersList.Location = new System.Drawing.Point(7, 4);
            this.btnUsersList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUsersList.Name = "btnUsersList";
            this.btnUsersList.Size = new System.Drawing.Size(122, 32);
            this.btnUsersList.TabIndex = 19;
            this.btnUsersList.Text = "    Refresh users";
            this.btnUsersList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUsersList.UseVisualStyleBackColor = false;
            this.btnUsersList.Click += new System.EventHandler(this.btnUsersList_Click);
            // 
            // usersGrid1
            // 
            this.usersGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.usersGrid1.Location = new System.Drawing.Point(-2, 46);
            this.usersGrid1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.usersGrid1.Name = "usersGrid1";
            this.usersGrid1.Size = new System.Drawing.Size(798, 270);
            this.usersGrid1.TabIndex = 23;
            this.usersGrid1.OnUserChange += new Fwk.Security.Admin.UserChangeHandler(this.usersGrid1_OnUserChange);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(7, 316);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(373, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "Comments";
            // 
            // btnchangePwd
            // 
            this.btnchangePwd.BackColor = System.Drawing.Color.White;
            this.btnchangePwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnchangePwd.Image = global::Fwk.Security.Admin.Properties.Resources.lock_16;
            this.btnchangePwd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnchangePwd.Location = new System.Drawing.Point(408, 4);
            this.btnchangePwd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnchangePwd.Name = "btnchangePwd";
            this.btnchangePwd.Size = new System.Drawing.Size(188, 32);
            this.btnchangePwd.TabIndex = 31;
            this.btnchangePwd.Text = "Change password";
            this.btnchangePwd.UseVisualStyleBackColor = false;
            this.btnchangePwd.Click += new System.EventHandler(this.btnchangePwd_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.White;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Image = global::Fwk.Security.Admin.Properties.Resources.lock_16;
            this.btnApprove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApprove.Location = new System.Drawing.Point(602, 4);
            this.btnApprove.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(117, 32);
            this.btnApprove.TabIndex = 32;
            this.btnApprove.Text = "Aprovar";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // txtComments
            // 
            this.txtComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtComments.Location = new System.Drawing.Point(10, 339);
            this.txtComments.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtComments.Name = "txtComments";
            this.txtComments.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtComments.Properties.Appearance.Options.UseBackColor = true;
            this.txtComments.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtComments.Size = new System.Drawing.Size(765, 45);
            this.txtComments.TabIndex = 29;
            // 
            // btnUnlock
            // 
            this.btnUnlock.BackColor = System.Drawing.Color.White;
            this.btnUnlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnlock.Image = global::Fwk.Security.Admin.Properties.Resources.ulock_24;
            this.btnUnlock.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnUnlock.Location = new System.Drawing.Point(725, 4);
            this.btnUnlock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(148, 32);
            this.btnUnlock.TabIndex = 33;
            this.btnUnlock.Text = "Desbloquear";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // UserAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUnlock);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnchangePwd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnUsersList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.usersGrid1);
            this.Controls.Add(this.lblRolesByUser);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.grdRoles1);
            this.Controls.Add(this.txtComments);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "UserAdmin";
            this.Size = new System.Drawing.Size(1043, 569);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnsw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoles1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRoles1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComments.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRolesByUser;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdRoles1;
        private System.Windows.Forms.Button btnUsersList;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bindingSourceRoles1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnUpdate;
        private UsersGrid usersGrid1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtQuest;
        private DevExpress.XtraEditors.TextEdit txtAnsw;
        private System.Windows.Forms.CheckBox chkApproved;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnchangePwd;
        private System.Windows.Forms.Button btnApprove;
        private DevExpress.XtraEditors.MemoEdit txtComments;
        private System.Windows.Forms.Button btnUnlock;
    }
}
