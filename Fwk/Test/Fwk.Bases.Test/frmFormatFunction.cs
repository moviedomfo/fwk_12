using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Exceptions;
using Fwk.HelperFunctions.Compression;
using System.Net;

namespace Fwk.Bases.Test
{
    public partial class frmFormatFunction : Form
    {
        public frmFormatFunction()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //WebClient wc = new WebClient();
            //byte[] bytes = wc.DownloadData(textBox1.Text);
            Image img = Fwk.HelperFunctions.TypeFunctions.ConvertImageFromURL_ToImage(textBox1.Text);

            pictureBox1.Image = img;
        }

   
     

        private void frmFwkZip_Load(object sender, EventArgs e)
        {
            textBox1.Text = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS7GySTPMkBsysPlAuvsY5YFS_a134T99zk9xRBmOkh9D4H_03O";
        }
    }
}
