using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fwk.Bases;

namespace VivaldiSite
{
    public partial class disp_main_service_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null ||
                Request.QueryString["url"] == null ||
                Request.QueryString["prov"] == null)
            {
                //Response.Redirect(WebUserControlsConstants.NavigateUrl_Home);
            }
            string id = Request.QueryString["id"].ToString();
            string url = Request.QueryString["url"].ToString();
            string prov = Request.QueryString["prov"].ToString();

            Fwk.Bases.Connector.WebServiceWrapper wrapper = new Fwk.Bases.Connector.WebServiceWrapper();
            wrapper.ServiceMetadataProviderName = prov;
            wrapper.SourceInfo = url;

            ServiceConfiguration svc = wrapper.GetServiceConfiguration(id);

            txtName.Text = svc.Name;
            txtReq.Text = svc.Request;
            txtRes.Text = svc.Response;
            txtSVC.Text = svc.Handler;
            chkAudit.Checked = svc.Audit;
            chkAvailable.Checked = svc.Available;
            int index = -1;
            ListItem item = cmbTransactionalBehaviour.Items.FindByText(svc.TransactionalBehaviour.ToString());
            if (item != null)
            {
                index = cmbTransactionalBehaviour.Items.IndexOf(item);
                cmbTransactionalBehaviour.SelectedIndex = index;
            }
            item = cmbIsolationLevel.Items.FindByText(svc.IsolationLevel.ToString());
            if (item != null)
            {
                index = cmbIsolationLevel.Items.IndexOf(item);
                cmbIsolationLevel.SelectedIndex = index;
            }
        }

        protected void frm_btGrisNegrita_Click(object sender, EventArgs e)
        {

        }


    }
}