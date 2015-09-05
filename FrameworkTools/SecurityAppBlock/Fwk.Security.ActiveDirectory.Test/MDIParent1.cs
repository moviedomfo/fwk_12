using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Security.ActiveDirectory.Test
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            OpenForm(new frmTestLogin());
            
        }


       

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        void OpenForm(Form form)
        {

            form.MdiParent = this;
            form.Text = "Window " + childFormNumber++;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

       

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            OpenForm( new frmTestGroups());
            
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenForm(new frmTestLDAPconnections());
        }
    }
}
