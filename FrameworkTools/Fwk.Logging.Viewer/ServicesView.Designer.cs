namespace Fwk.Logging.Viewer
{
    partial class ServicesView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMessage2 = new System.Windows.Forms.Label();
            this.lblMessage1 = new System.Windows.Forms.Label();
            this.txtMessage2 = new System.Windows.Forms.TextBox();
            this.txtMessage1 = new System.Windows.Forms.TextBox();
            this.btnCopyResToClip = new System.Windows.Forms.Button();
            this.btnCopyRequstToClip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMessage2
            // 
            this.lblMessage2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage2.AutoSize = true;
            this.lblMessage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage2.Location = new System.Drawing.Point(582, 11);
            this.lblMessage2.Name = "lblMessage2";
            this.lblMessage2.Size = new System.Drawing.Size(63, 13);
            this.lblMessage2.TabIndex = 9;
            this.lblMessage2.Text = "Response";
            // 
            // lblMessage1
            // 
            this.lblMessage1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage1.AutoSize = true;
            this.lblMessage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage1.Location = new System.Drawing.Point(8, 10);
            this.lblMessage1.Name = "lblMessage1";
            this.lblMessage1.Size = new System.Drawing.Size(54, 13);
            this.lblMessage1.TabIndex = 8;
            this.lblMessage1.Text = "Request";
            // 
            // txtMessage2
            // 
            this.txtMessage2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMessage2.Location = new System.Drawing.Point(585, 33);
            this.txtMessage2.Multiline = true;
            this.txtMessage2.Name = "txtMessage2";
            this.txtMessage2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage2.Size = new System.Drawing.Size(556, 325);
            this.txtMessage2.TabIndex = 7;
            // 
            // txtMessage1
            // 
            this.txtMessage1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMessage1.Location = new System.Drawing.Point(6, 33);
            this.txtMessage1.Multiline = true;
            this.txtMessage1.Name = "txtMessage1";
            this.txtMessage1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage1.Size = new System.Drawing.Size(556, 325);
            this.txtMessage1.TabIndex = 6;
            // 
            // btnCopyResToClip
            // 
            this.btnCopyResToClip.BackColor = System.Drawing.Color.White;
            this.btnCopyResToClip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyResToClip.Image = global::Fwk.Logging.Viewer.Properties.Resources.Copy;
            this.btnCopyResToClip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopyResToClip.Location = new System.Drawing.Point(651, 6);
            this.btnCopyResToClip.Name = "btnCopyResToClip";
            this.btnCopyResToClip.Size = new System.Drawing.Size(57, 24);
            this.btnCopyResToClip.TabIndex = 11;
            this.btnCopyResToClip.Text = "Copy";
            this.btnCopyResToClip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopyResToClip.UseVisualStyleBackColor = false;
            this.btnCopyResToClip.Click += new System.EventHandler(this.btnCopyResToClip_Click);
            // 
            // btnCopyRequstToClip
            // 
            this.btnCopyRequstToClip.BackColor = System.Drawing.Color.White;
            this.btnCopyRequstToClip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyRequstToClip.Image = global::Fwk.Logging.Viewer.Properties.Resources.Copy;
            this.btnCopyRequstToClip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopyRequstToClip.Location = new System.Drawing.Point(80, 5);
            this.btnCopyRequstToClip.Name = "btnCopyRequstToClip";
            this.btnCopyRequstToClip.Size = new System.Drawing.Size(57, 24);
            this.btnCopyRequstToClip.TabIndex = 10;
            this.btnCopyRequstToClip.Text = "Copy";
            this.btnCopyRequstToClip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopyRequstToClip.UseVisualStyleBackColor = false;
            this.btnCopyRequstToClip.Click += new System.EventHandler(this.btnCopyRequstToClip_Click);
            // 
            // ServicesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCopyResToClip);
            this.Controls.Add(this.btnCopyRequstToClip);
            this.Controls.Add(this.lblMessage2);
            this.Controls.Add(this.lblMessage1);
            this.Controls.Add(this.txtMessage2);
            this.Controls.Add(this.txtMessage1);
            this.Name = "ServicesView";
            this.Size = new System.Drawing.Size(1166, 361);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage2;
        private System.Windows.Forms.Label lblMessage1;
        private System.Windows.Forms.TextBox txtMessage2;
        private System.Windows.Forms.TextBox txtMessage1;
        private System.Windows.Forms.Button btnCopyRequstToClip;
        private System.Windows.Forms.Button btnCopyResToClip;
    }
}
