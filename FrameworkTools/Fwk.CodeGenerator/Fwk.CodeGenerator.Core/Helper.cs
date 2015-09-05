using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using Fwk.DataBase;
using System.Diagnostics;

namespace Fwk.CodeGenerator
{
  

    public static class HelperFunctions 
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
        public static String GetAllMessageException(Exception ex)
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
        public static string OpenTextFile(string pFileName)
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
        public static string ProgramFilesx86()
        {
            if (8 == IntPtr.Size
                || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            }

            return Environment.GetEnvironmentVariable("ProgramFiles");
        }

        public static Boolean ValidateFileByExtencion(string pExtencion, string pFullNemeFile)
        {
            if (!System.IO.File.Exists(pFullNemeFile)) return false;
            if (pFullNemeFile.Length > 3)
            {
                if (pFullNemeFile.Substring(pFullNemeFile.Length - 3, 3).ToLower() != pExtencion.ToLower()) return false;
            }
            else
                return false;

            return true;

        }

        public static void CreateEventLog()
        {
            String Source = "CodeGenerator";
            if (!EventLog.SourceExists(Source, Environment.MachineName))
            {
                EventLog.CreateEventSource(Source, Source);
            }

        }

        public static void WriteEntryEventLog(String pMessage, Exception pException, int pEventID, EventLogEntryType pEventLogEntryType)
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
