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
    public partial class frmResset : Form
    {
        Fwk.Security.AD.TestLogin.ServiceReference1.ActiveDirectorySoapClient _proxy = null;
        public frmResset()
        {
            InitializeComponent();
            cmbDomains.SelectedIndex = 0;
            _proxy = new Fwk.Security.AD.TestLogin.ServiceReference1.ActiveDirectorySoapClient("ActiveDirectorySoap");
            lblCnn.Text = _proxy.Endpoint.Address.Uri.ToString();
            
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            lblCheckResult.Text = String.Empty;
            txtError.Text = String.Empty;
            try
            {
                LoogonUserResult wLoogonUserResult = _proxy.Autenticate(txtLoginName.Text, txtPassword.Text, cmbDomains.Text);
                lblCheckResult.Text = wLoogonUserResult.LogResult;
            }
            catch (Exception ex)
            {
                txtError.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
        }

        private void ResetPwd_Click(object sender, EventArgs e)
        {
            lblCheckResult.Text = String.Empty;
            txtError.Text = String.Empty;
            try
            {


                if (String.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Ingrese la nueva password");
                    txtPassword.Focus();
                }
                if (String.IsNullOrEmpty(txtLoginName.Text))
                {
                    MessageBox.Show("Usuario es requrido");
                    txtLoginName.Focus();
                }

                _proxy.User_Reset_Password(txtLoginName.Text, txtPassword.Text, cmbDomains.Text);
                lblCheckResult.Text = "Clave Reseteada";

            }
            catch (Exception ex)
            {
                txtError.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblCheckResult.Text = String.Empty;
            txtError.Text = String.Empty;
            try
            {

                Fwk.Security.AD.TestLogin.ServiceReference1.DomainsUrl[] list =_proxy.Retrive_DomainsUrl();
                StringBuilder str = new StringBuilder ();
                foreach(Fwk.Security.AD.TestLogin.ServiceReference1.DomainsUrl d in list)
                {
                    str.AppendLine(string.Concat("DomainName: ",d.DomainName));
                    str.AppendLine(string.Concat("LDAPPath: ",d.LDAPPath));
                    str.AppendLine(string.Concat("Usr: ", d.Usr));
                    str.AppendLine(string.Concat("Pwd: ", d.Pwd));
                       str.AppendLine(".......................................................");
                }
                lblCheckResult.Text = str.ToString();
            }
            catch (Exception ex)
            {
                txtError.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblCheckResult.Text = String.Empty;
            txtError.Text = String.Empty;
            try
            {

                MessageBox.Show(_proxy.Test());
                
            }
            catch (Exception ex)
            {
                txtError.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
        }
    }
}
