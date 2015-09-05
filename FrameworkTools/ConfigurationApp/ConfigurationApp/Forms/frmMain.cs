using System;
using System.Windows.Forms;
using ConfigurationApp.Common;
using ConfigurationApp.Forms;
using ConfigurationApp.IsolatedStorage;
using Fwk.ConfigSection;
using System.Reflection;


namespace ConfigurationApp
{
    public partial class frmMain : Form
    {

        #region [Private members]
        private WorkSpace _WorkSpace = new WorkSpace();
        private Storage _Storage = null;
        private SelectedRoot selectedRoot = SelectedRoot.None;
        #endregion

        public frmMain()
        {
            InitializeComponent();

            InitializeDocPanels();
            this.Text = string.Concat(this.Text, " version ", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            //if (m_SelectedRoot == SelectedRoot.ConfigManagerRoot)
            dockPanelConfigManager1.LoadFiles();
        }

        private void InitializeDocPanels()
        {
            _Storage = new Storage();

            dockPanelConfigManager1.Storage = _Storage;

            dockPanelConfigManager1.Panel = this.splitContainer1.Panel2.Controls;
            if (!_WorkSpace.Contains(ConfigurationType.ConfigurationManager))
            {
                dockPanelConfigManager1.Storage = _Storage;
                dockPanelConfigManager1.Enter += new EventHandler(_dockPanelConfigManager_Enter);

                _WorkSpace.Add(dockPanelConfigManager1, ConfigurationType.ConfigurationManager);
            }
        }

        #region Events --> MainMenuStrip

        /// <summary>
        /// Vuelve a cargar todos los archivos tanto de treeview como App client config
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuItemRefreshAllFiles_Click(object sender, EventArgs e)
        {
            RefreshAllFiles();
        }

        private void tsButtonRefreshAll_Click(object sender, EventArgs e)
        {
            dockPanelConfigManager1.SaveIsolatedStorage();

            RefreshAllFiles();
        }

        #endregion
        private void tsButtonConfigManagerShow_Click(object sender, EventArgs e)
        {
            if (!_WorkSpace.Contains(ConfigurationType.ConfigurationManager))
            {
                dockPanelConfigManager1.Storage = _Storage;
                dockPanelConfigManager1.Panel = this.splitContainer1.Panel2.Controls;
                dockPanelConfigManager1.Enter += new EventHandler(_dockPanelConfigManager_Enter);
                _WorkSpace.Add(dockPanelConfigManager1, ConfigurationType.ConfigurationManager);
            }
        }
        void _dockPanelConfigManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            _WorkSpace.Remove(ConfigurationType.ConfigurationManager);
        }
        void _dockPanelAppConfigClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            _WorkSpace.Remove(ConfigurationType.ApplicationConfiuration);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            dockPanelConfigManager1.SaveIsolatedStorage();
        }

        private void btnNewProvider_Click(object sender, EventArgs e)
        {
            using (frmCreateProvider frm = new frmCreateProvider())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    RefreshAllFiles();
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (frmExport1 frm = new frmExport1())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {

                    RefreshAllFiles();
                }
            }

        }


        #region File methods
        //private void SaveAllFiles()
        //{

        //    _dockPanelConfigManager.SaveAllFiles();
        //}
        //private void LoadFile()
        //{


        //    if (m_SelectedRoot == SelectedRoot.ConfigManagerRoot)
        //        _dockPanelConfigManager.LoadFile();
        //}
        //private void SaveFile()
        //{


        //    if (m_SelectedRoot == SelectedRoot.ConfigManagerRoot)
        //        _dockPanelConfigManager.SaveFile();
        //}

        void _dockPanelConfigManager_Enter(object sender, EventArgs e)
        {
            selectedRoot = SelectedRoot.ConfigManagerRoot;
        }

        void _dockPanelAppConfigClient_Enter(object sender, EventArgs e)
        {
            selectedRoot = SelectedRoot.AppConfigRoot;
        }

        private void RefreshAllFiles()
        {
            if (selectedRoot == SelectedRoot.ConfigManagerRoot)
                dockPanelConfigManager1.RefreshAllFiles();
        }
        #endregion

        private void btnExportXmlToBd_Click(object sender, EventArgs e)
        {
            frmExportXmlToBd wFrm = new frmExportXmlToBd();
            wFrm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

      

    }
}