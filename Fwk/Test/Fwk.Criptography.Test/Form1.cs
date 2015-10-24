using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.Cryptography;

namespace Fwk.Cryptography.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            txtOut.Text = SymetricCypherFactory.Cypher().Encrypt(txtIn.Text);
        }

        private void txtOut_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            txtDecryptedText.Text = SymetricCypherFactory.Cypher().Dencrypt(txtOut.Text);
        }
    }
}
