namespace Fwk.ServiceManagement.Tools.Win32
{
    partial class frmManageProviders
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
            this.grdProviders = new System.Windows.Forms.DataGridView();
            this.providerBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.provider1 = new Fwk.ServiceManagement.Tools.Win32.provider();
            this.txtAddres = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.providerTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.securityProviderNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceInfoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.applicationIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdProviders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.providerBindingSource1)).BeginInit();
            this.provider1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdProviders
            // 
            this.grdProviders.AllowUserToAddRows = false;
            this.grdProviders.AllowUserToDeleteRows = false;
            this.grdProviders.AutoGenerateColumns = false;
            this.grdProviders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProviders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.providerTypeDataGridViewTextBoxColumn,
            this.securityProviderNameDataGridViewTextBoxColumn,
            this.sourceInfoDataGridViewTextBoxColumn,
            this.applicationIdDataGridViewTextBoxColumn});
            this.grdProviders.DataSource = this.providerBindingSource1;
            this.grdProviders.Location = new System.Drawing.Point(27, 148);
            this.grdProviders.Name = "grdProviders";
            this.grdProviders.ReadOnly = true;
            this.grdProviders.RowTemplate.Height = 24;
            this.grdProviders.Size = new System.Drawing.Size(1154, 425);
            this.grdProviders.TabIndex = 53;
            this.grdProviders.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdProviders_RowEnter);
            this.grdProviders.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdProviders_MouseClick);
            // 
            // providerBindingSource1
            // 
            this.providerBindingSource1.DataSource = typeof(Fwk.ServiceManagement.Tools.Win32.Provider);
            // 
            // provider1
            // 
            this.provider1.Controls.Add(this.txtAddres);
            this.provider1.Location = new System.Drawing.Point(27, 47);
            this.provider1.Margin = new System.Windows.Forms.Padding(5);
            this.provider1.Name = "provider1";
            this.provider1.Size = new System.Drawing.Size(1208, 107);
            this.provider1.TabIndex = 52;
            // 
            // txtAddres
            // 
            this.txtAddres.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtAddres.AllowBlankSpace = true;
            this.txtAddres.AllowedCharacters = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
            this.txtAddres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddres.BackColor = System.Drawing.Color.White;
            this.txtAddres.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddres.CapitalOnly = false;
            this.txtAddres.ErrorIconRightToLeft = false;
            this.txtAddres.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddres.InactiveBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtAddres.Location = new System.Drawing.Point(111, 69);
            this.txtAddres.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddres.Multiline = true;
            this.txtAddres.Name = "txtAddres";
            this.txtAddres.NotAllowedCharactersErrorText = "";
            this.txtAddres.ReadOnly = true;
            this.txtAddres.Required = false;
            this.txtAddres.RequiredErrorText = null;
            this.txtAddres.Size = new System.Drawing.Size(1184, 25);
            this.txtAddres.TabIndex = 96;
            this.txtAddres.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 200;
            // 
            // providerTypeDataGridViewTextBoxColumn
            // 
            this.providerTypeDataGridViewTextBoxColumn.DataPropertyName = "ProviderType";
            this.providerTypeDataGridViewTextBoxColumn.HeaderText = "ProviderType";
            this.providerTypeDataGridViewTextBoxColumn.Name = "providerTypeDataGridViewTextBoxColumn";
            this.providerTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // securityProviderNameDataGridViewTextBoxColumn
            // 
            this.securityProviderNameDataGridViewTextBoxColumn.DataPropertyName = "SecurityProviderName";
            this.securityProviderNameDataGridViewTextBoxColumn.HeaderText = "SecurityProviderName";
            this.securityProviderNameDataGridViewTextBoxColumn.Name = "securityProviderNameDataGridViewTextBoxColumn";
            this.securityProviderNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.securityProviderNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // sourceInfoDataGridViewTextBoxColumn
            // 
            this.sourceInfoDataGridViewTextBoxColumn.DataPropertyName = "SourceInfo";
            this.sourceInfoDataGridViewTextBoxColumn.HeaderText = "SourceInfo";
            this.sourceInfoDataGridViewTextBoxColumn.Name = "sourceInfoDataGridViewTextBoxColumn";
            this.sourceInfoDataGridViewTextBoxColumn.ReadOnly = true;
            this.sourceInfoDataGridViewTextBoxColumn.Width = 500;
            // 
            // applicationIdDataGridViewTextBoxColumn
            // 
            this.applicationIdDataGridViewTextBoxColumn.DataPropertyName = "ApplicationId";
            this.applicationIdDataGridViewTextBoxColumn.HeaderText = "ApplicationId";
            this.applicationIdDataGridViewTextBoxColumn.Name = "applicationIdDataGridViewTextBoxColumn";
            this.applicationIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(991, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(170, 45);
            this.btnDelete.TabIndex = 54;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmManageProviders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 657);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.grdProviders);
            this.Controls.Add(this.provider1);
            this.Name = "frmManageProviders";
            this.Text = "frmManageProviders";
            ((System.ComponentModel.ISupportInitialize)(this.grdProviders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.providerBindingSource1)).EndInit();
            this.provider1.ResumeLayout(false);
            this.provider1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private provider provider1;
        private Bases.FrontEnd.Controls.FwkFlatTextBox txtAddres;
        private System.Windows.Forms.DataGridView grdProviders;
        private System.Windows.Forms.BindingSource providerBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn providerTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn securityProviderNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceInfoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn applicationIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnDelete;
    }
}