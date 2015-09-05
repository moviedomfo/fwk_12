using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Logging.Viewer
{
    public partial class OtherView : UserControl
    {
        public OtherView()
        {
            InitializeComponent();
        }
        public void Populate(EventGrid pEventGrid)
        {
            txtMessage1.Text = pEventGrid.FormatedMessage.AnyMessage;

        }

        private void btnCopyRequstToClip_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtMessage1.Text);
        }
    }
}
