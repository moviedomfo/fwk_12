using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Bases.Test
{
    public partial class frmEntityFromXmlWhitAttributes : Form
    {
        public frmEntityFromXmlWhitAttributes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtXml.ForeColor = Color.Black;
            Event wEv = new Event();
            wEv.Id = Guid.NewGuid();
            wEv.Machine = Environment.MachineName;
            wEv.User = Environment.UserName;
            wEv.Message = "some message";
            wEv.DateAndTime = System.DateTime.Now;
            wEv.Type = Fwk.Logging.EventType.Information;
            txtXml.Text = wEv.GetXml();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            txtXml.ForeColor = Color.Brown;
            Event wEv = Event.GetFromXml<Event>(Fwk.HelperFunctions.FileFunctions.OpenTextFile("XmlWhitAttributes.xml"));
           
            txtXml.Text = wEv.GetXml();
           
        }
    }
}
