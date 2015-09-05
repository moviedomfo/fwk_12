using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fwk.Logging;
using System.Xml.Serialization;
using System.Xml;
using System.Linq;
namespace Fwk.Logging.Viewer
{
    public partial class FRM_Document : Form
    {
        Fwk.Logging.Targets.Target _Target;
        EventGridList currentEvents = null;
        ServiceErrorView _ServiceErrorView;
        ServicesView _ServicesView;
        OtherView _OtherView;
        public FRM_Document()
        {
            InitializeComponent();

        }

        #region <public methods>

        public void Populate(Fwk.Logging.Targets.Target target)
        {

            _Target = target;
            //grdLogs.BindingContextChanged += new EventHandler(grdLogs_BindingContextChanged);

            Event ev = new Event();
            try
            {
                Events wEvents = _Target.SearchByParam(ev);
                currentEvents = Get_EventGridList(wEvents);
                this.eventGridListBindingSource.DataSource = null;
                this.eventGridListBindingSource.DataSource = currentEvents;

                grdLogs.Refresh();

            }
            catch (InvalidOperationException io)
            {
                MessageBox.Show("El archivo no tiene el formato correcto");

                throw io;
            }
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventIdList"></param>
        public void Remove()
        {
            List<Guid> wGuids = new List<Guid>();
            foreach (DataGridViewRow row in grdLogs.SelectedRows)
            {
                wGuids.Add((Guid)row.Cells["Id"].Value);
            }
            try
            {
                _Target.Remove(wGuids);
                currentEvents.Remove(wGuids);
                grdLogs.Refresh();

            }
            catch (Exception ex)
            {
                ExceptionViewer.Show(ex);
            }
           
        }

        /// <summary>
        /// 
        /// </summary>
        public void RemoveAll()
        {
             List < Guid > wGuids = new List<Guid>();
            foreach (DataGridViewRow row in grdLogs.Rows)
            {
                wGuids.Add((Guid)row.Cells["Id"].Value);
            }
            try
            {
                _Target.Remove(wGuids);
                currentEvents.Remove(wGuids);
                grdLogs.Refresh();

            }
            catch (Exception ex)
            {
                ExceptionViewer.Show(ex);
            }
            
        }




        #endregion






        /// <summary>
        /// 
        /// </summary>
        /// <param name="pMessage"></param>
        /// <returns></returns>
        internal static Message LoadMessage(String pMessage)
        {
            Message msg = new Message();
            StringBuilder s = new StringBuilder();
            s.AppendLine("<Message>");
            s.AppendLine(pMessage);
            s.AppendLine("</Message>");
            XmlNode node = null;
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            try
            {
                doc.LoadXml(s.ToString());

                node = Fwk.Xml.Node.NodeGet(doc.FirstChild, "Request");
                if (node != null)
                {

                    msg.Request = node.InnerXml;
                    msg.MessageContenType = MessageContenType.Service;
                }
                node = Fwk.Xml.Node.NodeGet(doc.FirstChild, "Response");
                if (node != null)
                    msg.Response = node.InnerXml;

                node = Fwk.Xml.Node.NodeGet(doc.FirstChild, "Error");
                if (node != null)
                {
                    msg.AnyMessage = node.OuterXml;
                    msg.MessageContenType = MessageContenType.ServiceError;
                }
                if (string.IsNullOrEmpty(msg.AnyMessage) &&
                    string.IsNullOrEmpty(msg.Request) &&
                    string.IsNullOrEmpty(msg.Response))
                {
                    msg.AnyMessage = pMessage;
                    msg.MessageContenType = MessageContenType.Other;
                }


            }
            catch (Exception )
            {
                msg.AnyMessage = pMessage;
            }

            return msg;
        }



       
        private void grdLogs_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (grdLogs.CurrentRow == null) return;
            //label1.Text =string.Concat( "CurrentRow = ",grdLogs.CurrentRow.Index ,"e.RowIndex", e.RowIndex);

            
            EventGrid x = (EventGrid)grdLogs.Rows[e.RowIndex].DataBoundItem as EventGrid;

            

            Message wMessage = LoadMessage(x.Message.Text);
            x.FormatedMessage = wMessage;
            if (wMessage.MessageContenType == MessageContenType.ServiceError)
            {
                if (_ServiceErrorView == null)
                    _ServiceErrorView = new ServiceErrorView();
                _ServiceErrorView.Populate(x);

                AddtoPanel(_ServiceErrorView);
            }

            if (wMessage.MessageContenType == MessageContenType.Service)
            {
                if (_ServicesView == null)
                    _ServicesView = new ServicesView();
                _ServicesView.Populate(x);

                AddtoPanel(_ServicesView);
            }
            if (wMessage.MessageContenType == MessageContenType.Other)
            {
                if (_OtherView == null)
                    _OtherView = new OtherView();
                _OtherView.Populate(x);

                AddtoPanel(_OtherView);
            }
        }

