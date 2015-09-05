using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Security.Admin.Controls
{
    public partial class frmRulesAdmin : Fwk.UI.Forms.FormDialogBase
    {
        public string RuleName { get; set; }
        
        public frmRulesAdmin()
        {
            
            InitializeComponent();
            rulesAssingControl1.State = Bases.EntityUpdateEnum.NEW;
            rulesAssingControl1.ButtonSaveVisible = false;
        }
        public frmRulesAdmin(string ruleName)
        {
            this.RuleName = ruleName;
        
            InitializeComponent();
            rulesAssingControl1.State = Bases.EntityUpdateEnum.UPDATED;
            rulesAssingControl1.ButtonSaveVisible = false;
        }
        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {
            this.DialogResult = result;

            if (result == System.Windows.Forms.DialogResult.OK)
                if (this.rulesAssingControl1.AceptChanges())
                {
                    this.Close();
                }
            if (result == System.Windows.Forms.DialogResult.Cancel)
                this.Close();

        }

        private void frmRulesAdmin_Load(object sender, EventArgs e)
        {
            rulesAssingControl1.Initialize();
            if (!String.IsNullOrEmpty(RuleName))
                rulesAssingControl1.Populate(RuleName);
        }


    }
}
