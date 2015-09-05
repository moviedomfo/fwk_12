using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Fwk.DataBase.DataEntities;
namespace Fwk.DataBase
{
	/// <summary>
	/// Summary description for StoreProcedureBack.
	/// </summary>
    internal class StoreProcedureBack:HandlersBase 
	{
		


        /// <summary>
        /// Costuctor .-
        /// </summary>
        /// <param name="pCnnString">Cadena de coneccion.-</param>
        /// <param name="pServerVersion">Version del SQL.-</param>
        internal StoreProcedureBack(string pCnnString, int pServerVersion)
            : base(pCnnString)
        {
           
            _ServerVersion = pServerVersion;
        }

        #region [Public Methods]

        
        /// <summary>
        /// Carga todos los store procedures de una base de datos 
        /// </summary>
        /// <returns>Coleccion de StoreProcedure</returns>
        internal StoreProcedures LoadStoreProcedures()
        {
           return LoadStoreProcedures(false);
        }
       
        /// <summary>
        /// Carga todos los store procedures de una base de datos .-
        /// </summary>
        /// <param name="pLoadParameters">Indica si se cargan los parametros y text del Store Procedure .-</param>
        /// <returns></returns>
        internal StoreProcedures LoadStoreProcedures(bool pLoadParameters)
		{
			
            StoreProcedure wStoreProcedure = null;
			StoreProcedures wStoreProcedures = new  StoreProcedures() ;
            DataSet wDtsStores = null;
            
			try
			{
				wDtsStores = GetStoredProcedureFromDatabase();
				
				foreach (DataRow wDtr in wDtsStores.Tables [0].Rows)
				{
                    wStoreProcedure = new StoreProcedure();


                    wStoreProcedure.Name = wDtr["Name"].ToString();
                    wStoreProcedure.Schema = wDtr["Schema"].ToString();

                    if (pLoadParameters == true)
                        FillParametesAndText(wStoreProcedure);

                    wStoreProcedures.Add(wStoreProcedure);
				}

				wStoreProcedures.IsLoaded = true;

                wDtsStores.Dispose();
                wDtsStores = null;

                OnAddElementEvent();
				return wStoreProcedures;
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }

        internal StoreProcedures LoadStoreProceduresByTables(Tables pTables,bool pLoadParameters)
        {
            string strSpName = String.Empty;
            StoreProcedures wStoreProcedures = null;
            StoreProcedure wStoreProcedure = null;
            foreach (Table wTabla in pTables)
            {
                DataSet wDtsStores = GetStoreProceduresFromTable(wTabla.Name);
                if (wDtsStores.Tables.Count > 0 && wDtsStores.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow wDtr in wDtsStores.Tables[0].Rows)
                    {
                        if (wDtr[1].ToString().ToUpper() == "STORED PROCEDURE")
                        {
                            strSpName = wDtr[0].ToString().Substring(4, wDtr[0].ToString().Length - 4);

                         
                            wStoreProcedure = new StoreProcedure();

                            wStoreProcedure.Name = strSpName;
                            if (pLoadParameters == true)
                                FillParametesAndText(wStoreProcedure);

                            wStoreProcedures.Add(wStoreProcedure);
                        }
                    }

                }
            }

            return wStoreProcedures;
        }

        /// <summary>
        /// Establece los parametros y texto del Store Procedure.-
        /// </summary>
        /// <param name="pStoreProcedures"></param>
        internal void FillParametesAndText(StoreProcedure pStoreProcedures)
        {
            DataSet wDtsParametesAndTex = GetParametesAndTextFromSP(pStoreProcedures);

            // Seteo Texto del SP
            if(wDtsParametesAndTex.Tables[1].Rows.Count !=0)
                pStoreProcedures.Text = wDtsParametesAndTex.Tables[1].Rows[0][0].ToString();

            // Seteo los Parametros
            SetParameters(pStoreProcedures, wDtsParametesAndTex.Tables[0]);


        }

        #endregion


        #region [Private Methods]

        #region [Setings]

