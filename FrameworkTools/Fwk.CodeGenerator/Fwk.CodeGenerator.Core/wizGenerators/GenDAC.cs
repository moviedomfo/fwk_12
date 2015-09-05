using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Smo;

namespace Fwk.CodeGenerator
{

    public static class GenDAC
    {
        static string _DAC_tt;
        static string _Method_tt;
        static GenDAC()
        {
            _DAC_tt = FwkGeneratorHelper.GetFileTemplate("DAC.txt");
            _Method_tt = FwkGeneratorHelper.TemplateDocument.GetTemplate("Method").Content; //FwkGeneratorHelper.GetFileTemplate("Method.txt");

        }


        public static string Gen_DAC(TableViewBase pTable, bool pPerformBatch, string projectNmae)
        {
            StringBuilder wClass = new StringBuilder(_DAC_tt);
            StringBuilder wMethods = new StringBuilder();

            foreach (CodeGeneratorCommon.MethodActionType t in FwkGeneratorHelper.MethodActionTypeList)
            {
                wMethods.AppendLine(GenMethod(pTable, t));

                if (t == CodeGeneratorCommon.MethodActionType.Insert || t == CodeGeneratorCommon.MethodActionType.Update)
                    if (pPerformBatch)
                        wMethods.AppendLine(GenBatchMethod(pTable, t));
            }

            wClass.Replace(CodeGeneratorCommon.CommonConstants.CONST_BODY, wMethods.ToString());
            wClass.Replace(CodeGeneratorCommon.CommonConstants.CONST_AUTHOR, Environment.UserName);
            wClass.Replace(CodeGeneratorCommon.CommonConstants.CONST_ENTITY_NAME, pTable.Name);
            wClass.Replace(CodeGeneratorCommon.CommonConstants.CONST_CREATION_DATETIME, string.Format("{0:s}", DateTime.Now));
            wClass.Replace(CodeGeneratorCommon.CommonConstants.CONST_FwkProject_NAME, projectNmae);

            return wClass.ToString();
        }
        static string GenBatchMethod(TableViewBase pTable, CodeGeneratorCommon.MethodActionType t)
        {
            StringBuilder wMethod = new StringBuilder(FwkGeneratorHelper.TemplateDocument.GetTemplate("MethodBatch").Content);
            wMethod.Replace("[SummaryParams]", GenParametersSummary(t, pTable));
            wMethod.Replace("[ParamArgs]", GenMethodParameters(t, pTable));
            wMethod.Replace("[MethodName]", t.ToString());
            wMethod.Replace("[StoredProcedureName]", GetSPName(pTable, t));
            wMethod.Replace("[Parameters]", GenSPParameters_Batch(pTable, t));
            return wMethod.ToString();
        }
        static string GenMethod(TableViewBase pTable, CodeGeneratorCommon.MethodActionType t)
        {
            StringBuilder wMethod = new StringBuilder(_Method_tt);
            wMethod.Replace("[SummaryParams]", GenParametersSummary(t, pTable));
            wMethod.Replace("[ParamArgs]", GenMethodParameters(t, pTable));
            wMethod.Replace("[MethodName]", t.ToString());
            wMethod.Replace("[RetType]", GetRetType(pTable, t));
            wMethod.Replace("[StoredProcedureName]", GetSPName(pTable, t));
            wMethod.Replace("[Parameters]", GenSPParameters(pTable, t));
            wMethod.Replace("[Declarations]", GenDeclaration(pTable, t));
            wMethod.Replace("[Return]", GenMethodReturn(pTable, t));
            return wMethod.ToString();
        }

