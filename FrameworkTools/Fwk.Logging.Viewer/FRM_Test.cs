using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Configuration;
using Fwk.Logging;

namespace Fwk.Logging.Viewer
{
    public partial class FRM_Test : Form
    {
        public FRM_Test()
        {
            InitializeComponent();
        }

        private void btnGetLoggingConfiguration_Click(object sender, EventArgs e)
        {
            Logger wLogger = new Logger();
           
          
            MessageBox.Show("Archivo Log generado correctamente.");
            wLogger.Error("FRM_Main.btnGettLoggingConfiguration", "Este es un texto de prueba.");
            MessageBox.Show("Archivo Xml generado correctamente.");
            wLogger.Information("FRM_Main.btnGettLoggingConfiguration", "Este es un texto de prueba.");
            MessageBox.Show("Evento de Windows generado correctamente.");
            wLogger.Warning("FRM_Main.btnGettLoggingConfiguration", "Este es un texto de prueba.");
            MessageBox.Show("Log en base de datos generado correctamente.");
        }
    }
}