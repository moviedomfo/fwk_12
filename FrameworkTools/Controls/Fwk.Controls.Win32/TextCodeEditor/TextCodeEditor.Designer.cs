using System.Windows.Forms;

using System.Drawing;
using System.Windows.Forms.Integration;
using AvalonEdit.Sample;
using ICSharpCode.AvalonEdit.Folding;
namespace Fwk.Controls.Win32.TextCodeEditor
{
    partial class TextCodeEditor
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

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.textCodeEditorHost1 = new Fwk.Controls.Win32.TextCodeEditor.TextCodeEditorHost();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.Silver;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(610, 16);
            this.lblTitle.TabIndex = 2;
            // 
            // textCodeEditorHost1
            // 
            this.textCodeEditorHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textCodeEditorHost1.Location = new System.Drawing.Point(0, 0);
            this.textCodeEditorHost1.Name = "textCodeEditorHost1";
            this.textCodeEditorHost1.Size = new System.Drawing.Size(622, 412);
            this.textCodeEditorHost1.TabIndex = 3;
            // 
            // TextCodeEditor
            // 
            this.Controls.Add(this.textCodeEditorHost1);
            this.Controls.Add(this.lblTitle);
            this.Name = "TextCodeEditor";
            this.Size = new System.Drawing.Size(622, 412);
            this.ResumeLayout(false);

        }


        

        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem menuItem13;
        private System.Windows.Forms.Label lblTitle;
       
        #endregion
        private TextCodeEditorHost textCodeEditorHost1;
    }
}
