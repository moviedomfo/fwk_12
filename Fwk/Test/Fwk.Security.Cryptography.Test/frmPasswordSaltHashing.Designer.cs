namespace Fwk.Security.Cryptography.Test
{
    partial class frmPasswordSaltHashing
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
            this.btnGenHashedPassword = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPasswordHased = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGeneratedSalt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGenHashedPassword
            // 
            this.btnGenHashedPassword.Location = new System.Drawing.Point(542, 54);
            this.btnGenHashedPassword.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenHashedPassword.Name = "btnGenHashedPassword";
            this.btnGenHashedPassword.Size = new System.Drawing.Size(155, 27);
            this.btnGenHashedPassword.TabIndex = 26;
            this.btnGenHashedPassword.Text = "Generate";
            this.btnGenHashedPassword.UseVisualStyleBackColor = true;
            this.btnGenHashedPassword.Click += new System.EventHandler(this.btnGenHashedPassword_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.txtPassword.Location = new System.Drawing.Point(39, 77);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(441, 22);
            this.txtPassword.TabIndex = 27;
            this.txtPassword.Text = "cataqlina";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "Password";
            // 
            // txtPasswordHased
            // 
            this.txtPasswordHased.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPasswordHased.Location = new System.Drawing.Point(39, 326);
            this.txtPasswordHased.Margin = new System.Windows.Forms.Padding(4);
            this.txtPasswordHased.Multiline = true;
            this.txtPasswordHased.Name = "txtPasswordHased";
            this.txtPasswordHased.Size = new System.Drawing.Size(777, 53);
            this.txtPasswordHased.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 305);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Generated Has";
            // 
            // txtGeneratedSalt
            // 
            this.txtGeneratedSalt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGeneratedSalt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtGeneratedSalt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.txtGeneratedSalt.Location = new System.Drawing.Point(39, 172);
            this.txtGeneratedSalt.Margin = new System.Windows.Forms.Padding(4);
            this.txtGeneratedSalt.Multiline = true;
            this.txtGeneratedSalt.Name = "txtGeneratedSalt";
            this.txtGeneratedSalt.Size = new System.Drawing.Size(777, 50);
            this.txtGeneratedSalt.TabIndex = 31;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 399);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 27);
            this.button1.TabIndex = 33;
            this.button1.Text = "Virify";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 133);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 17);
            this.label4.TabIndex = 35;
            this.label4.Text = "salt";
            // 
            // frmPasswordSaltHashing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 511);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtGeneratedSalt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPasswordHased);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnGenHashedPassword);
            this.Name = "frmPasswordSaltHashing";
            this.Text = "frmPasswordSaltHashing";
            this.Load += new System.EventHandler(this.frmPasswordSaltHashing_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenHashedPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPasswordHased;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGeneratedSalt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
    }
}