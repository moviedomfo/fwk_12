namespace ConfigurationApp
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
            this.lblAddress = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblConnectionType = new System.Windows.Forms.Label();
            this.txtConfigName = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.cnnstring = new ConfigurationApp.cnnstring();
            this.SuspendLayout();
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblAddress.Location = new System.Drawing.Point(1, 43);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(79, 13);
            this.lblAddress.TabIndex = 101;
            this.lblAddress.Text = "Config Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(3, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 100;
            this.label3.Text = "Type:";
            // 
            // lblConnectionType
            // 
            this.lblConnectionType.AutoSize = true;
            this.lblConnectionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionType.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblConnectionType.Location = new System.Drawing.Point(80, 14);
            this.lblConnectionType.Name = "lblConnectionType";
            this.lblConnectionType.Size = new System.Drawing.Size(16, 13);
            this.lblConnectionType.TabIndex = 99;
            this.lblConnectionType.Text = "---";
            // 
            // txtConfigName
            // 
            this.txtConfigName.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtConfigName.AllowBlankSpace = true;
            this.txtConfigName.AllowedCharacters = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
            this.txtConfigName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfigName.BackColor = System.Drawing.Color.White;
            this.txtConfigName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfigName.CapitalOnly = false;
            this.txtConfigName.ErrorIconRightToLeft = false;
            this.txtConfigName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfigName.InactiveBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtConfigName.Location = new System.Drawing.Point(91, 41);
            this.txtConfigName.Multiline = true;
            this.txtConfigName.Name = "txtConfigName";
            this.txtConfigName.NotAllowedCharactersErrorText = "";
            this.txtConfigName.ReadOnly = true;
            this.txtConfigName.Required = false;
            this.txtConfigName.RequiredErrorText = null;
            this.txtConfigName.Size = new System.Drawing.Size(417, 20);
            this.txtConfigName.TabIndex = 96;
            this.txtConfigName.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            // 
            // cnnstring
            // 
            this.cnnstring.Location = new System.Drawing.Point(2, 67);
            this.cnnstring.Name = "cnnstring";
            this.cnnstring.Size = new System.Drawing.Size(506, 32);
            this.cnnstring.TabIndex = 105;
            this.cnnstring.Visible = false;
            // 
            // provider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cnnstring);
            this.Controls.Add(this.txtConfigName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblConnectionType);
            this.Name = "provider";
            this.Size = new System.Drawing.Size(511, 107);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private cnnstring cnnstring;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtConfigName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblConnectionType;
    }
}
