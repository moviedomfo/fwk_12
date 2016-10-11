namespace ConfigurationApp.Forms
{
    partial class UCConfigElement
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
            this.groupKey = new System.Windows.Forms.GroupBox();
            this.chkCrypted = new System.Windows.Forms.CheckBox();
            this.txtNewValue = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewKeyName = new System.Windows.Forms.TextBox();
            this.keyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupKey.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.groupKey);
            this.groupBox1.Controls.Add(this.txtGroupName);
            this.groupBox1.Controls.Add(this.lblFileName);
            this.groupBox1.Controls.Add(this.lblFile);
            this.groupBox1.Controls.Add(this.lblGroup);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 338);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // groupKey
            // 
            this.groupKey.Controls.Add(this.chkCrypted);
            this.groupKey.Controls.Add(this.txtNewValue);
            this.groupKey.Controls.Add(this.lblKey);
            this.groupKey.Controls.Add(this.label4);
            this.groupKey.Controls.Add(this.txtNewKeyName);
            this.groupKey.Location = new System.Drawing.Point(27, 126);
            this.groupKey.Name = "groupKey";
            this.groupKey.Size = new System.Drawing.Size(579, 153);
            this.groupKey.TabIndex = 25;
            this.groupKey.TabStop = false;
            this.groupKey.Text = "Propertie";
            // 
            // chkCrypted
            // 
            this.chkCrypted.AutoSize = true;
            this.chkCrypted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCrypted.Location = new System.Drawing.Point(98, 120);
            this.chkCrypted.Name = "chkCrypted";
            this.chkCrypted.Size = new System.Drawing.Size(69, 17);
            this.chkCrypted.TabIndex = 22;
            this.chkCrypted.Text = "Crypted";
            this.chkCrypted.UseVisualStyleBackColor = true;
            this.chkCrypted.CheckedChanged += new System.EventHandler(this.chkCrypted_CheckedChanged);
            // 
            // txtNewValue
            // 
            this.txtNewValue.Location = new System.Drawing.Point(98, 78);
            this.txtNewValue.Name = "txtNewValue";
            this.txtNewValue.Size = new System.Drawing.Size(328, 20);
            this.txtNewValue.TabIndex = 21;
            this.txtNewValue.TextChanged += new System.EventHandler(this.txtNewValue_TextChanged);
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey.ForeColor = System.Drawing.Color.Black;
            this.lblKey.Location = new System.Drawing.Point(22, 39);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(39, 13);
            this.lblKey.TabIndex = 11;
            this.lblKey.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(22, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Value";
            // 
            // txtNewKeyName
            // 
            this.txtNewKeyName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.keyBindingSource, "Name", true));
            this.txtNewKeyName.Location = new System.Drawing.Point(98, 39);
            this.txtNewKeyName.Name = "txtNewKeyName";
            this.txtNewKeyName.ReadOnly = true;
            this.txtNewKeyName.Size = new System.Drawing.Size(328, 20);
            this.txtNewKeyName.TabIndex = 20;
            this.txtNewKeyName.TextChanged += new System.EventHandler(this.txtNewKeyName_TextChanged);
            // 
            // keyBindingSource
            // 
            this.keyBindingSource.DataSource = typeof(Fwk.Configuration.Common.Key);
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(94, 72);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.ReadOnly = true;
            this.txtGroupName.Size = new System.Drawing.Size(512, 20);
            this.txtGroupName.TabIndex = 23;
            this.txtGroupName.TextChanged += new System.EventHandler(this.txtGroupName_TextChanged);
            // 
            // lblFileName
            // 
            this.lblFileName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.ForeColor = System.Drawing.Color.DimGray;
            this.lblFileName.Location = new System.Drawing.Point(94, 49);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(512, 16);
            this.lblFileName.TabIndex = 13;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFile.ForeColor = System.Drawing.Color.Black;
            this.lblFile.Location = new System.Drawing.Point(24, 49);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(27, 13);
            this.lblFile.TabIndex = 10;
            this.lblFile.Text = "File";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroup.ForeColor = System.Drawing.Color.Black;
            this.lblGroup.Location = new System.Drawing.Point(23, 72);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(41, 13);
            this.lblGroup.TabIndex = 9;
            this.lblGroup.Text = "Group";
            // 
            // UCConfigElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UCConfigElement";
            this.Size = new System.Drawing.Size(639, 338);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupKey.ResumeLayout(false);
            this.groupKey.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keyBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNewValue;
        private System.Windows.Forms.TextBox txtNewKeyName;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.BindingSource keyBindingSource;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.GroupBox groupKey;
        private System.Windows.Forms.CheckBox chkCrypted;
    }
}
