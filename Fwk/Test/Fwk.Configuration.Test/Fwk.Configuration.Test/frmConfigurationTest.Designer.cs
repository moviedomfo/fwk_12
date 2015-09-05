namespace Fwk.Configuration.Test
{
    partial class frmConfigurationTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigurationTest));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.encryptedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canUndoDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.keyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnGetGroupKeys = new System.Windows.Forms.Button();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtProrpetieName = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetProvider = new System.Windows.Forms.Button();
            this.grdGroups = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.xmlConfitFile = new System.Windows.Forms.TextBox();
            this.txtConfigFileName = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnLoadConfigFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnchangeDefaulProvider = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDefaulProvider = new System.Windows.Forms.TextBox();
            this.txtValueChangeDefaultProvider = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.ForestGreen;
            this.button1.Location = new System.Drawing.Point(212, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "GetProperty";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Beige;
            this.textBox1.Location = new System.Drawing.Point(431, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(386, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "group:ClientMessages  key: contrato_comercial_obligatorio";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(1, 71);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(957, 592);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox4);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(949, 566);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Configuracion Remota";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.White;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBox4.Location = new System.Drawing.Point(431, 61);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(386, 21);
            this.textBox4.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(24, 97);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(903, 393);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btnGetProvider);
            this.tabPage2.Controls.Add(this.grdGroups);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(949, 566);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configuracion Local";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(149, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "File name";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Controls.Add(this.btnGetGroupKeys);
            this.groupBox3.Controls.Add(this.txtGroupName);
            this.groupBox3.Location = new System.Drawing.Point(363, 53);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(564, 381);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Group";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Group name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn1,
            this.encryptedDataGridViewCheckBoxColumn,
            this.valueDataGridViewTextBoxColumn,
            this.canUndoDataGridViewCheckBoxColumn1});
            this.dataGridView1.DataSource = this.keyBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(10, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(539, 304);
            this.dataGridView1.TabIndex = 8;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            // 
            // encryptedDataGridViewCheckBoxColumn
            // 
            this.encryptedDataGridViewCheckBoxColumn.DataPropertyName = "Encrypted";
            this.encryptedDataGridViewCheckBoxColumn.HeaderText = "Encrypted";
            this.encryptedDataGridViewCheckBoxColumn.Name = "encryptedDataGridViewCheckBoxColumn";
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // canUndoDataGridViewCheckBoxColumn1
            // 
            this.canUndoDataGridViewCheckBoxColumn1.HeaderText = "CanUndo";
            this.canUndoDataGridViewCheckBoxColumn1.Name = "canUndoDataGridViewCheckBoxColumn1";
            this.canUndoDataGridViewCheckBoxColumn1.ReadOnly = true;
            this.canUndoDataGridViewCheckBoxColumn1.Visible = false;
            // 
            // keyBindingSource
            // 
            this.keyBindingSource.DataSource = typeof(Fwk.Configuration.Common.Key);
            // 
            // btnGetGroupKeys
            // 
            this.btnGetGroupKeys.Location = new System.Drawing.Point(267, 19);
            this.btnGetGroupKeys.Name = "btnGetGroupKeys";
            this.btnGetGroupKeys.Size = new System.Drawing.Size(106, 28);
            this.btnGetGroupKeys.TabIndex = 6;
            this.btnGetGroupKeys.Text = "Get Group Keys";
            this.btnGetGroupKeys.UseVisualStyleBackColor = true;
            this.btnGetGroupKeys.Click += new System.EventHandler(this.btnGetGroupKeys_Click);
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(10, 36);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(213, 20);
            this.txtGroupName.TabIndex = 9;
            this.txtGroupName.Text = "ExceptionMessages";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txtProrpetieName);
            this.groupBox2.Location = new System.Drawing.Point(365, 440);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(564, 91);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Propertie";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Value";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(101, 53);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(392, 28);
            this.textBox2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Provider name";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(330, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 28);
            this.button2.TabIndex = 4;
            this.button2.Text = "Get propertie";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtProrpetieName
            // 
            this.txtProrpetieName.Location = new System.Drawing.Point(101, 19);
            this.txtProrpetieName.Name = "txtProrpetieName";
            this.txtProrpetieName.Size = new System.Drawing.Size(192, 20);
            this.txtProrpetieName.TabIndex = 15;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(149, 28);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(192, 20);
            this.textBox3.TabIndex = 14;
            this.textBox3.Text = "ConfigurationManager_02.xml";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "P1",
            "P2"});
            this.comboBox1.Location = new System.Drawing.Point(452, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(111, 21);
            this.comboBox1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(371, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Provider name";
            // 
            // btnGetProvider
            // 
            this.btnGetProvider.Location = new System.Drawing.Point(-1, 20);
            this.btnGetProvider.Name = "btnGetProvider";
            this.btnGetProvider.Size = new System.Drawing.Size(144, 28);
            this.btnGetProvider.TabIndex = 11;
            this.btnGetProvider.Text = "Get groups from file";
            this.btnGetProvider.UseVisualStyleBackColor = true;
            this.btnGetProvider.Click += new System.EventHandler(this.btnGetProvider_Click);
            // 
            // grdGroups
            // 
            this.grdGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdGroups.AutoGenerateColumns = false;
            this.grdGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn});
            this.grdGroups.DataSource = this.groupBindingSource;
            this.grdGroups.Location = new System.Drawing.Point(7, 70);
            this.grdGroups.Name = "grdGroups";
            this.grdGroups.Size = new System.Drawing.Size(334, 490);
            this.grdGroups.TabIndex = 7;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // groupBindingSource
            // 
            this.groupBindingSource.DataSource = typeof(Fwk.Configuration.Common.Group);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.xmlConfitFile);
            this.tabPage3.Controls.Add(this.txtConfigFileName);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.btnLoadConfigFile);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(949, 566);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Config File";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(7, 35);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(171, 31);
            this.button4.TabIndex = 10;
            this.button4.Text = "Load Config File from object";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // xmlConfitFile
            // 
            this.xmlConfitFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xmlConfitFile.Location = new System.Drawing.Point(7, 72);
            this.xmlConfitFile.Multiline = true;
            this.xmlConfitFile.Name = "xmlConfitFile";
            this.xmlConfitFile.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.xmlConfitFile.Size = new System.Drawing.Size(656, 445);
            this.xmlConfitFile.TabIndex = 9;
            // 
            // txtConfigFileName
            // 
            this.txtConfigFileName.Location = new System.Drawing.Point(364, 29);
            this.txtConfigFileName.Name = "txtConfigFileName";
            this.txtConfigFileName.Size = new System.Drawing.Size(394, 20);
            this.txtConfigFileName.TabIndex = 8;
            this.txtConfigFileName.Text = "ConfigurationManager_02.xml";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(198, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(147, 31);
            this.button3.TabIndex = 5;
            this.button3.Text = "Load group from file";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnLoadConfigFile
            // 
            this.btnLoadConfigFile.Location = new System.Drawing.Point(7, 9);
            this.btnLoadConfigFile.Name = "btnLoadConfigFile";
            this.btnLoadConfigFile.Size = new System.Drawing.Size(171, 31);
            this.btnLoadConfigFile.TabIndex = 0;
            this.btnLoadConfigFile.Text = "Load Config File from object";
            this.btnLoadConfigFile.UseVisualStyleBackColor = true;
            this.btnLoadConfigFile.Click += new System.EventHandler(this.btnLoadConfigFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(958, 65);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label2.ForeColor = System.Drawing.Color.SlateGray;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(355, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fwk configuration";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtValueChangeDefaultProvider);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.txtDefaulProvider);
            this.tabPage4.Controls.Add(this.btnchangeDefaulProvider);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(949, 566);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnchangeDefaulProvider
            // 
            this.btnchangeDefaulProvider.Location = new System.Drawing.Point(70, 64);
            this.btnchangeDefaulProvider.Name = "btnchangeDefaulProvider";
            this.btnchangeDefaulProvider.Size = new System.Drawing.Size(328, 23);
            this.btnchangeDefaulProvider.TabIndex = 0;
            this.btnchangeDefaulProvider.Text = "Change Defaul Provider";
            this.btnchangeDefaulProvider.UseVisualStyleBackColor = true;
            this.btnchangeDefaulProvider.Click += new System.EventHandler(this.btnchangeDefaulProvider_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(98, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "DefaulProvider name";
            // 
            // txtDefaulProvider
            // 
            this.txtDefaulProvider.Location = new System.Drawing.Point(101, 152);
            this.txtDefaulProvider.Name = "txtDefaulProvider";
            this.txtDefaulProvider.Size = new System.Drawing.Size(213, 20);
            this.txtDefaulProvider.TabIndex = 18;
            // 
            // txtValueChangeDefaultProvider
            // 
            this.txtValueChangeDefaultProvider.Location = new System.Drawing.Point(143, 245);
            this.txtValueChangeDefaultProvider.Name = "txtValueChangeDefaultProvider";
            this.txtValueChangeDefaultProvider.Size = new System.Drawing.Size(213, 20);
            this.txtValueChangeDefaultProvider.TabIndex = 20;
            // 
            // frmConfigurationTest
            // 
            this.ClientSize = new System.Drawing.Size(958, 675);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmConfigurationTest";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnLoadConfigFile;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtConfigFileName;
        private System.Windows.Forms.TextBox xmlConfitFile;
        private System.Windows.Forms.DataGridView grdGroups;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn canUndoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn canRedoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource groupBindingSource;
        private System.Windows.Forms.Button btnGetGroupKeys;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn encryptedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn canUndoDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn canRedoDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.BindingSource keyBindingSource;
        private System.Windows.Forms.Button btnGetProvider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProrpetieName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnchangeDefaulProvider;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDefaulProvider;
        private System.Windows.Forms.TextBox txtValueChangeDefaultProvider;
    }
}

