using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Web.Security;
using Fwk.Security.Common;
using System.Security.Principal;
using Fwk.Bases.FrontEnd.Controls;
using Fwk.Security;
using Fwk.Security.Admin.Controls;
using System.Reflection;
using Fwk.UI.Controls;

namespace Fwk.Security.Admin
{
    public partial class frmAdmin : frmSecBase
    {
        bool onInit = true;
        SecurityControlBase currontSecurityControlBase;
        public static MembershipProvider Provider = null;//Membership.Provider;
        public static Boolean CurrentProviderConnectedOk = false;
        public frmAdmin()
        {

            InitializeComponent();
            try
            {
                Provider = System.Web.Security.Membership.Provider;
            }
            catch(System.Configuration.Provider.ProviderException ex)
                {
                    ExceptionViewComponent wExceptionViewer = new ExceptionViewComponent();
                    wExceptionViewer.ButtonsYesNoVisible = DevExpress.XtraBars.BarItemVisibility.Always;
                    wExceptionViewer.Title = "Error de configuracion ";

                   wExceptionViewer.Show(wExceptionViewer.Title, ex.Message, string.Empty, false);

                }
            this.Text = string.Concat(this.Text, " version ", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            SetEnabledItems();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User user = FwkMembership.GetUser(Environment.UserName, frmAdmin.Provider.Name);
        }

        private void navBarControl1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                currontSecurityControlBase = ControlsFactory.Show(e.Link, this.panelControl1);
                //Esto se hace de esta manera ya que el tree listo no se carga correctamente la  primera vez que se levanta el control
                if (currontSecurityControlBase.GetType() == typeof(RulesEditControl))
                    ((RulesEditControl)currontSecurityControlBase).PopulateAsync();
            }
            catch (Exception ex)
            {
                base.MessageViewInfo.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
            }


        }

        private void cmbProviders_EditValueChanged(object sender, EventArgs e)
        {

            Connect();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            cmbProviders.Properties.DataSource = FwkMembership.GetAllMembershiproviderNameArray();
            cmbProviders.ItemIndex = 0;
            navBarControl1.SelectedLink = navBarItem2.Links[0];

            onInit = false;
        }

        private void btnRefreshConnection_Click(object sender, EventArgs e)
        {
            Connect();
        }

        void Connect()
        {
            try
            {

                this.Cursor = Cursors.WaitCursor;
                frmAdmin.Provider = System.Web.Security.Membership.Providers[cmbProviders.Text];
                RoleProvider wRoleProvider =  FwkMembership.GetRoleProvider(cmbProviders.Text);
                string cnnString = FwkMembership.GetProvider_ConnectionString(frmAdmin.Provider.Name);
                Fwk.DataBase.CnnString cnn = new DataBase.CnnString("", cnnString);

                lblServer.Text = cnn.DataSource;
                lblDatabase.Text = cnn.InitialCatalog;
                lblCnnString.Text = cnn.ToString();
                if (!onInit)
                {
                    DataBase.Metadata m = new DataBase.Metadata(cnn);

                    if (m.TestConnection())
                    {
                        CurrentProviderConnectedOk = true;
                        lblConnectionStatus.Text = "Connected";
                        this.btnRefreshConnection.Image = global::Fwk.Security.Admin.Properties.Resources.Connection_Check;
                        this.btnRefreshConnection.Text = "Refresh";
                    }
                    else
                    {
                        CurrentProviderConnectedOk = false;
                        lblConnectionStatus.Text = "Disconected";
                        this.btnRefreshConnection.Image = global::Fwk.Security.Admin.Properties.Resources.Connection_Warning;
                        this.btnRefreshConnection.Text = "Try reconnect";
                    }

                }
            }
            catch (Exception ex)
            {
                CurrentProviderConnectedOk = false;
                lblConnectionStatus.Text = "Disconected";
                this.btnRefreshConnection.Image = global::Fwk.Security.Admin.Properties.Resources.Connection_Warning;
                this.btnRefreshConnection.Text = "Try reconnect";

                base.MessageViewInfo.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
            }
            if (currontSecurityControlBase == null)
            {
                this.Cursor = Cursors.Arrow;
                return;
            }
            try
            {
                currontSecurityControlBase.Initialize();

            }
            catch (Exception ex)
            {
                CurrentProviderConnectedOk = false;
                lblConnectionStatus.Text = "Disconected";
                base.MessageViewInfo.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
            }
            this.Cursor = Cursors.Arrow;
        }


        void SetEnabledItems()
        {
            bool IsSoftwareFactory = false;
            if (System.Configuration.ConfigurationManager.AppSettings["sf"] != null)
            {

                Boolean.TryParse(System.Configuration.ConfigurationManager.AppSettings["sf"], out IsSoftwareFactory);

            }

            navBarItem_Encrypt.Enabled =
              
                navBarItem_CategoryCreate.Enabled =
                navBarItem_Check_Rule.Enabled = navBarItem_CreateRule.Enabled =
               navBarItem_RoleCreate.Enabled = IsSoftwareFactory;

        }
    }
}
