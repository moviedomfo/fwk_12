namespace Fwk.Security.Admin.Controls
{
    partial class frmAddName
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
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButton_OkCreateCategory = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(12, 33);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(240, 22);
            this.textEdit1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Enter category name";
            // 
            // simpleButton_OkCreateCategory
            // 
            this.simpleButton_OkCreateCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton_OkCreateCategory.Image = global::Fwk.Security.Admin.Properties.Resources.file_apply_16;
            this.simpleButton_OkCreateCategory.Location = new System.Drawing.Point(268, 27);
            this.simpleButton_OkCreateCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton_OkCreateCategory.Name = "simpleButton_OkCreateCategory";
            this.simpleButton_OkCreateCategory.Size = new System.Drawing.Size(54, 28);
            this.simpleButton_OkCreateCategory.TabIndex = 33;
            this.simpleButton_OkCreateCategory.Text = "Ok";
            this.simpleButton_OkCreateCategory.Click += new System.EventHandler(this.simpleButton_OkCreateCategory_Click);
            // 
            // frmAddName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 90);
            this.Controls.Add(this.simpleButton_OkCreateCategory);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddName";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ingrese el Nombre";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButton_OkCreateCategory;
    }
}