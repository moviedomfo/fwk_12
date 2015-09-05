namespace Fwk.GuidPk
{
    partial class wizDAC
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ctrlTreeViewTables1 = new Fwk.GuidPk.ctrlTreeViewTables();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGenerationResult = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // infoPanel
            // 
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.None;
            this.infoPanel.Location = new System.Drawing.Point(0, 148);
            this.infoPanel.Margin = new System.Windows.Forms.Padding(5);
            this.infoPanel.Size = new System.Drawing.Size(800, 500);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.ctrlTreeViewTables1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtGenerationResult);
            this.groupBox1.Location = new System.Drawing.Point(7, 96);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(784, 573);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Image = global::Fwk.GuidPk.Properties.Resources.applications_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(323, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(247, 44);
            this.button1.TabIndex = 75;
            this.button1.Text = "Check generation";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctrlTreeViewTables1
            // 
            this.ctrlTreeViewTables1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ctrlTreeViewTables1.CheckBoxes = true;
            this.ctrlTreeViewTables1.Location = new System.Drawing.Point(5, 17);
            this.ctrlTreeViewTables1.Margin = new System.Windows.Forms.Padding(5);
            this.ctrlTreeViewTables1.Name = "ctrlTreeViewTables1";
            this.ctrlTreeViewTables1.SelectedTable = null;
            this.ctrlTreeViewTables1.Size = new System.Drawing.Size(301, 545);
            this.ctrlTreeViewTables1.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(324, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 25);
            this.label1.TabIndex = 69;
            this.label1.Text = "Generation logs";
            // 
            // txtGenerationResult
            // 
            this.txtGenerationResult.BackColor = System.Drawing.Color.White;
            this.txtGenerationResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGenerationResult.ForeColor = System.Drawing.SystemColors.Control;
            this.txtGenerationResult.Location = new System.Drawing.Point(323, 111);
            this.txtGenerationResult.Margin = new System.Windows.Forms.Padding(4);
            this.txtGenerationResult.Multiline = true;
            this.txtGenerationResult.Name = "txtGenerationResult";
            this.txtGenerationResult.Size = new System.Drawing.Size(453, 424);
            this.txtGenerationResult.TabIndex = 71;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Image = global::Fwk.GuidPk.Properties.Resources.fabrica;
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(805, 92);
            this.lblTitle.TabIndex = 64;
            this.lblTitle.Text = "Set DAC info";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wizDAC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitle);
            this.InfoRTBoxSize = new System.Drawing.Size(461, 74);
            this.Name = "wizDAC";
            this.Size = new System.Drawing.Size(805, 673);
            this.Load += new System.EventHandler(this.wizDAC_Load);
            this.VisibleChanged += new System.EventHandler(this.wizDAC_VisibleChanged);
            this.Controls.SetChildIndex(this.infoPanel, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.TextBox txtGenerationResult;
        private ctrlTreeViewTables ctrlTreeViewTables1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}
