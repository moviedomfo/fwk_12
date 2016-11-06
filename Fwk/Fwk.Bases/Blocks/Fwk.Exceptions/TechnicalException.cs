using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web.Services.Protocols;
using System.Xml;
using Fwk.Configuration;
using Fwk.Bases;


namespace Fwk.Exceptions
{
    /// <summary>
    /// Excepcion Tecnica.
    /// </summary>
    /// <Author>moviedo</Author>
    /// <Date>28-12-2005</Date>
    [ComVisible(false)]
    [Serializable()]
    public class TechnicalException : ApplicationException
    {
        #region --[Protected Constants]--
        /// <summary>
        /// EXCEPTIONSMESSAGES_GROUPNAME.
        /// </summary>
        protected const string EXCEPTIONSMESSAGES_GROUPNAME = "ExceptionMessages";
        
        /// <summary>
        /// TECHNICALMESSAGE_ATTRIBUTENAME
        /// </summary>
        protected const string TECHNICALMESSAGE_ATTRIBUTENAME = "TechExceptionMsg";
        #endregion

        #region --[Protected Vars]--
        private String _ErrorId = String.Empty;

        /// <summary>
        /// Assembly.
        /// </summary>
        protected string mAssembly;

        /// <summary>
        /// Namespace.
        /// </summary>
        protected string mNamespace;

        /// <summary>
        /// Class.
        /// </summary>
        protected string mClass;

        /// <summary>
        /// Machine.
        /// </summary>
        protected string mMachine;

        /// <summary>
        /// UserName.
        /// </summary>
        protected string mUserName;

        /// <summary>
        /// Message.
        /// </summary>
        protected string mMsg;
        #endregion

        #region --[Public Properties]--

        /// <summary>
        /// 
        /// </summary>
        public String ServiceName { get; set; }
        /// <summary>
        /// Identificador del error
        /// </summary>
        public String ErrorId
        {
            get { return _ErrorId; }
            set { _ErrorId = value; }
        }

        /// <summary>
        /// Assembly donde se produce la excepcion.
        /// </summary>
        public string Assembly
        {
            get { return mAssembly; }
            set { mAssembly = value; }
        }
        /// <summary>
        /// Namespace de la clase donde se produce la excepcion.
        /// </summary>
        public string Namespace
        {
            get { return mNamespace; }
            set { mNamespace = value; }
        }

        /// <summary>
        /// Clase donde se produce la excepcion.
        /// </summary>
        public string Class
        {
            get { return mClass; }
            set { mClass = value; }
        }

        /// <summary>
        /// Nombre del Equipo del cliente donde se produce la excepcion.
        /// </summary>
        public string Machine
        {
            get { return mMachine; }
            set { mMachine = value; }
        }

        /// <summary>
        /// Nombre del usuario cliente.
        /// </summary>
        public string UserName
        {
            get { return mUserName; }
            set { mUserName = value; }
        }

        /// <summary>
        /// Message.
        /// </summary>
        public override string Message
        {
            get { return mMsg; }
        }

        #endregion

        #region --[Constructors]--
        /// <summary>
        /// Excepcion tecnica.
        /// </summary>
        public TechnicalException()
        {
        }

        /// <summary>
        /// Excepcion tecnica.
        /// </summary>
        /// <param name="pinfo">The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="pcontext">The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.</param>
        protected TechnicalException(SerializationInfo pinfo, StreamingContext pcontext): base(pinfo, pcontext)
        {
            mMsg = pinfo.GetString("mMsg");
            mAssembly = pinfo.GetString("mAssembly");
            mNamespace = pinfo.GetString("mNamespace");
            mClass = pinfo.GetString("mClass");
            mMachine = pinfo.GetString("mMachine");
            mUserName = pinfo.GetString("mUserName");
            this.Source = ConfigurationsHelper.HostApplicationName;
        }

        /// <summary>
        /// Excepcion tecnica.
        /// </summary>
        /// <param name="pmsg">Mensaje del error.</param>
        public TechnicalException(string pmsg): base(pmsg)
        {
            mMsg = pmsg;
            this.Source = ConfigurationsHelper.HostApplicationName;
        }

        /// <summary>
        /// Excepcion tecnica.
        /// </summary>
        /// <param name="passembly">Nombre del assembly donde se produce el error.</param>
        /// <param name="pnamespace">Namespace de la clase donde se produce el error.</param>
        /// <param name="pclass">Clase donde se produce el error.</param>
        /// <param name="pmachine">Equipo donde se produce el error.</param>
        /// <param name="puserName">Nombre de usuario.</param>
        public TechnicalException(string passembly, string pnamespace, string pclass, string pmachine, string puserName): this(passembly, pnamespace, pclass, pmachine, puserName, "")
        { this.Source = ConfigurationsHelper.HostApplicationName; }

