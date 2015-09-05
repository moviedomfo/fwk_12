using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Bases.FrontEnd;

namespace ConfigurationApp.Forms
{
    public delegate void ClickOkCancelHandler(object sender, DialogResult result);
    public partial class UserControlBase : FwkUserControlBase
    {
        public UserControlBase()
        {
            InitializeComponent();
        }

        public event ClickOkCancelHandler ClickOkCancelEvent;
        protected void OnClickOkCanceHandler(DialogResult pDialogResult)
        {
            if (ClickOkCancelEvent != null)
                ClickOkCancelEvent(this, pDialogResult);
        }
    }
}
