namespace Fwk.GuidPk
{
    partial class wizDbSelect_2
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtCnnString = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDataBases = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.WindowsAutentificaction = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // infoPanel
            // 
            this.infoPanel.BackColor = System.Drawing.SystemColors.Control;
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.None;
            this.infoPanel.Location = new System.Drawing.Point(4, 107);
            this.infoPanel.Size = new System.Drawing.Size(714, 379);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Image = global::Fwk.GuidPk.Properties.Resources.home_migracion;
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(722, 103);
            this.lblTitle.TabIndex = 67;
            this.lblTitle.Text = "                              Connection";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.btnCopy);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.txtCnnString);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.lblUserName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbDataBases);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbServer);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(20, 162);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(671, 295);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            // 
            // btnCopy
            // 
            this.btnCopy.Image = global::Fwk.GuidPk.Properties.Resources.copy_16;
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(13, 212);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(26, 68);
            this.btnCopy.TabIndex = 76;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(346, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 34);
            this.button1.TabIndex = 61;
            this.button1.Text = "Test connection";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.DimGray;
            this.lblPassword.Location = new System.Drawing.Point(36, 129);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(139, 22);
            this.lblPassword.TabIndex = 59;
            this.lblPassword.Text = "Password";
            // 
            // txtCnnString
            // 
            this.txtCnnString.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCnnString.ForeColor = System.Drawing.Color.SlateGray;
            this.txtCnnString.Location = new System.Drawing.Point(40, 212);
            this.txtCnnString.Multiline = true;
            this.txtCnnString.Name = "txtCnnString";
            this.txtCnnString.Size = new System.Drawing.Size(624, 68);
            this.txtCnnString.TabIndex = 67;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Enabled = false;
            this.txtPassword.ForeColor = System.Drawing.Color.Maroon;
            this.txtPassword.Location = new System.Drawing.Point(178, 125);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(255, 22);
            this.txtPassword.TabIndex = 57;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Enabled = false;
            this.txtUserName.ForeColor = System.Drawing.Color.Maroon;
            this.txtUserName.Location = new System.Drawing.Point(178, 92);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(255, 22);
            this.txtUserName.TabIndex = 55;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.DimGray;
            this.lblUserName.Location = new System.Drawing.Point(36, 99);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(139, 22);
            this.lblUserName.TabIndex = 54;
            this.lblUserName.Text = "User name";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(11, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 53;
            this.label4.Text = "SQL Server";
            // 
            // cmbDataBases
            // 
            this.cmbDataBases.Location = new System.Drawing.Point(160, 52);
            this.cmbDataBases.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDataBases.Name = "cmbDataBases";
            this.cmbDataBases.Size = new System.Drawing.Size(255, 24);
            this.cmbDataBases.TabIndex = 50;
            this.cmbDataBases.SelectedIndexChanged += new System.EventHandler(this.cmbDataBases_SelectedIndexChanged);
            this.cmbDataBases.Click += new System.EventHandler(this.cmbDataBases_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(12, 59);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 20);
            this.label6.TabIndex = 48;
            this.label6.Text = "Database";
            // 
            // cmbServer
            // 
            this.cmbServer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(160, 20);
            this.cmbServer.Margin = new System.Windows.Forms.Padding(4);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(255, 24);
            this.cmbServer.TabIndex = 2;
            this.cmbServer.Click += new System.EventHandler(this.cmbServer_Click);
            // 
            // WindowsAutentificaction
            // 
            this.WindowsAutentificaction.BackColor = System.Drawing.SystemColors.Control;
            this.WindowsAutentificaction.Checked = true;
            this.WindowsAutentificaction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WindowsAutentificaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindowsAutentificaction.ForeColor = System.Drawing.Color.DimGray;
            this.WindowsAutentificaction.Location = new System.Drawing.Point(4, 107);
            this.WindowsAutentificaction.Margin = new System.Windows.Forms.Padding(4);
            this.WindowsAutentificaction.Name = "WindowsAutentificaction";
            this.WindowsAutentificaction.Size = new System.Drawing.Size(433, 49);
            this.WindowsAutentificaction.TabIndex = 65;
            this.WindowsAutentificaction.Text = "Use windows authentication";
            this.WindowsAutentificaction.UseVisualStyleBackColor = false;
            this.WindowsAutentificaction.CheckedChanged += new System.EventHandler(this.WindowsAutentificaction_CheckedChanged);
            // 
            // wizDbSelect_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.WindowsAutentificaction);
            this.Name = "wizDbSelect_2";
            this.Size = new System.Drawing.Size(722, 490);
            this.Load += new System.EventHandler(this.wizDbSelect_2_Load);
            this.Controls.SetChildIndex(this.infoPanel, 0);
            this.Controls.SetChildIndex(this.WindowsAutentificaction, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDataBases;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.CheckBox WindowsAutentificaction;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCnnString;
        private System.Windows.Forms.Button btnCopy;
    }
}
