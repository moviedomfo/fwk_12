using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace VivaldiSite.Security
{
    public partial class NotAuthorizedUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Login1.DestinationPageUrl = Request.QueryString["id"];

               
               ////////// HtmlForm mainform = (HtmlForm)Master.FindControl("form1");
               //////// Button loginbtn =(Button)Login1.FindControl("LoginButton");
               //////// //if (mainform != null && loginbtn != null)
               //////// //{
               ////////     Panel1.DefaultButton = loginbtn.UniqueID;
               //////// //}

            }
        }

        protected void Login1_LoginError(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

        }
    }
}
