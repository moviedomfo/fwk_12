namespace Fwk.Logging.Viewer
{
    partial class FRM_Document
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Document));
            this.grdLogs = new System.Windows.Forms.DataGridView();
            this.colImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.logTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machineDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventGridListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExceptionViewer = new Fwk.Bases.FrontEnd.Controls.FwkExceptionViewComponent(this.components);
            this.fwkMessageViewComponent1 = new Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent(this.components);
            this.filter1 = new Fwk.Logging.Viewer.Filter();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventGridListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grdLogs
            // 
            this.grdLogs.AllowUserToAddRows = false;
            this.grdLogs.AllowUserToOrderColumns = true;
            this.grdLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLogs.AutoGenerateColumns = false;
            this.grdLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdLogs.BackgroundColor = System.Drawing.Color.White;
            this.grdLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdLogs.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.grdLogs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImg,
            this.logTypeDataGridViewTextBoxColumn,
            this.Id,
            this.logDateDataGridViewTextBoxColumn,
            this.userDataGridViewTextBoxColumn,
            this.machineDataGridViewTextBoxColumn,
            this.sourceDataGridViewTextBoxColumn,
            this.appIdDataGridViewTextBoxColumn,
            this.messageDataGridViewTextBoxColumn});
            this.grdLogs.DataSource = this.eventGridListBindingSource;
            this.grdLogs.Location = new System.Drawing.Point(9, 92);
            this.grdLogs.Name = "grdLogs";
            this.grdLogs.ReadOnly = true;
            this.grdLogs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdLogs.RowHeadersVisible = false;
            this.grdLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLogs.Size = new System.Drawing.Size(1044, 318);
            this.grdLogs.TabIndex = 0;
            this.grdLogs.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLogs_RowEnter);
            // 
            // colImg
            // 
            this.colImg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colImg.DataPropertyName = "LogImage";
            this.colImg.Description = "IconImage";
            this.colImg.FillWeight = 155.5696F;
            this.colImg.Frozen = true;
            this.colImg.HeaderText = "";
            this.colImg.Name = "colImg";
            this.colImg.ReadOnly = true;
            this.colImg.Width = 5;
            // 
            // logTypeDataGridViewTextBoxColumn
            // 
            this.logTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.logTypeDataGridViewTextBoxColumn.DataPropertyName = "LogType";
            this.logTypeDataGridViewTextBoxColumn.FillWeight = 114.0627F;
            this.logTypeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.logTypeDataGridViewTextBoxColumn.Name = "logTypeDataGridViewTextBoxColumn";
            this.logTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.logTypeDataGridViewTextBoxColumn.Width = 72;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 5;
            // 
            // logDateDataGridViewTextBoxColumn
            // 
            this.logDateDataGridViewTextBoxColumn.DataPropertyName = "LogDate";
            this.logDateDataGridViewTextBoxColumn.FillWeight = 36.18885F;
            this.logDateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.logDateDataGridViewTextBoxColumn.Name = "logDateDataGridViewTextBoxColumn";
            this.logDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userDataGridViewTextBoxColumn
            // 
            this.userDataGridViewTextBoxColumn.DataPropertyName = "User";
            this.userDataGridViewTextBoxColumn.FillWeight = 36.18885F;
            this.userDataGridViewTextBoxColumn.HeaderText = "User";
            this.userDataGridViewTextBoxColumn.Name = "userDataGridViewTextBoxColumn";
            this.userDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // machineDataGridViewTextBoxColumn
            // 
            this.machineDataGridViewTextBoxColumn.DataPropertyName = "Machine";
            this.machineDataGridViewTextBoxColumn.FillWeight = 36.18885F;
            this.machineDataGridViewTextBoxColumn.HeaderText = "Machine";
            this.machineDataGridViewTextBoxColumn.Name = "machineDataGridViewTextBoxColumn";
            this.machineDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sourceDataGridViewTextBoxColumn
            // 
            this.sourceDataGridViewTextBoxColumn.DataPropertyName = "Source";
            this.sourceDataGridViewTextBoxColumn.FillWeight = 36.18885F;
            this.sourceDataGridViewTextBoxColumn.HeaderText = "Source";
            this.sourceDataGridViewTextBoxColumn.Name = "sourceDataGridViewTextBoxColumn";
            this.sourceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // appIdDataGridViewTextBoxColumn
            // 
            this.appIdDataGridViewTextBoxColumn.DataPropertyName = "AppId";
            this.appIdDataGridViewTextBoxColumn.FillWeight = 36.18885F;
            this.appIdDataGridViewTextBoxColumn.HeaderText = "AppId";
            this.appIdDataGridViewTextBoxColumn.Name = "appIdDataGridViewTextBoxColumn";
            this.appIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // messageDataGridViewTextBoxColumn
            // 
            this.messageDataGridViewTextBoxColumn.DataPropertyName = "Message";
            this.messageDataGridViewTextBoxColumn.FillWeight = 4.993313F;
            this.messageDataGridViewTextBoxColumn.HeaderText = "Message";
            this.messageDataGridViewTextBoxColumn.Name = "messageDataGridViewTextBoxColumn";
            this.messageDataGridViewTextBoxColumn.ReadOnly = true;
            this.messageDataGridViewTextBoxColumn.Visible = false;
            // 
            // eventGridListBindingSource
            // 
            this.eventGridListBindingSource.DataSource = typeof(Fwk.Logging.Viewer.EventGridList);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(11, 416);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1042, 237);
            this.panel1.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "LogType";
            this.dataGridViewTextBoxColumn1.HeaderText = "LogType";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 262;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "LogType";
            this.dataGridViewTextBoxColumn2.HeaderText = "LogType";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 262;
            // 
            // ExceptionViewer
            // 
            this.ExceptionViewer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ExceptionViewer.TextMessageColor = System.Drawing.Color.White;
            this.ExceptionViewer.TextMessageForeColorColor = System.Drawing.SystemColors.WindowText;
            this.ExceptionViewer.Title = "FrmTechnicalMsg";
            // 
            // fwkMessageViewComponent1
            // 
            this.fwkMessageViewComponent1.BackColor = System.Drawing.Color.SteelBlue;
            this.fwkMessageViewComponent1.IconSize = Fwk.Bases.FrontEnd.Controls.IconSize.Small;
            this.fwkMessageViewComponent1.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.fwkMessageViewComponent1.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Information;
            this.fwkMessageViewComponent1.TextMessageColor = System.Drawing.Color.SteelBlue;
            this.fwkMessageViewComponent1.TextMessageForeColor = System.Drawing.Color.PaleGoldenrod;
            this.fwkMessageViewComponent1.Title = "Message";
            // 
            // filter1
            // 
            this.filter1.Location = new System.Drawing.Point(10, 4);
            this.filter1.Name = "filter1";
            this.filter1.Size = new System.Drawing.Size(1052, 78);
            this.filter1.TabIndex = 6;
            this.filter1.OnFilterChanged += new Fwk.Logging.Viewer.OnFilterChangedHandler(this.filter1_OnFilterChanged);
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Location = new System.Drawing.Point(696, 13);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(118, 23);
            this.btnClearLogs.TabIndex = 7;
            this.btnClearLogs.Text = "Clear all logs";
            this.btnClearLogs.UseVisualStyleBackColor = true;
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(696, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Clear selected";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FRM_Document
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1065, 665);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClearLogs);
            this.Controls.Add(this.filter1);
            this.Controls.Add(this.grdLogs);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FRM_Document";
            this.Text = "[name]";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.FRM_Document_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FRM_Document_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventGridListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdLogs;
        private System.Windows.Forms.Panel panel1;
        private Filter filter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent fwkMessageViewComponent1;
        private Fwk.Bases.FrontEnd.Controls.FwkExceptionViewComponent ExceptionViewer;
        private System.Windows.Forms.BindingSource eventGridListBindingSource;
        private System.Windows.Forms.DataGridViewImageColumn colImg;
        private System.Windows.Forms.DataGridViewTextBoxColumn logTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn logDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn appIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnClearLogs;
        private System.Windows.Forms.Button button1;

    }
}