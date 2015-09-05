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
using Fwk.Bases.FrontEnd.Controls;

namespace Fwk.Security.Admin.Controls
{
    [DefaultEvent("NewSecurityInfoCreated")]
    public partial class RolesCreate : SecurityControlBase
    {
        Rol selectedRol;
        public override string AssemblySecurityControl
        {
            get
            {
                return typeof(RolesCreate).AssemblyQualifiedName;
            }
        }
        public event NewSecurityInfoCreatedHandler NewSecurityInfoCreated;
        protected void NewSecurityInfoCreatedHandler()
        {
            if (NewSecurityInfoCreated != null)
                NewSecurityInfoCreated(this);
        }
        public RolesCreate()
        {
            InitializeComponent();
        }

        private void btnCreateNewRol_Click(object sender, EventArgs e)
        {
            using (new WaitCursorHelper(this))
            {
                try
                {
                    FwkMembership.CreateRole(txtRolName.Text, txtDescription.Text, frmAdmin.Provider.Name);

                    base.MessageViewInfo.Show(string.Format(Properties.Resources.RolCreatedMessage, txtRolName.Text));
                    Initialize();
                    NewSecurityInfoCreatedHandler();
                }
                catch (Exception ex)
                {
                    FwkMessageView.Show(ex, "Rol creation  ", System.Windows.Forms.MessageBoxButtons.OK, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error);
                }
            }
        }
        public override void Initialize()
        {
            using (new WaitCursorHelper(this))
            {
                rolListBindingSource.DataSource = FwkMembership.GetAllRoles(frmAdmin.Provider.Name);
                grdRoles.Refresh();
            }
        }

        private void grdRoles2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdRoles.CurrentRow == null || grdRoles.CurrentRow.DataBoundItem == null) return;
            selectedRol = (Rol)grdRoles.CurrentRow.DataBoundItem;

            using (new WaitCursorHelper(this))
            {
                grdUsers.DataSource = FwkMembership.GetUsersDetailedInRole(selectedRol.RolName, frmAdmin.Provider.Name);
                grdUsers.Refresh();
            }
        }

        private void txtRolName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtRolName.Text))
            {
                errorProvider1.SetError(txtRolName, "Rol name must not be empty");
            }
            else
            {
                errorProvider1.SetError(txtRolName, string.Empty);
            }
        }

        private void btnFindUsers_Click(object sender, EventArgs e)
        {
            using (frmUserFind frm = new frmUserFind())
            {

                if (frm.ShowDialog() == DialogResult.OK)
                {

                    FwkMembership.CreateUsersToRole(selectedRol.RolName, frm.SelectedUserList, frmAdmin.Provider.Name);
                    grdUsers.DataSource = FwkMembership.GetUsersDetailedInRole(selectedRol.RolName, frmAdmin.Provider.Name);
                    grdUsers.Refresh();
                }
            }
        }

        private void grdUsers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveItem();
            }
        }
       
        private void RemoveItem()
        {
            MessageViewInfo.MessageBoxButtons = MessageBoxButtons.YesNo;
            MessageViewInfo.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Question;
            if (MessageViewInfo.Show("Are you sure to remove selected users from current role : " + selectedRol.RolName) == DialogResult.Yes)
            {

                UserList removedUsersList = new UserList();
              
                foreach (DataGridViewRow row in grdUsers.SelectedRows)
                {
                    removedUsersList.Remove(((User)row.DataBoundItem));
                }

                FwkMembership.RemoveUsersFromRole(removedUsersList.GetArraNames(), selectedRol.RolName, frmAdmin.Provider.Name);

                grdUsers.DataSource = FwkMembership.GetUsersDetailedInRole(selectedRol.RolName, frmAdmin.Provider.Name);
                grdUsers.Refresh();

    
            }
            SetMessageViewToDefault();
        }


    }
}
