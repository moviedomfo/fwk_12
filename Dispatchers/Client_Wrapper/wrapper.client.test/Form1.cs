using Client;
using Fwk.Bases;
using Fwk.Bases.ISVC;
using Fwk.ConfigSection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace wrapper.client.test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); FillProviders();
        }

        private void btnRetrivePatients_Click(object sender, EventArgs e)
        {
            if (_IServiceWrapper == null)
            { 
                txtRes.Text = "Seleccione un wrapper";
                return;
            }
            DispatcherInfoBE res = _IServiceWrapper.CheckServiceAvailability(true, true, true);

            txtRes.Text = res.GetXml();

        }
        void FillProviders()
        {
            List<wrap_provider> providers = new List<wrap_provider>();
            foreach (WrapperProviderElement p in WrapperFactory.ProviderSection.Providers)
            {
                providers.Add(new wrap_provider(p));
            }
            wrapproviderBindingSource.DataSource = providers;
            comboProviders.Refresh();

        }
        wrap_provider current_wrap_provider = null;
        IServiceWrapper _IServiceWrapper = null;
        private void comboProviders_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_wrap_provider = comboProviders.SelectedItem as wrap_provider;
            StringBuilder str = new StringBuilder("Wrapper name: " + current_wrap_provider.Name);
            str.AppendLine();
            str.AppendLine("SourceInfo: " + current_wrap_provider.SourceInfo);
            str.AppendLine("WrapperProviderType: " + current_wrap_provider.WrapperProviderType);
            str.AppendLine("ApplicationId: " + current_wrap_provider.ApplicationId);
            txtRes.Text = str.ToString();

            _IServiceWrapper = Fwk.Bases.WrapperFactory.GetWrapper(current_wrap_provider.Name);
        }

        
    }
}
