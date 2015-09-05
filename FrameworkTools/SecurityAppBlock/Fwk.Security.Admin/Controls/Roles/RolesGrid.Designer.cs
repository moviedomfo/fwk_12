namespace Fwk.Security.Admin.Controls
{
    partial class RolesGrid
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
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.grdUsers = new System.Windows.Forms.DataGridView();
            this.rolNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(10, 47);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(369, 22);
            this.textEdit1.TabIndex = 22;
            this.textEdit1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEdit1_KeyPress);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Image = global::Fwk.Security.Admin.Properties.Resources.Users;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(7, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 28);
            this.label9.TabIndex = 21;
            this.label9.Text = "Roles";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grdUsers
            // 
            this.grdUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdUsers.AutoGenerateColumns = false;
            this.grdUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grdUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rolNameDataGridViewTextBoxColumn});
            this.grdUsers.DataSource = this.rolBindingSource;
            this.grdUsers.Location = new System.Drawing.Point(3, 79);
            this.grdUsers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdUsers.Name = "grdUsers";
            this.grdUsers.RowTemplate.Height = 24;
            this.grdUsers.Size = new System.Drawing.Size(536, 479);
            this.grdUsers.TabIndex = 20;
            // 
            // rolNameDataGridViewTextBoxColumn
            // 
            this.rolNameDataGridViewTextBoxColumn.DataPropertyName = "RolName";
            this.rolNameDataGridViewTextBoxColumn.HeaderText = "RolName";
            this.rolNameDataGridViewTextBoxColumn.Name = "rolNameDataGridViewTextBoxColumn";
            // 
            // rolBindingSource
            // 
            this.rolBindingSource.DataSource = typeof(Fwk.Security.Common.Rol);
            // 
            // RolesGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.grdUsers);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "RolesGrid";
            this.Size = new System.Drawing.Size(542, 561);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView grdUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource rolBindingSource;
    }
}
