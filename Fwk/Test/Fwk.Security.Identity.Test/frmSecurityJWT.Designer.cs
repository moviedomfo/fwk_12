namespace Fwk.Security.Identity.Test
{
    partial class frmSecurityJWT
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
            this.txtAudienseHased = new System.Windows.Forms.TextBox();
            this.btnKey = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.txtAutenticatedValues = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtAutenticatedValues2 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.txtToken2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAudienseHased
            // 
            this.txtAudienseHased.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAudienseHased.Location = new System.Drawing.Point(268, 33);
            this.txtAudienseHased.Margin = new System.Windows.Forms.Padding(4);
            this.txtAudienseHased.Multiline = true;
            this.txtAudienseHased.Name = "txtAudienseHased";
            this.txtAudienseHased.Size = new System.Drawing.Size(561, 38);
            this.txtAudienseHased.TabIndex = 15;
            // 
            // btnKey
            // 
            this.btnKey.Location = new System.Drawing.Point(22, 33);
            this.btnKey.Margin = new System.Windows.Forms.Padding(4);
            this.btnKey.Name = "btnKey";
            this.btnKey.Size = new System.Drawing.Size(225, 27);
            this.btnKey.TabIndex = 16;
            this.btnKey.Text = "Create Audiense Secret";
            this.btnKey.UseVisualStyleBackColor = true;
            this.btnKey.Click += new System.EventHandler(this.btnKey_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(504, 38);
            this.button1.TabIndex = 17;
            this.button1.Text = "Generar Token con CustomJwtFormat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnGenerateToken1_Click);
            // 
            // txtToken
            // 
            this.txtToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToken.Location = new System.Drawing.Point(7, 61);
            this.txtToken.Margin = new System.Windows.Forms.Padding(4);
            this.txtToken.Multiline = true;
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(632, 395);
            this.txtToken.TabIndex = 18;
            // 
            // txtAutenticatedValues
            // 
            this.txtAutenticatedValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAutenticatedValues.Location = new System.Drawing.Point(661, 67);
            this.txtAutenticatedValues.Margin = new System.Windows.Forms.Padding(4);
            this.txtAutenticatedValues.Multiline = true;
            this.txtAutenticatedValues.Name = "txtAutenticatedValues";
            this.txtAutenticatedValues.Size = new System.Drawing.Size(419, 389);
            this.txtAutenticatedValues.TabIndex = 19;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(883, 15);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 27);
            this.button2.TabIndex = 20;
            this.button2.Text = "Consumir con Token";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(22, 112);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1095, 516);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtToken);
            this.tabPage1.Controls.Add(this.txtAutenticatedValues);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1087, 487);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtAutenticatedValues2);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.txtToken2);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1087, 487);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtAutenticatedValues2
            // 
            this.txtAutenticatedValues2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAutenticatedValues2.Location = new System.Drawing.Point(740, 67);
            this.txtAutenticatedValues2.Margin = new System.Windows.Forms.Padding(4);
            this.txtAutenticatedValues2.Multiline = true;
            this.txtAutenticatedValues2.Name = "txtAutenticatedValues2";
            this.txtAutenticatedValues2.Size = new System.Drawing.Size(340, 389);
            this.txtAutenticatedValues2.TabIndex = 21;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(780, 26);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(197, 27);
            this.button4.TabIndex = 22;
            this.button4.Text = "Consumir / validar con Token";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnValidateToken_Click);
            // 
            // txtToken2
            // 
            this.txtToken2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToken2.Location = new System.Drawing.Point(23, 67);
            this.txtToken2.Margin = new System.Windows.Forms.Padding(4);
            this.txtToken2.Multiline = true;
            this.txtToken2.Name = "txtToken2";
            this.txtToken2.Size = new System.Drawing.Size(677, 381);
            this.txtToken2.TabIndex = 19;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(4, 7);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(504, 38);
            this.button3.TabIndex = 18;
            this.button3.Text = "Generar Token con JwtSecurityToken";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnGenerateToken_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(932, 55);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(138, 27);
            this.button5.TabIndex = 22;
            this.button5.Text = "User get";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // frmSecurityJWT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1468, 675);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnKey);
            this.Controls.Add(this.txtAudienseHased);
            this.Name = "frmSecurityJWT";
            this.Text = "frmSecurityJWT";
            this.Load += new System.EventHandler(this.frmSecurityJWT_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAudienseHased;
        private System.Windows.Forms.Button btnKey;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.TextBox txtAutenticatedValues;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtToken2;
        private System.Windows.Forms.TextBox txtAutenticatedValues2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

