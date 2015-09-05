using System;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Fwk.Bases;
using Fwk.HelperFunctions;
using System.Configuration;
using Fwk.ConfigSection;
using Fwk.Exceptions;
using System.Reflection;


namespace Fwk.ServiceManagement.Tools.Win32
{
    /// <summary>
    /// 
    /// </summary>
	public partial class frmServices : Fwk.Bases.FrontEnd.FrmBase
	{   
        string _AuxServiceName;
        public static ServiceProviderElement CurrentProvider;
		/// <summary>
		/// Constructor por defecto.
		/// </summary>
		/// <date>2007-07-13T00:00:00</date>
		/// <author>moviedo</author>
		public frmServices()
		{
			InitializeComponent();
            cnfg();
            ctrlService1.ShowAction = Action.Query;
            this.Text = string.Concat(this.Text, " v.", Assembly.GetExecutingAssembly().GetName().Version.ToString());
		}


		#region < Actions methods >

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                ucbServiceGrid1.Services = ServiceMetadata.GetAllServices(frmServices.CurrentProvider.Name);

                ucbServiceGrid1.Applications = ServiceMetadata.GetAllApplicationsId(CurrentProvider.Name);
                provider1.SetConnected(true);
            }
            catch(Exception ex)
            {
               
                base.ExceptionViewer.Show(ex);
                provider1.SetConnected(false);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddService(); 
            ucbServiceGrid1.RefreshServices();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditService(); ucbServiceGrid1.RefreshServices();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteService(); ucbServiceGrid1.RefreshServices();
        }



		/// <summary>
		/// Crea una nueva configuración de servicio de negocio.
		/// </summary>
		/// <date>2007-07-13T00:00:00</date>
		/// <author>moviedo</author>
        private void AddService()
        {
            if (ucbServiceGrid1.Services == null)
            {
                base.MessageViewer.Show("Debe conectarce al despachaor de servicio antes de ejecutar esta operación");
                return;
            }

            ServiceConfiguration wServiceNew = new ServiceConfiguration();
            
            if (frmEdit.ShowNew(ref wServiceNew) == DialogResult.OK)
            {
                wServiceNew.CreatedUserName = Environment.UserName;
                wServiceNew.CreatedDateTime = System.DateTime.Now;
                wServiceNew.ApplicationId = CurrentProvider.ApplicationId;
                try
                {
                    //ucbServiceGrid1.Add(wServiceNew);

             
                    //base.Wrapper.AddServiceConfiguration(CurrentProvider.Name, wServiceNew);
                    Fwk.ServiceManagement.ServiceMetadata.AddServiceConfiguration(CurrentProvider.Name, wServiceNew);
                   
                }
                catch(Exception ex)
                {
                    base.MessageViewer.Show(ex.Message);
                }
            }
        }

		/// <summary>
		/// Edita una configuración de servicio de negocio.
		/// </summary>
		/// <date>2007-07-13T00:00:00</date>
		/// <author>moviedo</author>
		private void EditService()
		{
            if (ucbServiceGrid1.Services == null)
            {
                base.MessageViewer.Show("Debe conectarce al despachaor de servicio antes de ejecutar esta operación");
                return;
            }
            if (ucbServiceGrid1.CurentServiceConfiguration == null)
            {
                base.MessageViewer.Show("Seleccione un servicio para configurar");
                return;
            }
             _AuxServiceName  = ucbServiceGrid1.CurentServiceConfiguration.Name;
            ServiceConfiguration clon = ucbServiceGrid1.CurentServiceConfiguration.Clone();
            if (frmEdit.ShowEdit(clon) == DialogResult.OK)
            {
                //Fwk.ServiceManagement.ServiceMetadata.SetServiceConfiguration(CurrentProvider.Name, _AuxServiceName, ucbServiceGrid1.CurentServiceConfiguration);
                Fwk.ServiceManagement.ServiceMetadata.SetServiceConfiguration(CurrentProvider.Name, _AuxServiceName, clon);
                ServiceConfiguration s = ucbServiceGrid1.CurentServiceConfiguration;
               
                Fwk.HelperFunctions.ReflectionFunctions.MapProperties<ServiceConfiguration>(clon, ref s);
     
            }
            ucbServiceGrid1_OnClickServiceHandler(ucbServiceGrid1.CurentServiceConfiguration);   
		}
       
