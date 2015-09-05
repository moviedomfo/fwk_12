using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.Diagnostics;


namespace Fwk.Guidance.Core
{

    /// <summary>
    /// Helper extraccion de Fwk.Helper para usar desde t4
    /// </summary>
    public static class HelperFunctions
    {
        internal static Fwk.Caching.FwkSimpleStorageBase<Storage> Settings = new Caching.FwkSimpleStorageBase<Storage>();
        static List<string> RequiresNewPrefix;
        static HelperFunctions()
        {
            RequiresNewPrefix = new List<string>();
            RequiresNewPrefix.Add("Create");
            RequiresNewPrefix.Add("Crear");
            RequiresNewPrefix.Add("Insert");
            RequiresNewPrefix.Add("Insertar");
            RequiresNewPrefix.Add("Update");
            RequiresNewPrefix.Add("Modificar");
            RequiresNewPrefix.Add("Actualizar");
            RequiresNewPrefix.Add("Remove");
            RequiresNewPrefix.Add("Remover");
            RequiresNewPrefix.Add("Eliminar");
            RequiresNewPrefix.Add("Delete");
            
            Settings.Load();
            
        }

        public static bool RequiresNew(string value)
        {
            int indexOf = -1;
            foreach (string s in RequiresNewPrefix)
            {

                indexOf = value.IndexOf(s, 0, StringComparison.CurrentCultureIgnoreCase);
                //Si Contiene e inicia.
                if (indexOf != -1 && indexOf == 0)
                    return true;
            }
            return false;
        }
        internal static string GetFileTemplate(string roottemplate, string name)
        {

            string file = name;

            if (System.IO.File.Exists(Path.Combine(roottemplate, name)))
                file = Path.Combine(roottemplate, name);

            if (!System.IO.File.Exists(file))
            {
                throw new Exception(string.Concat("No se pueden encontrar las plantillas de generacion de codigo ex .-", Path.Combine(roottemplate, name)));
            }
            return HelperFunctions.OpenTextFile(file);


        }

        #region -- Xml Serialization using Xml --

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObjType"></param>
        /// <param name="pXmlData"></param>
        /// <returns></returns>
        internal static object Deserialize(Type pObjType, string pXmlData)
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
        internal static object Deserialize(Type pObjType, string pXmlData, string pXPath)
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
        internal static object DeserializeFromXml(Type pTipo, string pXml)
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
        internal static string SerializeToXml(object pObj)
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
        internal static string Serialize(object pObj)
        {
            return Serialize(pObj, false);
        }

        /// <summary>
        /// Serializa un objeto.
        /// </summary>
        /// <param name="pObj">Objeto a serializar</param>
        /// <param name="pRemoveDeclaration">Indica si se debe remover el nodo de declaración</param>
        /// <returns>Representación en XML del objeto</returns>
        internal static string Serialize(object pObj, bool pRemoveDeclaration)
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
        internal static MemoryStream GetStream(object pObj)
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



        internal static void CreateEventLog()
        {
            String Source = "CodeGenerator";
            if (!EventLog.SourceExists(Source, Environment.MachineName))
            {
                EventLog.CreateEventSource(Source, Source);
            }

        }

        internal static void WriteEntryEventLog(String pMessage, Exception pException, int pEventID, EventLogEntryType pEventLogEntryType)
        {
            String LogName = "CodeGenerator";

            // Insert into event log
            EventLog Log = new EventLog();
            Log.Source = LogName;

            pMessage += Environment.NewLine + Fwk.Exceptions.ExceptionHelper.GetAllMessageException(pException);
            Log.WriteEntry(pMessage, pEventLogEntryType, pEventID);

        }
    }





    


}
