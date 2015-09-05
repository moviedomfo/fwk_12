using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Fwk.UI.Controls;

namespace Fwk.Security.Admin
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
            try
            {
                Application.Run(new frmAdmin());
            }
            catch (Exception wException)
            {
                ExceptionViewComponent wExceptionViewer = new ExceptionViewComponent();
                wExceptionViewer.ButtonsYesNoVisible = DevExpress.XtraBars.BarItemVisibility.Always;
                wExceptionViewer.Title = "Error no manejado";

                wExceptionViewer.Title = string.Concat(wExceptionViewer.Title, " : ", wException.Source);

                DialogResult wResult = wExceptionViewer.Show(wExceptionViewer.Title, wException.Message, Fwk.Exceptions.ExceptionHelper.GetAllMessageException(wException), false);

                if (wResult == DialogResult.OK)
                    Application.Exit();
            }

        }
    }
}
