using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.Common;

namespace Fwk.Security.Admin.Controls
{
    public partial class RolesGrid : SecurityControlBase
    {

        public Rol CurrentRol;

        RolList rolesList;

        RolList selectedRoleList = new RolList();
        [Browsable(false)]
        public RolList SelectedRoleList
        {
            get
            {
                GetSelecteds();
                return selectedRoleList;
            }

        }
        public RolesGrid()
        {
            InitializeComponent();
        }


        public void Initialize()
        {
            try
            {
                rolesList = FwkMembership.GetAllRoles(frmAdmin.Provider.Name);
            }
            catch (Exception ex)
            {
               
                base.MessageViewInfo.Show(ex);
                return;
            }
            grdUsers.DataSource = rolesList;
            grdUsers.Refresh();
        }
        public void GetSelecteds()
        {
            selectedRoleList.Clear();
            foreach (DataGridViewRow row in grdUsers.SelectedRows)
            {
                selectedRoleList.Add(((Rol)row.DataBoundItem));
            }

        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;
            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                grdUsers.DataSource = rolesList;
                grdUsers.Refresh();
            }
            string strFind = textEdit1.Text.ToUpper();
            var list = from u in rolesList
                       where
                        u.RolName.ToUpper().Contains(strFind) 
                  
                       select u;

            grdUsers.DataSource = list.ToList<Rol>();
            grdUsers.Refresh();
        }
    }
}
