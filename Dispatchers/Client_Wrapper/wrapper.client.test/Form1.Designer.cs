namespace wrapper.client.test
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
            this.comboProviders = new System.Windows.Forms.ComboBox();
            this.wrapproviderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRetrivePatients = new System.Windows.Forms.Button();
            this.txtRes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.wrapproviderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboProviders
            // 
            this.comboProviders.DataSource = this.wrapproviderBindingSource;
            this.comboProviders.DisplayMember = "Name";
            this.comboProviders.FormattingEnabled = true;
            this.comboProviders.Location = new System.Drawing.Point(32, 11);
            this.comboProviders.Margin = new System.Windows.Forms.Padding(2);
            this.comboProviders.Name = "comboProviders";
            this.comboProviders.Size = new System.Drawing.Size(367, 21);
            this.comboProviders.TabIndex = 13;
            this.comboProviders.ValueMember = "SourceInfo";
            this.comboProviders.SelectedIndexChanged += new System.EventHandler(this.comboProviders_SelectedIndexChanged);
            // 
            // wrapproviderBindingSource
            // 
            this.wrapproviderBindingSource.DataSource = typeof(Client.wrap_provider);
            // 
            // btnRetrivePatients
            // 
            this.btnRetrivePatients.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRetrivePatients.Location = new System.Drawing.Point(419, 12);
            this.btnRetrivePatients.Name = "btnRetrivePatients";
            this.btnRetrivePatients.Size = new System.Drawing.Size(125, 29);
            this.btnRetrivePatients.TabIndex = 14;
            this.btnRetrivePatients.Text = "Execute";
            this.btnRetrivePatients.UseVisualStyleBackColor = false;
            this.btnRetrivePatients.Click += new System.EventHandler(this.btnRetrivePatients_Click);
            // 
            // txtRes
            // 
            this.txtRes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRes.Location = new System.Drawing.Point(-1, 63);
            this.txtRes.Margin = new System.Windows.Forms.Padding(2);
            this.txtRes.Multiline = true;
            this.txtRes.Name = "txtRes";
            this.txtRes.Size = new System.Drawing.Size(709, 418);
            this.txtRes.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(11, 112);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 52);
            this.label6.TabIndex = 17;
            this.label6.Text = "Wrqapper info";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 481);
            this.Controls.Add(this.txtRes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnRetrivePatients);
            this.Controls.Add(this.comboProviders);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.wrapproviderBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboProviders;
        private System.Windows.Forms.Button btnRetrivePatients;
        private System.Windows.Forms.TextBox txtRes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource wrapproviderBindingSource;
    }
}

