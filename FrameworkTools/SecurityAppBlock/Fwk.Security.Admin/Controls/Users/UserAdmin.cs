using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.Common;
using Fwk.Security;
using System.Web.Security;
using System.Web.Profile;
using Fwk.Bases.FrontEnd.Controls;

namespace Fwk.Security.Admin.Controls
{
    [DefaultEvent("NewSecurityInfoCreated")]
    public partial class UserAdmin : SecurityControlBase
    {  

        public override string AssemblySecurityControl
        {
            get
            {
                return typeof(UserAdmin).AssemblyQualifiedName;
            }
        }
        public event NewSecurityInfoCreatedHandler NewSecurityInfoCreated;
        protected void NewSecurityInfoCreatedHandler()
        {
            if (NewSecurityInfoCreated != null)
                NewSecurityInfoCreated(this);
        }
        public UserAdmin()
        {
            InitializeComponent();
        }


        public override void Initialize()
        {
            using (new WaitCursorHelper(this))
            {
                usersGrid1.Initialize();

                bindingSourceRoles1.DataSource = FwkMembership.GetAllRoles(frmAdmin.Provider.Name);

                
            }
        }





       

        private void btnUsersList_Click(object sender, EventArgs e)
        {
            
            usersGrid1.Initialize();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (usersGrid1.CurrentUser == null)
            {
                btnRemove.Enabled = false;
                btnUpdate.Enabled = false;
                return;
            }
            String wUserName = usersGrid1.CurrentUser.UserName;



            FwkMembership.DeleteUser(wUserName, frmAdmin.Provider.Name);
            MessageViewInfo.Show("User was successfully removed");



            lblRolesByUser.Text = string.Empty;
            txtEmail.Text = String.Empty;
            txtUserName.Text = String.Empty;
            btnRemove.Enabled = false;
            btnUpdate.Enabled = false;
            usersGrid1.Initialize();

        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {

            User wUser = usersGrid1.CurrentUser;


            User wpdatedUser = new User(txtUserName.Text);
            wpdatedUser.Email = txtEmail.Text;
            wpdatedUser.Comment = txtComments.Text;
            wpdatedUser.IsApproved = chkApproved.Checked;

            wpdatedUser.AnswerPassword = txtAnsw.Text;
            wpdatedUser.QuestionPassword = txtQuest.Text;



            FwkMembership.UpdateUser(wpdatedUser, wUser.UserName, frmAdmin.Provider.Name);
            MessageViewInfo.Show("User was successfully updated");

            usersGrid1.Initialize();
        }

        private void usersGrid1_OnUserChange(User user, RolList roles)
        {
            if (usersGrid1.CurrentUser == null)
            {
                btnRemove.Enabled = false;
                btnUpdate.Enabled = false;
                return;
            }

            lblRolesByUser.Text = "User roles " + usersGrid1.CurrentUser.UserName;
            txtEmail.Text = usersGrid1.CurrentUser.Email;
            txtUserName.Text = usersGrid1.CurrentUser.UserName;
            txtQuest.Text = usersGrid1.CurrentUser.QuestionPassword;
            txtAnsw.Text = usersGrid1.CurrentUser.AnswerPassword;
            chkApproved.Checked = usersGrid1.CurrentUser.IsApproved;
            txtComments.Text = usersGrid1.CurrentUser.Comment;
            btnRemove.Enabled = true;
            btnUpdate.Enabled = true;
            if (usersGrid1.CurrentUser.IsApproved)
                btnApprove.Text = "DisApprove";
            else
                btnApprove.Text = "Approve";


            using (new WaitCursorHelper(this))
            {
                grdRoles1.DataSource = roles;
            }
        }

        private void btnchangePwd_Click(object sender, EventArgs e)
        {
            if (usersGrid1.CurrentUser == null) return;
            using (frmChangePwd frm = new frmChangePwd(usersGrid1.CurrentUser))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageViewInfo.Show("User password was successfully updated");
                }
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (usersGrid1.CurrentUser == null) return;
            if (usersGrid1.CurrentUser.IsApproved)
            {
                FwkMembership.UnApproveUser(usersGrid1.CurrentUser.UserName, frmAdmin.Provider.Name);
                MessageViewInfo.Show(string.Concat("User password was successfully ", "disapproved"));
            }
            else
            {
                FwkMembership.ApproveUser(usersGrid1.CurrentUser.UserName, frmAdmin.Provider.Name);
                MessageViewInfo.Show(string.Concat("User password was successfully ", "approved"));
            }

            usersGrid1.Initialize();

           
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            if (usersGrid1.CurrentUser == null) return;
          
                FwkMembership.UnlockUser(usersGrid1.CurrentUser.UserName, frmAdmin.Provider.Name);
                MessageViewInfo.Show(string.Format("User {0} was successfully unlocked", usersGrid1.CurrentUser.UserName));
            

            usersGrid1.Initialize();
        }

    

    }
}
