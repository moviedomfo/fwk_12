using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Bases.Test
{
    public partial class frmHelperFunctions : Form
    {
        public frmHelperFunctions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtXml.Text = Fwk.HelperFunctions.FileFunctions.OpenTextFile("ConfigurationManager.xml");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtXml.Text = Fwk.Configuration.ConfigurationManager.GetProperty("ValidationExceptionMessage", "NullOrEmptyField");

        }
    }
}
