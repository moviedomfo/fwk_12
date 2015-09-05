using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.ServiceManagement.Tools.Win32
{
    public partial class cnnstring : UserControl
    {
        public cnnstring()
        {
            InitializeComponent();
        }
        public void Populate(Fwk.DataBase.CnnString pCnnString)
        {
            txtDatabase.Text = pCnnString.DataSource;
            txtSQLServer.Text = pCnnString.InitialCatalog;
        }
        public void Clear()
        {
            txtDatabase.Text = string.Empty;
            txtSQLServer.Text = string.Empty;
        }
    }
}
