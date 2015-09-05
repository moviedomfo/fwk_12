using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fwk.ConfigSection;
using VivaldiSite.DAC;
using Fwk.ConfigData;
using Fwk.Bases;

namespace VivaldiSite
{
    public partial class disp_main_services : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["disp_inst"] == null)
            {
                //Response.Redirect(WebUserControlsConstants.NavigateUrl_Home);
            }
            string disp_inst = Request.QueryString["disp_inst"].ToString();
            if (!IsPostBack)
            {
                if (DataCoreDAC.Dispatcher_Exist(disp_inst, null))
                {

                    fwk_ServiceDispatcher disp = DataCoreDAC.Dispatcher_Get(disp_inst);
                    txtUrl.Text = disp.Url_URI;
                    txtServerName.Text = disp.HostName;
                    txtInstanceName.Text = disp.InstanseName;

                    DispatcherInfo wDispatcherInfo = GetDispatcherInfo(disp.Url_URI);
                    if (wDispatcherInfo != null)
                    {
                        grdMetadataProvider.DataSource = wDispatcherInfo.MetadataProviders;
                        grdMetadataProvider.DataBind();


                        ServiceConfigurationCollection services = GetAllServices(txtUrl.Text, "");
                        grid_ProviderServices.DataSource = services;
                        grid_ProviderServices.DataBind();
                    }

                }

            }
        }


        DispatcherInfo GetDispatcherInfo(string url_URI)
        {
            Fwk.Bases.Connector.WebServiceWrapper wrapper = new Fwk.Bases.Connector.WebServiceWrapper();
            wrapper.SourceInfo = url_URI;

            DispatcherInfo wDispatcherInfo = null;
            #region retrive info from server
            try
            {
                wDispatcherInfo = wrapper.RetriveDispatcherInfo();
                UpdatePanel1.Visible = false;
            }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;

                UpdatePanel1.Visible = true;
                return null;
            }
            #endregion

            if (wDispatcherInfo == null)
            {
                msgError.Text = "No fue posible establecer conexión con el dispatcher intentelo mas tarde o pongace en contacto con el administrador del mismo";
                UpdatePanel1.Visible = true;

                return null;
            }
            return wDispatcherInfo;
        }
        ServiceConfigurationCollection GetAllServices(string url_URI, string serviceMetadataProviderName)
        {
            Fwk.Bases.Connector.WebServiceWrapper wrapper = new Fwk.Bases.Connector.WebServiceWrapper();
            wrapper.SourceInfo = url_URI;
            wrapper.ServiceMetadataProviderName = serviceMetadataProviderName;
            ServiceConfigurationCollection services = null;
            #region retrive info from server
            try
            {
                services = wrapper.GetAllServices();
                UpdatePanel1.Visible = false;
            }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;

                UpdatePanel1.Visible = true;
                return null;
            }
            #endregion

            if (services == null)
            {
                msgError.Text = "No fue posible establecer conexión con el dispatcher intentelo mas tarde o pongace en contacto con el administrador del mismo";
                UpdatePanel1.Visible = true;

                return null;
            }
            return services;
        }


        string selectedProvider;
        protected void grdMetadataProvider_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            switch (e.CommandName)
            {
                case ("View"):
                    {

                        selectedProvider = e.CommandArgument.ToString();
                        ServiceConfigurationCollection services = GetAllServices(txtUrl.Text, selectedProvider);
                        grid_ProviderServices.DataSource = services;
                        grid_ProviderServices.DataBind();

                        break;
                    }
            }
        }

        const string url = "~/disp_main_service_admin.aspx?id={0}&url={1}&prov={2}";
        protected void grid_ServerSettings_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var hyperLink = (e.Row.Cells[0].Controls[0]) as HyperLink;
                if (hyperLink != null)
                    hyperLink.NavigateUrl = String.Format(url, DataBinder.Eval(e.Row.DataItem, "Name"),txtUrl.Text,this.selectedProvider);
            }
        }
    }
}