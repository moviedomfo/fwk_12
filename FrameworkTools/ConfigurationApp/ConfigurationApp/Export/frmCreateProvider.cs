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
using System.IO;

namespace ConfigurationApp
{
    public partial class frmCreateProvider : FrmBase
    {
        System.Configuration.Configuration configuration;
        public ConfigProviderElement CreatedProvider;

        public frmCreateProvider(string fileName)
        {
            InitializeComponent();

            txtConfigFileName.Text = fileName;
            txtSource.Text = fileName;
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

        private void btnSearhAssemblie_Click(object sender, EventArgs e)
        {
            if (cboType.Text == "xml")
            {
                OpenFileDialog wDialog = new OpenFileDialog();
                wDialog.DefaultExt = "";
                wDialog.CheckFileExists = true;

                wDialog.Filter = "xml Files (*.xml)|*.xml";
                wDialog.ShowReadOnly = true;
                if (wDialog.ShowDialog() == DialogResult.OK)
                {
         
                    if (CheckFile(wDialog.FileName))
                        txtSource.Text = wDialog.FileName;
                }

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!Validate()) return;
            CreatedProvider = new ConfigProviderElement();
            if (cboType.Text == "xml")
            {
                CreatedProvider.BaseConfigFile = txtSource.Text;
                CreatedProvider.ConfigProviderType = ConfigProviderType.local;
            }
            else
            {
                CreatedProvider.BaseConfigFile = txtConfigFileName.Text;
                CreatedProvider.SourceInfo = txtCnnStringName.Text;
                CreatedProvider.ConfigProviderType = ConfigProviderType.sqldatabase;
                AddNewCnnString();
            }

            CreatedProvider.Name = txtName.Text;
   

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
                if (CheckFile(txtSource.Text) == false)
                    return false; 
            }
            if (string.IsNullOrEmpty(txtConfigFileName.Text))
            {
                base.ExceptionViewer.Show(new Exception("Config name is required."));
                txtConfigFileName.Focus();
                return false;
            }
            else //SQL server
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
        bool CheckFile(string fileName)
        {
            if (!System.IO.File.Exists(fileName))
            {
                base.ExceptionViewer.Show(new Exception("File not exist"));
                return false;
            }
            Fwk.Configuration.Common.ConfigurationFile file = new Fwk.Configuration.Common.ConfigurationFile();
            try
            {
                file.SetXml(Fwk.HelperFunctions.FileFunctions.OpenTextFile(fileName));
            }
            catch
            {
                base.ExceptionViewer.Show(new Exception("Incorrect configuration file"));
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

        void AddNewProvider(ConfigProviderElement newProvider)
        {
            try
            {
               
                ConfigProviderSection config = (ConfigProviderSection)configuration.Sections["FwkConfigProvider"];
                config.Providers.Add(newProvider);
                
                configuration.Save(ConfigurationSaveMode.Minimal, true);

                Fwk.Configuration.ConfigurationManager.ConfigProvider.Providers.Add(newProvider);
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

        private void txtSource_TextChanged(object sender, EventArgs e)
        {
            if (CheckFile(txtSource.Text))
            {
                FileInfo f = new FileInfo(txtSource.Text);
                txtConfigFileName.Text = f.Name;
            }
            else
            {
                txtSource.SelectAll();
            }
        }

       

       
    }
}