        private static string GenMethodReturn(TableViewBase pTable, CodeGeneratorCommon.MethodActionType t)
        {
            StringBuilder wBuilderReturn = null;
            switch (t)
            {
                case CodeGeneratorCommon.MethodActionType.Insert:
                    {
                        Column pPK = FwkGeneratorHelper.GetPrimaryKey(pTable);
                        if (pPK != null)
                        {
                            
                            wBuilderReturn = new StringBuilder("  wDataBase.ExecuteNonQuery(wCmd);");
                            wBuilderReturn.AppendLine(FwkGeneratorHelper.TemplateDocument.GetTemplate("InsertReturn").Content);
                            wBuilderReturn.Replace(CodeGeneratorCommon.CommonConstants.CONST_ENTITY_PROPERTY_NAME, pPK.Name);
                            wBuilderReturn.Replace(CodeGeneratorCommon.CommonConstants.CONST_TYPENAME, FwkGeneratorHelper.GetCSharpType(pPK));

                            return wBuilderReturn.ToString();
                        }
                        else
                            return "  wDataBase.ExecuteNonQuery(wCmd);";
                    }
                case CodeGeneratorCommon.MethodActionType.Update:
                    return "  wDataBase.ExecuteNonQuery(wCmd);";

                case CodeGeneratorCommon.MethodActionType.SearchByParam:

                    wBuilderReturn = new StringBuilder(FwkGeneratorHelper.TemplateDocument.GetTemplate("SearchReturn").Content);

                    return wBuilderReturn.ToString();
                case CodeGeneratorCommon.MethodActionType.Delete:
                    return  "  wDataBase.ExecuteNonQuery(wCmd);";

            }

            return string.Empty;

        }

        private static string GenDeclaration(TableViewBase pTable, CodeGeneratorCommon.MethodActionType t)
        {

            switch (t)
            {
                case CodeGeneratorCommon.MethodActionType.GetByParam:
                case CodeGeneratorCommon.MethodActionType.SearchByParam:
                    {
                        return FwkGeneratorHelper.TemplateDocument.GetTemplate("EntityAnListDeclaration").Content;
                    }

            }

            return string.Empty;

        }



        /// <summary>
        /// Genera comentarios sobre los parámetros de un método.
        /// </summary>
        /// <param name="pMethodInfo">información sobre el método a generar.</param>
        /// <returns>Comentarios sobre los parámetros.</returns>
        /// <author>Marcelo Oviedo</author>
        static string GenParametersSummary(CodeGeneratorCommon.MethodActionType pMethodActionType, TableViewBase pTable)
        {
            StringBuilder wBuilder = new StringBuilder(FwkGeneratorHelper.TemplateDocument.GetTemplate("ParameterSummary").Content);



            switch (pMethodActionType)
            {
                case CodeGeneratorCommon.MethodActionType.Insert:
                case CodeGeneratorCommon.MethodActionType.Update:
                case CodeGeneratorCommon.MethodActionType.GetByParam:
                case CodeGeneratorCommon.MethodActionType.SearchByParam:

                    wBuilder.Replace("[MethodParameterName]", pTable.Name);
                    wBuilder.Replace("[ParameterName]", pTable.Name);
                    break;
                case CodeGeneratorCommon.MethodActionType.Delete:
                    Column pPK = FwkGeneratorHelper.GetPrimaryKey(pTable);
                    if (pPK != null)
                    {
                        wBuilder.Replace("[MethodParameterName]", pPK.Name);
                    }
                    else
                    {
                        wBuilder.Replace("[MethodParameterName]", "pId");
                    }
                    wBuilder.Replace("[ParameterName]", string.Concat("Id por el cual realizar la busqueda de registros a eliminar de tabla ", pTable.Name));
                    break;
            }
            return wBuilder.ToString();




        }

