using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using System.Web.Security;
using Fwk.Bases.FrontEnd;
using Fwk.Security.Test;
using Fwk.Security;
using Fwk.Bases.FrontEnd.Controls;

namespace SecurityAppBlock.Use
{
    public partial class Form1 : Form
    {

        #region

        private IIdentity _Identity;		// Identity for authenticated users
        Boolean _Authenticated;
        CredentialsForm credentialsForm;

        #endregion
        public Form1()
        {
            InitializeComponent();

            credentialsForm = new CredentialsForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textApplicationName.Text= Membership.Provider.ApplicationName;
        }

        private void btnLogOn_Click(object sender, EventArgs e)
        {
            
            // Prompt the user for name and password
            this.credentialsForm.Text = Properties.Resources.AuthenticateTitleMessage;
            DialogResult result = this.credentialsForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                using (new WaitCursorHelper(this))
                {


                    _Authenticated = FwkMembership.ValidateUser(this.credentialsForm.Username, this.credentialsForm.Password, Membership.Provider.Name);

                    if (_Authenticated)
                    {
                        _Identity = new GenericIdentity(this.credentialsForm.Username, Membership.Provider.Name);
                        
                        txtUserName.Text = _Identity.Name;

                 

                        FwkMessageView.Show(string.Format(Properties.Resources.ValidCredentialsMessage, this.credentialsForm.Username),
                            "ValidateUser", 
                            System.Windows.Forms.MessageBoxButtons.OK, 
                           Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error);
                    }
                    else
                    {
                        FwkMessageView.Show(string.Format(Properties.Resources.InvalidCredentialsMessage, this.credentialsForm.Username), "ValidateUser",
                                             System.Windows.Forms.MessageBoxButtons.OK, 
                           Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error);
               
                    }
                }
            }
        }
    }
}
