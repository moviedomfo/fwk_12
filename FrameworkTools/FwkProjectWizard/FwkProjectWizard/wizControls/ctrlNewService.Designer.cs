namespace Fwk.Wizard
{
    partial class ctrlNewService
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
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReq = new System.Windows.Forms.TextBox();
            this.lblSVC = new System.Windows.Forms.Label();
            this.txtBE = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Nuevo servicio SVC";
            // 
            // btnCancel
            // 
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnNext
            // 
            this.btnNext.Visible = false;
            // 
            // btnBack
            // 
            this.btnBack.Visible = false;
            // 
            // txtServiceName
            // 
            this.txtServiceName.Location = new System.Drawing.Point(131, 110);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(348, 20);
            this.txtServiceName.TabIndex = 69;
            this.txtServiceName.TextChanged += new System.EventHandler(this.txtServiceName_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtRes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtReq);
            this.groupBox1.Controls.Add(this.lblSVC);
            this.groupBox1.Controls.Add(this.txtBE);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.groupBox1.Location = new System.Drawing.Point(19, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 142);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clases";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Response";
            // 
            // txtRes
            // 
            this.txtRes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRes.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRes.ForeColor = System.Drawing.Color.SlateGray;
            this.txtRes.Location = new System.Drawing.Point(96, 78);
            this.txtRes.Name = "txtRes";
            this.txtRes.ReadOnly = true;
            this.txtRes.Size = new System.Drawing.Size(458, 20);
            this.txtRes.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Request";
            // 
            // txtReq
            // 
            this.txtReq.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReq.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReq.ForeColor = System.Drawing.Color.SlateGray;
            this.txtReq.Location = new System.Drawing.Point(96, 52);
            this.txtReq.Name = "txtReq";
            this.txtReq.ReadOnly = true;
            this.txtReq.Size = new System.Drawing.Size(458, 20);
            this.txtReq.TabIndex = 10;
            // 
            // lblSVC
            // 
            this.lblSVC.AutoSize = true;
            this.lblSVC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSVC.Location = new System.Drawing.Point(8, 24);
            this.lblSVC.Name = "lblSVC";
            this.lblSVC.Size = new System.Drawing.Size(46, 13);
            this.lblSVC.TabIndex = 12;
            this.lblSVC.Text = "Service ";
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
            // ctrlNewService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtServiceName);
            this.Name = "ctrlNewService";
            this.Title = "Nuevo servicio SVC";
 
            this.Controls.SetChildIndex(this.txtServiceName, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnBack, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReq;
        private System.Windows.Forms.Label lblSVC;
        private System.Windows.Forms.TextBox txtBE;
    }
}