        /// <summary>
        /// Genera código de parámetros de llamado a un método.
        /// </summary>
        /// <param name="CodeGeneratorCommon.MethodActionType">información sobre el método a generar.</param>
        /// <param name="pTable">tabla.</param>
        /// <returns>Código que representa los parámetros para ejecutar el método.</returns>
        /// <author>Marcelo Oviedo</author>
        static string GenMethodParameters(CodeGeneratorCommon.MethodActionType pMethodActionType, TableViewBase pTable)
        {
            String wBuilder = string.Empty;
            switch (pMethodActionType)
            {
                case CodeGeneratorCommon.MethodActionType.Insert:
                case CodeGeneratorCommon.MethodActionType.Update:
                case CodeGeneratorCommon.MethodActionType.GetByParam:
                case CodeGeneratorCommon.MethodActionType.SearchByParam:

                    wBuilder = string.Concat(pTable.Name, " p", pTable.Name);
                    break;
                case CodeGeneratorCommon.MethodActionType.Delete:
                    Column pPK = FwkGeneratorHelper.GetPrimaryKey(pTable);
                    if (pPK != null)
                    {
                        FwkGeneratorHelper.GetCSharpType(pPK);
                        wBuilder = String.Concat(FwkGeneratorHelper.GetCSharpType(pPK), " p", pPK.Name);
                    }
                    else
                    {
                        wBuilder = String.Concat("int pId");
                    }

                    break;
            }
            return wBuilder;


        }

        /// <summary>
        /// Retorno del metodo
        /// </summary>
        /// <param name="pTable"></param>
        /// <param name="pMethodActionType"></param>
        /// <returns></returns>
        static string GetRetType(TableViewBase pTable, CodeGeneratorCommon.MethodActionType pMethodActionType)
        {
            String wBuilder = string.Empty;
            Column c = FwkGeneratorHelper.GetPrimaryKey(pTable);
            switch (pMethodActionType)
            {
                case CodeGeneratorCommon.MethodActionType.Insert:

                case CodeGeneratorCommon.MethodActionType.Update:
                case CodeGeneratorCommon.MethodActionType.Delete:
                    wBuilder = "void";
                    break;
                case CodeGeneratorCommon.MethodActionType.SearchByParam:
                    wBuilder = string.Concat(pTable.Name, "List");
                    break;
                case CodeGeneratorCommon.MethodActionType.GetByParam:
                    wBuilder = pTable.Name;
                    break;
            }
            return wBuilder;
        }

        /// <summary>
        /// Retorno del metodo
        /// </summary>
        /// <param name="pTable"></param>
        /// <param name="pMethodActionType"></param>
        /// <returns></returns>
        static string GetSPName(TableViewBase pTable, CodeGeneratorCommon.MethodActionType pMethodActionType)
        {
            String sufix = string.Empty;

            switch (pMethodActionType)
            {
                case CodeGeneratorCommon.MethodActionType.Insert:
                    sufix = "_i";
                    break;
                case CodeGeneratorCommon.MethodActionType.GetByParam:
                    sufix = "_gp";
                    break;
                case CodeGeneratorCommon.MethodActionType.Update:
                    sufix = "_u";
                    break;
                case CodeGeneratorCommon.MethodActionType.Delete:
                    sufix = "_d";
                    break;
                case CodeGeneratorCommon.MethodActionType.SearchByParam:

                    sufix = "_sp";
                    break;
                case CodeGeneratorCommon.MethodActionType.Get:
                    sufix = "_g";
                    break;

            }

            return string.Concat(pTable.Name, sufix);
        }


