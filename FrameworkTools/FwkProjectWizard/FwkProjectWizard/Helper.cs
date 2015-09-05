using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Data.SqlClient;
using System.Data;
using System.Xml;

namespace Fwk.Wizard
{
  

    internal static class HelperFunctions 
    {
        #region -- Xml Serialization using Xml --

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObjType"></param>
        /// <param name="pXmlData"></param>
        /// <returns></returns>
        public static object Deserialize(Type pObjType, string pXmlData)
        {
            XmlSerializer wSerializer;
            UTF8Encoding wEncoder = new UTF8Encoding();
            MemoryStream wStream = new MemoryStream(wEncoder.GetBytes(pXmlData));

            wSerializer = new XmlSerializer(pObjType);
            return wSerializer.Deserialize(wStream);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObjType"></param>
        /// <param name="pXmlData"></param>
        /// <param name="pXPath"></param>
        /// <returns></returns>
        public static object Deserialize(Type pObjType, string pXmlData, string pXPath)
        {
            XmlDocument wDom = new XmlDocument();
            wDom.LoadXml(pXmlData);
            return Deserialize(pObjType, wDom.DocumentElement.SelectSingleNode(pXPath).OuterXml);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTipo"></param>
        /// <param name="pXml"></param>
        /// <returns></returns>
        public static object DeserializeFromXml(Type pTipo, string pXml)
        {
            XmlSerializer wSerializer;
            StringReader wStrSerializado = new StringReader(pXml);
            XmlTextReader wXmlReader = new XmlTextReader(wStrSerializado);
            //XmlSerializerNamespaces wNameSpaces = new XmlSerializerNamespaces();
            object wResObj = null;

            //wNameSpaces.Add(String.Empty, String.Empty);
            wSerializer = new XmlSerializer(pTipo);
            wResObj = wSerializer.Deserialize(wXmlReader);

            return wResObj;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public static string SerializeToXml(object pObj)
        {
            XmlSerializer wSerializer;
            StringWriter wStwSerializado = new StringWriter();
            XmlTextWriter wXmlWriter = new XmlTextWriter(wStwSerializado);
            XmlSerializerNamespaces wNameSpaces = new XmlSerializerNamespaces();

            wXmlWriter.Formatting = Formatting.Indented;
            wNameSpaces.Add(String.Empty, String.Empty);

            wSerializer = new XmlSerializer(pObj.GetType());
            wSerializer.Serialize(wXmlWriter, pObj, wNameSpaces);


            return wStwSerializado.ToString().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", String.Empty);
        }

        /// <summary>
        /// Serializa un objeto.
        /// </summary>
        /// <param name="pObj">Objeto a serializar</param>
        /// <returns>Representación en XML del objeto</returns>
        public static string Serialize(object pObj)
        {
            return Serialize(pObj, false);
        }

        /// <summary>
        /// Serializa un objeto.
        /// </summary>
        /// <param name="pObj">Objeto a serializar</param>
        /// <param name="pRemoveDeclaration">Indica si se debe remover el nodo de declaración</param>
        /// <returns>Representación en XML del objeto</returns>
        public static string Serialize(object pObj, bool pRemoveDeclaration)
        {
            XmlDocument wDoc = new XmlDocument();
            wDoc.Load(GetStream(pObj));

            if (pRemoveDeclaration && wDoc.ChildNodes.Count > 0 && wDoc.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
            {
                wDoc.RemoveChild(wDoc.FirstChild);
            }

            return wDoc.InnerXml;
        }


        /// <summary>
        /// Devuelve un stream formado a partir del objeto enviado por parámetro.
        /// </summary>
        /// <param name="pObj">Objeto para extraer stream</param>
        /// <returns>MemoryStream</returns>
        public static MemoryStream GetStream(object pObj)
        {
            XmlSerializer wSerializer;
            MemoryStream wStream = new MemoryStream();

            wSerializer = new XmlSerializer(pObj.GetType());
            wSerializer.Serialize(wStream, pObj);

            wStream.Position = 0;

            return wStream;
        }

        #endregion

        /// <summary>
        /// Genera un string con el contenido del InnerException .-
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        internal static String GetAllMessageException(Exception ex)
        {
            
            StringBuilder wMessage = new StringBuilder();
            wMessage.Append(ex.Message);
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                wMessage.AppendLine("Source: ");
                wMessage.AppendLine(ex.Source);
                wMessage.AppendLine();
                wMessage.AppendLine("Message: ");
                wMessage.AppendLine(ex.Message);
            }
            return wMessage.ToString();
        }

        /// <summary>
        /// Abre un archivo de texto
        /// </summary>
        /// <param name="pFileName">Nombre completo del archivo</param>
        /// <returns></returns>
        internal static string OpenTextFile(string pFileName)
        {
            using (StreamReader sr = File.OpenText(pFileName))
            {
                string retString = sr.ReadToEnd();
                sr.Close();

                return retString;
            }

        }
     
