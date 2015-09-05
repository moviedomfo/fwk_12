using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CentralizedSecurity.wcf
{

    public class WCFHelper
    {

        public const bool IncludeExceptionDetailInFaults =
#if DEBUG
 true;
#else
            false;
#endif

    }


    [DataContract]
    public class WCFServiceError
    {

        #region --[Protected Vars]--
        private String _Message;
        private String _InnerMessageException;
        private String _Source;
        private String _ErrorId;
        private String _Severity;
        private String _Type;
        private string _StackTrace;

        /// <summary>
        ///    Gets a string representation of the frames on the call stack at the time
        //     the current exception was thrown.
        /// </summary>
        [DataMember]
        public string StackTrace
        {
            get { return _StackTrace; }
            set { _StackTrace = value; }
        }
        /// <summary>
        /// Retorna el tipo de excepcion 
        /// </summary>
        [DataMember]
        public String Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        /// <summary>
        /// Assembly.
        /// </summary>
        protected string m_Assembly;

        /// <summary>
        /// Namespace.
        /// </summary>
        protected string m_Namespace;

        /// <summary>
        /// Class.
        /// </summary>
        protected string m_Class;

        /// <summary>
        /// Machine.
        /// </summary>
        protected string m_Machine;

        /// <summary>
        /// UserName.
        /// </summary>
        protected string m_UserName;


        #endregion

        #region --[Public Properties]--
        /// <summary>
        /// Assembly donde se produce la excepcion.
        /// </summary>
        [DataMember]
        public string Assembly
        {
            get { return m_Assembly; }
            set { m_Assembly = value; }
        }
        /// <summary>
        /// Namespace de la clase donde se produce la excepcion.
        /// </summary>
        [DataMember]
        public string Namespace
        {
            get { return m_Namespace; }
            set { m_Namespace = value; }
        }

        /// <summary>
        /// Clase donde se produce la excepcion.
        /// </summary>
        [DataMember]
        public string Class
        {
            get { return m_Class; }
            set { m_Class = value; }
        }

        /// <summary>
        /// Nombre del Equipo del cliente donde se produce la excepcion.
        /// </summary>
        public string Machine
        {
            get { return m_Machine; }
            set { m_Machine = value; }
        }

        /// <summary>
        /// Nombre del usuario cliente.
        /// </summary>
        [DataMember]
        public string UserName
        {
            get { return m_UserName; }
            set { m_UserName = value; }
        }

        /// <summary>
        /// Determina el grado de severidad del la exepción.-
        /// </summary>
        [DataMember]
        public String Severity
        {
            get { return _Severity; }
            set { _Severity = value; }
        }


        /// <summary>
        /// Indica el origen del error.-
        /// </summary>
        [DataMember]
        public String Source
        {
            get { return _Source; }
            set { _Source = value; }
        }

        /// <summary>
        /// Mensaje  descriptivo del error
        /// </summary>
        [DataMember]
        public String Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        /// <summary>
        /// Trace de las excepciones producidas asta capturar el error
        /// </summary>
        [DataMember]
        public String InnerMessageException
        {
            get { return _InnerMessageException; }
            set { _InnerMessageException = value; }
        }

        /// <summary>
        /// Identificador del error
        /// </summary>
        [DataMember]
        public String ErrorId
        {
            get { return _ErrorId; }
            set { _ErrorId = value; }
        }

        #endregion

    }
}
