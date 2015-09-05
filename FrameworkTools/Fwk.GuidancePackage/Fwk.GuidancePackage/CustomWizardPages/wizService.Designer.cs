namespace Fwk.GuidPk
{
    partial class wizService
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReq = new System.Windows.Forms.TextBox();
            this.lblSVC = new System.Windows.Forms.Label();
            this.txtBE = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGenerationResult = new System.Windows.Forms.TextBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // infoPanel
            // 
            this.infoPanel.Location = new System.Drawing.Point(0, 207);
            this.infoPanel.Margin = new System.Windows.Forms.Padding(5);
            this.infoPanel.Size = new System.Drawing.Size(892, 393);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtGenerationResult);
            this.groupBox1.Controls.Add(this.btnTestConnection);
            this.groupBox1.Controls.Add(this.txtServiceName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(4, 111);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(884, 485);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtRes);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtReq);
            this.groupBox2.Controls.Add(this.lblSVC);
            this.groupBox2.Controls.Add(this.txtBE);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.groupBox2.Location = new System.Drawing.Point(35, 148);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(751, 144);
            this.groupBox2.TabIndex = 74;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(11, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Response";
            // 
            // txtRes
            // 
            this.txtRes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRes.ForeColor = System.Drawing.Color.Black;
            this.txtRes.Location = new System.Drawing.Point(128, 96);
            this.txtRes.Margin = new System.Windows.Forms.Padding(4);
            this.txtRes.Name = "txtRes";
            this.txtRes.ReadOnly = true;
            this.txtRes.Size = new System.Drawing.Size(577, 23);
            this.txtRes.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(11, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Request";
            // 
            // txtReq
            // 
            this.txtReq.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReq.ForeColor = System.Drawing.Color.Black;
            this.txtReq.Location = new System.Drawing.Point(128, 64);
            this.txtReq.Margin = new System.Windows.Forms.Padding(4);
            this.txtReq.Name = "txtReq";
            this.txtReq.ReadOnly = true;
            this.txtReq.Size = new System.Drawing.Size(577, 23);
            this.txtReq.TabIndex = 10;
            // 
            // lblSVC
            // 
            this.lblSVC.AutoSize = true;
            this.lblSVC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSVC.ForeColor = System.Drawing.Color.DimGray;
            this.lblSVC.Location = new System.Drawing.Point(11, 30);
            this.lblSVC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSVC.Name = "lblSVC";
            this.lblSVC.Size = new System.Drawing.Size(70, 20);
            this.lblSVC.TabIndex = 12;
            this.lblSVC.Text = "Service ";
            // 
            // txtBE
            // 
            this.txtBE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtBE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBE.ForeColor = System.Drawing.Color.Black;
            this.txtBE.Location = new System.Drawing.Point(128, 26);
            this.txtBE.Margin = new System.Windows.Forms.Padding(4);
            this.txtBE.Name = "txtBE";
            this.txtBE.ReadOnly = true;
            this.txtBE.Size = new System.Drawing.Size(577, 23);
            this.txtBE.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(32, 111);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 25);
            this.label1.TabIndex = 72;
            this.label1.Text = "Generation class";
            // 
            // txtGenerationResult
            // 
            this.txtGenerationResult.BackColor = System.Drawing.Color.White;
            this.txtGenerationResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGenerationResult.ForeColor = System.Drawing.SystemColors.Control;
            this.txtGenerationResult.Location = new System.Drawing.Point(35, 356);
            this.txtGenerationResult.Margin = new System.Windows.Forms.Padding(4);
            this.txtGenerationResult.Multiline = true;
            this.txtGenerationResult.Name = "txtGenerationResult";
            this.txtGenerationResult.Size = new System.Drawing.Size(719, 62);
            this.txtGenerationResult.TabIndex = 73;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestConnection.BackColor = System.Drawing.Color.SlateGray;
            this.btnTestConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestConnection.ForeColor = System.Drawing.SystemColors.Info;
            this.btnTestConnection.Location = new System.Drawing.Point(43, 160);
            this.btnTestConnection.Margin = new System.Windows.Forms.Padding(4);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(149, 30);
            this.btnTestConnection.TabIndex = 61;
            this.btnTestConnection.Text = "Check generation";
            this.btnTestConnection.UseVisualStyleBackColor = false;
            this.btnTestConnection.Visible = false;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // txtServiceName
            // 
            this.txtServiceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServiceName.ForeColor = System.Drawing.Color.Maroon;
            this.txtServiceName.Location = new System.Drawing.Point(163, 50);
            this.txtServiceName.Margin = new System.Windows.Forms.Padding(4);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(517, 22);
            this.txtServiceName.TabIndex = 55;
            this.txtServiceName.TextChanged += new System.EventHandler(this.txtServiceName_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(32, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 22);
            this.label2.TabIndex = 54;
            this.label2.Text = "Service name";
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
            this.lblTitle.Size = new System.Drawing.Size(892, 92);
            this.lblTitle.TabIndex = 64;
            this.lblTitle.Text = "Set service info";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wizService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupBox1);
            this.InfoRTBoxSize = new System.Drawing.Size(661, 74);
            this.Name = "wizService";
            this.Size = new System.Drawing.Size(892, 600);
            this.Load += new System.EventHandler(this.wizService_Load);
            this.Controls.SetChildIndex(this.infoPanel, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtGenerationResult;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtReq;
        private System.Windows.Forms.Label lblSVC;
        private System.Windows.Forms.TextBox txtBE;
    }
}
