using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Fwk.DataBase.DataEntities;

        /*Listado de tablas
		select s1 = o.name, s2 = user_name(o.uid),o.crdate,o.id, N'SystemObj' = (case when (OBJECTPROPERTY(o.id, N'IsMSShipped')=1) then 1 else OBJECTPROPERTY(o.id, N'IsSystemTable') end),        o.category, 0, ObjectProperty(o.id, N'TableHasActiveFulltextIndex'), ObjectProperty(o.id, N'TableFulltextCatalogId'), N'FakeTable' = (case when (OBJECTPROPERTY(o.id, N'tableisfake')=1) then 1 else 0 end),        (case when (OBJECTPROPERTY(o.id, N'IsQuotedIdentOn')=1) then 1 else 0 end), (case when (OBJECTPROPERTY(o.id, N'IsAnsiNullsOn')=1) then 1 else 0 end)        from dbo.sysobjects o, dbo.sysindexes i where OBJECTPROPERTY(o.id, N'IsTable') = 1 and i.id = o.id and i.indid < 2 and o.name not like N'#%'   order by s1, s2
		Listado de SP
	    select o.name, user_name(o.uid), o.crdate, xtype=convert(nchar(2), o.xtype), o.id, OBJECTPROPERTY(o.id, N'ExecIsStartup'), OBJECTPROPERTY(o.id, N'ExecIsQuotedIdentOn'), OBJECTPROPERTY(o.id, N'ExecIsAnsiNullsOn'), OBJECTPROPERTY(o.id, N'IsMSShipped') from dbo.sysobjects o where (OBJECTPROPERTY(o.id, N'IsProcedure') = 1 or OBJECTPROPERTY(o.id, N'IsExtendedProc') = 1 or OBJECTPROPERTY(o.id, N'IsReplProc') = 1) and o.name not like N'#%%'  order by o.name
       */
namespace Fwk.DataBase
{
	/// <summary>
	/// Summary description for TablesBack.
	/// </summary>
    internal class TablesBack : HandlersBase
	{
        
	    private List<string> SysDataBasesList = null; 

        /// <summary>
        /// Costuctor .-
        /// </summary>
        /// <param name="pCnnString">Cadena de coneccion.-</param>
        internal TablesBack(string pCnnString)
            : base(pCnnString)
		{
	
            FillSysDataBasesList();
            
        }
        

        #region [Public Methods]
        /// <summary>
		/// Carga las tablas de la base de datos accediendo a la base de datos nuevamente.-
		/// </summary>
        /// <returns>Tables </returns>
        internal Tables LoadTables()
        {
            return LoadTables(false);
        }

		/// <summary>
		/// Carga las tablas de la base de datos accediendo a la base de datos nuevamente.-
		/// </summary>
        /// <returns>Tables </returns>
        internal Tables LoadTables(bool pLoadColumns)
		{

            DataTable wDttTablas = null;
            Table wTable = null;
            Tables wTables = new Tables();
			try 
			{
				wDttTablas = GetTablesFromDataBase ();
                wDttTablas.TableName = "Tablas";
                foreach (DataRow oDtr in wDttTablas.Rows)
                {
                    if (oDtr["Schema"].ToString().Trim() != "sys")
                        if (!SysDataBasesList.Contains(oDtr["Name"].ToString().ToLower()))
                        {
                            wTable = new Table(oDtr["Name"].ToString());
                            //Carga el nombre del esquema
                            wTable.Schema = oDtr["Schema"].ToString();//GetSchema(wTable.Name);
                            wTables.Add(wTable);
                        }
                }

			    if(pLoadColumns)
				    SetColumnsAndKeysToTables(wTables);

                wDttTablas.Dispose();
                wDttTablas = null;

                OnAddElementEvent();
				return wTables;
                
			}
			catch(Exception ex)
			{throw ex;}

        }

