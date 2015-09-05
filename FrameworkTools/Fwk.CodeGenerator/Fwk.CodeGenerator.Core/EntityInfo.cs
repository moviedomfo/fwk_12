using System;
using System.Collections.Generic;
using System.Text;
using fwkDataEntities = Fwk.DataBase.DataEntities;

using Microsoft.SqlServer.Management.Smo;


namespace Fwk.CodeGenerator
{
    /// <summary>
    /// Clase que mantiene información acerca de una entidad de negocio.
    /// </summary>
    /// <remarks>
    /// Se utiliza en el proceso de generación de código de entidades de negocio.
    /// </remarks>
    /// <author>Marcelo Oviedo</author>
    public class EntityInfo
    {
        #region [Private fields]

        
        private string _Name;
        private string _Namespace;
       // private bool _GenerateCode;
        private bool _WithNolock;

       
        //private List<MethodInfo> _Methods;
        private Table _Table = null;
        private StoredProcedure _StoredProcedure = null;
        //private List<GlobalElementComplexType> _GlobalElementComplexTypeList = null;

        //public List<GlobalElementComplexType> GlobalElementComplexTypeList
        //{
        //    get { return _GlobalElementComplexTypeList; }
        //    set { _GlobalElementComplexTypeList = value; }
        //}

        public Table Table
        {
            get { return _Table; }
            set { _Table = value; }
        }
        public StoredProcedure StoredProcedure
        {
            get { return _StoredProcedure; }
            set { _StoredProcedure = value; }
        }
        private StringBuilder _Code;

        public bool WithNolock
        {
            get { return _WithNolock; }
            set { _WithNolock = value; }
        }
 
       

        #endregion

        #region [Public properties]

        /// <summary>
        /// Codigo generado .-
        /// </summary>
        public StringBuilder Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
        /// <summary>
        /// Nombre de la entidad de negocio.
        /// </summary>
        /// <author>Marcelo Oviedo</author>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// Namespace de la entidad de negocio.
        /// </summary>
        
        /// <author>Marcelo Oviedo</author>
        public string Namespace
        {
            get { return _Namespace; }
            set { _Namespace = value; }
        }

      

        /// <summary>
        /// Lista de métodos a generar.
        /// </summary>
        /// <date>2007-5-25T00:00:00</date>
        /// <author>Marcelo Oviedo</author>
        //public List<MethodInfo> Methods
        //{
        //    get { return _Methods; }
        //    set { _Methods = value; }
        //}

       


       

        #endregion

        #region [Constructors]

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <author>Marcelo Oviedo</author>
        //public EntityInfo(Table pTable)
        //{

        //    _Table = pTable;
        //    _Methods = new List<MethodInfo>();
        //}
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pStoredProcedure"></param>
        /// <author>Marcelo Oviedo</author>
        public EntityInfo(StoredProcedure pStoredProcedure)
        {

            _StoredProcedure = pStoredProcedure;
            //_Methods = new List<MethodInfo>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pStoredProcedure"></param>
        /// <author>Marcelo Oviedo</author>
       // public EntityInfo( List<GlobalElementComplexType> pGlobalElementComplexTypeList)
        //{
        //    _GlobalElementComplexTypeList = pGlobalElementComplexTypeList;
        //    //_Methods = new List<MethodInfo>();
        //}
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public EntityInfo()
        {

        }
        #endregion
    }
}
