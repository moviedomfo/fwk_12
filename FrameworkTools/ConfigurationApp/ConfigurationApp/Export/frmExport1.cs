using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Bases.FrontEnd;
using Fwk.ConfigSection;
using System.Collections;
using Fwk.Configuration.Common;
using System.Data.SqlClient;
using ConfigurationApp.Forms;

namespace ConfigurationApp
{
    public partial class frmExport1 : FrmBase
    {
       ConfigurationFile sourceConfigFile = null;
       ConfigProviderElement desConfigProviderElement = null;
       public frmExport1(System.Collections.Specialized.ListDictionary source)
       {
           InitializeComponent();
     
           sourceConfigFile = source["ConfigurationFile"] as ConfigurationFile;
           desConfigProviderElement = new ConfigProviderElement();
       }
       
        public frmExport1()
        {
            InitializeComponent();
          
            
        }
       



        

        void Expòrt()
        {
            bool wHasErrors = false;
           
          

            StringBuilder log = new StringBuilder();
           

            if (!wHasErrors)
            {
                  desConfigProviderElement.BaseConfigFile = txtConfigFileName.Text;
                  if (radioButton1.Checked)//database
                  {
                      desConfigProviderElement.SourceInfoIsConnectionString = true;
                      var cnn = CreateConnection();
                      desConfigProviderElement.SourceInfo = cnn.ConnectionString;
                      desConfigProviderElement.ConfigProviderType = ConfigProviderType.sqldatabase;
                  }
                  else
                  {
                      desConfigProviderElement.ConfigProviderType = ConfigProviderType.local;
                      desConfigProviderElement.SourceInfo = "";
                  }


                Fwk.Configuration.ConfigurationManager.Import(sourceConfigFile, desConfigProviderElement);  

          
            }
            textBox1.Text = log.ToString();
            if (wHasErrors)
                this.MessageViewer.Show("Export terminated with warnings or errors!! ");
            else
                this.MessageViewer.Show("Export terminated successfully !! ");

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnOk.Enabled)
                this.DialogResult = DialogResult.Cancel;
            else
                this.DialogResult = DialogResult.OK;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            Expòrt();
         
            btnCancel.Text = "Exit";

         
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnDbCheck_Click(object sender, EventArgs e)
        {
            SqlConnection wConn = null;

            try
            {

                wConn = CreateConnection();
                if (wConn == null)
                    return;

                wConn.Open();
                MessageBox.Show("Conexión Exitosa", "Probar Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Probar Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (wConn != null && wConn.State == ConnectionState.Open)
                    wConn.Close();
                btnDbCheck.Enabled = true;
            }
        }
        #region << -Methods- >>
        private bool DataBaseValidateRequired()
        {
            bool wValid = true;

            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtServer.Text.Trim()))
            {
                errorProvider1.SetError(txtServer, "Server name is required");
                wValid = false;
            }


            if (string.IsNullOrEmpty(txtDataBase.Text.Trim()))
            {
                errorProvider1.SetError(txtDataBase, "Database name is required");
                wValid = false;
            }


            if (cmbAuthenticationMode.Text == ConfigurationApp.Common.Helper.GetEnumDescription(AuthenticationModes.SqlAuthentication))
            {
                if (string.IsNullOrEmpty(txtUser.Text.Trim()))
                {
                    errorProvider1.SetError(txtUser, "Username is required");
                    wValid = false;
                }

            }

            return wValid;
        }

        private bool XmlValidationRequired()
        {
            bool wValid = true;

            if (string.IsNullOrEmpty(txtXml.Text))
            {
                errorProvider1.SetError(txtXml, "The input configuration file must not be empty");
                wValid = false;
            }
            if (!System.IO.File.Exists(txtXml.Text))
            {
                errorProvider1.SetError(txtXml, "The input configuration file is incorrect or not exist.. please check the correct file location ");
                wValid = false;
            }
            if (string.IsNullOrEmpty(txtConfigFileName.Text))
            {
                errorProvider1.SetError(txtConfigFileName, "The  configFileName must not be empty");
                wValid = false;
            }


            return wValid;
        }

        private SqlConnection CreateConnection()
        {
            SqlConnectionStringBuilder wConnStr = null;
            SqlConnection wConn = null;

            if (!DataBaseValidateRequired())
                return null;
            wConnStr = new SqlConnectionStringBuilder();
            wConnStr.InitialCatalog = txtDataBase.Text.Trim();
            wConnStr.DataSource = txtServer.Text.Trim();
            wConnStr.IntegratedSecurity = (cmbAuthenticationMode.Text == ConfigurationApp.Common.Helper.GetEnumDescription(AuthenticationModes.IntegratedAuthentication));
            wConnStr.PersistSecurityInfo = (cmbAuthenticationMode.Text == ConfigurationApp.Common.Helper.GetEnumDescription(AuthenticationModes.SqlAuthentication));
            if (txtUser.Enabled)
            {
                wConnStr.UserID = txtUser.Text.Trim();
                wConnStr.Password = txtPassword.Text.Trim();
            }

            wConn = new SqlConnection(wConnStr.ToString());

            return wConn;
        }

        #endregion

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                groupBox2.Visible = true;
                groupBox1.Visible = false;
            }

        }

    }
}
