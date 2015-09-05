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
using Fwk.Bases.FrontEnd;

namespace Fwk.ServiceManagement.Tools.Win32
{
    public partial class frmExport1 : FrmBase
    {
        ServiceProviderElement _SourceProvider;
        ServiceProviderElement _SelectedProvider;
      
        public frmExport1(ServiceProviderElement sourceProvider)
        {
            _SourceProvider = sourceProvider;
            InitializeComponent(); 
            LoadConfig();
        }
        void LoadConfig()
        {
      

            SetProviderSource();
            SetProviderDest();


            //cargo la grilla izquierda
            ucbServiceGrid1.Services = ServiceMetadata.GetAllServices(_SourceProvider.Name);
            ucbServiceGrid1.Applications = ServiceMetadata.GetAllApplicationsId(_SourceProvider.Name);
    
            //lleno el combo de posibles proveedores destino
            foreach (ServiceProviderElement p in ServiceMetadata.ProviderSection.Providers)
            {
                if (!_SourceProvider.Name.Equals(p.Name))
                    cmb2.Items.Add(p.Name);
            }


            cmb2.SelectedIndex = 0;
            _SelectedProvider = ServiceMetadata.ProviderSection.GetProvider(cmb2.SelectedItem.ToString());

            cmb2.SelectedValueChanged += new EventHandler(cb_SelectedValueChanged);


            this.Text = string.Concat("Export data from ", _SourceProvider.Name, " to ", _SourceProvider.Name);
        }

        /// <summary>
        /// CAmbia el proveedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cb_SelectedValueChanged(object sender, EventArgs e)
        {

            _SelectedProvider = ServiceMetadata.ProviderSection.GetProvider(cmb2.SelectedItem.ToString());

            SetProviderDest() ;


            try
            {
                
                //cargo la grilla derecha
                ucbServiceGrid2.Services = ServiceMetadata.GetAllServices(_SelectedProvider.Name);
                ucbServiceGrid2.Applications = ServiceMetadata.GetAllApplicationsId(_SelectedProvider.Name);

            

                //muestro el titulo
                this.Text = string.Concat("Export data from ", _SelectedProvider.Name, " to ", _SelectedProvider.Name);
            }
            catch (Exception ex)
            {

                base.ExceptionViewer.Show(ex);
               
                ucbServiceGrid1.Services = null;

            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            using (frmExport2 frm = new frmExport2(_SourceProvider,_SelectedProvider,ucbServiceGrid1.SelecdedServices))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if(frm.HasErrors)
                        this.MessageViewer.Show("Export terminated with warnings or errors!! ");
                    else
                        this.MessageViewer.Show("Export terminated successfully !! ");
                }
            }
        }


        void SetProviderSource()
        {
            provider1.Populate(_SourceProvider);
          
        }

        void SetProviderDest()
        {
            provider2.Populate(_SelectedProvider);
        }
        
    }
}
