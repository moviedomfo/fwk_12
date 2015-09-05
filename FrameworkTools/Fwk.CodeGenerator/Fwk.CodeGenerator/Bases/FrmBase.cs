using System;
using System.Threading;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;


using Fwk.DataBase;


namespace Fwk.CodeGenerator
{


    internal delegate void OnConnectionSourceChangeHandler();
    public partial class FrmBase : Fwk.Controls.Win32.DockContent
    {

        #region privete members


        private CodeGenerator.MessageViewWait _MessageViewWait;
        private Fwk.DataBase.Metadata _Metadata = null;
        public Boolean MessageViewVisible = false;
        private Boolean _ConnectionOk = false;
        private Boolean _CnnStringChange = false;
        private LastAccessStorage _LastAccessStorage = null;
        private TemplateSettingObject _TemplateSettingObject = null;
        /// <summary>
        /// Indica si el programa se conectará a una base de datos 
        /// o leera la estructura de datos desde un archivo.
        /// Esta opción se configura desde el App.Config.
        /// </summary>
        private bool LoadMetaDataFromXML = false;
        /// <summary>
        /// En caso de que LoadMetaDataFromXML = true, indica si el archivo ya ha sido cargado.        
        /// </summary>
        private bool IsLoadedMetaDataFromXML = false;
        /// <summary>
        /// Extención del archivo con la metadata para leer..
        /// </summary>
        private const string SZ_METADATAFILEEXTENSION = @"xml";

        public String XSDREQ
        {
            get { return _LastAccessStorage.LastAccess.LastISVC.XSDReqPath; }
            set { _LastAccessStorage.LastAccess.LastISVC.XSDReqPath = value; }
        }


        public String XSDRES
        {
            get { return _LastAccessStorage.LastAccess.LastISVC.XSDResPath; }
            set { _LastAccessStorage.LastAccess.LastISVC.XSDResPath = value; }
        }
        [Browsable(false)]
        public LastAccessStorage LastAccessStorage
        {
            get { return _LastAccessStorage; }
            set { _LastAccessStorage = value; }
        }
        [Browsable(false)]
        public Fwk.DataBase.Metadata Metadata
        {
            get { return _Metadata; }
            set { _Metadata = value; }

        }
        [Browsable(false)]
        public TemplateSettingObject TemplateSettingObject
        {
            get { return _TemplateSettingObject; }
            set { _TemplateSettingObject = value; }
        }


        public CodeGeneratorCommon.SelectedObject _SelectedObject = CodeGeneratorCommon.SelectedObject.Tables;

        public string DataBaseName
        {
            get { return _Metadata.DataBaseName; }
        }


        public string ServerName
        {
            get { return _Metadata.ServerName; }

        }

        public string UserName
        {
            get { return _Metadata.UserName; }

        }


        protected Boolean CnnStringChange
        {
            get { return _CnnStringChange; }
            set { _CnnStringChange = value; }
        }
        protected Boolean ConnectionOk
        {
            get { return _ConnectionOk; }
            set { _ConnectionOk = value; }
        }
     
        public CnnString CnnString
        {
            get { return _Metadata.CnnString; }
        }

        protected string SchemaPath
        {
            get { return _LastAccessStorage.LastAccess.LastISVC.XSDPath; }
            set { _LastAccessStorage.LastAccess.LastISVC.XSDPath = value; }
        }


        protected void ShowConnection()
        {
            if (LoadMetaDataFromXML)
            {
                LoadMetaDataFromXml();
            }
            else
            {
                ConnectionForm oConnectionForm = new ConnectionForm();
                oConnectionForm.ShowDialog();

                _ConnectionOk = oConnectionForm.ConnectionOK;
                _CnnStringChange = oConnectionForm.CnnStringChange;
                //Actualizo la coneccion por si se modifico por medio de el componente de coneccion
                _Metadata.RefreshConnection();
                
                //TODO: Ver ReloadObjects
                _Metadata.ReloadObjects = true;
            }
        }

        /// <summary>
        /// Selecciona el archivo XML que contiene el objeto 
        /// Metadata para deserializarlo.
        /// </summary>        
        protected void LoadMetaDataFromXml()
        {
            OpenFileDialog dlgOpenFile = new OpenFileDialog();
            dlgOpenFile.AddExtension = true;
            dlgOpenFile.Multiselect = false;
            dlgOpenFile.Filter = string.Format("GenCode Data Model File|*.{0}", SZ_METADATAFILEEXTENSION);

            if (dlgOpenFile.ShowDialog() != DialogResult.OK)
                return;

            this.LoadMetaDataFromXml(dlgOpenFile.FileName);
            
        }

        /// <summary>
        /// Deserializa un objeto Metadata desde un archivo XML.
        /// </summary>
        /// <param name="pszFullPath">Ruta al archivo XML con el objeto Metadata serializado.</param>
        private void LoadMetaDataFromXml(string pszFullPath)
        {
            XmlSerializer oSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Fwk.DataBase.Metadata));

            Stream oFileStream = null;

