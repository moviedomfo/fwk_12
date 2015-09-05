using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Exceptions;

namespace Fwk.Bases.Test
{
    public partial class frmException : Form
    {
        public frmException()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {



            Fwk.Exceptions.FunctionalException fw = new Fwk.Exceptions.FunctionalException("localFile",null, "RecordSetsNull", "ValidationExceptionMessage", new string[] { "parametro 1", "parametro 2" });

            Fwk.Exceptions.FunctionalException fw2 = new Fwk.Exceptions.FunctionalException(null, "RecordSetsNull", "ValidationExceptionMessage",String.Empty,string.Empty);
            

            MessageBox.Show(fw.Message);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.DataMisalignedException ex = new DataMisalignedException("Erro de prueba");
            ServiceError svcError = Fwk.Exceptions.ExceptionHelper.GetServiceError(ex);

            MessageBox.Show(svcError.GetXml());

            Exception ex2 = Fwk.Exceptions.ExceptionHelper.ProcessException(svcError);
            Exception ex3 = Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
        }
    }
}
