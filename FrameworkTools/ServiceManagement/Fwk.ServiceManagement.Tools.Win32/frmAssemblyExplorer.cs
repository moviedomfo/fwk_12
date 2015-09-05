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

namespace Fwk.ServiceManagement.Tools.Win32
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmAssemblyExplorer : Fwk.Bases.FrontEnd.FrmBase
    {
        Fwk.Caching.FwkSimpleStorageBase<Storage>  _StorageFactory = new Fwk.Caching.FwkSimpleStorageBase<Storage>();

        private ServiceConfiguration _SelectedServiceConfiguration = null;

        [Browsable(false)]
        public ServiceConfiguration SelectedServiceConfiguration
        {
            get { return _SelectedServiceConfiguration; }
            set { _SelectedServiceConfiguration = value; }
        }
        ServiceConfigurationCollection Services; 
        /// <summary>
        /// 
        /// </summary>
        public frmAssemblyExplorer()
        {
            InitializeComponent();

           
               Services = Fwk.ServiceManagement.ServiceMetadata.GetAllServices(frmServices.CurrentProvider.Name);
               if (!string.IsNullOrEmpty(_StorageFactory.StorageObject.AssemblyPath))
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
                _StorageFactory.StorageObject.AssemblyPath = wSchemaDialog.FileName;
          
                _StorageFactory.Save();
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
                Assembly wAssembly = new Assembly(_StorageFactory.StorageObject.AssemblyPath);
                Fwk.Bases.ServiceConfiguration s = null;
                Fwk.Bases.ServiceConfigurationCollection list = new Fwk.Bases.ServiceConfigurationCollection();
                lblFileName.Text = _StorageFactory.StorageObject.AssemblyPath;

                foreach (AssemblyClass wAssemblyClass in wAssembly.ClassCollections)
                {
                    if (wAssemblyClass.BaseType != null)
                    {
                        if (wAssemblyClass.BaseType.Name.Contains("BusinessService"))
                        {
                            if (!Services.Exists(p => p.Name.Equals(wAssemblyClass.Name.Trim())))
                            {
                                s = new Fwk.Bases.ServiceConfiguration();
                                //Service name
                                s.Name = wAssemblyClass.Name;
                                s.Handler = wAssemblyClass.FullyQualifiedName;
                                //Request
                                s.Request = wAssemblyClass.Methods[0].Parameters[0].ParameterType.AssemblyQualifiedName;

                                //Response
                                s.Response = wAssemblyClass.Methods[0].ReturnType.AssemblyQualifiedName;

                                list.Add(s);
                            }
                        }
                    }
                }

                var ordenedList = from x in list orderby x.Name select x;
                serviceConfigurationCollectionBindingSource.DataSource = ordenedList;
            }
            catch (System.Reflection.ReflectionTypeLoadException rx)
            {
                base.ExceptionViewer.Show(rx.LoaderExceptions, "Service Management:. Loading assembly");
                _StorageFactory.Clear();
            }
            catch (Exception ex)
            {

                base.ExceptionViewer.Show(ex);
                _StorageFactory.StorageObject.AssemblyPath = string.Empty;
                _StorageFactory.Save();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmAssemblyExplorer_Load(object sender, EventArgs e)
        {
            _StorageFactory.Load();
        }
    }

   
}
