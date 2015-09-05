using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Security;
using System.Security.Permissions;
using System.Drawing.Design;
using System.ComponentModel.Design;

namespace Fwk.Bases.FrontEnd.Controls
{
    [ToolboxItem(true),
    ToolboxBitmap(typeof(FwkExceptionViewComponent))]
    public partial class FwkExceptionViewComponent : Component
    {

        #region [Properties]
        private FrmExceptionView _FwkMessageView;

        public System.Drawing.Color BackColor
        {
            get { return _FwkMessageView.BackColor; }
            set { _FwkMessageView.BackColor = value; }
        }
        public System.Drawing.Color TextMessageColor
        {
            get { return _FwkMessageView.TextMessageColor; }
            set { _FwkMessageView.TextMessageColor = value; }
        }
        public System.Drawing.Color TextMessageForeColorColor
        {
            get { return _FwkMessageView.TextMessageForeColor; }
            set { _FwkMessageView.TextMessageForeColor = value; }
        }
       
        /// <summary>
        /// Titulo
        /// </summary>
        public String Title
        {
            get { return _FwkMessageView.Text; }
            set { _FwkMessageView.Text = value; }
        }
        #endregion


        public FwkExceptionViewComponent()
        {
            InitializeComponent();
            _FwkMessageView = new FrmExceptionView();
            
        }

        public FwkExceptionViewComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            _FwkMessageView = new FrmExceptionView();
        }



        /// <summary>
        /// Muestra el mensaje
        /// </summary>
        /// <param name="pMessage">Mensaje a mostrar</param>
        /// <returns>DialogResult</returns>
        public DialogResult Show(String pSource, String pMessage, String pDetail)
        {
            _FwkMessageView.Source = pSource;
            _FwkMessageView.Message = pMessage;
            _FwkMessageView.Detail = pDetail;
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

            _FwkMessageView.Source = e.Source;
            if(e.InnerException != null  )
                _FwkMessageView.Detail = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e.InnerException);
            _FwkMessageView.Message = e.Message ;

            _FwkMessageView.ShowDialog();
            return _FwkMessageView.DialogResult;
        }

        /// <summary>
        /// Muestra el mensaje
        /// </summary>
        /// <param name="e">Exception</param>
        /// <returns>DialogResult</returns>
        public DialogResult Show(Exception[] e,string pSource)
        {

            _FwkMessageView.Source = pSource;
            _FwkMessageView.Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);

            _FwkMessageView.ShowDialog();
            return _FwkMessageView.DialogResult;
        }
    }




    


}
