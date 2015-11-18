using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fwk.Security.ActiveDirectory.Test
{
    public partial class frmResetPassword : Form
    {
        ImpersonateLogin _ImpersonateLogin = new ImpersonateLogin();
        public frmResetPassword()
        {
            InitializeComponent();

            textBox1.Text = System.Configuration.ConfigurationManager.AppSettings["user"];
            textBox2.Text = System.Configuration.ConfigurationManager.AppSettings["pwd"];
            textBox3.Text = System.Configuration.ConfigurationManager.AppSettings["Domain"];
            textBox4.Text = System.Configuration.ConfigurationManager.AppSettings["LDAP"];
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

            _ImpersonateLogin.user = textBox1.Text;
            _ImpersonateLogin.password = textBox2.Text;
            _ImpersonateLogin.domain = textBox3.Text;
            _ImpersonateLogin.ldap = textBox4.Text;
            User_Reset_Password(txtLoginName.Text, txtPassword.Text, txtDomain.Text);
        }



          void User_Reset_Password(string userName, string newPassword, string domain)
        {
            ADWrapper ad = new ADWrapper(domain,  _ImpersonateLogin);

            ad.User_ResetPwd(userName, newPassword, true);

            ad.Dispose();
        }
    }
}
