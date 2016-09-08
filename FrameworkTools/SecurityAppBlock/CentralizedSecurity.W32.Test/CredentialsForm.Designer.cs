using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SecurityAppBlock.Use
{
    partial class CredentialsForm
    {
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CredentialsForm));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAutenticate2 = new System.Windows.Forms.Button();
            this.btnAutenticate1 = new System.Windows.Forms.Button();
            this.btnResset = new System.Windows.Forms.Button();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.cmbAllDomains = new System.Windows.Forms.ComboBox();
            this.domainUrlInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Domain = new System.Windows.Forms.Label();
            this.txtErr = new System.Windows.Forms.TextBox();
            this.txtLDAPUser = new System.Windows.Forms.TextBox();
            this.txtCnnString = new System.Windows.Forms.TextBox();
            this.btnGetUserInfo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.domainUrlInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAutenticate2);
            this.groupBox1.Controls.Add(this.btnAutenticate1);
            this.groupBox1.Controls.Add(this.btnResset);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btnAutenticate2
            // 
            resources.ApplyResources(this.btnAutenticate2, "btnAutenticate2");
            this.btnAutenticate2.Name = "btnAutenticate2";
            this.btnAutenticate2.UseVisualStyleBackColor = true;
            this.btnAutenticate2.Click += new System.EventHandler(this.btnAutenticate2_Click);
            // 
            // btnAutenticate1
            // 
            resources.ApplyResources(this.btnAutenticate1, "btnAutenticate1");
            this.btnAutenticate1.Name = "btnAutenticate1";
            this.btnAutenticate1.UseVisualStyleBackColor = true;
            this.btnAutenticate1.Click += new System.EventHandler(this.btnAutenticate1_Click);
            // 
            // btnResset
            // 
            resources.ApplyResources(this.btnResset, "btnResset");
            this.btnResset.Name = "btnResset";
            this.btnResset.UseVisualStyleBackColor = true;
            this.btnResset.Click += new System.EventHandler(this.btnResset_Click);
            // 
            // usernameTextBox
            // 
            resources.ApplyResources(this.usernameTextBox, "usernameTextBox");
            this.usernameTextBox.Name = "usernameTextBox";
            // 
            // passwordTextBox
            // 
            resources.ApplyResources(this.passwordTextBox, "passwordTextBox");
            this.passwordTextBox.Name = "passwordTextBox";
            // 
            // cmbAllDomains
            // 
            this.cmbAllDomains.DataSource = this.domainUrlInfoBindingSource;
            this.cmbAllDomains.DisplayMember = "DomainName";
            this.cmbAllDomains.FormattingEnabled = true;
            resources.ApplyResources(this.cmbAllDomains, "cmbAllDomains");
            this.cmbAllDomains.Name = "cmbAllDomains";
            this.cmbAllDomains.ValueMember = "Id";
            this.cmbAllDomains.SelectedIndexChanged += new System.EventHandler(this.cmbAllDomains_SelectedIndexChanged);
            // 
            // domainUrlInfoBindingSource
            // 
            this.domainUrlInfoBindingSource.DataSource = typeof(Fwk.Security.ActiveDirectory.DomainUrlInfo);
            // 
            // Domain
            // 
            resources.ApplyResources(this.Domain, "Domain");
            this.Domain.Name = "Domain";
            // 
            // txtErr
            // 
            resources.ApplyResources(this.txtErr, "txtErr");
            this.txtErr.Name = "txtErr";
            // 
            // txtLDAPUser
            // 
            resources.ApplyResources(this.txtLDAPUser, "txtLDAPUser");
            this.txtLDAPUser.Name = "txtLDAPUser";
            // 
            // txtCnnString
            // 
            resources.ApplyResources(this.txtCnnString, "txtCnnString");
            this.txtCnnString.Name = "txtCnnString";
            // 
            // btnGetUserInfo
            // 
            resources.ApplyResources(this.btnGetUserInfo, "btnGetUserInfo");
            this.btnGetUserInfo.Name = "btnGetUserInfo";
            this.btnGetUserInfo.UseVisualStyleBackColor = true;
            this.btnGetUserInfo.Click += new System.EventHandler(this.btnGetUserInfo_Click);
            // 
            // CredentialsForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnGetUserInfo);
            this.Controls.Add(this.txtCnnString);
            this.Controls.Add(this.txtLDAPUser);
            this.Controls.Add(this.txtErr);
            this.Controls.Add(this.Domain);
            this.Controls.Add(this.cmbAllDomains);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CredentialsForm";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CredentialsForm_FormClosing);
            this.Load += new System.EventHandler(this.CredentialsForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.domainUrlInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ComboBox cmbAllDomains;
        private System.Windows.Forms.Label Domain;
        private System.Windows.Forms.TextBox txtErr;
        private System.Windows.Forms.Button btnResset;
        private System.Windows.Forms.BindingSource domainUrlInfoBindingSource;
        private System.Windows.Forms.TextBox txtLDAPUser;
        private System.Windows.Forms.TextBox txtCnnString;
        private System.Windows.Forms.Button btnAutenticate2;
        private System.Windows.Forms.Button btnAutenticate1;
   		private System.Windows.Forms.Button btnGetUserInfo;
        private IContainer components;
    }
}
