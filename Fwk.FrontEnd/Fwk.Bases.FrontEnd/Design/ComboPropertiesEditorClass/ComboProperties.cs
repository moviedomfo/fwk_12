using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace Fwk.Bases.FrontEnd.Controls.FwkCombo.Design
{

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class ComboProperties
    {
        #region Events
        public delegate void ReadOnlyChangeHandler();
        public event ReadOnlyChangeHandler ReadOnlyChangeEvent;
        private void OnReadOnlyChangeEvent()
        {
            if (ReadOnlyChangeEvent != null)
                ReadOnlyChangeEvent();
        }

        public delegate void AutoCompleteChangeHandler();
        public event AutoCompleteChangeHandler AutoCompleteChangeEvent;
        private void OnAutoCompleteChangeEvent()
        {
            if (AutoCompleteChangeEvent != null)
                AutoCompleteChangeEvent();
        }
        #endregion

        #region Members

        private Color _ActiveBorderColor = SystemColors.ControlDarkDark;
        private Color _InactiveBorderColor = SystemColors.ControlDark;
        private Color _ActiveArrowColor = SystemColors.ControlDarkDark;
        private Color _InactiveArrowColor = SystemColors.ControlDark;
        private Color _ActiveButtonColor = SystemColors.ControlDark;
        private Color _InactiveButtonColor = SystemColors.Control;
        private Color _ReadOnlyColor = SystemColors.Control;
        private Color _BackColor = SystemColors.ControlText;


        private Boolean _Required;
        private Boolean _Readonly;
        private Boolean _AutoComplete = true;

        #endregion




        #region Properties
        [Browsable(false)]
        public Color BackColor
        {
            get { return _BackColor; }
            set { _BackColor = value; }
        }

        [CategoryAttribute("Behavior"), Description("Determina si el combo se autocompleta y admite entradas nuevas")]
        public bool AutoComplete
        {
            get { return _AutoComplete; }
            set { _AutoComplete = value; OnAutoCompleteChangeEvent(); }
        }

        /// <summary>
        /// Setea u Obtiene si el control es solo lectura.
        /// </summary>
        [CategoryAttribute("Behavior"), Description("Setea u Obtiene si el control es solo lectura.")]
        public bool ReadOnly
        {
            get { return _Readonly; }
            set { _Readonly = value; OnReadOnlyChangeEvent(); }
        }

        [CategoryAttribute("Appearance")]
        public Color ActiveBorderColor
        {
            get { return _ActiveBorderColor; }
            set { _ActiveBorderColor = value; }
        }

        [CategoryAttribute("Appearance")]
        public Color InactiveBorderColor
        {
            get { return _InactiveBorderColor; }
            set { _InactiveBorderColor = value; }
        }

        [CategoryAttribute("Appearance")]
        public Color ActiveButtonColor
        {
            get { return _ActiveButtonColor; }
            set { _ActiveButtonColor = value; }
        }

        [CategoryAttribute("Appearance")]
        public Color InactiveButtonColor
        {
            get { return _InactiveButtonColor; }
            set { _InactiveButtonColor = value; }
        }

        [CategoryAttribute("Appearance")]
        public Color ActiveArrowColor
        {
            get { return _ActiveArrowColor; }
            set { _ActiveArrowColor = value; }
        }

        [CategoryAttribute("Appearance")]
        public Color InactiveArrowColor
        {
            get { return _InactiveArrowColor; }
            set { _InactiveArrowColor = value; }
        }

        [Description("Determina si el valor del combo es requerido"), CategoryAttribute("Behavior")]
        public bool Required
        {
            get { return _Required; }
            set { _Required = value; }
        }

        public Color ReadOnlyColor
        {
            get { return _ReadOnlyColor; }
            set { _ReadOnlyColor = value; }
        }
        #endregion

        public override string ToString()
        {
            return "Custom Combo Properties";
        }
    }

}
