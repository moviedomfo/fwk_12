namespace Fwk.Security.Admin.Controls
{
    partial class UserAssingRoles
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
            this.lstBoxRoles = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.rolListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAsignarRoles = new System.Windows.Forms.Button();
            this.bindingSourceUserRole = new System.Windows.Forms.BindingSource(this.components);
            this.lblSelectedUser = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usersGrid1 = new Fwk.Security.Admin.UsersGrid();
            this.lblRolesByUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstBoxRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUserRole)).BeginInit();
            this.SuspendLayout();
            // 
            // lstBoxRoles
            // 
            this.lstBoxRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBoxRoles.Appearance.BackColor = System.Drawing.Color.White;
            this.lstBoxRoles.Appearance.BackColor2 = System.Drawing.Color.White;
            this.lstBoxRoles.Appearance.BorderColor = System.Drawing.Color.White;
            this.lstBoxRoles.Appearance.Options.UseBackColor = true;
            this.lstBoxRoles.Appearance.Options.UseBorderColor = true;
            this.lstBoxRoles.CheckOnClick = true;
            this.lstBoxRoles.DataSource = this.rolListBindingSource;
            this.lstBoxRoles.DisplayMember = "RolName";
            this.lstBoxRoles.Location = new System.Drawing.Point(804, 83);
            this.lstBoxRoles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstBoxRoles.Name = "lstBoxRoles";
            this.lstBoxRoles.Size = new System.Drawing.Size(193, 503);
            this.lstBoxRoles.TabIndex = 13;
            this.lstBoxRoles.ValueMember = "RolName";
            // 
            // rolListBindingSource
            // 
            this.rolListBindingSource.DataSource = typeof(Fwk.Security.Common.RolList);
            // 
            // btnAsignarRoles
            // 
            this.btnAsignarRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignarRoles.BackColor = System.Drawing.Color.White;
            this.btnAsignarRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarRoles.Image = global::Fwk.Security.Admin.Properties.Resources.save_16;
            this.btnAsignarRoles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignarRoles.Location = new System.Drawing.Point(3, 9);
            this.btnAsignarRoles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAsignarRoles.Name = "btnAsignarRoles";
            this.btnAsignarRoles.Size = new System.Drawing.Size(140, 34);
            this.btnAsignarRoles.TabIndex = 14;
            this.btnAsignarRoles.Text = "Save changes";
            this.btnAsignarRoles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignarRoles.UseVisualStyleBackColor = false;
            this.btnAsignarRoles.Click += new System.EventHandler(this.btnAsignarRoles_Click);
            // 
            // bindingSourceUserRole
            // 
            this.bindingSourceUserRole.DataSource = typeof(Fwk.Security.Common.RolList);
            // 
            // lblSelectedUser
            // 
            this.lblSelectedUser.AutoSize = true;
            this.lblSelectedUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSelectedUser.ForeColor = System.Drawing.Color.Maroon;
            this.lblSelectedUser.Location = new System.Drawing.Point(348, 17);
            this.lblSelectedUser.Name = "lblSelectedUser";
            this.lblSelectedUser.Size = new System.Drawing.Size(76, 17);
            this.lblSelectedUser.TabIndex = 18;
            this.lblSelectedUser.Text = ".................";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = global::Fwk.Security.Admin.Properties.Resources.User;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(193, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 28);
            this.label2.TabIndex = 21;
            this.label2.Text = "Selected user: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // usersGrid1
            // 
            this.usersGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersGrid1.Location = new System.Drawing.Point(-1, 50);
            this.usersGrid1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.usersGrid1.Name = "usersGrid1";
            this.usersGrid1.Size = new System.Drawing.Size(799, 542);
            this.usersGrid1.TabIndex = 22;
            this.usersGrid1.OnUserChange += new Fwk.Security.Admin.UserChangeHandler(this.usersGrid1_OnUserChange);
            // 
            // lblRolesByUser
            // 
            this.lblRolesByUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRolesByUser.Image = global::Fwk.Security.Admin.Properties.Resources.Users;
            this.lblRolesByUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRolesByUser.Location = new System.Drawing.Point(804, 59);
            this.lblRolesByUser.Name = "lblRolesByUser";
            this.lblRolesByUser.Size = new System.Drawing.Size(113, 20);
            this.lblRolesByUser.TabIndex = 23;
            this.lblRolesByUser.Text = "All roles";
            this.lblRolesByUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UserAssingRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSelectedUser);
            this.Controls.Add(this.lblRolesByUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstBoxRoles);
            this.Controls.Add(this.btnAsignarRoles);
            this.Controls.Add(this.usersGrid1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "UserAssingRoles";
            this.Size = new System.Drawing.Size(1003, 592);
            this.Load += new System.EventHandler(this.UserAssingRoles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstBoxRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUserRole)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckedListBoxControl lstBoxRoles;
        private System.Windows.Forms.Button btnAsignarRoles;
        private System.Windows.Forms.BindingSource rolListBindingSource;

        private System.Windows.Forms.BindingSource bindingSourceUserRole;
        private System.Windows.Forms.Label lblSelectedUser;
        private System.Windows.Forms.Label label2;
        private UsersGrid usersGrid1;
        private System.Windows.Forms.Label lblRolesByUser;
    }
}
