using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.ConfigSection;
using Fwk.Configuration.Common;

namespace ConfigurationApp.Forms
{
    public enum AuthenticationModes
    {
        [Description("Autenticación SQL")]
        SqlAuthentication = 1,
        [Description("Autenticación de Windows")]
        IntegratedAuthentication = 2
    }
    public partial class frmExportXmlToBd : Form
    {
        #region << -Attributes- >>
       

        private const string _ErrorColor = "#F8F4B3";
        #endregion

        #region << -Constructors- >>
        public frmExportXmlToBd()
        {
            InitializeComponent();
        }
        #endregion

        #region << -Events- >>
        private void frmExportXmlToBd_Load(object sender, EventArgs e)
        {
            try
            {
                cmbAuthenticationMode.Items.Add(ConfigurationApp.Common.Helper.GetEnumDescription(AuthenticationModes.SqlAuthentication));
                cmbAuthenticationMode.Items.Add(ConfigurationApp.Common.Helper.GetEnumDescription(AuthenticationModes.IntegratedAuthentication));
                cmbAuthenticationMode.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Multiselect = false;
                openFileDialog1.FileName = string.Empty;
                
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return;

                txtXml.Text = openFileDialog1.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SqlConnection wConn = null;
            string wXmlText = string.Empty;
            ConfigurationFile wConfigFile = null;
            
            System.IO.FileInfo wFInfo = null;

            try
            {
                progressBar1.Value = 0;

                wConn = CreateConnection();
                if (wConn == null || !XmlValidationRequired())
                    return;

                progressBar1.Increment(2);

                //Obtengo los datos del xml
                wFInfo = new System.IO.FileInfo(txtXml.Text);
                wXmlText = Fwk.HelperFunctions.FileFunctions.OpenTextFile(txtXml.Text);
                wConfigFile = new ConfigurationFile();
                wConfigFile = ConfigurationFile.GetFromXml<ConfigurationFile>(wXmlText);
                if (wConfigFile.Groups == null)
                {
                    MessageBox.Show("No hay datos para migrar", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                progressBar1.Increment(48);

              
                progressBar1.Increment(40);
                ConfigProviderElement tempProvider = new ConfigProviderElement();
                tempProvider.BaseConfigFile = txtConfigFileName.Text;
                tempProvider.ConfigProviderType = ConfigProviderType.sqldatabase;
                tempProvider.SourceInfo = wConn.ConnectionString;
                tempProvider.SourceInfoIsConnectionString = true;
           

                Fwk.Configuration.ConfigurationManager_CRUD.Import(wConfigFile,tempProvider);
           

                progressBar1.Increment(10);

                MessageBox.Show("Exportación terminada exitosamente", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (wConn != null && wConn.State == ConnectionState.Open)
                    wConn.Close();
            }
        }


        private void cmbAuthenticationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbAuthenticationMode.Text == ConfigurationApp.Common.Helper.GetEnumDescription(AuthenticationModes.SqlAuthentication))
                {
                    txtUser.Enabled = true;
                    txtPassword.Enabled = true;
                }
                else
                {
                    txtUser.Enabled = false;
                    txtPassword.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        #endregion

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
                errorProvider1.SetError(txtXml,"The input configuration file is incorrect or not exist.. please check the correct file location ");
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

        private void txtXml_TextChanged(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(txtXml.Text)) return;

            System.IO.FileInfo f = new System.IO.FileInfo(txtXml.Text);
            txtConfigFileName.Text = f.Name;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}
