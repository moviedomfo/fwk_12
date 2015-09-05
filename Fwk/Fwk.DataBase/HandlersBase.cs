using System;
using System.Collections.Generic;
using System.Text;

namespace Fwk.DataBase
{
    
    /// <summary>
    /// 
    /// </summary>
    public delegate void AddElementHandler(); 
    /// <summary>
    /// Clase base para los metadatos
    /// 
    /// </summary>
    public class HandlersBase
    {

        /// <summary>
        /// Query para obtener el esquema de una tabla
        /// </summary>
        protected const String _GetSchemaQuery = "SELECT SCHEMA_NAME(tbl.schema_id) AS [Schema] FROM sys.tables  as tbl WHERE (tbl.name= '[TableName]')";
        
        /// <summary>
        /// CAdena de coneccion.-
        /// </summary>
        protected string _CnnString;

        /// <summary>
        /// Version de SQL Server
        /// </summary>
        protected int _ServerVersion = 2005;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCnnString"></param>
        public HandlersBase(string pCnnString)
        {
            _CnnString = pCnnString;
        }
        private  event AddElementHandler _AddElementEvent;
       
       /// <summary>
       /// 
       /// </summary>
        internal  void OnAddElementEvent()
        {

            if (_AddElementEvent != null)
                _AddElementEvent();
        }
        /// <summary>
        /// 
        /// </summary>
        public  event AddElementHandler AddElementEvent
        {
            add
            {
                _AddElementEvent = (AddElementHandler)Delegate.Combine(_AddElementEvent, value);
            }
            remove
            {
                _AddElementEvent = (AddElementHandler)Delegate.Remove(_AddElementEvent, value);
            }
        }


       
    }
}
