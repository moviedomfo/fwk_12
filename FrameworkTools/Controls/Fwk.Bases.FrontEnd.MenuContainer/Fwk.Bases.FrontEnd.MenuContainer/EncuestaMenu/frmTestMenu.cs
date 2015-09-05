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
    public partial class frmTestMenu : Form
    {
        public frmTestMenu(string file)
        {
            InitializeComponent();

            treeListMenuControl1.Populate(file);
        }

        private void treeListMenu1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(treeListMenuControl1.MenuItemSelected.GetXml());
        }

        private void treeListMenuControl1_MenuItemClick(MenuItemEncuesta pMenuItemSelected)
        {

        }

        
        
    }
}
