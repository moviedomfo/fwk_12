using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using fwkDataEntities = Fwk.DataBase.DataEntities;

using System.Diagnostics;
using Microsoft.SqlServer.Management.Smo;
using Fwk.CodeGenerator;
using System.Windows.Forms;

namespace Fwk.CodeGenerator
{
    /// <summary>
    /// Generador de codigo especializado para generar Store procedures apartir de Objetos Tablas
    /// </summary>
    public class GenSP
    {
        static String _CommonTemplate = String.Empty;
        static String _CommonTemplateExecuteSQL = String.Empty;

        static GenSP()
        {

            _CommonTemplate = FwkGeneratorHelper.TemplateDocument.GetTemplate("SP_Common").Content;
            _CommonTemplateExecuteSQL = FwkGeneratorHelper.TemplateDocument.GetTemplate("SP_Search_DefinicionGlobal").Content;

            _CommonTemplate = _CommonTemplate.Replace("<DROP>", GetDROP());
            _CommonTemplateExecuteSQL = _CommonTemplateExecuteSQL.Replace("<DROP>", GetDROP());
        }

        
      


        /// <summary>
        /// Genera el código fuente de un conjunto de procedimientos almacenados.
        /// </summary>
        /// <remarks>
        /// Este método hace distinción de dos tipos de métodos: métodos <b>built-in</b> y métodos <b>generados por el usuario</b> (<see cref="MethodActionType"/>).
        /// La generación de los del tipo built-in la determina esta clase, los parámetros son tomados de los campos de la tabla seleccionada para generar la entidad y sus métodos. Para los del otro tipo, se tomarán los parámetros selecionados por el usuario o los propios de un procedimiento almacenado preexistente.
        /// </remarks>
        /// <param name="pEntityInfo">Entidad para la que se generarán los procedimientos almacenados.</param>
        /// <param name="pProceduresCode">Lista de código generado.</param>
        /// <date>2006-03-20T00:00:00</date>
        /// <author>Marcelo Oviedo</author>
        internal static List<GeneratedCode> GenCode(TableViewBase pTable, List<GeneratedCode> pProceduresCode)
        {

            string wSPBodyCode;


            foreach (CodeGeneratorCommon.MethodActionType wMethodType in FwkGeneratorHelper.MethodActionTypeList)
            {

                wSPBodyCode = FwkGeneratorHelper.TemplateDocument.GetTemplate(string.Concat("SP_", wMethodType)).Content;

                switch (wMethodType)
                {
                    case CodeGeneratorCommon.MethodActionType.Insert:
                        {
                            GenCodeInsert(pTable,  wSPBodyCode, wMethodType, pProceduresCode);
                            break;
                        }

                    case CodeGeneratorCommon.MethodActionType.Update:
                        {
                            GenCodeUpdate(pTable,  wSPBodyCode, wMethodType, pProceduresCode);
                            break;
                        }

                    case CodeGeneratorCommon.MethodActionType.Delete:
                        {
                            GenCodeDelete(pTable, wSPBodyCode, wMethodType, pProceduresCode);
                            break;
                        }
                    //case MethodActionType.Get:
                    //    {
                    //        GenCodeGet(wMethodInfo, wActionCode, pProceduresCode);
                    //        break;
                    //    }
                    //case MethodActionType.GetAll:
                    //case MethodActionType.GetAllPaginated:
                    //    {
                    //        GenCodeGetAll(wMethodInfo, wSPBodyCode, pProceduresCode);
                    //        break;
                    //    }
                    case CodeGeneratorCommon.MethodActionType.SearchByParam:
                        {
                            GenCodeGetByParam(pTable, wSPBodyCode, wMethodType, pProceduresCode);
                            break;
                        }

                }


            }
            return pProceduresCode;

        }