        static string GenSPParameters(TableViewBase pTable, CodeGeneratorCommon.MethodActionType pMethodActionType)
        {

            StringBuilder wParams = new StringBuilder();



            switch (pMethodActionType)
            {
                case CodeGeneratorCommon.MethodActionType.Insert:
                    foreach (Column c in pTable.Columns)
                    {
                        if (!FwkGeneratorHelper.NotSupportTypes_ToIncludeInBackEnd.Contains(c.DataType.SqlDataType.ToString().ToLower()))
                        {
                            if (c.InPrimaryKey)
                            {
                                wParams.Append(GetOutParameter(pTable, c));
                            }
                            else
                            {
                                wParams.Append(GetInParameter(pTable, c));
                            }
                        }
                    }
                    break;

                case CodeGeneratorCommon.MethodActionType.Update:
                    foreach (Column c in pTable.Columns)
                    {
                        if (!FwkGeneratorHelper.NotSupportTypes_ToIncludeInBackEnd.Contains(c.DataType.SqlDataType.ToString().ToLower()))
                        {
                            wParams.Append(GetInParameter(pTable, c));
                        }
                    }
                    break;
                case CodeGeneratorCommon.MethodActionType.Delete:

                    Column cPK = FwkGeneratorHelper.GetPrimaryKey(pTable);
                    if (cPK != null)
                        wParams.Append(GetInParameter(cPK.Name, FwkGeneratorHelper.GetDBType(cPK)));
                    else
                        wParams.Append(GetInParameter("Id", "System.Data.DbType.Int32"));

                    break;
                case CodeGeneratorCommon.MethodActionType.SearchByParam:
               
                    foreach (Column c in pTable.Columns)
                    {
                        if (FwkGeneratorHelper.GeColumnFindeable(c))
                            wParams.Append(GetInParameter(pTable, c));

                    }
                    break;
                case CodeGeneratorCommon.MethodActionType.Get:
                    wParams.Append(string.Empty);
                    break;

            }
            return wParams.ToString();
        }

        static string GetInParameter(TableViewBase pTable, Column c)
        {
            StringBuilder wParamBuilder = new StringBuilder(FwkGeneratorHelper.TemplateDocument.GetTemplate("ParameterInput").Content);
            //Si es un tipo de dato string y hacepta nulos se agrega la condicion para decidir si pasar o no el parametros al SP
            if (c.Nullable && FwkGeneratorHelper.GetDBType(c).Contains("string"))
                wParamBuilder.Replace("[ConditionalString]", FwkGeneratorHelper.TemplateDocument.GetTemplate("ConditionalString").Content);
            else
                wParamBuilder.Replace("[ConditionalString]", String.Empty);

            //quito si esxiste la cadena .Value de [Property_Name].Value.ToString("yy
            if(!c.Nullable )
                wParamBuilder.Replace("Value.", string.Empty);

            wParamBuilder.Replace("[ParameterName]", c.Name);
            wParamBuilder.Replace("[ParameterType]", FwkGeneratorHelper.GetDBType(c));
            wParamBuilder.Replace("[ParameterValue]", string.Concat("p", pTable.Name, ".", c.Name));

            
          

            return wParamBuilder.ToString();
        }
        static string GetInParameter(string name, string type)
        {
            StringBuilder wParamBuilder = new StringBuilder(FwkGeneratorHelper.TemplateDocument.GetTemplate("ParameterInput").Content);

            //Si es un tipo de dato string y hacepta nulos se agrega la condicion para decidir si pasar o no el parametros al SP
            if (type.Contains("string"))
                wParamBuilder.Replace("[ConditionalString]", FwkGeneratorHelper.TemplateDocument.GetTemplate("ConditionalString").Content);
            else
                wParamBuilder.Replace("[ConditionalString]", String.Empty);

            wParamBuilder.Replace("[ParameterName]", name);
            wParamBuilder.Replace("[ParameterType]", type);
            wParamBuilder.Replace("[ParameterValue]", "p" + name);


            return wParamBuilder.ToString();
        }

        static string GetOutParameter(TableViewBase pTable, Column c)
        {
            StringBuilder wParamBuilder = new StringBuilder(FwkGeneratorHelper.TemplateDocument.GetTemplate("ParameterOutput").Content);
            wParamBuilder.Replace("[ParameterName]", c.Name);
            wParamBuilder.Replace("[ParameterType]", FwkGeneratorHelper.GetDBType(c));
            wParamBuilder.Replace("[ParameterLength]", c.DataType.MaximumLength.ToString());


            return wParamBuilder.ToString();
        }