        /// <summary>
        /// Setea los parametros de un StoreProcedure determinado
        /// </summary>
        /// <param name="pSP">StoreProcedure</param>
		private  void SetParameterToStoreProcedure(StoreProcedure pSP)
		{
            //Si estan cargados los parametros no hacer nada .-
            if (pSP.IsParametersLoaded) return;

			DataSet wDts = GetParametersFromStoredProcedure(pSP.Name);

            

			if ( wDts.Tables[0].Rows.Count >0)
            {
                pSP.IsParametersLoaded = true;

				foreach(DataRow wDtrParameter in wDts.Tables[0].Rows)
				{
					if(wDtrParameter[3].ToString().ToUpper() != "@RETURN_VALUE")
					{
						SPParameter wSPParametro = new SPParameter ();

						wSPParametro.Name			= wDtrParameter["COLUMN_NAME"].ToString().Replace("@",String.Empty);
						wSPParametro.Type			= wDtrParameter["TYPE_NAME"].ToString();
						//wSPParametro.DbSqlType	= wDtrParameter[6];
						wSPParametro.Length			=  Convert.ToInt32(wDtrParameter["LENGTH"]);
						wSPParametro.ParamOrder		= Convert.ToInt32(wDtrParameter["ORDINAL_POSITION"]);
						wSPParametro.Collation		= String.Empty ;
						if(Convert.ToBoolean (wDtrParameter["NULLABLE"]) == true)
							wSPParametro.Nullable = true;
						wSPParametro.Prec			= Convert.ToInt32(wDtrParameter["PRECISION"]);

                        wSPParametro.Direction = SPParameter.GetDirecction(Convert.ToInt32(wDtrParameter["COLUMN_TYPE"]));

						pSP.Parameters.Add(wSPParametro);
					}

				}
								
			}
			
		

		}

        /// <summary>
        /// Carga los parametros de un SP.-
        /// </summary>
        /// <param name="pSP">StoreProcedure</param>
        /// <param name="pDattSPs">DataTable con los parametros.-</param>
		private   void SetParameters(StoreProcedure pSP,DataTable pDattSPs)
		{
            SPParameter wParameter = null;
			if ( pDattSPs.Rows.Count >0)
			{
				foreach(DataRow wDtrParameter in pDattSPs.Rows)
				{
					if(wDtrParameter[3].ToString().ToUpper() != "@RETURN_VALUE")
					{
						wParameter = new SPParameter ();

						wParameter.Name = wDtrParameter["COLUMN_NAME"].ToString().Replace("@",String.Empty);
						wParameter.Type = wDtrParameter["TYPE_NAME"].ToString();
						//wSPParametro.DbSqlType = wDtrParameter[6];
						wParameter.Length =  Convert.ToInt32(wDtrParameter["LENGTH"]);
						wParameter.ParamOrder = Convert.ToInt32(wDtrParameter["ORDINAL_POSITION"]);
						wParameter.Collation = string.Empty ;
						if(Convert.ToBoolean (wDtrParameter["NULLABLE"]) == true)
							wParameter.Nullable = true;
						wParameter.Prec = Convert.ToInt32(wDtrParameter["PRECISION"]);
						
                        wParameter.Direction = SPParameter.GetDirecction(Convert.ToInt32(wDtrParameter["COLUMN_TYPE"]));

						pSP.Parameters.Add(wParameter);
					}

				}
								
			}
        }
        #endregion

        #region [GETS]

