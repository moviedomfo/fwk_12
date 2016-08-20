namespace Fwk.Security.AD.TestLogin
{
    partial class frmResset
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResset));
            this.ForceChange = new System.Windows.Forms.CheckBox();
            this.UnLock = new System.Windows.Forms.CheckBox();
            this.ResetPwd = new System.Windows.Forms.Button();
            this.lblCheckResult = new System.Windows.Forms.TextBox();
            this.cmbDomains = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtError = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCnn = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ForceChange
            // 
            this.ForceChange.AutoSize = true;
            this.ForceChange.Location = new System.Drawing.Point(340, 45);
            this.ForceChange.Name = "ForceChange";
            this.ForceChange.Size = new System.Drawing.Size(111, 17);
            this.ForceChange.TabIndex = 90;
            this.ForceChange.Text = "ForceChangePwd";
            this.ForceChange.UseVisualStyleBackColor = true;
            this.ForceChange.Visible = false;
            // 
            // UnLock
            // 
            this.UnLock.AutoSize = true;
            this.UnLock.Location = new System.Drawing.Point(452, 46);
            this.UnLock.Name = "UnLock";
            this.UnLock.Size = new System.Drawing.Size(64, 17);
            this.UnLock.TabIndex = 89;
            this.UnLock.Text = "UnLock";
            this.UnLock.UseVisualStyleBackColor = true;
            this.UnLock.Visible = false;
            // 
            // ResetPwd
            // 
            this.ResetPwd.BackColor = System.Drawing.Color.White;
            this.ResetPwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetPwd.ForeColor = System.Drawing.Color.Red;
            this.ResetPwd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ResetPwd.Location = new System.Drawing.Point(230, 162);
            this.ResetPwd.Name = "ResetPwd";
            this.ResetPwd.Size = new System.Drawing.Size(85, 22);
            this.ResetPwd.TabIndex = 84;
            this.ResetPwd.Text = "Reset Pwd!";
            this.ResetPwd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ResetPwd.UseVisualStyleBackColor = false;
            this.ResetPwd.Click += new System.EventHandler(this.ResetPwd_Click);
            // 
            // lblCheckResult
            // 
            this.lblCheckResult.BackColor = System.Drawing.Color.White;
            this.lblCheckResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckResult.Location = new System.Drawing.Point(10, 191);
            this.lblCheckResult.Multiline = true;
            this.lblCheckResult.Name = "lblCheckResult";
            this.lblCheckResult.ReadOnly = true;
            this.lblCheckResult.Size = new System.Drawing.Size(482, 105);
            this.lblCheckResult.TabIndex = 87;
            // 
            // cmbDomains
            // 
            this.cmbDomains.BackColor = System.Drawing.Color.Beige;
            this.cmbDomains.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDomains.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDomains.FormattingEnabled = true;
            this.cmbDomains.Items.AddRange(new object[] {
            "allus-ar"});
            this.cmbDomains.Location = new System.Drawing.Point(138, 125);
            this.cmbDomains.Name = "cmbDomains";
            this.cmbDomains.Size = new System.Drawing.Size(175, 23);
            this.cmbDomains.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 85;
            this.label2.Text = "Domain";
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.White;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheck.Location = new System.Drawing.Point(136, 162);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(87, 22);
            this.btnCheck.TabIndex = 83;
            this.btnCheck.Text = "Ahutenticate";
            this.btnCheck.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 83;
            this.label1.Text = "Password";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 82;
            this.label9.Text = "Login name";
            // 
            // txtLoginName
            // 
            this.txtLoginName.Location = new System.Drawing.Point(136, 43);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(178, 20);
            this.txtLoginName.TabIndex = 80;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(136, 76);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(178, 20);
            this.txtPassword.TabIndex = 81;
            this.txtPassword.Text = "Pelsoft+123";
            // 
            // txtError
            // 
            this.txtError.BackColor = System.Drawing.Color.White;
            this.txtError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtError.Location = new System.Drawing.Point(10, 301);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.ReadOnly = true;
            this.txtError.Size = new System.Drawing.Size(482, 105);
            this.txtError.TabIndex = 91;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 435);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 92;
            this.label3.Text = "Web service: ";
            // 
            // lblCnn
            // 
            this.lblCnn.AutoSize = true;
            this.lblCnn.ForeColor = System.Drawing.Color.DimGray;
            this.lblCnn.Location = new System.Drawing.Point(88, 435);
            this.lblCnn.Name = "lblCnn";
            this.lblCnn.Size = new System.Drawing.Size(73, 13);
            this.lblCnn.TabIndex = 93;
            this.lblCnn.Text = "Web service: ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(340, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 22);
            this.button1.TabIndex = 94;
            this.button1.Text = "GetDomains";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(433, 162);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 22);
            this.button2.TabIndex = 95;
            this.button2.Text = "Test";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmResset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(557, 457);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblCnn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.ForceChange);
            this.Controls.Add(this.UnLock);
            this.Controls.Add(this.ResetPwd);
            this.Controls.Add(this.lblCheckResult);
            this.Controls.Add(this.cmbDomains);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtLoginName);
            this.Controls.Add(this.txtPassword);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmResset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Centralized security 1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ForceChange;
        private System.Windows.Forms.CheckBox UnLock;
        private System.Windows.Forms.Button ResetPwd;
        private System.Windows.Forms.TextBox lblCheckResult;
        private System.Windows.Forms.ComboBox cmbDomains;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLoginName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCnn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}