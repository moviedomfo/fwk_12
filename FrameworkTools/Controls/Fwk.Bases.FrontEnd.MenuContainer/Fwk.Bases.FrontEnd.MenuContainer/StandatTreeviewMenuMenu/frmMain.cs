using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Fwk.Bases.FrontEnd.MenuContainer
{
    public partial class frmMain : Form
    {

        Boolean m_Saved = true;
        String _CurrentFullFileName;
        RootMenu _RootMenu;
        MenuItem _MenuItemSelected;
        int _TreeViewSelectedNodeIndex = 0;
        public frmMain()
        {
            InitializeComponent();
    
        }

      
      

        private void treeViewDesingner_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeViewDesingner.SelectedNode = e.Node;
            _TreeViewSelectedNodeIndex = treeViewDesingner.SelectedNode.Index;
            _MenuItemSelected = (MenuItem)treeViewDesingner.SelectedNode.Tag;
            this.menuItemEditor1.EntityParam = _MenuItemSelected;
            this.menuItemEditor1.Populate();
           
        }

       

        private void treeViewDesingner_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            this.menuItemEditor1.EntityParam=(MenuItem)e.Node.Tag;
            this.menuItemEditor1.Populate();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddMenuItem();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditMenuItem();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteMenuItem();
        }

    


        #region Tool bar Button

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            _CurrentFullFileName = Helper.OpenFile("(*.xml)|*.xml");
            if (String.IsNullOrEmpty(_CurrentFullFileName)) return;

            LoadMenuFile();
        }
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_CurrentFullFileName)) return;

            TreeViewEngine.SaveMenuToFile(_CurrentFullFileName, _RootMenu);
            m_Saved = true;
            fwkMessageView_Warning.Show("Menu sussefully saved");


        }
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            _RootMenu = new RootMenu();
            _RootMenu.MenuItem.DisplayName = "Root element";
            _CurrentFullFileName = Helper.NewFile(_RootMenu);

            LoadMenuFile();



        }


        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            LoadMenuFile();
        }
        #endregion


        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string str = ((string[])e.Data.GetData(DataFormats.FileDrop, true))[0];
                _CurrentFullFileName = str;
                LoadMenuFile();
            }

        }

        private void frmMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }


        /// <summary>
        /// 
        /// </summary>
        void LoadMenuFile()
        {

            if (String.IsNullOrEmpty(_CurrentFullFileName)) return;
            try
            {

                _RootMenu = TreeViewEngine.LoadMenuFromFile(_CurrentFullFileName);
                TreeViewEngine.Load(this.treeViewDesingner, _RootMenu);
                lblFileLoad.Text = String.Concat("File ", _CurrentFullFileName);
            }
            catch (InvalidOperationException )
            {
                fwkMessageView_Error.Show("The file not contain correct format to represent any menu .-");
            }
            catch (Exception ex2)
            {
                fwkMessageView_Error.Show(ex2);

            }
        }

        /// <summary>
        /// Agrega un  MenuItem de negocio.
        /// </summary>
        /// <date>2008-07-13T00:00:00</date>
        /// <author>moviedo</author>
        private void AddMenuItem()
        {
            if (_MenuItemSelected == null)
            {
                fwkMessageView_Warning.Show("Please.. select any menu to execute this option.-");
                return;
            }

            MenuItem wMenuItemNew = new MenuItem();
            if (frmEdit.ShowNew(ref wMenuItemNew,_RootMenu.MenuImageList) == DialogResult.OK)
            {
                TreeViewEngine.Create(this.treeViewDesingner.SelectedNode, _MenuItemSelected, wMenuItemNew);
            }
            m_Saved = false;
        }

        /// <summary>
        /// Edita un  MenuItem de negocio.
        /// </summary>
        /// <date>2008-07-13T00:00:00</date>
        /// <author>moviedo</author>
        private void EditMenuItem()
        {

            if (_MenuItemSelected == null)
            {
                fwkMessageView_Warning.Show("Please.. select any menu to execute this option.-");
                return;
            }
            MenuItem wServiceClon = _MenuItemSelected;//_MenuItemSelected.Clone();
            if (frmEdit.ShowEdit(_MenuItemSelected,_RootMenu.MenuImageList) == DialogResult.OK)
            {
                TreeViewEngine.Update(this.treeViewDesingner.SelectedNode, _MenuItemSelected);
            }
            m_Saved = false;
        }


        /// <summary>
        /// Elimina un menu item de negocio.
        /// </summary>
        /// <date>2008-07-13T00:00:00</date>
        /// <author>moviedo</author>
        private void DeleteMenuItem()
        {
            if (_MenuItemSelected == null)
            {
                fwkMessageView_Warning.Show("Please.. select any menu to execute this option.-");
                return;
            }
            DialogResult wDialogResult = fwkMessageView_Warning.Show("Confirm remove this item ?" + _MenuItemSelected.DisplayName);

            if (wDialogResult == DialogResult.OK)
            {
                this.treeViewDesingner.SelectedNode.Remove();
                _MenuItemSelected = null;
            }
            m_Saved = false;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!m_Saved)
            {
                if (fwkMessageView_Warning.Show("Save current menu ?") == DialogResult.OK)
                {
                    TreeViewEngine.SaveMenuToFile(_CurrentFullFileName, _RootMenu);
                    m_Saved = true;
                }
            }
        }
    }
}
