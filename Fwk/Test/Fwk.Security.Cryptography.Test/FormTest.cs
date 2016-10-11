using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace Fwk.Security.Cryptography.Test
{
    public partial class FormTest : Form
    {
        SymetriCypher<RijndaelManaged> _SymetriCypher = null;
        public FormTest()
        {
            InitializeComponent();
        }

        private void btnKey_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();
       
            //Error
            //SymetriCypher<System.Security.Cryptography.TripleDES> wTripleDES = new SymetriCypher<System.Security.Cryptography.TripleDES>();


            _SymetriCypher = new SymetriCypher<RijndaelManaged>();
             //SymetriCypher<RijndaelManaged> _SymetriCypher = new SymetriCypher<RijndaelManaged>();

            //str.Append(SymetricCypherFactory.GenNewKey());


             str.AppendLine(_SymetriCypher.GeneratetNewK());
           // _SymetriCypher.Encrypt("", "j7Ab7ScPtcoxGTDANnvn3e4VJxqD+dR5bnJO6+hXn78=$HJoNwcu5Riru293Mj2dEXQ==");
            txtKey.Text = str.ToString();

            

        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
      
            //Este = funciona
            //txtCifrado.Text = SymetricCypherFactory.Cypher().Encrypt(txtNoCifrado.Text);

            txtCifrado.Text = _SymetriCypher.Encrypt(txtNoCifrado.Text);
        }

        private void btnDEncrypt_Click(object sender, EventArgs e)
        {
  
            //Usa el encriptador por defecto configurado
            //txtValorOriginal.Text = SymetricCypherFactory.Cypher().Dencrypt(txtCifrado.Text);
            txtValorOriginal.Text = _SymetriCypher.Dencrypt(txtCifrado.Text);
        }
    }
}
