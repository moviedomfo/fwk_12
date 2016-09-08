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

        private void btnUsersList_Click(object sender, EventArgs e)
        {

        }

       
        

     
       

       

    }









}