        /// <summary>
        /// Genera código fuente de un parámetro del procedimiento almacenado a partir de un campo de la tabla.
        /// </summary>
        /// <param name="pTableFieldInfo">información sobre el parámetro a generar.</param>
        /// <param name="pActionType">Tipo de Acción a realizar por el procedimiento almacenado.</param>
        /// <param name="pSetDirection">Dirección del parámetro.</param>
        /// <param name="pSetDefaultNull">Indica si se pasa NULL como valor por defecto.</param>
        /// <returns>Código fuente del parámetro.</returns>
        /// <date>2007-5-25T00:00:00</date>
        /// <author>Marcelo Oviedo</author>
        static StringBuilder BuildParameter(Column pColumn,
           CodeGeneratorCommon.MethodActionType pActionType, bool pSetDirection, bool pSetDefaultNull)
        {
            string wDirection = string.Empty;
            StringBuilder wBuilder = new StringBuilder();

            wBuilder.Append("\t");
            wBuilder.Append(FwkGeneratorHelper.GetParameterPattern(pColumn));
            //@Nombre
            wBuilder.Replace("[Name]", "@" + pColumn.Name);
            if (pColumn.DataType.ToString().ToLower().Contains("image"))

                wBuilder.Replace("[Type]", "varbinary");
            else
                wBuilder.Replace("[Type]", pColumn.DataType.ToString());

            if (pColumn.DataType.MaximumLength != -1 && pColumn.DataType.MaximumLength != 0)
                wBuilder.Replace("[Length]", pColumn.DataType.MaximumLength.ToString());
            else
                wBuilder.Replace("[Length]", "max");

            wBuilder.Replace("[Precision]", pColumn.DataType.NumericPrecision.ToString());
            wBuilder.Replace("[Scale]", pColumn.DataType.NumericScale.ToString());

            if (pSetDirection)
            {
                ParameterDirection wParamDirection = ((pColumn.InPrimaryKey) && (pActionType == CodeGeneratorCommon.MethodActionType.Insert)) ? ParameterDirection.Output : ParameterDirection.Input;

                switch (wParamDirection)
                {
                    case System.Data.ParameterDirection.Input:
                        {
                            wDirection = String.Empty;
                            break;
                        }
                    case System.Data.ParameterDirection.Output:
                        {
                            wDirection = "OUTPUT";
                            break;
                        }

                    case System.Data.ParameterDirection.InputOutput:
                        {
                            wDirection = String.Empty;
                            break;
                        }
                    default:
                        {
                            wDirection = string.Empty;
                            break;
                        }
                }
            }

            wBuilder.Replace("[Direction]", wDirection);

            if (pSetDefaultNull && pColumn.Nullable)
            {
                wBuilder.Append(" = NULL");
            }

            wBuilder.Append(",\r\n");

            return wBuilder;
        }



        /// <summary>
        /// Genera código común para todas las acciones.
        /// </summary>
        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
        /// <param name="pSpBody">StringBuilder sobre el cual se realizarán los reemplazos de tags.</param>

        /// <date>2007-5-25T00:00:00</date>
        /// <author>Marcelo Oviedo</author>
        static StringBuilder GenCodeCommon(TableViewBase pTable, string pSpBody)
        {
            StringBuilder wBuilder = new StringBuilder();
            wBuilder.Append(_CommonTemplate);

            wBuilder.Replace("[ProcedureBody]", pSpBody);

            wBuilder.Replace(CodeGeneratorCommon.CommonConstants.CONST_AUTHOR, Environment.UserName);
            wBuilder.Replace(CodeGeneratorCommon.CommonConstants.CONST_CREATION_DATETIME, string.Format("{0:s}", DateTime.Now));
            wBuilder.Replace(CodeGeneratorCommon.CommonConstants.CONST_TABLE_NAME, pTable.Name);

            return wBuilder;
        }

        #region [private methods]

        /// <summary>
        /// Retorna Nombre del SP segun toipo de accion del SP
        /// </summary>
        /// <param name="pTableName">Nombre de tabla</param>
        /// <param name="pActionType">Puede ser get insert update delente etc</param>
        /// <returns>StoredProcedureName</returns>
        static String GetStoredProcedureName(String pTableName, String pSchema, CodeGeneratorCommon.MethodActionType pActionType)
        {

            String pSpName = String.Empty;

      

            switch (pActionType)
            {
                case CodeGeneratorCommon.MethodActionType.Insert:
                    {
                        pSpName = string.Concat(pSchema, ".",pTableName, "_i");
                        break;
                    }

                case CodeGeneratorCommon.MethodActionType.Update:
                    {
                        pSpName = string.Concat(pSchema, ".", pTableName, "_u");
                        break;
                    }

                case CodeGeneratorCommon.MethodActionType.Delete:
                    {
                        pSpName = string.Concat(pSchema, ".", pTableName, "_d");
                        break;
                    }

                case CodeGeneratorCommon.MethodActionType.SearchByParam:
                    {
                        pSpName = string.Concat(pSchema, ".", pTableName, "_s");
                        break;
                    }

            }
           
            return pSpName;

        }

