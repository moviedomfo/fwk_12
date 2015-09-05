using System;
namespace Fwk.Bases.FrontEnd.Controls.FwkGrid.Design
{
    public interface IFwkCellStyle
    {
        FwkDataGridViewCellStyle AlternatingRowsDefaultCellStyle { get; set; }
        FwkDataGridViewCellStyle ColumnHeadersDefaultCellStyle { get; set; }
        FwkDataGridViewCellStyle DefaultCellStyle { get; set; }
        FwkDataGridViewCellStyle RowHeadersDefaultCellStyle { get; set; }
        FwkDataGridViewCellStyle RowsDefaultCellStyle { get; set; }
    }
}
