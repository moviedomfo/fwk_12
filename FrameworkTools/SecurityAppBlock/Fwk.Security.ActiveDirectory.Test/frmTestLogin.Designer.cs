namespace Fwk.Security.ActiveDirectory.Test
{
    partial class frmTestLogin
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
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.lblCheckResult = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAllDomains = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.White;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Image = global::Fwk.Security.ActiveDirectory.Test.Properties.Resources.apply_16;
            this.btnCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheck.Location = new System.Drawing.Point(142, 221);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(112, 25);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "Ahutenticate";
            this.btnCheck.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(142, 187);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(178, 20);
            this.txtDomain.TabIndex = 3;
            this.txtDomain.Text = "Pelsoft-ar";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(142, 86);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(178, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // txtLoginName
            // 
            this.txtLoginName.Location = new System.Drawing.Point(142, 54);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(178, 20);
            this.txtLoginName.TabIndex = 1;
            // 
            // lblCheckResult
            // 
            this.lblCheckResult.BackColor = System.Drawing.Color.White;
            this.lblCheckResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckResult.Location = new System.Drawing.Point(16, 259);
            this.lblCheckResult.Name = "lblCheckResult";
            this.lblCheckResult.Size = new System.Drawing.Size(330, 27);
            this.lblCheckResult.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 55;
            this.label9.Text = "Login name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Password";
            // 
            // cmbAllDomains
            // 
            this.cmbAllDomains.FormattingEnabled = true;
            this.cmbAllDomains.Location = new System.Drawing.Point(142, 139);
            this.cmbAllDomains.Name = "cmbAllDomains";
            this.cmbAllDomains.Size = new System.Drawing.Size(178, 21);
            this.cmbAllDomains.TabIndex = 58;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(4, 187);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(132, 17);
            this.radioButton1.TabIndex = 59;
            this.radioButton1.Text = "Coustom domain name";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(4, 143);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(133, 17);
            this.radioButton2.TabIndex = 60;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Selected domain name";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // frmTestLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 295);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.cmbAllDomains);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblCheckResult);
            this.Controls.Add(this.txtLoginName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.txtDomain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTestLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmTestLogin";
            this.Load += new System.EventHandler(this.frmTestLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtLoginName;
        private System.Windows.Forms.Label lblCheckResult;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAllDomains;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}