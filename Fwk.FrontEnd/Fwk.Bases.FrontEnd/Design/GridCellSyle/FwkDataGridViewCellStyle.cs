using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Bases.FrontEnd.Controls.FwkGrid.Design
{
    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    [ToolboxItem(false)]
    public partial class FwkDataGridViewCellStyle : Component
    {



        private DataGridViewCellStyle _DataGridViewCellStyle = new DataGridViewCellStyle();

        public DataGridViewCellStyle DataGridViewCellStyle
        {
            get { return _DataGridViewCellStyle; }
            set { _DataGridViewCellStyle = value; }
        }

        public FwkDataGridViewCellStyle()
        {
            InitializeComponent();
        }

        public FwkDataGridViewCellStyle(IContainer container)
        {
           

            InitializeComponent();
        }
        public override string ToString()
        {
            return  "FwkCellStyleGreenFlat";
        }
    }
}
