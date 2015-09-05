namespace TEST
{
    partial class Form1
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
            this.textCodeEditor1 = new Fwk.Controls.Win32.TextCodeEditor.TextCodeEditor();
            this.SuspendLayout();
            // 
            // textCodeEditor1
            // 
            this.textCodeEditor1.Location = new System.Drawing.Point(47, 75);
            this.textCodeEditor1.Name = "textCodeEditor1";
            this.textCodeEditor1.Size = new System.Drawing.Size(669, 450);
            this.textCodeEditor1.TabIndex = 0;
            this.textCodeEditor1.TitleText = "";
            this.textCodeEditor1.TitleVisible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 609);
            this.Controls.Add(this.textCodeEditor1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Fwk.Controls.Win32.TextCodeEditor.TextCodeEditor textCodeEditor1;
    }
}

