//
// Mobius.Utility.SortedDataGridView
//
// Authors:
//    Paul T Anderson (paul.t.anderson at gmail)
//
// (C) 2007 Paul T Anderson
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

using System.ComponentModel;
using System.Diagnostics;
using Fwk.FrontEnd.Common.Controls.DataGridViewSorted;

using Fwk.Bases;
using Fwk.Bases.FrontEnd.Controls;
using Fwk.HelperFunctions;
[ToolboxItem(false)]
public class SortedDataGridView : DataGridView
{

    #region --[ Variables Miembro ]--

    DataGridComparer _columnSorter;
    private DataView mo_dvDataView;
    List<SortColDefn> _sortedColumns;
    string msz_Sort = string.Empty;

    private struct SortColDefn
    {
        internal string colName;
        internal bool ascending;

        internal SortColDefn(string columnName, SortOrder sortOrder)
        {
            colName = columnName;
            ascending = (sortOrder != SortOrder.Descending);
        }
    }


    public Object OrigenDatos
    {
        set
        {
            if (value != null)
            {
                if (value.GetType().GetInterface("IEntity") != null)
                {
                    //Revisar
                    if (((IEntity)value).GetDataSet().Tables.Count > 0)
                        mo_dvDataView = ((IEntity)value).GetDataSet().Tables[0].DefaultView;
                    else
                        mo_dvDataView = null;
                }
                else
                {
                    mo_dvDataView = ((DataTable)value).DefaultView;

                }
                //Limpio el datasource anterior
                base.DataSource = null;
                base.DataSource = value;
            }
            else
            {
                base.DataSource = null;
            }
        }
    }


    public string OrderDescription
    {
        get { return "Order by " + msz_Sort; }

    }

    #endregion

    #region --[ Constructor ]--

    public SortedDataGridView()
    {
        InitializeComponent();
        _columnSorter = new DataGridComparer(this);
        _sortedColumns = new List<SortColDefn>();
    }

    #endregion


    #region --[ Funcionalidad del Ordenamiento ]--


    public string SortOrderDescription
    {
        get { return _columnSorter.SortOrderDescription; }
    }


    public void LimpiarOrdenamiento()
    {

        _sortedColumns.Clear();

    }


    protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
    {
        //Si no tiene datos asociados salgo.
        if (mo_dvDataView == null)
            return;

        //Agrego a la lista de columnas para el ordenamiento
        SortColDefn wSortColDefn = new SortColDefn(Columns[e.ColumnIndex].DataPropertyName,
                                                   this.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection);

        //Busco la columna en la coleccion
        int windex = _sortedColumns.FindIndex(delegate(SortColDefn auxSortColDefn)
                         { return auxSortColDefn.colName == wSortColDefn.colName; });

        //Verifico que no exista en la lista de columnas a ordenar
        if (windex != -1)
        {

            //Objeto columna Auxiliar 
            SortColDefn wo_SortColDefn;

            //Obtengo el objeto de la posicion i.
            wo_SortColDefn = _sortedColumns[windex];

            _sortedColumns.Remove(wSortColDefn);

            //Seteo el tipo de orden
            if (wSortColDefn.ascending)
            {
                wo_SortColDefn.ascending = false;
                this.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                    System.Windows.Forms.SortOrder.Descending;
            }
            else
            {
                wo_SortColDefn.ascending = true;
                this.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                    System.Windows.Forms.SortOrder.Ascending;
            }

            //Elimino el que estaba en la lista de columnas
            _sortedColumns.Remove(wo_SortColDefn);

            //Inserto en la posicion que tenía un nuevo item con el ordenamiento solicitado
            _sortedColumns.Insert(windex, wo_SortColDefn);
        }
        else
        {
            //Seteo el tipo de orden
            if (wSortColDefn.ascending)
            {
                wSortColDefn.ascending = false;
                //this.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                //  System.Windows.Forms.SortOrder.Descending;
            }
            else
            {
                wSortColDefn.ascending = true;
                //this.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                //  System.Windows.Forms.SortOrder.Ascending;
            }

            //Agrego la columna a la lista
            _sortedColumns.Add(wSortColDefn);
        }


        Columns[e.ColumnIndex].SortMode = DataGridViewColumnSortMode.Programmatic;


        msz_Sort = string.Empty;

        //Recorro la coleccion de columnas a ordenar
        foreach (SortColDefn wColDefn in _sortedColumns)
        {
            msz_Sort = msz_Sort + wColDefn.colName;

            if (wColDefn.ascending)
            {
                msz_Sort = msz_Sort + " ASC,";
            }
            else
            {
                msz_Sort = msz_Sort + " DESC,";
            }

        }

        msz_Sort = msz_Sort.Substring(0, msz_Sort.Length - 1);

        mo_dvDataView.Sort = msz_Sort;


        this.DataSource = mo_dvDataView;



        base.OnColumnHeaderMouseClick(e);

    }



    #endregion


    #region --[ Designer ]--

    private void Inicializar()
    {

        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        this.SuspendLayout();
        // 
        // SortedDataGridView
        this.AllowUserToDeleteRows = false;
        this.AllowUserToOrderColumns = true;
        this.AllowUserToResizeRows = false;
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(251)))), ((int)(((byte)(171)))));
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
        this.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(249)))), ((int)(((byte)(234)))));
        this.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Khaki;
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        this.ColumnHeadersHeight = 22;
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(251)))), ((int)(((byte)(171)))));
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.DefaultCellStyle = dataGridViewCellStyle3;
        this.EnableHeadersVisualStyles = false;
        this.GridColor = System.Drawing.Color.White;
        this.Location = new System.Drawing.Point(3, 42);
        this.MultiSelect = false;
        this.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.InactiveCaption;
        dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
        dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
        dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
        dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
        this.RowHeadersVisible = false;
        dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
        this.RowsDefaultCellStyle = dataGridViewCellStyle5;
        this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.Size = new System.Drawing.Size(702, 242);
        this.TabIndex = 19;
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        this.ResumeLayout(false);
    }

    private void InitializeComponent()
    {
        Inicializar();
    }

    #endregion


    public void ExportToExcel()
    {
        if (mo_dvDataView != null)
           ExportFunctions.ExportToExcel(mo_dvDataView.Table, "ExportToExcel");
        else
            ExportFunctions.ExportToExcel(((IEntity)DataSource).GetDataSet().Tables[0], "ExportToExcel");

    }

}

