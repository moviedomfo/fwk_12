using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fwk.Bases.Test;
using helper = Fwk.HelperFunctions;
using Services = Fwk.Bases.Test.Services;
using Sebito.BackEnd.BusinessEntities;
using Fwk.Bases;
using Fwk.HelperFunctions;
using Fwk.ServiceManagement;
namespace Fwk.Bases.Test
{
    public partial class frmEntitiesTest : Form
    {
        private String m_Nombre = string.Empty;
        ClienteCollectionBE m_ClienteCollectionBE = null;
        public frmEntitiesTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_ClienteCollectionBE  = new ClienteCollectionBE();

            ClienteBE wClienteBE1 = new ClienteBE();
            wClienteBE1.EntityState = EntityState.Changed;
            wClienteBE1.Nombre = "Marcelo F Oviedo";
            wClienteBE1.Apellido = "Pelsoft";
            wClienteBE1.Edad = 32;
            wClienteBE1.Historial= new Xml.CData();
            wClienteBE1.Historial.Text = @"<Contrato Nro 21>";
            wClienteBE1.FechaNacimiento = Convert.ToDateTime("2006-10-18T00:00:00"); //new DateTime(2006,12,18);


            m_ClienteCollectionBE.Add(wClienteBE1);
            string ss = m_ClienteCollectionBE.ToString();
            label2.Text = "Xml de ClienteBE1";

            txtEntidadSimple.Text = wClienteBE1.GetXml();


            try
            {
                label1.Text = "Xml de ClienteCollectionBE";
                txtCollection.Text = m_ClienteCollectionBE.GetXml();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            ClienteCollectionBE wClienteCollectionBE = new ClienteCollectionBE();

            #region crear objetos
            ClienteBE wClienteBE1 = new ClienteBE();
            
            wClienteBE1.Nombre = "Marcelo";
            wClienteBE1.Apellido = "Oviedo";
            wClienteBE1.Edad = 32;
            wClienteBE1.FechaNacimiento = Convert.ToDateTime("1974-10-18T00:00:00");

            ClienteBE wClienteBE2 = new ClienteBE();

            wClienteBE2.Nombre = "Javier";
            wClienteBE2.Apellido = "Oviedo";
            wClienteBE2.Edad = 30;
            wClienteBE2.FechaNacimiento = Convert.ToDateTime("1976-10-18T00:00:00"); 

            wClienteCollectionBE.Add(wClienteBE1);
            wClienteCollectionBE.Add(wClienteBE2);

            #endregion

            label2.Text = "wClienteBE1.GetDataSet().GetXml()";
            txtEntidadSimple.Text = wClienteBE1.GetDataSet().GetXml();
             
            DataSet wDtsClienteCollection  = wClienteCollectionBE.GetDataSet();

            label1.Text = "wDtsClienteCollection.GetXml()";
            txtCollection.Text = wDtsClienteCollection.GetXml();
            dataGridView1.DataSource = wDtsClienteCollection.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Services.CrearFacturasContadoRequest req = new Services.CrearFacturasContadoRequest();

            Services.FacturaBE wFacturaBE = req.BusinessData.FacturaBE;

            Services.ItemCollectionBE wItemCollectionBE = new Services.ItemCollectionBE();

            Services.ItemBE wItemBE = new Services.ItemBE();
            wItemBE.Cantidad = 100;
            wItemBE.Descripcion = "Manzanas";
            wItemCollectionBE.Add(wItemBE);

            wItemBE = new Services.ItemBE();
            wItemBE.Cantidad = 34200;
            wItemBE.Descripcion = "Peras";

            wItemCollectionBE.Add(wItemBE);

            wFacturaBE.NombreCliente = "Marcelo";
            wFacturaBE.NumeroCliente = 90000;
            wFacturaBE.FechaFactura = System.DateTime.Now;
            wFacturaBE.ItemCollectionBE = wItemCollectionBE;

            #region (Context)
            //Services.CrearFacturasContadoRequest
            Fwk.Bases.ContextInformation wContext = new Fwk.Bases.ContextInformation();

            wContext.HostName = Environment.MachineName;
            wContext.UserId = Environment.UserName;
            wContext.HostTime = System.DateTime.Now;

            req.ContextInformation = wContext;
            #endregion

            txtEntidadSimple.Text = wFacturaBE.GetXml();

            label1.Text = "xml del request";
            txtCollection.Text = req.GetXml();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtCollection.Text.Length == 0)
            {
                MessageBox.Show("Primero ejecute el boton de la derecha ..");
                return;
            }

