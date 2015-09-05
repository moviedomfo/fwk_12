namespace Fwk.Bases.FrontEnd.Controls
{
    /// <summary>
    /// 
    /// </summary>
    partial class FrmExceptionView
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
            this.mnuToolBar = new System.Windows.Forms.MenuStrip();
            this.mnuCerrar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExpandir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopiar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMail = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.imgIcon = new System.Windows.Forms.PictureBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.imgFormExpansion = new System.Windows.Forms.ImageList(this.components);
            this.lblSource = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblDetail = new System.Windows.Forms.Label();
            this.pnlFill.SuspendLayout();
            this.mnuToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFill
            // 
            this.pnlFill.BackColor = System.Drawing.Color.White;
            this.pnlFill.Controls.Add(this.lblDetail);
            this.pnlFill.Controls.Add(this.lblMessage);
            this.pnlFill.Controls.Add(this.lblSource);
            this.pnlFill.Controls.Add(this.txtDetail);
            this.pnlFill.Controls.Add(this.txtMessage);
            this.pnlFill.Controls.Add(this.txtSource);
            this.pnlFill.Controls.Add(this.imgIcon);
            this.pnlFill.Controls.Add(this.mnuToolBar);
            this.pnlFill.Size = new System.Drawing.Size(352, 176);
            // 
            // mnuToolBar
            // 
            this.mnuToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCerrar,
            this.mnuExpandir,
            this.mnuCopiar,
            this.mnuSave,
            this.mnuMail});
            this.mnuToolBar.Location = new System.Drawing.Point(0, 0);
            this.mnuToolBar.Name = "mnuToolBar";
            this.mnuToolBar.ShowItemToolTips = true;
            this.mnuToolBar.Size = new System.Drawing.Size(350, 24);
            this.mnuToolBar.TabIndex = 0;
            this.mnuToolBar.Text = "menuStrip1";
            // 
            // mnuCerrar
            // 
            this.mnuCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuCerrar.Image = global::Fwk.Bases.FrontEnd.ImagesResource.close_16;
            this.mnuCerrar.Name = "mnuCerrar";
            this.mnuCerrar.Size = new System.Drawing.Size(28, 20);
            this.mnuCerrar.Text = "Cerrar";
            this.mnuCerrar.ToolTipText = "Cerrar...";
            this.mnuCerrar.Click += new System.EventHandler(this.mnuCerrar_Click);
            // 
            // mnuExpandir
            // 
            this.mnuExpandir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuExpandir.Image = global::Fwk.Bases.FrontEnd.Properties.Resources.MaxImage;
            this.mnuExpandir.Name = "mnuExpandir";
            this.mnuExpandir.Size = new System.Drawing.Size(28, 20);
            this.mnuExpandir.Text = "Expandir";
            this.mnuExpandir.ToolTipText = "Ver detalle...";
            this.mnuExpandir.Click += new System.EventHandler(this.mnuExpandir_Click);
            // 
            // mnuCopiar
            // 
            this.mnuCopiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuCopiar.Image = global::Fwk.Bases.FrontEnd.Properties.Resources.copy_16;
            this.mnuCopiar.Name = "mnuCopiar";
            this.mnuCopiar.Size = new System.Drawing.Size(28, 20);
            this.mnuCopiar.Text = "Copiar";
            this.mnuCopiar.ToolTipText = "Copiar al portapapeles...";
            this.mnuCopiar.Click += new System.EventHandler(this.mnuCopiar_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuSave.Image = global::Fwk.Bases.FrontEnd.ImagesResource.save_16;
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(28, 20);
            this.mnuSave.Text = "Guardar";
            this.mnuSave.ToolTipText = "Guardar...";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuMail
            // 
            this.mnuMail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuMail.Image = global::Fwk.Bases.FrontEnd.Properties.Resources.mail_16;
            this.mnuMail.Name = "mnuMail";
            this.mnuMail.Size = new System.Drawing.Size(28, 20);
            this.mnuMail.Text = "Mail";
            this.mnuMail.ToolTipText = "Enviar por mail...";
            this.mnuMail.Click += new System.EventHandler(this.mnuMail_Click);
            // 
            // txtSource
            // 
            this.txtSource.BackColor = System.Drawing.Color.White;
            this.txtSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSource.Location = new System.Drawing.Point(111, 33);
            this.txtSource.Name = "txtSource";
            this.txtSource.ReadOnly = true;
            this.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSource.Size = new System.Drawing.Size(216, 13);
            this.txtSource.TabIndex = 16;
            // 
            // imgIcon
            // 
            this.imgIcon.Image = global::Fwk.Bases.FrontEnd.ImagesResource.close_32;
            this.imgIcon.Location = new System.Drawing.Point(6, 29);
            this.imgIcon.Name = "imgIcon";
            this.imgIcon.Size = new System.Drawing.Size(45, 78);
            this.imgIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgIcon.TabIndex = 15;
            this.imgIcon.TabStop = false;
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.BackColor = System.Drawing.Color.White;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Location = new System.Drawing.Point(57, 64);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(284, 102);
            this.txtMessage.TabIndex = 17;
            // 
            // txtDetail
            // 
            this.txtDetail.BackColor = System.Drawing.Color.White;
            this.txtDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDetail.Location = new System.Drawing.Point(13, 190);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.ReadOnly = true;
            this.txtDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetail.Size = new System.Drawing.Size(328, 129);
            this.txtDetail.TabIndex = 18;
            // 
            // imgFormExpansion
            // 
            this.imgFormExpansion.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgFormExpansion.ImageSize = new System.Drawing.Size(16, 16);
            this.imgFormExpansion.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource.Location = new System.Drawing.Point(61, 31);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(44, 13);
            this.lblSource.TabIndex = 19;
            this.lblSource.Text = "Origen";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(61, 48);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(54, 13);
            this.lblMessage.TabIndex = 20;
            this.lblMessage.Text = "Mensaje";
            // 
            // lblDetail
            // 
            this.lblDetail.AutoSize = true;
            this.lblDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetail.Location = new System.Drawing.Point(11, 173);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(47, 13);
            this.lblDetail.TabIndex = 21;
            this.lblDetail.Text = "Detalle";
            // 
            // FrmExceptionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 176);
            this.MainMenuStrip = this.mnuToolBar;
            this.Name = "FrmExceptionView";
            this.Text = "FrmTechnicalMsg";
            this.Load += new System.EventHandler(this.FrmTechnicalMsg_Load);
            this.pnlFill.ResumeLayout(false);
            this.pnlFill.PerformLayout();
            this.mnuToolBar.ResumeLayout(false);
            this.mnuToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuToolBar;
        private System.Windows.Forms.ToolStripMenuItem mnuCerrar;
        private System.Windows.Forms.ToolStripMenuItem mnuExpandir;
        private System.Windows.Forms.ToolStripMenuItem mnuCopiar;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuMail;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.PictureBox imgIcon;
        private System.Windows.Forms.ImageList imgFormExpansion;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.Label lblMessage;
    }
}