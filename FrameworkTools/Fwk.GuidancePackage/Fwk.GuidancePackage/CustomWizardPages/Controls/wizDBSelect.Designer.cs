namespace Fwk.GuidPk
{
    partial class wizDBSelect
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDataBases = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.WindowsAutentificaction = new System.Windows.Forms.CheckBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // infoPanel
            // 
            this.infoPanel.Location = new System.Drawing.Point(0, 180);
            this.infoPanel.Margin = new System.Windows.Forms.Padding(5);
            this.infoPanel.Size = new System.Drawing.Size(897, 379);
            // 
            // cmbServer
            // 
            this.cmbServer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(160, 47);
            this.cmbServer.Margin = new System.Windows.Forms.Padding(4);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(255, 24);
            this.cmbServer.TabIndex = 2;
            
            this.cmbServer.Click += new System.EventHandler(this.cmbServer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.btnTestConnection);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbDataBases);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbServer);
            this.groupBox1.Location = new System.Drawing.Point(17, 164);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(876, 246);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(68, 156);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 22);
            this.label5.TabIndex = 59;
            this.label5.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Enabled = false;
            this.txtPassword.ForeColor = System.Drawing.Color.Maroon;
            this.txtPassword.Location = new System.Drawing.Point(217, 154);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(255, 22);
            this.txtPassword.TabIndex = 57;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestConnection.BackColor = System.Drawing.Color.SlateGray;
            this.btnTestConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestConnection.ForeColor = System.Drawing.SystemColors.Info;
            this.btnTestConnection.Location = new System.Drawing.Point(524, 146);
            this.btnTestConnection.Margin = new System.Windows.Forms.Padding(4);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(100, 30);
            this.btnTestConnection.TabIndex = 60;
            this.btnTestConnection.Text = "Test ";
            this.btnTestConnection.UseVisualStyleBackColor = false;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Enabled = false;
            this.txtUserName.ForeColor = System.Drawing.Color.Maroon;
            this.txtUserName.Location = new System.Drawing.Point(217, 121);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(255, 22);
            this.txtUserName.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(68, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 22);
            this.label2.TabIndex = 54;
            this.label2.Text = "Nombre de usuario";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(11, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 53;
            this.label4.Text = "Servidor SQL";
            // 
            // cmbDataBases
            // 
            this.cmbDataBases.Location = new System.Drawing.Point(160, 79);
            this.cmbDataBases.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDataBases.Name = "cmbDataBases";
            this.cmbDataBases.Size = new System.Drawing.Size(255, 24);
            this.cmbDataBases.TabIndex = 50;
            this.cmbDataBases.SelectedIndexChanged += new System.EventHandler(this.cmbDataBases_SelectedIndexChanged);
            this.cmbDataBases.Click += new System.EventHandler(this.cmbDataBases_Click);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.SteelBlue;
            this.label6.Location = new System.Drawing.Point(12, 86);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 20);
            this.label6.TabIndex = 48;
            this.label6.Text = "Base de datos";
            // 
            // WindowsAutentificaction
            // 
            this.WindowsAutentificaction.Checked = true;
            this.WindowsAutentificaction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WindowsAutentificaction.ForeColor = System.Drawing.Color.SteelBlue;
            this.WindowsAutentificaction.Location = new System.Drawing.Point(35, 129);
            this.WindowsAutentificaction.Margin = new System.Windows.Forms.Padding(4);
            this.WindowsAutentificaction.Name = "WindowsAutentificaction";
            this.WindowsAutentificaction.Size = new System.Drawing.Size(437, 27);
            this.WindowsAutentificaction.TabIndex = 62;
            this.WindowsAutentificaction.Text = "Usar autentificacion de windows";
            this.WindowsAutentificaction.CheckedChanged += new System.EventHandler(this.WindowsAutentificaction_CheckedChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Image = global::Fwk.GuidPk.Properties.Resources.applications_32;
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(897, 92);
            this.lblTitle.TabIndex = 64;
            this.lblTitle.Text = "Select database";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wizDBSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.WindowsAutentificaction);
            this.Name = "wizDBSelect";
            this.Size = new System.Drawing.Size(897, 559);
            this.Load += new System.EventHandler(this.wizDBSelect_Load);
            this.VisibleChanged += new System.EventHandler(this.wizDBSelect_VisibleChanged);
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

        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDataBases;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox WindowsAutentificaction;
        private System.Windows.Forms.Button btnTestConnection;
        public System.Windows.Forms.Label lblTitle;
    }
}
