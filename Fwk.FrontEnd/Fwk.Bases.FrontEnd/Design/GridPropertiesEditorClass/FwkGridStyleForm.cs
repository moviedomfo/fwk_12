using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Bases.FrontEnd.Controls.FwkGrid.Design
{
    /// <summary>
    /// Visor de las propiedades expandidas que lanza el editor de estilos.- FwkGridStyleEditor
    /// </summary>
    public partial class FwkGridStyleForm : Form
    {
        private GridProperties _GridProperties;

        public GridProperties GridProperties
        {
            get { return _GridProperties; }
            set { _GridProperties = value; }
        }

        [Description("Custom grid properties")]
        public FwkGridStyleForm(GridProperties pGridProperties)
        {

            _GridProperties = pGridProperties;
            InitializeComponent();
          
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.StandardDoubleClick, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);


            chkAllowAddRows.Checked = _GridProperties.AllowAddRows;
            chkAllowDeleteRows.Checked = _GridProperties.AllowDeleteRows;
            chkAllowReziseRows.Checked = _GridProperties.AllowResizeRows;
            chkAllowSortColumns.Checked = _GridProperties.AllowOrderColumns;
            chkAllowResizeColumns.Checked = _GridProperties.AllowResizeColumns;

            chkHeaderVisible.Checked = _GridProperties.RowHeaderVisible;
            chkMarckEditedRow.Checked = _GridProperties.MarckEditedRow;
            lblRowEditColor.BackColor = _GridProperties.RowEditedColor;

            //DefaultStyles( _GridProperties.IFwkCellStyle);
            FillCliente();
        }




        private void StyleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _GridProperties.AllowOrderColumns = chkAllowSortColumns.Checked;
            _GridProperties.AllowResizeColumns = chkAllowResizeColumns.Checked;
            _GridProperties.AllowResizeRows = chkAllowReziseRows.Checked;
            _GridProperties.AllowAddRows = chkAllowAddRows.Checked;
            _GridProperties.AllowDeleteRows = chkAllowDeleteRows.Checked;
            _GridProperties.RowHeaderVisible = chkHeaderVisible.Checked;
            _GridProperties.MarckEditedRow = chkMarckEditedRow.Checked;
          
        }

        

        private void cmbDefaultStyles_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((GridStyleEnum)cmbDefaultStyles.SelectedIndex)
            {
                case GridStyleEnum.GreenFlat:
                    {
                        DefaultStyles(new FwkCellStyleGreenFlat());
                        break;
                    }
                case GridStyleEnum.MaroonFlat:
                    {
                        DefaultStyles(new FwkCellStyleMarronFlat());
                        break;
                    }
                case GridStyleEnum.LightBlueFlat:
                    {
                        DefaultStyles(new FwkCellStyleLightBlueFlat());
                        break;
                    }
            }
        }
       

       

        private void lblEditColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog(this);
            lblRowEditColor.BackColor = colorDialog1.Color;
            _GridProperties.RowEditedColor = colorDialog1.Color;
        }

        #region [private methods]
        void DefaultStyles(IFwkCellStyle pIFwkCellStyle)
        {

            if (pIFwkCellStyle == null) return;
            //_GridProperties.IFwkCellStyle = pIFwkCellStyle;
            

            dataGridView1.SuspendLayout();

            dataGridView1.AlternatingRowsDefaultCellStyle = pIFwkCellStyle.AlternatingRowsDefaultCellStyle.DataGridViewCellStyle;
            dataGridView1.ColumnHeadersDefaultCellStyle = pIFwkCellStyle.ColumnHeadersDefaultCellStyle.DataGridViewCellStyle;
            dataGridView1.DefaultCellStyle = pIFwkCellStyle.DefaultCellStyle.DataGridViewCellStyle;
            dataGridView1.RowHeadersDefaultCellStyle = pIFwkCellStyle.RowHeadersDefaultCellStyle.DataGridViewCellStyle;
            dataGridView1.RowsDefaultCellStyle = pIFwkCellStyle.RowsDefaultCellStyle.DataGridViewCellStyle;

            DefaultGridSetting(dataGridView1);

            dataGridView1.ResumeLayout(false);
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
        void FillCliente()
        {
            ClienteCollection wClienteCollection = new ClienteCollection();
            Cliente wCliente = new Cliente();

            wCliente.IdCliente = 20008;
            wCliente.Nombre = "Albert";
            wCliente.Apellido = "Stiefel";
            wClienteCollection.Add(wCliente);

            wCliente = new Cliente();
            wCliente.IdCliente = 10000;
            wCliente.Nombre = "Joan";
            wCliente.Apellido = "Pullut";
            wClienteCollection.Add(wCliente);
            wCliente = new Cliente();
            wCliente.IdCliente = 40005;
            wCliente.Nombre = "July";
            wCliente.Apellido = "Brown";
            wClienteCollection.Add(wCliente);

            dataGridView1.DataSource = wClienteCollection;
        }


        #endregion
    }
    public enum GridStyleEnum
    {
        MaroonFlat = 0,
        GreenFlat = 1,
        LightBlueFlat = 2, Custom = 3
    }
}