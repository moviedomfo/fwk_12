namespace Fwk.Logging.Viewer
{
    partial class ServiceErrorView
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblErrorId = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMachine = new System.Windows.Forms.Label();
            this.Machine = new System.Windows.Forms.Label();
            this.lblMessage1 = new System.Windows.Forms.Label();
            this.txtMessage1 = new System.Windows.Forms.TextBox();
            this.lblErrorType = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCopyRequstToClip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Error Id";
            // 
            // lblErrorId
            // 
            this.lblErrorId.BackColor = System.Drawing.Color.White;
            this.lblErrorId.Location = new System.Drawing.Point(84, 29);
            this.lblErrorId.Name = "lblErrorId";
            this.lblErrorId.Size = new System.Drawing.Size(182, 13);
            this.lblErrorId.TabIndex = 1;
            // 
            // lblSource
            // 
            this.lblSource.BackColor = System.Drawing.Color.White;
            this.lblSource.Location = new System.Drawing.Point(84, 79);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(182, 13);
            this.lblSource.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Source";
            // 
            // lblMachine
            // 
            this.lblMachine.BackColor = System.Drawing.Color.White;
            this.lblMachine.Location = new System.Drawing.Point(84, 53);
            this.lblMachine.Name = "lblMachine";
            this.lblMachine.Size = new System.Drawing.Size(182, 13);
            this.lblMachine.TabIndex = 5;
            // 
            // Machine
            // 
            this.Machine.AutoSize = true;
            this.Machine.Location = new System.Drawing.Point(16, 53);
            this.Machine.Name = "Machine";
            this.Machine.Size = new System.Drawing.Size(48, 13);
            this.Machine.TabIndex = 4;
            this.Machine.Text = "Machine";
            // 
            // lblMessage1
            // 
            this.lblMessage1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage1.AutoSize = true;
            this.lblMessage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage1.Location = new System.Drawing.Point(346, 11);
            this.lblMessage1.Name = "lblMessage1";
            this.lblMessage1.Size = new System.Drawing.Size(57, 13);
            this.lblMessage1.TabIndex = 7;
            this.lblMessage1.Text = "Message";
            // 
            // txtMessage1
            // 
            this.txtMessage1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMessage1.Location = new System.Drawing.Point(316, 33);
            this.txtMessage1.Multiline = true;
            this.txtMessage1.Name = "txtMessage1";
            this.txtMessage1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage1.Size = new System.Drawing.Size(481, 299);
            this.txtMessage1.TabIndex = 6;
            // 
            // lblErrorType
            // 
            this.lblErrorType.BackColor = System.Drawing.Color.White;
            this.lblErrorType.Location = new System.Drawing.Point(84, 117);
            this.lblErrorType.Name = "lblErrorType";
            this.lblErrorType.Size = new System.Drawing.Size(182, 13);
            this.lblErrorType.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Error Type";
            // 
            // lblUser
            // 
            this.lblUser.BackColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(84, 151);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(182, 13);
            this.lblUser.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "User";
            // 
            // btnCopyRequstToClip
            // 
            this.btnCopyRequstToClip.BackColor = System.Drawing.Color.White;
            this.btnCopyRequstToClip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyRequstToClip.Image = global::Fwk.Logging.Viewer.Properties.Resources.Copy;
            this.btnCopyRequstToClip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopyRequstToClip.Location = new System.Drawing.Point(418, 5);
            this.btnCopyRequstToClip.Name = "btnCopyRequstToClip";
            this.btnCopyRequstToClip.Size = new System.Drawing.Size(57, 24);
            this.btnCopyRequstToClip.TabIndex = 12;
            this.btnCopyRequstToClip.Text = "Copy";
            this.btnCopyRequstToClip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopyRequstToClip.UseVisualStyleBackColor = false;
            this.btnCopyRequstToClip.Click += new System.EventHandler(this.btnCopyRequstToClip_Click);
            // 
            // ServiceErrorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCopyRequstToClip);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblErrorType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblMessage1);
            this.Controls.Add(this.txtMessage1);
            this.Controls.Add(this.lblMachine);
            this.Controls.Add(this.Machine);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblErrorId);
            this.Controls.Add(this.label1);
            this.Name = "ServiceErrorView";
            this.Size = new System.Drawing.Size(856, 346);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblErrorId;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMachine;
        private System.Windows.Forms.Label Machine;
        private System.Windows.Forms.Label lblMessage1;
        private System.Windows.Forms.TextBox txtMessage1;
        private System.Windows.Forms.Label lblErrorType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCopyRequstToClip;
    }
}
