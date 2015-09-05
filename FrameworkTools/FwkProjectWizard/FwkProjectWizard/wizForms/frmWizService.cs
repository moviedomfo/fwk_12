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
    public partial class frmWizService :  frmWizBase
    {

        public string Svc
        {
            get { return ctrlNewService1.Svc; }
         
        }
        

        public string Req
        {
            get { return ctrlNewService1.Req; }
        
        }
      

        public string Res
        {
            get { return ctrlNewService1.Res; }
        
        }
        public string ServiceName
        {
            get { return ctrlNewService1.ServiceName; }
            set {  ctrlNewService1.ServiceName = value; }
        }

        public string SvcCode
        {
            get { return ctrlNewService1.SvcCode; }
            
        }

        public override string ProjectName
        {
            get
            {
                return ctrlNewService1.ProjectName;
            }
            set
            {
                ctrlNewService1.ProjectName = value;
            }
        }
        public string IsvcCode
        {
            get { return ctrlNewService1.IsvcCode; }
            
        }
        
       
        public  string ProjectSvcName
        {
            get { return ctrlNewService1.ProjectSvcName; }
            set { ctrlNewService1.ProjectSvcName = value; }
        }
        public  string ProjectISvcName
        {
            get { return ctrlNewService1.ProjectISvcName; }
            set { ctrlNewService1.ProjectISvcName = value; }
        }
        

        public frmWizService()
        {
            InitializeComponent();
        }
        
       

        private void ctrlNewService1_OnWizardButtonClickEvent(object arg, WizardButton result)
        {
            this.WizardButton = result;
            if (result == WizardButton.Ok)
            {
                //this.GenCode = ctrlNewService1.ServiceName;

              
            }
            this.OnFinalizeWiz(WizardButton);
            this.Close();
        }
    }
}
