using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConfigurationApp
{
    public partial class frmNewGroup : Fwk.Bases.FrontEnd.FrmBase
    {
        public string GroupName
        {
            get { return txtGroupName.Text; }
            
        }
        public frmNewGroup()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}