namespace Fwk.Security.Admin.Controls
{
    partial class frmRulesAdmin
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
            this.rulesAssingControl1 = new Fwk.Security.Admin.Controls.RulesAssingControl();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(8, 568);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(975, 32);
            this.aceptCancelButtonBar1.ClickOkCancelEvent += new Fwk.UI.Common.ClickOkCancelHandler(this.aceptCancelButtonBar1_ClickOkCancelEvent);
            // 
            // rulesAssingControl1
            // 
            this.rulesAssingControl1.Location = new System.Drawing.Point(8, 9);
            this.rulesAssingControl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.rulesAssingControl1.Name = "rulesAssingControl1";
            this.rulesAssingControl1.Size = new System.Drawing.Size(975, 565);
            this.rulesAssingControl1.TabIndex = 1;
            // 
            // frmRulesAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 609);
            this.Controls.Add(this.rulesAssingControl1);
            this.Name = "frmRulesAdmin";
            this.Text = "Rules admin";
            this.Load += new System.EventHandler(this.frmRulesAdmin_Load);
            this.Controls.SetChildIndex(this.rulesAssingControl1, 0);
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private RulesAssingControl rulesAssingControl1;
    }
}