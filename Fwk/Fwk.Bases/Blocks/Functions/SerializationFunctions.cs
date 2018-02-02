using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Fwk.HelperFunctions
{
    /// <summary>
    /// Esta clase ayuda con los problemas que tienen que ver
    /// con la serialización de objetos.
    /// </summary>
    public class SerializationFunctions
    {
        #region -- Binary Serialization --

        /// <summary>
        /// Serializa un objeto a un archivo binario.
        /// </summary>
        /// <param name="fileName">Ruta del archivo en el cual depositar los bytes</param>
        /// <param name="objToSerialize">Objeto en memoria a transformar en bytes</param>
        public static void SerializeToBin(string fileName, object objToSerialize)
        {
            using (System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write))
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter b = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                b.Serialize(fs, objToSerialize);
                fs.Close();
            }  
        }

        /// <summary>
        /// Deserializa un objeto a partir del contenido de un archivo binario
        /// </summary>
        /// <param name="fileName">Archivo desde donde toma los bytes que se
        /// encuentran serializados</param>
        /// <returns>objeto deserializado</returns>
        public static object DeserializeFromBin(string fileName)
        {
            using (System.IO.FileStream ds = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return bf.Deserialize(ds);
            }  
        }

        #endregion

        #region -- Xml Serialization using DataSet --

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObject"></param>
        /// <param name="pDataSet"></param>
        public static void SerializeToXml(object pObject, ref DataSet pDataSet)
        {
            XmlSerializer wSerializer;
            MemoryStream wStream = new MemoryStream();

            if (pDataSet == null)
                pDataSet = new DataSet();

            wSerializer = new XmlSerializer(pObject.GetType());

            wSerializer.Serialize(wStream, pObject);

            wStream.Position = 0;
            pDataSet.ReadXml(wStream);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObj"></param>
        /// <param name="pDataSet"></param>
        public static void Serialize(object pObj, ref DataSet pDataSet)
        {
            XmlSerializer serializer;
            MemoryStream ms = new MemoryStream();

            if (pDataSet == null)
                pDataSet = new DataSet();

            serializer = new XmlSerializer(pObj.GetType());
            serializer.Serialize(ms, pObj);

            ms.Position = 0;
            pDataSet.ReadXml(ms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObjType"></param>
        /// <param name="pDataSet"></param>
        /// <param name="pTableName"></param>
        /// <returns></returns>
        public static object Deserialize(Type pObjType, DataSet pDataSet, string pTableName)
        {
            XmlDocument wDom = new XmlDocument();
            wDom.LoadXml(pDataSet.GetXml());
            return Deserialize(pObjType, wDom.GetElementsByTagName(pTableName).Item(0).OuterXml);
        }

        #endregion

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
        /// Crea un objeto a partir de la descerializacion del xml pasado por parametro
        /// <code>
        /// var xmlContrato = "<Contrato/>";
        /// 
        /// var contrato = new (ContratoBE)SerializationFunctions.DeserializeFromXml(typeOf(ContratoBE),xmlContrato);
        /// 
        /// </code>
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
        /// Serializa un objeto
        /// <code>
        /// var xmlContrato = "<Contrato/>";
        /// Contrato c = new Contrato();
        /// var xmlContrato = SerializationFunctions.SerializeToXml(c);
        /// 
        /// </code>
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public static string SerializeToXml(object pObj)
        {
            XmlSerializer wSerializer;
            StringWriter wStwSerializado = new StringWriter();
            XmlTextWriter wXmlWriter = new XmlTextWriter(wStwSerializado);
            XmlSerializerNamespaces wNameSpaces = new XmlSerializerNamespaces();

            wXmlWriter.Formatting = System.Xml.Formatting.Indented;
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
        /// Serializa un objeto utilizando DataContractJsonSerializer
        /// <code>
        /// Contrato c = new Contrato();
        /// //set c properties here 
        /// string strContratoJSON = SerializationFunctions.SerializeObjectToJson&lt;Contrato&gt;(c);
        /// 
        /// </code>
        /// </summary>
        /// <typeparam name="T">Tipo del objeto</typeparam>
        /// <param name="obj">objet</param>
        /// <returns>Retorna un string con el json del objeto.-</returns>
        public static string SerializeObjectToJson<T>(object obj)
        {
            //var json = new JavaScriptSerializer().Serialize(obj);

            //return json;

            MemoryStream stream1 = new MemoryStream();
            System.Runtime.Serialization.Json.DataContractJsonSerializer ser = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));
            ser.WriteObject(stream1, obj);

            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            return sr.ReadToEnd();
        }


        /// <summary>
        /// Serializa un objeto utilizando DataContractJsonSerializer
        /// <code>
        /// Contrato c = new Contrato();
        /// //set c properties here 
        /// string strContratoJSON = (Contrato)SerializationFunctions.SerializeObjectToJson(typeOf(Contrato),c);
        /// 
        /// </code>
        /// </summary>
        /// <param name="objType">typeOf(type)</param>
        /// <param name="obj">Objetc</param>
        /// <returns></returns>
        public static string SerializeObjectToJson(Type objType, object obj)
        {

            //var json = new JavaScriptSerializer().Serialize(obj);

            //return json;

            MemoryStream stream1 = new MemoryStream();
            System.Runtime.Serialization.Json.DataContractJsonSerializer ser = new System.Runtime.Serialization.Json.DataContractJsonSerializer(objType);
            ser.WriteObject(stream1, obj);

            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            return sr.ReadToEnd();
        }

        /// <summary>
        /// Serializar un objeto utilizando JavaScriptSerializer
        /// <code>
        /// Contrato c = new Contrato();
        /// //set c properties here 
        /// string strContratoJSON = (Contrato)SerializationFunctions.SerializeObjectToJson_JavaScriptSerializer(typeOf(Contrato),c);
        /// 
        /// </code>
        /// </summary>
        /// <param name="objType">typeOf(type)</param>
        /// <param name="obj">Objetc</param>
        /// <returns></returns>
        public static string SerializeObjectToJson_JavaScriptSerializer(Type objType, object obj)
        {

            var json = new JavaScriptSerializer().Serialize(obj);

            return json;

           
        }


        /// <summary>
        /// Serializar un objeto utilizando Newtonsoft.Json.SerializeObject
        /// <code>
        /// Contrato c = new Contrato();
        /// //set c properties here 
        /// string strContratoJSON = (Contrato)SerializationFunctions.SerializeObjectToJson_Newtonsoft(typeOf(Contrato),c);
        /// 
        /// </code>
        /// </summary>
        /// <param name="objType">typeOf(type)</param>
        /// <param name="obj">Objetc</param>
        /// <returns></returns>
        public static string SerializeObjectToJson_Newtonsoft(object obj)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj, new JsonSerializerSettings());

            return json;
        }

        /// <summary>
        /// Deserializar un json genericamente DataContractJsonSerializer 
        /// <code>
        /// Contrato c = SerializationFunctions.DeSerializeObjectFromJson&lt;Contrato&gt;(strContratoJSON);
        /// </code>
        /// </summary>
        /// <param name="json">string con formato json</param>
        /// <returns></returns>
        public static T DeSerializeObjectFromJson<T>(string json)
        {
            //var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);

            ////var obj = new JavaScriptSerializer().Deserialize(json, typeof(T));
            //return (T)obj;
            //var instance = Activator.CreateInstance<T>();
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                //var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(instance.GetType());
                var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(ms);
            }
        }

        /// <summary>
        /// Deserializar un json utilizando DataContractJsonSerializer, requiere casteo de tipos
        /// <code>
        /// Contrato c = (Contrato)SerializationFunctions.DeSerializeObjectFromJson(typeOf(Contrato),strContratoJSON);
        /// </code>
        /// </summary>
        /// <param name="objType">typeOf(type)</param>
        /// <param name="json">string con formato json</param>
        /// <returns></returns>
        public static object DeSerializeObjectFromJson(Type objType, string json)
        {

            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(objType);
                return serializer.ReadObject(ms);
            }
        }

        /// <summary>
        /// Deserializar un json utilizando JavaScriptSerializer, requiere casteo de tipos
        /// <code>
        /// Contrato c = (Contrato)SerializationFunctions.DeSerializeObjectFromJson_JavaScriptSerializer(typeOf(Contrato),strContratoJSON);
        /// 
        /// </code>
        /// </summary>
        /// <param name="objType">typeOf(type)</param>
        /// <param name="json">string con formato json</param>
        /// <returns></returns>
        public static object DeSerializeObjectFromJson_JavaScriptSerializer(Type objType, string json)
        {
           
            var obj = new JavaScriptSerializer().Deserialize(json, objType);
            return obj;
        
        }

        /// <summary>
        /// Deserializar un json utilizando Newtonsoft.Json.JsonConvert, requiere casteo de tipos
        /// <code>
        /// Contrato c = (Contrato)SerializationFunctions.DeSerializeObjectFromJson_Newtonsoft(typeOf(Contrato),strContratoJSON);
        /// 
        /// </code>
        /// </summary>
        /// <param name="objType">typeOf(type)</param>
        /// <param name="json">string con formato json</param>
        /// <returns></returns>
        public static object DeSerializeObjectFromJson_Newtonsoft(Type objType, string json)
        {
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(json, objType, new JsonSerializerSettings());
            //dynamic results = JsonConvert.DeserializeObject<dynamic>(json);
            //var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(json, objType.GetType());
            
            return obj;
           
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTypeNameOld"></param>
        /// <param name="pTypeNameNew"></param>
        /// <param name="pXml"></param>
        /// <returns></returns>
        public static string ReplaseTypeNameForSerialization(Type pTypeNameOld, Type pTypeNameNew, String pXml)
        {
            System.Text.StringBuilder strXml = new System.Text.StringBuilder(pXml);

            strXml.Replace("<" + pTypeNameOld.Name + ">", "<" + pTypeNameNew.Name + ">");
            strXml.Replace("</" + pTypeNameOld.Name + @">", "</" + pTypeNameNew.Name + @">");

            return strXml.ToString();
        }
    }
}