using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConfigurationApp
{
    public partial class frmNewKey : Fwk.Bases.FrontEnd.FrmBase
    {
       

        public string FileName
        {
            get { return lblFileName.Text ; }
            set { lblFileName.Text = value; }
        }
        public string GroupName
        {
            get { return lblGroupName.Text; }
            set { lblGroupName.Text = value; }
        }

        public string KeyName
        {
            get { return txtKeyName.Text; }
        }
        public string KeyValue
        {
            get { return txtKeyValue.Text; }
        }

        public frmNewKey()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}