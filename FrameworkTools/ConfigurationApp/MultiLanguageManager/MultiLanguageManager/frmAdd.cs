using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiLanguageManager
{
    public partial class frmAdd : Form
    {
        public string Key
        {
            get { return txtKey.Text; }
        }
        //string group;
        //public string Group
        //{
        //    get { return group; }
        //    set {  group = value; }
        //}
        public frmAdd()
        {
            InitializeComponent();
        }

        public frmAdd(string group)
        {
            InitializeComponent();

            // TODO: Complete member initialization
            lblGroup.Text = group;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (String.IsNullOrEmpty(txtKey.Text))
            {
                errorProvider1.SetError(txtKey, "Ingrese el nobre de la clave");
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
