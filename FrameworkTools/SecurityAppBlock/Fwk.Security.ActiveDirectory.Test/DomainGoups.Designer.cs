namespace Fwk.Security.ActiveDirectory.Test
{
    partial class DomainGoups
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
            this.grdDomainGroups = new System.Windows.Forms.DataGridView();
            this.objectDomainGroupBindingSource = new System.Windows.Forms.BindingSource();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDomainGroupName = new System.Windows.Forms.TextBox();
            this.btnFilterGroup = new System.Windows.Forms.Button();
            this.cNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DistinguishedName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdDomainGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDomainGroupBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDomainGroups
            // 
            this.grdDomainGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDomainGroups.AutoGenerateColumns = false;
            this.grdDomainGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDomainGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.DistinguishedName,
            this.Category,
            this.Description});
            this.grdDomainGroups.DataSource = this.objectDomainGroupBindingSource;
            this.grdDomainGroups.Location = new System.Drawing.Point(4, 37);
            this.grdDomainGroups.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdDomainGroups.Name = "grdDomainGroups";
            this.grdDomainGroups.Size = new System.Drawing.Size(763, 694);
            this.grdDomainGroups.TabIndex = 23;
            this.grdDomainGroups.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDomainGroups_CellClick);
            // 
            // objectDomainGroupBindingSource
            // 
            this.objectDomainGroupBindingSource.DataSource = typeof(Fwk.Security.ActiveDirectory.ADGroup);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 46;
            this.label1.Text = "Groups";
            // 
            // txtDomainGroupName
            // 
            this.txtDomainGroupName.Location = new System.Drawing.Point(80, 4);
            this.txtDomainGroupName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDomainGroupName.Name = "txtDomainGroupName";
            this.txtDomainGroupName.Size = new System.Drawing.Size(236, 22);
            this.txtDomainGroupName.TabIndex = 43;
            this.txtDomainGroupName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDomainGroupName_KeyDown);
            // 
            // btnFilterGroup
            // 
            this.btnFilterGroup.BackColor = System.Drawing.Color.White;
            this.btnFilterGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterGroup.Image = global::Fwk.Security.ActiveDirectory.Test.Properties.Resources.srch_16;
            this.btnFilterGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilterGroup.Location = new System.Drawing.Point(347, 2);
            this.btnFilterGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFilterGroup.Name = "btnFilterGroup";
            this.btnFilterGroup.Size = new System.Drawing.Size(79, 27);
            this.btnFilterGroup.TabIndex = 44;
            this.btnFilterGroup.Text = "Filter";
            this.btnFilterGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFilterGroup.UseVisualStyleBackColor = false;
            this.btnFilterGroup.Click += new System.EventHandler(this.btnFilterGroup_Click);
            // 
            // cNDataGridViewTextBoxColumn
            // 
            this.cNDataGridViewTextBoxColumn.DataPropertyName = "CN";
            this.cNDataGridViewTextBoxColumn.HeaderText = "CN";
            this.cNDataGridViewTextBoxColumn.Name = "cNDataGridViewTextBoxColumn";
            this.cNDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 200;
            // 
            // DistinguishedName
            // 
            this.DistinguishedName.DataPropertyName = "DistinguishedName";
            this.DistinguishedName.HeaderText = "DistinguishedName";
            this.DistinguishedName.Name = "DistinguishedName";
            this.DistinguishedName.ReadOnly = true;
            this.DistinguishedName.Width = 300;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "Category";
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // DomainGoups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDomainGroupName);
            this.Controls.Add(this.btnFilterGroup);
            this.Controls.Add(this.grdDomainGroups);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DomainGoups";
            this.Size = new System.Drawing.Size(771, 735);
            ((System.ComponentModel.ISupportInitialize)(this.grdDomainGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDomainGroupBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdDomainGroups;
        private System.Windows.Forms.BindingSource objectDomainGroupBindingSource;
        //private System.Windows.Forms.DataGridViewTextBoxColumn oUDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDomainGroupName;
        private System.Windows.Forms.Button btnFilterGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DistinguishedName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}
