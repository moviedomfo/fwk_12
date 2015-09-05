namespace Fwk.Security.ActiveDirectory.Test
{
    partial class UserPropertiesUpdate
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
            this.btnSearchInDomain = new System.Windows.Forms.Button();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSearchInDomain
            // 
            this.btnSearchInDomain.BackColor = System.Drawing.Color.White;
            this.btnSearchInDomain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchInDomain.Image = global::Fwk.Security.ActiveDirectory.Test.Properties.Resources.srch_16;
            this.btnSearchInDomain.Location = new System.Drawing.Point(324, 114);
            this.btnSearchInDomain.Name = "btnSearchInDomain";
            this.btnSearchInDomain.Size = new System.Drawing.Size(36, 20);
            this.btnSearchInDomain.TabIndex = 17;
            this.btnSearchInDomain.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearchInDomain.UseVisualStyleBackColor = false;
            this.btnSearchInDomain.Click += new System.EventHandler(this.btnSearchInDomain_Click);
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(138, 114);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(180, 20);
            this.txtDomain.TabIndex = 16;
            this.txtDomain.Text = "Pelsoft-ar";
            // 
            // UserPropertiesUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 524);
            this.Controls.Add(this.btnSearchInDomain);
            this.Controls.Add(this.txtDomain);
            this.Name = "UserPropertiesUpdate";
            this.Text = "UserPropertiesUpdate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchInDomain;
        private System.Windows.Forms.TextBox txtDomain;
    }
}