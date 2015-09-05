using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Wizard
{
    /// <summary>
    /// Formulario que permite ingresar parametros basicos para construir 
    /// proyectos de tipo :
    /// 
    /// </summary>
    public partial class frmBackeçEndProjects : Form
    {




        public bool UseStatics
        {
            get { return chkUseStatics.Checked; }
           

        }
  



        public string ProjectName
        {
            get { return txtProjectName.Text; }
            set
            {
                txtProjectName.Text = value;
            }

        }

   
        public frmBackeçEndProjects()
        {
            InitializeComponent();
             
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (VAlidateTextBox())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool VAlidateTextBox()
        {
            if (txtProjectName.Text.Length == 0)
            {
                MessageBox.Show("El nombre del proyecto no puede estar vacio");
                txtProjectName.Focus();
                return false;
            }
            //if (txtApp.Text.Length == 0)
            //{
            //    MessageBox.Show("El nombre de aplicacion no puede estar vacio");
            //    txtApp.Focus();
            //    return false;
            //}
            //if (txtCompanyName.Text.Length == 0)
            //{
            //    MessageBox.Show("El nombre de compania no puede estar vacio");
            //    txtCompanyName.Focus();
            //    return false;
            //}
            return true;
        }

      

     

       

        string Msg()
        {
            StringBuilder str = new StringBuilder ("Ingrese aqui el nombre del proyecto y su modulo ");

            str.AppendLine(Environment.NewLine);
            str.AppendLine("ej: Allus.Meucci.Cliente");
            //str.AppendLine(Environment.NewLine);
            str.AppendLine("ej: Allus.Bigbang.Encuestas");
            //str.AppendLine(Environment.NewLine);
            return str.ToString();
        }

        private void FrmBusinessComponents_Load(object sender, EventArgs e)
        {
            label3.Text = Msg();
        }

       

        private void txtProjectName_TextChanged(object sender, EventArgs e)
        {
            txtBC.Text = string.Concat(txtProjectName.Text, @".Backend.BC");
            txtBE.Text = string.Concat(txtProjectName.Text, @".Common.BE");
            txtDAC.Text = string.Concat(txtProjectName.Text, @".Backend.DAC");
            txtISVC.Text = string.Concat(txtProjectName.Text, @".Common.ISVC");
            txtSVC.Text = string.Concat(txtProjectName.Text, @".Backend.SVC");
        }
    }
}