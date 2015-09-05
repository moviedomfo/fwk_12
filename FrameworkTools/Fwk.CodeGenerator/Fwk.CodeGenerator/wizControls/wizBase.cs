using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Fwk.CodeGenerator
{
    public delegate void OnWizardButtonClickHandler(object arg, CodeGeneratorCommon.WizardButton result);
    [DefaultEvent("OnWizardFinalizeEvent")]
    [ToolboxItem(true)]
    public partial class wizBase : UserControl
    {
        [Category("Fwk Wizard")]
        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }
        [Category("Fwk Wizard")]
        public bool Button_OK_Visible
        {
            get {return  btnOk.Visible; }
            set { btnOk.Visible = value; }
        }
        [Category("Fwk Wizard")]
        public bool Button_Next_Visible
        {
            get { return btnNext.Visible; }
            set { btnNext.Visible = value; }
        }
        [Category("Fwk Wizard")]
        public bool Button_Cancel_Visible
        {
            get { return btnCancel.Visible; }
            set { btnCancel.Visible = value; }
        }
        [Category("Fwk Wizard")]
        public bool Button_Back_Visible
        {
            get { return btnBack.Visible; }
            set { btnBack.Visible = value; }
        }
        [Category("Fwk Wizard")]
        public event OnWizardButtonClickHandler OnWizardButtonClickEvent;
        public void DoEvent(object o, CodeGeneratorCommon.WizardButton r)
        {
            if (OnWizardButtonClickEvent != null)
                OnWizardButtonClickEvent(o,r);
        }
        public wizBase()
        {
            InitializeComponent();
        }

     

      

       

        
    }
}
