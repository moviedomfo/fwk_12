using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Bases.FrontEnd.MenuContainer.EncuestaMenu
{

    public partial class frmMainDevExpress : Form
    {
        bool _Saved = false;
        MenuItemEncuestaList _MenuItemEncuestaList;
        string _CurrentFullFileName;
        MenuItemEncuesta _MenuItemSelected;
       

        public frmMainDevExpress()
        {
            InitializeComponent();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            _MenuItemEncuestaList = new MenuItemEncuestaList();
            _CurrentFullFileName = Helper.NewFile(_MenuItemEncuestaList);

            LoadMenuFile();
        }

        /// <summary>
        /// 
        /// </summary>
        void LoadMenuFile()
        {

            if (String.IsNullOrEmpty(_CurrentFullFileName)) return;
            try
            {
                this.menuItemEncuestaBindingSource.DataSource = _MenuItemEncuestaList = TreeListEngineDevExpress.LoadMenuFromFile(_CurrentFullFileName);
                treeList1.ExpandAll();
                treeList1.RefreshDataSource();
                lblFileLoad.Text = String.Concat("File ", _CurrentFullFileName);
            }
            catch (InvalidOperationException)
            {
                fwkMessageView_Error.Show("The file not contain correct format to represent any menu .-");
            }
            catch (Exception ex2)
            {
                fwkMessageView_Error.Show(ex2);

            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_CurrentFullFileName)) return;

            TreeListEngineDevExpress.SaveMenuToFile(_CurrentFullFileName, _MenuItemEncuestaList);
            _Saved = true;
            fwkMessageView_Warning.Show("Menu sussefully saved");
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            _CurrentFullFileName = Helper.OpenFile("(*.xml)|*.xml");
            if (String.IsNullOrEmpty(_CurrentFullFileName)) return;

            LoadMenuFile();
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

        }



        /// <summary>
        /// Agrega un  MenuItem de negocio.
        /// </summary>
        /// <date>2008-07-13T00:00:00</date>
        /// <author>moviedo</author>
        private void AddMenuItem()
        {
            MenuItemEncuesta wMenuItemNew = new MenuItemEncuesta();

            if (_MenuItemEncuestaList == null) return;

            if (_MenuItemSelected == null)
            {
                AddCategory();
                return;

            }
            else
            {
                wMenuItemNew.ParentID = _MenuItemSelected.ID;
            }


            using (frmEditEncuesta frm = new frmEditEncuesta(wMenuItemNew, Action.New))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (_MenuItemSelected != null)
                        wMenuItemNew.ID = _MenuItemEncuestaList.Count + 1;
                    _MenuItemEncuestaList.Add(wMenuItemNew);
                    treeList1.RefreshDataSource();
                }
            }

            _Saved = false;
        }

        /// <summary>
        /// Edita un  MenuItem de negocio.
        /// </summary>
        /// <date>2008-07-13T00:00:00</date>
        /// <author>moviedo</author>
        private void EditMenuItem()
        {
            if (_MenuItemEncuestaList == null) return;

            if (_MenuItemSelected == null)
            {
                fwkMessageView_Warning.Show("Please.. select any menu to execute this option.-");
                return;
            }

            using (frmEditEncuesta frm = new frmEditEncuesta(_MenuItemSelected, Action.Edit))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    treeList1.RefreshDataSource();
                }
            }
            _Saved = false;
        }

        private void AddCategory()
        {
            if (_MenuItemEncuestaList == null) return;
            _MenuItemSelected = new MenuItemEncuesta();
            _MenuItemSelected.ParentID = 0;
            _MenuItemSelected.ID = _MenuItemEncuestaList.Count + 1;
            _MenuItemSelected.DisplayName = "Category " + _MenuItemSelected.ID.ToString();
            _MenuItemEncuestaList.Add(_MenuItemSelected);
            treeList1.RefreshDataSource();
            _Saved = false;
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            _MenuItemSelected = (MenuItemEncuesta)treeList1.GetDataRecordByNode(e.Node); 
            
            if (_MenuItemSelected != null)
            {
                if (_MenuItemSelected.ParentID == 0) return;
                menuItemEditorEncuesta1.ShowAction = Action.Query;
                menuItemEditorEncuesta1.MenuItemSelected = _MenuItemSelected;
                menuItemEditorEncuesta1.Populate();
            }
        }


       

        private void frmMainDevExpress_Leave(object sender, EventArgs e)
        {
            if (!_Saved)
                if (fwkMessageView_Warning.Show("Save file " + _CurrentFullFileName) == DialogResult.OK)
                {
                    if (String.IsNullOrEmpty(_CurrentFullFileName)) return;

                    TreeListEngineDevExpress.SaveMenuToFile(_CurrentFullFileName, _MenuItemEncuestaList);
                   
                    fwkMessageView_Warning.Show("Menu sussefully saved");
                }

        }

        private void treeList1_NodeChanged(object sender, DevExpress.XtraTreeList.NodeChangedEventArgs e)
        {

        }

        private void btnAddCategory1_Click(object sender, EventArgs e)
        {
            AddCategory();
        }

        private void btnMenuPreview_Click(object sender, EventArgs e)
        {
            using (frmTestMenu frm = new frmTestMenu(_CurrentFullFileName))
            {
                frm.ShowDialog();
            }
        }



    }
}
