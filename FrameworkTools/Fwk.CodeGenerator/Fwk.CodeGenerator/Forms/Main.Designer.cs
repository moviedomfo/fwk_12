namespace Fwk.CodeGenerator
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.generatosFormsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backEndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servicesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToStringBuilderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigurationLibrariesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDAC = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEntity = new System.Windows.Forms.ToolStripMenuItem();
            this.servicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanel1 = new Fwk.Controls.Win32.DockPanel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generatosFormsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.toolStripMenuItemDAC,
            this.toolStripMenuItemEntity,
            this.servicesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(873, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // generatosFormsToolStripMenuItem
            // 
            this.generatosFormsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backEndToolStripMenuItem,
            this.entitiesToolStripMenuItem,
            this.servicesToolStripMenuItem1});
            this.generatosFormsToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.generatosFormsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.generatosFormsToolStripMenuItem.Image = global::Fwk.CodeGenerator.Properties.Resources.apps_16;
            this.generatosFormsToolStripMenuItem.Name = "generatosFormsToolStripMenuItem";
            this.generatosFormsToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.generatosFormsToolStripMenuItem.Text = "Generatos ";
            // 
            // backEndToolStripMenuItem
            // 
            this.backEndToolStripMenuItem.Image = global::Fwk.CodeGenerator.Properties.Resources.SchemaDataSourceOk2;
            this.backEndToolStripMenuItem.Name = "backEndToolStripMenuItem";
            this.backEndToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.backEndToolStripMenuItem.Text = "BackEnd";
            this.backEndToolStripMenuItem.Click += new System.EventHandler(this.backEndToolStripMenuItem_Click);
            // 
            // entitiesToolStripMenuItem
            // 
            this.entitiesToolStripMenuItem.Image = global::Fwk.CodeGenerator.Properties.Resources.WindowsHS;
            this.entitiesToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.entitiesToolStripMenuItem.Name = "entitiesToolStripMenuItem";
            this.entitiesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.entitiesToolStripMenuItem.Text = "Entities";
            this.entitiesToolStripMenuItem.Click += new System.EventHandler(this.entitiesToolStripMenuItem_Click);
            // 
            // servicesToolStripMenuItem1
            // 
            this.servicesToolStripMenuItem1.Image = global::Fwk.CodeGenerator.Properties.Resources.web_16;
            this.servicesToolStripMenuItem1.Name = "servicesToolStripMenuItem1";
            this.servicesToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.servicesToolStripMenuItem1.Text = "Services";
            this.servicesToolStripMenuItem1.Click += new System.EventHandler(this.servicesToolStripMenuItem1_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textToStringBuilderToolStripMenuItem,
            this.ConfigurationLibrariesToolStripMenuItem,
            this.customizeTemplateToolStripMenuItem});
            this.toolsToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolsToolStripMenuItem.Image = global::Fwk.CodeGenerator.Properties.Resources.tools_16;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // textToStringBuilderToolStripMenuItem
            // 
            this.textToStringBuilderToolStripMenuItem.Image = global::Fwk.CodeGenerator.Properties.Resources.textdoc;
            this.textToStringBuilderToolStripMenuItem.Name = "textToStringBuilderToolStripMenuItem";
            this.textToStringBuilderToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.textToStringBuilderToolStripMenuItem.Text = "Text to StringBuilder";
            this.textToStringBuilderToolStripMenuItem.Click += new System.EventHandler(this.textToStringBuilderToolStripMenuItem_Click);
            // 
            // ConfigurationLibrariesToolStripMenuItem
            // 
            this.ConfigurationLibrariesToolStripMenuItem.Image = global::Fwk.CodeGenerator.Properties.Resources.Web_XML;
            this.ConfigurationLibrariesToolStripMenuItem.Name = "ConfigurationLibrariesToolStripMenuItem";
            this.ConfigurationLibrariesToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.ConfigurationLibrariesToolStripMenuItem.Text = " configuration libraries";
            this.ConfigurationLibrariesToolStripMenuItem.Click += new System.EventHandler(this.ConfigurationLibrariesToolStripMenuItem_Click);
            // 
            // customizeTemplateToolStripMenuItem
            // 
            this.customizeTemplateToolStripMenuItem.Image = global::Fwk.CodeGenerator.Properties.Resources.SetDef32;
            this.customizeTemplateToolStripMenuItem.Name = "customizeTemplateToolStripMenuItem";
            this.customizeTemplateToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.customizeTemplateToolStripMenuItem.Text = "Customize Template";
            this.customizeTemplateToolStripMenuItem.Click += new System.EventHandler(this.customizeTemplateToolStripMenuItem_Click);
            // 
            // toolStripMenuItemDAC
            // 
            this.toolStripMenuItemDAC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItemDAC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItemDAC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripMenuItemDAC.Image = global::Fwk.CodeGenerator.Properties.Resources.SchemaDataSourceOk2;
            this.toolStripMenuItemDAC.Name = "toolStripMenuItemDAC";
            this.toolStripMenuItemDAC.Size = new System.Drawing.Size(28, 20);
            this.toolStripMenuItemDAC.Text = "Generate BackEnd";
            this.toolStripMenuItemDAC.ToolTipText = "Generate BackEnd";
            this.toolStripMenuItemDAC.Click += new System.EventHandler(this.toolStripMenuItemDAC_Click);
            // 
            // toolStripMenuItemEntity
            // 
            this.toolStripMenuItemEntity.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItemEntity.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItemEntity.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripMenuItemEntity.Image = global::Fwk.CodeGenerator.Properties.Resources.WindowsHS;
            this.toolStripMenuItemEntity.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripMenuItemEntity.Name = "toolStripMenuItemEntity";
            this.toolStripMenuItemEntity.Size = new System.Drawing.Size(28, 20);
            this.toolStripMenuItemEntity.Text = "Generate Entity";
            this.toolStripMenuItemEntity.ToolTipText = "Generate Entity";
            this.toolStripMenuItemEntity.Click += new System.EventHandler(this.toolStripMenuItemEntity_Click);
            // 
            // servicesToolStripMenuItem
            // 
            this.servicesToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.servicesToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.servicesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.servicesToolStripMenuItem.Image = global::Fwk.CodeGenerator.Properties.Resources.web_16;
            this.servicesToolStripMenuItem.Name = "servicesToolStripMenuItem";
            this.servicesToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.servicesToolStripMenuItem.Text = "Services";
            this.servicesToolStripMenuItem.ToolTipText = "Generate Services ";
            this.servicesToolStripMenuItem.Click += new System.EventHandler(this.servicesToolStripMenuItem_Click);
            // 
            // dockPanel1
            // 
            this.dockPanel1.ActiveAutoHideContent = null;
            this.dockPanel1.BackColor = System.Drawing.Color.Transparent;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(873, 460);
            this.dockPanel1.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(873, 460);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dockPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Code generator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDAC;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEntity;
        private System.Windows.Forms.ToolStripMenuItem servicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textToStringBuilderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConfigurationLibrariesToolStripMenuItem;
        private Fwk.Controls.Win32.DockPanel dockPanel1;
        private System.Windows.Forms.ToolStripMenuItem customizeTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatosFormsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backEndToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem servicesToolStripMenuItem1;
    }
}