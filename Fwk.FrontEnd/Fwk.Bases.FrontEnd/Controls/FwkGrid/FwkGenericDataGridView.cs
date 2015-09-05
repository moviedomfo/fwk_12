using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Fwk.Bases;
using System.Windows.Forms;
using Fwk.FrontEnd.Common.Controls.DataGridViewSorted;
using System.Data;
using System.Drawing;
using Fwk.Bases.FrontEnd.Controls.FwkGrid.Design;
using Fwk.HelperFunctions;

namespace Fwk.Bases.FrontEnd.Controls.FwkGrid
{
    
    public delegate void EnbtitySelectEventHandler<E>(E pEntity) where E : Entity;
    /// <summary>
    /// 
    /// </summary>
    /// <Author>Marcelo Oviedo</Author>
    //[ToolboxBitmap(@"D:\Desarrollo\Fwk\SourceCode\Fwk.FrontEnd\Fwk.Bases.FrontEnd.Controls\Resources\ShowGridlines2HS.bmp")]
    [ToolboxBitmap(typeof(FwkGenericDataGridView), "FwkMessageViewComponent")]
    public partial class FwkGenericDataGridView : DataGridView
    {

        #region Set Browsable = False

      
        #endregion

        #region Properties
        private GridViewExtendedProperties _Properties = null;
        GridProperties _GridProperties = new GridProperties();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public GridViewExtendedProperties Properties
        {
            get
            {
                 _Properties = new GridViewExtendedProperties();
                 return _Properties;
            }
        }


        [Description("Custom grid properties")]
        [BrowsableAttribute(true)]
        //[EditorAttribute(typeof(FwkGridStyleEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
         public GridProperties CustomGridProperties
        {
            get
            {
                GridPropertiesSet();
                return _GridProperties;
            }
            set
            {
                _GridProperties = value;


            }
        }

        #endregion


        void GridPropertiesSet()
        {
            this.AllowUserToAddRows = _GridProperties.AllowAddRows;
            this.AllowUserToOrderColumns = _GridProperties.AllowOrderColumns;
            this.AllowUserToResizeColumns = _GridProperties.AllowResizeColumns;
            this.AllowUserToResizeRows = _GridProperties.AllowResizeRows;
            this.AllowUserToDeleteRows = _GridProperties.AllowDeleteRows;
            this.RowHeadersVisible = _GridProperties.RowHeaderVisible;


        }

        public FwkGenericDataGridView()
        {
            InitializeComponent();
            
        }

        public FwkGenericDataGridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            _Properties = new GridViewExtendedProperties();
        }



        public virtual void Populate<L,E>(L pEntities)
            where E : Entity
            where L : Entities<E>
        {
            if (pEntities.GetDataSet().Tables.Count != 0)
            {
                _Properties.DataView = pEntities.GetDataSet().Tables[0].DefaultView;
            }
            this.DataSource = null;
            this.DataSource = pEntities;
            
        }
        public E GetSelectedEntity<E>() where E : IBaseEntity
        {
            object o = null;
            if (this.CurrentRow == null) return (E)o;

            return ((E)this.CurrentRow.DataBoundItem);
        }
        public void RemoveSelectedEntity<L, E>()
            where E : Entity
            where L : Entities<E>
        {
            if (!(this.DataSource is Entities<E>)) return;
            L wEntities = (L)this.DataSource;
            if (wEntities == null) return;
            if (wEntities.Count == 0) return;
            E wEntity = (E)this.CurrentRow.DataBoundItem;
            wEntities.Remove(wEntity);
            this.DataSource = null;
            this.DataSource = wEntities;
            this.Refresh();
        }
        public void ClearAllItems<L,E>()
            where E : Entity
            where L : Entities<E>
        {
            if (!(this.DataSource is L)) return;

            L wEntities = (L)this.DataSource;
            wEntities.Clear();

            this.DataSource = null;
            this.Refresh();

        }
        public Entities<E> GetEntityCollection<E>() where E : Entity
        {
            return (Entities<E>)this.DataSource;
        }
        public L GetEntityCollection<L, E>()
            where E : Entity
            where L :  Entities<E>,new ()
        {
            if (!(this.DataSource is Entities<E>))
            {
                L pEntities = new L();
                this.DataSource = null;
                this.DataSource = pEntities;
                return pEntities;
            }
            return (L)this.DataSource;
        }
        public void AddEntity<L, E>(E pEntity)
            where E : Entity
            where L : Entities<E>, new()
        {
            L pEntities = null;
            if (!(this.DataSource is Entities<E>))
            {
                pEntities = new L();
            }
            else
            { pEntities = (L)this.DataSource; }
            
            pEntities.Add(pEntity);
            this.DataSource = null;
            this.DataSource = pEntities;
            this.Refresh();

        }

