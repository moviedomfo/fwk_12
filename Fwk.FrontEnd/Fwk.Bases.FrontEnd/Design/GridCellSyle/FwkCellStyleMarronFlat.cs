using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


namespace Fwk.Bases.FrontEnd.Controls.FwkGrid.Design
{
    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    [ToolboxItem(false)]
    public partial class FwkCellStyleMarronFlat : Component, IFwkCellStyle
    {

        public FwkCellStyleMarronFlat()
        {
            InitializeComponent();
        }

        public FwkCellStyleMarronFlat(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }



        #region IFwkCellStyle Members

        public FwkDataGridViewCellStyle AlternatingRowsDefaultCellStyle
        {
            get
            {
                return this._AlternatingRowsDefaultCellStyle;
            }
            set
            {
                _AlternatingRowsDefaultCellStyle = value;
            }
        }

        public FwkDataGridViewCellStyle ColumnHeadersDefaultCellStyle
        {
            get
            {
                return this._ColumnHeadersDefaultCellStyle;
            }
            set
            {
                _ColumnHeadersDefaultCellStyle = value;
            }
        }

        public FwkDataGridViewCellStyle DefaultCellStyle
        {
            get
            {
                return this._DefaultCellStyle;
            }
            set
            {
                _DefaultCellStyle = value;
            }
        }

        public FwkDataGridViewCellStyle RowHeadersDefaultCellStyle
        {
            get
            {
                return this._RowHeadersDefaultCellStyle;
            }
            set
            {
                _RowHeadersDefaultCellStyle = value;
            }
        }

        public FwkDataGridViewCellStyle RowsDefaultCellStyle
        {
            get
            {
                return this._RowsDefaultCellStyle;
            }
            set
            {
                _RowsDefaultCellStyle = value;
            }
        }

        #endregion
    }

}
