namespace Fwk.CodeGenerator
{
    partial class FrmBase
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
            this.MessageView = new Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent(this.components);
            this.SuspendLayout();
            // 
            // MessageView
            // 
            this.MessageView.BackColor = System.Drawing.Color.White;
            this.MessageView.IconSize = Fwk.Bases.FrontEnd.Controls.IconSize.Small;
            this.MessageView.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.MessageView.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Information;
            this.MessageView.TextMessageColor = System.Drawing.Color.White;
            this.MessageView.TextMessageForeColor = System.Drawing.Color.Black;
            this.MessageView.Title = "Message";
            // 
            // FrmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(520, 266);
            this.Name = "FrmBase";
            this.TabText = "Frm_Base";
            this.Text = "Frm_Base";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Base_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        public Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent MessageView;





    }
}