        static String GetDROP()
        {
            //String wStrDrop;

            //----------------------------------------------------------------------
            //-- Cargo el pattern segun la version de SQL Server
            //----------------------------------------------------------------------
            //if (versionSQLServer == 2005)
            //////////wStrDrop = _StoredProcedureTemplate.Keys.GetKey("DropStoreSQL2005").TextContent;
            //else
            //    sbPatternDROP = Common.OpenTextFile(@"Templates\SQL\DropStoreSQL2000.txt");


            return string.Empty;
        }
        /// <summary>
        /// Remueve la cantidad especificada de caracteres al final de la cadena.
        /// </summary>
        /// <param name="pBuilder">StringBuilder para efectuar el recorte de caracteres.</param>
        /// <param name="pCount">Cantidad de caracteres a remover.</param>
        /// <date>2007-5-25T00:00:00</date>
        /// <author>Marcelo Oviedo</author>
        static void RemoveChars(StringBuilder pBuilder, int pCount)
        {
            if (pBuilder.Length > 0)
            {
                pBuilder.Remove(pBuilder.Length - pCount, pCount).Append("\r\n");
            }
        }

        /// <summary>
        /// Devuelve el código generado para una entidad.
        /// </summary>
        /// <param name="pEntityInfo">Entidad para la que se generarán los procedimientos almacenados.</param>
        /// <param name="pProceduresCode">Lista de código generado.</param>
        /// <returns>Código generado para una entidad.</returns>
        /// <date>2006-03-20T00:00:00</date>
        /// <author>Marcelo Oviedo</author>
        static GeneratedCode GetEntityGeneratedCode(EntityInfo pEntityInfo, List<GeneratedCode> pProceduresCode)
        {
            GeneratedCode wResult = null;

            foreach (GeneratedCode wCode in pProceduresCode)
            {
                if (wCode.Id == pEntityInfo.Name)
                {
                    wResult = wCode;
                    break;
                }
            }

            if (wResult == null)
            {
                wResult = new GeneratedCode();
                wResult.Id = pEntityInfo.Name;


                pProceduresCode.Add(wResult);
            }

            return wResult;

        }
        #endregion


        #region [-- generación de código --]



