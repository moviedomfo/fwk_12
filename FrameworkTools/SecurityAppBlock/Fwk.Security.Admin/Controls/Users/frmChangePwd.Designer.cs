namespace Fwk.Security.Admin.Controls
{
    partial class frmChangePwd
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
            this.label1 = new System.Windows.Forms.Label();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.brnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAcept = new DevExpress.XtraEditors.SimpleButton();
            this.lblUser = new System.Windows.Forms.Label();
            
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(22, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Confirm password:";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(21, 129);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.textEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.textEdit1.Size = new System.Drawing.Size(233, 22);
            this.textEdit1.TabIndex = 20;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(21, 75);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtPassword.Properties.Appearance.Options.UseBackColor = true;
            this.txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtPassword.Size = new System.Drawing.Size(233, 22);
            this.txtPassword.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(22, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Password:";
            // 
            // brnCancel
            // 
            this.brnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.brnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.brnCancel.Location = new System.Drawing.Point(320, 186);
            this.brnCancel.Name = "brnCancel";
            this.brnCancel.Size = new System.Drawing.Size(75, 23);
            this.brnCancel.TabIndex = 24;
            this.brnCancel.Text = "Cancel";
            // 
            // btnAcept
            // 
            this.btnAcept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcept.Location = new System.Drawing.Point(227, 186);
            this.btnAcept.Name = "btnAcept";
            this.btnAcept.Size = new System.Drawing.Size(75, 23);
            this.btnAcept.TabIndex = 23;
            this.btnAcept.Text = "Acept";
            this.btnAcept.Click += new System.EventHandler(this.btnAcept_Click);
            // 
            // lblUser
            // 
            this.lblUser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUser.Location = new System.Drawing.Point(18, 19);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(80, 16);
            this.lblUser.TabIndex = 25;
            this.lblUser.Text = "Usuario:";
            this.lblUser.Click += new System.EventHandler(this.lblUser_Click);
            // 
            // exceptionViewComponent1
            // 
         
            // 
            // frmChangePwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 221);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.brnCancel);
            this.Controls.Add(this.btnAcept);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePwd";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change password";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SimpleButton brnCancel;
        private DevExpress.XtraEditors.SimpleButton btnAcept;
        private System.Windows.Forms.Label lblUser;
        
    }
}