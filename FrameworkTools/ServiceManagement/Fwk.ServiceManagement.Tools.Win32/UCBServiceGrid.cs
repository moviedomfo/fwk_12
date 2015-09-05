using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Fwk.HelperFunctions;
using Fwk.Bases;
namespace Fwk.ServiceManagement.Tools.Win32
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pServiceConfiguration"></param>
    public delegate void OnClickServiceHandler(ServiceConfiguration pServiceConfiguration);
    [DefaultEvent("OnClickServiceHandler")]
    public partial class UCBServiceGrid : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public event OnClickServiceHandler OnClickServiceHandler;
        private ServiceConfigurationCollection _Services = null;
        private ServiceConfiguration _CurrentServiceConfiguration = null;

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public ServiceConfiguration CurentServiceConfiguration
        {
            get { return _CurrentServiceConfiguration; }
            set { _CurrentServiceConfiguration = value; }
        }
        ServiceConfigurationCollection _SelecdedServices;

        public ServiceConfigurationCollection SelecdedServices
        {
            get { return _SelecdedServices; }
     
        }
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public ServiceConfigurationCollection Services
        {

            get
            {
               
                return _Services;      
            }
            set
            {
                    _Services = value;


                     _SelecdedServices = _Services;
                    serviceConfigurationCollectionBindingSource.DataSource = _Services;
                    SetSort();
                
            }
        }
        List<string> _Applications;
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public List<string> Applications
        {

            get
            {

                return _Applications;
            }
            set
            {
                if(value ==null) return;
                _Applications = value;
                _Applications.Add("Any");
                
                cmbApplication.DataSource = _Applications;

                cmbApplication.SelectedIndex = _Applications.Count-1;
            }
        }


        void SetSort()
        {
            DataGridViewColumn newColumn = grdServices.Columns[0];

            //serviceConfigurationCollectionBindingSource.SupportsSorting = true;
            //grdServices.Sort(newColumn, ListSortDirection.Ascending);

        }
        /// <summary>
        /// 
        /// </summary>
        public UCBServiceGrid()
        {
            InitializeComponent();
            InitializeFilterCombo();

            grdServices.Columns[0].Width = 250;
            grdServices.Columns[1].Width = 100;

        }

     



        private void grdServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _CurrentServiceConfiguration = grdServices.GetSelectedEntity<ServiceConfiguration>();

            if (OnClickServiceHandler != null)
                OnClickServiceHandler(_CurrentServiceConfiguration);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pServiceConfiguration"></param>
        internal void Update(ServiceConfiguration pServiceConfiguration)
        {
            //TODO:Ver appname
            //if (_Services.Exists(pServiceConfiguration.Name, string.Empty))
            //{
            //    _Services.Remove(_CurrentServiceConfiguration);

            //    _CurrentServiceConfiguration = pServiceConfiguration;

            //    _Services.Add(_CurrentServiceConfiguration);

         

            //}
            serviceConfigurationCollectionBindingSource.ResetBindings(true);
            Filter();
        }
        internal void RefreshServices()
        {
            
          
            Filter();
        }
        /// <summary>
        /// 
        /// </summary>
        internal void RemoveCurrent()
        {
            //_Services.Remove(_CurrentServiceConfiguration);
            //serviceConfigurationCollectionBindingSource.ResetBindings(true);
            Filter();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pServiceConfiguration"></param>
        internal void Add(ServiceConfiguration pServiceConfiguration)
        {


            //if (_Services.Exists(pServiceConfiguration.Name, string.Empty))
            //{
            //    throw new Fwk.Exceptions.TechnicalException(string.Concat("El servicio " + pServiceConfiguration.Name + " ya existe en la metadata"));
            //}
            _CurrentServiceConfiguration = pServiceConfiguration;
            //_Services.Add(_CurrentServiceConfiguration);
            //serviceConfigurationCollectionBindingSource.ResetBindings(true);
            Filter();
        }


        

        private void cmbFilterIsolationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

            Filter();
        }

        private void cmbFilterTransactionalBehaviour_SelectedIndexChanged(object sender, EventArgs e)
        {
 
            Filter();
        }

        private void cmbApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            Filter();
        }

        #region Filters
        private void toolStripButtonFilter_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            Filter();
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
        bool init = true;
        private void InitializeFilterCombo()
        {





            String wTitle = String.Empty;
            cmbFilterTransactionalBehaviour.Items.Add("Any");
            foreach (string wName in Enum.GetNames(typeof(Fwk.Transaction.TransactionalBehaviour)))
            {
                cmbFilterTransactionalBehaviour.Items.Add(wName);
            }
            cmbFilterIsolationLevel.Items.Add("Any");
            foreach (string wName in Enum.GetNames(typeof(Fwk.Transaction.IsolationLevel)))
            {
                cmbFilterIsolationLevel.Items.Add(wName);
            }


            foreach (string wName in Enum.GetNames(typeof(Common.TipoBusquedaEnum)))
            {
                cmbSearchType.Items.Add(wName);
            }


            cmbSearchType.SelectedIndex = 0;
            cmbFilterTransactionalBehaviour.SelectedIndex = 0;
            cmbFilterIsolationLevel.SelectedIndex = 0;
            init = false;
        }

        private void txtXmlFilePath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                Filter();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
        
        protected void Filter()
        {
            if (init) return;
            ServiceConfiguration wServiceConfiguration = new ServiceConfiguration();
            wServiceConfiguration.Name = txtXmlFilePath.Text;

            if (cmbFilterIsolationLevel.SelectedIndex != 0)
                wServiceConfiguration.IsolationLevel = (Fwk.Transaction.IsolationLevel)Enum.Parse(typeof(Fwk.Transaction.IsolationLevel), cmbFilterIsolationLevel.Text);
            if (cmbFilterTransactionalBehaviour.SelectedIndex != 0)
                wServiceConfiguration.TransactionalBehaviour = (Fwk.Transaction.TransactionalBehaviour)Enum.Parse(typeof(Fwk.Transaction.TransactionalBehaviour), cmbFilterTransactionalBehaviour.Text);
            if (cmbApplication.SelectedIndex != 0)
                wServiceConfiguration.ApplicationId = cmbApplication.Text;


            if (_Services == null) return;
            bool wNotInclude_IsolationLevel = (cmbFilterIsolationLevel.SelectedIndex == 0);
            bool wNotInclude_TransactionalBehaviour = (cmbFilterTransactionalBehaviour.SelectedIndex == 0);
            bool wNotInclude_ApplicationId = (cmbApplication.SelectedIndex == _Applications.Count - 1);
            Common.TipoBusquedaEnum tb = Common.TipoBusquedaEnum.Contains;
            try
            {

                 tb = (Common.TipoBusquedaEnum)Enum.Parse(typeof(Common.TipoBusquedaEnum), cmbSearchType.Text);

            }
            catch (Exception)
            {
 
            }
            IEnumerable<ServiceConfiguration> list = from s in _Services
                                                     where

                                                         (wNotInclude_TransactionalBehaviour || wServiceConfiguration.TransactionalBehaviour == s.TransactionalBehaviour)
                                                         &&
                                                         (wNotInclude_IsolationLevel || wServiceConfiguration.IsolationLevel == s.IsolationLevel)
                                                         &&
                                                            (wNotInclude_ApplicationId || wServiceConfiguration.ApplicationId == s.ApplicationId)
                                                         &&
                                                         (
                                                         (s.Name.StartsWith(wServiceConfiguration.Name, StringComparison.OrdinalIgnoreCase) && Common.TipoBusquedaEnum.Start == tb)
                                                           ||
                                                           (s.Name.EndsWith(wServiceConfiguration.Name, StringComparison.OrdinalIgnoreCase) && Common.TipoBusquedaEnum.Finalize == tb)
                                                           ||
                                                           (s.Name.ToLower().Contains(wServiceConfiguration.Name.ToLower()) && Common.TipoBusquedaEnum.Contains == tb)
                                                           ||
                                                           (s.Name == wServiceConfiguration.Name && Common.TipoBusquedaEnum.Equal == tb)
                                                           ||
                                                           String.IsNullOrEmpty(wServiceConfiguration.Name))
                                                     select s;

             _SelecdedServices = new ServiceConfigurationCollection();

            foreach (ServiceConfiguration s in list)
            {
                _SelecdedServices.Add(s);
            }


            serviceConfigurationCollectionBindingSource.DataSource = _SelecdedServices;
            _CurrentServiceConfiguration = grdServices.GetSelectedEntity<ServiceConfiguration>();
        }
        private void cmbSearchType_Click(object sender, EventArgs e)
        {
            Filter();
        }





        #endregion




    }
}
