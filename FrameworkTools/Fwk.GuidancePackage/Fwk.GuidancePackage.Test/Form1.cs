using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.GuidancePackage.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool g= Fwk.Guidance.Core.HelperFunctions.RequiresNew("CreatePerson");

           bool  g2 = Fwk.Guidance.Core.HelperFunctions.RequiresNew("createPerson");

            bool g3 = Fwk.Guidance.Core.HelperFunctions.RequiresNew("PersonWasaaaaacreateerwgsvdf");

            if (g && g2 && !g3)
                MessageBox.Show("Okis");
            else
                MessageBox.Show("No anda");
        }
    }
}
