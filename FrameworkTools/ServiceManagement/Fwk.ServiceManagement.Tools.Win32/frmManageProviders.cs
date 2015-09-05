using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fwk.Bases.FrontEnd;
using Fwk.ConfigSection;

namespace Fwk.ServiceManagement.Tools.Win32
{
    public partial class frmManageProviders : FrmBase
    {
        System.Configuration.Configuration configuration;
        public frmManageProviders()
        {
            InitializeComponent();
            ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name + ".config";
            configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            init();
        }

        void init()
        {
            List<Provider> list = new List<Provider>();
            foreach (ServiceProviderElement p in ServiceMetadata.ProviderSection.Providers)
            {
                list.Add(new Provider(p));
            }

            providerBindingSource1.DataSource = list;
            grdProviders.Refresh();
        }

        void RemoveProvider(Provider selectedProvider)
        {
           
        
            try
            {

                ServiceProviderSection config = (ServiceProviderSection)configuration.Sections["FwkServiceMetadata"];

                config.Providers.Remove(selectedProvider.Name);
                
                configuration.Save(ConfigurationSaveMode.Minimal, true);
                
                //ServiceMetadata.ProviderSection.Providers.Add(newProvider);
            }
            catch (Exception ex)
            {
                this.ExceptionViewer.Show(ex);
            }
        
        }

        private void grdProviders_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdProviders_MouseClick(object sender, MouseEventArgs e)
        {
            Provider selectedProvider = (Provider)grdProviders.CurrentRow.DataBoundItem;
            provider1.Populate(selectedProvider);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Provider selectedProvider = (Provider)grdProviders.CurrentRow.DataBoundItem;
            RemoveProvider(selectedProvider);
        }
    }
}
