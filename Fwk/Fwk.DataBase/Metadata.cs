using System;
using System.Text;
using System.Xml;
using System.Data;   
using System.Data.SqlClient;
using Fwk.HelperFunctions;
using Fwk.DataBase.DataEntities;

namespace Fwk.DataBase 

{
    

    /// <summary>
    /// Handler para manejar la carga de los Store Procedure.-
    /// </summary>
	public delegate void OnStoreProcedureLoadHandler();
    /// <summary>
    /// 
    /// </summary>
	public delegate void OnTablesLoadHandler();
	
	/// <summary>
	/// Descripción breve de Metadata.
	/// </summary>
    public class Metadata : HandlersBase
	{	
		#region --[Eventos]--

      

        /// <summary>
        /// 
        /// </summary>
		public event OnStoreProcedureLoadHandler OnStoreProcedureLoad = null;
        /// <summary>
        /// 
        /// </summary>
		public event OnTablesLoadHandler OnTablesLoad = null;
		
		#endregion	

		#region [Atributos]
		private Boolean _ReloadObjects = true;
		private Tables _Tables = null;
		private StoreProcedures _StoreProcedures = null;
		private DataBaseServer _DataBaseServer;
        private UserDefinedTypes _UserDefinedTypes = null;

        /// <summary>
        /// 
        /// </summary>
		public   Boolean ReloadObjects
		{
			get	{return _ReloadObjects;}
			set{_ReloadObjects = value;}
		}		
	
        /// <summary>
        /// Nombre del servidodr de base de datos
        /// </summary>
		public   string ServerName
		{
			get
			{
                
				return _DataBaseServer.CnnString.DataSource;
			}
			
		}

        /// <summary>
        /// Nombre de usuario .-
        /// </summary>
		public  string UserName
		{
			get {return  _DataBaseServer.CnnString.User;}
		}

        /// <summary>
        /// Nombre de Base de datos.-
        /// </summary>
        public string DataBaseName
        {
            get { return _DataBaseServer.CnnString.InitialCatalog; }
        }
         /// <summary>
        ///
        /// </summary>
        public CnnString CnnString
        {
            get { return _DataBaseServer.CnnString; }
        }
	
		/// <summary>
		/// Obtiene todas las Tables de la Base de datos.-
		/// </summary>
		/// <returns></returns>
		public Tables Tables 
			
		{
			get{return _Tables;}
			
		}

        /// <summary>
        /// 
        /// </summary>
        public UserDefinedTypes UserDefinedTypes
        {
            get { return _UserDefinedTypes; }

        }
        /// <summary>
        /// Obtiene todos los StoreProcedures de la Base de datos.-
        /// </summary>
        public StoreProcedures StoreProcedures
		{
			get{return _StoreProcedures;}
		}

		#endregion

		#region [Constructor]

        /// <summary>
        /// 
        /// </summary>
		public Metadata():base(String.Empty)
		{
			_Tables = new Tables ();	
			_StoreProcedures = new StoreProcedures ();
			_DataBaseServer = new DataBaseServer (true);
		}
        /// <summary>
        /// 
        /// </summary>
        public Metadata(CnnString cnnString)
            : base(String.Empty)
        {
            _Tables = new Tables();
            _StoreProcedures = new StoreProcedures();
            _DataBaseServer = new DataBaseServer(true);

            _DataBaseServer.CurrentCnnString = cnnString;
        }

		#endregion

		#region --[Methods]--
		

		/// <summary>
		/// Carga las Tables de la base de datos accediendo a la base de datos nuevamente.-
		/// </summary>
		/// <returns></returns>
		public void LoadTables()
		{
			if(!_ReloadObjects) return;
			TablesBack wTablesBack = new TablesBack (_DataBaseServer.CnnString.ToString());
            wTablesBack.AddElementEvent += new AddElementHandler(TablesBack_AddElementEvent);
            try
            {
                _Tables = wTablesBack.LoadTables();

                _Tables.IsLoaded = true;

                if (OnTablesLoad != null)
                    OnTablesLoad();


            }
            catch (Exception ex)
            {
                throw new DataBaseExeption(ex, _DataBaseServer.CnnString);
            }
            finally 
            {
                wTablesBack.AddElementEvent -= new AddElementHandler(TablesBack_AddElementEvent);
                wTablesBack = null;
            }
		
		}


        void TablesBack_AddElementEvent()
        {
            OnAddElementEvent();
        }

        /// <summary>
        /// Rellena la tabla con sus respectivas columnas .-
        /// </summary>
        /// <param name="pTable">Table</param>
        public void Table_FillColumns(Table pTable)
        {
            if (pTable.IsColumnsLoaded) return;

            pTable.IsColumnsLoaded = true;

            TablesBack wTablesBack = new TablesBack(_DataBaseServer.CnnString.ToString());
            try
            {
                wTablesBack.FillColumns(pTable);
            }
            catch (Exception ex)
            { throw new DataBaseExeption(ex, _DataBaseServer.CnnString); }

        }

        /// <summary>
        /// Rellena el Store Procedures con sus parametros
        /// </summary>
        /// <param name="pStoreProcedure">Store Procedure</param>
        public void StoreProcedures_FillParameters(StoreProcedure pStoreProcedure)
        {
            if (pStoreProcedure.IsParametersLoaded) return;
            pStoreProcedure.IsParametersLoaded = true;
            StoreProcedureBack wStoreProcedureBack = new StoreProcedureBack(_DataBaseServer.CnnString.ToString(), _DataBaseServer.ServerVersion);
            try
            {
                wStoreProcedureBack.FillParametesAndText(pStoreProcedure);
            }
            catch (Exception ex)
            {
                throw new DataBaseExeption(ex, _DataBaseServer.CnnString); 
            }

        }
	
		/// <summary>
		/// Carga los StoreProcedures de la base de datos accediendo a la base de datos nuevamente.-
		/// </summary>
		/// <returns>StoreProcedures</returns>
        public void LoadStoreProcedures()
		{
			if(!_ReloadObjects) return;
			StoreProcedureBack wStoreProcedureBack = new StoreProcedureBack  (_DataBaseServer.CnnString.ToString(),_DataBaseServer.ServerVersion);
			try
			{
				
				_StoreProcedures = wStoreProcedureBack.LoadStoreProcedures();
				_StoreProcedures.IsLoaded = true;

				if(OnStoreProcedureLoad!=null)
					OnStoreProcedureLoad();
				
			}
			catch(Exception ex)
			{
                throw new DataBaseExeption(ex, _DataBaseServer.CnnString);
			}
		}

        /// <summary>
        /// Carga el atributo UserDefinedTypes 
        /// </summary>
        public void LoadUserDefinedTypes()
        {
            UserDefinedTypesBack wUserDefinedTypesBack = new UserDefinedTypesBack(_DataBaseServer.CnnString.ToString());
            _UserDefinedTypes = wUserDefinedTypesBack.LoadUserDefinedTypes();

        }
		/// <summary>
		/// Permite leer nuevamente el archivo de configuracion donde esta el acceso a la BD para recargar la coneccion.-
		/// </summary>
		public void RefreshConnection()
		{
			_DataBaseServer.InitializeConfig();
		}

		/// <summary>
		/// Permite leer nuevamente el archivo de configuracion donde esta el acceso a la BD para recargar la coneccion.-
		/// </summary>
		public System.Boolean TestConnection()
		{
			return _DataBaseServer.TestConnection();
		}

		#endregion

		
	}
}
