namespace Fwk.Security.AD.TestLogin
{
    partial class frmDinamic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDinamic));
            this.label2 = new System.Windows.Forms.Label();
            this.btnAutenticate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblURL = new System.Windows.Forms.Label();
            this.cmbDomains = new System.Windows.Forms.ComboBox();
            this.domainUrlInfoBindingSource = new System.Windows.Forms.BindingSource();
            this.lblCheckResult = new System.Windows.Forms.TextBox();
            this.ResetPwd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.UnLock = new System.Windows.Forms.CheckBox();
            this.ForceChange = new System.Windows.Forms.CheckBox();
            this.txtError = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.domainUrlInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 132);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 72;
            this.label2.Text = "Domain";
            // 
            // btnAutenticate
            // 
            this.btnAutenticate.BackColor = System.Drawing.Color.White;
            this.btnAutenticate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutenticate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAutenticate.Location = new System.Drawing.Point(54, 167);
            this.btnAutenticate.Margin = new System.Windows.Forms.Padding(4);
            this.btnAutenticate.Name = "btnAutenticate";
            this.btnAutenticate.Size = new System.Drawing.Size(116, 27);
            this.btnAutenticate.TabIndex = 70;
            this.btnAutenticate.Text = "Ahutenticate";
            this.btnAutenticate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAutenticate.UseVisualStyleBackColor = false;
            this.btnAutenticate.Click += new System.EventHandler(this.btnAutenticate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 68;
            this.label1.Text = "Password";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 33);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 17);
            this.label9.TabIndex = 67;
            this.label9.Text = "Login name";
            // 
            // txtLoginName
            // 
            this.txtLoginName.Location = new System.Drawing.Point(171, 33);
            this.txtLoginName.Margin = new System.Windows.Forms.Padding(4);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(236, 22);
            this.txtLoginName.TabIndex = 65;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(171, 73);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(236, 22);
            this.txtPassword.TabIndex = 66;
            this.txtPassword.Text = "Pelsoft+123";
            // 
            // lblURL
            // 
            this.lblURL.BackColor = System.Drawing.Color.White;
            this.lblURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.lblURL.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblURL.Location = new System.Drawing.Point(12, 302);
            this.lblURL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(647, 30);
            this.lblURL.TabIndex = 73;
            // 
            // cmbDomains
            // 
            this.cmbDomains.DataSource = this.domainUrlInfoBindingSource;
            this.cmbDomains.DisplayMember = "DomainName";
            this.cmbDomains.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDomains.FormattingEnabled = true;
            this.cmbDomains.Location = new System.Drawing.Point(173, 134);
            this.cmbDomains.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDomains.Name = "cmbDomains";
            this.cmbDomains.Size = new System.Drawing.Size(232, 24);
            this.cmbDomains.TabIndex = 74;
            // 
            // domainUrlInfoBindingSource
            // 
            this.domainUrlInfoBindingSource.DataSource = typeof(Fwk.Security.ActiveDirectory.DomainUrlInfo);
            // 
            // lblCheckResult
            // 
            this.lblCheckResult.BackColor = System.Drawing.Color.White;
            this.lblCheckResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckResult.Location = new System.Drawing.Point(16, 202);
            this.lblCheckResult.Margin = new System.Windows.Forms.Padding(4);
            this.lblCheckResult.Multiline = true;
            this.lblCheckResult.Name = "lblCheckResult";
            this.lblCheckResult.ReadOnly = true;
            this.lblCheckResult.Size = new System.Drawing.Size(641, 128);
            this.lblCheckResult.TabIndex = 75;
            // 
            // ResetPwd
            // 
            this.ResetPwd.BackColor = System.Drawing.Color.White;
            this.ResetPwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetPwd.ForeColor = System.Drawing.Color.Red;
            this.ResetPwd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ResetPwd.Location = new System.Drawing.Point(295, 167);
            this.ResetPwd.Margin = new System.Windows.Forms.Padding(4);
            this.ResetPwd.Name = "ResetPwd";
            this.ResetPwd.Size = new System.Drawing.Size(113, 27);
            this.ResetPwd.TabIndex = 76;
            this.ResetPwd.Text = "Reset Pwd!";
            this.ResetPwd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ResetPwd.UseVisualStyleBackColor = false;
            this.ResetPwd.Click += new System.EventHandler(this.ResetPwd_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(416, 503);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(243, 27);
            this.button1.TabIndex = 77;
            this.button1.Text = "Install Pelsoft Root Certs";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UnLock
            // 
            this.UnLock.AutoSize = true;
            this.UnLock.Location = new System.Drawing.Point(573, 172);
            this.UnLock.Margin = new System.Windows.Forms.Padding(4);
            this.UnLock.Name = "UnLock";
            this.UnLock.Size = new System.Drawing.Size(78, 21);
            this.UnLock.TabIndex = 78;
            this.UnLock.Text = "UnLock";
            this.UnLock.UseVisualStyleBackColor = true;
            // 
            // ForceChange
            // 
            this.ForceChange.AutoSize = true;
            this.ForceChange.Location = new System.Drawing.Point(416, 172);
            this.ForceChange.Margin = new System.Windows.Forms.Padding(4);
            this.ForceChange.Name = "ForceChange";
            this.ForceChange.Size = new System.Drawing.Size(141, 21);
            this.ForceChange.TabIndex = 79;
            this.ForceChange.Text = "ForceChangePwd";
            this.ForceChange.UseVisualStyleBackColor = true;
            // 
            // txtError
            // 
            this.txtError.BackColor = System.Drawing.Color.White;
            this.txtError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtError.Location = new System.Drawing.Point(16, 367);
            this.txtError.Margin = new System.Windows.Forms.Padding(4);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.ReadOnly = true;
            this.txtError.Size = new System.Drawing.Size(641, 128);
            this.txtError.TabIndex = 80;
            // 
            // frmDinamic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(797, 613);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.ForceChange);
            this.Controls.Add(this.UnLock);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ResetPwd);
            this.Controls.Add(this.lblCheckResult);
            this.Controls.Add(this.cmbDomains);
            this.Controls.Add(this.lblURL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAutenticate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtLoginName);
            this.Controls.Add(this.txtPassword);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDinamic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDinamic";
            this.Load += new System.EventHandler(this.frmDinamic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.domainUrlInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAutenticate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLoginName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.ComboBox cmbDomains;
        private System.Windows.Forms.BindingSource domainUrlInfoBindingSource;
        private System.Windows.Forms.TextBox lblCheckResult;
        private System.Windows.Forms.Button ResetPwd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox UnLock;
        private System.Windows.Forms.CheckBox ForceChange;
        private System.Windows.Forms.TextBox txtError;

    }
}