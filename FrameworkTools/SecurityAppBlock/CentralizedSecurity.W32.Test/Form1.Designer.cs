namespace CentralizedSecurity.W32.Test
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAuthenticate = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.chkUseProxy = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProxyAddress = new System.Windows.Forms.TextBox();
            this.cmbDomain = new System.Windows.Forms.ComboBox();
            this.txtPwdProxy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserProxy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtAuthenticate_Domain = new System.Windows.Forms.TextBox();
            this.txtAuthenticate_Password = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAuthenticate_UserName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(879, 120);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "xxxxxxxx";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(879, 165);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(176, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "Retrive_DomainsUrl ASYNK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAuthenticate
            // 
            this.btnAuthenticate.Location = new System.Drawing.Point(349, 55);
            this.btnAuthenticate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAuthenticate.Name = "btnAuthenticate";
            this.btnAuthenticate.Size = new System.Drawing.Size(176, 28);
            this.btnAuthenticate.TabIndex = 2;
            this.btnAuthenticate.Text = "Authenticate";
            this.btnAuthenticate.UseVisualStyleBackColor = true;
            this.btnAuthenticate.Click += new System.EventHandler(this.Authenticate_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(413, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "WCF Security credentials";
            // 
            // chkUseProxy
            // 
            this.chkUseProxy.AutoSize = true;
            this.chkUseProxy.Location = new System.Drawing.Point(9, 9);
            this.chkUseProxy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkUseProxy.Name = "chkUseProxy";
            this.chkUseProxy.Size = new System.Drawing.Size(93, 21);
            this.chkUseProxy.TabIndex = 11;
            this.chkUseProxy.Text = "Use proxy";
            this.chkUseProxy.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDomain);
            this.groupBox2.Controls.Add(this.txtPwd);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtUser);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(416, 34);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(376, 151);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(144, 25);
            this.txtDomain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(175, 22);
            this.txtDomain.TabIndex = 9;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(144, 95);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = 'X';
            this.txtPwd.Size = new System.Drawing.Size(175, 22);
            this.txtPwd.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Domain";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Password";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(144, 62);
            this.txtUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(175, 22);
            this.txtUser.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Username";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtProxyAddress);
            this.groupBox1.Controls.Add(this.cmbDomain);
            this.groupBox1.Controls.Add(this.txtPwdProxy);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUserProxy);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(9, 34);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(376, 159);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "Port";
            // 
            // txtProxyAddress
            // 
            this.txtProxyAddress.Location = new System.Drawing.Point(157, 124);
            this.txtProxyAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtProxyAddress.Name = "txtProxyAddress";
            this.txtProxyAddress.Size = new System.Drawing.Size(175, 22);
            this.txtProxyAddress.TabIndex = 9;
            // 
            // cmbDomain
            // 
            this.cmbDomain.FormattingEnabled = true;
            this.cmbDomain.Items.AddRange(new object[] {
            "allus-ar",
            "allus-pr"});
            this.cmbDomain.Location = new System.Drawing.Point(147, 21);
            this.cmbDomain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDomain.Name = "cmbDomain";
            this.cmbDomain.Size = new System.Drawing.Size(185, 24);
            this.cmbDomain.TabIndex = 3;
            // 
            // txtPwdProxy
            // 
            this.txtPwdProxy.Location = new System.Drawing.Point(157, 92);
            this.txtPwdProxy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPwdProxy.Name = "txtPwdProxy";
            this.txtPwdProxy.PasswordChar = 'X';
            this.txtPwdProxy.Size = new System.Drawing.Size(175, 22);
            this.txtPwdProxy.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Proxy Domain";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Proxy password";
            // 
            // txtUserProxy
            // 
            this.txtUserProxy.Location = new System.Drawing.Point(157, 58);
            this.txtUserProxy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserProxy.Name = "txtUserProxy";
            this.txtUserProxy.Size = new System.Drawing.Size(175, 22);
            this.txtUserProxy.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Proxy username";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtAuthenticate_Domain);
            this.groupBox3.Controls.Add(this.txtAuthenticate_Password);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtAuthenticate_UserName);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.btnAuthenticate);
            this.groupBox3.Location = new System.Drawing.Point(27, 230);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(551, 151);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            // 
            // txtAuthenticate_Domain
            // 
            this.txtAuthenticate_Domain.Location = new System.Drawing.Point(144, 25);
            this.txtAuthenticate_Domain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAuthenticate_Domain.Name = "txtAuthenticate_Domain";
            this.txtAuthenticate_Domain.Size = new System.Drawing.Size(175, 22);
            this.txtAuthenticate_Domain.TabIndex = 9;
            // 
            // txtAuthenticate_Password
            // 
            this.txtAuthenticate_Password.Location = new System.Drawing.Point(144, 95);
            this.txtAuthenticate_Password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAuthenticate_Password.Name = "txtAuthenticate_Password";
            this.txtAuthenticate_Password.PasswordChar = 'X';
            this.txtAuthenticate_Password.Size = new System.Drawing.Size(175, 22);
            this.txtAuthenticate_Password.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 17);
            this.label12.TabIndex = 4;
            this.label12.Text = "Domain";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 95);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 17);
            this.label13.TabIndex = 7;
            this.label13.Text = "Password";
            // 
            // txtAuthenticate_UserName
            // 
            this.txtAuthenticate_UserName.Location = new System.Drawing.Point(144, 62);
            this.txtAuthenticate_UserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAuthenticate_UserName.Name = "txtAuthenticate_UserName";
            this.txtAuthenticate_UserName.Size = new System.Drawing.Size(175, 22);
            this.txtAuthenticate_UserName.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 17);
            this.label14.TabIndex = 6;
            this.label14.Text = "Username";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "Authenticate Method ";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(31, 415);
            this.txtResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(985, 169);
            this.txtResult.TabIndex = 23;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSaveSettings.Location = new System.Drawing.Point(879, 74);
            this.btnSaveSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(159, 34);
            this.btnSaveSettings.TabIndex = 24;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = false;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 598);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkUseProxy);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Leave += new System.EventHandler(this.Form1_Leave);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAuthenticate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkUseProxy;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtProxyAddress;
        private System.Windows.Forms.ComboBox cmbDomain;
        private System.Windows.Forms.TextBox txtPwdProxy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserProxy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtAuthenticate_Domain;
        private System.Windows.Forms.TextBox txtAuthenticate_Password;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAuthenticate_UserName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnSaveSettings;
    }
}

