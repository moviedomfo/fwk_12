using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Controls.Win32.PropertyWrapper
{
    public partial class PropertyWraperControl : UserControl
    {

        /// <summary>
        /// The list with all properties
        /// </summary>
        private GenericPropertyCollection_CustomTypeDescriptor _Properties = new GenericPropertyCollection_CustomTypeDescriptor();

        public GenericPropertyCollection_CustomTypeDescriptor Properties
        {
            get { return _Properties; }
            set { _Properties = value; }
        }

        public PropertyWraperControl()
        {
            InitializeComponent();
        }
        public void RefreshProperties()
        {



            PropertySetting.SelectedObject = _Properties;
            PropertySetting.ExpandAllGridItems();






        }
    }
}