            try
            {
                ClienteCollectionBE wClienteCollectionBE = (ClienteCollectionBE)helper.SerializationFunctions.DeserializeFromXml(typeof(ClienteCollectionBE), txtCollection.Text);
                MessageBox.Show(wClienteCollectionBE.GetXml(), "ClienteCollectionBE creardo por helper.SerializationFunctions(...)");
            }
            catch(Exception )
            {
                MessageBox.Show("Error al deserializar");
            }
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtCollection.Text.Length == 0)
            {
                MessageBox.Show("Primero ejecute el boton de la derecha ..");
                return;
            }

            try
            {
                
                Services.CrearFacturasContadoRequest wCrearFacturasContadoRequest = new Fwk.Bases.Test.Services.CrearFacturasContadoRequest();

                wCrearFacturasContadoRequest.SetXml (txtCollection.Text);

                MessageBox.Show(wCrearFacturasContadoRequest.GetXml ());

            }
            catch (Exception )
            {
                MessageBox.Show("Error al deserializar");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Services.CrearFacturasContadoRequest req = new Services.CrearFacturasContadoRequest();

            #region Set Entity
            Services.FacturaBE wFacturaBE = req.BusinessData.FacturaBE;
       


            
            Services.ItemCollectionBE wItemCollectionBE = new Services.ItemCollectionBE();

            Services.ItemBE wItemBE = new Services.ItemBE();
            wItemBE.Cantidad = 100;
            wItemBE.Descripcion = "Manzanas";
            wItemCollectionBE.Add(wItemBE);

            wItemBE = new Services.ItemBE();
            wItemBE.Cantidad = 34200;
            wItemBE.Descripcion = "Peras";

            wItemCollectionBE.Add(wItemBE);

            wFacturaBE.NombreCliente = "Marcelo";
            wFacturaBE.NumeroCliente = 90000;
            wFacturaBE.FechaFactura = System.DateTime.Now;
            wFacturaBE.ItemCollectionBE = wItemCollectionBE;
           
            #endregion

            #region (Context)
            //Services.CrearFacturasContadoRequest
            Fwk.Bases.ContextInformation wContext = new Fwk.Bases.ContextInformation();

            wContext.HostName = Environment.MachineName;
            wContext.UserId = Environment.UserName;
            wContext.ServerTime = System.DateTime.Now;

            req.ContextInformation = wContext;
            #endregion

            txtEntidadSimple.Text = wFacturaBE.GetXml();

            label1.Text = "xml del request";
            //txtCollection.Text = Fwk.HelperFunctions.SerializationFunctions.SerializeToXml(req);
            txtCollection.Text = req.GetXml();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txtCollection.Text.Length == 0)
            {
                MessageBox.Show("Primero ejecute el boton Amarillo..");
                return;
            }
            try
            {
                ClienteCollectionBE wClienteCollectionBE = ClienteCollectionBE.GetFromXml<ClienteCollectionBE>(txtCollection.Text);
                MessageBox.Show(wClienteCollectionBE.GetDataSet().GetXml(), "ClienteCollectionBE creado apartir de un xml");
            }
            catch (Exception ex)
            { throw ex; }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Services.CrearFacturasContadoRequest wCrearFacturasContadoRequest =   (Services.CrearFacturasContadoRequest)
                helper.SerializationFunctions.DeserializeFromXml(typeof(Services.CrearFacturasContadoRequest),
                txtCollection.Text);