        /// <summary>
        /// Agrega el texto a un archivo. Si el archivo no existe, este método crea uno nuevo. 
        /// </summary>
        /// <param name="pFileName">Nombre completo del archivo</param>
        /// <param name="pContent">Contenido del archivo</param>
        /// <param name="pAppend">Determina si se van a agregar datos al archivo. 
        /// Si ya existe el archivo y append es false, el archivo se sobrescribirá. 
        /// Si ya existe el archivo y append es true, los datos se anexarán al archivo. De lo contrario, se crea un nuevo archivo. 
        /// </param>
        public static void SaveTextFile(string pFileName, string pContent, bool pAppend)
        {
            using (StreamWriter sw = new StreamWriter(pFileName, pAppend))
            {
                sw.Write(pContent);
                sw.Close();
            }
        }
        internal static string ProgramFilesx86()
        {
            if (8 == IntPtr.Size
                || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            }

            return Environment.GetEnvironmentVariable("ProgramFiles");
        }

        internal static EnvDTE.Project GetDTE_SelectedProject(EnvDTE.Solution solution)
        {
            EnvDTE.Project project = null;
            EnvDTE.SelectedItems wSelectedItems = ((EnvDTE.SelectedItems)((EnvDTE.Projects)solution.Projects).DTE.SelectedItems);

            if (wSelectedItems.Item(1).ProjectItem != null)
            {
                project = ((EnvDTE.Project)wSelectedItems.Item(1).ProjectItem.ContainingProject);

            }

            if (wSelectedItems.Item(1).Project != null)
            {
                project = wSelectedItems.Item(1).Project;
            }
            return project;
        }

        /// <summary>
        /// ReferencePath
        ///PreBuildEvent
        ///Copyright
        ///ApplicationIcon
        ///ExcludedPermissions
        ///RunPostBuildEvent
        ///DefaultTargetSchema
        ///RootNamespace
        ///ManifestTimestampUrl
        ///ManifestKeyFile
        ///DebugSecurityZoneURL
        ///Product
        ///PostBuildEvent
        ///OptionStrict
        ///DefaultHTMLPageLayout
        ///DelaySign
        ///OutputType
        ///NeutralResourcesLanguage
        ///OptionExplicit
        ///OutputFileName
        ///ServerExtensionsVersion
        ///AssemblyGuid
        ///GenerateManifests
        ///AssemblyVersion
        ///Win32ResourceFile
        ///Description
        ///URL
        ///DefaultClientScript
        ///TargetFrameworkSubset
        ///TargetFramework
        ///SignManifests
        ///OfflineURL
        ///WebServerVersion
        ///Publish
        ///AssemblyType
        ///FullPath
        ///WebAccessMethod
        ///AssemblyKeyProviderName
        ///TypeComplianceDiagnostics
        ///Company
        ///ActiveFileSharePath
        ///AssemblyOriginatorKeyFile
        ///ApplicationManifest
        ///AssemblyFileVersion
        ///AspnetVersion
        ///FileSharePath
        ///AssemblyName
        ///LocalPath
        ///DefaultNamespace
        ///LinkRepair
        ///TargetZone
        ///SignAssembly
        /// </summary>
        /// <param name="project"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        internal static EnvDTE.Property GetDTEProperty(EnvDTE.Project project, string propertyName)
        {

            EnvDTE.Properties wProperties = ((EnvDTE.Properties)project.Properties);

            return GetDTEProperty(wProperties, propertyName); ;
        }

        /// <summary>
        /// ExtenderCATID
        ///ProjectDependencies
        ///Extender
        ///ActiveConfig
        ///Path
        ///ExtenderNames
        ///Description
        ///Name
        ///StartupProject
        /// </summary>
        /// <param name="solution"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        internal static EnvDTE.Property GetDTEProperty(EnvDTE.Solution solution, string propertyName)
        {

            EnvDTE.Properties wProperties = ((EnvDTE.Properties)solution.Properties);
            return GetDTEProperty(wProperties, propertyName);
        }

        internal static EnvDTE.Property GetDTEProperty(EnvDTE.Properties pProperties, string propertyName)
        {
            StringBuilder str = new StringBuilder();
            EnvDTE.Property prop = null;
            foreach (EnvDTE.Property p in pProperties)
            {
                str.AppendLine(p.Name);
                if (p.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase))
                {
                    prop = ((EnvDTE.Property)pProperties.Item(propertyName));
                    break;
                }
            }