        static void GenCodeGetByParam(TableViewBase pTable, string pSpBody, CodeGeneratorCommon.MethodActionType action, List<GeneratedCode> pProceduresCode)
        {
            GeneratedCode wCode = null;

            try
            {
                String wSPCode = GenerateStoreSearchByParam(pTable);

                wCode = new GeneratedCode();
                wCode.Code.Append(wSPCode);
                wCode.MethodActionType = action;
                wCode.Id = pTable.Name;
                pProceduresCode.Add(wCode);

            }
            finally
            {

                wCode = null;
            }
        }
        static void GenCodeUpdate(TableViewBase pTable, string pSpBody, CodeGeneratorCommon.MethodActionType action, List<GeneratedCode> pProceduresCode)
        {
            StringBuilder wBuilder = null;
            GeneratedCode wCode = null;
            String wIntermediateCode = String.Empty;
            try
            {
                wBuilder = GenCodeCommon(pTable, pSpBody);

                wIntermediateCode = "(" + GenCodeUpdateParameters(pTable, action) + ")";
                wBuilder.Replace("[Parameters]", wIntermediateCode);
                wBuilder.Replace("[SetStatements]", GenCodeUpdateSetStatements(pTable,action));
                wBuilder.Replace("[WhereClause]", GenCodeWhereClause(pTable));

                wBuilder.Replace(CodeGeneratorCommon.CommonConstants.CONST_STOREDPROCEDURE_NAME, GetStoredProcedureName(pTable.Name, pTable.Schema, action));

                //wCode = GetEntityGeneratedCode(pMethodInfo.Entity, pProceduresCode);
                wCode = new GeneratedCode();
                wCode.Id =pTable.Name;
                wCode.Code.Append(wBuilder.ToString());
                wCode.MethodActionType = action;
                pProceduresCode.Add(wCode);

            }
            finally
            {
                wBuilder = null;
                wCode = null;
            }
        }
        static void GenCodeDelete(TableViewBase pTable, string pSpBody, CodeGeneratorCommon.MethodActionType action, List<GeneratedCode> pProceduresCode)
        {

            StringBuilder wBuilder = null;
            GeneratedCode wCode = null;
            String wIntermediateCode = String.Empty;
            try
            {
                wBuilder = new StringBuilder();

                wBuilder = GenCodeCommon(pTable, pSpBody);
                wIntermediateCode = "(" + GenCodeDeleteParameters(pTable, action) + ")";
                wBuilder.Replace("[Parameters]", wIntermediateCode);
                wBuilder.Replace("[WhereClause]", GenCodeWhereClause(pTable));

                wBuilder.Replace(CodeGeneratorCommon.CommonConstants.CONST_STOREDPROCEDURE_NAME, GetStoredProcedureName(pTable.Name, pTable.Schema, action));

                //wCode = GetEntityGeneratedCode(pMethodInfo.Entity, pProceduresCode);
                wCode = new GeneratedCode();
                wCode.Id =pTable.Name;
                wCode.Code.Append(wBuilder.ToString());
                wCode.MethodActionType = action;
                pProceduresCode.Add(wCode);
            }
            finally
            {
                wBuilder = null;
                wCode = null;
            }
        }
        static void GenCodeInsert(TableViewBase pTable, string pSpBody, CodeGeneratorCommon.MethodActionType action, List<GeneratedCode> pProceduresCode)
        {

            StringBuilder wBuilder = null;
            GeneratedCode wCode = null;
            String wIntermediateCode = String.Empty;
            try
            {
                wBuilder = new StringBuilder();

                wBuilder = GenCodeCommon(pTable, pSpBody);
                wIntermediateCode = "(" + GenCodeInsertParameters(pTable, action) + ")";
                wBuilder.Replace("[Parameters]", wIntermediateCode);
                wBuilder.Replace("[Fields]", GenCodeInsertFields(pTable, action));
                wBuilder.Replace("[Values]", GenCodeInsertValues(pTable, action));
                wBuilder.Replace("[ReturnAutogenerated]", GenCodeInsertReturnAutogenerated(pTable, action));

                wBuilder.Replace(CodeGeneratorCommon.CommonConstants.CONST_STOREDPROCEDURE_NAME, GetStoredProcedureName(pTable.Name, pTable.Schema, action));

                //wCode = GetEntityGeneratedCode(pMethodInfo.Entity, pProceduresCode);
                wCode = new GeneratedCode();

                wCode.Id = pTable.Name;
                wCode.Code.Append(wBuilder.ToString());
                wCode.MethodActionType = action;
                pProceduresCode.Add(wCode);
            }
            finally
            {
                wBuilder = null;
                wCode = null;
            }
        }
        static string GenCodeWhereClause(TableViewBase pTable)
        {
            StringBuilder wBuilder = new StringBuilder();


            foreach (Column wColumn in pTable.Columns)
            {
                if ( wColumn.IsForeignKey || wColumn.InPrimaryKey)
                {
                wBuilder.Append(wColumn.Name);
                wBuilder.Append(" = @");

                wBuilder.Append(wColumn.Name);
                wBuilder.Append(" AND \r\n");
                }
            }




            RemoveChars(wBuilder, 6);

            return wBuilder.ToString();
        }
        #endregion



        #region -- auxiliares get --

        /// <summary>
        /// Genera código de parámetros de un procedimiento almacenado de Búsqueda por clave primaria.
        /// </summary>
        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
        /// <returns>Código fuente generado.</returns>
        /// <date>2007-5-25T00:00:00</date>
        /// <author>Marcelo Oviedo</author>
        protected string GenCodeParameters(TableViewBase pTable, CodeGeneratorCommon.MethodActionType action)
        {

            StringBuilder wBuilder = new StringBuilder();

            //if (action == MethodActionType.Get)
            //{
            foreach (Column wColumn in pTable.Columns)
            {
                //if (wColumn.KeyField)// && wColumn.Selected)
                //{
                StringBuilder wParamBuilder = BuildParameter(wColumn, action, false, false);
                wBuilder.Append(wParamBuilder.ToString());
                //}
            }
            //}
            //else
            //{
            //    foreach (ParameterInfo wParameterInfo in pMethodInfo.Parameters)
            //    {

            //        StringBuilder wParamBuilder = base.BuildParameter(wParameterInfo);
            //        wBuilder.Append(wParamBuilder.ToString());
            //    }
            //}

            RemoveChars(wBuilder, 3);

            return wBuilder.ToString();

        }

        /// <summary>
        /// Genera código de campos de retorno de un procedimiento almacenado de Búsqueda.
        /// Genera los campos del SELECT
        /// </summary>
        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
        /// <returns>Código fuente generado.</returns>
        /// <date>2007-5-25T00:00:00</date>
        /// <author>Marcelo Oviedo</author>
        static string GenCodeGetSelectList(TableViewBase pTable)
        {
            StringBuilder wBuilder = new StringBuilder();

            foreach (Column wColumn in pTable.Columns)
            {

                //wBuilder.Append("\t");
                wBuilder.AppendLine(wColumn.Name);
                wBuilder.Append(",");

            }

            RemoveChars(wBuilder, 2);

            return wBuilder.ToString();
        }


