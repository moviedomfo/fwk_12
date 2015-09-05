using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Fwk.Bases.FrontEnd.Controls
{
    public partial class FrmExceptionView : FrmMsgBase
    {

        #region --[enums]--

        private enum FormExpansion
        {
            Show = 0,
            Hide = 1
        };

        #endregion

        #region --[Properties]--

        private const int _HeightExpanded = 332;
        private const int _HeightCollapsed = 176;
        private FormExpansion _Detalle = FormExpansion.Show;
        private string _Source = String.Empty;
        private string _Detail = String.Empty;

        [CategoryAttribute("Factory Tools"), Description("")]
        public string Source
        {
            get { return _Source; }
            set { _Source = value; }
        }
        
        [CategoryAttribute("Factory Tools"), Description("")]
        public string Detail
        {
            get { return _Detail; }
            set { _Detail = value; }
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
        #endregion

        #region --[constructor]--

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSource"></param>
        /// <param name="pMessage"></param>
        /// <param name="pDetail"></param>
        public FrmExceptionView()
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
        public static DialogResult Show(String pSource, String pMessage, String pDetail, String pTitle)
        {
            using (FrmExceptionView wfrmMessageView = new FrmExceptionView())
            {
                wfrmMessageView.Text = pTitle;
                wfrmMessageView.Message = pMessage;
                wfrmMessageView.Source = pSource;
                wfrmMessageView.Detail = pDetail;
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
        public static DialogResult Show(Exception e, String pTitle)
        {

            using (FrmExceptionView wfrmMessageView = new FrmExceptionView())
            {

                wfrmMessageView.Detail = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);
                wfrmMessageView.Message = e.Message;
                wfrmMessageView.Source = e.Source;

                if (!String.IsNullOrEmpty(pTitle))
                    wfrmMessageView.Text = pTitle;
                wfrmMessageView.ShowDialog();
                return wfrmMessageView.DialogResult;
            }
        }
        #endregion

        #region --[event handlers]--

        private void FrmTechnicalMsg_Load(object sender, EventArgs e)
        {

            txtSource.Text = _Source;
            txtMessage.Text = base.Message;
            txtDetail.Text = _Detail;
         
        }

        private void mnuExpandir_Click(object sender, EventArgs e)
        {
            ShowDetail();
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void mnuCopiar_Click(object sender, EventArgs e)
        {
            CopyToClipBoard();
        }

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuMail_Click(object sender, EventArgs e)
        {
            SendMail();
        }
        
        #endregion

        #region --[toolbar methods]--

        private void ShowDetail()
        {
            if (_Detalle == FormExpansion.Show)
            {
                this.Height = _HeightExpanded;
                mnuExpandir.ToolTipText = "Ocultar detalle...";
                mnuExpandir.Image = Fwk.Bases.FrontEnd.Properties.Resources.MaxImage;//imgFormExpansion.Images[1];
                _Detalle = FormExpansion.Hide;
            }
            else
            {
                this.Height = _HeightCollapsed;
                mnuExpandir.ToolTipText = "Ver detalle...";
                mnuExpandir.Image = Fwk.Bases.FrontEnd.Properties.Resources.MinImage;
                _Detalle = FormExpansion.Show;
            }
        }

        private void SaveAs()
        {
            FileStream wFs = null;
            string wPath = String.Empty;
            SaveFileDialog wDlg = new SaveFileDialog();
            wDlg.Filter = "Documentos de Texto|*.txt";

            if (wDlg.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            wFs = File.OpenWrite(wDlg.FileName);

            StreamWriter wSw = new StreamWriter(wFs);
            wSw.Write(txtDetail.Text);
            wSw.Close();
            wFs.Close();
        }

        private void CopyToClipBoard()
        {
            Clipboard.SetDataObject(txtDetail.Text, true);
        }

        private void SendMail()
        {
            System.Diagnostics.Process.Start("mailto:?body=" + txtDetail.Text);
        }
        #endregion
    }
}