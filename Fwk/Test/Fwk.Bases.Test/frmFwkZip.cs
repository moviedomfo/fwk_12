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
    public partial class frmFwkZip : Form
    {
        public frmFwkZip()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            textBox2.Text = FwkCompression.Zip_base64(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS7GySTPMkBsysPlAuvsY5YFS_a134T99zk9xRBmOkh9D4H_03O");
            Image img = Fwk.HelperFunctions.TypeFunctions.ConvertByteArrayToImage(bytes);

            FwkZip zip = FwkZip.Create(@"f:\projects\xdev-sf-produziert\Company\analisis prueba.zip","");
            FwkZip.Compression c = new FwkZip.Compression();

            zip.AddFile(c, @"c:\RODRIGO\Requerimientos.docx", @"Requerimientos.docx", "xxx");
            zip.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = FwkCompression.UnzipZip_From_base64(textBox1.Text);
            }
            catch(System.FormatException)
            {
                MessageBox.Show("El origen debe ser en un string en b64 producto de haber utilizado la funcion FwkCompression.UnzipZip_From_base64(origen);");
            }
            
        }

        private void frmFwkZip_Load(object sender, EventArgs e)
        {
            textBox1.Text = "A Simple Component React components implement a render() method that takes input data and returns what to display. This example uses an XML-like syntax called JSX. Input data that is passed into the component can be accessed by render() via this.props. JSX is optional and not required to use React. Try the Babel REPL to see the raw JavaScript code produced by the JSX compilation step.";
        }
    }
}
