using Fwk.Controls.Win32.TextCodeEditor;
namespace ConfigurationApp.Export
{
    partial class frmViewInsertScript
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
            this.txtSQLInserts = new Fwk.Controls.Win32.TextCodeEditor.TextCodeEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtSQLInserts
            // 
            this.txtSQLInserts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSQLInserts.BackColor = System.Drawing.Color.GhostWhite;
            this.txtSQLInserts.Location = new System.Drawing.Point(12, 78);
            this.txtSQLInserts.Name = "txtSQLInserts";
            this.txtSQLInserts.Size = new System.Drawing.Size(1200, 639);
            this.txtSQLInserts.TabIndex = 31;
            this.txtSQLInserts.TitleText = "";
            this.txtSQLInserts.TitleVisible = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Change Configguration File Name";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(547, 17);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(91, 26);
            this.btnRefresh.TabIndex = 33;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(237, 21);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(287, 20);
            this.txtFileName.TabIndex = 34;
            // 
            // frmViewInsertScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 729);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSQLInserts);
            this.Name = "frmViewInsertScript";
            this.Text = "Inserts ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextCodeEditor txtSQLInserts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtFileName;
        
    }
}