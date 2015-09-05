using System.Windows.Forms;

using System.Drawing;
using System.Windows.Forms.Integration;
using AvalonEdit.Sample;
using ICSharpCode.AvalonEdit.Folding;
namespace Fwk.Controls.Win32.TextCodeEditor
{
    partial class TextCodeEditorHost
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
         
            
            this.SuspendLayout();
            // 
            // host
            // 
           
         
          
            this.Name = "TextCodeEditorHost";
            this.Size = new System.Drawing.Size(536, 338);
            this.ResumeLayout(false);

        }


        
        ICSharpCode.AvalonEdit.TextEditor textEditor ;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem menuItem13;
        private BraceFoldingStrategy foldingStrategy;
        private FoldingManager foldingManager;
        #endregion
        
    }
}
