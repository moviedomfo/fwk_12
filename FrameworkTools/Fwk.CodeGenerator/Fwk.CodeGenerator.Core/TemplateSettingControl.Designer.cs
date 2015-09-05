namespace Fwk.CodeGenerator
{
    partial class TemplateSettingControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateSettingControl));
            this.PropertyGridTempleteSetting = new System.Windows.Forms.PropertyGrid();
            this.toolStripAppClientConfig = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.SaveAstoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTemplate = new System.Windows.Forms.Label();
            this.toolStripAppClientConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // PropertyGridTempleteSetting
            // 
            this.PropertyGridTempleteSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyGridTempleteSetting.BackColor = System.Drawing.Color.LightSteelBlue;
            this.PropertyGridTempleteSetting.HelpBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PropertyGridTempleteSetting.Location = new System.Drawing.Point(3, 42);
            this.PropertyGridTempleteSetting.Name = "PropertyGridTempleteSetting";
            this.PropertyGridTempleteSetting.Size = new System.Drawing.Size(268, 308);
            this.PropertyGridTempleteSetting.TabIndex = 11;
            this.PropertyGridTempleteSetting.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PropertyGridTempleteSetting_PropertyValueChanged);
            // 
            // toolStripAppClientConfig
            // 
            this.toolStripAppClientConfig.BackColor = System.Drawing.Color.LightGray;
            this.toolStripAppClientConfig.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripAppClientConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton1,
            this.openToolStripButton1,
            this.saveToolStripButton1,
            this.SaveAstoolStripButton,
            this.toolStripSeparator1});
            this.toolStripAppClientConfig.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripAppClientConfig.Location = new System.Drawing.Point(0, 0);
            this.toolStripAppClientConfig.Name = "toolStripAppClientConfig";
            this.toolStripAppClientConfig.Size = new System.Drawing.Size(274, 23);
            this.toolStripAppClientConfig.TabIndex = 12;
            this.toolStripAppClientConfig.Text = "toolStrip1";
            // 
            // newToolStripButton1
            // 
            this.newToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton1.Image")));
            this.newToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton1.Name = "newToolStripButton1";
            this.newToolStripButton1.Size = new System.Drawing.Size(23, 20);
            this.newToolStripButton1.Text = "&New";
            this.newToolStripButton1.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // openToolStripButton1
            // 
            this.openToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton1.Image")));
            this.openToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton1.Name = "openToolStripButton1";
            this.openToolStripButton1.Size = new System.Drawing.Size(23, 20);
            this.openToolStripButton1.Text = "&Open";
            this.openToolStripButton1.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // saveToolStripButton1
            // 
            this.saveToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton1.Image")));
            this.saveToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton1.Name = "saveToolStripButton1";
            this.saveToolStripButton1.Size = new System.Drawing.Size(23, 20);
            this.saveToolStripButton1.Text = "&Save";
            this.saveToolStripButton1.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // SaveAstoolStripButton
            // 
            this.SaveAstoolStripButton.BackColor = System.Drawing.Color.Transparent;
            this.SaveAstoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveAstoolStripButton.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.SaveAstoolStripButton.Name = "SaveAstoolStripButton";
            this.SaveAstoolStripButton.Size = new System.Drawing.Size(23, 4);
            this.SaveAstoolStripButton.Text = "Save As";
            this.SaveAstoolStripButton.Click += new System.EventHandler(this.SaveAstoolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // lblTemplate
            // 
            this.lblTemplate.AutoSize = true;
            this.lblTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemplate.ForeColor = System.Drawing.Color.OldLace;
            this.lblTemplate.Location = new System.Drawing.Point(3, 26);
            this.lblTemplate.Name = "lblTemplate";
            this.lblTemplate.Size = new System.Drawing.Size(63, 13);
            this.lblTemplate.TabIndex = 13;
            this.lblTemplate.Text = "Template:";
            // 
            // GenTemplateSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.lblTemplate);
            this.Controls.Add(this.toolStripAppClientConfig);
            this.Controls.Add(this.PropertyGridTempleteSetting);
            this.Name = "GenTemplateSetting";
            this.Size = new System.Drawing.Size(274, 353);
            this.Load += new System.EventHandler(this.GenTemplateSetting_Load);
            this.toolStripAppClientConfig.ResumeLayout(false);
            this.toolStripAppClientConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid PropertyGridTempleteSetting;
        private System.Windows.Forms.ToolStrip toolStripAppClientConfig;
        private System.Windows.Forms.ToolStripButton SaveAstoolStripButton;
        private System.Windows.Forms.ToolStripButton newToolStripButton1;
        private System.Windows.Forms.ToolStripButton openToolStripButton1;
        private System.Windows.Forms.ToolStripButton saveToolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label lblTemplate;
    }
}
