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
using Fwk.Configuration.Common;
using Fwk.ConfigData;
namespace ConfigurationApp
{
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pServiceConfiguration"></param>
    public delegate void OnClickServiceHandler(ServiceConfiguration pServiceConfiguration);
    [DefaultEvent("OnClickServiceHandler")]
    public partial class UCBServiceGrid : UserControl
    {
        bool init = true;
        List<fwk_ConfigManager> _ConfigList;

        public List<fwk_ConfigManager> ConfigList
        {
            get { return ConfigList; }
           
        }
        
        private ConfigurationFile _ConfigurationFile = null;
       

        
     
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public Fwk.Configuration.Common.ConfigurationFile ConfigurationFile
        {

            get
            {
                return _ConfigurationFile;
            }
            set
            {

                _ConfigurationFile = value;
                _ConfigList = new List<fwk_ConfigManager>();
                fwk_ConfigManager config = null;
                foreach (Group group in _ConfigurationFile.Groups)
                {
                    foreach (Key k in group.Keys)
                    {
                        config = new fwk_ConfigManager();
                        config.ConfigurationFileName = _ConfigurationFile.FileName;
                        config.group = group.Name;
                        config.key = k.Name;
                        config.value = k.Value.Text;
                        _ConfigList.Add(config);
                    }
                }

                fwkConfigMannagerBindingSource.DataSource = ConfigList;


                //SetSort();

            }
        }
        
    


        //void SetSort()
        //{
        //    DataGridViewColumn newColumn = grdServices.Columns[0];

        //    //serviceConfigurationCollectionBindingSource.SupportsSorting = true;
        //    //grdServices.Sort(newColumn, ListSortDirection.Ascending);

        //}
        /// <summary>
        /// 
        /// </summary>
        public UCBServiceGrid()
        {
            InitializeComponent();
            

            grdServices.Columns[0].Width = 250;
            grdServices.Columns[1].Width = 100;

        }
     
      
        internal void RefreshServices()
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
       
     

        private void txtXmlFilePath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                Filter();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
        
        protected void Filter()
        {
            if (init) return;
    
            if (_ConfigurationFile == null) return;

            IEnumerable<fwk_ConfigManager> list = from s in ConfigList
                                                   where s.key.Contains(txtXmlFilePath.Text) 
                                                     select s;

            fwkConfigMannagerBindingSource.DataSource = list;
        }
        private void cmbSearchType_Click(object sender, EventArgs e)
        {
            Filter();
        }





        #endregion




    }
}
