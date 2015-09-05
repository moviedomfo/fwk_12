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
    public partial class frmEditEncuesta : Form
    {

        public frmEditEncuesta(MenuItemEncuesta pMenuItemEncuesta, Action pAction)
        {
            InitializeComponent();
            menuItemEditorEncuesta1.ShowAction = pAction;
            menuItemEditorEncuesta1.MenuItemSelected = pMenuItemEncuesta;
            menuItemEditorEncuesta1.Populate();
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            menuItemEditorEncuesta1.FillMenuItem();
          
        }

        
    }
}
