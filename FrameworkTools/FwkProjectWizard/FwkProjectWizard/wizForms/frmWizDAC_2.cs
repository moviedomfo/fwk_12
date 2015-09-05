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
    public partial class frmWizDAC_2 : frmWizBase
    {
        public frmWizDAC_2()
        {
            InitializeComponent();
        }
        public frmWizDAC_2(CnnString Cnn)
        {
            InitializeComponent();
            wizTablesTreeSelector1.Populate(Cnn);
            wizTablesTreeSelector1.CheckBoxes = false;
        }

        private void wizTablesTreeSelector1_OnWizardButtonClickEvent(object arg, WizardButton result)
        {
            this.WizardButton = result;
            if (result == WizardButton.Ok)
            {
                List<MethodActionType> wMethodActionTypeList = new List<MethodActionType>();

                if (chkInsert.Checked)
                    wMethodActionTypeList.Add(MethodActionType.Insert);
                if (chkUpdate.Checked)
                    wMethodActionTypeList.Add(MethodActionType.Update);
                if (chkSearchByParams.Checked)
                    wMethodActionTypeList.Add(MethodActionType.SearchByParam);

                if (chkDelete.Checked)
                    wMethodActionTypeList.Add(MethodActionType.Delete);

                this.GenCode = new Dictionary<string, string>();

                this.GenCode.Add(string.Concat(wizTablesTreeSelector1.SelectedTable.Name, "DAC.cs")
                    , GenDAC.Gen_DAC(wizTablesTreeSelector1.SelectedTable, wMethodActionTypeList, chkBatch.Checked, this.ProjectName));


            }
            this.OnFinalizeWiz(this.WizardButton);
        }

        
    }
}
