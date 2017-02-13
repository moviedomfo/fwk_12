using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using System.Threading;
using System.Security.Permissions;
using Fwk.Security.Common;
using Fwk.Bases.FrontEnd.Controls;
using System.Web.Security;


namespace Fwk.Security.ActiveDirectory.Test
{
    public partial class frmTest : Form
    {

        //String[] _SelectedGroups;
        ADGroup _CurrentGroup;
        ADUser _CurrentUser;
       

        public frmTest()
        {
            InitializeComponent();
                        //System.Web.Security.SqlMembershipProvider wSqlMembershipProvider = new System.Web.Security.SqlMembershipProvider();
            //wSqlMembershipProvider.ApplicationName = 
            using (new WaitCursorHelper(this))
            {
                try
                {
                    userByAppBindingSource.DataSource = FwkMembership.GetAllUsers(System.Web.Security.Membership.Provider.Name);
                    rolListBindingSource.DataSource = FwkMembership.GetAllRoles(System.Web.Security.Membership.Provider.Name);
                }
                catch (Exception ex)
                {
                    FwkMessageView.Show(ex, Properties.Resources.MessageBoxTitle, MessageBoxButtons.OK, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error);
                }
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {

            using (new WaitCursorHelper(this))
            {
                try
                {
                    FwkMembership.CreateUser(_CurrentUser.LoginName, txtPassword.Text,String.Empty);
                }
                catch (Exception ex)
                {
                    FwkMessageView.Show(ex, Properties.Resources.MessageBoxTitle, System.Windows.Forms.MessageBoxButtons.OK,
                        Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error);
                }

            }
            userByAppBindingSource.DataSource = FwkMembership.GetAllUsers(System.Web.Security.Membership.Provider.Name);
        }


        private void btnSearchInDomain_Click(object sender, EventArgs e)
        {
            domainGoups2.Initialize(txtDomain.Text);
            StaticAD.LoadDomain(txtDomain.Text);
            
            using (new WaitCursorHelper(this))
            {
                domainGoups2.Populate();
                //domainUsers1.Populate();
            }
        }

        private void domainGoups2_ObjectDomainChangeEvent(ADGroup pObjectDomainGroup)
        {
            _CurrentGroup = pObjectDomainGroup;
        }

        private void domainUsers1_ObjectDomainChangeEvent(ADUser user)
        {
            _CurrentUser = user;

            txtUserFullName.Text = string .Concat (user.FirstName , " " , user.LastName);
            txtUserName.Text = user.LoginName; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //FwkActyveDirectory _FwkActyveDirectory = new FwkActyveDirectory("Alco");

           
            //Int32 CA =_CurrentUser.ActiveDirectoryGroups.Count;
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //this.dataGridView1.DataSource = _CurrentUser.ActiveDirectoryGroups;

        }

       
        

     
       

       

    }









}

