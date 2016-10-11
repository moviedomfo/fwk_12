using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ConfigurationApp.Common;
using ConfigurationApp.IsolatedStorage;
using Fwk.Configuration.Common;
using System.Collections.Specialized;
using Fwk.ConfigSection;

namespace ConfigurationApp.Forms
{
    public delegate void DoActionEventHandler(Object sender);
    public partial class dockPanelConfigManager : UserControl
    {
        private Control.ControlCollection _Panel;
        public Control.ControlCollection Panel
        {
            get { return _Panel; }
            set
            {
                if (value == null) return;
                _Panel = value;
                _UCConfigElement = new UCConfigElement();
                _Panel.Clear();
                _UCConfigElement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
                _Panel.Add(_UCConfigElement);
            }

        }
        private event DoActionEventHandler _DoActionEvent;

        private void OnDoActionEvent(Object sender)
        {
            if (_DoActionEvent != null)
                _DoActionEvent(sender);
        }

        public event DoActionEventHandler DoActionEvent
        {
            add
            {
                _DoActionEvent = (DoActionEventHandler)Delegate.Combine(_DoActionEvent, value);

            }
            remove
            {
                _DoActionEvent = (DoActionEventHandler)Delegate.Remove(_DoActionEvent, value);
            }
        }

        #region Private members
        private CnfgManagerSelectedNodeType _CnfgManagerSelectedNodeType = CnfgManagerSelectedNodeType.Root;
        private Storage _Storage = null;






      

        public TreeNode SelectedNode
        {
            get { return treeView1.SelectedNode; }
        }
        internal Storage Storage
        {
            set { _Storage = value; }
        }
        #endregion

        public dockPanelConfigManager()
        {
            InitializeComponent();
        }

        #region Events --> mnCnfgManFile





        /// <summary>
        /// Inserta un nuevo grupo en el archivo y el xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuItemNewGroup_Click(object sender, EventArgs e)
        {
            if (_CnfgManagerSelectedNodeType == CnfgManagerSelectedNodeType.File)
            {
                frmNewGroup f = new frmNewGroup();
                f.ShowDialog();

                if (f.GroupName.Length != 0)
                {
                    ConfigManagerControl.AddGroup(treeView1.SelectedNode, f.GroupName, mnGroupAndKey);
                }
            }

        }
        #endregion


        #region Events --> mnGroupAndKey

        /// <summary>
        /// Inserta una nueva clave de configuracion a algun grupo/archivo determinado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuItemNewKey_Click(object sender, EventArgs e)
        {
            if (_CnfgManagerSelectedNodeType == CnfgManagerSelectedNodeType.Group)
            {

                frmNewKey f = new frmNewKey();
                f.GroupName = treeView1.SelectedNode.Text;
                f.FileName = treeView1.SelectedNode.Parent.Text;
                
                f.ShowDialog();

                if (f.KeyName.Length != 0)
                {
                    ConfigManagerControl.AddKey(treeView1.SelectedNode.Parent, treeView1.SelectedNode, f.KeyName, f.KeyValue,f.Crypted, mnGroupAndKey);
                }
            }
        }

        /// <summary>
        /// Elimina una clave o grupo de configuracion dependiendo del nodo seleccionado
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuItemRemoveGrOrKey_Click(object sender, EventArgs e)
        {
            TreeNode wSel = treeView1.SelectedNode;
            switch (_CnfgManagerSelectedNodeType)
            {
                case CnfgManagerSelectedNodeType.Key:
                    {
                        ConfigManagerControl.RemoveKey(wSel.Parent.Parent, wSel.Parent.Text, wSel.Text);

                        break;
                    }
                case CnfgManagerSelectedNodeType.Group:
                    {
                        ConfigManagerControl.RemoveGroup(wSel.Parent, wSel.Text);
                        break;
                    }

            }
            wSel.Remove();
            treeView1.Refresh();
        }

        #endregion

        #region File Methods



