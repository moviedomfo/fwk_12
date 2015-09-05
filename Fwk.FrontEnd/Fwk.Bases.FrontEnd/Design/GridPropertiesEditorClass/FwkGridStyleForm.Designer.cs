namespace Fwk.Bases.FrontEnd.Controls.FwkGrid.Design
{
    partial class FwkGridStyleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FwkGridStyleForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageRowsSetting = new System.Windows.Forms.TabPage();
            this.lblRowEditColor = new System.Windows.Forms.Label();
            this.lblRowEditedColor = new System.Windows.Forms.Label();
            this.chkMarckEditedRow = new System.Windows.Forms.CheckBox();
            this.chkHeaderVisible = new System.Windows.Forms.CheckBox();
            this.chkAllowReziseRows = new System.Windows.Forms.CheckBox();
            this.chkAllowDeleteRows = new System.Windows.Forms.CheckBox();
            this.chkAllowAddRows = new System.Windows.Forms.CheckBox();
            this.tabPageColumnsSetting = new System.Windows.Forms.TabPage();
            this.chkAllowResizeColumns = new System.Windows.Forms.CheckBox();
            this.chkAllowSortColumns = new System.Windows.Forms.CheckBox();
            this.btnColumnHeaders = new System.Windows.Forms.Button();
            this.tabPageCellsSetting = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clietCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbDefaultStyles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabControl1.SuspendLayout();
            this.tabPageRowsSetting.SuspendLayout();
            this.tabPageColumnsSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clietCollectionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageRowsSetting);
            this.tabControl1.Controls.Add(this.tabPageColumnsSetting);
            this.tabControl1.Controls.Add(this.tabPageCellsSetting);
            this.tabControl1.Font = new System.Drawing.Font("Lucida Bright", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(166, 268);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPageRowsSetting
            // 
            this.tabPageRowsSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageRowsSetting.Controls.Add(this.lblRowEditColor);
            this.tabPageRowsSetting.Controls.Add(this.lblRowEditedColor);
            this.tabPageRowsSetting.Controls.Add(this.chkMarckEditedRow);
            this.tabPageRowsSetting.Controls.Add(this.chkHeaderVisible);
            this.tabPageRowsSetting.Controls.Add(this.chkAllowReziseRows);
            this.tabPageRowsSetting.Controls.Add(this.chkAllowDeleteRows);
            this.tabPageRowsSetting.Controls.Add(this.chkAllowAddRows);
            this.tabPageRowsSetting.Location = new System.Drawing.Point(4, 23);
            this.tabPageRowsSetting.Name = "tabPageRowsSetting";
            this.tabPageRowsSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRowsSetting.Size = new System.Drawing.Size(158, 241);
            this.tabPageRowsSetting.TabIndex = 1;
            this.tabPageRowsSetting.Text = "Rows ";
            this.tabPageRowsSetting.UseVisualStyleBackColor = true;
            // 
            // lblEditColor
            // 
            this.lblRowEditColor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRowEditColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRowEditColor.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblRowEditColor.Location = new System.Drawing.Point(85, 161);
            this.lblRowEditColor.Name = "lblEditColor";
            this.lblRowEditColor.Size = new System.Drawing.Size(32, 14);
            this.lblRowEditColor.TabIndex = 8;
            this.lblRowEditColor.Click += new System.EventHandler(this.lblEditColor_Click);
            // 
            // lblRowEditedColor
            // 
            this.lblRowEditedColor.AutoSize = true;
            this.lblRowEditedColor.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblRowEditedColor.Location = new System.Drawing.Point(6, 161);
            this.lblRowEditedColor.Name = "lblRowEditedColor";
            this.lblRowEditedColor.Size = new System.Drawing.Size(73, 14);
            this.lblRowEditedColor.TabIndex = 7;
            this.lblRowEditedColor.Text = "Edited Color";
            // 
            // chkMarckEditedRow
            // 
            this.chkMarckEditedRow.AutoSize = true;
            this.chkMarckEditedRow.Location = new System.Drawing.Point(12, 130);
            this.chkMarckEditedRow.Name = "chkMarckEditedRow";
            this.chkMarckEditedRow.Size = new System.Drawing.Size(128, 18);
            this.chkMarckEditedRow.TabIndex = 6;
            this.chkMarckEditedRow.Text = "Marck Edited Rows";
            this.chkMarckEditedRow.UseVisualStyleBackColor = true;
            // 
            // chkHeaderVisible
            // 
            this.chkHeaderVisible.AutoSize = true;
            this.chkHeaderVisible.Location = new System.Drawing.Point(12, 86);
            this.chkHeaderVisible.Name = "chkHeaderVisible";
            this.chkHeaderVisible.Size = new System.Drawing.Size(105, 18);
            this.chkHeaderVisible.TabIndex = 5;
            this.chkHeaderVisible.Text = "Header Visible";
            this.chkHeaderVisible.UseVisualStyleBackColor = true;
            // 
            // chkAllowReziseRows
            // 
            this.chkAllowReziseRows.AutoSize = true;
            this.chkAllowReziseRows.Location = new System.Drawing.Point(12, 62);
            this.chkAllowReziseRows.Name = "chkAllowReziseRows";
            this.chkAllowReziseRows.Size = new System.Drawing.Size(97, 18);
            this.chkAllowReziseRows.TabIndex = 4;
            this.chkAllowReziseRows.Text = "Allow Rezise";
            this.chkAllowReziseRows.UseVisualStyleBackColor = true;
            // 
            // chkAllowDeleteRows
            // 
            this.chkAllowDeleteRows.AutoSize = true;
            this.chkAllowDeleteRows.Location = new System.Drawing.Point(12, 16);
            this.chkAllowDeleteRows.Name = "chkAllowDeleteRows";
            this.chkAllowDeleteRows.Size = new System.Drawing.Size(97, 18);
            this.chkAllowDeleteRows.TabIndex = 2;
            this.chkAllowDeleteRows.Text = "Allow Delete";
            this.chkAllowDeleteRows.UseVisualStyleBackColor = true;
            // 
            // chkAllowAddRows
            // 
            this.chkAllowAddRows.AutoSize = true;
            this.chkAllowAddRows.Location = new System.Drawing.Point(12, 39);
            this.chkAllowAddRows.Name = "chkAllowAddRows";
            this.chkAllowAddRows.Size = new System.Drawing.Size(83, 18);
            this.chkAllowAddRows.TabIndex = 3;
            this.chkAllowAddRows.Text = "Allow Add";
            this.chkAllowAddRows.UseVisualStyleBackColor = true;
            // 
            // tabPageColumnsSetting
            // 
            this.tabPageColumnsSetting.Controls.Add(this.chkAllowResizeColumns);
            this.tabPageColumnsSetting.Controls.Add(this.chkAllowSortColumns);
            this.tabPageColumnsSetting.Controls.Add(this.btnColumnHeaders);
            this.tabPageColumnsSetting.Location = new System.Drawing.Point(4, 23);
            this.tabPageColumnsSetting.Name = "tabPageColumnsSetting";
            this.tabPageColumnsSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageColumnsSetting.Size = new System.Drawing.Size(158, 241);
            this.tabPageColumnsSetting.TabIndex = 2;
            this.tabPageColumnsSetting.Text = "Colums";
            this.tabPageColumnsSetting.UseVisualStyleBackColor = true;
            // 
            // chkAllowResizeColumns
            // 
            this.chkAllowResizeColumns.AutoSize = true;
            this.chkAllowResizeColumns.Location = new System.Drawing.Point(11, 41);
            this.chkAllowResizeColumns.Name = "chkAllowResizeColumns";
            this.chkAllowResizeColumns.Size = new System.Drawing.Size(97, 18);
            this.chkAllowResizeColumns.TabIndex = 5;
            this.chkAllowResizeColumns.Text = "Allow Resize";
            this.chkAllowResizeColumns.UseVisualStyleBackColor = true;
            // 
            // chkAllowSortColumns
            // 
            this.chkAllowSortColumns.AutoSize = true;
            this.chkAllowSortColumns.Location = new System.Drawing.Point(11, 65);
            this.chkAllowSortColumns.Name = "chkAllowSortColumns";
            this.chkAllowSortColumns.Size = new System.Drawing.Size(81, 18);
            this.chkAllowSortColumns.TabIndex = 6;
            this.chkAllowSortColumns.Text = "Allow Sort";
            this.chkAllowSortColumns.UseVisualStyleBackColor = true;
            // 
            // btnColumnHeaders
            // 
            this.btnColumnHeaders.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnColumnHeaders.ForeColor = System.Drawing.Color.Coral;
            this.btnColumnHeaders.Location = new System.Drawing.Point(11, 6);
            this.btnColumnHeaders.Name = "btnColumnHeaders";
            this.btnColumnHeaders.Size = new System.Drawing.Size(28, 18);
            this.btnColumnHeaders.TabIndex = 1;
            this.btnColumnHeaders.UseVisualStyleBackColor = false;
            // 
            // tabPageCellsSetting
            // 
            this.tabPageCellsSetting.Location = new System.Drawing.Point(4, 23);
            this.tabPageCellsSetting.Name = "tabPageCellsSetting";
            this.tabPageCellsSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCellsSetting.Size = new System.Drawing.Size(158, 241);
            this.tabPageCellsSetting.TabIndex = 3;
            this.tabPageCellsSetting.Text = "Cells ";
            this.tabPageCellsSetting.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idClienteDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.apellidoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.clietCollectionBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(205, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(350, 126);
            this.dataGridView1.TabIndex = 6;
            // 
            // idClienteDataGridViewTextBoxColumn
            // 
            this.idClienteDataGridViewTextBoxColumn.DataPropertyName = "IdCliente";
            this.idClienteDataGridViewTextBoxColumn.HeaderText = "IdCliente";
            this.idClienteDataGridViewTextBoxColumn.Name = "idClienteDataGridViewTextBoxColumn";
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            // 
            // apellidoDataGridViewTextBoxColumn
            // 
            this.apellidoDataGridViewTextBoxColumn.DataPropertyName = "Apellido";
            this.apellidoDataGridViewTextBoxColumn.HeaderText = "Apellido";
            this.apellidoDataGridViewTextBoxColumn.Name = "apellidoDataGridViewTextBoxColumn";
            // 
            // clietCollectionBindingSource
            // 
            this.clietCollectionBindingSource.DataSource = typeof(Fwk.Bases.FrontEnd.Controls.FwkGrid.Design.ClienteCollection);
            // 
            // cmbDefaultStyles
            // 
            this.cmbDefaultStyles.FormattingEnabled = true;
            this.cmbDefaultStyles.Items.AddRange(new object[] {
            "MaroonFlat",
            "GreenFlat",
            "LightBlueFlat "});
            this.cmbDefaultStyles.Location = new System.Drawing.Point(287, 8);
            this.cmbDefaultStyles.Name = "cmbDefaultStyles";
            this.cmbDefaultStyles.Size = new System.Drawing.Size(198, 21);
            this.cmbDefaultStyles.TabIndex = 22;
            this.cmbDefaultStyles.SelectedIndexChanged += new System.EventHandler(this.cmbDefaultStyles_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Default styles";
            // 
            // colorDialog1
            // 
            this.colorDialog1.Color = System.Drawing.Color.Maroon;
            // 
            // FwkGridStyleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(594, 368);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDefaultStyles);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.Color.OliveDrab;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FwkGridStyleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Style grid settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StyleForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPageRowsSetting.ResumeLayout(false);
            this.tabPageRowsSetting.PerformLayout();
            this.tabPageColumnsSetting.ResumeLayout(false);
            this.tabPageColumnsSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clietCollectionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageRowsSetting;
        private System.Windows.Forms.CheckBox chkAllowReziseRows;
        private System.Windows.Forms.CheckBox chkAllowDeleteRows;
        private System.Windows.Forms.CheckBox chkAllowAddRows;
        private System.Windows.Forms.TabPage tabPageColumnsSetting;
        private System.Windows.Forms.CheckBox chkAllowResizeColumns;
        private System.Windows.Forms.CheckBox chkAllowSortColumns;
        private System.Windows.Forms.Button btnColumnHeaders;
        private System.Windows.Forms.TabPage tabPageCellsSetting;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource clietCollectionBindingSource;
        private System.Windows.Forms.ComboBox cmbDefaultStyles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkHeaderVisible;
        private System.Windows.Forms.CheckBox chkMarckEditedRow;
        private System.Windows.Forms.Label lblRowEditColor;
        private System.Windows.Forms.Label lblRowEditedColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}