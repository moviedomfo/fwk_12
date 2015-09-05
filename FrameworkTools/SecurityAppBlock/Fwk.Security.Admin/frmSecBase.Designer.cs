namespace Fwk.Security.Admin
{
    partial class frmSecBase
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
            this.MessageViewInfo = new Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent(this.components);
            this.SuspendLayout();
            // 
            // MessageViewInfo
            // 
            this.MessageViewInfo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.MessageViewInfo.IconSize = Fwk.Bases.FrontEnd.Controls.IconSize.Small;
            this.MessageViewInfo.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.MessageViewInfo.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Information;
            this.MessageViewInfo.TextMessageColor = System.Drawing.Color.White;
            this.MessageViewInfo.TextMessageForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.MessageViewInfo.Title = "Security admin";
            // 
            // frmSecBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(560, 361);
            this.Name = "frmSecBase";
            this.Text = "frmSecBase";
            this.ResumeLayout(false);

        }

        #endregion

        public Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent MessageViewInfo;
    }
}