        static string GenSPParameters_Batch(TableViewBase pTable, CodeGeneratorCommon.MethodActionType pMethodActionType)
        {

            StringBuilder wParams = new StringBuilder();
            int i = 0;
            bool appendProperty = true;
            Column primaryKey = FwkGeneratorHelper.GetPrimaryKey(pTable);
            foreach (Column c in pTable.Columns)
            {
                i++;
                if (pMethodActionType == CodeGeneratorCommon.MethodActionType.Insert ||
                    pMethodActionType == CodeGeneratorCommon.MethodActionType.Update)
                {

                    if (primaryKey != null)
                        appendProperty = !(primaryKey == c && pMethodActionType == CodeGeneratorCommon.MethodActionType.Insert);

                    if (appendProperty)
                        //i == pTable.Columns.Count --> Fin de la coleccion
                        wParams.Append(Get_Property_Batch(c, (i == pTable.Columns.Count)));

                }
               

            }
            return wParams.ToString();
        }


        /// <summary>
        /// Obtiene el seteo de parametro que se envia a un store procedure  para Aplication Block,
        /// en forma de batch.-
        /// 
        /// </summary>
        /// <param name="pTableName">Nombre de tabla</param>
        /// <param name="pColumnName">Nombre de columna</param>
        /// <param name="pType">Tipo de SQL Server</param>
        /// <param name="pLastField">indica si es el ultimo parametro</param>
        ///<example>
        /// <code>
        /// 		
        ///   BatchCommandText.Append("@[Property_Name] = ");
        ///   if (w[NamePattern].[Property_Name] != null)
        ///    {
        ///         BatchCommandText.Append(w[NamePattern].[Property_Name]  == true ? "1":"0");
        ///     }
        ///     else { BatchCommandText.Append("NULL"); }
        ///     BatchCommandText.Append( ",");
        /// 
        /// </code>
        /// </example>
        /// <returns>string</returns>
        static string Get_Property_Batch(Column c, bool pLastField)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();

            switch (c.DataType.ToString().ToUpper())
            {
                case "BIT":
                    str.Append(FwkGeneratorHelper.TemplateDocument.GetTemplate("SPParameterBatchBit").Content);
                    break;
                case "REAL":
                case "NUMERIC":
                case "BIGINT":
                case "SMALLINT":
                case "INT":
                case "TINYINT":
                    str.Append(FwkGeneratorHelper.TemplateDocument.GetTemplate("SPParameterBatchInteger").Content);
                    break;
                case "MONEY":
                case "SMALLMONEY":
                case "DECIMAL":
                case "FLOAT":
                    str.Append(FwkGeneratorHelper.TemplateDocument.GetTemplate("SPParameterBatchDecimal").Content);
                    break;
                case "SMALLDATETIME":
                case "DATETIME":
                    str.Append(FwkGeneratorHelper.TemplateDocument.GetTemplate("SPParameterBatchDateTime").Content);
                    break;
                case "TEXT":
                case "NTEXT":
                case "CHAR":
                case "NCHAR":
                case "VARCHAR":
                case "NVARCHAR":
                    str.Append(FwkGeneratorHelper.TemplateDocument.GetTemplate("SPParameterBatchString").Content);
                    break;
                ///TODO:Ver paso de binarios por batch
                case "IMAGE":
                case "VARBINARY":
                case "BINARY":
                    str.Append(FwkGeneratorHelper.TemplateDocument.GetTemplate("SPParameterBatchString").Content);
                    break;

            }
            if (!c.Nullable) str.Replace("[Batch_NULL_Question]", String.Empty);

            else
            {
                if (FwkGeneratorHelper.GetCSharpType(c).Contains("string"))
                    str.Replace("[Batch_NULL_Question_string]", FwkGeneratorHelper.TemplateDocument.GetTemplate("Batch_NULL_Question").Content);
                else
                    str.Replace("[Batch_NULL_Question]", FwkGeneratorHelper.TemplateDocument.GetTemplate("Batch_NULL_Question").Content);
            }



            str.Replace(CodeGeneratorCommon.CommonConstants.CONST_ENTITY_PROPERTY_NAME, c.Name);

            if (pLastField)
                str.Replace("wBatchCommandText.Append( \",\");", "wBatchCommandText.Append( \";\");");

            return str.ToString();
        }
       
    }
}
