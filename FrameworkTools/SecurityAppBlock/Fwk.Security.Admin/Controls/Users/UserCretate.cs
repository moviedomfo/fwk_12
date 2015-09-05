using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.Common;
using System.Web.Security;

namespace Fwk.Security.Admin.Controls
{
    public partial class UserCretate : SecurityControlBase
    {
        public event NewSecurityInfoCreatedHandler NewSecurityInfoCreated;
        protected void OnNewSecurityInfoCreated()
        {
            if (NewSecurityInfoCreated != null)
                NewSecurityInfoCreated(this);
        }
        /// <summary>
        /// Representa la informacion del tipo de control a instanciar 
        /// </summary>
        public override string AssemblySecurityControl
        {
            get
            {
                return typeof(UserAssingRoles).AssemblyQualifiedName;
            }
        }
        public UserCretate()
        {
            InitializeComponent();
        }
        public override void  Initialize()
        {}

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (!ValidateControls()) return;
            string wMessage = string.Empty;
            using (new WaitCursorHelper(this))
            {
                try
                {
                    MembershipCreateStatus wStatus = MembershipCreateStatus.Success;
                    if (string.IsNullOrEmpty(txtAnsw.Text) && string.IsNullOrEmpty(txtQuest.Text))
                        FwkMembership.CreateUser(txtUserName.Text, txtPassword.Text, txtEmail.Text, frmAdmin.Provider.Name);
                    else
                        FwkMembership.CreateUser(txtUserName.Text, txtPassword.Text, txtEmail.Text, txtQuest.Text, txtAnsw.Text, chkApproved.Checked, out wStatus, frmAdmin.Provider.Name);

                    if (wStatus == MembershipCreateStatus.Success)
                    {

                        wMessage = String.Format(Properties.Resources.UserCreatedMessage, txtUserName.Text);
                    }
                    MessageViewInfo.Show(wMessage);
                    this.Initialize();
                    OnNewSecurityInfoCreated();
                }
                catch (Exception ex)
                {
                    MessageViewInfo.Show(ex);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (FwkMembership.ValidateUser(txtUserName.Text, txtPassword.Text, frmAdmin.Provider.Name))
            {
                MessageViewInfo.Show("Log sussefully");
            }
            else
            {
                MessageViewInfo.Show("Log not sussefully");
            }
        }

        bool ValidateControls()
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "El nombre de usuario es requerido");
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text) )
            {
                errorProvider1.SetError(txtPassword, "El pasword de usuario es requerido");
                return false;
            }
            if (!txtConfirmPassword.Text.Trim().Equals(txtPassword.Text.Trim(),StringComparison.Ordinal))
            {
                errorProvider1.SetError(txtConfirmPassword, "La confrirmacion y password no coinciden");
                return false;
            }
            return true;
        }
    }
}
