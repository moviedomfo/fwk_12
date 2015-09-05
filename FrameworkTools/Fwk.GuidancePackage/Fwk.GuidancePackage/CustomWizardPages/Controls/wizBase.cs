using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.WizardFramework;



namespace Fwk.GuidPk
{


    [ToolboxItem(true)]
    public partial class wizBase : CustomWizardPage
    {
        public wizBase(WizardForm parent)
            : base(parent)
        {
            InitializeComponent();
        }
        public wizBase()
        
        {
            InitializeComponent();
        }

        [Category("Fwk Wizard")]
        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }










    }
}