        /// <summary>
        /// Obtienen los parametros y texto del store procedure desde la base de datos.-
        /// </summary>
        /// <param name="pStoreProcedure">Nombre store procedure </param>
        /// <returns>DataSet </returns>
        private DataSet GetParametesAndTextFromSP(StoreProcedure pStoreProcedure)
        {
            DataSet wDs = null;
            string wQuery = " Exec sp_sproc_columns [" + pStoreProcedure.Name + "]";

            wQuery = wQuery + " select c.text from dbo.syscomments c where  c.id = object_id(N'[" + pStoreProcedure.Schema + "].[" + pStoreProcedure.Name + "]')";
            using (SqlConnection wCnn = new SqlConnection(_CnnString))
            using (SqlCommand wCmd = new SqlCommand())
            {
                try
                {
                    wDs = new DataSet();

                    wCmd.CommandType = CommandType.Text;
                    wCmd.CommandText = wQuery;
                    wCmd.Connection = wCnn;

                    SqlDataAdapter wDa = new SqlDataAdapter(wCmd);

                    wDa.Fill(wDs);
                    wCnn.Close();
                    return wDs;

                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }
		/// <summary>
		/// Busca todos los stored procedures de la base de datos actual.-
		/// </summary>
		/// <returns></returns>
		private  DataSet GetStoredProcedureFromDatabase()
		{
            String wQuery = GetSPQuery(_ServerVersion);
            

			using(SqlConnection wCnn = new SqlConnection (_CnnString))
			using (SqlCommand wCmd = new SqlCommand())
			{
				try
				{
					DataSet wDs = new DataSet ();
					SqlParameter wParam = new SqlParameter ();
		
					wCmd.CommandType = CommandType.Text;
					wCmd.CommandText = wQuery;
		
					wCmd.Connection = wCnn;
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

        private static String GetSPQuery(int pSQLServerVersion)
        {
            StringBuilder wQuery = new StringBuilder();

            if (pSQLServerVersion == 2005)
            {
                wQuery.Append(@" SELECT sp.name AS [Name],SCHEMA_NAME(sp.schema_id) AS [Schema]");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"FROM sys.all_objects AS sp ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"LEFT OUTER JOIN sys.sql_modules AS smsp ON smsp.object_id = sp.object_id ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"LEFT OUTER JOIN sys.system_sql_modules AS ssmsp ON ssmsp.object_id = sp.object_id ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"WHERE ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"(sp.type = N'P' OR sp.type = N'RF' OR sp.type='PC')");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"and(CAST( case  when sp.is_ms_shipped = 1 then 1 when (  select  major_id  from  sys.extended_properties  where  major_id = sp.object_id and  minor_id = 0 and  class = 1 and  name = N'microsoft_database_tools_support')  is not null then 1 else 0 end                       AS bit)=0) ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"ORDER BY  [Name] ASC ");
            }
            if (pSQLServerVersion == 2000)
            {
                
                wQuery.Append(@"SELECT");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"sp.name AS [Name],");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"'Server[@Name=' + quotename(CAST(serverproperty(N'Servername') ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"AS sysname),'''') + ']' + '/Database[@Name=' + quotename(db_name(),'''') + ']' + '/StoredProcedure[@Name=' + ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"quotename(sp.name,'''') + ' and @Schema=' + quotename(ssp.name,'''') + ']' AS [Urn],");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"ssp.name AS [Schema],");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"CAST((SELECT TOP 1 encrypted ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"FROM dbo.syscomments p WHERE sp.id = p.id AND p.colid=1 and p.number < 2) AS bit) AS [IsEncrypted],");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"1 AS [ImplementationType],");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"sp.crdate AS [CreateDate]");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"FROM");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"dbo.sysobjects AS sp");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"INNER JOIN sysusers AS ssp ON ssp.uid = sp.uid");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"WHERE");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"(sp.xtype = N'P' OR sp.xtype = N'RF')and(CAST(");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"                CASE WHEN (OBJECTPROPERTY(sp.id, N'IsMSShipped')=1) ");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"THEN 1 WHEN 1 = OBJECTPROPERTY(sp.id, N'IsSystemTable') THEN 1 ELSE 0 END");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"             AS bit)=0)");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"ORDER BY");
                wQuery.Append(Environment.NewLine);
                wQuery.Append(@"[Schema] ASC,[Name] ASC");
                wQuery.Append(Environment.NewLine);

            }
            //wQuery.Append(" SELECT sp.name AS [Name], 'Server[@Name=' + quotename(CAST(serverproperty(N'Servername') AS sysname),'''') + ']' + '/Database[@Name=' + ");
            //wQuery.Append(" quotename(db_name(),'''') + ']' + '/StoredProcedure[@Name=' + quotename(sp.name,'''') + ' and @Schema=' + ");
            //wQuery.Append(" quotename(SCHEMA_NAME(sp.schema_id),'''') + ']' AS [Urn],");
            //wQuery.Append(" SCHEMA_NAME(sp.schema_id) AS [Schema],");
            //wQuery.Append(" CAST(CASE WHEN ISNULL(smsp.definition, ssmsp.definition) IS NULL THEN 1 ELSE 0 END AS bit) AS [IsEncrypted],");
            //wQuery.Append(" CASE WHEN sp.type = N'P' THEN 1 WHEN sp.type = N'PC' THEN 2 ELSE 1 END AS [ImplementationType],");
            //wQuery.Append(" sp.create_date AS [CreateDate]");
            //wQuery.Append(" FROM");
            //wQuery.Append(" sys.all_objects AS sp");
            //wQuery.Append(" LEFT OUTER JOIN sys.sql_modules AS smsp ON smsp.object_id = sp.object_id");
            //wQuery.Append(" LEFT OUTER JOIN sys.system_sql_modules AS ssmsp ON ssmsp.object_id = sp.object_id");
            //wQuery.Append(" WHERE");
            //wQuery.Append(" (sp.type = N'P' OR sp.type = N'RF' OR sp.type='PC')and(CAST(");
            //wQuery.Append(" case ");
            //wQuery.Append(" when sp.is_ms_shipped = 1 then 1");
            //wQuery.Append(" when (");
            //wQuery.Append("  select ");
            //wQuery.Append(" major_id ");
            //wQuery.Append(" from ");
            //wQuery.Append(" sys.extended_properties ");
            //wQuery.Append(" where ");
            //wQuery.Append(" major_id = sp.object_id and ");
            //wQuery.Append(" minor_id = 0 and ");
            //wQuery.Append(" class = 1 and ");
            //wQuery.Append(" name = N'microsoft_database_tools_support') ");
            //wQuery.Append(" is not null then 1");
            //wQuery.Append(" else 0");
            //wQuery.Append(" end          ");
            //wQuery.Append("             AS bit)=0)");
            //wQuery.Append(" ORDER BY ");
            //wQuery.Append(" [Schema] ASC,[Name] ASC ");
            return wQuery.ToString();
        }


		/// <summary>
		/// Obtione informacion de la tabla.-
		/// </summary>
        /// <param name="pStoredProcedureName">Nombre del Stored Procedure</param>
        /// <returns>DataSet</returns>
		private  DataSet GetParametersFromStoredProcedure(string pStoredProcedureName)
		{
			using(SqlConnection wCnn = new SqlConnection (_CnnString))
			using (SqlCommand wCmd = new SqlCommand())
			{
				DataSet wDs =null;
				SqlParameter wParam = null;
				try
				{
					wDs = new DataSet ();
					wCnn.Open();
		
					wCmd.CommandType = CommandType.StoredProcedure;
					wCmd.CommandText = "sp_sproc_columns";
		
					wParam = wCmd.Parameters.Add("@procedure_name",SqlDbType.VarChar ,390);
					wParam.Value = pStoredProcedureName;

					wCmd.Connection = wCnn;
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
	

		/// <summary>
		/// Obtione text des la StoredProcedure.-
		/// </summary>
		/// <param name="pStoredProcedureName"></param>
		/// <returns></returns>
		private string GetTextFromStoredProcedure(string pStoredProcedureName)
		{
			using(SqlConnection wCnn = new SqlConnection (_CnnString))
			using (SqlCommand wCmd = new SqlCommand())
			{
				DataSet wDs =null;
				SqlParameter wParam = null;
				try
				{
					wDs = new DataSet ();
					wCnn.Open();
		
					wCmd.CommandType = CommandType.StoredProcedure;
					wCmd.CommandText = "sp_helptext";
		
					wParam = wCmd.Parameters.Add("@objname",SqlDbType.VarChar ,1552);
					wParam.Value = pStoredProcedureName;

					wCmd.Connection = wCnn;
					SqlDataAdapter wDa = new SqlDataAdapter(wCmd);
				
					wDa.Fill(wDs);
					wCnn.Close();
					return wDs.Tables[0].Rows[0]["Text"].ToString();
				}
				catch(SqlException ex)
				{
					throw ex;
				}
			}
		}


				
		/// <summary>
		/// Obtione informacion de la tabla.-
		/// </summary>
		/// <param name="pNombreTabla"></param>
		/// <returns></returns>
		private  DataSet GetStoreProceduresFromTable(string pNombreTabla)
		{
			using(SqlConnection wCnn = new SqlConnection (_CnnString))
			using (SqlCommand wCmd = new SqlCommand())
			{
				DataSet wDs =null;
				SqlParameter wParam = null;
				try
				{
					wDs = new DataSet ();
					wCnn.Open();

					wCmd.CommandType = CommandType.StoredProcedure;
					wCmd.CommandText = "sp_depends";
		
					wParam = wCmd.Parameters.Add("@objname",SqlDbType.VarChar ,776);
					wParam.Value = pNombreTabla;


					wCmd.Connection = wCnn;
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
	
		#endregion}

        #endregion
    }
}
