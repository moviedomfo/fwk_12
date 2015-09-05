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

namespace Fwk.Security.ActiveDirectory.Test
{
    public partial class frmTestGroups : Form
    {
      

        public frmTestGroups()
        {
            InitializeComponent();
        }

        private void domainGoups2_DomainGroupChangeEvent(ADGroup pGroup)
        {
            //_CurrentObjectDomainGroup = pGroup;
            //txtXmlGroupInfo.Text = _CurrentObjectDomainGroup.GetXml();
           
          
            //objectDomainGroupBindingSource.DataSource = pGroup;
            //grdGroupInfo.Refresh();
            //StaticAD.LoadDomain(txtDomain.Text);
            
            domainUsers1.Populate(pGroup.Name);
            //domainGoups1.Populate(pGroup.ActiveDirectoryMembersGroups);
            //System.Threading.Thread.Sleep(100);
            
        }

        void Init()
        {
            
            txtPassword.Text = System.Configuration.ConfigurationManager.AppSettings["pwd"];
            txtLoginName.Text = System.Configuration.ConfigurationManager.AppSettings["user"];
            txtPath.Text = System.Configuration.ConfigurationManager.AppSettings["LDAP"];
        }

        private void btnSearchInDomain_Click(object sender, EventArgs e)
        {
            domainGoups2.Initialize(txtDomain.Text);
       

            using (new WaitCursorHelper(this))
            {
                domainGoups2.Populate();
             
            }
        }

      

        private void domainUsers1_ObjectDomainChangeEvent(ADUser user)
        {
            
        }

        private void domainUsers1_ObjectDomainDoubleClickEvent(ADUser user)
        {
            using (frmUserDetails frm = new frmUserDetails())
            {
                frm.user = user;
                frm.ShowDialog();
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            domainGoups2.Initialize(txtPath.Text, txtLoginName.Text, txtPassword.Text);

            using (new WaitCursorHelper(this))
            {
                domainGoups2.Populate();
             
            }

       
            
        }

        private void frmTestGroups_Load(object sender, EventArgs e)
        {
            Init();
        }
    }
}
