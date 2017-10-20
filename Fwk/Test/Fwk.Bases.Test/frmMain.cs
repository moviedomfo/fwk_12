using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Fwk.HelperFunctions.Compression;

namespace Fwk.Bases.Test
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (frmEntitiesTest frm = new frmEntitiesTest ())
            { frm.ShowDialog(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (frmEntityFromXmlWhitAttributes frm = new frmEntityFromXmlWhitAttributes())
            { frm.ShowDialog(); }

           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (frmUndoRedoEntitiesTest frm = new frmUndoRedoEntitiesTest())
            { frm.ShowDialog(); }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            using (frmHelperFunctions frm = new frmHelperFunctions())
            { frm.ShowDialog(); }

        }

        private void btnExeptions_Click(object sender, EventArgs e)
        {
            using (frmException frm = new frmException())
            { frm.ShowDialog(); }
        }


        
        public class Person
        {
            public Person(int id,string nombre) {
                this.Id = id;
                this.Nombre = nombre;
            }
            public Person() { }
            public int Id { get; set; }
            public string Nombre { get; set; }
        }

        private void button_SingletonFactoryArray_Click(object sender, EventArgs e)
        {
            SingletonFactoryArray<Person> personList = new SingletonFactoryArray<Person>();

            Person p1 = new Person();
            p1.Id = 1000;
            p1.Nombre = "Gaus";
            personList.Add(p1.Nombre, p1);

            Person p2 = new Person();
            p2.Id = 2000;
            p2.Nombre = "Hendryx";
            personList.Add(p2.Nombre, p2);



           Person p3 =  personList.Create("Maria");
           Person p4 = personList.Create("Robert", new Object[] { 3000, "Robert" });
        }

        private void btnJSON_Click(object sender, EventArgs e)
        {
            EventResponse wEventResponse = new EventResponse();
            IServiceContract sc = (IServiceContract)wEventResponse;
            EventResponseParams wEventResponseParams = new EventResponseParams();
            wEventResponseParams.AuthModesResponse = new EventResponseParams.AuthenticationModesResponse();
            wEventResponseParams.AuthModesResponse.Domains = new DomainList();

            Domain d = new Domain();
            d.Id = "1";
            d.Name = "asdsad";
            wEventResponseParams.AuthModesResponse.Domains.Add(d);
            d = new Domain();
            d.Id = "2";
            d.Name = "allus";
            wEventResponseParams.AuthModesResponse.Domains.Add(d);

            wEventResponseParams.TrackingGUID = Guid.NewGuid();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.None;
            wEventResponse.BusinessData = wEventResponseParams;
            settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            var sd = Procesar<EventResponse, EventResponse>(wEventResponse);

            

            String jsonReq = Fwk.HelperFunctions.FileFunctions.OpenTextFile(@"E:\Projects\fwk\trunk\12.0\Fwk\Test\Fwk.Bases.Test\TextFile1.txt");

            EventRequest req2 = (EventRequest)Fwk.HelperFunctions.SerializationFunctions.DeSerializeObjectFromJson<EventRequest>(jsonReq);

            IServiceContract req = (IServiceContract)Fwk.HelperFunctions.SerializationFunctions.DeSerializeObjectFromJson<IServiceContract>( jsonReq);


           String xml = wEventResponse.GetXml();
            
            //EventResponse response2 = Newtonsoft.Json.JsonConvert.DeserializeObject<EventResponse>(res2, settings);

            //String res3 = Fwk.HelperFunctions.SerializationFunctions.SerializeObjectToJson<EventResponse>( wEventResponse);
            //EventResponse response3 = (EventResponse)Fwk.HelperFunctions.SerializationFunctions.DeSerializeObjectFromJson < EventResponse>( res3);

   
        }


        public TResponse Procesar<TRequest, TResponse>(TRequest req)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {
            String json = Fwk.HelperFunctions.SerializationFunctions.SerializeObjectToJson<TRequest>(req);

            TResponse res = (TResponse)Fwk.HelperFunctions.SerializationFunctions.DeSerializeObjectFromJson<TResponse>(json);

            return res;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            using (frmFwkZip frm = new frmFwkZip())
            { frm.ShowDialog(); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (frmFormatFunction frm = new frmFormatFunction())
            { frm.ShowDialog(); }

        }

      
    }

   
}
