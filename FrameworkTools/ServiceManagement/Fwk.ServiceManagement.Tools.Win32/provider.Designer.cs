namespace Fwk.ServiceManagement.Tools.Win32
{
    partial class provider
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
            this.components = new System.ComponentModel.Container();
            this.txtApplicationId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.lblAddress = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblConnectionType = new System.Windows.Forms.Label();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddres = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.cnnstring = new Fwk.ServiceManagement.Tools.Win32.cnnstring();
            this.SuspendLayout();
            // 
            // txtApplicationId
            // 
            this.txtApplicationId.AutoSize = true;
            this.txtApplicationId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApplicationId.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtApplicationId.Location = new System.Drawing.Point(397, 29);
            this.txtApplicationId.Name = "txtApplicationId";
            this.txtApplicationId.Size = new System.Drawing.Size(16, 13);
            this.txtApplicationId.TabIndex = 104;
            this.txtApplicationId.Text = "---";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(277, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 103;
            this.label2.Text = "Application Id:";
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnView.Image = global::Fwk.ServiceManagement.Tools.Win32.Properties.Resources.prntpv_16;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(454, 58);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(49, 19);
            this.btnView.TabIndex = 102;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblAddress.Location = new System.Drawing.Point(6, 58);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(56, 13);
            this.lblAddress.TabIndex = 101;
            this.lblAddress.Text = "Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 100;
            this.label3.Text = "Metadata type:";
            // 
            // lblConnectionType
            // 
            this.lblConnectionType.AutoSize = true;
            this.lblConnectionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionType.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblConnectionType.Location = new System.Drawing.Point(123, 29);
            this.lblConnectionType.Name = "lblConnectionType";
            this.lblConnectionType.Size = new System.Drawing.Size(16, 13);
            this.lblConnectionType.TabIndex = 99;
            this.lblConnectionType.Text = "---";
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionStatus.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblConnectionStatus.Location = new System.Drawing.Point(123, 4);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(25, 13);
            this.lblConnectionStatus.TabIndex = 98;
            this.lblConnectionStatus.Text = "......";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 97;
            this.label1.Text = "Connection status:";
            // 
            // txtAddres
            // 
            this.txtAddres.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtAddres.AllowBlankSpace = true;
            this.txtAddres.AllowedCharacters = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
            this.txtAddres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddres.BackColor = System.Drawing.Color.White;
            this.txtAddres.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddres.CapitalOnly = false;
            this.txtAddres.ErrorIconRightToLeft = false;
            this.txtAddres.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddres.InactiveBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtAddres.Location = new System.Drawing.Point(83, 56);
            this.txtAddres.Multiline = true;
            this.txtAddres.Name = "txtAddres";
            this.txtAddres.NotAllowedCharactersErrorText = "";
            this.txtAddres.ReadOnly = true;
            this.txtAddres.Required = false;
            this.txtAddres.RequiredErrorText = null;
            this.txtAddres.Size = new System.Drawing.Size(365, 20);
            this.txtAddres.TabIndex = 96;
            this.txtAddres.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            // 
            // cnnstring
            // 
            this.cnnstring.Location = new System.Drawing.Point(5, 82);
            this.cnnstring.Name = "cnnstring";
            this.cnnstring.Size = new System.Drawing.Size(498, 32);
            this.cnnstring.TabIndex = 105;
            this.cnnstring.Visible = false;
            // 
            // provider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cnnstring);
            this.Controls.Add(this.txtApplicationId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAddres);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblConnectionType);
            this.Controls.Add(this.lblConnectionStatus);
            this.Controls.Add(this.label1);
            this.Name = "provider";
            this.Size = new System.Drawing.Size(511, 128);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private cnnstring cnnstring;
        private System.Windows.Forms.Label txtApplicationId;
        private System.Windows.Forms.Label label2;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtAddres;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblConnectionType;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.Label label1;
    }
}