            try
            {
                oFileStream = File.OpenRead(pszFullPath);

                _Metadata = (Fwk.DataBase.Metadata)oSerializer.Deserialize(oFileStream);

                this.ConnectionOk = true;

                IsLoadedMetaDataFromXML = true;

                this.RefreshMetadata();
            }
            catch (Exception ex)
            {
                
                MessageView.Show(ex);
            }
            finally
            {
                if (oFileStream != null)
                    oFileStream.Close();
                oFileStream = null;
                oSerializer = null;
            }
        }


        #endregion

        /// <summary>
        /// Formulario base de todos los generadores de codigo.-
        /// </summary>
        public FrmBase()
        {
            InitializeComponent();
            _LastAccessStorage = new LastAccessStorage();
            if (!Fwk.HelperFunctions.EnvironmentFunctions.IsInDesigntime())
            {
                if (!bool.TryParse(System.Configuration.ConfigurationManager.AppSettings["LoadMetaDataFromXML"].ToLower(), out LoadMetaDataFromXML))
                    LoadMetaDataFromXML = false;
            }
        }



        /// <summary>
        /// Carga el archivo LastAccess.xml
        /// </summary>
        protected void InitializeLastAccessSource()
        {


            try
            {

                _Metadata = new Fwk.DataBase.Metadata();


            }
            catch (Exception ex)
            {

                //Common.WriteEntryEventLog("Error en InitializeLastAccessSource. Puede que no este bien formado el archivo LastAcces.xml", ex,1000, System.Diagnostics.EventLogEntryType.Error);

   
                StringBuilder message = new StringBuilder("Error en InitializeLastAccessSource. ");
                message.Append(Environment.NewLine);

                message.Append(Environment.NewLine);

                message.Append("AllMessageException: " + Environment.NewLine + Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));


        

                MessageView.Show(message.ToString());
            }


        }


        private void Frm_Base_FormClosing(object sender, FormClosingEventArgs e)
        {
            _LastAccessStorage.Save();

        }

        /// <summary>
        /// Inicia LoadFromDAtaBaseWorker para que trabaje ebn un hilo diferente
        /// </summary>
        protected bool RefreshMetadata()
        {
            if (_Metadata.CnnString == null)
            {
                MessageView.Show("Debe establecer una conexión a la bace dedatos.-");
                return false;
            }
            //Si la metadata se abre desde un archivo, no ejecuto este método.
            if (LoadMetaDataFromXML)
            {
                if (!IsLoadedMetaDataFromXML)
                    this.LoadMetaDataFromXml();
                return true;
            }            


            try
            {
                if (!_Metadata.TestConnection())
                    return false;
            }
            catch (Exception ex)
            {
           
                MessageView.Show(ex);
                return false;
            }


            LoadFromDatabaseWorker _LoadFromDatabaseWorker = new LoadFromDatabaseWorker();

            _LoadFromDatabaseWorker.StartWorkEvent += new StartWorkHandler(_LoadFromDAtaBaseWorker_StartWorkEvent);
            _LoadFromDatabaseWorker.FinishtWorkEvent += new FinishWorkHandler(_LoadFromDatabaseWorker_FinishtWorkEvent);
            _LoadFromDatabaseWorker.FailtWorkEvent += new FailWorkHandler(_LoadFromDatabaseWorker_FailtWorkEvent);

            _LoadFromDatabaseWorker.SelectedObject = _SelectedObject;
            _LoadFromDatabaseWorker.Metadata = _Metadata;

            _LoadFromDatabaseWorker.Start();

            _LoadFromDatabaseWorker.StartWorkEvent -= new StartWorkHandler(_LoadFromDAtaBaseWorker_StartWorkEvent);
            _LoadFromDatabaseWorker.FinishtWorkEvent -= new FinishWorkHandler(_LoadFromDatabaseWorker_FinishtWorkEvent);
            return true;
        }

        void _LoadFromDatabaseWorker_FailtWorkEvent(Exception error)
        {
            if (this.InvokeRequired)
            {
                _LoadFromDAtaBaseWorker_FinishtWorkEventCallBack oDelegate =
                    new _LoadFromDAtaBaseWorker_FinishtWorkEventCallBack(this._LoadFromDatabaseWorker_FinishtWorkEvent);
                this.Invoke(oDelegate);
            }
            else
            {
                WaitViewHide();

            }

        }

        private delegate void X(String pMessage, String pOtherMsg);

        void _LoadFromDAtaBaseWorker_StartWorkEvent(String pMessage, String pOtherMsg)
        {
            if (this.InvokeRequired)
            {
                X oDelegate = new X(_LoadFromDAtaBaseWorker_StartWorkEvent);
                object[] args;
                args = new object[2] { pMessage, pMessage };
                this.Invoke(oDelegate, args);
            }
            else
            {
                if (pOtherMsg.Length == 0)
                {
                    _MessageViewWait = new MessageViewWait();
                    _MessageViewWait.OptionalMessage = pMessage;
                    _MessageViewWait.ShowDialog();
                }
                else
                {

                    MessageView.Show(pMessage + Environment.NewLine + pOtherMsg);
                }
            }
        }

        private delegate void _LoadFromDAtaBaseWorker_FinishtWorkEventCallBack();

        void _LoadFromDatabaseWorker_FinishtWorkEvent()
        {
            if (this.InvokeRequired)
            {
                _LoadFromDAtaBaseWorker_FinishtWorkEventCallBack oDelegate =
                    new _LoadFromDAtaBaseWorker_FinishtWorkEventCallBack(this._LoadFromDatabaseWorker_FinishtWorkEvent);
                this.Invoke(oDelegate);
            }
            else
            {
                WaitViewHide();
            }

        }


        protected void WaitViewHide()
        {

            _MessageViewWait.Close();

        }


    }
}