        #endregion


        #region -- auxiliares Insert --

        static string GenCodeInsertParameters(TableViewBase pTable, CodeGeneratorCommon.MethodActionType action)
        {
            StringBuilder wBuilder = new StringBuilder();
            StringBuilder wParamBuilder;
            foreach (Column c in pTable.Columns)
            {
                if (IsColumnValidToInsert(c) )
                {
                     wParamBuilder = BuildParameter(c, action, true, true);
                    wBuilder.Append(wParamBuilder.ToString());
                }
            }
            RemoveChars(wBuilder, 3);
            return wBuilder.ToString();
        }

        /// <summary>
        /// Determina si la columna es de tipo valido para pasar como parametro a un SP.-
        /// </summary>
        /// <param name="pColumn"></param>
        /// <returns></returns>
        static bool IsColumnValidToInsert(Column pColumn)
        {
            return !FwkGeneratorHelper.NotSupportTypes_ToInsertStoreProcedure.Contains(pColumn.DataType.Name);
        }
        /// <summary>
        /// Determina si la columna es de tipo valido para pasar como parametro a un SP busqueda.-
        /// </summary>
        /// <param name="pColumn">Columna</param>
        /// <returns>bool</returns>
        /// <author>Marcelo Oviedo</author>
        static bool IsColumnValidToSearch(Column pColumn)
        {
            return !FwkGeneratorHelper.NotSupportTypes_ToSearchInStoreProcedure.Contains(pColumn.DataType.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pMethodInfo"></param>
        /// <returns></returns>
        /// <author>Marcelo Oviedo</author>
        static string GenCodeInsertFields(TableViewBase pTable, CodeGeneratorCommon.MethodActionType action)
        {
            StringBuilder wBuilder = new StringBuilder();

            foreach (Column wColumn in pTable.Columns)
            {
                //!wColumn.Autogenerated && wColumn.Selected &&
                if (IsColumnValidToInsert(wColumn))
                {
                    wBuilder.AppendLine(wColumn.Name);
                    wBuilder.Append(",");
                }
            }

            RemoveChars(wBuilder, 2);

            return wBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pMethodInfo"></param>
        /// <returns></returns>
        /// <author>Marcelo Oviedo</author>
        static string GenCodeInsertValues(TableViewBase pTable, CodeGeneratorCommon.MethodActionType action)
        {
            StringBuilder wBuilder = new StringBuilder();

            foreach (Column wColumn in pTable.Columns)
            {
                //wColumn.Selected 
                if (IsColumnValidToInsert(wColumn))
                {
                    wBuilder.AppendLine(string.Concat("@", wColumn.Name,","));
                }
            }

            RemoveChars(wBuilder, 3);

            return wBuilder.ToString();
        }
        ///TODO: Ver si se utiliza esto
        static string GenCodeInsertReturnAutogenerated(TableViewBase pTable, CodeGeneratorCommon.MethodActionType action)
        {
            StringBuilder wBuilder = new StringBuilder();
            string wText = string.Empty;

            foreach (Column wColumn in pTable.Columns)
            {
                if (wColumn.Identity)
                {
                    wBuilder.Append("@");
                    wBuilder.Append(wColumn.Name);

                    //wText = Properties.Settings.Default.GetReturnAutogeneratedPattern.Replace("[Name]", wBuilder.ToString());
                    break;
                }
            }

            string wOutputIdentitySet = FwkGeneratorHelper.TemplateDocument.GetTemplate("SP_OutputIdentitySet").Content;
            if (wBuilder.Length == 0)
                return String.Empty;
            else
                return wOutputIdentitySet.Replace("[OutputVariable]", wBuilder.ToString());
        }

        #endregion


        #region -- auxiliares delete --

        /// <summary>
        /// Genera código de parámetros de un procedimiento almacenado de borrado.
        /// </summary>
        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
        /// <returns>Código fuente generado.</returns>
        /// <date>2007-5-25T00:00:00</date>
        /// <author>Marcelo Oviedo</author>
        static string GenCodeDeleteParameters(TableViewBase pTable, CodeGeneratorCommon.MethodActionType action)
        {
            StringBuilder wBuilder = new StringBuilder();

            foreach (Column wColumn in pTable.Columns)
            {
                if (wColumn.InPrimaryKey) //&& wColumn.Selected)
                {
                    StringBuilder wParamBuilder = BuildParameter(wColumn, action, false, false);
                    wBuilder.Append(wParamBuilder.ToString());
                }
            }

            RemoveChars(wBuilder, 3);

            return wBuilder.ToString();
        }

        #endregion


        #region -- auxiliares update --

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pMethodInfo"></param>
        /// <returns>string</returns>
        /// <author>Marcelo Oviedo</author>
        static string GenCodeUpdateParameters(TableViewBase pTable, CodeGeneratorCommon.MethodActionType action)
        {
            StringBuilder wBuilder = new StringBuilder();

            foreach (Column wColumn in pTable.Columns)
            {
                if (IsColumnValidToInsert(wColumn))
                {
                    StringBuilder wParamBuilder = BuildParameter(wColumn, action, false, true);
                    wBuilder.Append(wParamBuilder.ToString());
                }
            }

            RemoveChars(wBuilder, 3);

            return wBuilder.ToString();
        }

        /// <summary>
        /// Genera el listado de campos para el update 
        /// </summary>
        /// <param name="pMethodInfo"></param>
        /// <returns>string</returns>
        /// <author>Marcelo Oviedo</author>
        static string GenCodeUpdateSetStatements(TableViewBase pTable, CodeGeneratorCommon.MethodActionType action)
        {
            StringBuilder wBuilder = new StringBuilder();

            foreach (Column wColumn in pTable.Columns)
            {
                if (!wColumn.Identity)//&& wColumn.Selected)
                {
                    wBuilder.Append(wColumn.Name);
                    wBuilder.Append(" = @");
                    
                    wBuilder.Append(wColumn.Name);
                    wBuilder.Append(",\r\n");
                }
            }

            RemoveChars(wBuilder, 3);

            return wBuilder.ToString();
        }

        #endregion


        

        #region Genera el Store Procedure GetAll By param

        /// <summary>
        /// Genera el script del sp para obtener por parametros (GetAll By param)
        /// </summary>
        /// <param name="pTable"></param>
        /// <returns></returns>
        /// <author>Marcelo Oviedo</author>
        static string GenerateStoreSearchByParam(TableViewBase pTable)
        {

            StringBuilder wSPPatternWitchExecutesql = new StringBuilder();
            StringBuilder sbNombreCampo = new StringBuilder();
            StringBuilder sbParametros = new StringBuilder();
            StringBuilder sbParametrosTipo = new StringBuilder();
            StringBuilder sbParametrosSolo = new StringBuilder();
            StringBuilder sbCampos = new StringBuilder();
            Boolean wAnyParameterToSelec = false;
            string szParametro = String.Empty;


            //----------------------------------------------------------------------
            //-- Cargo el contenido de la Definicion global para Store Search
            //----------------------------------------------------------------------
            wSPPatternWitchExecutesql.Append(_CommonTemplateExecuteSQL);

            try
            {
                wSPPatternWitchExecutesql.Replace(CodeGeneratorCommon.CommonConstants.CONST_AUTHOR, Environment.UserName);
                wSPPatternWitchExecutesql.Replace(CodeGeneratorCommon.CommonConstants.CONST_CREATION_DATETIME, DateTime.Now.ToString());


                #region Nombre del SP
                //Patron de nombres de SP 
                string wSpName = GetStoredProcedureName(pTable.Name, pTable.Schema, CodeGeneratorCommon.MethodActionType.SearchByParam);

                ///Nombre del Store procedure 
                wSpName = wSpName.Replace(CodeGeneratorCommon.CommonConstants.CONST_TABLE_NAME, pTable.Name);
                wSPPatternWitchExecutesql = wSPPatternWitchExecutesql.Replace(CodeGeneratorCommon.CommonConstants.CONST_STOREDPROCEDURE_NAME, wSpName);
                #endregion

                #region -- Recorro la coleccion Campos que se haya SELECCIONADO


                foreach (Column wColumn in pTable.Columns)
                {
                    //-- Por el momento no podemos buscar por campos XML, IMAGE, TIMESTAMP
                    //wColumn.Selected &&
                    if ( IsColumnValidToSearch(wColumn))
                    {
                        wAnyParameterToSelec = true;
                        ///TODO: Ver tema fechas
                        if (wColumn.DataType.SqlDataType.ToString().ToUpper().Contains("DATETIME"))
                        {
                            //Solo  para parametros tipo fechas ya que se atiende de manera especial este tipo de dato.-
                            szParametro = BuildParameter(wColumn, CodeGeneratorCommon.MethodActionType.SearchByParam, true, true).Replace(wColumn.Name, wColumn.Name + "Desde").ToString();
                            szParametro += Environment.NewLine;
                            szParametro += BuildParameter(wColumn, CodeGeneratorCommon.MethodActionType.SearchByParam, true, true).Replace(wColumn.Name, wColumn.Name + "Hasta").ToString();
                            szParametro =szParametro.Replace("@","--" + "@");

                            szParametro +=BuildParameter(wColumn, CodeGeneratorCommon.MethodActionType.SearchByParam, true, true).ToString();
                        }
                        else
                        {
                            szParametro = BuildParameter(wColumn, CodeGeneratorCommon.MethodActionType.SearchByParam, true, true).ToString();
                        }

                        sbParametros.AppendLine(szParametro);

                        sbParametrosTipo.AppendLine(szParametro);


                        sbParametrosSolo.Append(GetPatternSearchParametersSp_ExecuteSql(wColumn));

                        //-- Levanto el Pattern correspondiente a este tipo de campo
                        //-------------------------------------------------------------
                        sbCampos.AppendLine(GetPatternSearch(wColumn));
                    }
                }
                #endregion

                if (wAnyParameterToSelec)
                {
                    //--------------------------------------------------------
                    //-- Replazo los parámetros
                    //--------------------------------------------------------
                    wSPPatternWitchExecutesql = wSPPatternWitchExecutesql.Replace("<PARAMETROS>", sbParametros.ToString().TrimEnd().Remove(sbParametros.ToString().TrimEnd().Length - 1, 1));
                    wSPPatternWitchExecutesql = wSPPatternWitchExecutesql.Replace("<PARAMETROS_TIPO>", sbParametrosTipo.ToString().TrimEnd().Remove(sbParametrosTipo.ToString().TrimEnd().Length - 1, 1));
                    wSPPatternWitchExecutesql = wSPPatternWitchExecutesql.Replace("<PARAMETROS_SOLO>", sbParametrosSolo.ToString().TrimEnd().Remove(sbParametrosSolo.ToString().TrimEnd().Length - 1, 1));

                    //-- Reemplado en Select * From [TableName]
                    wSPPatternWitchExecutesql = wSPPatternWitchExecutesql.Replace(CodeGeneratorCommon.CommonConstants.CONST_TABLE_NAME, pTable.Name);

                    wSPPatternWitchExecutesql = wSPPatternWitchExecutesql.Replace("<CAMPOS>", sbCampos.ToString());

                    //if (false)
                    //    wSPPatternWitchExecutesql.Replace("<WITH_NO_LOCK>", "WITH (NOLOCK)");
                    //else
                    wSPPatternWitchExecutesql.Replace("<WITH_NO_LOCK>", String.Empty);

                }
                else
                {
                    wSPPatternWitchExecutesql.Remove(0, wSPPatternWitchExecutesql.Length);
                    wSPPatternWitchExecutesql.Append("El SP :");
                    wSPPatternWitchExecutesql.Append(wSpName);
                    wSPPatternWitchExecutesql.AppendLine(" no se pudo crear debido a que no tiene campos seleccionados");
                    wSPPatternWitchExecutesql.AppendLine("de la tabla ");
                    wSPPatternWitchExecutesql.Append(pTable.Name);
                    wSPPatternWitchExecutesql.AppendLine(" que son validos para efectuar una busqueda");
                }

                return wSPPatternWitchExecutesql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion



        #region GetPatternSearchParametersSp_ExecuteSql
        /// <summary>
        /// Genera uns string con el Pattern para el campo de los parámetros utilizados como 3er parámetro pasado a sp_executesql.
        /// </summary>
         static string GetPatternSearchParametersSp_ExecuteSql(Column pColumn)
        {

            StringBuilder sbTipo = new StringBuilder(String.Empty);
            switch (pColumn.DataType.SqlDataType.ToString().ToUpper())
            {
                case "SMALLDATETIME":
                case "DATETIME":
                    sbTipo.AppendLine();
                    sbTipo.Append("--@" + pColumn.Name + "Desde, ");
                    sbTipo.AppendLine();
                    sbTipo.Append("--@" + pColumn.Name + "Hasta, ");
                    sbTipo.AppendLine();
                    sbTipo.Append("@" + pColumn.Name + ", ");
                    break;
                default:
                    sbTipo.Append("@" + pColumn.Name + ", ");
                    break;
            }
            return sbTipo.ToString();

        }
        #endregion

        #region GetPatternSearch
       
         /// <summary>
         /// Retorna el Pattern para el Store Search del Tipo de dato pasado como parámetro.
         /// </summary>
         /// <example ><code>
         /// Ej:
         /// -- <NOMBRE_CAMPO> = TYPE [TYPENAME]
         /// IF (<NOMBRE_PARAMETRO_CAMPO> IS NOT NULL)
         /// BEGIN
         ///       SET @sql = @sql + ' AND <NOMBRE_CAMPO>  LIKE  <NOMBRE_PARAMETRO_CAMPO> '
         /// END
         /// <param name="SQLServerType">Tipo de dato SQL Server.</param>
         /// <param name="NombreCampo">Nombre del campo.</param>
         /// <returns></returns>
         static string GetTemplateSearch(Column c)
         {
             string wTemplate = string.Empty;
             //Template wStoredProcedureTemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.StoredProcedureTemplate);
             switch (c.DataType.SqlDataType.ToString().ToUpper())
             {
                 case "VARCHAR":
                 case "NVARCHAR":
                 case "NVARCHARMAX":
                 case "CHAR":
                 case "NCHAR":
                     {
                         wTemplate = FwkGeneratorHelper.TemplateDocument.GetTemplate("SP_Search_TypeVarChar").Content;
                         break;
                     }
                 case "REAL":
                 case "DECIMAL":
                 case "NUMERIC":
                 case "MONEY":
                 case "SMALLMONEY":
                 case "FLOAT":
                 case "INT":
                 case "BIGINT":
                 case "SMALLINT":
                 case "TINYINT":
                     {
                         wTemplate = FwkGeneratorHelper.TemplateDocument.GetTemplate("SP_Search_TypeNumeric").Content;
                         break;
                     }
                 case "BIT":
                     {
                         wTemplate = FwkGeneratorHelper.TemplateDocument.GetTemplate("SP_Search_TypeBit").Content;

                         break;
                     }
                 case "DATETIME":
                 case "SMALLDATETIME":
                     {
                         wTemplate = FwkGeneratorHelper.TemplateDocument.GetTemplate("SP_Search_TypeDateTime").Content;

                         break;
                     }


                 case "UNIQUEIDENTIFIER":
                     {
                         wTemplate = String.Empty;
                         break;
                     }
                 case "TEXT":
                 case "NTEXT":
                     {
                         wTemplate = FwkGeneratorHelper.TemplateDocument.GetTemplate("SP_Search_TypeNText").Content;

                         break;
                     }
                 //    ****************** NO SE BUSCA POR ESTOS CAMPOS ************************
                 //case "IMAGE":
                 //case "VARBINARY":  
                 //case "BINARY":
                 //   
             }
             return wTemplate.Replace(CodeGeneratorCommon.CommonConstants.CONST_TYPENAME, c.DataType.SqlDataType.ToString()); ;
         }
         /// <summary>
         /// Levanta el pattern para el tipo de dato del campo desde una archivo físico.
         /// Pisa tags [NOMBRE_CAMPO],[NOMBRE_PARAMETRO_CAMPO],[NOMBRE_PARAMETRO_OPERADOR_CAMPO],
         /// [NOMBRE_PARAMETRO_CAMPO_DESDE],[NOMBRE_PARAMETRO_CAMPO_HASTA],[PARAMETRO_SPEXECUTESQL]
         /// y retorna el string actualizado.
         /// </summary>
         /// <returns>String actualizado.</returns>
         public static string GetPatternSearch(Column pColumn)
         {



             string sbPatternSearch = GetTemplateSearch(pColumn);

             sbPatternSearch = sbPatternSearch.Replace("<NOMBRE_CAMPO>", pColumn.Name.Trim());
             sbPatternSearch = sbPatternSearch.Replace("<NOMBRE_PARAMETRO_CAMPO>", "@" + pColumn.Name.Trim());
             sbPatternSearch = sbPatternSearch.Replace("<NOMBRE_PARAMETRO_OPERADOR_CAMPO>", "@Ope" + pColumn.Name.Trim());
             sbPatternSearch = sbPatternSearch.Replace("<NOMBRE_PARAMETRO_CAMPO_DESDE>", "@" + pColumn.Name.Trim() + "Desde");
             sbPatternSearch = sbPatternSearch.Replace("<NOMBRE_PARAMETRO_CAMPO_HASTA>", "@" + pColumn.Name.Trim() + "Hasta");

             string parametros_spExecuteSql = "@" + pColumn.Name.Trim() + " " + pColumn.DataType.MaximumLength.ToString() + ",";

             sbPatternSearch.Replace("<PARAMETRO_SPEXECUTESQL>", parametros_spExecuteSql);

             return sbPatternSearch;
         }
        #endregion

    }


}
