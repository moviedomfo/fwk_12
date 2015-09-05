
using System;
using System.Collections;
using System.ComponentModel;

using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;
using System.IO;



namespace Fwk.Guidance.Core
{
    /// <summary>
    /// Extraccion de Fwk.CodeGenerator.Coer.FwkGenerator para usar desde t4
    /// </summary>
    public class FwkGenerator
    {
          
        internal static string NotSupportTypes_ToIncludeInBackEnd;
        internal static string NotSupportTypes_ToSearchInStoreProcedure;
        internal static string NotSupportTypes_ToInsertStoreProcedure;
        static MappingTypes _MappingTypes;
        internal static MappingTypes MappingTypes
        {
            get { return _MappingTypes; }
        }

        static FwkGenerator()
        {
            
            LoadMappingTypes();
            NotSupportTypes_ToIncludeInBackEnd = "xml,timestamp,sql_variant";
            NotSupportTypes_ToSearchInStoreProcedure = "xml,timestamp,sql_variant,varbinary,binary,image";
            NotSupportTypes_ToInsertStoreProcedure = "xml,timestamp,sql_variant";

        
        }
        internal static string Xml = "value 1";
        public static string Get()
        {
            return Xml;
        }

        internal static CodeGenerator.TemplateSettingObject TemplateSettingFactoty()
        {
            if (Fwk.CodeGenerator.FwkGeneratorHelper.TemplateSetting == null)
                Fwk.CodeGenerator.FwkGeneratorHelper.TemplateSetting = new CodeGenerator.TemplateSettingObject();

            return Fwk.CodeGenerator.FwkGeneratorHelper.TemplateSetting;

        }

        public static string GetCSharpType(string dataTypeName)
        {

            //if (pColumn.DataType.SqlDataType.ToString().Equals("UserDefinedDataType"))
            //{
            //    //dataTypeName = UserDefinedTypes.GetUserDefinedType(pColumn.DataType.Name).SystemType.ToUpper();
            //}
            if (_MappingTypes.ExistMappingType_sqlname(dataTypeName))
                return _MappingTypes.GetMappingType_sqlname(dataTypeName).Cshrarptype;


            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTypeName">pColumn.DataType.Name</param>
        /// <returns></returns>
        public static string GetNullable(string dataTypeName)
        {




            //if (!pColumn.Nullable)
            //    return string.Empty;
            //string wTypeName = pColumn.DataType.Name.ToUpper();
            //if (pColumn.DataType.SqlDataType.ToString().Equals("UserDefinedDataType"))
            //{
            //    wTypeName = UserDefinedTypes.GetUserDefinedType(pColumn.DataType.Name).SystemType.ToUpper();
            //}


            switch (dataTypeName)
            {
                case "UNIQUEIDENTIFIER":

                case "BIT":
                case "REAL":
                case "NUMERIC":
                case "BIGINT":
                case "SMALLINT":
                case "INT":
                case "TINYINT":
                case "MONEY":
                case "SMALLMONEY":
                case "DECIMAL":
                case "FLOAT":
                case "SMALLDATETIME":
                case "DATETIME":
                    return "?";

                case "TEXT":
                case "NTEXT":
                case "CHAR":
                case "NCHAR":
                case "VARCHAR":
                case "NVARCHAR":
                    return String.Empty;

                case "IMAGE":
                case "VARBINARY":
                case "BINARY":
                case "TINYUNT":
                    return String.Empty;


            }
            return String.Empty;

        }


        private static void LoadMappingTypes()
        {
            _MappingTypes = new MappingTypes();
            
            _MappingTypes.Add(new MappingType("varchar", "System.String", "System.Data.DbType.String", "string", "[Name] [Type]([Length]) [Direction]"));   
            _MappingTypes.Add(new MappingType("nvarchar", "System.String", "System.Data.DbType.String", "string", "[Name] [Type]([Length]) [Direction]"));
            _MappingTypes.Add(new MappingType("text", "System.String", "System.Data.DbType.String", "string", "[Name] varchar(8000) [Direction]"));
            _MappingTypes.Add(new MappingType("ntext", "System.String", "System.Data.DbType.String", "string", "[Name] varchar(8000) [Direction]"));
              _MappingTypes.Add(new MappingType("uniqueidentifier", "Guid", "System.Data.DbType.String", "string", "[Name] uniqueidentifier"));
            
            _MappingTypes.Add(new MappingType("nchar", "System.String", "System.Data.DbType.String", "string", "[Name] nchar([Length]) [Direction]"));
            
            _MappingTypes.Add(new MappingType("char", "System.String", "System.Data.DbType.String", "string", "[Name] char([Length]) [Direction]"));
            
            _MappingTypes.Add(new MappingType("sysname", "System.String", "System.Data.DbType.String", "string", "[Name] char([Length]) [Direction]"));
            
            _MappingTypes.Add(new MappingType("bit", "System.Boolean", "System.Data.DbType.Boolean", "boolean", "[Name] [Type] [Direction]"));
            
            _MappingTypes.Add(new MappingType("datetime", "System.DateTime", "System.Data.DbType.DateTime", "dateTime", "[Name] [Type] [Direction]"));
            
            _MappingTypes.Add(new MappingType("smalldatetime", "System.DateTime", "System.Data.DbType.DateTime", "dateTime", "[Name] [Type] [Direction]"));
            
            _MappingTypes.Add(new MappingType("real", "System.Int32", "System.Data.DbType.Int32", "double", "[Name] [Type] [Direction]"));
            
            _MappingTypes.Add(new MappingType("numeric", "System.Int32", "System.Data.DbType.Int32", "decimal", "[Name] [Type]([Precision],[Scale]) [Direction]"));
            
            _MappingTypes.Add(new MappingType("bigint", "System.Int32", "System.Data.DbType.Int32", "int", "[Name] [Type] [Direction]"));
            
            _MappingTypes.Add(new MappingType("smallint", "System.Int32", "System.Data.DbType.Int32", "int", "[Name] [Type] [Direction]"));
            
            _MappingTypes.Add(new MappingType("int", "System.Int32", "System.Data.DbType.Int32", "int", "[Name] [Type] [Direction]"));
            
            _MappingTypes.Add(new MappingType("tinyint", "System.Int32", "System.Data.DbType.Int32", "int", "[Name] [Type] [Direction]"));
            
            _MappingTypes.Add(new MappingType("decimal", "System.Decimal", "System.Data.DbType.Decimal", "decimal", "[Name] [Type] [Direction]"));
            
            _MappingTypes.Add(new MappingType("float", "System.Double", "System.Data.DbType.Double", "float", "[Name] [Type] [Direction]"));
            
            _MappingTypes.Add(new MappingType("double", "System.Double", "System.Data.DbType.Double", "dounble", "[Name] [Type] [Direction]"));
            
            _MappingTypes.Add(new MappingType("money", "System.Double", "System.Data.DbType.Double", "double", "[Name] [Type] [Direction]"));
            
            _MappingTypes.Add(new MappingType("smallmoney", "System.Double", "System.Data.DbType.Double", "double", "[Name] [Type] [Direction]"));
            
            _MappingTypes.Add(new MappingType("image", "System.Byte[]", "System.Data.DbType.Binary", "base64Binary", "[Name] [Type]([Length])"));
            
            _MappingTypes.Add(new MappingType("binary", "System.Byte[]", "System.Data.DbType.Binary", "base64Binary", "[Name] [Type]([Length])"));
            
            _MappingTypes.Add(new MappingType("varbinary", "System.Byte[]", "System.Data.DbType.Binary", "base64Binary", "[Name] [Type]([Length])"));
        }

    }
}