        /// <summary>
        /// Vuelve a cargar todo
        /// </summary>
        public void RefreshAllFiles()
        {
            _CnfgManagerSelectedNodeType = CnfgManagerSelectedNodeType.Root;
            treeView1.BeginUpdate();

            treeView1.Nodes[0].Nodes.Clear();


            ConfigManagerControl.RefreshAllFiles(treeView1.Nodes[0], mnCnfgManFile, mnCnfgManFile_Fail, mnGroupAndKey, _Storage);
            treeView1.EndUpdate();
            treeView1.Refresh();
            treeView1.ExpandAll();


        }

        /// <summary>
        /// Carga todo
        /// </summary>
        /// <param name="pClear">Elimina todos los nodos existentes en el tre view</param>
        public void LoadFiles()
        {
            _CnfgManagerSelectedNodeType = CnfgManagerSelectedNodeType.Root;
            treeView1.BeginUpdate();


            ConfigManagerControl.LoadFiles(treeView1.Nodes[0], mnCnfgManFile, mnCnfgManFile_Fail, mnGroupAndKey, _Storage);
            treeView1.EndUpdate();
            treeView1.Refresh();
            treeView1.ExpandAll();


        }
        public void QuitFile()
        {

        }
        #endregion

        #region [Keys & Settings]
        private void CnfgManagerApplyChanges(TreeNode ptreeNode)
        {


            switch (_CnfgManagerSelectedNodeType)
            {
                case CnfgManagerSelectedNodeType.Key:
                    {
                        Key updatedK = (Key)_UCConfigElement.Get();
                        Key currentK = ((Key)ptreeNode.Tag);

                        if (!currentK.Name.Equals(updatedK.Name, StringComparison.OrdinalIgnoreCase)
                            || !currentK.Value.Text.Equals(updatedK.Value.Text, StringComparison.OrdinalIgnoreCase)
                            || currentK.Encrypted != updatedK.Encrypted
                            )
                        {
                            ConfigManagerControl.ChangeKey(ptreeNode, updatedK);
                        }
                        break;
                    }
                case CnfgManagerSelectedNodeType.Group:
                    {
                        Group updatedK = (Group)_UCConfigElement.Get();
                        Group currentK = ((Group)ptreeNode.Tag);
                        if (!currentK.Name.Equals(updatedK.Name))
                            ConfigManagerControl.ChangeGroupName(ptreeNode, updatedK);
                        break;
                    }
            }
        }




        #endregion


        UCConfigElement _UCConfigElement = new UCConfigElement();

        private void DoConfigManager(TreeNode pTreeNodeSelected)
        {
            Group wGroup;
            ListDictionary dic;

            switch (_CnfgManagerSelectedNodeType)
            {
                case CnfgManagerSelectedNodeType.Key:
                    {
                        Key wKey = (Key)pTreeNodeSelected.Tag;

                        dic = (ListDictionary)pTreeNodeSelected.Parent.Parent.Tag;
                        ConfigurationFile wConfigurationFile = (ConfigurationFile)dic["ConfigurationFile"];

                        wGroup = (Group)pTreeNodeSelected.Parent.Tag;

                        _UCConfigElement.Populate(wKey, wConfigurationFile.FileName, wGroup.Name);

                        break;
                    }
                case CnfgManagerSelectedNodeType.Group:
                    {
                        dic = (ListDictionary)pTreeNodeSelected.Parent.Tag;
                        ConfigurationFile wConfigurationFile = (ConfigurationFile)dic["ConfigurationFile"];
                        _UCConfigElement.Populate((Group)pTreeNodeSelected.Tag, wConfigurationFile.FileName);

                        break;
                    }
                case CnfgManagerSelectedNodeType.File:
                    {
                        if (pTreeNodeSelected.Parent.Index == 1)
                        {
                            _UCConfigElement.Populate(pTreeNodeSelected.Text);


                        }

                        break;
                    }
                case CnfgManagerSelectedNodeType.Root:
                    {

                        break;
                    }
            }
            OnDoActionEvent(this);
        }


