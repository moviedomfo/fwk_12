namespace Fwk.Bases.FrontEnd.Controls{
    partial class FwkNumericTextBox
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
            this.txtTextBox = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTextBox
            // 
            this.txtTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTextBox.BackColor = System.Drawing.Color.White;
            this.txtTextBox.Location = new System.Drawing.Point(0, 0);
            this.txtTextBox.Name = "txtTextBox";
            this.txtTextBox.Size = new System.Drawing.Size(126, 20);
            this.txtTextBox.TabIndex = 65;
            this.txtTextBox.Text = "0";
            this.txtTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTextBox_KeyPress);
            this.txtTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.txtTextBox_Validating);
            this.txtTextBox.MouseEnter += new System.EventHandler(this.txtTextBox_MouseEnter);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FwkNumericTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtTextBox);
            this.Name = "FwkNumericTextBox";
            this.Size = new System.Drawing.Size(142, 21);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
