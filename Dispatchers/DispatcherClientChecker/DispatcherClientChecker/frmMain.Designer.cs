namespace DispatcherClientChecker
{
    partial class frmMain
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
            this.wrapproviderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboProviders = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGetAllServices = new System.Windows.Forms.Button();
            this.btnRetriveDispatcherInfo = new System.Windows.Forms.Button();
            this.btnGetAllApplicationsId = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnGetProviderInfo = new System.Windows.Forms.Button();
            this.rndJSON = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.wrapproviderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboProviders
            // 
            this.comboProviders.DataSource = this.wrapproviderBindingSource;
            this.comboProviders.DisplayMember = "Name";
            this.comboProviders.FormattingEnabled = true;
            this.comboProviders.Location = new System.Drawing.Point(12, 42);
            this.comboProviders.Name = "comboProviders";
            this.comboProviders.Size = new System.Drawing.Size(255, 24);
            this.comboProviders.TabIndex = 13;
            this.comboProviders.ValueMember = "SourceInfo";
            this.comboProviders.SelectedIndexChanged += new System.EventHandler(this.comboProviders_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox1.Location = new System.Drawing.Point(12, 116);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(376, 155);
            this.textBox1.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.OldLace;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(18, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 19);
            this.label6.TabIndex = 17;
            this.label6.Text = "Wrqapper info";
            // 
            // btnGetAllServices
            // 
            this.btnGetAllServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetAllServices.ForeColor = System.Drawing.Color.White;
            this.btnGetAllServices.Location = new System.Drawing.Point(21, 280);
            this.btnGetAllServices.Name = "btnGetAllServices";
            this.btnGetAllServices.Size = new System.Drawing.Size(238, 34);
            this.btnGetAllServices.TabIndex = 19;
            this.btnGetAllServices.Text = "RetriveAllServices";
            this.btnGetAllServices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetAllServices.UseVisualStyleBackColor = true;
            this.btnGetAllServices.Click += new System.EventHandler(this.btnGetAllServices_Click);
            // 
            // btnRetriveDispatcherInfo
            // 
            this.btnRetriveDispatcherInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetriveDispatcherInfo.ForeColor = System.Drawing.Color.White;
            this.btnRetriveDispatcherInfo.Location = new System.Drawing.Point(21, 320);
            this.btnRetriveDispatcherInfo.Name = "btnRetriveDispatcherInfo";
            this.btnRetriveDispatcherInfo.Size = new System.Drawing.Size(238, 34);
            this.btnRetriveDispatcherInfo.TabIndex = 20;
            this.btnRetriveDispatcherInfo.Text = "RetriveDispatcherInfo";
            this.btnRetriveDispatcherInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRetriveDispatcherInfo.UseVisualStyleBackColor = true;
            this.btnRetriveDispatcherInfo.Click += new System.EventHandler(this.btnRetriveDispatcherInfo_Click);
            // 
            // btnGetAllApplicationsId
            // 
            this.btnGetAllApplicationsId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetAllApplicationsId.ForeColor = System.Drawing.Color.White;
            this.btnGetAllApplicationsId.Location = new System.Drawing.Point(21, 371);
            this.btnGetAllApplicationsId.Name = "btnGetAllApplicationsId";
            this.btnGetAllApplicationsId.Size = new System.Drawing.Size(238, 34);
            this.btnGetAllApplicationsId.TabIndex = 21;
            this.btnGetAllApplicationsId.Text = "GetAllApplicationsId";
            this.btnGetAllApplicationsId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetAllApplicationsId.UseVisualStyleBackColor = true;
            this.btnGetAllApplicationsId.Click += new System.EventHandler(this.btnGetAllApplicationsId_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtResult.Location = new System.Drawing.Point(394, 2);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(892, 624);
            this.txtResult.TabIndex = 22;
            // 
            // btnGetProviderInfo
            // 
            this.btnGetProviderInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetProviderInfo.ForeColor = System.Drawing.Color.White;
            this.btnGetProviderInfo.Location = new System.Drawing.Point(21, 428);
            this.btnGetProviderInfo.Name = "btnGetProviderInfo";
            this.btnGetProviderInfo.Size = new System.Drawing.Size(246, 34);
            this.btnGetProviderInfo.TabIndex = 23;
            this.btnGetProviderInfo.Text = "GetProviderInfo (default provider)";
            this.btnGetProviderInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetProviderInfo.UseVisualStyleBackColor = true;
            this.btnGetProviderInfo.Click += new System.EventHandler(this.btnGetProviderInfo_Click);
            // 
            // rndJSON
            // 
            this.rndJSON.AutoSize = true;
            this.rndJSON.ForeColor = System.Drawing.Color.White;
            this.rndJSON.Location = new System.Drawing.Point(293, 371);
            this.rndJSON.Name = "rndJSON";
            this.rndJSON.Size = new System.Drawing.Size(66, 21);
            this.rndJSON.TabIndex = 24;
            this.rndJSON.Text = "JSON";
            this.rndJSON.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(293, 334);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(57, 21);
            this.radioButton1.TabIndex = 25;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "XML";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1286, 627);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.rndJSON);
            this.Controls.Add(this.btnGetProviderInfo);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnGetAllApplicationsId);
            this.Controls.Add(this.btnRetriveDispatcherInfo);
            this.Controls.Add(this.btnGetAllServices);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboProviders);
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dispatcher client checker";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wrapproviderBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource wrapproviderBindingSource;
        private System.Windows.Forms.ComboBox comboProviders;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGetAllServices;
        private System.Windows.Forms.Button btnRetriveDispatcherInfo;
        private System.Windows.Forms.Button btnGetAllApplicationsId;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnGetProviderInfo;
        private System.Windows.Forms.RadioButton rndJSON;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

