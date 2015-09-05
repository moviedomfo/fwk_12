using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Fwk.Bases.FrontEnd.Controls.Test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnAddFacturas_Click(object sender, EventArgs e)
        {
            ClienteBECollection _ClienteBECollection = new ClienteBECollection();
            ClienteBE wClienteBE = new ClienteBE();
            wClienteBE.Apellido = "Oviedo";
            wClienteBE.Nombre = "Marcelo Fabian";
            wClienteBE.IdCliente = 345;

            _ClienteBECollection.Add(wClienteBE);

            wClienteBE = new ClienteBE();

            wClienteBE.Apellido = "Braida";
            wClienteBE.Nombre = "Hernan de las pasturas";
            wClienteBE.IdCliente = 120;


            _ClienteBECollection.Add(wClienteBE);

            wClienteBE = new ClienteBE();

            wClienteBE.Apellido = "Honda";
            wClienteBE.Nombre = "Kamakawa";
            wClienteBE.IdCliente = 3000;
         

            _ClienteBECollection.Add(wClienteBE);

            fwkFlatComboBox1.DataSource = _ClienteBECollection;
            clietnteBECollectionBindingSource.DataSource = wClienteBE;
            
        }

        private void fwkFlatComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClienteBE c = (ClienteBE)fwkFlatComboBox1.SelectedEntity;

            if (c == null)
            {
                textBox1.Text = "ClienteBE = NULL ";
                return;
            }

            textBox1.Text = c.GetXml();
            
        }

        private void btnGetEntiyt_Click(object sender, EventArgs e)
        {

            ClienteBE c = (ClienteBE)fwkFlatComboBox1.SelectedEntity;

            if (c == null)
            {
                textBox1.Text = "ClienteBE = NULL ";
                return;
            }
         
            textBox1.Text = c.GetXml();
        }

        private void btnAddObject_Click(object sender, EventArgs e)
        {
            DriveInfo[] di = DriveInfo.GetDrives();

            cmbObject.DataSource = di;
            cmbObject.DisplayMember = "Name";

            cmbObject.SelectedIndex = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fwkMessageViewComponent1.Show("prueva de message viewer erroorrrrrrrrrrrrrrrrrrr");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Fwk.AssemblyExplorer.Assembly asasa = new Fwk.AssemblyExplorer.Assembly("asda");
            }
            catch (Exception rr)
            {
                fwkExceptionViewComponent2.Show(rr);
            }
            
        }
    }
}