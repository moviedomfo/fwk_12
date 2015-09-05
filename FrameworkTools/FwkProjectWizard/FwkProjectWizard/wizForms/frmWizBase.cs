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
    public delegate void FinalizeWizHandler(frmWizBase frm,WizardButton pWizardButton);
  
    public partial class frmWizBase : Form
    {
        CnnString cnn;

        public CnnString Cnn
        {
            get { return cnn; }
            set { cnn = value; }
        }
        public event FinalizeWizHandler FinalizeWizEvent;

        protected void OnFinalizeWiz(WizardButton pWizardButton)
        {
            if(this.FinalizeWizEvent!= null)
                FinalizeWizEvent(this,pWizardButton);
        }
        WizardButton _WizardButton;
        
        public WizardButton WizardButton
        {
            get { return _WizardButton; }
            set { _WizardButton = value; }
        }
       string projectName;

        public virtual string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }
         Dictionary<string,string> genCode;

        public Dictionary<string,string> GenCode
        {
            get { return genCode; }
            set { genCode = value; }
        }
        public frmWizBase()
        {
            InitializeComponent();
        }
    }
}