        private TreeNode GetTreeNodeFile()
        {
            TreeNode wTreeNodeFile = null;

            switch (_CnfgManagerSelectedNodeType)
            {
                case CnfgManagerSelectedNodeType.File:
                    {
                        wTreeNodeFile = treeView1.SelectedNode;
                        break;
                    }
                case CnfgManagerSelectedNodeType.Group:
                    {
                        wTreeNodeFile = treeView1.SelectedNode.Parent;
                        break;
                    }
                case CnfgManagerSelectedNodeType.Key:
                    {
                        wTreeNodeFile = treeView1.SelectedNode.Parent.Parent;
                        break;
                    }
            }


            return wTreeNodeFile;
        }


        #region Envents --> treeView
        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {

            //string node = e.Node.Text; ---> Node que se acaba de seleccionar
            //string sel = treeView1.SelectedNode.Text; ---> Nodo seleccionado

            //return;
            if (treeView1.SelectedNode != null)
                CnfgManagerApplyChanges(treeView1.SelectedNode);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string node = e.Node.Text;
            //string sel = treeView1.SelectedNode.Text;
            //return;
            if (e.Node == null) return;


            // Determino que es lo que esta seleccionado 
            _CnfgManagerSelectedNodeType = (CnfgManagerSelectedNodeType)Enum.Parse(typeof(CnfgManagerSelectedNodeType), e.Node.Level.ToString());

            DoConfigManager(treeView1.SelectedNode);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;

            if (_CnfgManagerSelectedNodeType == CnfgManagerSelectedNodeType.Key)
            {

                tsMenuItemNewKey.Visible = false;
            }
            else
            {
                tsMenuItemNewKey.Visible = true;
            }
        }
        #endregion

        #region Events --> mnConfigManagerRoot



        private void tsMenuItemRefreshAllFiles_Click(object sender, EventArgs e)
        {
            RefreshAllFiles();
        }
        #endregion



        /// <summary>
        /// Almaceno la informacion de las rutas a los archivos cargados en el tree view en un 
        /// isolated storage
        /// </summary>
        internal void SaveIsolatedStorage()
        {
            ConfigManagerControl.SaveIsolatedStorage(treeView1.Nodes[0], _Storage);
        }



        private void exploreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode wTreeNodeFile = GetTreeNodeFile();
            System.Diagnostics.Process.Start("IExplore", wTreeNodeFile.ToolTipText);

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TreeNode nodeFile = GetTreeNodeFile();
            ListDictionary wDictionary = (ListDictionary)nodeFile.Tag;

            //try
            //{

            //    ConfigProviderSection config = (ConfigProviderSection)configuration.Sections["FwkConfigProvider"];
            //    config.Providers.re(newProvider);

            //    configuration.Save(ConfigurationSaveMode.Minimal, true);

            //    Fwk.Configuration.ConfigurationManager.ConfigProvider.Providers.re(newProvider);
            //}
            //catch (Exception ex)
            //{
            //    this.ExceptionViewer.Show(ex);
            //}


            // RefreshAllFiles();

        }

        private void tsMenuItemQuitFile_Click(object sender, EventArgs e)
        {
            ConfigManagerControl.QuitFile(GetTreeNodeFile());
            RefreshAllFiles();
        }

        private void tsMenuItemRefreshFile_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);


            if (files.Length != 0)
                using (frmCreateProvider frm = new frmCreateProvider(files[0]))
                {

                    if (frm.ShowDialog() == DialogResult.OK)
                        RefreshAllFiles();
                }

        }

        private void exportToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_CnfgManagerSelectedNodeType == CnfgManagerSelectedNodeType.File)
            {
               
                TreeNode wTreeNodeFile = GetTreeNodeFile();
                frmExport1 f = new frmExport1((System.Collections.Specialized.ListDictionary)wTreeNodeFile.Tag);
                f.ShowDialog();
            }
        }

        private void viewInsertScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_CnfgManagerSelectedNodeType == CnfgManagerSelectedNodeType.File)
            {

                TreeNode wTreeNodeFile = GetTreeNodeFile();
                ConfigurationApp.Export.frmViewInsertScript f = new ConfigurationApp.Export.frmViewInsertScript((System.Collections.Specialized.ListDictionary)wTreeNodeFile.Tag);
                f.ShowDialog();
            }
        }


    }
}