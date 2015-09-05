using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Security.Admin.Controls
{
    public partial class frmAddName : Form
    {
        public frmAddName()
        {
            InitializeComponent();
        }

        private void simpleButton_OkCreateCategory_Click(object sender, EventArgs e)
        {
            this.Tag = textEdit1.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
