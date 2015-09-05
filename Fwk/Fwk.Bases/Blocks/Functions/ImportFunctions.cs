using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;

using System.Data.OleDb;

using Fwk.Bases;
using System.Xml.Serialization;


namespace Fwk.HelperFunctions
{
    /// <summary>
    /// 
    /// </summary>
    //public class ImportFunctions
    //{
    //    public static WorkSheets SearchWorkSheets(String pPath)
    //    {
    //        try
    //        {
    //            DataTable dt = null;
    //            OleDbConnection wObjConnection = null;
    //            WorkSheets wWorkSheetsListBE = new WorkSheets();
    //            WorkSheet wWorkSheetBE = null;

    //            string wConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source= {0}; Extended Properties=Excel 8.0;", pPath);

    //            wObjConnection = new OleDbConnection(wConnectionString);
    //            wObjConnection.Open();

    //            dt = wObjConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

    //            if (dt == null)
    //                return null;

    //            foreach (DataRow wRow in dt.Rows)
    //            {
    //                wWorkSheetBE = new WorkSheet();
    //                wWorkSheetBE.SheetOriginalName = wRow["TABLE_NAME"].ToString();
    //                //Validamos si el nombre original fue cambiado y se le agregaron comillas y el signo '$'
    //                if (wWorkSheetBE.SheetOriginalName.Contains("'"))
    //                {
    //                    //Eliminamos el signo pesos del anteúltimo lugar y la comilla simple del último lugar
    //                    wWorkSheetBE.SheetDisplayName = wWorkSheetBE.SheetOriginalName.Remove(wWorkSheetBE.SheetOriginalName.Length - 2);
    //                    //Eliminamos la comilla simple del primer lugar.
    //                    wWorkSheetBE.SheetDisplayName = wWorkSheetBE.SheetDisplayName.Remove(0, 1);
    //                }
    //                else
    //                    //Eliminamos el signo pesos del último lugar
    //                    wWorkSheetBE.SheetDisplayName = wWorkSheetBE.SheetOriginalName.Remove(wWorkSheetBE.SheetOriginalName.Length - 1);

    //                wWorkSheetsListBE.Add(wWorkSheetBE);
    //            }

    //            return wWorkSheetsListBE;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(ex.Message);
    //        }
    //    }


    //    public static DataTable ImportFromExcel(string pPath, string pSheetName)
    //    {
    //        try
    //        {
    //            OleDbDataAdapter wDataAdapter;
    //            string wConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source= {0}; Extended Properties=Excel 8.0;", pPath);

    //            wDataAdapter = new OleDbDataAdapter(string.Format("SELECT * FROM [{0}]", pSheetName), wConnectionString);

    //            DataSet wDataSet = new DataSet();
    //            wDataAdapter.Fill(wDataSet, "ExcelInfo");

    //            return wDataSet.Tables["ExcelInfo"];
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(ex.Message);
    //        }

    //    }
    //}

    //[XmlRoot("WorkSheets"), SerializableAttribute]
    //public class WorkSheets : Entities<WorkSheet>
    //{

    //}

    //[XmlInclude(typeof(WorkSheet)), Serializable]
    //public class WorkSheet : Entity
    //{
    //    #region Members
    //    String _SheetDisplayName;
    //    String _SheetOriginalName;
    //    #endregion

    //    #region Properties
    //    public String SheetDisplayName
    //    {
    //        get { return _SheetDisplayName; }
    //        set { _SheetDisplayName = value; }
    //    }

    //    public String SheetOriginalName
    //    {
    //        get { return _SheetOriginalName; }
    //        set { _SheetOriginalName = value; }
    //    }
    //    #endregion

    //}
}

#region Exportar a objeto con LINQ
//var query = from r in dataTable.AsEnumerable()
//            select new
//            {
//                RelationNr = r.Field<double>("RelationNumber"),
//                ClientName = r.Field<string>("ClientName"),
//            };
//foreach (var item in query)
//{
//    Console.WriteLine(item.ClientName);
//}
#endregion