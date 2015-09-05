using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Fwk.Bases.FrontEnd.MenuContainer.EncuestaMenu;

namespace Fwk.Bases.FrontEnd.MenuContainer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMainDevExpress());
        }
    }
}
