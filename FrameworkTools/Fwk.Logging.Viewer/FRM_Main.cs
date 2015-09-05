using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.ProviderBase;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fwk.Bases;
using Fwk.Xml;
using System.Configuration;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Fwk.Logging;
using Fwk.HelperFunctions;
using System.Reflection;

namespace Fwk.Logging.Viewer
{
    public partial class FRM_Main : Form
    {
        public static FRM_Document Current_Document;
        public FRM_Main()
        {
            InitializeComponent();

            this.Text = string.Concat(this.Text, Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }

        #region <private event handlers>
        private void FRM_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                HideForm();
            }
            if (e.KeyCode == Keys.F5)
            {
                RefreshTabDocument();
                System.Threading.Thread.Sleep(1000);
            }
        }
        #endregion

        #region <private menu event handlers>
        void refreshToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            RefreshTabDocument();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void mnuMostrar_Click(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void ctlNotify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowForm();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            string wFileName = Fwk.HelperFunctions.FileFunctions.OpenFileDialog_Open(Fwk.HelperFunctions.FileFunctions.OpenFilterEnums.OpenXmlFilter);
            if (!string.IsNullOrEmpty(wFileName))
            {
                CreateTabDocument(wFileName);
            }
        }

        private void mnuOpenFromDB_Click(object sender, EventArgs e)
        {

            CreateTabDocumentFromDB();
        }


        #endregion

        #region <private methods>
        private void CloseForm()
        {
            this.Close();
        }

        private void HideForm()
        {
            if (this.WindowState == FormWindowState.Maximized || this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void ShowForm()
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            this.Activate();
        }


        private void CreateTabDocumentFromDB()
        {

            using (ConnectionForm frm = new ConnectionForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.ConnectionOK)
                    {
                        Fwk.Logging.Targets.Target t = new Fwk.Logging.Targets.DatabaseTarget();
                        ((Fwk.Logging.Targets.DatabaseTarget)t).ConnectionString = frm.CnnString.ToString();

                        Load_FRM_Document(t);

                    }
                }
            }




        }

        private void CreateTabDocument(string pFileName)
        {
            Fwk.Logging.Targets.Target xmlFileTarget = new Fwk.Logging.Targets.XmlTarget();
            xmlFileTarget.FileName = pFileName;
            Load_FRM_Document(xmlFileTarget);


        }

        void Load_FRM_Document(Fwk.Logging.Targets.Target t)
        {
            FRM_Document wForm ;
            try
            {
                wForm = new FRM_Document();
                wForm.Populate(t);
                wForm.MdiParent = this;
                wForm.Show();
            }
            catch (InvalidOperationException)
            { }
            catch (Exception ex)
            {
                this.ExceptionViewer.Show(ex);
            }
        }
        private void RefreshTabDocument()
        {
            if (Current_Document != null)
                Current_Document.Refresh();
        }

        private List<Event> ParseDB(DataSet pLogs)
        {
            List<Event> wEvents = new List<Event>();


            return wEvents;
        }

        private List<Event> ParseFile(FileInfo wFile)
        {
            try
            {
                return ParseXmlFile(wFile.FullName);
            }
            catch (Exception ex)
            {
                fwkMessageViewComponent1.Show(ex.Message);
                return null;
            }

        }

        private List<Event> ParseLogFile(string pFileName)
        {
            List<Event> wEvents = new List<Event>();
            Event wEvent = null;
            StreamReader wReader = new StreamReader(pFileName);
            string wLineContent = "";
            while (wReader.EndOfStream == false)
            {
                wEvent = new Event();
                wLineContent = wReader.ReadLine();
                string[] wStringSections = wLineContent.Split('|');
                wEvent.Id = new Guid(wStringSections[0].Trim().Replace("Log Id: ", ""));
                wEvent.LogDate = Convert.ToDateTime(wStringSections[1].Trim().Replace("Date: ", ""));
                wEvent.LogType = (EventType)System.Enum.Parse(typeof(EventType), wStringSections[2].Trim().Replace("Type: ", ""), true);
                wEvent.Message.Text = wStringSections[3].Trim().Replace("Message: ", "");
                wEvent.Source = wStringSections[4].Trim().Replace("Source: ", "");
                wEvent.User = wStringSections[5].Trim().Replace("User : ", "");
                wEvent.Machine = wStringSections[6].Trim().Replace("Machine : ", "");
                wEvents.Add(wEvent);
            }
            return wEvents;
        }

        private List<Event> ParseXmlFile(string pFileName)
        {
            List<Event> wEvents = new List<Event>();




            return wEvents;
        }
        #endregion

        private void clearAllEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuClose_Click(object sender, EventArgs e)
        {

        }




        private void actionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshTabDocument();
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void mnuMenu_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string wFileName = ((string[])e.Data.GetData(DataFormats.FileDrop, true))[0];

                if (!string.IsNullOrEmpty(wFileName))
                {
                  
                        CreateTabDocument(wFileName);
              
                }
            }
        }
        private void FRM_Main_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string wFileName = ((string[])e.Data.GetData(DataFormats.FileDrop, true))[0];

                if (!string.IsNullOrEmpty(wFileName))
                {
                
                        CreateTabDocument(wFileName);
               
                }
            }
        }
        private void FRM_Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void mnuMenu_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }




    }
}

