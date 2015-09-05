using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Fwk.DataBase.DataEntities;

namespace Fwk.DataBase
{
    /// <summary>
    /// 
    /// </summary>
    public class UserDefinedTypesBack : HandlersBase
    {
        private UserDefinedTypes _UserDefinedTypes;
        private String _GetUserDefinedTypesQuery;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="pCnnString"></param>
        public UserDefinedTypesBack(string pCnnString)
            : base(pCnnString)
        {
            _UserDefinedTypes = new UserDefinedTypes();
            _GetUserDefinedTypesQuery = GetQuery();
        }

        /// <summary>
        /// Carga los tipos definidos por el usuario
        /// </summary>
        /// <returns>Tables </returns>
        internal UserDefinedTypes LoadUserDefinedTypes()
        {

            DataTable wDttTypes = null;
            UserDefinedType wUserDefinedType;
            UserDefinedTypes wUserDefinedTypes = new UserDefinedTypes();
            Tables wTables = new Tables();
            try
            {
                wDttTypes = GetUserDefinedTypesFromDataBase();
                wDttTypes.TableName = "Types";
                foreach (DataRow oDtr in wDttTypes.Rows)
                {
                    wUserDefinedType = new UserDefinedType();
                    wUserDefinedType.Name = oDtr["Name"].ToString();
                    wUserDefinedType.Nullable = Convert.ToBoolean(oDtr["Nullable"]);
                    wUserDefinedType.Length = Convert.ToInt32(oDtr["Length"]);
                    wUserDefinedType.NumericPrecision = Convert.ToInt32(oDtr["NumericPrecision"]);
                    wUserDefinedType.Schema = oDtr["Schema"].ToString();
                    wUserDefinedType.SystemType = oDtr["SystemType"].ToString();
                    
                    wUserDefinedTypes.Add(wUserDefinedType);
                }


                wDttTypes.Dispose();
                wDttTypes = null;

                OnAddElementEvent();
                return wUserDefinedTypes;

            }
            catch (Exception ex)
            { throw ex; }

        }

        DataTable GetUserDefinedTypesFromDataBase()
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

                    wCmd.CommandText = _GetUserDefinedTypesQuery;

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


        String GetQuery()
        {

            StringBuilder sb = new StringBuilder(5000);
     
            sb.Append(@"SELECT");
            sb.Append(Environment.NewLine);
            sb.Append(@"st.name AS [Name],");
            sb.Append(Environment.NewLine);
            sb.Append(@"sst.name AS [Schema],");
            sb.Append(Environment.NewLine);
            sb.Append(@"baset.name AS [SystemType],");
            sb.Append(Environment.NewLine);
            sb.Append(@"CAST(CASE WHEN baset.name IN (N'nchar', N'nvarchar') AND st.max_length <> -1 ");
            sb.Append(Environment.NewLine);
            sb.Append(@"THEN st.max_length/2 ELSE st.max_length END AS int) AS [Length],");
            sb.Append(Environment.NewLine);
            sb.Append(@"CAST(st.precision AS int) AS [NumericPrecision],");
            sb.Append(Environment.NewLine);
            sb.Append(@"CAST(st.scale AS int) AS [NumericScale],");
            sb.Append(Environment.NewLine);
            sb.Append(@"st.is_nullable AS [Nullable]");
            sb.Append(Environment.NewLine);
            sb.Append(@"FROM  sys.types AS st");
            sb.Append(Environment.NewLine);
            sb.Append(@"INNER JOIN sys.schemas AS sst ON sst.schema_id = st.schema_id");
            sb.Append(Environment.NewLine);
            sb.Append(@"LEFT OUTER JOIN sys.types AS baset ON baset.user_type_id = st.system_type_id ");
            sb.Append(Environment.NewLine);
            sb.Append(@"and baset.user_type_id = baset.system_type_id");
            sb.Append(Environment.NewLine);
            sb.Append(@"WHERE");
            sb.Append(Environment.NewLine);
            sb.Append(@"(st.schema_id!=4 and st.system_type_id!=240 and st.user_type_id != st.system_type_id)");
            sb.Append(Environment.NewLine);
            sb.Append(@"ORDER BY");
            sb.Append(Environment.NewLine);
            sb.Append(@"[Schema] ASC,[Name] ASC");
            sb.Append(Environment.NewLine);


            return sb.ToString();
        }

    }
}
