using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Fwk.Bases;
using System.Windows.Forms;
using Fwk.HelperFunctions;
using Fwk.Bases.FrontEnd;
using System.Drawing;
using Fwk.Bases.FrontEnd.Properties;

namespace Fwk.Bases.FrontEnd.Controls
{
    public delegate void CloseFormHandler(IBaseEntity pIEntityResult);




    //[ToolboxBitmap(@"..\..\Resources\misc2.ico")]
    //[ToolboxBitmap(@"D:\Desarrollo\Fwk\SourceCode\Fwk.FrontEnd\Fwk.Bases.FrontEnd.Controls\Resources\misc2.ico")]
    //[ToolboxBitmap(typeof(FormConnector), "misc2")]
    public partial class FormConnector : Component
    {

        Dictionary<String, IEntity> _d = new Dictionary<string, IEntity>();

            #region Declarations
        private System.Windows.Forms.FormWindowState _FormWindowState = FormWindowState.Normal;
        private System.Windows.Forms.FormStartPosition _FormStartPosition = FormStartPosition.WindowsDefaultBounds;

        public System.Windows.Forms.FormStartPosition FormStartPosition
        {
            get { return _FormStartPosition; }
            set { _FormStartPosition = value; }
        }
        public System.Windows.Forms.FormWindowState FormWindowState
        {
            get { return _FormWindowState; }
            set { _FormWindowState = value; }
        }
        private IBaseEntity _EntityResult = null;

        public IBaseEntity EntityResult
        {
            get { return _EntityResult; }
            set { _EntityResult = value; }
        }
        private IBaseEntity _EntityParam = null;

        public IBaseEntity EntityParam
        {
            get { return _EntityParam; }
            set { _EntityParam = value; }
        }
        public event CloseFormHandler CloseFormEvent;

        private String _FormAssemblyName;

        public String FormAssemblyName
        {
            get { return _FormAssemblyName; }
            set { _FormAssemblyName = value; }
        }
        private String _FormClassName;

        public String FormClassName
        {
            get { return _FormClassName; }
            set { _FormClassName = value; }
        }
        #endregion


        void OnCloseFormEvent()
        {
            if (CloseFormEvent != null)
                CloseFormEvent(_EntityResult);
        }

        public FormConnector()
        {
            InitializeComponent();
        }

        public FormConnector(IContainer container)
        {
            container.Add(this);
            _d["clientiro"].GetXml();
            InitializeComponent();
        }

      
        public void OpenForm()
        {

           

            
            string wAssemblyInfo = String.Concat(new string[] { _FormClassName, ", ", _FormAssemblyName });
            try
            {
                //Obtener la instancia del Formulario
                using (FrmBase f = (FrmBase)ReflectionFunctions.CreateInstance(wAssemblyInfo))
                {
                    //Busco en el archivo Configuration Manager el nombre de ensamblado, namespace y clase para crear diamicamente
                    //FrontClientes.frmModificacion , FrontClientes"
                   
                    f.WindowState = _FormWindowState;
                    f.StartPosition = _FormStartPosition;

                    if (_EntityParam != null)
                        f.EntityParam = _EntityParam;

                    f.ShowDialog();

                    if (f.EntityResult != null)
                        _EntityResult = f.EntityResult;
                }
                OnCloseFormEvent();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