		/// <summary>
		/// Elimina configuración de servicio de negocio.
		/// </summary>
		/// <date>2007-07-13T00:00:00</date>
		/// <author>moviedo</author>
		private void DeleteService()
		{
            if (ucbServiceGrid1.Services == null)
            {
                base.MessageViewer.Show("Debe conectarce al despachaor de servicio antes de ejecutar esta operación");
                return;
            }
            if (ucbServiceGrid1.CurentServiceConfiguration == null)
            {
                base.MessageViewer.Show("Seleccione un servicio para configurar");
                return;
            }
            base.MessageViewer.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Question;
            base.MessageViewer.MessageBoxButtons = MessageBoxButtons.OKCancel;
            DialogResult wDialogResult = base.MessageViewer.Show("Confirma la eliminación de la configuración del servicio " + ucbServiceGrid1.CurentServiceConfiguration.Name);
            base.SetMessageViewInfoDefault();
            if (wDialogResult == DialogResult.OK)
            {
                Fwk.ServiceManagement.ServiceMetadata.DeleteServiceConfiguration(CurrentProvider.Name, ucbServiceGrid1.CurentServiceConfiguration.Name);
                ucbServiceGrid1.RemoveCurrent();
               
                //base.Wrapper.DeleteServiceConfiguration(CurrentProvider.Name, ucbServiceGrid1.CurentServiceConfiguration.Name);
            }

            ctrlService1.EntityParam = ucbServiceGrid1.CurentServiceConfiguration;
            ctrlService1.Populate();
		}

		#endregion

        private void ucbServiceGrid1_OnClickServiceHandler(ServiceConfiguration pServiceConfiguration)
        {
           
            ctrlService1.EntityParam = pServiceConfiguration;
            ctrlService1.Populate();

        }



        void cnfg()
        {
            
          
            
            provider1.SetConnected(false);

            ComboBox cb = (ComboBox)cmbProviders.Control;

            foreach (ServiceProviderElement p in ServiceMetadata.ProviderSection.Providers)
            {
                cb.Items.Add(p.Name);
            }

            cmbProviders.SelectedIndex = 0;
            CurrentProvider = ServiceMetadata.ProviderSection.GetProvider(cmbProviders.SelectedItem.ToString());
            provider1.Populate(CurrentProvider);

            cb.SelectedValueChanged += new EventHandler(cb_SelectedValueChanged);

        }

        void cb_SelectedValueChanged(object sender, EventArgs e)
        {

            CurrentProvider = ServiceMetadata.ProviderSection.GetProvider(cmbProviders.SelectedItem.ToString());

            provider1.Populate(CurrentProvider);
           
            try
            {

               ucbServiceGrid1.Services = Fwk.ServiceManagement.ServiceMetadata.GetAllServices(CurrentProvider.Name);

                ucbServiceGrid1.Applications = Fwk.ServiceManagement.ServiceMetadata.GetAllApplicationsId(CurrentProvider.Name);
                provider1.SetConnected(true);
            }
            catch (Exception ex)
            {

                base.ExceptionViewer.Show(ex);
                provider1.SetConnected(false);
                ucbServiceGrid1.Services = null;

            }
        }

        //void SetProvider()
        //{

        //    //lblConnectionType.Text = CurrentProvider.ProviderType.ToString();
        //    //txtAddres.Text = CurrentProvider.SourceInfo;
        //    //txtApplicationId.Text = CurrentProvider.ApplicationId;
        //    //cnnstring.Clear();
        //    //if (CurrentProvider.ProviderType == ServiceProviderType.xml)
        //    //{
        //    //    cnnstring.Visible = false;
        //    //    lblAddress.Text = "File :";
        //    //    btnView.Visible = true;
        //    //}
        //    //if (CurrentProvider.ProviderType == ServiceProviderType.sqldatabase)
        //    //{
        //    //    btnView.Visible = false;
        //    //    lblAddress.Text = "Connection string";
        //    //    if (System.Configuration.ConfigurationManager.ConnectionStrings[CurrentProvider.SourceInfo] != null)
        //    //    {
        //    //        Fwk.DataBase.CnnString c = new Fwk.DataBase.CnnString(CurrentProvider.SourceInfo, System.Configuration.ConfigurationManager.ConnectionStrings[CurrentProvider.SourceInfo].ConnectionString);
        //    //        cnnstring.Populate(c);
        //    //        cnnstring.Visible = true;
        //    //    }
               
        //    //}
        //} 
        private void button1_Click(object sender, EventArgs e)
        {
            frmAssemblyExplorer f = new frmAssemblyExplorer();
            f.ShowDialog();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            
          
      

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (frmExport1 frm = new frmExport1(CurrentProvider))
            {
                frm.ShowDialog();
            }
        }

        private void btnNewProvider_Click(object sender, EventArgs e)
        {
            //using (frmManageProviders frm = new frmManageProviders())
            //{
            //    frm.ShowDialog();
             
            //}
            using (frmCreateProvider frm = new frmCreateProvider())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    ComboBox cb = (ComboBox)cmbProviders.Control;
                    cb.Items.Clear();
                    int index = 0;
                    foreach (ServiceProviderElement p in ServiceMetadata.ProviderSection.Providers)
                    {
                        cb.Items.Add(p.Name);
                        if (frm.CreatedProvider.Name.Equals(p.Name)) cb.SelectedIndex = index;
                        index++;
                        
                    }

                    
                   

                }
            }
        }

       
       

      

       
	}
}