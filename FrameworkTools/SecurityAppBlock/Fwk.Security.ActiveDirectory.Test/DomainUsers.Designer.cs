namespace Fwk.Security.ActiveDirectory.Test
{
    partial class DomainUsers
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
            this.txDomainUserName = new System.Windows.Forms.TextBox();
            this.grdDomainUsers = new System.Windows.Forms.DataGridView();
            this.loginNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middleNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userAccountControlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginNameWithDomainDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.streetAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postalCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.homePhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extensionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.managerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnFilterUsers = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdDomainUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDUserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txDomainUserName
            // 
            this.txDomainUserName.Location = new System.Drawing.Point(106, 9);
            this.txDomainUserName.Name = "txDomainUserName";
            this.txDomainUserName.Size = new System.Drawing.Size(178, 20);
            this.txDomainUserName.TabIndex = 23;
            this.txDomainUserName.TextChanged += new System.EventHandler(this.txDomainUserName_TextChanged);
            this.txDomainUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txDomainUserName_KeyDown);
            // 
            // grdDomainUsers
            // 
            this.grdDomainUsers.AllowUserToAddRows = false;
            this.grdDomainUsers.AllowUserToDeleteRows = false;
            this.grdDomainUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDomainUsers.AutoGenerateColumns = false;
            this.grdDomainUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDomainUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.loginNameDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.middleNameDataGridViewTextBoxColumn,
            this.lastNameDataGridViewTextBoxColumn,
            this.emailAddressDataGridViewTextBoxColumn,
            this.userAccountControlDataGridViewTextBoxColumn,
            this.departmentDataGridViewTextBoxColumn,
            this.loginNameWithDomainDataGridViewTextBoxColumn,
            this.streetAddressDataGridViewTextBoxColumn,
            this.cityDataGridViewTextBoxColumn,
            this.stateDataGridViewTextBoxColumn,
            this.postalCodeDataGridViewTextBoxColumn,
            this.countryDataGridViewTextBoxColumn,
            this.homePhoneDataGridViewTextBoxColumn,
            this.extensionDataGridViewTextBoxColumn,
            this.mobileDataGridViewTextBoxColumn,
            this.faxDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.companyDataGridViewTextBoxColumn,
            this.managerNameDataGridViewTextBoxColumn});
            this.grdDomainUsers.DataSource = this.aDUserBindingSource;
            this.grdDomainUsers.Location = new System.Drawing.Point(3, 32);
            this.grdDomainUsers.Name = "grdDomainUsers";
            this.grdDomainUsers.ReadOnly = true;
            this.grdDomainUsers.Size = new System.Drawing.Size(905, 375);
            this.grdDomainUsers.TabIndex = 21;
            this.grdDomainUsers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDomainUsers_CellDoubleClick);
            this.grdDomainUsers.Click += new System.EventHandler(this.grdDomainUsers_Click);
            // 
            // loginNameDataGridViewTextBoxColumn
            // 
            this.loginNameDataGridViewTextBoxColumn.DataPropertyName = "LoginName";
            this.loginNameDataGridViewTextBoxColumn.HeaderText = "LoginName";
            this.loginNameDataGridViewTextBoxColumn.Name = "loginNameDataGridViewTextBoxColumn";
            this.loginNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            this.firstNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // middleNameDataGridViewTextBoxColumn
            // 
            this.middleNameDataGridViewTextBoxColumn.DataPropertyName = "MiddleName";
            this.middleNameDataGridViewTextBoxColumn.HeaderText = "MiddleName";
            this.middleNameDataGridViewTextBoxColumn.Name = "middleNameDataGridViewTextBoxColumn";
            this.middleNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            this.lastNameDataGridViewTextBoxColumn.HeaderText = "LastName";
            this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            this.lastNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailAddressDataGridViewTextBoxColumn
            // 
            this.emailAddressDataGridViewTextBoxColumn.DataPropertyName = "EmailAddress";
            this.emailAddressDataGridViewTextBoxColumn.HeaderText = "EmailAddress";
            this.emailAddressDataGridViewTextBoxColumn.Name = "emailAddressDataGridViewTextBoxColumn";
            this.emailAddressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userAccountControlDataGridViewTextBoxColumn
            // 
            this.userAccountControlDataGridViewTextBoxColumn.DataPropertyName = "UserAccountControl";
            this.userAccountControlDataGridViewTextBoxColumn.HeaderText = "UserAccountControl";
            this.userAccountControlDataGridViewTextBoxColumn.Name = "userAccountControlDataGridViewTextBoxColumn";
            this.userAccountControlDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // departmentDataGridViewTextBoxColumn
            // 
            this.departmentDataGridViewTextBoxColumn.DataPropertyName = "Department";
            this.departmentDataGridViewTextBoxColumn.HeaderText = "Department";
            this.departmentDataGridViewTextBoxColumn.Name = "departmentDataGridViewTextBoxColumn";
            this.departmentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // loginNameWithDomainDataGridViewTextBoxColumn
            // 
            this.loginNameWithDomainDataGridViewTextBoxColumn.DataPropertyName = "LoginNameWithDomain";
            this.loginNameWithDomainDataGridViewTextBoxColumn.HeaderText = "LoginNameWithDomain";
            this.loginNameWithDomainDataGridViewTextBoxColumn.Name = "loginNameWithDomainDataGridViewTextBoxColumn";
            this.loginNameWithDomainDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // streetAddressDataGridViewTextBoxColumn
            // 
            this.streetAddressDataGridViewTextBoxColumn.DataPropertyName = "StreetAddress";
            this.streetAddressDataGridViewTextBoxColumn.HeaderText = "StreetAddress";
            this.streetAddressDataGridViewTextBoxColumn.Name = "streetAddressDataGridViewTextBoxColumn";
            this.streetAddressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cityDataGridViewTextBoxColumn
            // 
            this.cityDataGridViewTextBoxColumn.DataPropertyName = "City";
            this.cityDataGridViewTextBoxColumn.HeaderText = "City";
            this.cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
            this.cityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stateDataGridViewTextBoxColumn
            // 
            this.stateDataGridViewTextBoxColumn.DataPropertyName = "State";
            this.stateDataGridViewTextBoxColumn.HeaderText = "State";
            this.stateDataGridViewTextBoxColumn.Name = "stateDataGridViewTextBoxColumn";
            this.stateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // postalCodeDataGridViewTextBoxColumn
            // 
            this.postalCodeDataGridViewTextBoxColumn.DataPropertyName = "PostalCode";
            this.postalCodeDataGridViewTextBoxColumn.HeaderText = "PostalCode";
            this.postalCodeDataGridViewTextBoxColumn.Name = "postalCodeDataGridViewTextBoxColumn";
            this.postalCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // countryDataGridViewTextBoxColumn
            // 
            this.countryDataGridViewTextBoxColumn.DataPropertyName = "Country";
            this.countryDataGridViewTextBoxColumn.HeaderText = "Country";
            this.countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            this.countryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // homePhoneDataGridViewTextBoxColumn
            // 
            this.homePhoneDataGridViewTextBoxColumn.DataPropertyName = "HomePhone";
            this.homePhoneDataGridViewTextBoxColumn.HeaderText = "HomePhone";
            this.homePhoneDataGridViewTextBoxColumn.Name = "homePhoneDataGridViewTextBoxColumn";
            this.homePhoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // extensionDataGridViewTextBoxColumn
            // 
            this.extensionDataGridViewTextBoxColumn.DataPropertyName = "Extension";
            this.extensionDataGridViewTextBoxColumn.HeaderText = "Extension";
            this.extensionDataGridViewTextBoxColumn.Name = "extensionDataGridViewTextBoxColumn";
            this.extensionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mobileDataGridViewTextBoxColumn
            // 
            this.mobileDataGridViewTextBoxColumn.DataPropertyName = "Mobile";
            this.mobileDataGridViewTextBoxColumn.HeaderText = "Mobile";
            this.mobileDataGridViewTextBoxColumn.Name = "mobileDataGridViewTextBoxColumn";
            this.mobileDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // faxDataGridViewTextBoxColumn
            // 
            this.faxDataGridViewTextBoxColumn.DataPropertyName = "Fax";
            this.faxDataGridViewTextBoxColumn.HeaderText = "Fax";
            this.faxDataGridViewTextBoxColumn.Name = "faxDataGridViewTextBoxColumn";
            this.faxDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // companyDataGridViewTextBoxColumn
            // 
            this.companyDataGridViewTextBoxColumn.DataPropertyName = "Company";
            this.companyDataGridViewTextBoxColumn.HeaderText = "Company";
            this.companyDataGridViewTextBoxColumn.Name = "companyDataGridViewTextBoxColumn";
            this.companyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // managerNameDataGridViewTextBoxColumn
            // 
            this.managerNameDataGridViewTextBoxColumn.DataPropertyName = "ManagerName";
            this.managerNameDataGridViewTextBoxColumn.HeaderText = "ManagerName";
            this.managerNameDataGridViewTextBoxColumn.Name = "managerNameDataGridViewTextBoxColumn";
            this.managerNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aDUserBindingSource
            // 
            this.aDUserBindingSource.DataSource = typeof(Fwk.Security.ActiveDirectory.ADUser);
            // 
            // btnFilterUsers
            // 
            this.btnFilterUsers.BackColor = System.Drawing.Color.White;
            this.btnFilterUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilterUsers.Location = new System.Drawing.Point(290, 7);
            this.btnFilterUsers.Name = "btnFilterUsers";
            this.btnFilterUsers.Size = new System.Drawing.Size(59, 22);
            this.btnFilterUsers.TabIndex = 24;
            this.btnFilterUsers.Text = "Filter";
            this.btnFilterUsers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFilterUsers.UseVisualStyleBackColor = false;
            this.btnFilterUsers.Click += new System.EventHandler(this.btnFilterUsers_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::Fwk.Security.ActiveDirectory.Test.Properties.Resources.users;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(3, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(27, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "group name";
            // 
            // DomainUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txDomainUserName);
            this.Controls.Add(this.btnFilterUsers);
            this.Controls.Add(this.grdDomainUsers);
            this.Name = "DomainUsers";
            this.Size = new System.Drawing.Size(911, 410);
            ((System.ComponentModel.ISupportInitialize)(this.grdDomainUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDUserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txDomainUserName;
        private System.Windows.Forms.Button btnFilterUsers;
        private System.Windows.Forms.DataGridView grdDomainUsers;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn middleNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userAccountControlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginNameWithDomainDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn streetAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postalCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn homePhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extensionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn faxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn managerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource aDUserBindingSource;
    }
}
