using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Bases;
using Fwk.HelperFunctions;

namespace Fwk.Win32.Test
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
          WorkSheets wWorkSheetsList =new WorkSheets();
          wWorkSheetsList = ImportFunctions.SearchWorkSheets(@"C:\PruebaExportacion.xls");
          workSheetsBindingSource.DataSource = wWorkSheetsList;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            gridView1.Columns.Clear();
            gridControl1.DataSource = ImportFunctions.ImportFromExcel(@"C:\PruebaExportacion.xls", lookUpEdit1.EditValue.ToString());
           gridControl1.RefreshDataSource();
        }

    }
}
