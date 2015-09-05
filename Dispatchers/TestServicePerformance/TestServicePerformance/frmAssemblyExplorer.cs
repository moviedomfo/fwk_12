using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.DirectoryServices;
using System.Collections;
using Fwk.AssemblyExplorer;
using Fwk.Bases;

namespace TestServicePerformance
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmAssemblyExplorer : Fwk.Bases.FrontEnd.FrmBase
    {

        private ServiceConfiguration _SelectedServiceConfiguration = null;

        [Browsable(false)]
        public ServiceConfiguration SelectedServiceConfiguration
        {
            get { return _SelectedServiceConfiguration; }
            set { _SelectedServiceConfiguration = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public frmAssemblyExplorer()
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(ControllerTest.Storage.StorageObject.AssemblyPath))
            {
                
                LoadAssembly();
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog wSchemaDialog = new OpenFileDialog();
            wSchemaDialog.DefaultExt = "dll";
            wSchemaDialog.CheckFileExists = true;

            wSchemaDialog.Filter = "DLL Files (*.dll)|*.dll|All Files (*.*)|*.*";
            wSchemaDialog.ShowReadOnly = true;
           
            

            if (wSchemaDialog.ShowDialog() == DialogResult.OK)
            {
                ControllerTest.Storage.StorageObject.AssemblyPath= wSchemaDialog.FileName;
                ControllerTest.Storage.Save();
                LoadAssembly();
            }
            
           
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (((System.Windows.Forms.ListBox)(sender)).Text != String.Empty)
            {
                _SelectedServiceConfiguration = (ServiceConfiguration)((System.Windows.Forms.ListBox)(sender)).SelectedItem;
               lblServiceName.Text = _SelectedServiceConfiguration.Name;
            }


        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_SelectedServiceConfiguration != null)
                this.DialogResult = DialogResult.OK;
        }

        void LoadAssembly()
        {
           
            try
            {
                if (!System.IO.File.Exists(ControllerTest.Storage.StorageObject.AssemblyPath))
                    return;
                Assembly wAssembly = new Assembly(ControllerTest.Storage.StorageObject.AssemblyPath);
                Fwk.Bases.ServiceConfiguration wServiceConfiguration = null;
                Fwk.Bases.ServiceConfigurationCollection list = new Fwk.Bases.ServiceConfigurationCollection();
                lblFileName.Text = ControllerTest.Storage.StorageObject.AssemblyPath;

                foreach (AssemblyClass wAssemblyClass in wAssembly.ClassCollections)
                {
                    if (wAssemblyClass.BaseType != null)
                    {
                        if (wAssemblyClass.BaseType.Name.Contains("BusinessService"))
                        {
                            wServiceConfiguration = new Fwk.Bases.ServiceConfiguration();
                            //Service name
                            wServiceConfiguration.Name = wAssemblyClass.Name;
                            wServiceConfiguration.Handler = wAssemblyClass.FullyQualifiedName;
                            //Request
                            wServiceConfiguration.Request = wAssemblyClass.Methods[0].Parameters[0].ParameterType.AssemblyQualifiedName;

                            //Response
                            wServiceConfiguration.Response = wAssemblyClass.Methods[0].ReturnType.AssemblyQualifiedName;

                            list.Add(wServiceConfiguration);
                        }
                    }
                }

                serviceConfigurationCollectionBindingSource.DataSource = list.OrderBy (p=> p.Name );
            }
            catch (System.Reflection.ReflectionTypeLoadException rx)
            {
                base.ExceptionViewer.Show(rx.LoaderExceptions, "Service Management:. Loading assembly");
                //ControllerTest.Storage.Clear();
            }
            catch (Exception ex)
            {

                base.ExceptionViewer.Show(ex);
                //ControllerTest.Storage.Clear();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

   
}
