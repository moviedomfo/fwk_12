using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fwk.Security.ActiveDirectory;
using Fwk.Exceptions;

namespace Fwk.CheckLogging
{
    public partial class _Default : System.Web.UI.Page
    {
        LDAPHelper _ADHelper;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            lblError.Text = "NO Error";
            try
            {
                if (SetAD(false))
                {
                    TechnicalException logError = null;

                    lblResult.Text = _ADHelper.User_Logon(txtUsr.Text, txtpassword.Text, out logError).ToString();

                    if (logError != null)
                        lblError.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(logError);
                    else
                        lblError.Text = "NO Error";

                }
            }
            catch (Exception ex)
            {
                lblError.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);


            }
        }



        bool SetAD(Boolean pSecure)
        {
            _ADHelper = new LDAPHelper(txtDomain.Text, "testActiveDirectory", pSecure, false);

            return true;
        }
    }
}
