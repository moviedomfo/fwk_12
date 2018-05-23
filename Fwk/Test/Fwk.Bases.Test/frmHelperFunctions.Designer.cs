namespace Fwk.Bases.Test
{
    partial class frmHelperFunctions
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
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnFormatFunctions = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtResult2 = new System.Windows.Forms.TextBox();
            this.txtResult1 = new System.Windows.Forms.TextBox();
            this.btnGet_logonserver = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label3.ForeColor = System.Drawing.Color.SlateGray;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(-2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(582, 36);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fwk HelperFunctions";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(753, 147);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnFormatFunctions);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(745, 121);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "FormatFunctions";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnFormatFunctions
            // 
            this.btnFormatFunctions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnFormatFunctions.Location = new System.Drawing.Point(6, 6);
            this.btnFormatFunctions.Name = "btnFormatFunctions";
            this.btnFormatFunctions.Size = new System.Drawing.Size(195, 22);
            this.btnFormatFunctions.TabIndex = 0;
            this.btnFormatFunctions.Text = "GetStringBuilderWhitSeparator";
            this.btnFormatFunctions.UseVisualStyleBackColor = false;
            this.btnFormatFunctions.Click += new System.EventHandler(this.btnFormatFunctions_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(745, 121);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Servicios";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage3.Size = new System.Drawing.Size(745, 121);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ServiceConfigurationManager";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtResult2
            // 
            this.txtResult2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtResult2.Location = new System.Drawing.Point(356, 215);
            this.txtResult2.Multiline = true;
            this.txtResult2.Name = "txtResult2";
            this.txtResult2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult2.Size = new System.Drawing.Size(413, 202);
            this.txtResult2.TabIndex = 17;
            // 
            // txtResult1
            // 
            this.txtResult1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtResult1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtResult1.Location = new System.Drawing.Point(7, 215);
            this.txtResult1.Multiline = true;
            this.txtResult1.Name = "txtResult1";
            this.txtResult1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult1.Size = new System.Drawing.Size(334, 202);
            this.txtResult1.TabIndex = 16;
            // 
            // btnGet_logonserver
            // 
            this.btnGet_logonserver.Location = new System.Drawing.Point(555, 12);
            this.btnGet_logonserver.Name = "btnGet_logonserver";
            this.btnGet_logonserver.Size = new System.Drawing.Size(160, 35);
            this.btnGet_logonserver.TabIndex = 18;
            this.btnGet_logonserver.Text = "Get (\"logonserver\")";
            this.btnGet_logonserver.UseVisualStyleBackColor = true;
            this.btnGet_logonserver.Click += new System.EventHandler(this.btnGet_logonserver_Click);
            // 
            // frmHelperFunctions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 488);
            this.Controls.Add(this.btnGet_logonserver);
            this.Controls.Add(this.txtResult2);
            this.Controls.Add(this.txtResult1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label3);
            this.Name = "frmHelperFunctions";
            this.Text = "frmHelperFunctions";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnFormatFunctions;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtResult2;
        private System.Windows.Forms.TextBox txtResult1;
        private System.Windows.Forms.Button btnGet_logonserver;
    }
}