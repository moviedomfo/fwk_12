using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Logging;
using Fwk.Configuration;
using Fwk.ConfigSection;
using Fwk.Logging.Targets;
namespace Fwk.Logging.Test
{
    public partial class frmLoggingTest : Form
    {
        Logger _loger = new Logger("Fwk.Logging.Test.frmLoggingTest");
        LoggingSection _LoggingSection;
        public frmLoggingTest()
        {
            InitializeComponent();
            txtFilePrefix.Text = string.Concat(DateTime.Now.Hour, "_", DateTime.Now.Minute, "_");
            _LoggingSection = System.Configuration.ConfigurationManager.GetSection("FwkLogging") as LoggingSection;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                _loger.Warning("Fwk Loggin test", "Mensaje de prueba para Fwk Loggin");
                txtNoStaticResult.Text = XmlTarget.Logs.GetXml();
            }
            catch (Exception ex)
            {
                ExceptionView.Show(ex);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                _loger.Audit("Fwk Loggin test", "mensaje de prueba para Fwk Loggin", Environment.UserName, Environment.MachineName);
                txtNoStaticResult.Text = XmlTarget.Logs.GetXml();
            }
            catch (Exception ex)
            {
                ExceptionView.Show(ex);
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {

            Events _Logs = Fwk.Logging.Events.GetFromXml<Events>(Fwk.HelperFunctions.FileFunctions.OpenTextFile(_LoggingSection.GetProvider().FileName));
            
            loadingResultsTextBox.Text = _Logs.GetXml();

            Target.TargetFactory(TargetType.Xml, "");  
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                _loger.Error("Test Login", "pppppppppppppppppppppppp");
            }
            catch (Exception ex)
            {
                ExceptionView.Show(ex);
            }
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            Fwk.Logging.StaticLogger.ClearXmlTargetEvents();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Events _Logs = Fwk.Logging.Events.GetFromXml<Events>(Fwk.HelperFunctions.FileFunctions.OpenTextFile(_LoggingSection.GetProvider().FileName));

                txtNoStaticResult.Text = _Logs.GetXml();
            }
            catch (Exception ex)
            {
                ExceptionView.Show(ex);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {

                Events _Logs = Fwk.Logging.Events.GetFromXml<Events>
                    (Fwk.HelperFunctions.FileFunctions.OpenTextFile
                    (_LoggingSection.GetProvider().FileName));

                txtNoStaticResult.Text = _Logs.GetXml();
            }
            catch (Exception ex)
            {
                ExceptionView.Show(ex);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 100; i++)
            {
                Event ev = new Event();
                ev.Message.Text = "test login" + i.ToString() + "aaaaaaaaaaaaaaaa";
                ev.LogType = EventType.Error;
                Fwk.Logging.StaticLogger.Log("P4",ev);

            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {

                ITarget target = GetTarget(String.Empty);
                //string filename = string.Concat(txtFilePrefix.Text, _LoggingSection.GetRuleByEventType(EventType.Warning).FileName);
                //filename = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
                //Events _Logs = Fwk.Logging.Events.GetFromXml<Events>(Fwk.HelperFunctions.FileFunctions.OpenTextFile(filename));
                Event ee = new Event();

                Events _Logs = target.SearchByParam(ee);
                textBox2.Text = _Logs.GetXml();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));

            }

        }
        ITarget GetTarget(string providerName)
        {
            ITarget target = null;
            LogProviderElement provider = _LoggingSection.GetProvider(providerName);
            switch (provider.Target)
            {
                case TargetType.Database:
                    {
                        target = new DatabaseTarget();
                        ((DatabaseTarget)target).CnnStringName = provider.CnnStringName;

                        break;
                    }
                case TargetType.Xml:
                    {
                        target = new XmlTarget();
                        ((XmlTarget)target).FileName = provider.FileName;
                        break;
                    }
            }
            return target;
        }

        private void button10_Click(object sender, EventArgs e)
        {

            StaticLogger.Log(TargetType.Xml, new Event(EventType.Warning, "Test", "Hola mundo"), @"c:\" + HelperFunctions.DateFunctions.Get_Year_Mont_Day_String(DateTime.Now, '_') + "pepe.xml", string.Empty);
            StaticLogger.Log(TargetType.Xml, new Event(), @"c:\logs.xml", string.Empty);
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            List<string> lst = new List<string>();
            Event eventFilter = new Event();
            try
            {
                _loger.Information("Fwk Loggin test", "Mensaje de prueba para Fwk Loggin");
                System.Configuration.ConnectionStringSettings cnn = System.Configuration.ConfigurationManager.ConnectionStrings[_LoggingSection.GetProvider().CnnStringName];
                if(cnn == null)
                {
                    throw new Exception("no existe la ConnectionString " + _LoggingSection.GetProvider().CnnStringName + " configurada en el config file para EventType.Information");
                }
                ITarget t = DatabaseTarget.TargetFactory(TargetType.Database, cnn.Name);
                _loger.Information("test logging", "Informe de error");
                //eventFilter.LogType = EventType.Information;
                //t.SearchByParam(eventFilter);
                //foreach (Event wEvent in t.SearchByParam(eventFilter))
                //{
                //    lst.Add(wEvent.Id.ToString());
                //}
                //t.Remove(lst);
                //eventFilter.LogType = EventType.None;
                txtNoStaticResult.Text = t.SearchByParam(eventFilter).GetXml();



            }
            catch (Exception ex)
            {
                ExceptionView.Show(ex);
            }
        }

        private void btnClearWarning_Click(object sender, EventArgs e)
        {
            //TRaigo el target de warning por medio del TargetFactory.. Uso como clave _LoggingSection.GetRuleByEventType(EventType.Warning).FileName 
            ITarget t = XmlTarget.TargetFactory(TargetType.Xml, _LoggingSection.GetProvider().FileName);
            List<string> lst = new List<string>();
            

            
            Event eventFilter = new Event();
            eventFilter.LogType = EventType.Warning;
  

            foreach (Event wEvent in t.SearchByParam(eventFilter))
            {
                lst.Add(wEvent.Id.ToString());
            }
            t.Remove(lst);
            txtNoStaticResult.Text = XmlTarget.Logs.GetXml();
        }

    }
}
