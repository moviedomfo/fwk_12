using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using Fwk.Bases.FrontEnd.Controls.FwkCombo.Design;

namespace Fwk.Bases.FrontEnd.Controls
{
    
    /// <summary>
    /// ComboBox plano y sensible al tacto.
    /// </summary>
    [ToolboxItem(true), System.Drawing.ToolboxBitmap(typeof(FwkFlatComboBox),"FwkFlatComboBox")]
    public partial class FwkFlatComboBox : ComboBox
    {
        
        #region Private members 
        public event BorderChangeHandler BorderChange;
        private  const int WM_PAINT = 0xF;
        private bool _IAmOn;
        private Color _BorderColor;
        private Color _ArrowColor;
        private Color _ButtonColor;
        private IEntity _SelectedEntity;
        private Color _ActiveBorderColor = SystemColors.ControlDarkDark;
        private Color _InactiveBorderColor = SystemColors.ControlDark;
        private Color _ActiveArrowColor = SystemColors.ControlDarkDark;
        private Color _InactiveArrowColor = SystemColors.ControlDark;
        private Color _ActiveButtonColor = SystemColors.ControlDark;
        private Color _InactiveButtonColor = SystemColors.Control;
        private Color _ReadOnlyColor = SystemColors.Control;
        private Color _BackColor = SystemColors.ControlText;
        private Boolean _AutoComplete;
        
        private IContainer components;
        private Boolean _KeysEnabledToAutoComplete;

        private string _RequiredErrorText;
        private Boolean _Required;
        private Boolean _ReadOnly;
        Boolean _ErrorIconRightToLeft = false;

        private String _NullTextValue;


        private Boolean _AllowNullTextValue = false;
        
        #endregion

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

        #region Properties
        
        [Browsable(false)]
        public  IEntity SelectedEntity
        {
            get { return _SelectedEntity; }
        }
        [BrowsableAttribute(false)]
        public bool IsON
        {
            get { return _IAmOn; }
        }
       

        /// <summary>
        /// Determina si el valor del combo es requerido
        /// </summary>
        [CategoryAttribute("Factory Tools"), Description("Determina si el valor del combo es requerido")]
        public bool Required
        {
            get { return _Required; }
            set { _Required = value; }
        }
        /// <summary>
        /// Texto que se muestra en el mensaje de error cuando el campo es requerido.-
        /// </summary>
        [CategoryAttribute("Factory Tools"), Description("Texto que se muestra en el mensaje de error cuando el campo es requerido.-")]
        public string RequiredErrorText
        {
            get { return _RequiredErrorText; }
            set { _RequiredErrorText = value; }
        }


        /// <summary>
        /// BackColor
        /// </summary>
        [Browsable(false)]
        [CategoryAttribute("Factory Tools")]
        public override Color BackColor
        {
            get { return _BackColor; }
            set { _BackColor = value; }
        }

        [CategoryAttribute("Factory Tools"), Description("Determina si el combo se autocompleta y admite entradas nuevas")]
        public bool AutoComplete
        {
            get { return _AutoComplete; }
            set { _AutoComplete = value; OnAutoCompleteChangeEvent(); }
        }

