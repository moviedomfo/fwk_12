using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fwk.Bases.FrontEnd.Controls.FwkCombo.Design;
 
namespace Fwk.Bases.FrontEnd.Controls.Test
{
    public partial class Form1 : Fwk.Bases.FrontEnd.FrmBase
    {
        FacturaBECollection _FacturaBElist = new FacturaBECollection();
        TipoClienteBEList _TipoClienteBEList = new TipoClienteBEList();
        ClienteBECollection _ClienteBECollection = new ClienteBECollection();

        public Form1()
        {
            InitializeComponent();

            FillTipoClienteBEList();
            FillFacturaBElist();
            FillClienteBECollection();
         
        }

        private void btnAddFacturas_Click(object sender, EventArgs e)
        {

            

            fwkGenericDataGridView1.Populate<FacturaBECollection, FacturaBE>(_FacturaBElist);
            
 
        }

        

        private void fwkGenericDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FacturaBE f = fwkGenericDataGridView1.GetSelectedEntity<FacturaBE>();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            fwkGenericDataGridView1.ClearAllItems<FacturaBECollection,FacturaBE>();
        }


        private void btnAddEntity_Click(object sender, EventArgs e)
        {
            FacturaBE wFacturaBE = new FacturaBE();

            wFacturaBE.ClienteBE.Apellido = "Shother";
            wFacturaBE.ClienteBE.Nombre = "Geretel Mirta";
            wFacturaBE.ClienteBE.IdCliente = 654;
            wFacturaBE.FechaFatura = System.DateTime.Now;
            wFacturaBE.IdFactura = 1234;
            wFacturaBE.IdCliente = wFacturaBE.ClienteBE.IdCliente;


            fwkGenericDataGridView1.AddEntity<FacturaBECollection, FacturaBE>(wFacturaBE);
        }

        private void btnRemoveEntity_Click(object sender, EventArgs e)
        {

            fwkGenericDataGridView1.RemoveSelectedEntity<FacturaBECollection,FacturaBE>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fwkGenericDataGridView_Combo.AddCombo("IdTipoCliente","Descripcion", "IdTipoCliente", _TipoClienteBEList);

            fwkGenericDataGridView_Combo.Populate<ClienteBECollection, ClienteBE>(_ClienteBECollection );
        }

        private void btnAdClientesToCombo_Click(object sender, EventArgs e)
        {

            fwkFlatComboBox_Clientes.DataSource = _ClienteBECollection;
            fwkAutoComboBox1.DataSource = _ClienteBECollection; 
        }

        
      

        private void fwkGenericDataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Msg lanzado desde fwkGenericDataGridView1_DataError ..." + e.Exception.Message);
        }
        private void FillFacturaBElist()
        {

            FacturaBE wFacturaBE = new FacturaBE();

            wFacturaBE.ClienteBE.Apellido = "Oviedo";
            wFacturaBE.ClienteBE.Nombre = "Marcelo Fabian";
            wFacturaBE.ClienteBE.IdCliente = 345;
            wFacturaBE.ClienteBE.IdTipoCliente = 100;
            wFacturaBE.FechaFatura = System.DateTime.Now;
            wFacturaBE.IdFactura = 90000;
            wFacturaBE.IdCliente = wFacturaBE.ClienteBE.IdCliente;
            _FacturaBElist.Add(wFacturaBE);

            wFacturaBE = new FacturaBE();

            wFacturaBE.ClienteBE.Apellido = "Braida";
            wFacturaBE.ClienteBE.Nombre = "Hernan de las pasturas";
            wFacturaBE.ClienteBE.IdCliente = 120;
            wFacturaBE.ClienteBE.IdTipoCliente = 100;
            wFacturaBE.IdCliente = wFacturaBE.ClienteBE.IdCliente;
            wFacturaBE.FechaFatura = System.DateTime.Now.AddDays(-12);
            wFacturaBE.IdFactura = 80002;

            _FacturaBElist.Add(wFacturaBE);

            wFacturaBE = new FacturaBE();

            wFacturaBE.ClienteBE.Apellido = "Honda";
            wFacturaBE.ClienteBE.Nombre = "Kamakawa";
            wFacturaBE.ClienteBE.IdCliente = 3000;
            wFacturaBE.ClienteBE.IdTipoCliente = 200;
            wFacturaBE.IdCliente = wFacturaBE.ClienteBE.IdCliente;
            wFacturaBE.FechaFatura = System.DateTime.Now.AddDays(-12);
            wFacturaBE.IdFactura = 10000234;

            _FacturaBElist.Add(wFacturaBE);
        }

        void FillTipoClienteBEList()
        {
            
            TipoClienteBE tc = new TipoClienteBE();

            tc.Descripcion = "Interno";
            tc.IdTipoCliente = 100;
            _TipoClienteBEList.Add(tc);

            tc = new TipoClienteBE();
            tc.Descripcion = "Externo";
            tc.IdTipoCliente = 200;
            _TipoClienteBEList.Add(tc);
        }
        private void FillClienteBECollection()
        {
            foreach (FacturaBE f in _FacturaBElist)
            {
                _ClienteBECollection.Add(f.ClienteBE);
            }
        }

        private void fwkGenericDataGridView_Combo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        
        }

        private void fwkGenericDataGridView_Combo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ClienteBE wClienteBE = fwkGenericDataGridView_Combo.GetSelectedEntity<ClienteBE>();
            txtCliente.Text += "IdTipoCliente: " + wClienteBE.IdTipoCliente;
            txtCliente.Text += Environment.NewLine;
            txtCliente.Text =  wClienteBE.Nombre;
            txtCliente.Text += Environment.NewLine;
            txtCliente.Text += "Tipo Cliente: " + fwkGenericDataGridView_Combo.CurrentRow.Cells["IdTipoCliente"].Value.ToString();

        }

        private void btnAddToCombo_Click(object sender, EventArgs e)
        {
            TipoClienteBE tc = new TipoClienteBE();
            tc.Descripcion = "Especial";
            tc.IdTipoCliente = 300;
            _TipoClienteBEList.Add(tc);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClienteBE myLocatedObject = _ClienteBECollection.Find(delegate(Fwk.Bases.FrontEnd.Controls.Test.ClienteBE c) 
            { return c.IdCliente == 120; });

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FwkMessageView.Show("asdfasdf", "titulito", MessageBoxButtons.OK, MessageBoxIcon.Question);   
        }

        


    }
}