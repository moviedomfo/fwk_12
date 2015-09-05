using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Collections;
using Fwk.AssemblyExplorer;
using Fwk.Bases;
namespace Fwk.Bases.FrontEnd.MenuContainer
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmAssemblyExplorer : Form
    {

        private MenuItem _SelectedForm = null;

        [Browsable(false)]
        public MenuItem SelectedForm
        {
            get { return _SelectedForm; }
            set { _SelectedForm = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public frmAssemblyExplorer()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog wSchemaDialog = new OpenFileDialog();
            wSchemaDialog.DefaultExt = "dll";
            wSchemaDialog.CheckFileExists = true;

            wSchemaDialog.Filter = "DLL Files (*.dll;*.exe)|*.dll;*.exe|All Files (*.*)|*.*";
            wSchemaDialog.ShowReadOnly = true;

            MenuItemList wMenuItemList = new MenuItemList();
            
     
            if (wSchemaDialog.ShowDialog() == DialogResult.OK)
            {
                MenuItem wMenuItem = new MenuItem();
                Assembly ass = new Assembly(wSchemaDialog.FileName);
                lblFileName.Text = wSchemaDialog.FileName;
                foreach (AssemblyClass wAssemblyClass in ass.ClassCollections)
                {
                    if (wAssemblyClass.BaseType != null)
                    {
                        if (wAssemblyClass.BaseType.Name.Contains("Form"))
                        {
                            wMenuItem = new MenuItem();
                            wMenuItem.AssemblyInfo = wAssemblyClass.FullyQualifiedName;
                            wMenuItem.FormName = wAssemblyClass.Name;
                            wMenuItemList.Add(wMenuItem);
                        }
                    }
                }

                listBox1.DataSource = wMenuItemList;
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (((System.Windows.Forms.ListBox)(sender)).Text != String.Empty)
            {
                _SelectedForm = (MenuItem)((System.Windows.Forms.ListBox)(sender)).SelectedItem;
                lblServiceName.Text = _SelectedForm.FormName;
            }


        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_SelectedForm != null)
                this.DialogResult = DialogResult.OK;
        }

        

    }

   
}
