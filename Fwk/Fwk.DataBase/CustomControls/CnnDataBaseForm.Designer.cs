namespace Fwk.DataBase.CustomControls
{
    partial class CnnDataBaseForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbConnections = new Fwk.Bases.FrontEnd.Controls.FwkAutoComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDataBases = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.WindowsAutentificaction = new System.Windows.Forms.CheckBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cnnStringListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cnnStringListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbConnections);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbDataBases);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(3, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 152);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            // 
            // cmbConnections
            // 
            this.cmbConnections.ActiveArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(142)))));
            this.cmbConnections.ActiveBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.cmbConnections.ActiveButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.cmbConnections.AllowEmptyTextValue = false;
            this.cmbConnections.AutoComplete = true;
            this.cmbConnections.DataSource = this.cnnStringListBindingSource;
            this.cmbConnections.DisplayMember = "Name";
            this.cmbConnections.ErrorIconRightToLeft = false;
            this.cmbConnections.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbConnections.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConnections.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.cmbConnections.FormattingEnabled = true;
            this.cmbConnections.InactiveArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.cmbConnections.InactiveBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.cmbConnections.InactiveButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.cmbConnections.Location = new System.Drawing.Point(120, 11);
            this.cmbConnections.Name = "cmbConnections";
            this.cmbConnections.NullTextValue = null;
            this.cmbConnections.ReadOnly = false;
            this.cmbConnections.ReadOnlyColor = System.Drawing.SystemColors.Control;
            this.cmbConnections.Required = true;
            this.cmbConnections.RequiredErrorText = null;
            this.cmbConnections.Size = new System.Drawing.Size(192, 21);
            this.cmbConnections.TabIndex = 63;
            this.cmbConnections.ValueMember = "Name";
            this.cmbConnections.SelectedValueChanged += new System.EventHandler(this.cmbConnections_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 62;
            this.label3.Text = "Connections";
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(8, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 59;
            this.label5.Text = "Password";
            // 
            // txtServer
            // 
            this.txtServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServer.ForeColor = System.Drawing.Color.Maroon;
            this.txtServer.Location = new System.Drawing.Point(120, 40);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(192, 20);
            this.txtServer.TabIndex = 58;
            this.txtServer.Leave += new System.EventHandler(this.txtServer_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.ForeColor = System.Drawing.Color.Maroon;
            this.txtPassword.Location = new System.Drawing.Point(120, 92);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(192, 20);
            this.txtPassword.TabIndex = 57;
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.ForeColor = System.Drawing.Color.Maroon;
            this.txtUserName.Location = new System.Drawing.Point(120, 65);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(192, 20);
            this.txtUserName.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(8, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 54;
            this.label2.Text = "Nombre de usuario";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(8, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 53;
            this.label1.Text = "Servidor SQL";
            // 
            // cmbDataBases
            // 
            this.cmbDataBases.Location = new System.Drawing.Point(120, 120);
            this.cmbDataBases.Name = "cmbDataBases";
            this.cmbDataBases.Size = new System.Drawing.Size(192, 21);
            this.cmbDataBases.TabIndex = 50;
            this.cmbDataBases.Click += new System.EventHandler(this.cmbDataBases_Click);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(8, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 48;
            this.label4.Text = "Base de datos";
            // 
            // WindowsAutentificaction
            // 
            this.WindowsAutentificaction.ForeColor = System.Drawing.Color.SteelBlue;
            this.WindowsAutentificaction.Location = new System.Drawing.Point(11, 6);
            this.WindowsAutentificaction.Name = "WindowsAutentificaction";
            this.WindowsAutentificaction.Size = new System.Drawing.Size(328, 22);
            this.WindowsAutentificaction.TabIndex = 58;
            this.WindowsAutentificaction.Text = "Usar autentificacion de windows";
            this.WindowsAutentificaction.CheckedChanged += new System.EventHandler(this.WindowsAutentificaction_CheckedChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.SlateGray;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.Info;
            this.btnAceptar.Location = new System.Drawing.Point(136, 186);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(80, 24);
            this.btnAceptar.TabIndex = 57;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.BackColor = System.Drawing.Color.SlateGray;
            this.btnTestConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestConnection.ForeColor = System.Drawing.SystemColors.Info;
            this.btnTestConnection.Location = new System.Drawing.Point(14, 185);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(112, 24);
            this.btnTestConnection.TabIndex = 56;
            this.btnTestConnection.Text = "Testear Coneccion";
            this.btnTestConnection.UseVisualStyleBackColor = false;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.SlateGray;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.Info;
            this.btnCancelar.Location = new System.Drawing.Point(235, 186);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 24);
            this.btnCancelar.TabIndex = 60;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cnnStringListBindingSource
            // 
            this.cnnStringListBindingSource.DataSource = typeof(Fwk.DataBase.CnnStringList);
            // 
            // CnnDataBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.WindowsAutentificaction);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnTestConnection);
            this.Name = "CnnDataBaseForm";
            this.Size = new System.Drawing.Size(348, 217);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cnnStringListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDataBases;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox WindowsAutentificaction;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Button btnCancelar;
       
        private System.Windows.Forms.Label label3;
        private Fwk.Bases.FrontEnd.Controls.FwkAutoComboBox cmbConnections;
        private System.Windows.Forms.BindingSource cnnStringListBindingSource;
    }
}
