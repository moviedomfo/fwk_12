using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Security.Admin.Controls
{
    public partial class SecurityControlBase : DevExpress.XtraEditors.XtraUserControl
    {
        public Fwk.Bases.EntityUpdateEnum State = Fwk.Bases.EntityUpdateEnum.NEW;
        public virtual String AssemblySecurityControl
        {
            get { return (string.Empty); }
        }
        
        public virtual void Initialize()
        {

        }
        public SecurityControlBase()
        {
            InitializeComponent();
        }

        protected void SetMessageViewToDefault()
        {
            MessageViewInfo.MessageBoxButtons = MessageBoxButtons.OK;
            MessageViewInfo.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Exclamation;
        }
    }
}
