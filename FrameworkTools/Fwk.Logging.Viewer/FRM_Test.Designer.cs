namespace Fwk.Logging.Viewer
{
    partial class FRM_Test
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
            this.btnGetLoggingConfiguration = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetLoggingConfiguration
            // 
            this.btnGetLoggingConfiguration.Location = new System.Drawing.Point(0, 0);
            this.btnGetLoggingConfiguration.Name = "btnGetLoggingConfiguration";
            this.btnGetLoggingConfiguration.Size = new System.Drawing.Size(293, 23);
            this.btnGetLoggingConfiguration.TabIndex = 1;
            this.btnGetLoggingConfiguration.Text = "GetLoggingConfiguration";
            this.btnGetLoggingConfiguration.UseVisualStyleBackColor = true;
            this.btnGetLoggingConfiguration.Click += new System.EventHandler(this.btnGetLoggingConfiguration_Click);
            // 
            // FRM_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.btnGetLoggingConfiguration);
            this.Name = "FRM_Test";
            this.Text = "FRM_Test";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetLoggingConfiguration;
    }
}