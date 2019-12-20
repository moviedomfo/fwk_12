using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Owin.Security.DataHandler.Encoder;

namespace Fwk.Security.Cryptography.Test
{
    public partial class frmJWT : Form
    {
        public frmJWT()
        {
            InitializeComponent();
        }

        private void btnGenHashedPassword_Click(object sender, EventArgs e)
        {

            var key = new byte[32];
            RNGCryptoServiceProvider.Create().GetBytes(key);
            //System.Security.Cryptography.RSACryptoServiceProvider.Create("PS256");
            //            System.Security.Cryptography.RSACryptoServiceProvider.Create(Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);
            //var base64Secret = TextEncodings.Base64Url.Encode(key);
            //txtAudienseHased.Text = base64Secret;

            txtAudienseHased.Text = TextEncodings.Base64Url.Encode(key);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var symmetricKeyAsBase64 = txtAudienseHased.Text;
            var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);
             
            var signingKey = new Thinktecture.IdentityModel.Tokens.HmacSigningCredentials(keyByteArray);
           
        }
    }
}
