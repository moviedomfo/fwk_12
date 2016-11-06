namespace Fwk.Security.ActiveDirectory.Test
{
    partial class frmTestLDAPconnections
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
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lstDomains = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.txtDomainName = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtPath3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPath2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtDomainC = new System.Windows.Forms.TextBox();
            this.btnUser_Get_ByName = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnGetRootProperty = new System.Windows.Forms.Button();
            this.txtRootProperty = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "Password";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 64;
            this.label9.Text = "Login name";
            // 
            // txtLoginName
            // 
            this.txtLoginName.Location = new System.Drawing.Point(107, 79);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(178, 20);
            this.txtLoginName.TabIndex = 61;
            this.txtLoginName.Text = "reseteos";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(107, 111);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(178, 20);
            this.txtPassword.TabIndex = 62;
            this.txtPassword.Text = "*R3s3t30s+";
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.White;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Image = global::Fwk.Security.ActiveDirectory.Test.Properties.Resources.apply_16;
            this.btnCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheck.Location = new System.Drawing.Point(638, 146);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(98, 25);
            this.btnCheck.TabIndex = 63;
            this.btnCheck.Text = "Connect";
            this.btnCheck.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(107, 148);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(525, 20);
            this.txtPath.TabIndex = 68;
            this.txtPath.Text = "LDAP://alcomovistar.com.ar/DC=alcomovistar,DC=com,DC=ar";
            // 
            // lstDomains
            // 
            this.lstDomains.FormattingEnabled = true;
            this.lstDomains.Location = new System.Drawing.Point(804, 21);
            this.lstDomains.Name = "lstDomains";
            this.lstDomains.Size = new System.Drawing.Size(185, 251);
            this.lstDomains.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label2.Location = new System.Drawing.Point(14, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(650, 50);
            this.label2.TabIndex = 70;
            this.label2.Text = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.txtDomainName);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.txtPath3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPath2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtLoginName);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.btnCheck);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(759, 312);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 77;
            this.label3.Text = "Domain";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Image = global::Fwk.Security.ActiveDirectory.Test.Properties.Resources.apply_16;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(638, 255);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(98, 25);
            this.button5.TabIndex = 76;
            this.button5.Text = "Connect";
            this.button5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtDomainName
            // 
            this.txtDomainName.Location = new System.Drawing.Point(107, 260);
            this.txtDomainName.Name = "txtDomainName";
            this.txtDomainName.Size = new System.Drawing.Size(525, 20);
            this.txtDomainName.TabIndex = 75;
            this.txtDomainName.Text = "Pelsoft.ar";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = global::Fwk.Security.ActiveDirectory.Test.Properties.Resources.apply_16;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(638, 213);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 25);
            this.button4.TabIndex = 74;
            this.button4.Text = "Connect";
            this.button4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = global::Fwk.Security.ActiveDirectory.Test.Properties.Resources.apply_16;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(638, 180);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 25);
            this.button3.TabIndex = 73;
            this.button3.Text = "Connect";
            this.button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtPath3
            // 
            this.txtPath3.Location = new System.Drawing.Point(107, 218);
            this.txtPath3.Name = "txtPath3";
            this.txtPath3.Size = new System.Drawing.Size(525, 20);
            this.txtPath3.TabIndex = 72;
            this.txtPath3.Text = "LDAP://";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 78;
            this.label5.Text = "Connected path";
            // 
            // txtPath2
            // 
            this.txtPath2.Location = new System.Drawing.Point(107, 182);
            this.txtPath2.Name = "txtPath2";
            this.txtPath2.Size = new System.Drawing.Size(525, 20);
            this.txtPath2.TabIndex = 71;
            this.txtPath2.Text = "LDAP://allus.ar/DC=allus,DC=ar";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label4.Location = new System.Drawing.Point(108, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(519, 16);
            this.label4.TabIndex = 75;
            // 
            // lblResult
            // 
            this.lblResult.BackColor = System.Drawing.Color.White;
            this.lblResult.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblResult.Location = new System.Drawing.Point(512, 433);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(432, 219);
            this.lblResult.TabIndex = 72;
            this.lblResult.Text = "label3";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Image = global::Fwk.Security.ActiveDirectory.Test.Properties.Resources.apply_16;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(173, 402);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(167, 25);
            this.button6.TabIndex = 79;
            this.button6.Text = "Global Catalog";
            this.button6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 433);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(400, 220);
            this.dataGridView1.TabIndex = 80;
            // 
            // txtDomainC
            // 
            this.txtDomainC.Location = new System.Drawing.Point(12, 404);
            this.txtDomainC.Name = "txtDomainC";
            this.txtDomainC.Size = new System.Drawing.Size(138, 20);
            this.txtDomainC.TabIndex = 81;
            this.txtDomainC.Text = "Pelsoft";
            // 
            // btnUser_Get_ByName
            // 
            this.btnUser_Get_ByName.BackColor = System.Drawing.Color.White;
            this.btnUser_Get_ByName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser_Get_ByName.Image = global::Fwk.Security.ActiveDirectory.Test.Properties.Resources.apply_16;
            this.btnUser_Get_ByName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUser_Get_ByName.Location = new System.Drawing.Point(23, 335);
            this.btnUser_Get_ByName.Name = "btnUser_Get_ByName";
            this.btnUser_Get_ByName.Size = new System.Drawing.Size(314, 25);
            this.btnUser_Get_ByName.TabIndex = 82;
            this.btnUser_Get_ByName.Text = "ADUSer = User_Get_ByName(name)";
            this.btnUser_Get_ByName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUser_Get_ByName.UseVisualStyleBackColor = false;
            this.btnUser_Get_ByName.Click += new System.EventHandler(this.btnUser_Get_ByName_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(346, 338);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 84;
            this.label6.Text = "Login name";
            // 
            // txtUserName
            // 
            this.txtUserName.AcceptsReturn = true;
            this.txtUserName.Location = new System.Drawing.Point(428, 337);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(178, 20);
            this.txtUserName.TabIndex = 83;
            // 
            // btnGetRootProperty
            // 
            this.btnGetRootProperty.BackColor = System.Drawing.Color.White;
            this.btnGetRootProperty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetRootProperty.Image = global::Fwk.Security.ActiveDirectory.Test.Properties.Resources.apply_16;
            this.btnGetRootProperty.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetRootProperty.Location = new System.Drawing.Point(29, 366);
            this.btnGetRootProperty.Name = "btnGetRootProperty";
            this.btnGetRootProperty.Size = new System.Drawing.Size(167, 25);
            this.btnGetRootProperty.TabIndex = 85;
            this.btnGetRootProperty.Text = "Get domain property";
            this.btnGetRootProperty.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGetRootProperty.UseVisualStyleBackColor = false;
            this.btnGetRootProperty.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtRootProperty
            // 
            this.txtRootProperty.AcceptsReturn = true;
            this.txtRootProperty.Location = new System.Drawing.Point(212, 368);
            this.txtRootProperty.Name = "txtRootProperty";
            this.txtRootProperty.Size = new System.Drawing.Size(178, 20);
            this.txtRootProperty.TabIndex = 86;
            // 
            // frmTestLDAPconnections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 665);
            this.Controls.Add(this.txtRootProperty);
            this.Controls.Add(this.btnGetRootProperty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnUser_Get_ByName);
            this.Controls.Add(this.txtDomainC);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstDomains);
            this.Name = "frmTestLDAPconnections";
            this.Text = "frmTestLDAPconnections";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLoginName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.ListBox lstDomains;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtPath3;
        private System.Windows.Forms.TextBox txtPath2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtDomainName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtDomainC;
        private System.Windows.Forms.Button btnUser_Get_ByName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnGetRootProperty;
        private System.Windows.Forms.TextBox txtRootProperty;
    }
}