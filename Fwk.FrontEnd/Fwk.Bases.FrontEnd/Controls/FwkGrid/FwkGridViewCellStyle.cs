using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Fwk.Bases.FrontEnd.Controls.FwkGrid.Design;
namespace Fwk.Bases.FrontEnd.Controls.FwkGrid
{
    internal class FwkGridViewCellStyle
    {


        //internal static void SetDefault(FwkGenericDataGridView fwkGenericDataGridView, GridStyleEnum gridStyleEnum)
        //{
        //    IFwkCellStyle wIFwkCellStyle = null;
        //    switch (gridStyleEnum)
        //    {
        //        case GridStyleEnum.GreenFlat:
        //            {
        //                wIFwkCellStyle = new FwkCellStyleGreenFlat();
        //                break;
        //            }
        //        case GridStyleEnum.MaroonFlat:
        //            {
        //                wIFwkCellStyle = new FwkCellStyleMarronFlat();
        //                break;
        //            }
        //        case GridStyleEnum.LightBlueFlat:
        //            {
        //                wIFwkCellStyle = new FwkCellStyleLightBlueFlat();
        //                break;
        //            }
        //        case GridStyleEnum.Custom:
        //            {
        //                return;
                      
        //            }
        //    }

        //    Set(fwkGenericDataGridView, wIFwkCellStyle);

        //}

        internal static void Set(FwkGenericDataGridView fwkGridViewCellStyle, IFwkCellStyle pIFwkCellStyle)
        {

            if (pIFwkCellStyle == null) return;
            fwkGridViewCellStyle.SuspendLayout();

            fwkGridViewCellStyle.AlternatingRowsDefaultCellStyle = pIFwkCellStyle.AlternatingRowsDefaultCellStyle.DataGridViewCellStyle;
            fwkGridViewCellStyle.ColumnHeadersDefaultCellStyle = pIFwkCellStyle.ColumnHeadersDefaultCellStyle.DataGridViewCellStyle;
            fwkGridViewCellStyle.DefaultCellStyle = pIFwkCellStyle.DefaultCellStyle.DataGridViewCellStyle;
            fwkGridViewCellStyle.RowHeadersDefaultCellStyle = pIFwkCellStyle.RowHeadersDefaultCellStyle.DataGridViewCellStyle;
            fwkGridViewCellStyle.RowsDefaultCellStyle = pIFwkCellStyle.RowsDefaultCellStyle.DataGridViewCellStyle;

            DefaultGridSetting(fwkGridViewCellStyle);

            fwkGridViewCellStyle.ResumeLayout(false);
        }

        private static void DefaultGridSetting(DataGridView dataGrid)
        {
            dataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGrid.EnableHeadersVisualStyles = false;
            dataGrid.GridColor = System.Drawing.Color.White;
            dataGrid.MultiSelect = false;
            dataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGrid.RowHeadersVisible = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToOrderColumns = true;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.AllowUserToResizeColumns = true;
            dataGrid.ColumnHeadersHeight = 22;

            dataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(249)))), ((int)(((byte)(234)))));

        }
    }
 
}
