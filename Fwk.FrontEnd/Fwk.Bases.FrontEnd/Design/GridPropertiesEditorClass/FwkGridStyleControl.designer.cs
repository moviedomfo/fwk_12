

namespace Fwk.Bases.FrontEnd.Controls.FwkGrid.Design
{
   partial  class FwkGridStyleControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this._AlternatingRowsDefaultCellStyle = new Fwk.Bases.FrontEnd.Controls.FwkGrid.Design.FwkDataGridViewCellStyle(this.components);
            this._ColumnHeadersDefaultCellStyle = new Fwk.Bases.FrontEnd.Controls.FwkGrid.Design.FwkDataGridViewCellStyle(this.components);
            this._DefaultCellStyle = new Fwk.Bases.FrontEnd.Controls.FwkGrid.Design.FwkDataGridViewCellStyle(this.components);
            this._RowHeadersDefaultCellStyle = new Fwk.Bases.FrontEnd.Controls.FwkGrid.Design.FwkDataGridViewCellStyle(this.components);
            this._RowsDefaultCellStyle = new Fwk.Bases.FrontEnd.Controls.FwkGrid.Design.FwkDataGridViewCellStyle(this.components);
            this.btnRowHeader = new System.Windows.Forms.Button();
            this.btnColumnHeaders = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.chkAllowDeleteRows = new System.Windows.Forms.CheckBox();
            this.chkAllowAddRows = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageRowsSetting = new System.Windows.Forms.TabPage();
            this.chkAllowReziseRows = new System.Windows.Forms.CheckBox();
            this.tabPageColumnsSetting = new System.Windows.Forms.TabPage();
            this.chkAllowResizeColumns = new System.Windows.Forms.CheckBox();
            this.chkAllowSortColumns = new System.Windows.Forms.CheckBox();
            this.tabPageCellsSetting = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPageRowsSetting.SuspendLayout();
            this.tabPageColumnsSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // _AlternatingRowsDefaultCellStyle
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this._AlternatingRowsDefaultCellStyle.DataGridViewCellStyle = dataGridViewCellStyle1;
            // 
            // _ColumnHeadersDefaultCellStyle
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this._ColumnHeadersDefaultCellStyle.DataGridViewCellStyle = dataGridViewCellStyle2;
            // 
            // _DefaultCellStyle
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Gray;
            this._DefaultCellStyle.DataGridViewCellStyle = dataGridViewCellStyle3;
            // 
            // _RowHeadersDefaultCellStyle
            // 
            this._RowHeadersDefaultCellStyle.DataGridViewCellStyle = dataGridViewCellStyle4;
            // 
            // _RowsDefaultCellStyle
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this._RowsDefaultCellStyle.DataGridViewCellStyle = dataGridViewCellStyle5;
            // 
            // btnRowHeader
            // 
            this.btnRowHeader.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRowHeader.ForeColor = System.Drawing.Color.Coral;
            this.btnRowHeader.Location = new System.Drawing.Point(12, 6);
            this.btnRowHeader.Name = "btnRowHeader";
            this.btnRowHeader.Size = new System.Drawing.Size(69, 26);
            this.btnRowHeader.TabIndex = 0;
            this.btnRowHeader.UseVisualStyleBackColor = false;
            this.btnRowHeader.Click += new System.EventHandler(this.btnRowHeader_Click);
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
            this.btnColumnHeaders.Click += new System.EventHandler(this.btnColumnHeaders_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.Color = System.Drawing.Color.Maroon;
            // 
            // chkAllowDeleteRows
            // 
            this.chkAllowDeleteRows.AutoSize = true;
            this.chkAllowDeleteRows.Location = new System.Drawing.Point(12, 61);
            this.chkAllowDeleteRows.Name = "chkAllowDeleteRows";
            this.chkAllowDeleteRows.Size = new System.Drawing.Size(97, 18);
            this.chkAllowDeleteRows.TabIndex = 2;
            this.chkAllowDeleteRows.Text = "Allow Delete";
            this.chkAllowDeleteRows.UseVisualStyleBackColor = true;
            this.chkAllowDeleteRows.CheckedChanged += new System.EventHandler(this.chlAllowDeleteRows_CheckedChanged);
            // 
            // chkAllowAddRows
            // 
            this.chkAllowAddRows.AutoSize = true;
            this.chkAllowAddRows.Location = new System.Drawing.Point(12, 84);
            this.chkAllowAddRows.Name = "chkAllowAddRows";
            this.chkAllowAddRows.Size = new System.Drawing.Size(83, 18);
            this.chkAllowAddRows.TabIndex = 3;
            this.chkAllowAddRows.Text = "Allow Add";
            this.chkAllowAddRows.UseVisualStyleBackColor = true;
            this.chkAllowAddRows.CheckedChanged += new System.EventHandler(this.chkAllowAddRows_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageRowsSetting);
            this.tabControl1.Controls.Add(this.tabPageColumnsSetting);
            this.tabControl1.Controls.Add(this.tabPageCellsSetting);
            this.tabControl1.Font = new System.Drawing.Font("Lucida Bright", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(306, 239);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPageRowsSetting
            // 
            this.tabPageRowsSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageRowsSetting.Controls.Add(this.chkAllowReziseRows);
            this.tabPageRowsSetting.Controls.Add(this.chkAllowDeleteRows);
            this.tabPageRowsSetting.Controls.Add(this.chkAllowAddRows);
            this.tabPageRowsSetting.Controls.Add(this.btnRowHeader);
            this.tabPageRowsSetting.Location = new System.Drawing.Point(4, 23);
            this.tabPageRowsSetting.Name = "tabPageRowsSetting";
            this.tabPageRowsSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRowsSetting.Size = new System.Drawing.Size(298, 212);
            this.tabPageRowsSetting.TabIndex = 1;
            this.tabPageRowsSetting.Text = "Rows ";
            this.tabPageRowsSetting.UseVisualStyleBackColor = true;
            // 
            // chkAllowReziseRows
            // 
            this.chkAllowReziseRows.AutoSize = true;
            this.chkAllowReziseRows.Location = new System.Drawing.Point(12, 107);
            this.chkAllowReziseRows.Name = "chkAllowReziseRows";
            this.chkAllowReziseRows.Size = new System.Drawing.Size(97, 18);
            this.chkAllowReziseRows.TabIndex = 4;
            this.chkAllowReziseRows.Text = "Allow Rezise";
            this.chkAllowReziseRows.UseVisualStyleBackColor = true;
            this.chkAllowReziseRows.CheckedChanged += new System.EventHandler(this.chkAllowReziseRows_CheckedChanged);
            // 
            // tabPageColumnsSetting
            // 
            this.tabPageColumnsSetting.Controls.Add(this.chkAllowResizeColumns);
            this.tabPageColumnsSetting.Controls.Add(this.chkAllowSortColumns);
            this.tabPageColumnsSetting.Controls.Add(this.btnColumnHeaders);
            this.tabPageColumnsSetting.Location = new System.Drawing.Point(4, 23);
            this.tabPageColumnsSetting.Name = "tabPageColumnsSetting";
            this.tabPageColumnsSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageColumnsSetting.Size = new System.Drawing.Size(298, 143);
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
            this.chkAllowResizeColumns.CheckedChanged += new System.EventHandler(this.chkAllowResizeColumns_CheckedChanged);
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
            this.chkAllowSortColumns.CheckedChanged += new System.EventHandler(this.chkAllowSortColumns_CheckedChanged);
            // 
            // tabPageCellsSetting
            // 
            this.tabPageCellsSetting.Location = new System.Drawing.Point(4, 23);
            this.tabPageCellsSetting.Name = "tabPageCellsSetting";
            this.tabPageCellsSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCellsSetting.Size = new System.Drawing.Size(298, 143);
            this.tabPageCellsSetting.TabIndex = 3;
            this.tabPageCellsSetting.Text = "Cells ";
            this.tabPageCellsSetting.UseVisualStyleBackColor = true;
            // 
            // FwkGridStyleControl
            // 
            this.Controls.Add(this.tabControl1);
            this.Name = "FwkGridStyleControl";
            this.Size = new System.Drawing.Size(312, 314);
            this.tabControl1.ResumeLayout(false);
            this.tabPageRowsSetting.ResumeLayout(false);
            this.tabPageRowsSetting.PerformLayout();
            this.tabPageColumnsSetting.ResumeLayout(false);
            this.tabPageColumnsSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FwkDataGridViewCellStyle _ColumnHeadersDefaultCellStyle;
        private FwkDataGridViewCellStyle _AlternatingRowsDefaultCellStyle;
        private FwkDataGridViewCellStyle _DefaultCellStyle;
        private FwkDataGridViewCellStyle _RowHeadersDefaultCellStyle;
        private FwkDataGridViewCellStyle _RowsDefaultCellStyle;
       private System.Windows.Forms.Button btnRowHeader;
       private System.Windows.Forms.Button btnColumnHeaders;
       private System.Windows.Forms.ColorDialog colorDialog1;
       private System.Windows.Forms.CheckBox chkAllowDeleteRows;
       private System.Windows.Forms.CheckBox chkAllowAddRows;
       private System.Windows.Forms.TabControl tabControl1;
       private System.Windows.Forms.TabPage tabPageRowsSetting;
       private System.Windows.Forms.CheckBox chkAllowReziseRows;
       private System.Windows.Forms.TabPage tabPageColumnsSetting;
       private System.Windows.Forms.CheckBox chkAllowResizeColumns;
       private System.Windows.Forms.CheckBox chkAllowSortColumns;
       private System.Windows.Forms.TabPage tabPageCellsSetting;

    }
}
