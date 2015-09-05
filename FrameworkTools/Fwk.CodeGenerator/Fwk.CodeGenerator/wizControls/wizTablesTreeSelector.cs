using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Fwk.DataBase;

namespace Fwk.CodeGenerator
{
    public partial class wizTablesTreeSelector : wizBase
    {
        public event AfterCheckHandler AfterCheckEvent;

        private void ctrlTreeViewTables1_AfterCheckEvent()
        {
            AfterCheckEvent();
        }

        public bool CheckBoxes
        {
            get { return ctrlTreeViewTables1.CheckBoxes; }
            set { ctrlTreeViewTables1.CheckBoxes = value; }
        }

        public Table SelectedTable
        {
            get { return ctrlTreeViewTables1.SelectedTable; }
           
        }
        public List<Table> CheckedTables
        {
            get { return ctrlTreeViewTables1.CheckedTables; }

        }
        public wizTablesTreeSelector()
        {
            InitializeComponent();
        }

        public void Populate(CnnString pCnn)
        {
            this.ctrlTreeViewTables1.Populate(pCnn);
        }

       
       

        private void btnOk_Click(object sender, EventArgs e)
        {
            base.DoEvent(ctrlTreeViewTables1.CheckedTables, CodeGeneratorCommon.WizardButton.Ok);
        }

      

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DoEvent(null, CodeGeneratorCommon.WizardButton.Cancel);
        }

       

        private void btnBack_Click(object sender, EventArgs e)
        {
            base.DoEvent(null,CodeGeneratorCommon.WizardButton.Back);
        }
        

    }
}
