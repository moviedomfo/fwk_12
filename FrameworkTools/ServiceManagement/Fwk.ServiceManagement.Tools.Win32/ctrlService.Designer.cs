namespace Fwk.ServiceManagement.Tools.Win32
{
    /// <summary>
    /// 
    /// </summary>
    partial class ctrlService
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
            this.txtApplicationId = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.bindingSourceService = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtResponse = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.txtRequest = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.txtHandler = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.txtName = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.txtDescription = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cboIsolationLevel = new System.Windows.Forms.ComboBox();
            this.ckbAudit = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.ckbAvailable = new System.Windows.Forms.CheckBox();
            this.cboTransactionalBehaviour = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceService)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txtApplicationId);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtResponse);
            this.groupBox1.Controls.Add(this.txtRequest);
            this.groupBox1.Controls.Add(this.txtHandler);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboIsolationLevel);
            this.groupBox1.Controls.Add(this.ckbAudit);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.ckbAvailable);
            this.groupBox1.Controls.Add(this.cboTransactionalBehaviour);
            this.groupBox1.Location = new System.Drawing.Point(3, 25);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(895, 531);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            // 
            // txtApplicationId
            // 
            this.txtApplicationId.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtApplicationId.AllowBlankSpace = true;
            this.txtApplicationId.AllowedCharacters = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
            this.txtApplicationId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApplicationId.BackColor = System.Drawing.Color.White;
            this.txtApplicationId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApplicationId.CapitalOnly = false;
            this.txtApplicationId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceService, "ApplicationId", true));
            this.txtApplicationId.ErrorIconRightToLeft = true;
            this.txtApplicationId.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApplicationId.InactiveBorderColor = System.Drawing.SystemColors.Control;
            this.txtApplicationId.Location = new System.Drawing.Point(12, 61);
            this.txtApplicationId.Margin = new System.Windows.Forms.Padding(4);
            this.txtApplicationId.Name = "txtApplicationId";
            this.txtApplicationId.NotAllowedCharactersErrorText = null;
            this.txtApplicationId.Required = true;
            this.txtApplicationId.RequiredErrorText = "Name value is required";
            this.txtApplicationId.Size = new System.Drawing.Size(870, 24);
            this.txtApplicationId.TabIndex = 75;
            this.txtApplicationId.TabStop = false;
            this.txtApplicationId.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            // 
            // bindingSourceService
            // 
            this.bindingSourceService.DataSource = typeof(Fwk.Bases.ServiceConfiguration);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 74;
            this.label3.Text = "Name";
            // 
            // txtResponse
            // 
            this.txtResponse.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtResponse.AllowBlankSpace = true;
            this.txtResponse.AllowedCharacters = null;
            this.txtResponse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponse.BackColor = System.Drawing.Color.White;
            this.txtResponse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResponse.CapitalOnly = false;
            this.txtResponse.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceService, "Response", true));
            this.txtResponse.ErrorIconRightToLeft = true;
            this.txtResponse.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResponse.InactiveBorderColor = System.Drawing.SystemColors.Control;
            this.txtResponse.Location = new System.Drawing.Point(16, 387);
            this.txtResponse.Margin = new System.Windows.Forms.Padding(4);
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.NotAllowedCharactersErrorText = null;
            this.txtResponse.Required = true;
            this.txtResponse.RequiredErrorText = "Response is required";
            this.txtResponse.Size = new System.Drawing.Size(866, 24);
            this.txtResponse.TabIndex = 72;
            this.txtResponse.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            // 
            // txtRequest
            // 
            this.txtRequest.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtRequest.AllowBlankSpace = true;
            this.txtRequest.AllowedCharacters = null;
            this.txtRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRequest.BackColor = System.Drawing.Color.White;
            this.txtRequest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRequest.CapitalOnly = false;
            this.txtRequest.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceService, "Request", true));
            this.txtRequest.ErrorIconRightToLeft = true;
            this.txtRequest.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequest.InactiveBorderColor = System.Drawing.SystemColors.Control;
            this.txtRequest.Location = new System.Drawing.Point(16, 339);
            this.txtRequest.Margin = new System.Windows.Forms.Padding(4);
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.NotAllowedCharactersErrorText = null;
            this.txtRequest.Required = true;
            this.txtRequest.RequiredErrorText = "Request is required";
            this.txtRequest.Size = new System.Drawing.Size(866, 24);
            this.txtRequest.TabIndex = 71;
            this.txtRequest.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            // 
            // txtHandler
            // 
            this.txtHandler.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtHandler.AllowBlankSpace = true;
            this.txtHandler.AllowedCharacters = null;
            this.txtHandler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHandler.BackColor = System.Drawing.Color.White;
            this.txtHandler.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHandler.CapitalOnly = false;
            this.txtHandler.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceService, "Handler", true));
            this.txtHandler.ErrorIconRightToLeft = true;
            this.txtHandler.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHandler.InactiveBorderColor = System.Drawing.SystemColors.Control;
            this.txtHandler.Location = new System.Drawing.Point(16, 291);
            this.txtHandler.Margin = new System.Windows.Forms.Padding(4);
            this.txtHandler.Name = "txtHandler";
            this.txtHandler.NotAllowedCharactersErrorText = null;
            this.txtHandler.Required = true;
            this.txtHandler.RequiredErrorText = "Handler is required";
            this.txtHandler.Size = new System.Drawing.Size(866, 24);
            this.txtHandler.TabIndex = 70;
            this.txtHandler.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
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
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceService, "Name", true));
            this.txtName.ErrorIconRightToLeft = true;
            this.txtName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.InactiveBorderColor = System.Drawing.SystemColors.Control;
            this.txtName.Location = new System.Drawing.Point(16, 121);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.NotAllowedCharactersErrorText = null;
            this.txtName.Required = true;
            this.txtName.RequiredErrorText = "Name value is required";
            this.txtName.Size = new System.Drawing.Size(870, 24);
            this.txtName.TabIndex = 69;
            this.txtName.TabStop = false;
            this.txtName.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            // 
            // txtDescription
            // 
            this.txtDescription.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtDescription.AllowBlankSpace = true;
            this.txtDescription.AllowedCharacters = null;
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.CapitalOnly = false;
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceService, "Description", true));
            this.txtDescription.ErrorIconRightToLeft = true;
            this.txtDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.InactiveBorderColor = System.Drawing.SystemColors.Control;
            this.txtDescription.Location = new System.Drawing.Point(16, 181);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.NotAllowedCharactersErrorText = null;
            this.txtDescription.Required = false;
            this.txtDescription.RequiredErrorText = null;
            this.txtDescription.Size = new System.Drawing.Size(867, 86);
            this.txtDescription.TabIndex = 68;
            this.txtDescription.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.ForestGreen;
            this.label4.Location = new System.Drawing.Point(257, 428);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 65;
            this.label4.Text = "Isolation level";
            // 
            // cboIsolationLevel
            // 
            this.cboIsolationLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIsolationLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboIsolationLevel.FormattingEnabled = true;
            this.cboIsolationLevel.Location = new System.Drawing.Point(261, 447);
            this.cboIsolationLevel.Margin = new System.Windows.Forms.Padding(4);
            this.cboIsolationLevel.Name = "cboIsolationLevel";
            this.cboIsolationLevel.Size = new System.Drawing.Size(199, 24);
            this.cboIsolationLevel.TabIndex = 58;
            // 
            // ckbAudit
            // 
            this.ckbAudit.AutoSize = true;
            this.ckbAudit.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSourceService, "Audit", true));
            this.ckbAudit.Location = new System.Drawing.Point(703, 450);
            this.ckbAudit.Margin = new System.Windows.Forms.Padding(4);
            this.ckbAudit.Name = "ckbAudit";
            this.ckbAudit.Size = new System.Drawing.Size(62, 21);
            this.ckbAudit.TabIndex = 61;
            this.ckbAudit.Text = "Audit";
            this.ckbAudit.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.ForestGreen;
            this.label10.Location = new System.Drawing.Point(8, 425);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(161, 17);
            this.label10.TabIndex = 64;
            this.label10.Text = "Transactional behaviour";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(12, 367);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 17);
            this.label9.TabIndex = 63;
            this.label9.Text = "Response";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(12, 319);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 17);
            this.label8.TabIndex = 62;
            this.label8.Text = "Request";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(12, 271);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 57;
            this.label2.Text = "Service";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 162);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 55;
            this.label1.Text = "Description";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(8, 41);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(92, 17);
            this.lblName.TabIndex = 54;
            this.lblName.Text = "Application Id";
            // 
            // ckbAvailable
            // 
            this.ckbAvailable.AutoSize = true;
            this.ckbAvailable.Checked = true;
            this.ckbAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbAvailable.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSourceService, "Available", true));
            this.ckbAvailable.Location = new System.Drawing.Point(561, 452);
            this.ckbAvailable.Margin = new System.Windows.Forms.Padding(4);
            this.ckbAvailable.Name = "ckbAvailable";
            this.ckbAvailable.Size = new System.Drawing.Size(87, 21);
            this.ckbAvailable.TabIndex = 60;
            this.ckbAvailable.Text = "Available";
            this.ckbAvailable.UseVisualStyleBackColor = true;
            // 
            // cboTransactionalBehaviour
            // 
            this.cboTransactionalBehaviour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransactionalBehaviour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTransactionalBehaviour.FormattingEnabled = true;
            this.cboTransactionalBehaviour.Location = new System.Drawing.Point(13, 445);
            this.cboTransactionalBehaviour.Margin = new System.Windows.Forms.Padding(4);
            this.cboTransactionalBehaviour.Name = "cboTransactionalBehaviour";
            this.cboTransactionalBehaviour.Size = new System.Drawing.Size(199, 24);
            this.cboTransactionalBehaviour.TabIndex = 56;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(4, 1);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(64, 25);
            this.lblTitle.TabIndex = 50;
            this.lblTitle.Text = "label3";
            // 
            // ctrlService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ctrlService";
            this.Size = new System.Drawing.Size(899, 560);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceService)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboIsolationLevel;
        private System.Windows.Forms.CheckBox ckbAudit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.CheckBox ckbAvailable;
        private System.Windows.Forms.ComboBox cboTransactionalBehaviour;
        private System.Windows.Forms.BindingSource bindingSourceService;
        private System.Windows.Forms.Label lblTitle;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtDescription;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtResponse;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtRequest;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtHandler;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtName;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtApplicationId;
        private System.Windows.Forms.Label label3;
    }
}
