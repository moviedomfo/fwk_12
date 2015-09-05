using System;
using System.Data;
using System.Xml;
using System.IO;

namespace Fwk.HelperFunctions
{
    /// <summary>
    /// Funciones de datos.
    /// </summary>
    /// <Date>12-05-2009</Date>
    /// <Author>moviedo</Author>
    public class DataFunctions
    {

        /// <summary>
        /// Obtiene un System.DataSet desde un xml
        /// </summary>
        /// <param name="strXml">Cadena con formato xml</param>
        /// <returns></returns>
        public DataSet GetDataSetFromXml(string strXml)
        {
            DataSet wDts = new DataSet();


            wDts.ReadXml(new StringReader(strXml));

            return wDts;
        }

        #region --[ValueGet]--
        /// <summary>
        /// Obtiene el valor de un campo del primer registro de un
        /// dataset en formato string. 
        /// </summary>
        /// <param name="pDataSet">El DataSet.</param>
        /// <param name="pTableName">El nombre de la tabla.</param>
        /// <param name="pColumnName">El nombre de la columna.</param>
        /// <returns>String.</returns>
        /// <Date>12-05-2009</Date>
        /// <Author>moviedo</Author>
        public static string ValueGet(DataSet pDataSet, string pTableName, string pColumnName)
        {
            try
            {
                return ValueGet(pDataSet, pTableName, 0, pColumnName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene el valor de un campo del primer registro de un
        /// dataset en formato string. 
        /// </summary>
        /// <param name="pDataSet">El DataSet.</param>
        /// <param name="pTableName">El nombre de la tabla.</param>
        /// <param name="pColumnIndex">El nombre de la columna.</param>
        /// <returns>String.</returns>
        /// <Date>12-05-2009</Date>
        /// <Author>moviedo</Author>
        public static string ValueGet(DataSet pDataSet, string pTableName, int pColumnIndex)
        {
            try
            {
                return ValueGet(pDataSet, pTableName, 0, pColumnIndex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene el valor de un campo de un registro de un
        /// dataset en formato string.
        /// </summary>
        /// <param name="pDataSet">El DataSet.</param>
        /// <param name="pTableName">El nombre de la tabla.</param>
        /// <param name="pRowIndex">El indice del registro.</param>
        /// <param name="pColumnName">El nombre de la columna.</param>
        /// <returns>String.</returns>
        /// <Date>12-05-2009</Date>
        /// <Author>moviedo</Author>
        public static string ValueGet(DataSet pDataSet, string pTableName, int pRowIndex, string pColumnName)
        {
            try
            {
                return pDataSet.Tables[pTableName].Rows[pRowIndex][pColumnName].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene el valor de un campo de un registro de un
        /// dataset en formato string.
        /// </summary>
        /// <param name="pDataSet">El DataSet.</param>
        /// <param name="pTableName">El nombre de la tabla.</param>
        /// <param name="pRowIndex">El indice del registro.</param>
        /// <param name="pColumnIndex">El indice de la columna.</param>
        /// <returns>String.</returns>
        /// <Date>12-05-2009</Date>
        /// <Author>moviedo</Author>
        public static string ValueGet(DataSet pDataSet, string pTableName, int pRowIndex, int pColumnIndex)
        {
            try
            {
                return pDataSet.Tables[pTableName].Rows[pRowIndex][pColumnIndex].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene el valor de un campo del primer registro de un
        /// datatable en formato string.
        /// </summary>
        /// <param name="pDataTable">El nombre del DataTable.</param>
        /// <param name="pColumnName">El nombre de la columna.</param>
        /// <returns>String.</returns>
        /// <Date>12-05-2009</Date>
        /// <Author>moviedo</Author>
        public static string ValueGet(DataTable pDataTable, string pColumnName)
        {
            try
            {
                return ValueGet(pDataTable, 0, pColumnName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene el valor de un campo del primer registro de un
        /// datatable en formato string.
        /// </summary>
        /// <param name="pDataTable">El nombre del DataTable.</param>
        /// <param name="pColumnIndex">El indice de la columna.</param>
        /// <returns>String.</returns>
        /// <Date>12-05-2009</Date>
        /// <Author>moviedo</Author>
        public static string ValueGet(DataTable pDataTable, int pColumnIndex)
        {
            try
            {
                return ValueGet(pDataTable, 0, pColumnIndex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene el valor de un campo de un registro de un
        /// datatable en formato string.
        /// </summary>
        /// <param name="pDataTable">El DataTable.</param>
        /// <param name="pRowIndex">El indice del registro.</param>
        /// <param name="pColumnName">El nombre de la columna.</param>
        /// <returns>String.</returns>
        /// <Date>12-05-2009</Date>
        /// <Author>moviedo</Author>
        public static string ValueGet(DataTable pDataTable, int pRowIndex, string pColumnName)
        {
            try
            {
                return pDataTable.Rows[pRowIndex][pColumnName].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene el valor de un campo de un registro de un
        /// datatable en formato string.
        /// </summary>
        /// <param name="pDataTable">El DataTable.</param>
        /// <param name="pRowIndex">El indice del registro.</param>
        /// <param name="pColumnIndex">El indice de la columna.</param>
        /// <returns>String.</returns>
        /// <Date>12-05-2009</Date>
        /// <Author>moviedo</Author>
        public static string ValueGet(DataTable pDataTable, int pRowIndex, int pColumnIndex)
        {
            try
            {
                return pDataTable.Rows[pRowIndex][pColumnIndex].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region --[IsEmpty]--
        /// <summary>
        /// Indica si un DataSet tiene datos.
        /// </summary>
        /// <param name="pDataSet">DataSet a verificar.</param>
        /// <returns>True: El DataSet tiene datos. False: El DataSet NO tiene datos.</returns>
        /// <Date>12-05-2009</Date>
        /// <Author>moviedo</Author>
        public static bool IsEmpty(DataSet pDataSet)
        {
            if (pDataSet.Tables.Count == 0)
                return true;

            foreach (DataTable wDataTable in pDataSet.Tables)
            {
                if (IsEmpty(wDataTable) == false)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Indica si un DataTable tiene datos.
        /// </summary>
        /// <param name="pDataTable">DataTable a verificar.</param>
        /// <returns>True: El DataSet tiene datos. False: El DataSet NO tiene datos.</returns>
        /// <Date>12-05-2009</Date>
        /// <Author>moviedo</Author>
        public static bool IsEmpty(DataTable pDataTable)
        {
            if (pDataTable.Rows.Count > 0)
                return false;
            return true;
        }
        #endregion

        #region --[SelectDistinct]--

        /// <summary>
        /// Compara dos arrays de valores, devolviendo true si sus posiciones son equivalentes.
        /// </summary>
        /// <param name="pLast">Primer array.</param>
        /// <param name="pCurrent">Segundo array.</param>
        /// <returns>bool.</returns>
        /// <Date>29-03-2006</Date>
        /// <Author>moviedo</Author>
        static private bool CompareArrays(object[] pLast, object[] pCurrent)
        {
            bool wResult = true;

            for (int i = 0; i < pCurrent.Length; i++)
            {
                if (!ColumnEqual(pLast[i], pCurrent[i]))
                {
                    wResult = false;
                    break;
                }
            }

            return wResult;
        }

        /// <summary>
        /// Compara dos valores para verificar si ambos son iguales.
        /// Tambien compara DBNULL.Value.
        /// </summary>
        /// <param name="A">Objeto "A".</param>
        /// <param name="B">Objeto "B".</param>
        /// <returns></returns>
        /// <Date>23-06-2009</Date>
        /// <Author>moviedo</Author>
        static private bool ColumnEqual(object A, object B)
        {
            if (A == DBNull.Value && B == DBNull.Value) //  both are DBNull.Value
                return true;
            if (A == DBNull.Value || B == DBNull.Value) //  only one is DBNull.Value
                return false;
            return (A.Equals(B));  // value type standard comparison
        }
        ///// <summary>
        ///// Devuelve un DataTable con valores unicos de una columna de otro DataTable.
        ///// </summary>
        ///// <param name="pTableName">Nombre de la tabla a devolver.</param>
        ///// <param name="pSourceTable">Tabla de origen.</param>
        ///// <param name="pFieldName">Nombre del campo por el cual distinguir.</param>
        ///// <returns>DataTable con valores unicos.</returns>
        ///// <Date>29-03-2006</Date>
        ///// <Author>moviedo</Author>
        //static public DataTable SelectDistinct(string pTableName, DataTable pSourceTable, string pFieldName)
        //{
        //    return SelectDistinct(pTableName, pSourceTable, new string[] { pFieldName });
        //}

        /// <summary>
        /// Devuelve un DataTable con valores unicos de una columna de otro DataTable.
        /// </summary>
        /// <param name="TableName">Nombre de la tabla de devolver.</param>
        /// <param name="SourceTable">Tabla de origen.</param>
        /// <param name="FieldName">Nombre del campo por el cual distinguir.</param>
        /// <returns>DataTable con valores unicos.</returns>
        /// <Date>29-03-2009</Date>
        /// <Author>moviedo</Author> 
        public static DataTable SelectDistinct(string TableName, DataTable SourceTable, string FieldName)
        {
            DataTable dt = new DataTable(TableName);

            foreach (DataColumn wCol in SourceTable.Columns)
            {
                dt.Columns.Add(wCol.Caption, wCol.DataType);
            }

            object LastValue = null;
            foreach (DataRow dr in SourceTable.Select("", FieldName))
            {
                if (LastValue == null || !(ColumnEqual(LastValue, dr[FieldName])))
                {
                    LastValue = dr[FieldName];
                    dt.Rows.Add(dr.ItemArray);
                }
            }
            return dt;
        }

        /// <summary>
        /// Devuelve un DataTable con valores unicos de una columnas de otro DataTable.
        /// </summary>
        /// <param name="pTableName">Nombre de la tabla a devolver.</param>
        /// <param name="pSourceTable">Tabla de origen.</param>
        /// <returns>DataTable con valores unicos.</returns>
        /// <Date>29-03-2009</Date>
        /// <Author>moviedo</Author>
        public static DataTable SelectDistinct(string pTableName, DataTable pSourceTable)
        {
            string[] wFields = new string[pSourceTable.Columns.Count];

            try
            {
                for (int i = 0; i < pSourceTable.Columns.Count; i++)
                {
                    wFields[i] = pSourceTable.Columns[i].ColumnName;
                }

                return SelectDistinct(pTableName, pSourceTable, wFields);

            }
            finally
            {
                wFields = null;
            }

        }

        /// <summary>
        /// Devuelve un DataTable con valores unicos de columnas de otro DataTable.
        /// </summary>
        /// <param name="pTableName">Nombre de la tabla a devolver.</param>
        /// <param name="pSourceTable">Tabla de origen.</param>
        /// <param name="pFields">Nombres de campos para distinguir.</param>
        /// <returns>DataTable con valores unicos.</returns>
        /// <Date>29-03-2006</Date>
        /// <Author>moviedo</Author>
        public static DataTable SelectDistinct(string pTableName, DataTable pSourceTable, string[] pFields)
        {
            DataTable wDt = new DataTable(pTableName);
            object[] wLastValues = new object[pFields.Length];
            object[] wCurrentValues = null;
            DataView wDv = new DataView(pSourceTable);

            try
            {
                foreach (DataColumn wCol in pSourceTable.Columns)
                {
                    wDt.Columns.Add(wCol.ColumnName, wCol.DataType);
                }

                wDv.Sort = string.Join(", ", pFields);

                foreach (DataRowView wDrv in wDv)
                {
                    wCurrentValues = wDrv.Row.ItemArray;

                    if (!CompareArrays(wLastValues, wCurrentValues))
                    {
                        wDt.LoadDataRow(wCurrentValues, true);
                        wLastValues = wCurrentValues;
                    }
                }

                return wDt;

            }
            finally
            {
                wCurrentValues = null;
                wLastValues = null;

                wDv.Dispose();
                wDv = null;
            }
        }

        /// <summary>
        /// Retorna una tabla con la union del conjunto de tablas que se pasa como parametro.
        /// La nueva tabla union contendra las columnas producto de la interseccion de columnas de 
        /// las tablas que se pasan como parametro.
        /// </summary>
        /// <param name="pTableName">Nombre de la tabla producto de la union.-</param>
        /// <param name="pTables">Conjunto de tablas a unir.-</param>
        /// <param name="pApplyDistinct">Determina si se eliminan filas duplicadas o no.-</param>
        /// <returns>Tabla producto de la union.-</returns>
        /// <Date>29-03-2006</Date>
        /// <Author>moviedo</Author>
        public static DataTable Union(string pTableName, DataTable[] pTables, bool pApplyDistinct)
        {
            DataTable wUnionDataTable = new DataTable();
            DataSet wDtsUnion = new DataSet();

            //Se realiza la interseccion de de columnas de todas las tablas.-
            foreach (DataColumn wDc in pTables[0].Columns)
            {
                foreach (DataTable wDt in pTables)
                {
                    if (!wDt.Equals(pTables[0]) && wDt.Columns.Contains(wDc.ColumnName) && !wUnionDataTable.Columns.Contains(wDc.ColumnName))
                    {
                        wUnionDataTable.Columns.Add(new DataColumn(wDc.ColumnName, wDc.DataType));
                    }
                }
            }

            //Agregamos la tabla resultante de la interseccion anterior con solo las columnas que interesan al dataset
            wDtsUnion.Tables.Add(wUnionDataTable);

            //Se realiza la union de las filas de todas las tablas del dataset.-
            foreach (DataTable wDt in pTables)
            {
                if (wUnionDataTable.TableName != wDt.TableName)
                {
                    DataTable wTmp = wDt.Copy();
                    wTmp.TableName = wUnionDataTable.TableName;

                    wDtsUnion.Merge(wTmp, true, MissingSchemaAction.Ignore);
                }
            }

            wDtsUnion.Tables[0].TableName = pTableName;

            //Se eliminan las filas duplicadas [Opcional]
            if (pApplyDistinct)
            {
                return SelectDistinct(wDtsUnion.Tables[0].TableName, wDtsUnion.Tables[0]);

            }

            return wDtsUnion.Tables[0];

        }

        #endregion

        #region --[GetValueFromRow]--
        /// <summary>
        ///	Obtiene el valor de un registro
        /// </summary>
        /// <param name="pRow">Fila de la cual obtener el registro</param>
        /// <param name="pField">Nombre del cuál obtener el valor</param>
        /// <returns></returns>
        public static string GetValueFromRow(DataRow pRow, String pField)
        {
            if (pRow[pField] == DBNull.Value)
                if (pRow.Table.Columns[pField].DataType.FullName == "System.Int32")
                    return "0";
                else
                    return String.Empty;
            else
                return pRow[pField].ToString();
        }
        #endregion

        #region --[GetTopRows]--

        /// <summary>
        /// Obtiene las primeras n filas de un DataTable
        /// </summary>
        /// <param name="pDataTable">DataTable del cual vamos a obtener las primeras n filas</param>
        /// <param name="pRowsQuantity">Cantidad de filas a obtener</param>
        /// <returns></returns>
        public static DataTable GetTopRows(DataTable pDataTable, Int32 pRowsQuantity)
        {
            DataTable wDt = pDataTable.Clone();

            //Validamos si la cantidad a obtener es mayor que la cantidad de filas del DataTable
            if (pRowsQuantity > pDataTable.Rows.Count)
                pRowsQuantity = pDataTable.Rows.Count;

            for (int i = 0; i < pRowsQuantity; i++)
            {
                wDt.ImportRow(pDataTable.Rows[i]);
            }

            return wDt;
        }
        #endregion

        #region --[XmlNamespaceRemove]--
        /// <summary>
        /// Quita el namespace del Xml del esquema de un dataset.
        /// </summary>
        /// <param name="pDataSet">DataSet.</param>
        /// <param name="pServiceName">Nombre de un servicio.</param>
        /// <returns>Xml sin el namespace.</returns>
        /// <Date>12-07-2009</Date>
        /// <Author>moviedo</Author>
        public static string XmlNamespaceRemove(DataSet pDataSet, string pServiceName)
        {
            return XmlNamespaceRemove(pDataSet.GetXml(), pServiceName);
        }
        /// <summary>
        /// Quita el namespace del Xml de un esquema.
        /// </summary>
        /// <param name="pXML">Xml del esquema.</param>
        /// <param name="pServiceName">Nombre de un servicio.</param>
        /// <returns>Xml sin el namespace.</returns>
        /// <Date>12-07-2009</Date>
        /// <Author>moviedo</Author>
        public static string XmlNamespaceRemove(string pXML, string pServiceName)
        {
            XmlDocument oDom = new XmlDocument();
            oDom.LoadXml(pXML);

            string nmspc = "xmlns=" + '"' + "http://tempuri.org/" + pServiceName + "RES.xsd" + '"';

            string Xml = oDom.OuterXml;
            Xml = Xml.Replace(nmspc, "");

            return Xml;
        }
        #endregion
    }
}
