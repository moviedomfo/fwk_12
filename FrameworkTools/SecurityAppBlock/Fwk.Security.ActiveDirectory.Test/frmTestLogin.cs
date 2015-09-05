using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Security.ActiveDirectory.Test
{
    public partial class frmTestLogin : Form
    {
        public frmTestLogin()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            //if (radioButton1.Checked)
            //    lblCheckResult.Text = ADHelper.User_CheckLogin(txtDomain.Text, txtLoginName.Text, txtPassword.Text).ToString();
            //else
            //    lblCheckResult.Text = ADHelper.User_CheckLogin(cmbAllDomains.Text, txtLoginName.Text, txtPassword.Text).ToString();

        }

        private void frmTestLogin_Load(object sender, EventArgs e)
        {
            cmbAllDomains.DataSource = ADHelper.Domain_GetList();
            cmbAllDomains.SelectedIndex = 0;
        }

       

       
    }
}
