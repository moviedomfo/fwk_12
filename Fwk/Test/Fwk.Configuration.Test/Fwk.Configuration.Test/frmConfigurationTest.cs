using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fwk.Configuration.Common;
using System.IO;

namespace Fwk.Configuration.Test
{
    public partial class frmConfigurationTest : Form
    {
        public frmConfigurationTest()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            txtDefaulProvider.Text = ConfigurationManager.DefaultProvider.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox4.Text = ConfigurationManager.GetProperty("svc", "ClientMessages", "contrato_comercial_obligatorio");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();
            try
            {
                
                textBox2.Text  = ConfigurationManager.GetProperty(txtGroupName.Text, txtProrpetieName.Text);
           
               
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
          

        }

        private void btnLoadConfigFile_Click(object sender, EventArgs e)
        {
            Fwk.Configuration.Common.Key wKey;
            Fwk.Configuration.Common.Groups wGroups;
            Fwk.Configuration.Common.Group wGroup;
            wGroups = new Fwk.Configuration.Common.Groups();
            ConfigurationFile wConfigurationFile = new ConfigurationFile();
            wConfigurationFile.CurrentVersion = "1.1";
            wConfigurationFile.Encrypted = false;
        


            wGroup = new Fwk.Configuration.Common.Group();
            wGroup.Name = "G1";
            wKey = new Fwk.Configuration.Common.Key();
            wKey.Name = "K1";
            wKey.Value.Text= "aaaaaaaaaaaaaaaaa";

            wGroup.Keys.Add(wKey);

            wKey = new Fwk.Configuration.Common.Key();
            wKey.Name = "K2";
            wKey.Value.Text = "cccccccccccccccccccccccccccccccccc";
            wGroup.Keys.Add(wKey);


            wGroups.Add(wGroup);



           

            wGroup = new Fwk.Configuration.Common.Group();
            wGroup.Name = "G2";
            wKey = new Fwk.Configuration.Common.Key();
            wKey.Name = "K1";
            wKey.Value.Text = "aaaaaaaaaaaaaaaaa";

            wGroup.Keys.Add(wKey);

            wKey = new Fwk.Configuration.Common.Key();
            wKey.Name = "K2";
            wKey.Value.Text = "cccccccccccccccccccccccccccccccccc";
            wGroup.Keys.Add(wKey);


            wGroups.Add(wGroup);
            wConfigurationFile.Groups = wGroups;

            xmlConfitFile.Text = wConfigurationFile.GetXml();
            xmlConfitFile.ForeColor = Color.Green;
        }

        private void btnGetProvider_Click(object sender, EventArgs e)
        {
            try
            {
                groupBindingSource.DataSource = ConfigurationManager.GetConfigurationFile(Path.Combine(Application.StartupPath, textBox3.Text)).Groups;
                grdGroups.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string xml = HelperFunctions.FileFunctions.OpenTextFile(Path.Combine( Application.StartupPath , txtConfigFileName.Text));

            ConfigurationFile wConfigurationFile = Fwk.Configuration.Common.ConfigurationFile.GetFromXml<ConfigurationFile>(xml);
          
            xmlConfitFile.ForeColor = Color.Red;

            xmlConfitFile.Text = wConfigurationFile.GetXml();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                ConfigurationFile wConfigurationFile = (ConfigurationFile)HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(ConfigurationFile), xmlConfitFile.Text);
                xmlConfitFile.ForeColor = Color.Blue;
                xmlConfitFile.Text = wConfigurationFile.GetXml();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetGroupKeys_Click(object sender, EventArgs e)
        {
            try
            {
                keyBindingSource.DataSource = ConfigurationManager.GetGroup(comboBox1.Text, txtGroupName.Text).Keys;
                grdGroups.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnchangeDefaulProvider_Click(object sender, EventArgs e)
        {
            ConfigurationManager.ChangeDefaultProvider("localFile");
            txtDefaulProvider.Text = ConfigurationManager.DefaultProvider.Name;
            txtValueChangeDefaultProvider.Text = ConfigurationManager.GetProperty("ExceptionMessages", "fecha_desde_igual_hasta_error");
        }
    }
}