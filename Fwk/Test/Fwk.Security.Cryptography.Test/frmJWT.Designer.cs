namespace Fwk.Security.Cryptography.Test
{
    partial class frmJWT
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
            this.txtAudienseHased = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGenHashedPassword
            // 
            this.btnGenHashedPassword.Location = new System.Drawing.Point(61, 44);
            this.btnGenHashedPassword.Name = "btnGenHashedPassword";
            this.btnGenHashedPassword.Size = new System.Drawing.Size(116, 22);
            this.btnGenHashedPassword.TabIndex = 29;
            this.btnGenHashedPassword.Text = "Generate";
            this.btnGenHashedPassword.UseVisualStyleBackColor = true;
            this.btnGenHashedPassword.Click += new System.EventHandler(this.btnGenHashedPassword_Click);
            // 
            // txtAudienseHased
            // 
            this.txtAudienseHased.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAudienseHased.Location = new System.Drawing.Point(61, 83);
            this.txtAudienseHased.Multiline = true;
            this.txtAudienseHased.Name = "txtAudienseHased";
            this.txtAudienseHased.Size = new System.Drawing.Size(584, 44);
            this.txtAudienseHased.TabIndex = 32;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 22);
            this.button1.TabIndex = 33;
            this.button1.Text = "Reverse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(94, 240);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(584, 44);
            this.textBox1.TabIndex = 34;
            // 
            // frmJWT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAudienseHased);
            this.Controls.Add(this.btnGenHashedPassword);
            this.Name = "frmJWT";
            this.Text = "frmJWT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGenHashedPassword;
        private System.Windows.Forms.TextBox txtAudienseHased;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}