        /// <summary>
        /// Setea u Obtiene si el control es solo lectura.
        /// </summary>
        [CategoryAttribute("Factory Tools"), Description("Setea u obtiene si el control es solo lectura.")]
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value; OnReadOnlyChangeEvent();
                ComboPropertiesSet();
            }
        }

        [CategoryAttribute("Factory Tools"), Description("Color del borde del combo cuando esta activo o tiene el foco")]
        public Color ActiveBorderColor
        {
            get { return _ActiveBorderColor; }
            set { _ActiveBorderColor = value; }
        }

        [CategoryAttribute("Factory Tools"), Description("Color del borde del combo cuando esta inactivo o no tiene el foco")]
        public Color InactiveBorderColor
        {
            get { return _InactiveBorderColor; }
            set { _InactiveBorderColor = value; }
        }

        [CategoryAttribute("Factory Tools"), Description("Color del boton del combo cuando esta activo o tiene el foco")]
        public Color ActiveButtonColor
        {
            get { return _ActiveButtonColor; }
            set { _ActiveButtonColor = value; }
        }

        [CategoryAttribute("Factory Tools"), Description("Color del boton del combo cuando esta inactivo o no tiene el foco")]
        public Color InactiveButtonColor
        {
            get { return _InactiveButtonColor; }
            set { _InactiveButtonColor = value; }
        }

        [CategoryAttribute("Factory Tools"), Description("Color de flecha del combo cuando esta activo o tiene el foco")]
        public Color ActiveArrowColor
        {
            get { return _ActiveArrowColor; }
            set { _ActiveArrowColor = value; }
        }

        [CategoryAttribute("Factory Tools"), Description("Color de flecha del combo cuando este esta en modo inactivo o no tiene el foco")]
        public Color InactiveArrowColor
        {
            get { return _InactiveArrowColor; }
            set { _InactiveArrowColor = value; }
        }


        [CategoryAttribute("Factory Tools"), Description("Color que se muestra cuando el combo esta en modo ReadOnly = True")]
        public Color ReadOnlyColor
        {
            get { return _ReadOnlyColor; }
            set
            {
                _ReadOnlyColor = value;
                ComboPropertiesSet();
            }
        }
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

        /// <summary>
        ///  Indica el texto que se muestra en el combo cuando no se selecciono ningun valor
        /// </summary>
        [CategoryAttribute("Factory Tools"), Description("Indica el texto que se muestra en el combo cuando no se selecciono ningun valor")]
        public String NullTextValue
        {
            get { return _NullTextValue; }
            set { _NullTextValue = value; }
        }
        /// <summary>
        ///  Determina si se permite agregar un valor al combo que indique seleccion nula.-
        /// </summary>
        [CategoryAttribute("Factory Tools"), Description("AllowEmptyTextValue")]
        public Boolean AllowEmptyTextValue
        {
            get { return _AllowNullTextValue; }
            set { _AllowNullTextValue = value; }
        }
        #endregion

       
        public FwkFlatComboBox()
        {
            InitializeComponent();

            base.DropDownStyle = ComboBoxStyle.DropDown;

            //_ReadOnlyChangeEvent += new ComboProperties.ReadOnlyChangeHandler(_ComboProperties_ReadOnlyChangeEvent);
            //_AutoCompleteChangeEvent += new ComboProperties.AutoCompleteChangeHandler(_ComboProperties_AutoCompleteChangeEvent);

            //_BackColor = this.BackColor;
        }

        
        #region protected override void On
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _IAmOn = true;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _IAmOn = false;
            this.Invalidate();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            _IAmOn = true;
            this.Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            _IAmOn = false;
            ValidateValue();
            this.Invalidate();
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            _IAmOn = true;
            this.Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseHover(e);
            _IAmOn = true;
            this.Invalidate();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            //No aplicamos el autocompletado 
            //si las teclas pulsadas son Suprimir o Borrar
            _KeysEnabledToAutoComplete = ((e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back));
            base.OnKeyDown(e);

        }


        protected override void OnDataSourceChanged(EventArgs e)
        {
            base.OnDataSourceChanged(e);

            //if (_AllowNullTextValue)
            // this.AddItemsCore(_NullTextValue);
        }


        /// <summary>
        /// Posiciona el combo  de acuerdo al texto pasado por parametros.
        /// </summary>
        /// <param name="pDisplayText"></param>
        public void PosicionarCombo(string pDisplayText)
        {
            int wiIndex;

            wiIndex = this.FindStringExact(pDisplayText);

            if (wiIndex > -1)
            {
                this.SelectedIndex = wiIndex;
                this.Text = pDisplayText;
            }
            else
            {
                this.Text = String.Empty;

            }
        }



        protected override void OnTextChanged(EventArgs e)
        {
            if (_AutoComplete && _KeysEnabledToAutoComplete)
            {
                string Texto = this.Text;
                //FindString localiza el primer ítem de la lista
                //cuyas primeras letras coinciden con las de su argumento
                //Está claro que es una función pensada 
                //para autocompletar el ComboBox.
                int Index = this.FindString(Texto);
                if (Index >= 0)
                {
                    //Al cargar la caja de texto con el ítem localizado
                    //se dispara otra vez el evento OnTextChanged
                    //o sea, este procedimiento,
                    //que volvería a cambiar el contenido de la caja de texto
                    //aunque fuera con el mismo texto,
                    //lo cual volvería a disparar el evento OnTextChanged
                    //formándose un ciclo sin fin.
                    //Por eso hay que crear una variable 
                    //de tipo booleano que haga de semáforo.
                    _AutoComplete = false;
                    this.SelectedIndex = Index;
                    if (this.SelectedValue != null)
                        if (this.SelectedItem != null && this.SelectedValue.GetType().BaseType == (typeof(Entity)))
                            _SelectedEntity = (IEntity)this.SelectedValue;
                    _AutoComplete = true;

                    //Al ir autocompletando mantenemos seleccionado
                    //el fragmento que no se ha autocompletado.
                    //Esto permite autocompletar el ítem entero
                    //teclando sólo las letras de la palabra.
                    this.Select(Texto.Length, this.Text.Length);
                }
            }
            base.OnTextChanged(e);
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {

            if (this.SelectedValue != null && this.SelectedValue.GetType().BaseType == (typeof(Entity)))
                _SelectedEntity = (IEntity)this.SelectedValue;

            base.OnSelectedIndexChanged(e);
        }
        #endregion

        

        
      

        public void ShareFocus(bool Focus)
        {
            _IAmOn = Focus;
            this.Invalidate();
        }

        public bool HasItems()
        {
            if (this.Items.Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       

    }





}