        #region AddCombo

        /// <summary>
        /// Permite agregar un combo como columna a la grilla
        /// </summary>
        /// <param name="pColumnName">Nombre la columna donde quiere posicionar el combo ej:Tipo Producto</param>
        /// <param name="DisplayColumn">Valor que quiere que se muestre en la celda ej: DescricionProducto</param>
        /// <param name="pValueMember">Valor que asume la selda al seleccionar el un item del combo ej:IdTipoProduct</param>
        /// <param name="pComboDataSource">Origen de datos del combo. Puede ser una entidad colecion tipo Entities del fwk o cualquier origen de datos</param>
        /// <Author>Marcelo Oviedo</Author>
        public void AddCombo(string pColumnName,  string pDisplayColumn, string pValueMember, Object pComboDataSource)
        {
           

            //if(Columns.Contains(pColumnName))
            DataGridViewComboBoxColumn column_addcombo = (DataGridViewComboBoxColumn)Columns[pColumnName];// new DataGridViewComboBoxColumn();
            column_addcombo.DataSource = pComboDataSource;
            column_addcombo.DisplayMember = pDisplayColumn;//"LB";
            column_addcombo.ValueMember = pValueMember;// "VL";
            column_addcombo.DataPropertyName = pColumnName;
            column_addcombo.Name = pColumnName;
         
        }
        #endregion

       

        //#region AddMask
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="ColumnName"></param>
        ///// <param name="HeaderText"></param>
        ///// <param name="MaskStr"></param>
        ///// <Author>Marcelo Oviedo</Author>
        //public void AddMask(string ColumnName, string HeaderText, string MaskStr)
        //{
        //    Columns.Remove(ColumnName);
        //    FwkMaskedTextColumn column_addmask;
        //    column_addmask = new FwkMaskedTextColumn();
        //    column_addmask.DataPropertyName = ColumnName;
        //    column_addmask.Name = ColumnName;
        //    column_addmask.HeaderText = HeaderText;
        //    column_addmask.maskA(MaskStr);
        //    Columns.Add(column_addmask);
        //    int j, i;
        //    string[] k = _Properties.DataColumns.Split(',');


        //    i = k.Length - 1;
        //    j = 0;
        //    while ((j < i) && (k[j].IndexOf(ColumnName) == -1))
        //    {
        //        j = j + 1;
        //    }
        //    Columns[i].DisplayIndex = j;
        //}
        //#endregion


        #region Events
        /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellCancelEventArgs"></see> that contains the event data.</param>
        protected override void OnCellBeginEdit(System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            CurrentRow.DefaultCellStyle.BackColor = _GridProperties.RowEditedColor; 
            
            base.OnCellBeginEdit(e);
        }


        /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellEventArgs"></see> that contains the event data.</param>
        protected override void OnRowValidated(System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            
            if (CurrentRow.DefaultCellStyle.BackColor == System.Drawing.Color.DarkSeaGreen)
            {
                if (_GridProperties.MarckEditedRow)
                    CurrentRow.DefaultCellStyle.BackColor = _GridProperties.RowEditedColor;
                //Row_Save(e.RowIndex);
                base.OnRowValidated(e);
            }
        }


