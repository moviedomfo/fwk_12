using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MailAgentTest
{
    public partial class frmAuth : Form
    {

        private String mUser;
        private String mPass;


        public String Pass
        {
            get
            {
                return mPass;
            }
            set
            {
                mPass = value;
            }
        }
        public String User
        {
            get
            {
                return mUser;
            }
            set
            {
                mUser = value;
            }
        }


        public frmAuth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mUser = textBox1.Text;
            mPass = textBox2.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
