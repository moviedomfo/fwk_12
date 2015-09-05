using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Exceptions;

namespace Fwk.Logging.Viewer
{
    public partial class ServiceErrorView : UserControl
    {
        public ServiceErrorView()
        {
            InitializeComponent();
        }

        public void Populate(EventGrid pMessage)
        {
            ServiceError error = ServiceError.GetFromXml<ServiceError>( pMessage.FormatedMessage .AnyMessage);
            lblMachine.Text = error.Machine;
            lblSource.Text = error.Source;
            lblErrorId.Text = error.ErrorId;
            lblErrorType.Text = error.Type;
            lblUser.Text = error.UserName;
            txtMessage1.Text = error.Message + Environment.NewLine + error.InnerMessageException;
          
        }

        private void btnCopyRequstToClip_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtMessage1.Text);
        }
    }
}
