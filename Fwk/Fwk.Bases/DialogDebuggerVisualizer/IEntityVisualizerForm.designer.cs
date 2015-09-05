namespace Fwk.Bases.Debug
{
    partial class IEntityVisualizerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IEntityVisualizerForm));
            this.lblNmaespace = new System.Windows.Forms.Label();
            this.txtXml = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabXmlEntity = new System.Windows.Forms.TabPage();
            this.tabAutoFill = new System.Windows.Forms.TabPage();
            this.txtXmlSample = new System.Windows.Forms.TextBox();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.mnuToolBar = new System.Windows.Forms.MenuStrip();
            this.mnuCerrar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopiar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMail = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.tabXmlEntity.SuspendLayout();
            this.tabAutoFill.SuspendLayout();
            this.mnuToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNmaespace
            // 
            this.lblNmaespace.AutoSize = true;
            this.lblNmaespace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNmaespace.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNmaespace.Location = new System.Drawing.Point(5, 26);
            this.lblNmaespace.Name = "lblNmaespace";
            this.lblNmaespace.Size = new System.Drawing.Size(73, 13);
            this.lblNmaespace.TabIndex = 3;
            this.lblNmaespace.Text = "Namespace";
            // 
            // txtXml
            // 
            this.txtXml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXml.BackColor = System.Drawing.Color.White;
            this.txtXml.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtXml.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtXml.Location = new System.Drawing.Point(6, 6);
            this.txtXml.Multiline = true;
            this.txtXml.Name = "txtXml";
            this.txtXml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtXml.Size = new System.Drawing.Size(712, 402);
            this.txtXml.TabIndex = 6;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabXmlEntity);
            this.tabControl.Controls.Add(this.tabAutoFill);
            this.tabControl.Location = new System.Drawing.Point(2, 49);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(732, 440);
            this.tabControl.TabIndex = 7;
            // 
            // tabXmlEntity
            // 
            this.tabXmlEntity.Controls.Add(this.txtXml);
            this.tabXmlEntity.Location = new System.Drawing.Point(4, 22);
            this.tabXmlEntity.Name = "tabXmlEntity";
            this.tabXmlEntity.Padding = new System.Windows.Forms.Padding(3);
            this.tabXmlEntity.Size = new System.Drawing.Size(724, 414);
            this.tabXmlEntity.TabIndex = 0;
            this.tabXmlEntity.Text = "Entity Xml";
            this.tabXmlEntity.UseVisualStyleBackColor = true;
            // 
            // tabAutoFill
            // 
            this.tabAutoFill.Controls.Add(this.txtXmlSample);
            this.tabAutoFill.Location = new System.Drawing.Point(4, 22);
            this.tabAutoFill.Name = "tabAutoFill";
            this.tabAutoFill.Padding = new System.Windows.Forms.Padding(3);
            this.tabAutoFill.Size = new System.Drawing.Size(724, 414);
            this.tabAutoFill.TabIndex = 1;
            this.tabAutoFill.Text = "Entity sample";
            this.tabAutoFill.UseVisualStyleBackColor = true;
            // 
            // txtXmlSample
            // 
            this.txtXmlSample.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXmlSample.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtXmlSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtXmlSample.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtXmlSample.Location = new System.Drawing.Point(6, 6);
            this.txtXmlSample.Multiline = true;
            this.txtXmlSample.Name = "txtXmlSample";
            this.txtXmlSample.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtXmlSample.Size = new System.Drawing.Size(712, 376);
            this.txtXmlSample.TabIndex = 7;
            // 
            // txtNamespace
            // 
            this.txtNamespace.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtNamespace.Location = new System.Drawing.Point(92, 23);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(381, 20);
            this.txtNamespace.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Location = new System.Drawing.Point(577, 26);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save in xml file";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // mnuToolBar
            // 
            this.mnuToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCerrar,
            this.mnuCopiar,
            this.mnuSave,
            this.mnuMail});
            this.mnuToolBar.Location = new System.Drawing.Point(0, 0);
            this.mnuToolBar.Name = "mnuToolBar";
            this.mnuToolBar.ShowItemToolTips = true;
            this.mnuToolBar.Size = new System.Drawing.Size(746, 24);
            this.mnuToolBar.TabIndex = 9;
            this.mnuToolBar.Text = "menuStrip1";
            // 
            // mnuCerrar
            // 
            this.mnuCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuCerrar.Image = global::Fwk.Bases.Properties.Resources.cancel;
            this.mnuCerrar.Name = "mnuCerrar";
            this.mnuCerrar.Size = new System.Drawing.Size(28, 20);
            this.mnuCerrar.Text = "Close";
            this.mnuCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mnuCerrar.ToolTipText = "Close";
            this.mnuCerrar.Click += new System.EventHandler(this.mnuCerrar_Click);
            // 
            // mnuCopiar
            // 
            this.mnuCopiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuCopiar.Image = global::Fwk.Bases.Properties.Resources.copy;
            this.mnuCopiar.Name = "mnuCopiar";
            this.mnuCopiar.Size = new System.Drawing.Size(28, 20);
            this.mnuCopiar.Text = "Copy to clipboard";
            this.mnuCopiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mnuCopiar.ToolTipText = "Copy to clipboard";
            this.mnuCopiar.Click += new System.EventHandler(this.mnuCopiar_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuSave.Image = global::Fwk.Bases.Properties.Resources.save;
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(28, 20);
            this.mnuSave.Text = "Save to file";
            this.mnuSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mnuSave.ToolTipText = "Save to file";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuMail
            // 
            this.mnuMail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuMail.Image = global::Fwk.Bases.Properties.Resources.mail_16;
            this.mnuMail.Name = "mnuMail";
            this.mnuMail.Size = new System.Drawing.Size(28, 20);
            this.mnuMail.Text = "Mail";
            this.mnuMail.ToolTipText = "Send e-mail";
            this.mnuMail.Click += new System.EventHandler(this.mnuMail_Click);
            // 
            // IEntityVisualizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(746, 501);
            this.Controls.Add(this.mnuToolBar);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lblNmaespace);
            this.Controls.Add(this.txtNamespace);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "IEntityVisualizerForm";
            this.Text = "Fwk IEntiy Debug Info";
            this.tabControl.ResumeLayout(false);
            this.tabXmlEntity.ResumeLayout(false);
            this.tabXmlEntity.PerformLayout();
            this.tabAutoFill.ResumeLayout(false);
            this.tabAutoFill.PerformLayout();
            this.mnuToolBar.ResumeLayout(false);
            this.mnuToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNmaespace;
        private System.Windows.Forms.TextBox txtXml;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabXmlEntity;
        private System.Windows.Forms.TabPage tabAutoFill;
        private System.Windows.Forms.TextBox txtXmlSample;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip mnuToolBar;
        private System.Windows.Forms.ToolStripMenuItem mnuCerrar;
        private System.Windows.Forms.ToolStripMenuItem mnuCopiar;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuMail;
    }
}