namespace Fwk.Bases.FrontEnd
{
	public partial class FrmBase
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
            this.MessageViewer = new Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent(this.components);
            this.ExceptionViewer = new Fwk.Bases.FrontEnd.Controls.FwkExceptionViewComponent(this.components);
            this.SuspendLayout();
            // 
            // MessageViewer
            // 
            this.MessageViewer.BackColor = System.Drawing.Color.White;
            this.MessageViewer.IconSize = Fwk.Bases.FrontEnd.Controls.IconSize.Small;
            this.MessageViewer.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.MessageViewer.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Information;
            this.MessageViewer.TextMessageColor = System.Drawing.Color.White;
            this.MessageViewer.TextMessageForeColor = System.Drawing.Color.Black;
            this.MessageViewer.Title = "Message";
            // 
            // ExceptionViewer
            // 
            this.ExceptionViewer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ExceptionViewer.TextMessageColor = System.Drawing.Color.White;
            this.ExceptionViewer.TextMessageForeColorColor = System.Drawing.SystemColors.WindowText;
            this.ExceptionViewer.Title = "FrmTechnicalMsg";
            // 
            // FrmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 346);
            this.Name = "FrmBase";
            this.Text = "FrmBase";
            this.ResumeLayout(false);

		}

		#endregion

        public Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent MessageViewer;
        public Fwk.Bases.FrontEnd.Controls.FwkExceptionViewComponent ExceptionViewer;

    }
}