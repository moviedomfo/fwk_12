using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace Fwk.Bases.FrontEnd.Controls.FwkGrid
{


    public class mskn
    {
        static public string msk = String.Empty;
    }

    /// <summary>
    /// Clase Mask columna para grilla Fwk <see cref="FwkGenericDataGridView"/>
    /// </summary>
    /// <Autor>Marcelo F Oviedo</Autor>
    public class FwkMaskedTextColumn : DataGridViewColumn
    {
        public FwkMaskedTextColumn()
            : base(new FwkMaskedTextCell())
        { }

        public void maskA(string m)
        {
            mskn.msk = m;
        }


        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(FwkMaskedTextCell)))
                {
                    throw new InvalidCastException("Must be a FwkMaskedTextCell");
                }
                base.CellTemplate = value;
            }
        }



    }


    /// <summary>
    /// Clase Mask celda para grilla Fwk <see cref="FwkGenericDataGridView"/>
    /// </summary>
    /// <Autor>Marcelo F Oviedo</Autor>
    public class FwkMaskedTextCell : DataGridViewTextBoxCell
    {
        public FwkMaskedTextCell()
            : base()
        {
            this.Style.ForeColor = System.Drawing.Color.RoyalBlue;

        }




        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            FwkMaskedTextEditingControl ctl = DataGridView.EditingControl as FwkMaskedTextEditingControl;
            ctl.Text = (string)this.Value;


        }

        public override Type EditType
        {
            get
            {
                return typeof(FwkMaskedTextEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(string);
            }
        }


        


    }

    /// <summary>
    /// Clase Mask para el editor de la celda que se incrusta en una grilla del Fwk <see cref="FwkGenericDataGridView"/>
    /// </summary>
    /// <Autor>Marcelo F Oviedo</Autor>
    class FwkMaskedTextEditingControl : MaskedTextBox, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged;
        int rowIndex;

        public FwkMaskedTextEditingControl()
        {
            this.Mask = mskn.msk;
        }


        public object EditingControlFormattedValue
        {
            get
            {
                return this.Text;
            }
            set
            {
                if (value is String)
                {
                    this.Text = (String)value;

                }
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
        }

        // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
        // property.
        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return false;
            }
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation needs to be done.
        }

        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }


        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }


        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnLeave(System.EventArgs e)
        {
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnTextChanged(e);
        }

    }

}
