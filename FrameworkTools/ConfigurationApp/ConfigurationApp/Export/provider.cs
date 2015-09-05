using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.ConfigSection;

namespace ConfigurationApp
{
    public partial class provider : UserControl
    {
        ConfigProviderElement Provider;
        public provider()
        {
            InitializeComponent();
        }

        public void Populate(ConfigProviderElement pProvider)
        {
            Provider = pProvider;
            if (pProvider == null) return;
            SetProvider();
        }

        void SetProvider()
        {

            lblConnectionType.Text = Provider.ConfigProviderType.ToString();
            txtConfigName.Text = Provider.BaseConfigFile;
        
            cnnstring.Clear();
            if (Provider.ConfigProviderType == ConfigProviderType.local)
            {
                cnnstring.Visible = false;
                lblAddress.Text = "File :";
         
            }
            if (Provider.ConfigProviderType == ConfigProviderType.sqldatabase)
            {
               
                lblAddress.Text = "Connection string";
                if (System.Configuration.ConfigurationManager.ConnectionStrings[Provider.SourceInfo] != null)
                {
                    Fwk.DataBase.CnnString c = new Fwk.DataBase.CnnString(Provider.SourceInfo, System.Configuration.ConfigurationManager.ConnectionStrings[Provider.SourceInfo].ConnectionString);
                    cnnstring.Populate(c);
                    cnnstring.Visible = true;
                }

            }
        }

      
    }
}
