using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Globalization;

namespace Fwk.Bases.FrontEnd.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FwkFlatTextBox :  System.Windows.Forms.TextBox
    {
        public FwkFlatTextBox()
        {
            InitializeComponent();
        }

        public FwkFlatTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        
        #region Declatarions
        public delegate void BorderChangeHandler(object sender, FlatBoxEventArgs e);
        public event BorderChangeHandler BorderChange;
        private const int WM_PAINT = 0xF;
        private Color _ActiveBorderColor = SystemColors.ControlDarkDark;
        private Color _InactiveBorderColor = SystemColors.ControlDark;
        private Color _BorderColor;
        private bool IAmOn;
        private TextBoxTypeEnum _TextBoxType;
        private string _AllowedCharacters;
        private bool _CapitalOnly = false;
        private bool _Required = false;
        private ErrorProvider errorProvider1;
        
        private string _RequiredErrorText;
        private String _NotAllowedCharactersErrorText = String.Empty;
        private Boolean _AllowBlankSpace = true;

       
        #endregion


        #region --[Propiedades]--
        [CategoryAttribute("Factory Tools"), Description("Indica si se adminen espacios en blanco ")]
        public Boolean AllowBlankSpace
        {
            get { return _AllowBlankSpace; }
            set { _AllowBlankSpace = value; }
        }
        [CategoryAttribute("Factory Tools"), Description("Indica si el control es obligatorio o no. Si lo establece a true tambien espesifique el valor de RequiredErrorText ")]
        public bool Required
        {
            get { return _Required; }
            set { _Required = value; }
        }

        [CategoryAttribute("Factory Tools"), Description("Mensaje de error que se muestra cuando el campo es requerido y no se establecio valor alguno")]
        public string RequiredErrorText
        {
            get { return _RequiredErrorText; }
            set { _RequiredErrorText = value; }
        }
        [CategoryAttribute("Factory Tools"), Description("Active Border Color")]
        public Color ActiveBorderColor
        {
            get { return _ActiveBorderColor; }
            set { _ActiveBorderColor = value; }
        }
        [CategoryAttribute("Factory Tools"), Description("Inactive Border Color")]
        public Color InactiveBorderColor
        {
            get { return _InactiveBorderColor; }
            set { _InactiveBorderColor = value; }
        }
        [CategoryAttribute("Factory Tools"), Description("Tipo de text box")]
        public TextBoxTypeEnum TextBoxType
        {
            get
            { return _TextBoxType; }
            set
            {
                _TextBoxType = value;
                UpdateControl();
            }
        }
        [CategoryAttribute("Factory Tools"), Description("Conjunto de caracteres permitidos. Si esta propiedad es Empty no se valida")]
        public string AllowedCharacters
        {
            get
            { return _AllowedCharacters; }
            set
            { _AllowedCharacters = value; }
        }

        [CategoryAttribute("Factory Tools"), Description("mensaje de error que se muestra cuando el campo es requerido y no se establecio valor alguno")]
        public string NotAllowedCharactersErrorText
        {
            get { return _NotAllowedCharactersErrorText; }
            set { _NotAllowedCharactersErrorText = value; }
        }
        [CategoryAttribute("Factory Tools"), Description("Solo capital")]
        public bool CapitalOnly
        {
            get
            { return _CapitalOnly; }
            set
            { _CapitalOnly = value; }
        }

        Boolean _ErrorIconRightToLeft = false;
        /// <summary>
        ///  Indica la pocicion del icono de error
        /// </summary>

        [CategoryAttribute("Factory Tools"), Description("Indica la pocicion del icono de error")]
        public Boolean ErrorIconRightToLeft
        {
            get
            {

                return _ErrorIconRightToLeft;
            }
            set
            { _ErrorIconRightToLeft = value; }
        }
        [BrowsableAttribute(false)]
        public bool IsON
        {
            get { return IAmOn; }
        }
        #endregion

       
        public void ShareFocus(bool Focus)
        {
            IAmOn = Focus;
            this.Invalidate();
        }


        #region --[protected override void On]--
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            IAmOn = true;
            this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            IAmOn = false;
            this.Invalidate();
        }
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            IAmOn = true;
            this.Invalidate();
        }
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            IAmOn = false;
            this.Invalidate();
        }
        protected override void OnMouseHover(EventArgs e)
        {
           base.OnMouseHover(e);
            IAmOn = true;
            this.Invalidate();
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (_TextBoxType == TextBoxTypeEnum.Nothing)
                return;

            if (e.KeyChar == ControlChars.Back)
            {
                e.Handled = false;
                return;
            }

            if (!(_AllowedCharacters.IndexOf(e.KeyChar, 0) >= 0) && e.KeyChar != ControlChars.Back
                && e.KeyChar != (char)24
                && e.KeyChar != (char)22
                && e.KeyChar != (char)3
                && e.KeyChar != (char)9
                && (!_AllowBlankSpace && e.KeyChar == (char)32)) // si se permiten espacios en blanco y la tecla es space permitir
            {
                e.Handled = true;
                return;
            }

            if (_CapitalOnly)
                e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT)
            {
                Graphics g = this.CreateGraphics();
                Rectangle Cliente = this.ClientRectangle;

                if (IAmOn == true)
                { _BorderColor = _ActiveBorderColor; }
                else
                { _BorderColor = _InactiveBorderColor; }

                g.DrawRectangle(new Pen(_BorderColor), 0, 0, Cliente.Width - 1, Cliente.Height - 1);

                g.Dispose();

                if (BorderChange != null)
                {
                    BorderChange(this, new FlatBoxEventArgs(_BorderColor, IAmOn));
                }
            }
        }
        ///// <summary>
        ///// Setea si es de solo lectura el control.
        ///// </summary>
        //public new bool ReadOnly
        //{
        //    set
        //    {
        //        //if (value == true)
        //        //{
        //        //    this.BackColor = System.Drawing.Color.FromArgb(230, 231, 253);
        //        //}
        //        //else
        //        //{
        //        //    this.BackColor = System.Drawing.Color.White;

        //        //}
        //        base.ReadOnly = value;
        //    }
        //    get
        //    {
        //        return base.ReadOnly;
        //    }

        //}
        /// <summary>
        /// Sobrecarga de la propiedad Text para quitar los espacios del comienzo y el final del String.
        /// </summary>
        /// <Author>cbauque</Author>
        /// <CreateDate>09/01/2008</CreateDate>
        public new string Text
        {
            set
            {
                base.Text = value;
            }
            get
            {
                if (base.Text != null)
                {
                    return base.Text.Trim();
                }
                else
                {
                    return String.Empty;
                }
            }
        }
        #endregion



        private void UpdateControl()
        {
            switch (_TextBoxType)
            {
                case TextBoxTypeEnum.AlphaNumericNotAllowSimbols:
                    _AllowedCharacters = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
                    break;

                case TextBoxTypeEnum.Numeric:
                    _AllowedCharacters = "0123456789";
                    break;

                case TextBoxTypeEnum.NumericDecimal:
                    _AllowedCharacters = "0123456789" + CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
                    break;

                case TextBoxTypeEnum.NumericDecimalWhitchPoint:
                    _AllowedCharacters = "0123456789.";
                    break;
            }
        }

        private void FwkFlatTextBox_Validating(object sender, CancelEventArgs e)
        {

            ValidateValue();

        }

        private bool ValidateValue()
        {
            errorProvider1.RightToLeft = _ErrorIconRightToLeft;
            if (_Required)
            {
                if (String.IsNullOrEmpty(this.Text))
                {
                    errorProvider1.SetError(this, _RequiredErrorText);
                    return false;

                }
            }
            if (!String.IsNullOrEmpty(_NotAllowedCharactersErrorText))
            {
                foreach (char s in this.Text.ToCharArray())
                {
                    if (_NotAllowedCharactersErrorText.Contains(s.ToString()))
                    {
                        errorProvider1.SetError(this, _NotAllowedCharactersErrorText);
                        return false;
                    }
                }
            }
            errorProvider1.Clear();
            return true;
        }
    }
}
