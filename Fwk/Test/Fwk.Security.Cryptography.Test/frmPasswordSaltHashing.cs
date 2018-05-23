using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Fwk.Security.Cryptography.Test
{
    public partial class frmPasswordSaltHashing : Form
    {
       
        public frmPasswordSaltHashing()
        {
            InitializeComponent();


        }
        
        private void frmPasswordSaltHashing_Load(object sender, EventArgs e)
        {
            txtGeneratedSalt.Text = GenerateSalt();
        }
       

        public static void GenerateSaltedHas(string password, out string hash, out string salt)
        {
            var salt_byte = new byte[64];
            var provider = new RNGCryptoServiceProvider();
             provider.GetNonZeroBytes(salt_byte);
             salt = Convert.ToBase64String(salt_byte);
             var rfc2898DerivedBytes = new Rfc2898DeriveBytes(password, salt_byte,10000);
             hash = Convert.ToBase64String(rfc2898DerivedBytes.GetBytes(256));
        }

        public static string GenerateHas(string password, string storedSalt)
        {
             
           

            var salt_bytes = Convert.FromBase64String(storedSalt);

            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(salt_bytes);

            var rfc2898DerivedBytes = new Rfc2898DeriveBytes(password, salt_bytes, 10000);
            string hash = Convert.ToBase64String(rfc2898DerivedBytes.GetBytes(256));

            return hash;
        }
        public static string GetHash(string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();

            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(input);

            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);
            
            return Convert.ToBase64String(byteHash);
        }

        public static string  GenerateSalt()
        {
            var salt_byte = new byte[64];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(salt_byte);
           string  salt = Convert.ToBase64String(salt_byte);

            return salt;
        }


        public static bool Verify(string password, string storedHash, string storedSalt)
        {
            var hash = GetHash(password);
            return hash == storedHash;
        }


        

        private void btnGenHashedPassword_Click(object sender, EventArgs e)
        {
           
            txtPasswordHased.Text = GenerateHas(txtPassword.Text, txtGeneratedSalt.Text);

            txtPasswordHased.Text = GetHash(txtPassword.Text); 
          // txtGeneratedSalt.Text = salt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Verify(txtPassword.Text, txtPasswordHased.Text,txtGeneratedSalt.Text))
            {
                MessageBox.Show("Password is valid");
            }
            else
            { MessageBox.Show("Password is NOT valid"); }
        }
   
        

        
    }
    
}
