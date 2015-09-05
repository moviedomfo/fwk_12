using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Fwk.Bases.FrontEnd.Properties;

namespace Fwk.Bases.FrontEnd.Controls
{
    /// <summary>
    /// Componente de visualizacion de mensajes personalizados.-
    /// 
    /// </summary>
    
    //[ToolboxBitmap(@"C:\Projects\Fwk 3.0\Icons\Usercontrol_MessageView.bmp")]
    //[ToolboxBitmap(typeof(FwkMessageViewComponent), "Usercontrol_MessageView")]
    //[ToolboxBitmap(typeof(FwkMessageViewComponent), "Resources.Usercontrol_MessageView.bmp")]
    [ToolboxItem(true), ToolboxBitmap(typeof(FwkMessageViewComponent), "FwkMessageViewComponent")]
    public partial class FwkMessageViewComponent : Component
    {
        #region [Properties]
        private FwkMessageView _FwkMessageView;


        /// <summary>
        /// Icono a mostrar
        /// </summary>
        [CategoryAttribute("Factory Tools"), Description("Icono a mostrar")]
        public Image Icon
        {
            get { return _FwkMessageView.Icon; }
        }
        //Fwk.Bases.FrontEnd.Controls.MessageBoxIcon _MessageBoxIcon;

        /// <summary>
        /// Icono a mostrar
        /// </summary>
        [CategoryAttribute("Factory Tools"), Description("Tipo Icono a mostrar")]
        public Fwk.Bases.FrontEnd.Controls.MessageBoxIcon MessageBoxIcon
        {
            get { return _FwkMessageView.MessageBoxIcon; }
            set { _FwkMessageView.MessageBoxIcon = value; }
        }


        
        /// <summary>
        /// Tamaño del icono
        /// </summary>
        [CategoryAttribute("Factory Tools"), Description("Tamaño del icono")]
        public Fwk.Bases.FrontEnd.Controls.IconSize IconSize
        {
            get { return _FwkMessageView.IconSize; }
            set
            {
                _FwkMessageView.IconSize = value;
            
            }
        }

        /// <summary>
        /// Color de fondo del FwkMessageView .-
        /// </summary>
        [CategoryAttribute("Factory Tools"), Description("Color de fondo del FwkMessageView ")]
        public System.Drawing.Color BackColor
        {
            get { return _FwkMessageView.BackColor; }
            set { _FwkMessageView.BackColor = value; }
        }
        /// <summary>
        /// Color de fondo del mensaje. Color del text box.-
        /// </summary>
        [CategoryAttribute("Factory Tools"), Description("Color de fondo del mensaje. Color del text box.-")]
        public System.Drawing.Color TextMessageColor
        {
            get { return _FwkMessageView.TextMessageColor; }
            set { _FwkMessageView.TextMessageColor = value; }
        }
        /// <summary>
        /// Color del texto del mensaje
        /// </summary>
        [CategoryAttribute("Factory Tools"), Description("Color del texto del mensaje.-")]
        public System.Drawing.Color TextMessageForeColor
        {
            get { return _FwkMessageView.TextMessageForeColor; }
            set { _FwkMessageView.TextMessageForeColor = value; }
        }
        MessageBoxButtons _MessageBoxButtons;
        /// <summary>
        /// Espesifica que conjunto de botones se mostraran.
        /// </summary>
        [CategoryAttribute("Factory Tools"), Description("Espesifica que conjunto de botones se mostraran.")]
        public MessageBoxButtons MessageBoxButtons
        {
            get { return _MessageBoxButtons; }
            set { _MessageBoxButtons = value; }
        }

       
        /// <summary>
        /// Titulo
        /// </summary>
        [CategoryAttribute("Factory Tools"), Description("Titulo")]
        public String  Title
        {
            get { return _FwkMessageView.Text ; }
            set { _FwkMessageView.Text = value; }
        }
        #endregion

        #region Constructor
        public FwkMessageViewComponent()
        {
            InitializeComponent();
            _FwkMessageView = new FwkMessageView();
   
        }

        public FwkMessageViewComponent(IContainer container)
        {
            container.Add(this);


            InitializeComponent();
            _FwkMessageView = new FwkMessageView();
        }

        #endregion

        /// <summary>
        /// Muestra el mensaje
        /// </summary>
        /// <param name="pMessage">Mensaje a mostrar</param>
        /// <returns>DialogResult</returns>
        public DialogResult Show(String pMessage)
        {

            _FwkMessageView.Message = pMessage;
   
            _FwkMessageView.SetButtonsVisibility(_MessageBoxButtons);
            _FwkMessageView.ShowDialog();

            return _FwkMessageView.DialogResult;
        }

        /// <summary>
        /// Muestra el mensaje
        /// </summary>
        /// <param name="e">Exception</param>
        /// <returns>DialogResult</returns>
        public DialogResult Show(Exception e)
        {
  
            _FwkMessageView.SetButtonsVisibility(_MessageBoxButtons);

            _FwkMessageView.Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);

      
            _FwkMessageView.ShowDialog();
            return _FwkMessageView.DialogResult;
        }
    }
}
