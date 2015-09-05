using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Bases.FrontEnd.MenuContainer.EncuestaMenu
{
    public delegate void MenuItemClickHandler(MenuItemEncuesta pMenuItemSelected);
    public partial class TreeListMenuControl : UserControl
    {
        #region  Properties & events
        public event MenuItemClickHandler MenuItemClick;
        void OnMenuItemClick()
        {
            if (MenuItemClick != null)
                MenuItemClick(_MenuItemSelected);
        }
        MenuItemEncuesta _MenuItemSelected = null;
        [Browsable(false)]
        public MenuItemEncuesta MenuItemSelected
        {
            get { return _MenuItemSelected; }
            set { _MenuItemSelected = value; }
        }
        MenuItemEncuestaList _MenuItemEncuestaList = null;

        [Browsable(false)]
        public MenuItemEncuestaList MenuItemEncuestaList
        {
            get { return _MenuItemEncuestaList; }
            set { _MenuItemEncuestaList = value; }
        }

        public String DisplayTextCaption
        {
            get { return this.colDisplayName.Caption; }
            set { this.colDisplayName.Caption = value; }
        }
        public String TypeImageCaption
        {
            get { return this.colTypeImage.Caption; }
            set { this.colTypeImage.Caption = value; }
        }

        #endregion
        public TreeListMenuControl()
        {
            InitializeComponent();
        }



        /// <summary>
        /// 
        /// </summary>
        public void Populate(string pFullFileName)
        {
            this.menuItemEncuestaBindingSource.DataSource = _MenuItemEncuestaList = TreeListEngineDevExpress.LoadMenuFromFile(pFullFileName);
            treeList1.ExpandAll();
            treeList1.RefreshDataSource();
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            _MenuItemSelected = (MenuItemEncuesta)treeList1.GetDataRecordByNode(e.Node);
            OnMenuItemClick();
        }
    }
}
