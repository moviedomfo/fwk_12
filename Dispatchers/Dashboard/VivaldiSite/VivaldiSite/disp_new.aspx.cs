using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VivaldiSite.DAC;

namespace VivaldiSite
{
    public partial class disp_new : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsCallback)
                return;
            if (!this.IsPostBack)
            {


                //cmbWrapperType.DataSource = ParametroDAC.GetByParams((int)Health.BE.Enums.TipoParametroEnum.Paices, null, true, string.Empty);
                //cmbWrapperType.DataBind();



                //cmbWrapperType.Attributes.Add("onchange", "javascript:return country_changed('" + cmbWrapperType.ClientID + "');");

                //cmbWrapperType.SelectedValue = "11000";




                //string stringbtnAcept = Page.ClientScript.GetCallbackEventReference(this, "'" + btnAcept.ClientID + "'", "ReceiveServerData_btnAcept", "null");
                //btnAcept.Attributes["onclick"] = stringbtnAcept;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Fwk.ConfigData.fwk_ServiceDispatcher disp = new Fwk.ConfigData.fwk_ServiceDispatcher();
  
            disp.CompanyName = txtCompany.Text;
            
            disp.HostName = txtServerName.Text;
            disp.InstanseName = txtInstanceName.Text;
            disp.InstanseId = Guid.NewGuid();
            disp.AuditMode= Convert.ToInt16(cmbAuditMode.SelectedValue);

            disp.HostIp = txtIp.Text;
            disp.Port = Convert.ToInt32(txtPort.Text);
            disp.Url_URI = txtUrl.Text;
            try
            {
                DataCoreDAC.Dispatcher_Create(disp);
                Response.Redirect(String.Concat("~/disp_new_wcome.aspx?id=", disp.InstanseName));
            }
            catch (Exception ex)
            { Helper.ProcessWebException(ex); }
            
        }
    }
}