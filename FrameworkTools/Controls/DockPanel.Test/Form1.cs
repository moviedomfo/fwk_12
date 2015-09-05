using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DockPanel.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Form2 f = new Form2();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new Form2().Show(dockPanel1, Fwk.Controls.Win32.DockState.DockLeftAutoHide);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}