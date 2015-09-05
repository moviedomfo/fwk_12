namespace Fwk.Security.Admin.Controls
{
    partial class frmUserFind
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
            this.btnAcept = new DevExpress.XtraEditors.SimpleButton();
            this.brnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.usersGrid1 = new Fwk.Security.Admin.UsersGrid();
            this.SuspendLayout();
            // 
            // btnAcept
            // 
            this.btnAcept.Location = new System.Drawing.Point(547, 570);
            this.btnAcept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAcept.Name = "btnAcept";
            this.btnAcept.Size = new System.Drawing.Size(100, 28);
            this.btnAcept.TabIndex = 1;
            this.btnAcept.Text = "Acept";
            this.btnAcept.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // brnCancel
            // 
            this.brnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.brnCancel.Location = new System.Drawing.Point(673, 570);
            this.brnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.brnCancel.Name = "brnCancel";
            this.brnCancel.Size = new System.Drawing.Size(100, 28);
            this.brnCancel.TabIndex = 2;
            this.brnCancel.Text = "Cancel";
            this.brnCancel.Click += new System.EventHandler(this.brnCancel_Click);
            // 
            // usersGrid1
            // 
            this.usersGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersGrid1.Location = new System.Drawing.Point(11, 15);
            this.usersGrid1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.usersGrid1.Name = "usersGrid1";
            this.usersGrid1.Size = new System.Drawing.Size(817, 548);
            this.usersGrid1.TabIndex = 0;
            // 
            // frmUserFind
            // 
            this.AcceptButton = this.btnAcept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.brnCancel;
            this.ClientSize = new System.Drawing.Size(841, 607);
            this.Controls.Add(this.brnCancel);
            this.Controls.Add(this.btnAcept);
            this.Controls.Add(this.usersGrid1);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserFind";
            this.ShowIcon = false;
            this.Text = "Find users";
            this.ResumeLayout(false);

        }

        #endregion

        private UsersGrid usersGrid1;
        private DevExpress.XtraEditors.SimpleButton btnAcept;
        private DevExpress.XtraEditors.SimpleButton brnCancel;
    }
}