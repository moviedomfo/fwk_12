namespace Fwk.Bases.FrontEnd.Controls.Test
{
    partial class Form2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAddFacturas = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnGetEntiyt = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.clietnteBECollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddObject = new System.Windows.Forms.Button();
            this.cmbObject = new Fwk.Bases.FrontEnd.Controls.FwkFlatComboBox();
            this.fwkFlatComboBox1 = new Fwk.Bases.FrontEnd.Controls.FwkFlatComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.fwkAutoComboBox1 = new Fwk.Bases.FrontEnd.Controls.FwkAutoComboBox();
            this.fwkFlatComboBox_Clientes = new Fwk.Bases.FrontEnd.Controls.FwkFlatComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.btnAddToCombo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.fwkGenericDataGridView_Combo = new Fwk.Bases.FrontEnd.Controls.FwkGrid.FwkGenericDataGridView(this.components);
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdTipoCliente = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.fwkMessageViewComponent1 = new Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent(this.components);
            this.fwkExceptionViewComponent2 = new Fwk.Bases.FrontEnd.Controls.FwkExceptionViewComponent(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.clietnteBECollectionBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fwkGenericDataGridView_Combo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddFacturas
            // 
            this.btnAddFacturas.Location = new System.Drawing.Point(6, 23);
            this.btnAddFacturas.Name = "btnAddFacturas";
            this.btnAddFacturas.Size = new System.Drawing.Size(97, 23);
            this.btnAddFacturas.TabIndex = 2;
            this.btnAddFacturas.Text = "Add Entities";
            this.btnAddFacturas.UseVisualStyleBackColor = true;
            this.btnAddFacturas.Click += new System.EventHandler(this.btnAddFacturas_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 159);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(640, 218);
            this.textBox1.TabIndex = 3;
            // 
            // btnGetEntiyt
            // 
            this.btnGetEntiyt.Location = new System.Drawing.Point(6, 83);
            this.btnGetEntiyt.Name = "btnGetEntiyt";
            this.btnGetEntiyt.Size = new System.Drawing.Size(97, 23);
            this.btnGetEntiyt.TabIndex = 5;
            this.btnGetEntiyt.Text = "Get Entiyt";
            this.btnGetEntiyt.UseVisualStyleBackColor = true;
            this.btnGetEntiyt.Click += new System.EventHandler(this.btnGetEntiyt_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clietnteBECollectionBindingSource, "Apellido", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.maskedTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.clietnteBECollectionBindingSource, "IdCliente", true));
            this.maskedTextBox1.Location = new System.Drawing.Point(153, 104);
            this.maskedTextBox1.Mask = "[Name]";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(189, 20);
            this.maskedTextBox1.TabIndex = 6;
            this.maskedTextBox1.Text = "a";
            // 
            // clietnteBECollectionBindingSource
            // 
            this.clietnteBECollectionBindingSource.DataSource = typeof(Fwk.Bases.FrontEnd.Controls.Test.ClienteBECollection);
            // 
            // btnAddObject
            // 
            this.btnAddObject.Location = new System.Drawing.Point(44, 29);
            this.btnAddObject.Name = "btnAddObject";
            this.btnAddObject.Size = new System.Drawing.Size(97, 23);
            this.btnAddObject.TabIndex = 9;
            this.btnAddObject.Text = "Add Entities";
            this.btnAddObject.UseVisualStyleBackColor = true;
            this.btnAddObject.Click += new System.EventHandler(this.btnAddObject_Click);
            // 
            // cmbObject
            // 
            this.cmbObject.ActiveArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(142)))));
            this.cmbObject.ActiveBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.cmbObject.ActiveButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.cmbObject.AllowEmptyTextValue = false;
            this.cmbObject.AutoComplete = true;
            this.cmbObject.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbObject.ErrorIconRightToLeft = false;
            this.cmbObject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbObject.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbObject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.cmbObject.FormattingEnabled = true;
            this.cmbObject.InactiveArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cmbObject.InactiveBorderColor = System.Drawing.Color.White;
            this.cmbObject.InactiveButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cmbObject.Location = new System.Drawing.Point(75, 6);
            this.cmbObject.Name = "cmbObject";
            this.cmbObject.NullTextValue = null;
            this.cmbObject.ReadOnly = false;
            this.cmbObject.ReadOnlyColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbObject.Required = false;
            this.cmbObject.RequiredErrorText = null;
            this.cmbObject.Size = new System.Drawing.Size(409, 21);
            this.cmbObject.TabIndex = 8;
            // 
            // fwkFlatComboBox1
            // 
            this.fwkFlatComboBox1.ActiveArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(142)))));
            this.fwkFlatComboBox1.ActiveBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.fwkFlatComboBox1.ActiveButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.fwkFlatComboBox1.AllowEmptyTextValue = true;
            this.fwkFlatComboBox1.AutoComplete = true;
            this.fwkFlatComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.fwkFlatComboBox1.ErrorIconRightToLeft = false;
            this.fwkFlatComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fwkFlatComboBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fwkFlatComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.fwkFlatComboBox1.FormattingEnabled = true;
            this.fwkFlatComboBox1.InactiveArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fwkFlatComboBox1.InactiveBorderColor = System.Drawing.Color.Maroon;
            this.fwkFlatComboBox1.InactiveButtonColor = System.Drawing.Color.SlateGray;
            this.fwkFlatComboBox1.Location = new System.Drawing.Point(153, 23);
            this.fwkFlatComboBox1.Name = "fwkFlatComboBox1";
            this.fwkFlatComboBox1.NullTextValue = "seleccione una opcion";
            this.fwkFlatComboBox1.ReadOnly = false;
            this.fwkFlatComboBox1.ReadOnlyColor = System.Drawing.Color.WhiteSmoke;
            this.fwkFlatComboBox1.Required = true;
            this.fwkFlatComboBox1.RequiredErrorText = "falta el dato";
            this.fwkFlatComboBox1.Size = new System.Drawing.Size(409, 21);
            this.fwkFlatComboBox1.TabIndex = 4;
            this.fwkFlatComboBox1.SelectedIndexChanged += new System.EventHandler(this.fwkFlatComboBox1_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 412);
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.fwkFlatComboBox1);
            this.tabPage1.Controls.Add(this.maskedTextBox1);
            this.tabPage1.Controls.Add(this.btnGetEntiyt);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.btnAddFacturas);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(652, 386);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Grilla";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 125);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Get Entities";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAddObject);
            this.tabPage2.Controls.Add(this.fwkAutoComboBox1);
            this.tabPage2.Controls.Add(this.cmbObject);
            this.tabPage2.Controls.Add(this.fwkFlatComboBox_Clientes);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(652, 386);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // fwkAutoComboBox1
            // 
            this.fwkAutoComboBox1.ActiveArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(142)))));
            this.fwkAutoComboBox1.ActiveBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.fwkAutoComboBox1.ActiveButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.fwkAutoComboBox1.AllowEmptyTextValue = false;
            this.fwkAutoComboBox1.AutoComplete = true;
            this.fwkAutoComboBox1.DataSource = this.clietnteBECollectionBindingSource;
            this.fwkAutoComboBox1.DisplayMember = "Nombre";
            this.fwkAutoComboBox1.ErrorIconRightToLeft = false;
            this.fwkAutoComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fwkAutoComboBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fwkAutoComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.fwkAutoComboBox1.FormattingEnabled = true;
            this.fwkAutoComboBox1.InactiveArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.fwkAutoComboBox1.InactiveBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.fwkAutoComboBox1.InactiveButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.fwkAutoComboBox1.Location = new System.Drawing.Point(355, 56);
            this.fwkAutoComboBox1.Name = "fwkAutoComboBox1";
            this.fwkAutoComboBox1.NullTextValue = null;
            this.fwkAutoComboBox1.ReadOnly = false;
            this.fwkAutoComboBox1.ReadOnlyColor = System.Drawing.SystemColors.Control;
            this.fwkAutoComboBox1.Required = false;
            this.fwkAutoComboBox1.RequiredErrorText = null;
            this.fwkAutoComboBox1.Size = new System.Drawing.Size(186, 21);
            this.fwkAutoComboBox1.TabIndex = 4;
            this.fwkAutoComboBox1.ValueMember = "Apellido";
            // 
            // fwkFlatComboBox_Clientes
            // 
            this.fwkFlatComboBox_Clientes.ActiveArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(142)))));
            this.fwkFlatComboBox_Clientes.ActiveBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.fwkFlatComboBox_Clientes.ActiveButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.fwkFlatComboBox_Clientes.AllowEmptyTextValue = false;
            this.fwkFlatComboBox_Clientes.AutoComplete = true;
            this.fwkFlatComboBox_Clientes.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.clietnteBECollectionBindingSource, "Apellido", true));
            this.fwkFlatComboBox_Clientes.ErrorIconRightToLeft = false;
            this.fwkFlatComboBox_Clientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fwkFlatComboBox_Clientes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fwkFlatComboBox_Clientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.fwkFlatComboBox_Clientes.FormattingEnabled = true;
            this.fwkFlatComboBox_Clientes.InactiveArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.fwkFlatComboBox_Clientes.InactiveBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.fwkFlatComboBox_Clientes.InactiveButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.fwkFlatComboBox_Clientes.Location = new System.Drawing.Point(355, 29);
            this.fwkFlatComboBox_Clientes.Name = "fwkFlatComboBox_Clientes";
            this.fwkFlatComboBox_Clientes.NullTextValue = null;
            this.fwkFlatComboBox_Clientes.ReadOnly = false;
            this.fwkFlatComboBox_Clientes.ReadOnlyColor = System.Drawing.SystemColors.Control;
            this.fwkFlatComboBox_Clientes.Required = false;
            this.fwkFlatComboBox_Clientes.RequiredErrorText = null;
            this.fwkFlatComboBox_Clientes.Size = new System.Drawing.Size(186, 21);
            this.fwkFlatComboBox_Clientes.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.btnAddToCombo);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.txtCliente);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.fwkGenericDataGridView_Combo);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(652, 386);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(284, 295);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(158, 23);
            this.button3.TabIndex = 27;
            this.button3.Text = "Add Element to combo";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnAddToCombo
            // 
            this.btnAddToCombo.Location = new System.Drawing.Point(262, 17);
            this.btnAddToCombo.Name = "btnAddToCombo";
            this.btnAddToCombo.Size = new System.Drawing.Size(158, 23);
            this.btnAddToCombo.TabIndex = 26;
            this.btnAddToCombo.Text = "Add Element to combo";
            this.btnAddToCombo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Cliente Seleccionado";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(15, 258);
            this.txtCliente.Multiline = true;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(248, 130);
            this.txtCliente.TabIndex = 24;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(28, 17);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(97, 23);
            this.button5.TabIndex = 21;
            this.button5.Text = "Add Entities";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // fwkGenericDataGridView_Combo
            // 
            this.fwkGenericDataGridView_Combo.AllowUserToAddRows = false;
            this.fwkGenericDataGridView_Combo.AllowUserToDeleteRows = false;
            this.fwkGenericDataGridView_Combo.AllowUserToOrderColumns = true;
            this.fwkGenericDataGridView_Combo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.fwkGenericDataGridView_Combo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.fwkGenericDataGridView_Combo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fwkGenericDataGridView_Combo.AutoGenerateColumns = false;
            this.fwkGenericDataGridView_Combo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(249)))), ((int)(((byte)(234)))));
            this.fwkGenericDataGridView_Combo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.fwkGenericDataGridView_Combo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.fwkGenericDataGridView_Combo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fwkGenericDataGridView_Combo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.IdTipoCliente});
            this.fwkGenericDataGridView_Combo.CustomGridProperties.AllowAddRows = false;
            this.fwkGenericDataGridView_Combo.CustomGridProperties.AllowDeleteRows = false;
            this.fwkGenericDataGridView_Combo.CustomGridProperties.AllowOrderColumns = true;
            this.fwkGenericDataGridView_Combo.CustomGridProperties.AllowResizeColumns = true;
            this.fwkGenericDataGridView_Combo.CustomGridProperties.AllowResizeRows = false;
            this.fwkGenericDataGridView_Combo.CustomGridProperties.MarckEditedRow = false;
            this.fwkGenericDataGridView_Combo.CustomGridProperties.RowEditedColor = System.Drawing.Color.Empty;
            this.fwkGenericDataGridView_Combo.CustomGridProperties.RowErrorColor = System.Drawing.Color.Empty;
            this.fwkGenericDataGridView_Combo.CustomGridProperties.RowHeaderVisible = false;
            this.fwkGenericDataGridView_Combo.DataSource = this.clietnteBECollectionBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.fwkGenericDataGridView_Combo.DefaultCellStyle = dataGridViewCellStyle3;
            this.fwkGenericDataGridView_Combo.EnableHeadersVisualStyles = false;
            this.fwkGenericDataGridView_Combo.GridColor = System.Drawing.Color.White;
            this.fwkGenericDataGridView_Combo.Location = new System.Drawing.Point(15, 46);
            this.fwkGenericDataGridView_Combo.MultiSelect = false;
            this.fwkGenericDataGridView_Combo.Name = "fwkGenericDataGridView_Combo";
            this.fwkGenericDataGridView_Combo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.fwkGenericDataGridView_Combo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.fwkGenericDataGridView_Combo.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fwkGenericDataGridView_Combo.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.fwkGenericDataGridView_Combo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fwkGenericDataGridView_Combo.Size = new System.Drawing.Size(587, 192);
            this.fwkGenericDataGridView_Combo.TabIndex = 20;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "IdCliente";
            this.dataGridViewTextBoxColumn5.HeaderText = "IdCliente";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn6.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // IdTipoCliente
            // 
            this.IdTipoCliente.DataPropertyName = "IdTipoCliente";
            this.IdTipoCliente.HeaderText = "TipoCliente";
            this.IdTipoCliente.Name = "IdTipoCliente";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 439);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(146, 33);
            this.button4.TabIndex = 25;
            this.button4.Text = "Message Viewer ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(371, 461);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 33);
            this.button1.TabIndex = 26;
            this.button1.Text = "Message Exeption";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fwkMessageViewComponent1
            // 
            this.fwkMessageViewComponent1.BackColor = System.Drawing.Color.White;
            this.fwkMessageViewComponent1.IconSize = Fwk.Bases.FrontEnd.Controls.IconSize.Large;
            this.fwkMessageViewComponent1.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.fwkMessageViewComponent1.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Information;
            this.fwkMessageViewComponent1.TextMessageColor = System.Drawing.Color.White;
            this.fwkMessageViewComponent1.TextMessageForeColor = System.Drawing.Color.Black;
            this.fwkMessageViewComponent1.Title = "Message";
            // 
            // fwkExceptionViewComponent2
            // 
            this.fwkExceptionViewComponent2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fwkExceptionViewComponent2.TextMessageColor = System.Drawing.Color.White;
            this.fwkExceptionViewComponent2.TextMessageForeColorColor = System.Drawing.SystemColors.WindowText;
            this.fwkExceptionViewComponent2.Title = "FrmTechnicalMsg";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 556);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.clietnteBECollectionBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fwkGenericDataGridView_Combo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddFacturas;
        private System.Windows.Forms.TextBox textBox1;
        private FwkFlatComboBox fwkFlatComboBox1;
        private System.Windows.Forms.Button btnGetEntiyt;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.BindingSource clietnteBECollectionBindingSource;
        private FwkFlatComboBox cmbObject;
        private System.Windows.Forms.Button btnAddObject;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button4;
        private FwkAutoComboBox fwkAutoComboBox1;
        private FwkFlatComboBox fwkFlatComboBox_Clientes;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnAddToCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button button5;
        private Fwk.Bases.FrontEnd.Controls.FwkGrid.FwkGenericDataGridView fwkGenericDataGridView_Combo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewComboBoxColumn IdTipoCliente;
        private System.Windows.Forms.Button button1;
        private FwkMessageViewComponent fwkMessageViewComponent1;
        private FwkExceptionViewComponent fwkExceptionViewComponent2;





    }
}