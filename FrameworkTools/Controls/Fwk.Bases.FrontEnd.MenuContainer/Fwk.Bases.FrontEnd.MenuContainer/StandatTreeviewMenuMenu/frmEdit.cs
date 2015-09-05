using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Bases.FrontEnd.MenuContainer
{
    public partial class frmEdit : Form
    {
        private static MenuImageList m_MenuImageList;
        public frmEdit()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            menuItemEditor1.FillMenuItem();
   
        }


        /// <summary>
        /// Muestra el formulario configurado para editar un MenuItem .
        /// </summary>
        /// <param name="MenuItem"><see cref="MenuItem"/></param>
        /// <returns>DialogResult</returns>
        /// <date>2007-07-13T00:00:00</date>
        /// <author>moviedo</author>
        internal static DialogResult ShowNew(ref MenuItem pMenuItem, MenuImageList pMenuImageList)
        {
            SetMenuImageList(pMenuImageList);
            using (frmEdit wfrmEdit = new frmEdit())
            {
                wfrmEdit.menuItemEditor1.MenuImageList = pMenuImageList;
                wfrmEdit.menuItemEditor1.ShowAction = Action.New;
                wfrmEdit.menuItemEditor1.EntityParam = pMenuItem;
                wfrmEdit.menuItemEditor1.Populate();
                wfrmEdit.Text = wfrmEdit.menuItemEditor1.Text;
                wfrmEdit.ShowDialog();
                pMenuItem = (MenuItem)wfrmEdit.menuItemEditor1.EntityResult;
                return wfrmEdit.DialogResult;
            }
        }

        /// <summary>
        /// Muestra el formulario configurado para editar un MenuItem .
        /// </summary>
        /// <param name="MenuItem">MenuItem</param>
        /// <date>2007-07-13T00:00:00</date>
        /// <author>moviedo</author>
        internal static DialogResult ShowEdit(MenuItem pMenuItem, MenuImageList pMenuImageList)
        {
            SetMenuImageList(pMenuImageList);
            using (frmEdit wfrmEdit = new frmEdit())
            {
                wfrmEdit.menuItemEditor1.MenuImageList = pMenuImageList;
                wfrmEdit.menuItemEditor1.ShowAction = Action.Edit;
                wfrmEdit.menuItemEditor1.EntityParam = pMenuItem;
                wfrmEdit.menuItemEditor1.Populate();
                wfrmEdit.Text = wfrmEdit.menuItemEditor1.Text;
                wfrmEdit.ShowDialog();

                return wfrmEdit.DialogResult;
            }
        }

        static void SetMenuImageList(MenuImageList pMenuImageList)
        {
            if(m_MenuImageList == null)
                m_MenuImageList = pMenuImageList;
        }
    }
}
