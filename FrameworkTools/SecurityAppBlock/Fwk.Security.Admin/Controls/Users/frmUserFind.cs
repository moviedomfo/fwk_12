using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.Common;
using DevExpress.XtraEditors;

namespace Fwk.Security.Admin.Controls
{
    public partial class frmUserFind : frmSecBase
    {
        public frmUserFind()
        {
            InitializeComponent();
            try
            {
                this.usersGrid1.Initialize();
            }
            catch (Exception ex)
            {

                base.MessageViewInfo.Show(ex);
                this.Close();
            }
        }

        [Browsable(false)]
        public List<User> SelectedUserList
        {
            get
            {
                return this.usersGrid1.SelectedUserList;
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void brnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