        /// <summary>
        /// Excepcion tecnica.
        /// </summary>
        /// <param name="passembly">Nombre del assembly donde se produce el error.</param>
        /// <param name="pnamespace">Namespace de la clase donde se produce el error.</param>
        /// <param name="pclass">Clase donde se produce el error.</param>
        /// <param name="pmachine">Equipo donde se produce el error.</param>
        /// <param name="puserName">Nombre de usuario.</param>
        /// <param name="pmsg">Mensaje del error.</param>
        public TechnicalException(string passembly, string pnamespace, string pclass, string pmachine, string puserName, string pmsg)
            : this(passembly, pnamespace, pclass, pmachine, puserName, pmsg, null)
        { this.Source = ConfigurationsHelper.HostApplicationName; }

        /// <summary>
        /// Excepcion tecnica.
        /// </summary>
        /// <param name="passembly">Nombre del assembly donde se produce el error.</param>
        /// <param name="pnamespace">Namespace de la clase donde se produce el error.</param>
        /// <param name="pclass">Clase donde se produce el error.</param>
        /// <param name="pmachine">Equipo donde se produce el error.</param>
        /// <param name="puserName">Nombre de usuario.</param>
        /// <param name="pinner">Excepcion original.</param>
        public TechnicalException(string passembly, string pnamespace, string pclass, string pmachine, string puserName, Exception pinner)
            : this(passembly, pnamespace, pclass, pmachine, puserName, String.Empty, pinner)
        {
            this.Source = ConfigurationsHelper.HostApplicationName;
            try
            {
                mMsg = ConfigurationManager.GetProperty(EXCEPTIONSMESSAGES_GROUPNAME, TECHNICALMESSAGE_ATTRIBUTENAME);
            }
            catch
            {
                mMsg = pinner.Message;
            }
        }

        /// <summary>
        /// Excepcion tecnica.
        /// </summary>
        /// <param name="passembly">Nombre del assembly donde se produce el error.</param>
        /// <param name="pnamespace">Namespace de la clase donde se produce el error.</param>
        /// <param name="pclass">Clase donde se produce el error.</param>
        /// <param name="pmachine">Equipo donde se produce el error.</param>
        /// <param name="puserName">Nombre de usuario.</param>
        /// <param name="pmsg">Mensaje del error.</param>
        /// <param name="pinner">Excepcion original.</param>
        public TechnicalException(string passembly, string pnamespace, string pclass, string pmachine, string puserName, string pmsg, Exception pinner)
            : this(pmsg, pinner)
        {
            mAssembly = passembly;
            mNamespace = pnamespace;
            mClass = pclass;
            mMachine = pmachine;
            mUserName = puserName;
            mMsg = pmsg;
            this.Source = ConfigurationsHelper.HostApplicationName;
        }

        /// <summary>
        /// Excepcion tecnica.
        /// </summary>
        /// <param name="pmsg">Mensaje del error.</param>
        /// <param name="pinner">Excepcion original.</param>
        public TechnicalException(string pmsg, Exception pinner): base(pmsg, pinner)
        {
            mMsg = pmsg;
            this.Source = ConfigurationsHelper.HostApplicationName;
        }
        #endregion

        #region --[Protected Methods]--
        /// <summary>
        /// Agrega texto al comienzo del mensaje
        /// </summary>
        /// <param name="pmsg"></param>
        public void AddMessage_Top(string pmsg)
        {
            mMsg = string.Concat(pmsg, Environment.NewLine, mMsg);
        }
        /// <summary>
        /// Agrega texto al final del mensae
        /// </summary>
        /// <param name="pmsg"></param>
        public void AddMessage_Down(string pmsg)
        {
            mMsg = string.Concat(mMsg, Environment.NewLine, pmsg);
        }
        /// <summary>
        /// Sets the System.Runtime.Serialization.SerializationInfo with information about the exception.
        /// </summary>
        /// <param name="pinfo">The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="pcontext">The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.</param>
        public override void GetObjectData(SerializationInfo pinfo, StreamingContext pcontext)
        {
            base.GetObjectData(pinfo, pcontext);
            pinfo.AddValue("mMsg", mMsg);
            pinfo.AddValue("mAssembly", mAssembly);
            pinfo.AddValue("mMachine", mMachine);
            pinfo.AddValue("mClass", mClass);
            pinfo.AddValue("mUserName", mUserName);
            pinfo.AddValue("mNamespace", mNamespace);
            pinfo.AddValue("_ErrorId", _ErrorId);
            
        }
        #endregion




    }
}