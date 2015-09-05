using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Fwk.Exceptions;

namespace VivaldiSite
{
    public partial class ErrorMessageViewer : System.Web.UI.Page
    {
        #region Members

        Exception _CurrentException;
        private HttpStatusCode _ErrorCode;

        #endregion

        #region Properties

        public HttpStatusCode ErrorCode
        {
            get { return _ErrorCode; }
            set { _ErrorCode = value; }
        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["code"] != null)
                _ErrorCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), Request["code"], true);

            this.LoadException();
        }

        #endregion

        #region Methods

        private void LoadException()
        {
            try
            {
                _CurrentException = (Exception)Session["Error"];
            }
            catch
            {
                _CurrentException = new TechnicalException("Ocurrio un error pero no se puede deducir el error producido. Contacte el equipo técnico para reportarlo");
            }
            this.lblErrorStack.Visible = false;
            this.lblErrorDetails.Visible = false;


            if (_CurrentException != null)
            {
                #region [Exceptions específicas]

                this.lblErrorMessage.Text = _CurrentException.Message;
                this.lblErrorStack.Text = _CurrentException.Source + System.Environment.NewLine + _CurrentException.StackTrace;
                FwkExceptionTypes t = Fwk.Exceptions.ExceptionHelper.GetFwkExceptionTypes(_CurrentException);
                switch (t)
                {
                    case FwkExceptionTypes.FunctionalException:
                        lblErrorTitle.Text = "Error Funcional";
                        break;

                    case FwkExceptionTypes.TechnicalException:
                        lblErrorTitle.Text = "Error Técnico";
                        break;
                }

                #endregion
            }
            else
            {
                switch (_ErrorCode)
                {
                    case HttpStatusCode.NotFound:
                        lblErrorTitle.Text = "Error 404";
                        this.lblErrorMessage.Text = "Página no encontrada.";
                        this.lblErrorStack.Text = "La página a la que está intentando ingresar no se encuentra disponible.";
                        break;

                    default:
                        lblErrorTitle.Text = "Error Desconocido";
                        this.lblErrorMessage.Text = "Error desconocido. Por favor, contáctese con el área de Soporte Técnico de BigBang Social Media.";
                        this.lblErrorStack.Text = "N/A.";
                        break;
                }
            }

            if (this.lblErrorStack.Text.Trim().Length > 0)
            {
                this.lblErrorStack.Visible = true;
                this.lblErrorDetails.Visible = true;
            }
        }

        #endregion
    }
}