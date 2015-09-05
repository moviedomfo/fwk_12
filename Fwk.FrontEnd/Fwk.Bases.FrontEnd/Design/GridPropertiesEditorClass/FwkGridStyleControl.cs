using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;


namespace Fwk.Bases.FrontEnd.Controls.FwkGrid.Design
{
    // Provides a user interface for adjusting an angle value.
    [ToolboxItem(false)]
    public partial class FwkGridStyleControl : UserControl
    {
        [Description("Custom GridProperties")]
        public GridProperties GridProperties;
        

        public FwkGridStyleControl(GridProperties pGridProperties)
        {
            this.GridProperties = pGridProperties;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.StandardDoubleClick , true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            InitializeComponent();

            chkAllowAddRows.Checked = GridProperties.AllowAddRows;
            chkAllowDeleteRows.Checked = GridProperties.AllowDeleteRows;
            chkAllowReziseRows.Checked = GridProperties.AllowResizeRows;
            chkAllowSortColumns.Checked = GridProperties.AllowOrderColumns;
            chkAllowResizeColumns.Checked = GridProperties.AllowResizeColumns;
        }


        private void btnRowHeader_Click(object sender, EventArgs e)
        {
            //colorDialog1.ShowDialog(this);
            //btnRowHeader.BackColor = colorDialog1.Color;
            //_RowHeadersDefaultCellStyle.DataGridViewCellStyle.BackColor = colorDialog1.Color;
            //Style.RowHeadersDefaultCellStyle.DataGridViewCellStyle.BackColor = colorDialog1.Color;
        }

        private void btnColumnHeaders_Click(object sender, EventArgs e)
        {

            //colorDialog1.ShowDialog(this);
            //btnRowHeader.BackColor = colorDialog1.Color;
            //Style.ColumnHeadersDefaultCellStyle.DataGridViewCellStyle.BackColor = colorDialog1.Color;
        }

        

        protected override void OnClick(EventArgs e)
        {
           
        }

        private void chlAllowDeleteRows_CheckedChanged(object sender, EventArgs e)
        {
            this.GridProperties.AllowDeleteRows = chkAllowDeleteRows.Checked;
        }
        private void chkAllowAddRows_CheckedChanged(object sender, EventArgs e)
        {
            this.GridProperties.AllowAddRows = chkAllowAddRows.Checked;
        }

        private void chkAllowReziseRows_CheckedChanged(object sender, EventArgs e)
        {
            this.GridProperties.AllowResizeRows = chkAllowReziseRows.Checked;
        }

        private void chkAllowResizeColumns_CheckedChanged(object sender, EventArgs e)
        {
            this.GridProperties.AllowResizeRows = chkAllowResizeColumns.Checked;
        }

        private void chkAllowSortColumns_CheckedChanged(object sender, EventArgs e)
        {
            this.GridProperties.AllowOrderColumns = chkAllowSortColumns.Checked;
        }

      
       

    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class GridProperties
    {
        //private IFwkCellStyle _IFwkCellStyle;

        //public IFwkCellStyle IFwkCellStyle
        //{
        //    get { return _IFwkCellStyle; }
        //    set { _IFwkCellStyle = value; }
        //}
        private Boolean _AllowDeleteRows = false;
        private Boolean _AllowAddRows = false;
        private Boolean _AllowResizeRows = false;
        private Boolean _AllowOrderColumns = true;
        private Boolean _AllowResizeColumns = true;
        private Boolean _RowHeaderVisible = false;
        private Boolean _MarckEditedRow = false;

        private Color _RowEditedColor;
        private Color _RowErrorColor;

        public Color RowErrorColor
        {
            get { return _RowErrorColor; }
            set { _RowErrorColor = value; }
        }
        public Color RowEditedColor
        {
            get { return _RowEditedColor; }
            set { _RowEditedColor = value; }
        }
        public Boolean MarckEditedRow
        {
            get { return _MarckEditedRow; }
            set { _MarckEditedRow = value; }
        }
        
        public Boolean RowHeaderVisible
        {
            get { return _RowHeaderVisible; }
            set { _RowHeaderVisible = value; }
        }
        
        public Boolean AllowDeleteRows
        {
            get { return _AllowDeleteRows; }
            set { _AllowDeleteRows = value; }
        }
       

        public Boolean AllowAddRows
        {
            get { return _AllowAddRows; }
            set { _AllowAddRows = value; }
        }

       

        public Boolean AllowResizeRows
        {
            get { return _AllowResizeRows; }
            set { _AllowResizeRows = value; }
        }
        

        public Boolean AllowResizeColumns
        {
            get { return _AllowResizeColumns; }
            set { _AllowResizeColumns = value; }
        }
        

        public Boolean AllowOrderColumns
        {
            get { return _AllowOrderColumns; }
            set { _AllowOrderColumns = value; }
        }

        public override string ToString()
        {
            return "Custom Grid Properties";
        }
    }

}
