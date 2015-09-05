namespace ConfigurationApp
{
    /// <summary>
    /// 
    /// </summary>
    partial class UCBServiceGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCBServiceGrid));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.fwkCellStyleGreenFlat1 = new Fwk.Bases.FrontEnd.Controls.FwkGrid.Design.FwkCellStyleGreenFlat(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFilter = new System.Windows.Forms.ToolStripButton();
            this.txtXmlFilePath = new System.Windows.Forms.ToolStripTextBox();
            this.fwkCellStyleMarronFlat1 = new Fwk.Bases.FrontEnd.Controls.FwkGrid.Design.FwkCellStyleMarronFlat(this.components);
            this.grdServices = new Fwk.Bases.FrontEnd.Controls.FwkGrid.FwkGenericDataGridView(this.components);
            this.fwkMessageViewComponent1 = new Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent(this.components);
            this.fwkConfigMannagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.configurationFileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.encryptedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdServices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fwkConfigMannagerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFilter,
            this.txtXmlFilePath});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(659, 25);
            this.toolStrip1.TabIndex = 38;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.Transparent;
            this.btnFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.Image")));
            this.btnFilter.ImageTransparentColor = System.Drawing.Color.Gainsboro;
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(51, 22);
            this.btnFilter.Text = "Filter";
            this.btnFilter.ToolTipText = "Filter ";
            this.btnFilter.Click += new System.EventHandler(this.toolStripButtonFilter_Click);
            // 
            // txtXmlFilePath
            // 
            this.txtXmlFilePath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtXmlFilePath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtXmlFilePath.Name = "txtXmlFilePath";
            this.txtXmlFilePath.Size = new System.Drawing.Size(200, 25);
            this.txtXmlFilePath.ToolTipText = "Name of service";
            this.txtXmlFilePath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtXmlFilePath_KeyDown);
            // 
            // grdServices
            // 
            this.grdServices.AllowUserToDeleteRows = false;
            this.grdServices.AllowUserToOrderColumns = true;
            this.grdServices.AllowUserToResizeColumns = false;
            this.grdServices.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.grdServices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdServices.AutoGenerateColumns = false;
            this.grdServices.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(249)))), ((int)(((byte)(234)))));
            this.grdServices.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Sienna;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Sienna;
            this.grdServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.configurationFileNameDataGridViewTextBoxColumn,
            this.groupDataGridViewTextBoxColumn,
            this.keyDataGridViewTextBoxColumn,
            this.encryptedDataGridViewCheckBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.grdServices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.grdServices.CustomGridProperties.AllowAddRows = true;
            this.grdServices.CustomGridProperties.AllowDeleteRows = false;
            this.grdServices.CustomGridProperties.AllowOrderColumns = true;
            this.grdServices.CustomGridProperties.AllowResizeColumns = false;
            this.grdServices.CustomGridProperties.AllowResizeRows = false;
            this.grdServices.CustomGridProperties.MarckEditedRow = false;
            this.grdServices.CustomGridProperties.RowEditedColor = System.Drawing.Color.Salmon;
            this.grdServices.CustomGridProperties.RowErrorColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdServices.CustomGridProperties.RowHeaderVisible = false;
            this.grdServices.DataSource = this.fwkConfigMannagerBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdServices.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdServices.EnableHeadersVisualStyles = false;
            this.grdServices.GridColor = System.Drawing.Color.White;
            this.grdServices.Location = new System.Drawing.Point(2, 28);
            this.grdServices.MultiSelect = false;
            this.grdServices.Name = "grdServices";
            this.grdServices.ReadOnly = true;
            this.grdServices.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdServices.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdServices.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grdServices.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdServices.Size = new System.Drawing.Size(643, 241);
            this.grdServices.TabIndex = 39;
            // 
            // fwkMessageViewComponent1
            // 
            this.fwkMessageViewComponent1.BackColor = System.Drawing.Color.White;
            this.fwkMessageViewComponent1.IconSize = Fwk.Bases.FrontEnd.Controls.IconSize.Small;
            this.fwkMessageViewComponent1.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.fwkMessageViewComponent1.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Information;
            this.fwkMessageViewComponent1.TextMessageColor = System.Drawing.Color.White;
            this.fwkMessageViewComponent1.TextMessageForeColor = System.Drawing.Color.Black;
            this.fwkMessageViewComponent1.Title = "Message";
            // 
            // fwkConfigMannagerBindingSource
            // 
            this.fwkConfigMannagerBindingSource.DataSource = typeof(Fwk.ConfigData.fwk_ConfigManager);
            // 
            // configurationFileNameDataGridViewTextBoxColumn
            // 
            this.configurationFileNameDataGridViewTextBoxColumn.DataPropertyName = "ConfigurationFileName";
            this.configurationFileNameDataGridViewTextBoxColumn.HeaderText = "ConfigurationFileName";
            this.configurationFileNameDataGridViewTextBoxColumn.Name = "configurationFileNameDataGridViewTextBoxColumn";
            this.configurationFileNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // groupDataGridViewTextBoxColumn
            // 
            this.groupDataGridViewTextBoxColumn.DataPropertyName = "group";
            this.groupDataGridViewTextBoxColumn.HeaderText = "group";
            this.groupDataGridViewTextBoxColumn.Name = "groupDataGridViewTextBoxColumn";
            this.groupDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // keyDataGridViewTextBoxColumn
            // 
            this.keyDataGridViewTextBoxColumn.DataPropertyName = "key";
            this.keyDataGridViewTextBoxColumn.HeaderText = "key";
            this.keyDataGridViewTextBoxColumn.Name = "keyDataGridViewTextBoxColumn";
            this.keyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // encryptedDataGridViewCheckBoxColumn
            // 
            this.encryptedDataGridViewCheckBoxColumn.DataPropertyName = "encrypted";
            this.encryptedDataGridViewCheckBoxColumn.HeaderText = "encrypted";
            this.encryptedDataGridViewCheckBoxColumn.Name = "encryptedDataGridViewCheckBoxColumn";
            this.encryptedDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // UCBServiceGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdServices);
            this.Controls.Add(this.toolStrip1);
            this.Name = "UCBServiceGrid";
            this.Size = new System.Drawing.Size(659, 272);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdServices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fwkConfigMannagerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox txtXmlFilePath;
        private System.Windows.Forms.ToolStripButton btnFilter;
        private Fwk.Bases.FrontEnd.Controls.FwkGrid.Design.FwkCellStyleGreenFlat fwkCellStyleGreenFlat1;
        private Fwk.Bases.FrontEnd.Controls.FwkGrid.Design.FwkCellStyleMarronFlat fwkCellStyleMarronFlat1;
        private Fwk.Bases.FrontEnd.Controls.FwkGrid.FwkGenericDataGridView grdServices;
        private Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent fwkMessageViewComponent1;
        private System.Windows.Forms.DataGridViewTextBoxColumn configurationFileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn encryptedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource fwkConfigMannagerBindingSource;
    }
}