        /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellEventArgs"></see> that contains the event data.</param>
        protected override void OnCellEndEdit(System.Windows.Forms.DataGridViewCellEventArgs e)
        {
         
            CurrentRow.DefaultCellStyle.BackColor = this.DefaultCellStyle.BackColor;
            this.Rows[e.RowIndex].ErrorText = String.Empty;
            base.OnCellEndEdit(e);
        }

        /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellValidatingEventArgs"></see> that contains the event data.</param>
        protected override void OnCellValidating(System.Windows.Forms.DataGridViewCellValidatingEventArgs e)
        {
            int i, j;
            j = _Properties.ValidationTable.Rows.Count - 1;
            if (j != -1)
            {

                i = 0;
                bool check = false;
                System.Data.DataView dv = new System.Data.DataView(_Properties.ValidationTable, "Name='" + this.Columns[e.ColumnIndex].Name + "'", null, System.Data.DataViewRowState.CurrentRows);
                if (dv.Count == 1)
                {
                    if ((bool)dv[0][1])
                    {
                        if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            this.Rows[e.RowIndex].ErrorText = "Empty Text";
                            e.Cancel = true;
                        }
                    }
                    if ((dv[0][2].ToString()) != String.Empty)
                    {
                        switch (dv[0][2].ToString())
                        {
                            case "0":
                                check = IsNumericInt(e.FormattedValue.ToString());
                                break;
                            case "1":
                                check = IsNumericDouble(e.FormattedValue.ToString());
                                break;
                            case "2":
                                check = IsEmail(e.FormattedValue.ToString());
                                break;
                            case "3":
                                check = IsDate(e.FormattedValue.ToString());
                                break;
                        }
                        if (check)
                        {
                            this.Rows[e.RowIndex].ErrorText = dv[0][3].ToString();
                            e.Cancel = check;
                        }
                    }

                }
            }
            base.OnCellValidating(e);
          
        }

        #region ValidationControls
        private bool IsNumericDouble(object ValueToCheck)
        {
            double Dummy = 0;
            return !double.TryParse(ValueToCheck.ToString(), System.Globalization.NumberStyles.Any, null, out Dummy);
        }

        private bool IsNumericInt(object ValueToCheck)
        {
            int Dummy = 0;
            return !int.TryParse(ValueToCheck.ToString(), System.Globalization.NumberStyles.Any, null, out Dummy);
        }

        private bool IsEmail(object ValueToCheck)
        {
            return !System.Text.RegularExpressions.Regex.IsMatch(ValueToCheck.ToString(), @"^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$");
        }

        private bool IsDate(object ValueToCheck)
        {
            return !System.Text.RegularExpressions.Regex.IsMatch(ValueToCheck.ToString(), @"^[0-2]?[1-9](/|-|.)[0-3]?[0-9](/|-|.)[1-2][0-9][0-9][0-9]$");

        }


        #endregion



        #endregion


      

        public void ExportToExcel()
        {
            if (_Properties.DataView != null)
                ExportFunctions.ExportToExcel(_Properties.DataView.Table, "ExportToExcel");
            else
                ExportFunctions.ExportToExcel(((IEntity)DataSource).GetDataSet().Tables[0], "ExportToExcel");

        }
        public string OrderDescription
        {
            get { return "Order by " + _Properties.Sort; }

        }
      
    }
   

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class GridViewExtendedProperties
    {
       
        #region Properties

        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataView DataView;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataGridComparer ColumnSorter;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<SortColDefn> SortedColumns;
        public string DataColumns;

        
        public string Sort = string.Empty;
 

        public DataTable ValidationTable = new DataTable("ValidationTable");

        #endregion

       

        public struct SortColDefn
        {
            internal string colName;
            internal bool ascending;

            internal SortColDefn(string columnName, SortOrder sortOrder)
            {
                colName = columnName;
                ascending = (sortOrder != SortOrder.Descending);
            }
        }
    }
}
