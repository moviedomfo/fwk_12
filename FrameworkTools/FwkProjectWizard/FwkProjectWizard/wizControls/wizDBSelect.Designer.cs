namespace Fwk.Wizard
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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(718, 75);
            this.lblTitle.Text = "Fwk entity item";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(572, 437);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(301, 437);
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(469, 437);
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(211, 437);
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // cmbServer
            // 
            this.cmbServer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(120, 38);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(192, 21);
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
            this.groupBox1.Location = new System.Drawing.Point(26, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(657, 202);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(51, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 18);
            this.label5.TabIndex = 59;
            this.label5.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Enabled = false;
            this.txtPassword.ForeColor = System.Drawing.Color.Maroon;
            this.txtPassword.Location = new System.Drawing.Point(163, 125);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(192, 20);
            this.txtPassword.TabIndex = 57;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestConnection.BackColor = System.Drawing.Color.SlateGray;
            this.btnTestConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestConnection.ForeColor = System.Drawing.SystemColors.Info;
            this.btnTestConnection.Location = new System.Drawing.Point(460, 85);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(112, 24);
            this.btnTestConnection.TabIndex = 60;
            this.btnTestConnection.Text = "Testear Coneccion";
            this.btnTestConnection.UseVisualStyleBackColor = false;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Enabled = false;
            this.txtUserName.ForeColor = System.Drawing.Color.Maroon;
            this.txtUserName.Location = new System.Drawing.Point(163, 98);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(192, 20);
            this.txtUserName.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(51, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 18);
            this.label2.TabIndex = 54;
            this.label2.Text = "Nombre de usuario";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(8, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 53;
            this.label4.Text = "Servidor SQL";
            // 
            // cmbDataBases
            // 
            this.cmbDataBases.Location = new System.Drawing.Point(120, 64);
            this.cmbDataBases.Name = "cmbDataBases";
            this.cmbDataBases.Size = new System.Drawing.Size(192, 21);
            this.cmbDataBases.TabIndex = 50;
            this.cmbDataBases.Click += new System.EventHandler(this.cmbDataBases_Click);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.SteelBlue;
            this.label6.Location = new System.Drawing.Point(9, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 16);
            this.label6.TabIndex = 48;
            this.label6.Text = "Base de datos";
            // 
            // WindowsAutentificaction
            // 
            this.WindowsAutentificaction.Checked = true;
            this.WindowsAutentificaction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WindowsAutentificaction.ForeColor = System.Drawing.Color.SteelBlue;
            this.WindowsAutentificaction.Location = new System.Drawing.Point(26, 105);
            this.WindowsAutentificaction.Name = "WindowsAutentificaction";
            this.WindowsAutentificaction.Size = new System.Drawing.Size(328, 22);
            this.WindowsAutentificaction.TabIndex = 62;
            this.WindowsAutentificaction.Text = "Usar autentificacion de windows";
            this.WindowsAutentificaction.CheckedChanged += new System.EventHandler(this.WindowsAutentificaction_CheckedChanged);
            // 
            // wizDBSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.WindowsAutentificaction);
            this.Name = "wizDBSelect";
            this.Size = new System.Drawing.Size(718, 477);
            this.Title = "Fwk entity item";
            this.Load += new System.EventHandler(this.wizDBSelect_Load);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnBack, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.WindowsAutentificaction, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

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
    }
}