        private string GetSchema(string pTableName)
        {
            using (SqlConnection wCnn = new SqlConnection(_CnnString))
            using (SqlCommand wCmd = new SqlCommand())
            {
                try
                {
                    wCnn.Open();
                    wCmd.CommandType = CommandType.Text;
                    wCmd.Connection = wCnn;

                    wCmd.CommandText = _GetSchemaQuery.Replace("[TableName]", pTableName);

                    String wSchema = wCmd.ExecuteScalar().ToString();

                    if (String.IsNullOrEmpty(wSchema))
                        wSchema = "dbo";

                   
                    wCnn.Close();

                    return wSchema;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }

        private void FillSysDataBasesList()
        {
            SysDataBasesList = new List<string>();

            SysDataBasesList.Add(@"dtproperties");
            SysDataBasesList.Add(@"syscolumns");
            SysDataBasesList.Add(@"syscomments");
            SysDataBasesList.Add(@"sysdepends");
            SysDataBasesList.Add(@"sysfilegroups");
            SysDataBasesList.Add(@"sysfiles");
            SysDataBasesList.Add(@"sysfiles1");
            SysDataBasesList.Add(@"sysforeignkeys");
            SysDataBasesList.Add(@"sysfulltextcatalogs");
            SysDataBasesList.Add(@"sysfulltextnotify");
            SysDataBasesList.Add(@"sysindexes");
            SysDataBasesList.Add(@"sysindexkeys");
            SysDataBasesList.Add(@"sysmembers");
            SysDataBasesList.Add(@"sysobjects");
            SysDataBasesList.Add(@"syspermissions");
            SysDataBasesList.Add(@"sysproperties");
            SysDataBasesList.Add(@"sysprotects");
            SysDataBasesList.Add(@"sysreferences");
            SysDataBasesList.Add(@"systypes");
            SysDataBasesList.Add(@"sysusers");
            SysDataBasesList.Add(@"sysdiagrams");

           
        }
        
        internal void FillColumns(Table pTable)
        {
            this.SetColumnsAndKeysToTable(pTable);

        }
        #endregion

        #region [Private Methods]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTables"></param>
        private void SetColumnsAndKeysToTables(Tables pTables)
		{
            
			foreach (Table wTable in pTables)
			{

				try
				{
                     SetColumnsAndKeysToTable(wTable);
		
				}
				catch(Exception ex)
				{
					throw ex;
				}

			}

		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wTable"></param>
        private void SetColumnsAndKeysToTable(Table wTable)
        {
            DataSet wDttTableInfo = null;
            try
            {
                wDttTableInfo = GetTableInfoFromDataBase(wTable);
                wTable.Columns = GetColumns(wDttTableInfo.Tables[0], wTable.Name);
              
               
                //SetKeys(wDttKeys, wTable.PrimaryKeys, wTable.ClavesForaneas);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                wDttTableInfo.Dispose();
                wDttTableInfo = null;
            }

        }

        /// <summary>
        /// Busca los campos que son claves primarias o secundarias de un adeterminada tabla
        /// </summary>
        /// <param name="pTableName">Nombre de la tabla</param>
        /// <returns>DataTable con las claves</returns>
        private DataTable GetKeysFromTable(string pTableName)
        {
            using (SqlConnection wCnn = new SqlConnection(_CnnString))
            using (SqlCommand wCmd = new SqlCommand())
            {
                DataSet wDs = new DataSet(); 
                SqlParameter wParam = new SqlParameter();
                try
                {

                    wParam = new SqlParameter();

                    wCnn.Open();

                    wCmd.CommandType = CommandType.Text;

                    wCmd.CommandText = "exec sp_pkeys " + pTableName;

                    wCmd.Connection = wCnn;
                    SqlDataAdapter wDa = new SqlDataAdapter(wCmd);

                    wDa.Fill(wDs);
                    wCnn.Close();
                    return wDs.Tables[0];
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }

		/// <summary>
		/// Establece las claves Primarias y foraneas de un objeto Table (No se usa actualmente)
		/// </summary>
		/// <param name="pDttClave"></param>
		/// <param name="pClavesPrimarias"></param>
		/// <param name="pClavesForaneas"></param>
		private  void SetKeys (DataTable pDttClave,Keys pClavesPrimarias, Keys pClavesForaneas)
		{
			foreach(DataRow oClaveRow in pDttClave.Rows)
			{
				Key wClave = new Key (); 
				
				wClave.Name 	= oClaveRow["cKeyCol1"].ToString();
				wClave.ConstraintName = oClaveRow["cName"].ToString();
				wClave.ConstraintType = oClaveRow["cType"].ToString();

				if(!oClaveRow.IsNull("cGroupName"))
					wClave.GroupName = oClaveRow["cGroupName"].ToString();
				
					
				if(wClave.GroupName == "PRIMARY")
					pClavesPrimarias.Add (wClave);
				else
					pClavesForaneas.Add	(wClave);
				
					
			}
			
		}
		
        /// <summary>
        /// Setea las columbas y claves de una determinada tabla .-
        /// </summary>
        /// <param name="pColumnsDtt">DataTable con las columnas de una tabla obtenida de la base de datos</param>
        /// <param name="pTableName">Nombre de la tabla.-</param>
        /// <returns>Objeto Columns de la tabla.-</returns>
		private  Columns  GetColumns(DataTable pColumnsDtt,string pTableName)
		{
			Columns wCampos = new Columns ();
            DataTable wDttKeys = GetKeysFromTable(pTableName);
           

			foreach(DataRow wDtrColumn in pColumnsDtt.Rows)
			{
				
				Column wCampo = new Column (); 
				wCampo.Name		= wDtrColumn["col_name"].ToString ();
                wCampo.IsIdentity = Convert.ToBoolean(wDtrColumn["col_identity"]);
				wCampo.Length	=	Convert.ToInt32 ( wDtrColumn["col_len"]);
                if (!wDtrColumn.IsNull("col_prec"))
                    wCampo.Prec = Convert.ToInt32(wDtrColumn["col_prec"]);
                if (!wDtrColumn.IsNull("col_scale"))
                    wCampo.Scale = Convert.ToInt32(wDtrColumn["col_scale"]);

				wCampo.Type		=	wDtrColumn["col_typename"].ToString ();
				wCampo.Nullable =	Convert.ToBoolean( wDtrColumn["col_null"]);
				wCampo.Computed =   wDtrColumn["col_iscomputed"].ToString ();
                wCampo.KeyField = (wDttKeys.Select("COLUMN_NAME = '" + wCampo.Name + "'").Length > 0);
                wCampo.Autogenerated = wCampo.IsIdentity;
				wCampos.Add (wCampo);
					
			}
			return wCampos;
			
		}
	
		
		/// <summary>
		/// Busca todas las tablas en la base de datos .-
		/// </summary>
        /// <returns>DataTable con las tablas obtenidas.-</returns>
		private  DataTable  GetTablesFromDataBase()
		{



            String wQuery = GetTableQuery(_ServerVersion);

			using(SqlConnection wCnn = new SqlConnection (_CnnString))
			using (SqlCommand wCmd = new SqlCommand())
			{
				DataSet wDs = new DataSet ();;
				SqlParameter wParam = new SqlParameter ();
				try
				{
				
					wParam = new SqlParameter ();

					wCnn.Open();
				
					wCmd.CommandType = CommandType.Text;
					
					wCmd.CommandText = wQuery.ToString();
		
					wCmd.Connection = wCnn;
					SqlDataAdapter wDa = new SqlDataAdapter(wCmd);
				
					wDa.Fill(wDs);
					wCnn.Close();
					return wDs.Tables [0];
				}
				catch(SqlException ex)
				{
					throw ex;
				}
			}
		}

        private static String GetTableQuery(int pSQLServerVersion)
        {
            StringBuilder wQuery = new StringBuilder();

            if (pSQLServerVersion == 2005)
            {
                wQuery.Append(@"SELECT");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"tbl.name AS [Name],");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"SCHEMA_NAME(tbl.schema_id) AS [Schema]");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"FROM");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"sys.tables AS tbl");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"WHERE");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"(CAST(");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@" case ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"    when tbl.is_ms_shipped = 1 then 1");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"    when (");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"        select ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"            major_id ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"        from ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"            sys.extended_properties ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"        where ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"            major_id = tbl.object_id and ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"            minor_id = 0 and ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"            class = 1 and ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"            name = N'microsoft_database_tools_support') ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"        is not null then 1");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"    else 0");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"end          ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"             AS bit)=0)");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"ORDER BY");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"[Schema] ASC,[Name] ASC");
                

            }
            else
            {
                wQuery.Append(@"select ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"[Name] = o.name, ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"[Schema]  = user_name(o.uid)");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"  from dbo.sysobjects o, dbo.sysindexes i ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"where ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"OBJECTPROPERTY(o.id, N'IsTable') = 1 ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"and i.id = o.id ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"and i.indid < 2 ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"and o.name not like N'#%'   ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"order by Name, [Schema] ");
                wQuery.Append(Environment.NewLine);

            }
            return wQuery.ToString();
        }
		/// <summary>
		/// Obtiene informacion de la tabla.-
		/// </summary>
        /// <param name="pTable">tabla</param>
		/// <returns>Marcelo Oviedo</returns>
		private  DataSet GetTableInfoFromDataBase(Table pTable)
		{
            

			using(SqlConnection wCnn = new SqlConnection (_CnnString))
			using (SqlCommand wCmd = new SqlCommand())
			{
				DataSet wDs = new DataSet ();;
				
				try
				{
					wCnn.Open();
                    wCmd.CommandType = CommandType.Text;
                    wCmd.Connection = wCnn;

                    wCmd.CommandText = "exec sp_MShelpcolumns N'[" + pTable.Schema + "].[" + pTable.Name + "]' ";
                    wCmd.CommandText += " exec sp_MStablekeys N'[" + pTable.Schema + "].[" + pTable.Name + "]' ";

                    SqlDataAdapter wDa = new SqlDataAdapter(wCmd);
					wDa.Fill(wDs);
					wCnn.Close();
				
					return wDs;
				}
				catch(SqlException ex)
				{
					throw ex;
				}
			}
		}
        

		
		#endregion


	}
}
