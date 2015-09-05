namespace Fwk.Bases.FrontEnd.Controls
{
    partial class FrmMsgBase
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
            this.pnlFill = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlFill
            // 
            this.pnlFill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 0);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(367, 115);
            this.pnlFill.TabIndex = 8;
            
            // 
            // FrmMsgBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(367, 115);
            this.ControlBox = false;
            this.Controls.Add(this.pnlFill);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMsgBase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMsgBase";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMsgBase_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public System.Windows.Forms.Panel pnlFill;

    }
}