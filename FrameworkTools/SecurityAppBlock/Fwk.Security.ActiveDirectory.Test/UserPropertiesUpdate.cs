using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace Fwk.Security.ActiveDirectory.Test
{
    public partial class UserPropertiesUpdate : Form
    {
        public UserPropertiesUpdate()
        {
            InitializeComponent();
        }

        void Connect()
        {
            ///172.22.12.110
            ADWrapper _ADHelper = new ADWrapper("LDAP://PC1.Pelsoft.es/DC=Pelsoft,DC=ar", "moviedo", "xxxxxx");

            _ADHelper.User_Get_ByName("moviedo");

            _ADHelper.User_ChangeEmail("moviedo","marcelo.oviedo@gmail.com.ar");

        }

        private void btnSearchInDomain_Click(object sender, EventArgs e)
        {

            StringCollection str = Fwk.Security.ActiveDirectory.ADWrapper.Domain_GetList();
            Connect();
        }
    }
}
