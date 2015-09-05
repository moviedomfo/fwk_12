using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.CodeGenerator;


namespace Fwk.Wizard
{
    public partial class frmWizEntity_1 : frmWizBase
    {

        public frmWizEntity_1(CnnString cnn)
        {
            this.Cnn = cnn;
            InitializeComponent();

            this.wizDBSelect1.LoadCnn(cnn);
        }
        public frmWizEntity_1()
        {
            InitializeComponent();

            
        }


        private void wizDBSelect1_OnWizardButtonClickEvent(object arg, WizardButton result)
        {
            this.WizardButton = result;
            if (result == WizardButton.Next)
            { 
                ///Levanta el segundo wizard
                using(frmWizEntity_2 frm = new frmWizEntity_2 (wizDBSelect1.Cnn))
                {
                    frm.ProjectName = this.ProjectName;
                    //Creo el manejador de para detectar la finalizacion
                    frm.FinalizeWizEvent += new FinalizeWizHandler(frmWizEntity_2_FinalizeWizEvent);

                    frm.ShowDialog();
                    
                }
                
                return;
            }

            if (result == WizardButton.Cancel)
            {
                this.OnFinalizeWiz(WizardButton.Cancel);
            }

           
        }

        void frmWizEntity_2_FinalizeWizEvent(frmWizBase frm, WizardButton pWizardButton)
        {
            this.WizardButton = pWizardButton;
            this.Cnn = this.wizDBSelect1.Cnn;
            if (frm.WizardButton == WizardButton.Ok)
            {
                this.GenCode = frm.GenCode;
                this.OnFinalizeWiz(WizardButton.Ok);
            }
            if (pWizardButton == WizardButton.Cancel)
            {
                this.OnFinalizeWiz(this.WizardButton);
            }

            frm.Close();
        }

       
       
    }
}