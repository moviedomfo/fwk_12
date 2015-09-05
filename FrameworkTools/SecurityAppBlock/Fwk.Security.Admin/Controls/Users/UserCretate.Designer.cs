namespace Fwk.Security.Admin.Controls
{
    partial class UserCretate
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComments = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuest = new DevExpress.XtraEditors.TextEdit();
            this.txtAnsw = new DevExpress.XtraEditors.TextEdit();
            this.chkApproved = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new DevExpress.XtraEditors.TextEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComments.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnsw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.button1);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.txtComments);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.txtQuest);
            this.groupControl1.Controls.Add(this.txtAnsw);
            this.groupControl1.Controls.Add(this.chkApproved);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.txtConfirmPassword);
            this.groupControl1.Controls.Add(this.label10);
            this.groupControl1.Controls.Add(this.txtPassword);
            this.groupControl1.Controls.Add(this.txtEmail);
            this.groupControl1.Controls.Add(this.txtUserName);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.btnCreateUser);
            this.groupControl1.Location = new System.Drawing.Point(3, 4);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(712, 365);
            this.groupControl1.TabIndex = 23;
            this.groupControl1.Text = "User properties";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(294, 314);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 32);
            this.button1.TabIndex = 26;
            this.button1.Text = "test log";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(376, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Comments";
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(379, 106);
            this.txtComments.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtComments.Name = "txtComments";
            this.txtComments.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtComments.Properties.Appearance.Options.UseBackColor = true;
            this.txtComments.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtComments.Size = new System.Drawing.Size(325, 24);
            this.txtComments.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(269, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Answer";
            // 
            // label3
            // 
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(269, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Question";
            // 
            // txtQuest
            // 
            this.txtQuest.Location = new System.Drawing.Point(272, 191);
            this.txtQuest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQuest.Name = "txtQuest";
            this.txtQuest.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtQuest.Properties.Appearance.Options.UseBackColor = true;
            this.txtQuest.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtQuest.Size = new System.Drawing.Size(325, 24);
            this.txtQuest.TabIndex = 21;
            // 
            // txtAnsw
            // 
            this.txtAnsw.Location = new System.Drawing.Point(273, 257);
            this.txtAnsw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAnsw.Name = "txtAnsw";
            this.txtAnsw.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtAnsw.Properties.Appearance.Options.UseBackColor = true;
            this.txtAnsw.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtAnsw.Size = new System.Drawing.Size(324, 24);
            this.txtAnsw.TabIndex = 20;
            // 
            // chkApproved
            // 
            this.chkApproved.AutoSize = true;
            this.chkApproved.Checked = true;
            this.chkApproved.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkApproved.Location = new System.Drawing.Point(379, 43);
            this.chkApproved.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkApproved.Name = "chkApproved";
            this.chkApproved.Size = new System.Drawing.Size(103, 21);
            this.chkApproved.TabIndex = 19;
            this.chkApproved.Text = "Is approved";
            this.chkApproved.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(8, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Confirm password:";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(6, 257);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtConfirmPassword.Properties.Appearance.Options.UseBackColor = true;
            this.txtConfirmPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtConfirmPassword.Size = new System.Drawing.Size(178, 24);
            this.txtConfirmPassword.TabIndex = 3;
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
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(10, 191);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtPassword.Properties.Appearance.Options.UseBackColor = true;
            this.txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtPassword.Size = new System.Drawing.Size(178, 24);
            this.txtPassword.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(5, 106);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txtEmail.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtEmail.Properties.Appearance.Options.UseBackColor = true;
            this.txtEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtEmail.Size = new System.Drawing.Size(325, 24);
            this.txtEmail.TabIndex = 1;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(6, 53);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtUserName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtUserName.Properties.Appearance.Options.UseBackColor = true;
            this.txtUserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtUserName.Size = new System.Drawing.Size(324, 24);
            this.txtUserName.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(7, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Password:";
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
            // btnCreateUser
            // 
            this.btnCreateUser.BackColor = System.Drawing.Color.White;
            this.btnCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateUser.Location = new System.Drawing.Point(9, 314);
            this.btnCreateUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(147, 32);
            this.btnCreateUser.TabIndex = 3;
            this.btnCreateUser.Text = "Create User";
            this.btnCreateUser.UseVisualStyleBackColor = false;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // UserCretate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "UserCretate";
            this.Size = new System.Drawing.Size(727, 399);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComments.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnsw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtConfirmPassword;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreateUser;
        private System.Windows.Forms.CheckBox chkApproved;
        private DevExpress.XtraEditors.TextEdit txtQuest;
        private DevExpress.XtraEditors.TextEdit txtAnsw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtComments;
        private System.Windows.Forms.Button button1;
    }
}
