using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Caching;
using back.Common.ISVC.SearchSalesOrderDetail;
using System.Reflection;
using back.Common.BE;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using Fwk.HelperFunctions;
using System.IO;

namespace TestServicePerformance
{

    public partial class frmTest : Form
    {
        Measures _Sizes = new Measures();
        
        ControllerTest Ctrl;
        RemotingWrapper _RemotingWrapper;
        RemotingWrapper_config _RemotingWrapper_config;
        StringBuilder strResult = new StringBuilder();
        SearchSalesOrderDetailRes _SearchSalesOrderDetailRes;

        public frmTest()
        {
            InitializeComponent();
            Ctrl = new ControllerTest();

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            strResult = new StringBuilder();

            txtTestResult.Text = string.Empty;
            if (_RemotingWrapper == null)
            {
                MessageBox.Show("Haga clic en el boton Init");
                return;
            }
            btnStartTest.Enabled = false;
            progressBar1.Visible = true;
            progressBar1.Maximum = ControllerTest.Storage.StorageObject.Threads * ControllerTest.Storage.StorageObject.Calls;

            try
            {

                _RemotingWrapper.MessageEvent += new CheckEven(_RemotingWrapper_MessageEvent);
                _RemotingWrapper.FinalizeEvent += new FinalizeHandler(_RemotingWrapper_FinalizeEvent);
                _RemotingWrapper.CallEvent += new CallHandler(_RemotingWrapper_CallEvent);
                _RemotingWrapper.Start(txtXmlRequest.Text);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                progressBar1.Visible = false;
                btnStartTest.Enabled = true;
            }

        }

        #region wrapper events
        void _RemotingWrapper_CallEvent()
        {
            if (this.InvokeRequired)
            {
                CallHandler d = new CallHandler(_RemotingWrapper_CallEvent);
                this.Invoke(d, new object[] { });
            }
            else
            {
                if (progressBar1.Value == progressBar1.Maximum) return;
                progressBar1.Value++;
            }
        }

        void _RemotingWrapper_FinalizeEvent(string msgError)
        {

            if (this.InvokeRequired)
            {
                FinalizeHandler d = new FinalizeHandler(_RemotingWrapper_FinalizeEvent);
                this.Invoke(d, new object[] { msgError });
            }
            else
            {

                if (!string.IsNullOrEmpty(msgError))
                {
                    strResult.AppendLine(msgError);
                    _RemotingWrapper.MessageEvent -= new CheckEven(_RemotingWrapper_MessageEvent);
                    _RemotingWrapper.FinalizeEvent -= new FinalizeHandler(_RemotingWrapper_FinalizeEvent);
                    _RemotingWrapper.CallEvent -= new CallHandler(_RemotingWrapper_CallEvent);
                }
                txtTestResult.Text = strResult.ToString();
                progressBar1.Visible = false;
                progressBar1.Value = progressBar1.Minimum;
                tabControl1.TabIndex = 2;
                btnStartTest.Enabled = true;



            }

        }

        void _RemotingWrapper_MessageEvent(string msg, int threadNumber, double average, double totalTime)
        {

            if (this.InvokeRequired)
            {
                CheckEven d = new CheckEven(_RemotingWrapper_MessageEvent);
                this.Invoke(d, new object[] { msg, threadNumber, average, totalTime });
            }
            else
            {

                string str = string.Concat(msg, threadNumber, average, totalTime);

                strResult.Append(msg);
                strResult.Append(threadNumber);
                strResult.Append(string.Concat("   Date : ", System.DateTime.Now));
                strResult.Append(string.Concat("   AVG time : ", average, " ms"));
                strResult.Append(string.Concat("    Total time : ", totalTime, " ms"));
                strResult.AppendLine(Environment.NewLine);


            }
        }

        #endregion

