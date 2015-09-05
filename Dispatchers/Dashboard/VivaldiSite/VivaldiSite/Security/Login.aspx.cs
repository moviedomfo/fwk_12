using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;
using Fwk.Security.BC;
using System.Security.Principal;
using Fwk.Security.Common;
///webadmin
///pletorico3_
namespace VivaldiSite.Security
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    this.Login1.DestinationPageUrl = Request.QueryString["id"];

            }
           
        }

        /// <summary>
        /// Solo verifica la Autentidad del usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            //Health.Security.HealthMembershipProvider provider = (Health.Security.HealthMembershipProvider)Membership.Provider;
            //Fwk.Security.Common.User dbUSer;
            //try
            //{
            //    TextBox UserName = (TextBox)Login1.FindControl("UserName");
            //    TextBox Password = (TextBox)Login1.FindControl("Password");
            //    e.Authenticated = provider.ValidateUser(UserName.Text, Password.Text);
            //    //if(e.Authenticated)
            //    //    dbUSer = Fwk.Security.FwkMembership.GetUserAnRoles(UserName.Text.Trim(), "sec");

            //    //Create_HttpCookie(dbUSer, true);
            //    //SessionMannager.Session(this.Session, Application).CurrentUserInfo = Fwk.Security.FwkMembership.GetUserAnRoles(UserName.Text.Trim(), "sec");
            //    //string err = string.Empty;
            //    //SessionMannager._SessionProxy.InitAuthorizationFactory(out err);
            //    //if (!string.IsNullOrEmpty(err))
            //    //{
            //    //    Login1.FailureText = err;
            //    //    e.Authenticated = false;
            //    //}
            //}
            //catch (Exception er)
            //{
            //    Login1.FailureText = er.Message;
            //    e.Authenticated = false;
            //}
        }

        internal  void Create_HttpCookie(User dbUSer, bool createPersistentCookie)
        {
            if (String.IsNullOrEmpty(dbUSer.UserName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            FormsAuthentication.SetAuthCookie(dbUSer.UserName, createPersistentCookie);
            string xmlUSer = Fwk.HelperFunctions.SerializationFunctions.SerializeToXml(dbUSer);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, dbUSer.UserName, DateTime.Now, DateTime.Now.AddMinutes(30), createPersistentCookie, xmlUSer);
            string encTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            HttpContext.Current.Response.Cookies.Add(faCookie);
        }

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
           
        }
    }
}
