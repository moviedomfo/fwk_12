using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using Fwk.Configuration;
using Fwk.Exceptions;
using System.Diagnostics;
using Fwk.Blocking;

namespace Fwk.Blocking
{

    /// <summary>
    /// Marca base de blocking .- Si decea implementar su propia clase de marcas haga heredadr su 
    /// clase de IBlockingMark e implemente una clase IBlockingEngine para la nueva definicion 
    /// de marca personalizada.
    /// </summary>
    /// <Auhor>moviedo</Auhor>
    public class BlockingMarkBase : IBlockingMark
    {
        
        #region Private members

        private Boolean _AlreadyExists;
        private DateTime? _DueDate;
        private String _Process;
        private Guid? _FwkGuid;
        private Int32? _BlockingId;
        private String _User;
        private Int32? _TTL;
        private String _TableName = "BlockingMarks";
        private String _Attribute;
        private String _AttValue;
       
        #endregion


        #region Constructors

        /// <summary>
        /// Constructor que asigna un nombre de tabla de modo de tratar con una tabla que no 
        /// sea la por defecto de blocking.
        /// Este constructor genera un nuevo valor de GUID
        /// </summary>
        /// <param name="pTableName">Nombre de tabla de marcas personalizadas.-</param>
        public BlockingMarkBase(String pTableName)
        {
            _TableName = pTableName;
            _FwkGuid = Guid.NewGuid();
            //Set default values
            SetValues();
        }
        /// <summary>
        /// Constructor que asigna un nombre de tabla de modo de tratar con una tabla que no 
        /// sea la por defecto de blocking.
        /// </summary>
        /// <param name="pGuid">Guid para el caso en que ya sea conocido este valor. Generalmente cuando
        /// la marca ya existe en la BD.
        /// </param>
        public BlockingMarkBase(Guid? pGuid, String pTableName)
       {
           _TableName = pTableName;
           _FwkGuid = pGuid;
           SetValues();
       }
        /// <summary>
        /// Constructor por defecto 
        /// </summary>
        /// <param name="pGuid">Guid para el caso en que ya sea conocido este valor. Generalmente cuando
        /// la marca ya existe en la BD.
        /// </param>
        public BlockingMarkBase(Guid pGuid)
        {
            _FwkGuid = pGuid;
            SetValues();
        }
        /// <summary>
        /// Constructor por defecto 
        /// este constructor genera un nuevo valor Guid par ala marca.
        /// Es utilizado para crear una marca por defecto.-
        /// </summary>
        public BlockingMarkBase()
        {
            _FwkGuid = Guid.NewGuid();
            SetValues();
        }
        /// <summary>
        /// Constructor para búsquedas
        /// todos los parametros pueden ser nulos
        /// </summary>
        public BlockingMarkBase(Int32? pBlockingId, String pTableName, String pAttribute, Int32? pTTL,
            String pUserName, Guid? pGuid, DateTime? pDueDate, String pProcess)
        {
            _BlockingId = pBlockingId;
            _TableName = pTableName;
            _Attribute = pAttribute;
            _TTL = pTTL;
            _User = pUserName;
            _FwkGuid = pGuid;
            _DueDate = pDueDate;
            _Process = pProcess;
        }

        #endregion


        #region Properties

        public String AttValue
        {
            get { return _AttValue; }
            set { _AttValue = value; }
        }
        public String Attribute
        {
            get { return _Attribute; }
            set { _Attribute = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Int32? BlockingId
        {
            get { return _BlockingId; }
            set { _BlockingId = value; }
        }
        /// <summary>
        /// Nombre del proceso de nogocio que requiere el bloqueo
        /// </summary>
        public String Process
        {
            get { return _Process; }
            set { _Process = value; }
        }
        /// <summary>
        /// Guid del Contexto de Bloqueo.- (solo lectura)
        /// </summary>
        public Guid? FwkGuid
        {
            get { return _FwkGuid; }
            set { _FwkGuid = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DueDate
        {
            get { return _DueDate; }
            set { _DueDate = value; }
        }
        /// <summary>
        /// Indica si la marca existe en la base de datos.
        /// </summary>
        public Boolean AlreadyExists
        {
            get { return _AlreadyExists; }
            set { _AlreadyExists = value; }
        }
        /// <summary>
        /// Time-To-Live del contexto de bloqueo.-
        /// </summary>
        public Int32? TTL
        {
            get { return _TTL; }
            set
            {
                _TTL = value;
                _DueDate = System.DateTime.Now.AddSeconds(Convert.ToDouble(_TTL));
            }
        }
        /// <summary>
        /// Usuario que efectua el bloqueo.-
        /// </summary>
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }
        /// <summary>
        /// Nombre de la tabla de bloqueo.- 
        /// </summary>
        public string TableName
        {
            get { return _TableName; }
        }

        #endregion


        #region Private Methods
        
        /// <summary>
        /// Setea los valores por defecto.-
        /// </summary>
        private void SetValues()
        {
            _TTL = 15; /* Seconds */
            //m_BlockingTime = 0;
            _User = String.Empty;
           
        }
        
        #endregion

    }

}