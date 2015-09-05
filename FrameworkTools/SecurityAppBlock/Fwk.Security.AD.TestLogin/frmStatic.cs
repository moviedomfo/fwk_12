using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.ActiveDirectory;
using Fwk.Security.AD.TestLogin.ServiceReference1;


namespace Fwk.Security.AD.TestLogin
{
    public partial class frmStatic : Form
    {
        Fwk.Security.AD.TestLogin.ServiceReference1.ActiveDirectorySoapClient _proxy = null;
        public frmStatic()
        {
            InitializeComponent();
             _proxy = new Fwk.Security.AD.TestLogin.ServiceReference1.ActiveDirectorySoapClient("ActiveDirectorySoap");
        }
   
        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                LoogonUserResult wLoogonUserResult  = _proxy.Autenticate(txtLoginName.Text, txtPassword.Text, txtDomain.Text);
                lblCheckResult.Text = wLoogonUserResult.LogResult;
            }
            catch (Exception ex)
            {
                lblCheckResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

        }

        private void lblCheckResult_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtDomain_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtLoginName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
