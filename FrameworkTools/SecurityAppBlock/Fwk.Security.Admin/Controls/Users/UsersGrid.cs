using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.Common;
using Fwk.Security.Admin.Controls;

namespace Fwk.Security.Admin
{
    public delegate void UserChangeHandler(User user, RolList roles);
    [DefaultEvent("OnUserChange")]
    public partial class UsersGrid : SecurityControlBase
    {
        public User CurrentUser;
        public event UserChangeHandler OnUserChange;
        List<User> userList;

        List<User> selectedUserList = new List<User>();
        [Browsable(false)]
        public List<User> SelectedUserList
        {
            get
            {
                GetSelecteds();
                return selectedUserList;
            }
        }

        public UsersGrid()
        {
            InitializeComponent();
            
     
        }

      

        public override void Initialize()
        {
            try
            {
                userList = FwkMembership.GetAllUsers(frmAdmin.Provider.Name);
            }
            catch (Exception ex)
            {
                base.MessageViewInfo.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
                return;
            }
            //userList = SecurityController.GetAllUsers(true).ToList<User>();
            userByAppBindingSource.DataSource = userList;
            gridView1.RefreshData();
        
        }



        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar != (char)Keys.Enter) return;
         
            //if (string.IsNullOrEmpty(textEdit1.Text))
            //{
            //    userByAppBindingSource.DataSource = userList;
            //    gridView1.RefreshData();
            //}
            //string strFind = textEdit1.Text.ToUpper();
            //var list = from u in userList
            //           where
            //            u.UserName.ToUpper().Contains(strFind) ||
            //            u.Email.ToUpper().Contains(strFind)
            //           select u;

     
            //userByAppBindingSource.DataSource = list.ToList<User>();
            //gridView1.RefreshData(); ;
            
        }
        

        public void GetSelecteds()
        {
            selectedUserList.Clear();
            foreach (int rowIndex in gridView1.GetSelectedRows())
            {
                
                selectedUserList.Add((User)gridView1.GetRow(rowIndex));
            }

        }

  

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetRow(e.FocusedRowHandle) == null) return;
            CurrentUser = ((User)gridView1.GetRow(e.FocusedRowHandle));
            if (CurrentUser == null) return;

            if (OnUserChange != null)
            {
                
                OnUserChange(CurrentUser, FwkMembership.GetRolesForUser(CurrentUser.UserName, frmAdmin.Provider.Name));
            }
        }


    }
}
