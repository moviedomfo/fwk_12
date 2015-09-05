using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Fwk.Bases;

namespace Fwk.Bases.FrontEnd.Controls.FwkGrid
{
    public class FwkGridViewEntityColum : DataGridViewColumn
    {
       
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(FwkGridViewCellEntity)))
                {
                    throw new InvalidCastException("Must be a FwkGridViewCellEntity");
                }
                base.CellTemplate = value;
            }
        }

    }

    public class FwkGridViewCellEntity : DataGridViewCell
    {
        

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that CalendarCell contains.
                return typeof(String);
            }
        }
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            FwkEntityEditingControl ctl = DataGridView.EditingControl as FwkEntityEditingControl;
            ctl.TexCellGrid = (String)this.Value;
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value.
                return String.Empty ;
            }
        }
        public override Type EditType
        {
            get
            {
                // Return the type of the editing contol that CalendarCell uses.
                return typeof(FwkEntityEditingControl);
            }
        }

    }

    class FwkEntityEditingControl : FwkEntityGrid, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        

        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
        // property.
        public object EditingControlFormattedValue
        {
            get
            {
                return this.TexCellGrid;
            }
            set
            {
                if (value is String)
                {
                    this.TexCellGrid = value.ToString();
                }
            }
        }

        // Implements the 
        // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
        public object GetEditingControlFormattedValue(
            DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        // Implements the 
        // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
        public void ApplyCellStyleToEditingControl(
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            //this.Font = dataGridViewCellStyle.Font;
            //this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
            //this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
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

        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
        // method.
        public bool EditingControlWantsInputKey(            Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed.
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

        // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
        // method.
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation needs to be done.
        }

        
        /// <summary>
        /// Implements the IDataGridViewEditingControl.RepositionEditingControlOnValueChange property.
        /// </summary>
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlDataGridView property.
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

        // Implements the IDataGridViewEditingControl
        // .EditingControlValueChanged property.
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

        // Implements the IDataGridViewEditingControl
        // .EditingPanelCursor property.
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        protected override void OnValueChanged(EventArgs e)
        {
            // Notify the DataGridView that the contents of the cell
            // have changed.
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(e);
        }
    }
    [Serializable ]
    public class FwkEntityGrid : Control
    {
        private Entity _Entity;

        public Entity Entity
        {
            get { return _Entity; }
            set { _Entity = value; }
        }
        public event EventHandler ValueChanged;

        protected virtual void OnValueChanged(EventArgs eventargs)
        {

            ValueChanged(this, eventargs);
        }

        private String _TexCellGrid;

        public String TexCellGrid
        {
            get { return _Entity.ToString(); }
            set
            {
                _TexCellGrid = value;

                OnValueChanged(new EventArgs());
            }
        }
        private Cursor _Cursor = Cursors.Hand;


        public override Cursor Cursor
        {
            get { return _Cursor; }
            set { _Cursor = value; }
        }
    }
}
