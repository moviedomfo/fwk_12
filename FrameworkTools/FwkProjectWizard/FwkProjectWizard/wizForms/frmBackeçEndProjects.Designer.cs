namespace Fwk.Wizard
{
    partial class frmBackeçEndProjects
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackeçEndProjects));
            this.button1 = new System.Windows.Forms.Button();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSVC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtISVC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDAC = new System.Windows.Forms.TextBox();
            this.lblBENamespace = new System.Windows.Forms.Label();
            this.txtBE = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkUseStatics = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(449, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtProjectName
            // 
            this.txtProjectName.BackColor = System.Drawing.Color.White;
            this.txtProjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProjectName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtProjectName.Location = new System.Drawing.Point(12, 27);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.ReadOnly = true;
            this.txtProjectName.Size = new System.Drawing.Size(358, 20);
            this.txtProjectName.TabIndex = 33;
            this.txtProjectName.TextChanged += new System.EventHandler(this.txtProjectName_TextChanged);
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectName.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblProjectName.Location = new System.Drawing.Point(12, 9);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(92, 15);
            this.lblProjectName.TabIndex = 3;
            this.lblProjectName.Text = "Project name";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSVC);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtISVC);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBC);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDAC);
            this.groupBox1.Controls.Add(this.lblBENamespace);
            this.groupBox1.Controls.Add(this.txtBE);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.groupBox1.Location = new System.Drawing.Point(12, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 226);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Namespase";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "SVC";
            // 
            // txtSVC
            // 
            this.txtSVC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSVC.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtSVC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSVC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSVC.ForeColor = System.Drawing.Color.SlateGray;
            this.txtSVC.Location = new System.Drawing.Point(96, 139);
            this.txtSVC.Name = "txtSVC";
            this.txtSVC.ReadOnly = true;
            this.txtSVC.Size = new System.Drawing.Size(458, 20);
            this.txtSVC.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "ISVC";
            // 
            // txtISVC
            // 
            this.txtISVC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtISVC.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtISVC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtISVC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtISVC.ForeColor = System.Drawing.Color.SlateGray;
            this.txtISVC.Location = new System.Drawing.Point(96, 113);
            this.txtISVC.Name = "txtISVC";
            this.txtISVC.ReadOnly = true;
            this.txtISVC.Size = new System.Drawing.Size(458, 20);
            this.txtISVC.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "BC";
            // 
            // txtBC
            // 
            this.txtBC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBC.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtBC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBC.ForeColor = System.Drawing.Color.SlateGray;
            this.txtBC.Location = new System.Drawing.Point(96, 78);
            this.txtBC.Name = "txtBC";
            this.txtBC.ReadOnly = true;
            this.txtBC.Size = new System.Drawing.Size(458, 20);
            this.txtBC.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "DAC";
            // 
            // txtDAC
            // 
            this.txtDAC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDAC.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtDAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDAC.ForeColor = System.Drawing.Color.SlateGray;
            this.txtDAC.Location = new System.Drawing.Point(96, 52);
            this.txtDAC.Name = "txtDAC";
            this.txtDAC.ReadOnly = true;
            this.txtDAC.Size = new System.Drawing.Size(458, 20);
            this.txtDAC.TabIndex = 10;
            // 
            // lblBENamespace
            // 
            this.lblBENamespace.AutoSize = true;
            this.lblBENamespace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBENamespace.Location = new System.Drawing.Point(8, 24);
            this.lblBENamespace.Name = "lblBENamespace";
            this.lblBENamespace.Size = new System.Drawing.Size(21, 13);
            this.lblBENamespace.TabIndex = 12;
            this.lblBENamespace.Text = "BE";
            // 
            // txtBE
            // 
            this.txtBE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBE.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtBE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBE.ForeColor = System.Drawing.Color.SlateGray;
            this.txtBE.Location = new System.Drawing.Point(96, 21);
            this.txtBE.Name = "txtBE";
            this.txtBE.ReadOnly = true;
            this.txtBE.Size = new System.Drawing.Size(458, 20);
            this.txtBE.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(380, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Ingrese aqui";
            // 
            // chkUseStatics
            // 
            this.chkUseStatics.AutoSize = true;
            this.chkUseStatics.Checked = true;
            this.chkUseStatics.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseStatics.Location = new System.Drawing.Point(24, 58);
            this.chkUseStatics.Name = "chkUseStatics";
            this.chkUseStatics.Size = new System.Drawing.Size(131, 17);
            this.chkUseStatics.TabIndex = 37;
            this.chkUseStatics.Text = " Use StaticsLibs folder";
            this.chkUseStatics.UseVisualStyleBackColor = true;
            // 
            // frmBackeçEndProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(612, 404);
            this.Controls.Add(this.chkUseStatics);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblProjectName);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBackeçEndProjects";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BackEnd component project  ";
            this.Load += new System.EventHandler(this.FrmBusinessComponents_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDAC;
        private System.Windows.Forms.Label lblBENamespace;
        private System.Windows.Forms.TextBox txtBE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSVC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtISVC;
        private System.Windows.Forms.CheckBox chkUseStatics;
    }
}