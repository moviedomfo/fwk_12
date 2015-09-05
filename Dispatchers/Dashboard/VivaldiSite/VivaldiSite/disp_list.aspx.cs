using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VivaldiSite.DAC;

namespace VivaldiSite
{
    public partial class disp_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    grid_ServerSettings.DataSource = DataCoreDAC.Dispatcher_List();
                    grid_ServerSettings.DataBind();
                    
                }
                catch (Exception ex)
                { Helper.ProcessWebException(ex); }
            }
        }

        
    }
}