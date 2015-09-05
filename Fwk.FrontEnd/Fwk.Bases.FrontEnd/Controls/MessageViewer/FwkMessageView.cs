using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Bases.FrontEnd.Controls
{

    public partial class FwkMessageView : Form
    {
        #region [Properties]
        private Fwk.Bases.FrontEnd.Controls.MessageBoxIcon _MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Information;

        [CategoryAttribute("Factory Tools"), Description("Tipo icono a mostrar")]
        public Fwk.Bases.FrontEnd.Controls.MessageBoxIcon MessageBoxIcon
        {
            get { return _MessageBoxIcon; }
            set
            {
                _MessageBoxIcon = value;
                imgIcon.Image= Common.GetMessageBoxIcon(_MessageBoxIcon, _IconSize);
            }
        }

       
        [CategoryAttribute("Factory Tools"), Description("Icono a mostrar")]
        public Image Icon
        {
            get { return imgIcon.Image; }
        }
        IconSize _IconSize = IconSize.Small;
        /// <summary>
        /// Tamaño del icono
        /// </summary>
        [CategoryAttribute("Factory Tools"), Description("Tamaño del icono"), DefaultValue(IconSize.Small)]
        public Fwk.Bases.FrontEnd.Controls.IconSize IconSize
        {
            get { return _IconSize; }
            set
            {
                _IconSize = value;
                if (_MessageBoxIcon == MessageBoxIcon.None)
                    imgIcon.Image = null;
                else
                    imgIcon.Image = Common.GetMessageBoxIcon(_MessageBoxIcon, _IconSize);
            }
        }
        /// <summary>
        ///Color del texbox
        /// </summary>
        [CategoryAttribute("Factory Tools"), Description("")]
        public Color TextMessageColor
        {
            set { txtMessage.BackColor = value; }
            get { return txtMessage.BackColor; }
        }

        /// <summary>
        ///Color de texto del mensaje
        /// </summary>
        [CategoryAttribute("Factory Tools"), Description("")]
        public Color TextMessageForeColor
        {
            set { txtMessage.ForeColor = value; }
            get { return txtMessage.ForeColor; }
        }
        /// <summary>
        /// Mensaje a mostraR
        /// </summary>
        [CategoryAttribute("Factory Tools"), Description("")]
        public string Message
        {
            set { txtMessage.Text = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [CategoryAttribute("Factory Tools"), Description("")]
        public bool BtnOkVisible
        {
            set { btnOk.Visible = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [CategoryAttribute("Factory Tools"), Description("")]
        public bool BtnCancelVisible
        {
            set { btnCancel.Visible = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        [CategoryAttribute("Factory Tools"), Description("")]
        public bool BtnYesVisible
        {
            set { btnYes.Visible = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        [CategoryAttribute("Factory Tools"), Description("")]
        public bool BtnNoVisible
        {
            set { btnNo.Visible = value; }
        }

        #endregion

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        /// 
        public FwkMessageView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Muestra el mensaje
        /// </summary>
        /// <param name="pMessage">Mensaje a mostrar</param>
        /// <param name="pMessageBoxButtons">Specifies constants defining which buttons to display on a System.Windows.Forms.MessageBox.</param>
        /// <param name="MessageBoxIcon">Specifies constants defining which information to display.</param>
        /// <returns>DialogResult</returns>
        public static DialogResult Show(String pMessage, String pTitle,
            MessageBoxButtons pMessageBoxButtons, MessageBoxIcon pIcon)
        {


            using (FwkMessageView wfrmMessageView = new FwkMessageView())
            {
                wfrmMessageView.Text = pTitle;
                wfrmMessageView.Message = pMessage;
                wfrmMessageView.MessageBoxIcon = pIcon;

                wfrmMessageView.SetButtonsVisibility(pMessageBoxButtons);


                wfrmMessageView.ShowDialog();

                return wfrmMessageView.DialogResult;
            }
        }
        /// <summary>
        /// Muestra el mensaje
        /// </summary>
        /// <param name="pMessage">Mensaje a mostrar</param>
        /// <param name="pMessageBoxButtons">Specifies constants defining which buttons to display on a System.Windows.Forms.MessageBox.</param>
        /// <param name="MessageBoxIcon">Specifies constants defining which information to display.</param>
        /// <returns>DialogResult</returns>
        public static DialogResult Show(Exception e, String pTitle,
            MessageBoxButtons pMessageBoxButtons, MessageBoxIcon? pIcon)
        {


            using (FwkMessageView wfrmMessageView = new FwkMessageView())
            {
                wfrmMessageView.Text = pTitle;

                wfrmMessageView.Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);

                if (pIcon == null)
                    pIcon = MessageBoxIcon.Error;

                wfrmMessageView.MessageBoxIcon = pIcon.Value;

                wfrmMessageView.SetButtonsVisibility(pMessageBoxButtons);


                wfrmMessageView.ShowDialog();

                return wfrmMessageView.DialogResult;
            }
        }


        public void SetButtonsVisibility(MessageBoxButtons pMessageBoxButtons)
        {
            SetButtonsVisibleFalse();
            switch (pMessageBoxButtons)
            {
                case MessageBoxButtons.OK:
                    {
                        this.BtnOkVisible = true;
                        break;
                    }
                case MessageBoxButtons.OKCancel:
                    {
                        this.BtnOkVisible = true;
                        this.BtnCancelVisible = true;
                        break;
                    }
                case MessageBoxButtons.YesNo:
                    {
                        this.BtnYesVisible = true;
                        this.BtnNoVisible = true;
                        break;
                    }
                case MessageBoxButtons.YesNoCancel:
                    {
                        this.BtnYesVisible = true;
                        this.BtnNoVisible = true;
                        this.BtnCancelVisible = true;
                        break;
                    }
            }
        }

        #region btn -  events

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void SetButtonsVisibleFalse()
        {
            this.BtnOkVisible = false;
            this.BtnCancelVisible = false;
            this.BtnYesVisible = false;
            this.BtnNoVisible = false;

        }
        #endregion

       
    }
}