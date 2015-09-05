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
using DevExpress.XtraEditors.Controls;

namespace Fwk.Security.Admin.Controls
{
    public delegate void NewSecurityInfoCreatedHandler(object sender);

    [DefaultEvent("NewSecurityInfoCreated")]
    public partial class UserAssingRoles : SecurityControlBase
    {
        RolList selectedRolList = null;
        /// <summary>
        /// Representa la informacion del tipo de control a instanciar 
        /// 
        /// </summary>
        public override string AssemblySecurityControl
        {
            get
            {
                return typeof(UserAssingRoles).AssemblyQualifiedName;
            }
        }

        public event NewSecurityInfoCreatedHandler NewSecurityInfoCreated;
        protected void NewSecurityInfoCreatedHandler()
        {
            if (NewSecurityInfoCreated != null)
                NewSecurityInfoCreated(this);
        }
        public UserAssingRoles()
        {
            InitializeComponent();
           
        }

        private void btnAsignarRoles_Click(object sender, EventArgs e)
        {

            if (usersGrid1.CurrentUser == null) return;
            RolList wNewRolList = new RolList();
            using (new WaitCursorHelper(this))
            {
                foreach (object obj in lstBoxRoles.CheckedItems)
                {
                    wNewRolList.Add((Rol)obj);
                }

                try
                {
                    if (selectedRolList != null)
                    {
                        FwkMembership.RemoveUserFromRoles(usersGrid1.CurrentUser.UserName, selectedRolList, frmAdmin.Provider.Name);
                        selectedRolList = null;
                    }
                    FwkMembership.CreateRolesToUser(wNewRolList, usersGrid1.CurrentUser.UserName, frmAdmin.Provider.Name);
                    selectedRolList = wNewRolList;
                }
                catch (Exception ex)
                {
                    if (((Fwk.Exceptions.TechnicalException)ex).InnerException != null)
                        MessageBox.Show(((Fwk.Exceptions.TechnicalException)ex).InnerException.Message);

                    else
                        MessageBox.Show(ex.Message);
                }
                
                bindingSourceUserRole.DataSource = FwkMembership.GetRolesForUser(usersGrid1.CurrentUser.UserName, frmAdmin.Provider.Name);

                NewSecurityInfoCreatedHandler();
            }
        }



        public override void Initialize()
        {
            using (new WaitCursorHelper(this))
            {
                rolListBindingSource.DataSource = FwkMembership.GetAllRoles(frmAdmin.Provider.Name);
                lstBoxRoles.Refresh();
                usersGrid1.Initialize();
            }
        }




        private void usersGrid1_OnUserChange(User user, RolList roles)
        {
            lblSelectedUser.Text = user.UserName;
            selectedRolList = roles;
            MachRolesGrid(roles);
        }

        private void UserAssingRoles_Load(object sender, EventArgs e)
        {
            usersGrid1.Initialize();
        }

        void MachRolesGrid(RolList roles)
        {
           lstBoxRoles.UnCheckAll();

            RolList list = (RolList)((System.Windows.Forms.BindingSource)(lstBoxRoles.DataSource)).List;
            foreach (Rol lstRol in list)
            {
           
                if (roles.Any(p => p.RolName.Equals(lstRol.RolName)))
                {
                    int i = lstBoxRoles.FindItem(lstRol);
                    object  odj = lstBoxRoles.GetItem(i);
                    lstBoxRoles.SetItemChecked(i, true);
                    
                }
            }
        }

        

    }
}