            return prop;
        }
        internal static EnvDTE.Project GetDTEProject(EnvDTE.Solution solution, string layer)
        {
            EnvDTE.Project prj = null;
            int start = 0;
            layer = string.Concat(".", layer);

            //Recorrido de los proyectos
            for (int i = 1; i <= solution.Projects.Count; i++)
            {
                prj = (EnvDTE.Project)solution.Projects.Item(i);
                //tomo el punto de inicio de la comparacion que es:
                // desde el final del nombre del proyecto 
                // hasta la cantiad de letras de "layer" (SVC, ISVC, etc) mas el punto .-
                start = prj.Name.Length - layer.Length;
                //Comparo si el final del nombre del proyecto es igual a .layer (ej: .ISVC)
                if (prj.Name.Substring(start, layer.Length).Equals(layer, StringComparison.OrdinalIgnoreCase))
                    break;
            }

            return prj;
        }
    }







    /// <summary>
    /// 
    /// </summary>
    public class UserDefinedTypesBack 
    {
        CnnString _CnnString;
        private UserDefinedTypes _UserDefinedTypes;

        public UserDefinedTypes UserDefinedTypes
        {
            get { return _UserDefinedTypes; }
            set { _UserDefinedTypes = value; }
        }
        private String _GetUserDefinedTypesQuery;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="pCnnString"></param>
        public UserDefinedTypesBack(CnnString pCnnString)
            
        {
            _CnnString = pCnnString;
           
            _GetUserDefinedTypesQuery = GetQuery();
            _UserDefinedTypes = LoadUserDefinedTypes();
        }

        /// <summary>
        /// Carga los tipos definidos por el usuario
        /// </summary>
        /// <returns>Tables </returns>
         UserDefinedTypes LoadUserDefinedTypes()
        {

            DataTable wDttTypes = null;
            UserDefinedType wUserDefinedType;
            UserDefinedTypes wUserDefinedTypes = new UserDefinedTypes();
       
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

      
                return wUserDefinedTypes;

            }
            catch (Exception ex)
            { throw ex; }

        }

        DataTable GetUserDefinedTypesFromDataBase()
        {
            using (SqlConnection wCnn = new SqlConnection(_CnnString.ToString()))
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

    /// <summary>
    /// Coleccion de tipos de datos de SQL que son deficidos por el usuario
    /// </summary>
    [XmlRoot("UserDefinedTypes"), SerializableAttribute]
    public class UserDefinedTypes : List<UserDefinedType>
    {



        ///// <summary>
        ///// Obtiene una UserDefinedType de la coleccion de UserDefinedTypes .-
        ///// </summary>
        ///// <param name="pUserDefinedTypeName">Nombre del tipo definido por el usuario-</param>
        ///// <returns>UserDefinedType</returns>
        public UserDefinedType GetUserDefinedType(string pUserDefinedTypeName)
        {
            UserDefinedType wUserDefinedType = null;
            if(this.Exists(p => p.Name.Equals(pUserDefinedTypeName)))
                wUserDefinedType = this.First<UserDefinedType>(p => p.Name.Equals(pUserDefinedTypeName));

            return wUserDefinedType;

        }
    }

    /// <summary>
    /// Clase que reprecenta la un tipodefinido por el usuario.- Es un tipo de dato customizado.-
    /// </summary>
    [XmlInclude(typeof(UserDefinedType)), Serializable]
    public class UserDefinedType 
    {
        private string _Name;
        private string _Schema;
        private Int32 _Length;
        private Int32 _NumericPrecision;
        private string _SystemType;


        private Boolean _Nullable;

        /// <summary>
        /// Nombre del tipo
        /// </summary>
        public UserDefinedType()
        {
        }
        /// <summary>
        /// Tipo del sistema que conforma el tiipo de dato definido por el usuario.-
        /// </summary>
        public string SystemType
        {
            get { return _SystemType; }
            set { _SystemType = value; }
        }
        /// <summary>
        /// Nombre del tipo definido por el usuario.-
        /// </summary>
        [XmlElement(ElementName = "Name", IsNullable = true, DataType = "string")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// Esquema al que pertenece el tipo definido por el usuario.-
        /// </summary>
        [XmlElement(ElementName = "Schema", IsNullable = true, DataType = "string")]
        public string Schema
        {
            get { return _Schema; }
            set { _Schema = value; }
        }

        /// <summary>
        /// Largo del tipo definido por el usuario.-
        /// </summary>
        public Int32 Length
        {
            get { return _Length; }
            set { _Length = value; }
        }

        /// <summary>
        /// Precicion
        /// </summary>
        public Int32 NumericPrecision
        {
            get { return _NumericPrecision; }
            set { _NumericPrecision = value; }
        }


        /// <summary>
        /// indica si este tipo de datos acepta nulos o no.-
        /// </summary>
        public Boolean Nullable
        {
            get { return _Nullable; }
            set { _Nullable = value; }
        }
    }
}
