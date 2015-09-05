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
    public partial class frmWizDAC_1 : frmWizBase
    {
        public frmWizDAC_1()
        {
            InitializeComponent();
        }

        public frmWizDAC_1(CnnString cnn)
        {
            InitializeComponent();
            this.Cnn = cnn;
            this.wizDBSelect1.LoadCnn(cnn);
          
        }

        

        private void wizDBSelect1_OnWizardButtonClickEvent(object arg, WizardButton result)
        {
            this.WizardButton = result;
            if (result == WizardButton.Next)
            {
                ///Levanta el segundo wizard
                using (frmWizDAC_2 frm = new frmWizDAC_2(wizDBSelect1.Cnn))
                {
                    //Creo el manejador de para detectar la finalizacion
                    frm.FinalizeWizEvent += new FinalizeWizHandler(frmWizEntity_2_FinalizeWizEvent);
                    frm.ProjectName = this.ProjectName;
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
            this.Cnn = wizDBSelect1.Cnn;
            if (frm.WizardButton == WizardButton.Ok)
            {
                
                this.GenCode = frm.GenCode;
                this.OnFinalizeWiz(this.WizardButton);
            }
            if (pWizardButton == WizardButton.Cancel)
            {
                this.OnFinalizeWiz(this.WizardButton);
            }
            frm.Close();
           
           
        }
    }
}