            MessageBox.Show(wCrearFacturasContadoRequest.GetBusinessDataXml(), "wCrearFacturasContadoRequest.GetXml()");

            String Str = helper.SerializationFunctions.SerializeToXml(wCrearFacturasContadoRequest);

            MessageBox.Show(Str);

        }

        private void button8_Click(object sender, EventArgs e)
        {

            
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Sebito.BackEnd.BusinessEntities.ParamBE param = new ParamBE ();

            param = ParamBE.GetFromXml < ParamBE>("");

            
             

            
        }

        private void btnDeserializeServiceConfigurationManager_Click(object sender, EventArgs e)
        {
            ServiceConfigurationCollection list = new ServiceConfigurationCollection();
            ServiceConfiguration c = new ServiceConfiguration();

            c.Audit = true;
            c.Description = "Servicio de prueba";
            c.IsolationLevel = Fwk.Transaction.IsolationLevel.ReadCommitted;
            c.Name = "pepep";
            c.TransactionalBehaviour = Fwk.Transaction.TransactionalBehaviour.Suppres;
            c.Request = "BuscarPaisesPorParametros.BuscarPaisesPorParametrosRequest , GestionarPaisesISVC";
            c.Response = "BuscarPaisesPorParametros.BuscarPaisesPorParametrosResponse , GestionarPaisesISVC";

            list.Add(c);
            c = new ServiceConfiguration();

            c.Audit = true;
            c.Description = "ModificarLocalidadService   ";
            c.IsolationLevel = Fwk.Transaction.IsolationLevel.ReadCommitted;
            c.Name = "ModificarLocalidadService";
            c.TransactionalBehaviour = Fwk.Transaction.TransactionalBehaviour.Suppres;
            c.Request = "BuscarPaisesPorParametros.BuscarPaisesPorParametrosRequest , GestionarPaisesISVC";
            c.Response = "BuscarPaisesPorParametros.BuscarPaisesPorParametrosResponse , GestionarPaisesISVC";

            list.Add(c);
            txtEntidadSimple.Text = c.GetXml();

            txtCollection.Text = SerializationFunctions.SerializeToXml(list);
        }

        private void btnDeSerializeServiceConfiguration_Click(object sender, EventArgs e)
        {
            String xml = FileFunctions.OpenTextFile("BPConfig.xml");
            ServiceConfigurationCollection list = 
                (ServiceConfigurationCollection)SerializationFunctions.DeserializeFromXml(typeof(ServiceConfigurationCollection),xml);
            txtCollection.Text = SerializationFunctions.SerializeToXml(list);
        }

        private void button9_Click_1(object sender, EventArgs e)
        {

            ServiceConfiguration service = Fwk.ServiceManagement.ServiceMetadata.GetServiceConfiguration(string.Empty,txtServiceConfigurationName.Text);
            txtEntidadSimple.Text = service.GetXml();
        }

        private void button10_Click(object sender, EventArgs e)
        {

            ServiceConfiguration service = ServiceConfiguration.GetFromXml < ServiceConfiguration>(txtEntidadSimple.Text);
            ServiceMetadata.SetServiceConfiguration("","", service);
        }

        private void button11_Click(object sender, EventArgs e)
        {

            ClienteBE c = m_ClienteCollectionBE.Where(p => p.Apellido.Equals( "pelsoft")).FirstOrDefault();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            GetColaboratorDataByParamsResponse res = new GetColaboratorDataByParamsResponse();
            res.BusinessData.ColaboratorData = new ColaboratorData();
            res.BusinessData.ColaboratorData.Username = "moviedo";
            res.BusinessData.ColaboratorData.UserId = 12;
            res.BusinessData.ColaboratorData.SucursalId = 12;
            res.BusinessData.ColaboratorData.Surname = "Oviedo";
            res.BusinessData.ColaboratorData.MachineIp = "asdfasfsadfsd";

            string xml = res.BusinessData.ColaboratorData.GetXml();
            xml = res.GetXml();
        }
    }
}
