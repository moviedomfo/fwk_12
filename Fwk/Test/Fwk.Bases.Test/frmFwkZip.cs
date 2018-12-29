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
using System.IO;
using System.Diagnostics;

namespace Fwk.Bases.Test
{
    public partial class frmFwkZip : Form
    {
   
        string[] selectedFilesToZip;
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

            FwkZip zip = FwkZip.Create(@"f:\projects\xdev-sf-produziert\Company\analisis prueba.zip", "");
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
            catch (System.FormatException)
            {
                MessageBox.Show("El origen debe ser en un string en b64 producto de haber utilizado la funcion FwkCompression.Zip_base64(origen);");
            }

        }

        private void frmFwkZip_Load(object sender, EventArgs e)
        {
            textBox1.Text = "A Simple Component React components implement a render() method that takes input data and returns what to display. This example uses an XML-like syntax called JSX. Input data that is passed into the component can be accessed by render() via this.props. JSX is optional and not required to use React. Try the Babel REPL to see the raw JavaScript code produced by the JSX compilation step.";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selectedFilesToZip = null;
            try
            {
                selectedFilesToZip = Fwk.HelperFunctions.FileFunctions.OpenFileDialog_Open_multiselect("Files (*.rar)|*.rar|All Files (*.*)|*.*", "Buscar zips", txtInitialPath.Text);
                if (selectedFilesToZip == null)
                    return;
                if (selectedFilesToZip.Count() == 0)
                    return;
                #region

                FileInfo file = new FileInfo(selectedFilesToZip[0]);

                txtInitialPath.Text = file.Directory.FullName;
                #endregion

                #region build treeView
                TreeNode node = null;

                foreach (string filename in selectedFilesToZip)
                {
                    file = new FileInfo(filename);
                    node = new TreeNode(file.Name);
                    node.ImageIndex = 6;
                    node.SelectedImageIndex = 6;
                    treeView1.Nodes.Add(node);

                }
                #endregion

                #region Extraer info del .Exe
                //exeFullFileName = selectedFilesToZip.Where(p => p.Substring(p.Length - 4, 4).ToLower().Equals(".exe")).FirstOrDefault();
                //if (string.IsNullOrEmpty(exeFullFileName))
                //{
                //    MessageBox.Show("Debe seleccionar al menos un archivo ejecutable para el release");
                //    return;
                //}
                //FileInfo exeFile = new FileInfo(exeFullFileName);
                //if (exeFile.Exists)
                //{
                //    //txtExeVersion.Text = "";
                //    string fileaName = exeFile.Name.Substring(0, exeFile.Name.Length - 4) + ".zip";
                //    //txtZipFileName.Text = fileaName;
                //    //var versInfo = FileVersionInfo.GetVersionInfo(exeFullFileName);
                //    //String fileVersion = versInfo.FileVersion;
                //    //txtExeVersion.Text = fileVersion;
                //}
                #endregion
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

            //FwkZip.Compress();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FileInfo f = FwkZip.Compress(selectedFilesToZip, txtZipFileName.Text.Trim());
            txtZipFileName.Text = f.FullName;
            txtSourcePathToExtract.Text = Path.Combine( f.Directory.FullName , "Extraction");
            MessageBox.Show("Archivo zip creado con exito ");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FwkZip.Extract(txtZipFileName.Text.Trim(), txtSourcePathToExtract.Text.Trim());

            MessageBox.Show("Archivo zip decomprimido con exito ");
            Process.Start("Explorer", txtSourcePathToExtract.Text.Trim());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteBE wClienteBE = (ClienteBE)FwkCompression.UnzipZip_From_base64_object(textBox1.Text);
                textBox2.Text = wClienteBE.GetXml();
            }
            catch (System.FormatException)
            {
                MessageBox.Show("El origen debe ser en un string en b64 producto de haber utilizado la funcion FwkCompression.UnzipZip_From_base64(origen);");
            }
        }

        private void btnZipObject_Click(object sender, EventArgs e)
        {
            ClienteBE wClienteBE = new ClienteBE();

            wClienteBE.Apellido = "Lopez";
            wClienteBE.Nombre = "Jenifer";
            wClienteBE.Edad = 3;
            textBox1.Text = FwkCompression.Zip_Object(wClienteBE);

        }
    }
}
