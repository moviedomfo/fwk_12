using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Wizard;

namespace FwkProjectWizard.Test
{
    public partial class Form1 : Form
    {
        Storage _Storage = new Storage();
        frmWizBase frm;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            _Storage.LoadStorage();
            frm = new Fwk.Wizard.frmWizDAC_1(_Storage.CnnString);
            frm.ShowDialog();
            if (frm.GenCode == null) return;
            string code;
            foreach (KeyValuePair<string, string> d in frm.GenCode)
            {
                code = d.Value;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           _Storage.CnnString = frm.Cnn;
            _Storage.SaveStorage();
        }
    }
}
