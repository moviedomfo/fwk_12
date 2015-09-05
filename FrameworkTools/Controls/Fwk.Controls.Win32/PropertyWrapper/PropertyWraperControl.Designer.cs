namespace Fwk.Controls.Win32.PropertyWrapper
{
    partial class PropertyWraperControl
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
            this.PropertySetting = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // PropertyGridTempleteSetting
            // 
            this.PropertySetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertySetting.BackColor = System.Drawing.Color.LightSteelBlue;
            this.PropertySetting.HelpBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PropertySetting.Location = new System.Drawing.Point(0, 0);
            this.PropertySetting.Name = "PropertySetting";
            this.PropertySetting.Size = new System.Drawing.Size(288, 326);
            this.PropertySetting.TabIndex = 12;
            // 
            // PropertyWraperControl
            // 
            this.Controls.Add(this.PropertySetting);
            this.Name = "PropertyWraperControl";
            this.Size = new System.Drawing.Size(294, 329);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid PropertySetting;

    }
}
