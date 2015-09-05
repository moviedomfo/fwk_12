using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fwk.CodeGenerator
{
    public partial class MessageViewWait : Form
    {
        

        public string OptionalMessage
        {

            set { lbOptionalMessage .Text = value; }
        }
        
       
        public MessageViewWait()
        {
            InitializeComponent();
        }

       

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}