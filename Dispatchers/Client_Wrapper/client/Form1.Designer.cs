namespace Client
{
    partial class Form1
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
            this.btn_RetrivePatientsReq1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_RetrivePatientsReq2 = new System.Windows.Forms.Button();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRetrivePatients = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIteraciones = new System.Windows.Forms.TextBox();
            this.comboProviders = new System.Windows.Forms.ComboBox();
            this.wrapproviderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wrapproviderBindingSource)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_RetrivePatientsReq1
            // 
            this.btn_RetrivePatientsReq1.Location = new System.Drawing.Point(14, 36);
            this.btn_RetrivePatientsReq1.Name = "btn_RetrivePatientsReq1";
            this.btn_RetrivePatientsReq1.Size = new System.Drawing.Size(128, 25);
            this.btn_RetrivePatientsReq1.TabIndex = 0;
            this.btn_RetrivePatientsReq1.Text = "RetrivePatientsReq";
            this.btn_RetrivePatientsReq1.UseVisualStyleBackColor = true;
            this.btn_RetrivePatientsReq1.Click += new System.EventHandler(this.btn_RetrivePatientsReq1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(37, 292);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(204, 33);
            this.button2.TabIndex = 1;
            this.button2.Text = "RetrivePacientesService";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_RetrivePatientsReq2
            // 
            this.btn_RetrivePatientsReq2.Location = new System.Drawing.Point(14, 88);
            this.btn_RetrivePatientsReq2.Name = "btn_RetrivePatientsReq2";
            this.btn_RetrivePatientsReq2.Size = new System.Drawing.Size(125, 29);
            this.btn_RetrivePatientsReq2.TabIndex = 2;
            this.btn_RetrivePatientsReq2.Text = "RetrivePatientsReq";
            this.btn_RetrivePatientsReq2.UseVisualStyleBackColor = true;
            this.btn_RetrivePatientsReq2.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtResponse
            // 
            this.txtResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponse.Location = new System.Drawing.Point(501, 60);
            this.txtResponse.Margin = new System.Windows.Forms.Padding(2);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResponse.Size = new System.Drawing.Size(510, 437);
            this.txtResponse.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(501, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Response";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(146, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = " Wrapper que reutiliza proxy _WCFWrapper_01";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(146, 84);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 32);
            this.label4.TabIndex = 9;
            this.label4.Text = "Wraapper Dispose using _WCFWrapper_02";
            // 
            // btnRetrivePatients
            // 
            this.btnRetrivePatients.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRetrivePatients.Location = new System.Drawing.Point(7, 44);
            this.btnRetrivePatients.Name = "btnRetrivePatients";
            this.btnRetrivePatients.Size = new System.Drawing.Size(125, 29);
            this.btnRetrivePatients.TabIndex = 10;
            this.btnRetrivePatients.Text = "RetrivePatientsReq";
            this.btnRetrivePatients.UseVisualStyleBackColor = false;
            this.btnRetrivePatients.Click += new System.EventHandler(this.btnRetrivePatientsReq_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(4, 76);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 32);
            this.label5.TabIndex = 11;
            this.label5.Text = "Repetitivo Wraapper Dispose using req.ExecuteService";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(2, 11);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(495, 490);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtIteraciones);
            this.tabPage1.Controls.Add(this.comboProviders);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btnRetrivePatients);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(487, 464);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Use Fwk Wraper";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 236);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(283, 175);
            this.textBox1.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(12, 219);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Wrqapper info";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(50, 143);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Iteraciones";
            // 
            // txtIteraciones
            // 
            this.txtIteraciones.Location = new System.Drawing.Point(134, 141);
            this.txtIteraciones.Margin = new System.Windows.Forms.Padding(2);
            this.txtIteraciones.Name = "txtIteraciones";
            this.txtIteraciones.Size = new System.Drawing.Size(86, 20);
            this.txtIteraciones.TabIndex = 13;
            this.txtIteraciones.Text = "1";
            // 
            // comboProviders
            // 
            this.comboProviders.DataSource = this.wrapproviderBindingSource;
            this.comboProviders.DisplayMember = "Name";
            this.comboProviders.FormattingEnabled = true;
            this.comboProviders.Location = new System.Drawing.Point(8, 19);
            this.comboProviders.Margin = new System.Windows.Forms.Padding(2);
            this.comboProviders.Name = "comboProviders";
            this.comboProviders.Size = new System.Drawing.Size(192, 21);
            this.comboProviders.TabIndex = 12;
            this.comboProviders.ValueMember = "SourceInfo";
            this.comboProviders.SelectedIndexChanged += new System.EventHandler(this.comboProviders_SelectedIndexChanged);
            // 
            // wrapproviderBindingSource
            // 
            this.wrapproviderBindingSource.DataSource = typeof(Client.wrap_provider);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.btn_RetrivePatientsReq1);
            this.tabPage2.Controls.Add(this.btn_RetrivePatientsReq2);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(487, 464);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Use test local wrappers";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(487, 464);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Serialiaciones";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(49, 215);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(204, 33);
            this.button3.TabIndex = 9;
            this.button3.Text = "json javascriptSerializer";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 33);
            this.button1.TabIndex = 8;
            this.button1.Text = "json Newton Soft";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(33, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(333, 32);
            this.label7.TabIndex = 7;
            this.label7.Text = "Serializar RetrivePatientsReq ";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(49, 82);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(204, 33);
            this.button4.TabIndex = 4;
            this.button4.Text = "json  DatacontractSerializer";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 533);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Test wrapper WCF";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wrapproviderBindingSource)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_RetrivePatientsReq1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_RetrivePatientsReq2;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRetrivePatients;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboProviders;
        private System.Windows.Forms.BindingSource wrapproviderBindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIteraciones;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
    }
}