        private void FRM_Document_Activated(object sender, EventArgs e)
        {
            FRM_Main.Current_Document = this;
        }

        private void filter1_OnFilterChanged(Event eventFilter, DateTime endDate)
        {
            Events wEvents = null;
            this.eventGridListBindingSource.DataSource = null;
            try
            {
                if (endDate == Fwk.HelperFunctions.DateFunctions.NullDateTime)
                {
                    wEvents = _Target.SearchByParam(eventFilter);

                }
                else
                {
                    wEvents = _Target.SearchByParam(eventFilter, endDate);

                }
            }
            catch (Exception ex)
            {
                ExceptionViewer.Show(ex);
            }
            currentEvents = Get_EventGridList(wEvents);
            if (currentEvents.Count == 0) return;
            this.eventGridListBindingSource.DataSource = null;
            this.eventGridListBindingSource.DataSource = currentEvents;
            grdLogs.Refresh();
        }


        private void FRM_Document_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (grdLogs.SelectedRows.Count != 0)
                {
                    DialogResult d = MessageBox.Show("Se eliminaran los logs seleccionados", "Fwk Logviewer", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (d == System.Windows.Forms.DialogResult.OK)
                    {
                        Remove();
                    }
                }
            }
        }

        public override void Refresh()
        {
            //this.filter1.Refresh();
        
            

            DateTime wEndDate = Fwk.HelperFunctions.DateFunctions.NullDateTime;
            Event wEventFilter =null;
            this.filter1.GetFilter(out wEventFilter,out wEndDate);
            Events wEvents = null;
            try
            {
                if (wEndDate == Fwk.HelperFunctions.DateFunctions.NullDateTime)
                {
                    wEvents = _Target.SearchByParam(wEventFilter);

                }
                else
                {
                    wEvents = _Target.SearchByParam(wEventFilter, wEndDate);

                }
            }
            catch (Exception ex)
            {
                ExceptionViewer.Show(ex);
            }
            currentEvents = Get_EventGridList(wEvents);
            this.eventGridListBindingSource.DataSource = null;
            this.eventGridListBindingSource.DataSource = currentEvents;
            grdLogs.Refresh();
            base.Refresh();



        }

        /// <summary>
        /// Mapea Events con EventGridList
        /// </summary>
        /// <param name="pEvents"></param>
        /// <returns></returns>
        EventGridList Get_EventGridList(Events pEvents)
        {
            if (pEvents.Count == 0) return new EventGridList();
            var lst = from e in pEvents select new EventGrid(e);
            EventGridList lst2 = new EventGridList();
            lst2.AddRange(lst.ToArray<EventGrid>());
            return lst2;
        }
        void AddtoPanel(Control pControlToAdd)
        {

            if (panel1.Contains(pControlToAdd)) return;

            pControlToAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            pControlToAdd.Location = new System.Drawing.Point(0, 0);

            
            
            panel1.Controls.Clear();
            panel1.Controls.Add(pControlToAdd);

        }

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
          DialogResult d=  MessageBox.Show("Se eliminaran todos los logs","Fwk Logviewer", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
          if (d == System.Windows.Forms.DialogResult.OK)
          {
              RemoveAll();
          }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Se eliminaran los logs seleccionados", "Fwk Logviewer", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (d == System.Windows.Forms.DialogResult.OK)
            {
                Remove();
            }
        }

       

       
    }


    [XmlInclude(typeof(Message)), Serializable]
    public class Message
    {
        MessageContenType _MessageContenType = MessageContenType.Other;

        internal MessageContenType MessageContenType
        {
            get { return _MessageContenType; }
            set { _MessageContenType = value; }
        }
        private String _Request;


        private String _Response;


        private String _AnyMessage;




        [XmlElement(ElementName = "Request", DataType = "string")]
        public String Request
        {
            get { return _Request; }
            set { _Request = value; }
        }
        [XmlElement(ElementName = "Response", DataType = "string")]
        public String Response
        {
            get { return _Response; }
            set { _Response = value; }
        }
        [XmlElement(ElementName = "AnyMessage", DataType = "string")]
        public String AnyMessage
        {
            get { return _AnyMessage; }
            set { _AnyMessage = value; }
        }

    }


    internal enum MessageContenType
    {
        Service,
        ServiceError,
        Other
    }

}