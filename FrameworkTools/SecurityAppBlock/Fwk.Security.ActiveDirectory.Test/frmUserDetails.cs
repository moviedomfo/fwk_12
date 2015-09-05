using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Security.ActiveDirectory.Test
{
    public partial class frmUserDetails : Form
    {
        public ADUser user;
        public frmUserDetails()
        {
            InitializeComponent();
        }
       

        private void frmUserDetails_Load(object sender, EventArgs e)
        {
           List<ADGroup> list = StaticAD.ADHelper.User_SearchGroupList(user.LoginName);
           bindingSourceADUser.DataSource = user;
           domainGoups1.Populate(list);
        }

    }
}
