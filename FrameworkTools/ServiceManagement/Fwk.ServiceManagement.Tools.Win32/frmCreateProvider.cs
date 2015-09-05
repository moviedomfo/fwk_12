using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Fwk.ConfigSection;
using System.Reflection;
using Fwk.Bases.FrontEnd;
using Fwk.Bases;

namespace Fwk.ServiceManagement.Tools.Win32
{
    public partial class frmCreateProvider : FrmBase
    {
        System.Configuration.Configuration configuration;
        public ServiceProviderElement CreatedProvider;
        public frmCreateProvider()
        {
            InitializeComponent();
            ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name + ".config";
            configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

            cboType.SelectedIndex = 0;

            foreach (ConnectionStringSettings cnn in ConfigurationManager.ConnectionStrings)
            {
                if (!cnn.Name.Equals("LocalSqlServer"))
                cboCnnStrings.Items.Add(cnn.Name);
            }
            cboCnnStrings.SelectedIndex = 0;
            txtName.Focus();
        }


       
        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.Text == "xml")
            {
                tabControl1.SelectedIndex = 0;
                groupBox2.Enabled = true;
                groupBox1.Enabled = false;
            }
            else
            {
                tabControl1.SelectedIndex = 1;
                groupBox2.Enabled = false;
                groupBox1.Enabled = true;
            }
         
        }

        private void btnSearAssemblie_Click(object sender, EventArgs e)
        {
            if (cboType.Text == "xml")
            {
                OpenFileDialog wSchemaDialog = new OpenFileDialog();
                wSchemaDialog.DefaultExt = "";
                wSchemaDialog.CheckFileExists = true;

                wSchemaDialog.Filter = "xml Files (*.xml)|*.xml";
                wSchemaDialog.ShowReadOnly = true;
                if (wSchemaDialog.ShowDialog() == DialogResult.OK)
                {

                    ServiceConfigurationCollection wServiceConfigurationCollection = new ServiceConfigurationCollection(); //Fwk.Configuration.Common.ConfigurationFile.GetFromXml<Fwk.Configuration.Common.ConfigurationFile>(Fwk.se);
                    try
                    {
                        wServiceConfigurationCollection.SetXml(Fwk.HelperFunctions.FileFunctions.OpenTextFile(wSchemaDialog.FileName));
                    }
                    catch
                    {
                        base.ExceptionViewer.Show(new Exception("Incorrect service configuration file"));
                        return;
                    }
                    txtSource.Text = wSchemaDialog.FileName;
                }
                else
                { 

                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!Validate()) return;
            CreatedProvider = new ServiceProviderElement();
            if (cboType.Text == "xml")
            {
                CreatedProvider.SourceInfo = txtSource.Text;
            }
            else
            {
                CreatedProvider.SourceInfo = txtCnnStringName.Text;
                AddNewCnnString();
            }

            CreatedProvider.Name = txtName.Text;
            CreatedProvider.ApplicationId = txtApplicationId.Text;

            CreatedProvider.ProviderType = (ServiceProviderType)Enum.Parse(typeof(ServiceProviderType), cboType.Text);
            AddNewProvider(CreatedProvider);

            this.DialogResult = DialogResult.OK; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool Validate()
        {
            if (String.IsNullOrEmpty(txtName.Text))
            {
                base.ExceptionViewer.Show(new Exception("Name is required."));
                txtName.Focus();
                return false;
            }
            if (cboType.Text == "xml")
            {
                if (CheckFile()== false)
                    return false; 
            }
            else
            {
                if (radioButton2.Checked)
                {
                    if (String.IsNullOrEmpty(txtCnnStringValue.Text))
                    {
                        base.ExceptionViewer.Show(new Exception("Connection string"));
                        txtCnnStringValue.Focus();
                        return false;
                    }

                    if (String.IsNullOrEmpty(txtCnnStringName.Text))
                    {
                        base.ExceptionViewer.Show(new Exception("Connection string name is required."));
                        txtCnnStringName.Focus();
                        return false;
                    }
                }
                if (radioButton1.Checked)
                    if (String.IsNullOrEmpty(cboCnnStrings.Text))
                    {
                        base.ExceptionViewer.Show(new Exception("Connection string name is required."));
                        cboCnnStrings.Focus();
                        return false;
                    }
            }
            return true; 
        }
        bool CheckFile()
        {
            if (!System.IO.File.Exists(txtSource.Text))
            {
                base.ExceptionViewer.Show(new Exception("File not exist"));
                return false;
            }
            ServiceConfigurationCollection wServiceConfigurationCollection = new ServiceConfigurationCollection();
            try
            {
                wServiceConfigurationCollection.SetXml(Fwk.HelperFunctions.FileFunctions.OpenTextFile(txtSource.Text));
            }
            catch
            {
                base.ExceptionViewer.Show(new Exception("Incorrect service configuration file"));
                return false;
            }

            return true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cboCnnStrings.Enabled = radioButton1.Checked;
            txtCnnStringName.ReadOnly = radioButton1.Checked;
            txtCnnStringValue.ReadOnly = radioButton1.Checked;

            if (radioButton1.Checked)
                txtCnnStringName.Text = cboCnnStrings.Text;
            else
                txtCnnStringName.Text = string.Empty;
        }

        //Agrega nueva cadena de coneccion si radioButton1.Checked = true   
        void AddNewCnnString()
        {
            if (radioButton1.Checked == true) return;
            ConnectionStringsSection config = (ConnectionStringsSection)configuration.Sections["connectionStrings"];

            ConnectionStringSettings wConnectionStringSettings = new ConnectionStringSettings( txtCnnStringName.Text,txtCnnStringValue.Text, "System.Data.SqlClient");
            config.ConnectionStrings.Add(wConnectionStringSettings);
            configuration.Save(ConfigurationSaveMode.Minimal, true);
        }

        void AddNewProvider(ServiceProviderElement newProvider)
        {
            try
            {

                ServiceProviderSection config = (ServiceProviderSection)configuration.Sections["FwkServiceMetadata"];
                config.Providers.Add(newProvider);

                configuration.Save(ConfigurationSaveMode.Minimal, true);
                
                ServiceMetadata.ProviderSection.Providers.Add(newProvider);
            }
            catch (Exception ex)
            {
                this.ExceptionViewer.Show(ex);
            }
        }

        private void cboCnnStrings_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCnnStringName.Text = cboCnnStrings.Text;
        }

       
    }
}