        private void btnPing_Click(object sender, EventArgs e)
        {
            this.btnPing.Image = global::TestServicePerformance.Properties.Resources.Ball__Red_;
            if (!ValidateInit()) return;
            _RemotingWrapper = new RemotingWrapper();
            try
            {
                _RemotingWrapper.Init(txtURL.Text);
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                dataGridView1.DataSource = _RemotingWrapper.RemoteObj.GetServicesList(string.Empty);
                this.btnPing.Image = global::TestServicePerformance.Properties.Resources.Ball__Green_;
                tabControl2.TabIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ControllerTest.Storage.Load();
            txtObjectUri.Text = ControllerTest.Storage.StorageObject.ObjectUri;
            txtServer.Text = ControllerTest.Storage.StorageObject.Server;
            txtPort.Text = ControllerTest.Storage.StorageObject.Port;
            txtSvc.Text = ControllerTest.Storage.StorageObject.Svc;
            txtXmlRequest.Text = ControllerTest.Storage.StorageObject.XmlRequest;
            txtSvc.Text = ControllerTest.Storage.StorageObject.SelectedServiceConfiguration.Name;
            numericThread.Value = Convert.ToDecimal(ControllerTest.Storage.StorageObject.Threads);
            numericCallsNumber.Value = Convert.ToDecimal(ControllerTest.Storage.StorageObject.Calls);

            txtURL.Text = string.Concat("tcp://", ControllerTest.Storage.StorageObject.Server, ":", ControllerTest.Storage.StorageObject.Port.Trim(), @"/", ControllerTest.Storage.StorageObject.ObjectUri);
            if (ControllerTest.Storage.StorageObject.SelectedServiceConfiguration.Request != null)
            {
                Fwk.Bases.IServiceContract isvcReq = (Fwk.Bases.IServiceContract)Fwk.HelperFunctions.ReflectionFunctions.CreateInstance(ControllerTest.Storage.StorageObject.SelectedServiceConfiguration.Request);
                this.txtXmlRequest.Text = isvcReq.GetBusinessDataXml();
            }
        }

        private void frmTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            ControllerTest.Storage.StorageObject.ObjectUri = txtObjectUri.Text;
            ControllerTest.Storage.StorageObject.Server = txtServer.Text;
            ControllerTest.Storage.StorageObject.Port = txtPort.Text;
            ControllerTest.Storage.StorageObject.Svc = txtSvc.Text;
            ControllerTest.Storage.StorageObject.XmlRequest = txtXmlRequest.Text;
            ControllerTest.Storage.StorageObject.Threads = (int)numericThread.Value;
            ControllerTest.Storage.StorageObject.Calls = (int)numericCallsNumber.Value;

            ControllerTest.Storage.StorageObject.SelectedServiceConfiguration.Name = txtSvc.Text;
            ControllerTest.Storage.Save();
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (frmAssemblyExplorer f = new frmAssemblyExplorer())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    txtSvc.Text = f.SelectedServiceConfiguration.Name;
                    ControllerTest.Storage.StorageObject.SelectedServiceConfiguration = f.SelectedServiceConfiguration;
                    ControllerTest.Storage.Save();
                    Fwk.Bases.IServiceContract isvcReq = (Fwk.Bases.IServiceContract)Fwk.HelperFunctions.ReflectionFunctions.CreateInstance(ControllerTest.Storage.StorageObject.SelectedServiceConfiguration.Request);
                    this.txtXmlRequest.Text = isvcReq.GetBusinessDataXml();
                }
            }

    

        }

        private void numericThread_ValueChanged(object sender, EventArgs e)
        {
            ControllerTest.Storage.StorageObject.Threads = (int)numericThread.Value;
        }

        private void numericCallsNumber_ValueChanged(object sender, EventArgs e)
        {
            ControllerTest.Storage.StorageObject.Calls = (int)numericCallsNumber.Value;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            progressBar1.Maximum = 101;
            progressBar1.Value = 0;
            for (int i = 0; i <= 100; i++)
            {

                progressBar1.Value++;
                System.Threading.Thread.Sleep(369);
            }
        }

        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            txtURL.Text = string.Concat("tcp://", txtServer.Text, ":", txtPort.Text.Trim(), @"/", txtObjectUri.Text);

        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {
            txtURL.Text = string.Concat("tcp://", txtServer.Text, ":", txtPort.Text.Trim(), @"/", txtObjectUri.Text);
        }

        private void txtObjectUri_TextChanged(object sender, EventArgs e)
        {
            txtURL.Text = string.Concat("tcp://", txtServer.Text, ":", txtPort.Text.Trim(), @"/", txtObjectUri.Text);
        }

        public decimal GetSizeOfObject(object obj)
        {
            long lSize = 0;



            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            BinaryFormatter objFormatter = new BinaryFormatter();
            objFormatter.Serialize(stream, obj);
            lSize = stream.Length;



            return (decimal)lSize;
        }

        #region populate async 
        void PopulateAsync()
        {
            Exception ex = null;
            DelegateWithOutAndRefParameters s = new DelegateWithOutAndRefParameters(Populate);
            s.BeginInvoke(out ex, new AsyncCallback(EndPopulate), null);
        }

        void EndPopulate(IAsyncResult res)
        {
            Exception ex;
            if (this.InvokeRequired)
            {
                AsyncCallback d = new AsyncCallback(EndPopulate);
                this.Invoke(d, new object[] { res });
            }
            else
            {
                AsyncResult result = (AsyncResult)res;
                DelegateWithOutAndRefParameters del = (DelegateWithOutAndRefParameters)result.AsyncDelegate;
                del.EndInvoke(out ex, res);

                if (_SearchSalesOrderDetailRes.Error != null)
                {
                    txtSimpleResult.Text = _SearchSalesOrderDetailRes.Error.GetXml();
                    return;
                }
                dataGridView2.DataSource = _SearchSalesOrderDetailRes.BusinessData.Times;

                _Sizes = new Measures();
                _Sizes.Add(new Measure("Result", GetSizeOfObject(_SearchSalesOrderDetailRes), false));
                _Sizes.Add(new Measure("Entity SalesOrderDetailList", GetSizeOfObject(_SearchSalesOrderDetailRes.BusinessData.SalesOrderDetailList), false));
                _Sizes.Add(new Measure("Test measures", GetSizeOfObject(_SearchSalesOrderDetailRes.BusinessData.Times), false));
                _Sizes.Add(new Measure("Result contextInformation", GetSizeOfObject(_SearchSalesOrderDetailRes.ContextInformation), false));

                dataGridView3.DataSource = _Sizes;

                string info = Fwk.HelperFunctions.SerializationFunctions.SerializeToXml(_SearchSalesOrderDetailRes.ContextInformation);
                txtSimpleResult.Text = string.Concat(info,Environment.NewLine,Environment.NewLine + "Bussiness data ",Environment.NewLine, _SearchSalesOrderDetailRes.BusinessData.SalesOrderDetailList.GetXml());

            }

        }

        void Populate(out Exception ex)
        {

            ex = null;
            _SearchSalesOrderDetailRes = ControllerTest.SearchSalesOrderDetailRes();

        }
        #endregion

        private void btnSaveResult_Click(object sender, EventArgs e)
        {
            if (_SearchSalesOrderDetailRes == null) return;

            if(!Directory.Exists("Logs"))
            {
                Directory.CreateDirectory("Logs");
            }
            TestRes wTestRes = new TestRes();
            wTestRes.Times = _SearchSalesOrderDetailRes.BusinessData.Times;
            wTestRes.Sizes = _Sizes;
            string name =string.Concat(@"Logs\R_",DateFunctions.Get_Year_Mont_Day_Hour_Min_Sec_String(_SearchSalesOrderDetailRes.ContextInformation.HostTime, '_'),".xml");

           

            Fwk.HelperFunctions.FileFunctions.SaveTextFile(name, wTestRes.GetXml(), false);

            MessageBox.Show("Test saved successfully");
        }
  

        private void btn_InitConfigFile_Click(object sender, EventArgs e)
        {
            this.btn_InitConfigFile.Image = global::TestServicePerformance.Properties.Resources.Ball__Red_;
            if (_RemotingWrapper_config == null)
                _RemotingWrapper_config = new RemotingWrapper_config();
            try
            {
                _RemotingWrapper_config.Init();
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                dataGridView1.DataSource = _RemotingWrapper_config.RemoteObj.GetServicesList(string.Empty);
                this.btn_InitConfigFile.Image = global::TestServicePerformance.Properties.Resources.Ball__Green_;
                tabControl2.TabIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _RemotingWrapper_config = null;
            }

        }

        private void btnStartSimpleTest_Click_1(object sender, EventArgs e)
        {
            PopulateAsync();
        }

        bool ValidateInit()
        {
            if (string.IsNullOrEmpty(txtPort.Text))
            {
                errorProvider1.SetError(txtPort, "No puede faltar este valor");
                txtPort.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtObjectUri.Text))
            {
                errorProvider1.SetError(txtObjectUri, "No puede faltar este valor");
                txtObjectUri.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtServer.Text))
            {
                errorProvider1.SetError(txtServer, "No puede faltar este valor");
                txtServer.Focus();
                return false;
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SearchSalesOrderDetailRes res = ControllerTest.SearchSalesOrderDetailRes();
                
                if (res.Error != null)
                    MessageBox.Show( Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error).Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

    
}
