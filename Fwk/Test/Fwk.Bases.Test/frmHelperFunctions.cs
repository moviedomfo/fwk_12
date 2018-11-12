using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Bases.Test
{
    public partial class frmHelperFunctions : Form
    {
        public frmHelperFunctions()
        {
            InitializeComponent();
        }

       
        private void btnFormatFunctions_Click(object sender, EventArgs e)
        {
            var clienteList = Controller.SearchCleintes();

            StringBuilder ids = Fwk.HelperFunctions.FormatFunctions.GetStringBuilderWhitSeparator<ClienteBE>(clienteList, ',', "IdCliente");
            txtResult1.Text = clienteList.GetXml();
            txtResult2.Text = ids.ToString();
        }

        private void btnGet_logonserver_Click(object sender, EventArgs e)
        {
            MessageBox.Show(System.Environment.GetEnvironmentVariable("logonserver"));
            string file = @"%logonserver%\netlogon\aplicaciones\Navegadores\GoogleChromePortablenew\";
            file = file.Replace("%logonserver%", System.Environment.GetEnvironmentVariable("logonserver"));
            if (System.IO.Directory.Exists(file))
                MessageBox.Show("Existe");
            else
                MessageBox.Show("no Existe");
        }

       
    }
}
