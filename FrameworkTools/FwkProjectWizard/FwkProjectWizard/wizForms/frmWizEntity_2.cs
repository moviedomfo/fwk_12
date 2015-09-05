using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Wizard;
using Microsoft.SqlServer.Management.Smo;
using Fwk.CodeGenerator;

namespace Fwk.Wizard
{
    public partial class frmWizEntity_2 : frmWizBase
    {
        public frmWizEntity_2()
        {
            InitializeComponent();
        }
        public frmWizEntity_2(CnnString Cnn)
        {
            InitializeComponent();
            wizTablesTreeSelector1.Populate(Cnn);
            wizTablesTreeSelector1.AfterCheckEvent += new AfterCheckHandler(wizTablesTreeSelector1_AfterCheckEvent);
        }

        void wizTablesTreeSelector1_AfterCheckEvent()
        {
            lstCheckedTables.DataSource = wizTablesTreeSelector1.CheckedTables;
        }
        
        private void wizTablesTreeSelector1_OnWizardButtonClickEvent(object arg, WizardButton result)
        {
            this.WizardButton = result;
            if (result == WizardButton.Ok)
            {
               List<Table> list = (List<Table>)arg;
               if (list.Count == 0)
               {
                   MessageBox.Show("Debe chequear al menos una tabla");
                   wizTablesTreeSelector1.Focus();
                   return;
               }
                this.GenCode = GenEntity.GenerateEntities(list, this.ProjectName);
                
            }
            this.OnFinalizeWiz(WizardButton);
            

          
        }

    }
}
