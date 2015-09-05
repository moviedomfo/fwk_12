using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Bases;
using Fwk.Mail;

namespace MailAgentTest
{
    public partial class Form1 : Form
    {
       // MailService wMail = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fwkMailAgent1.Stop();            
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {   // se inicia el servicio de mail, sin solicitar authenticacion
            fwkMailAgent1.Start();            
        }
      
        void wAlert_AlertClick(object sender, DevExpress.XtraBars.Alerter.AlertClickEventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore", Convert.ToString(e.Info.Tag));
        }              
        
        private void btnAuth_Click(object sender, EventArgs e)
        {
            ViewAuthenticationForm();
        }

        private void ViewAuthenticationForm()
        {
            frmAuth wFrm = new frmAuth();
            DialogResult wResult = wFrm.ShowDialog();

            if (wResult == DialogResult.OK)
                fwkMailAgent1.Start(wFrm.User, wFrm.Pass);
        }

        private void fwkMailAgent1_LoginResponse(object sender, LoginEventArgs e)
        {
            ViewAuthenticationForm();
        }

        private void fwkMailAgent1_NewReceivedMail(object sender, NewReceivedMailEventArgs e)
        {
            if (this.InvokeRequired)
            {
                EventHandler<NewReceivedMailEventArgs> d = new EventHandler<NewReceivedMailEventArgs>(fwkMailAgent1_NewReceivedMail);
                this.Invoke(d, new object[] { sender, e });

            }
            else
            {
                listBox1.Items.Add(String.Format("Tiene {0} nuevos mensajes", e.NewMailCount));
            }
        }

        private void fwkMailAgent1_RequireAuthentication(object sender, EventArgs e)
        {
            ViewAuthenticationForm();
        } 
    }
}
