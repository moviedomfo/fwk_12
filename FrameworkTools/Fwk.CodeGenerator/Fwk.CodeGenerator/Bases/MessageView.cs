using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fwk.CodeGenerator
{
    public partial class MessageView : Form
    {


        public string Message
        {

            set { txtMessage.Text = value; }
        }

        public  bool btnOkVisible
        {
            set {
                btnOk.Visible = value;
                
            }
        }
       
        public MessageView()
        {
            InitializeComponent();
        }

       

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}