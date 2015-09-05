namespace Fwk.ServiceManagement.Tools.Win32
{
    partial class frmExport1
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.provider1 = new Fwk.ServiceManagement.Tools.Win32.provider();
            this.label7 = new System.Windows.Forms.Label();
            this.ucbServiceGrid1 = new Fwk.ServiceManagement.Tools.Win32.UCBServiceGrid();
            this.provider2 = new Fwk.ServiceManagement.Tools.Win32.provider();
            this.ucbServiceGrid2 = new Fwk.ServiceManagement.Tools.Win32.UCBServiceGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(1424, 844);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(1300, 844);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 28);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(16, 4);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.provider1);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.ucbServiceGrid1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.provider2);
            this.splitContainer1.Panel2.Controls.Add(this.ucbServiceGrid2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.cmb2);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Size = new System.Drawing.Size(1556, 833);
            this.splitContainer1.SplitterDistance = 766;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 88;
            // 
            // provider1
            // 
            this.provider1.Location = new System.Drawing.Point(4, 52);
            this.provider1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.provider1.Name = "provider1";
            this.provider1.Size = new System.Drawing.Size(759, 158);
            this.provider1.TabIndex = 93;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(3, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(759, 39);
            this.label7.TabIndex = 92;
            this.label7.Text = "Source";
            // 
            // ucbServiceGrid1
            // 
            this.ucbServiceGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucbServiceGrid1.Applications = null;
            this.ucbServiceGrid1.CurentServiceConfiguration = null;
            this.ucbServiceGrid1.Location = new System.Drawing.Point(9, 210);
            this.ucbServiceGrid1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucbServiceGrid1.Name = "ucbServiceGrid1";
            this.ucbServiceGrid1.Services = null;
            this.ucbServiceGrid1.Size = new System.Drawing.Size(746, 603);
            this.ucbServiceGrid1.TabIndex = 87;
            // 
            // provider2
            // 
            this.provider2.Location = new System.Drawing.Point(4, 52);
            this.provider2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.provider2.Name = "provider2";
            this.provider2.Size = new System.Drawing.Size(1048, 158);
            this.provider2.TabIndex = 94;
            // 
            // ucbServiceGrid2
            // 
            this.ucbServiceGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucbServiceGrid2.Applications = null;
            this.ucbServiceGrid2.CurentServiceConfiguration = null;
            this.ucbServiceGrid2.Location = new System.Drawing.Point(4, 210);
            this.ucbServiceGrid2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucbServiceGrid2.Name = "ucbServiceGrid2";
            this.ucbServiceGrid2.Services = null;
            this.ucbServiceGrid2.Size = new System.Drawing.Size(766, 603);
            this.ucbServiceGrid2.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(328, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 91;
            this.label1.Text = "Provider";
            // 
            // cmb2
            // 
            this.cmb2.FormattingEnabled = true;
            this.cmb2.Location = new System.Drawing.Point(404, 26);
            this.cmb2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb2.Name = "cmb2";
            this.cmb2.Size = new System.Drawing.Size(339, 24);
            this.cmb2.TabIndex = 90;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(11, 9);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(764, 39);
            this.label9.TabIndex = 93;
            this.label9.Text = "Destination";
            // 
            // frmExport1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1588, 887);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmExport1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export from ";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private UCBServiceGrid ucbServiceGrid1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cmb2;
        private UCBServiceGrid ucbServiceGrid2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private provider provider1;
        private provider provider2;
    }
}