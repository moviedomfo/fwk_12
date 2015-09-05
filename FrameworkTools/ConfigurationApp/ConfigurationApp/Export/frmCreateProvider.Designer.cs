namespace ConfigurationApp
{
    partial class frmCreateProvider
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
            this.components = new System.ComponentModel.Container();
            this.txtConfigFileName = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.lblName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtSource = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.btnSearAssemblie = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCnnStrings = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCnnStringValue = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.txtCnnStringName = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtConfigFileName
            // 
            this.txtConfigFileName.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtConfigFileName.AllowBlankSpace = true;
            this.txtConfigFileName.AllowedCharacters = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
            this.txtConfigFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfigFileName.BackColor = System.Drawing.Color.White;
            this.txtConfigFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfigFileName.CapitalOnly = false;
            this.txtConfigFileName.ErrorIconRightToLeft = true;
            this.txtConfigFileName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfigFileName.InactiveBorderColor = System.Drawing.SystemColors.Control;
            this.txtConfigFileName.Location = new System.Drawing.Point(12, 78);
            this.txtConfigFileName.Name = "txtConfigFileName";
            this.txtConfigFileName.NotAllowedCharactersErrorText = null;
            this.txtConfigFileName.Required = true;
            this.txtConfigFileName.RequiredErrorText = "Name value is required";
            this.txtConfigFileName.Size = new System.Drawing.Size(662, 21);
            this.txtConfigFileName.TabIndex = 11;
            this.txtConfigFileName.TabStop = false;
            this.txtConfigFileName.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.AlphaNumericNotAllowSimbols;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 62);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(66, 13);
            this.lblName.TabIndex = 76;
            this.lblName.Text = "Config name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 79;
            this.label3.Text = "Provider name";
            // 
            // txtName
            // 
            this.txtName.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtName.AllowBlankSpace = true;
            this.txtName.AllowedCharacters = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.CapitalOnly = false;
            this.txtName.ErrorIconRightToLeft = true;
            this.txtName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.InactiveBorderColor = System.Drawing.SystemColors.Control;
            this.txtName.Location = new System.Drawing.Point(11, 26);
            this.txtName.Name = "txtName";
            this.txtName.NotAllowedCharactersErrorText = null;
            this.txtName.Required = true;
            this.txtName.RequiredErrorText = "Name value is required";
            this.txtName.Size = new System.Drawing.Size(662, 21);
            this.txtName.TabIndex = 10;
            this.txtName.TabStop = false;
            this.txtName.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 81;
            this.label4.Text = "Type";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "xml",
            "sqldatabase"});
            this.cboType.Location = new System.Drawing.Point(12, 129);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(222, 21);
            this.cboType.TabIndex = 12;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // btnOk
            // 
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(608, 443);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(66, 23);
            this.btnOk.TabIndex = 82;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtSource
            // 
            this.txtSource.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtSource.AllowBlankSpace = true;
            this.txtSource.AllowedCharacters = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSource.BackColor = System.Drawing.Color.White;
            this.txtSource.CapitalOnly = false;
            this.txtSource.ErrorIconRightToLeft = true;
            this.txtSource.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSource.InactiveBorderColor = System.Drawing.SystemColors.Control;
            this.txtSource.Location = new System.Drawing.Point(11, 42);
            this.txtSource.Name = "txtSource";
            this.txtSource.NotAllowedCharactersErrorText = null;
            this.txtSource.Required = true;
            this.txtSource.RequiredErrorText = "Name value is required";
            this.txtSource.Size = new System.Drawing.Size(575, 21);
            this.txtSource.TabIndex = 83;
            this.txtSource.TabStop = false;
            this.txtSource.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            this.txtSource.TextChanged += new System.EventHandler(this.txtSource_TextChanged);
            // 
            // btnSearAssemblie
            // 
            this.btnSearAssemblie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearAssemblie.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearAssemblie.Image = global::ConfigurationApp.Properties.Resources.mostrar;
            this.btnSearAssemblie.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearAssemblie.Location = new System.Drawing.Point(604, 42);
            this.btnSearAssemblie.Name = "btnSearAssemblie";
            this.btnSearAssemblie.Size = new System.Drawing.Size(28, 23);
            this.btnSearAssemblie.TabIndex = 84;
            this.btnSearAssemblie.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearAssemblie.UseVisualStyleBackColor = true;
            this.btnSearAssemblie.Click += new System.EventHandler(this.btnSearhAssemblie_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 85;
            this.label1.Text = "File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(48, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 87;
            this.label2.Text = "Connection strings";
            // 
            // cboCnnStrings
            // 
            this.cboCnnStrings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCnnStrings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCnnStrings.FormattingEnabled = true;
            this.cboCnnStrings.Location = new System.Drawing.Point(51, 43);
            this.cboCnnStrings.Name = "cboCnnStrings";
            this.cboCnnStrings.Size = new System.Drawing.Size(236, 21);
            this.cboCnnStrings.TabIndex = 86;
            this.cboCnnStrings.SelectedIndexChanged += new System.EventHandler(this.cboCnnStrings_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(11, 167);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(672, 273);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(664, 247);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Xml";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSource);
            this.groupBox2.Controls.Add(this.btnSearAssemblie);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(638, 222);
            this.groupBox2.TabIndex = 86;
            this.groupBox2.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(664, 247);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SQL Database";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboCnnStrings);
            this.groupBox1.Controls.Add(this.txtCnnStringValue);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCnnStringName);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(6, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 213);
            this.groupBox1.TabIndex = 91;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 91;
            this.label7.Text = "Connection string";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 83;
            this.label6.Text = "Name";
            // 
            // txtCnnStringValue
            // 
            this.txtCnnStringValue.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtCnnStringValue.AllowBlankSpace = true;
            this.txtCnnStringValue.AllowedCharacters = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
            this.txtCnnStringValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCnnStringValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(253)))));
            this.txtCnnStringValue.CapitalOnly = false;
            this.txtCnnStringValue.ErrorIconRightToLeft = true;
            this.txtCnnStringValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCnnStringValue.InactiveBorderColor = System.Drawing.SystemColors.Control;
            this.txtCnnStringValue.Location = new System.Drawing.Point(28, 171);
            this.txtCnnStringValue.Name = "txtCnnStringValue";
            this.txtCnnStringValue.NotAllowedCharactersErrorText = null;
            this.txtCnnStringValue.ReadOnly = true;
            this.txtCnnStringValue.Required = true;
            this.txtCnnStringValue.RequiredErrorText = "Name value is required";
            this.txtCnnStringValue.Size = new System.Drawing.Size(595, 21);
            this.txtCnnStringValue.TabIndex = 90;
            this.txtCnnStringValue.TabStop = false;
            this.txtCnnStringValue.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            // 
            // txtCnnStringName
            // 
            this.txtCnnStringName.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtCnnStringName.AllowBlankSpace = true;
            this.txtCnnStringName.AllowedCharacters = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
            this.txtCnnStringName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCnnStringName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(253)))));
            this.txtCnnStringName.CapitalOnly = false;
            this.txtCnnStringName.ErrorIconRightToLeft = true;
            this.txtCnnStringName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCnnStringName.InactiveBorderColor = System.Drawing.SystemColors.Control;
            this.txtCnnStringName.Location = new System.Drawing.Point(28, 125);
            this.txtCnnStringName.Name = "txtCnnStringName";
            this.txtCnnStringName.NotAllowedCharactersErrorText = null;
            this.txtCnnStringName.ReadOnly = true;
            this.txtCnnStringName.Required = true;
            this.txtCnnStringName.RequiredErrorText = "Name value is required";
            this.txtCnnStringName.Size = new System.Drawing.Size(239, 21);
            this.txtCnnStringName.TabIndex = 86;
            this.txtCnnStringName.TabStop = false;
            this.txtCnnStringName.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(10, 81);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(10, 11);
            this.radioButton2.TabIndex = 89;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(63, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 13);
            this.label5.TabIndex = 87;
            this.label5.Text = "New connection String";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(10, 27);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(10, 11);
            this.radioButton1.TabIndex = 88;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // frmCreateProvider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 466);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtConfigFileName);
            this.Controls.Add(this.lblName);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreateProvider";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add provider";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtConfigFileName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label3;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Button btnOk;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtSource;
        private System.Windows.Forms.Button btnSearAssemblie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCnnStrings;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtCnnStringName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtCnnStringValue;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}