using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Schema;

namespace Fwk.Bases
{


    [XmlRoot("dictionary")]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
{
    public XmlSchema GetSchema()
    {
        return null;
    }
 
    public void ReadXml(XmlReader xmlReader)
    {
        XmlSerializer keyXmlSerializer     = new XmlSerializer(typeof(TKey));
        XmlSerializer valueXmlSerializer   = new XmlSerializer(typeof(TValue));
 
        if (xmlReader.IsEmptyElement)
            return;
 
        xmlReader.ReadStartElement("root");
 
        while (xmlReader.NodeType != XmlNodeType.EndElement)
        {
            xmlReader.ReadStartElement("item");
            xmlReader.ReadStartElement("key");
 
            TKey key = (TKey)keyXmlSerializer.Deserialize(xmlReader);
 
            xmlReader.ReadEndElement();
            xmlReader.ReadStartElement("value");
            TValue value = (TValue)valueXmlSerializer.Deserialize(xmlReader);
            xmlReader.ReadEndElement();
 
            this.Add(key, value);
            xmlReader.ReadEndElement();                
        }
 
        xmlReader.ReadEndElement();
    }
 
    public SerializableDictionary<TKey, TValue> ReadFromString(string xmlString)
    {
        SerializableDictionary<TKey, TValue> result = null;
 
        StringReader stringReader = new StringReader(xmlString);
        XmlTextReader xmlTextReader = new XmlTextReader(stringReader);
 
        ReadXml(xmlTextReader);
 
        xmlTextReader.Close();
        stringReader.Close();
 
        return result;
    }
 
    public void WriteXml(XmlWriter xmlWriter)
    {
        XmlSerializer keyXMLSerializer     = new XmlSerializer(typeof(TKey));
        XmlSerializer valueXMLSerializer   = new XmlSerializer(typeof(TValue));
 
        foreach (TKey key in this.Keys)
        {
            xmlWriter.WriteStartElement("item");
 
            xmlWriter.WriteStartElement("key");
            keyXMLSerializer.Serialize(xmlWriter, key);
            xmlWriter.WriteEndElement();
 
            xmlWriter.WriteStartElement("value");
            TValue value = this[key];
            valueXMLSerializer.Serialize(xmlWriter, value);
            xmlWriter.WriteEndElement();
 
            xmlWriter.WriteEndElement();
        }
    }        
 
    public string SerializeToString()
    {
        string result = null;
        MemoryStream memoryStream = new MemoryStream();
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
        xmlTextWriter.Namespaces = true;
 
        WriteXml(xmlTextWriter);
 
        xmlTextWriter.Close();
        memoryStream.Close();
 
        result = Encoding.UTF8.GetString(memoryStream.GetBuffer());
        result = result.Substring(result.IndexOf(Convert.ToChar(60)));
        result = result.Substring(0, (result.LastIndexOf(Convert.ToChar(62)) + 1));
        result = "<root>" + result + "</root>";
 
        return result;
    }
}
    //[Serializable()]
    //public class SerializableDictionary<TKey, TVal> : Dictionary<TKey, TVal>, IXmlSerializable, ISerializable
    //{
    //    #region Constants
    //    private const string DictionaryNodeName = "Dictionary";
    //    private const string ItemNodeName = "Item";
    //    private const string KeyNodeName = "Key";
    //    private const string ValueNodeName = "Value";
    //    #endregion
    //    #region Constructors
    //    public SerializableDictionary()
    //    {
    //    }

    //    public SerializableDictionary(IDictionary<TKey, TVal> dictionary)
    //        : base(dictionary)
    //    {
    //    }

    //    public SerializableDictionary(IEqualityComparer<TKey> comparer)
    //        : base(comparer)
    //    {
    //    }

    //    public SerializableDictionary(int capacity)
    //        : base(capacity)
    //    {
    //    }

    //    public SerializableDictionary(IDictionary<TKey, TVal> dictionary, IEqualityComparer<TKey> comparer)
    //        : base(dictionary, comparer)
    //    {
    //    }

    //    public SerializableDictionary(int capacity, IEqualityComparer<TKey> comparer)
    //        : base(capacity, comparer)
    //    {
    //    }

    //    #endregion
    //    #region ISerializable Members

    //    protected SerializableDictionary(SerializationInfo info, StreamingContext context)
    //    {
    //        int itemCount = info.GetInt32("ItemCount");
    //        for (int i = 0; i < itemCount; i++)
    //        {
    //            KeyValuePair<TKey, TVal> kvp = (KeyValuePair<TKey, TVal>)info.GetValue(String.Format("Item{0}", i), typeof(KeyValuePair<TKey, TVal>));
    //            this.Add(kvp.Key, kvp.Value);
    //        }
    //    }

    //    void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
    //    {
    //        info.AddValue("ItemCount", this.Count);
    //        int itemIdx = 0;
    //        foreach (KeyValuePair<TKey, TVal> kvp in this)
    //        {
    //            info.AddValue(String.Format("Item{0}", itemIdx), kvp, typeof(KeyValuePair<TKey, TVal>));
    //            itemIdx++;
    //        }
    //    }

    //    #endregion
    //    #region IXmlSerializable Members

    //    void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer)
    //    {
    //        //writer.WriteStartElement(DictionaryNodeName);
    //        foreach (KeyValuePair<TKey, TVal> kvp in this)
    //        {
    //            writer.WriteStartElement(ItemNodeName);
    //            writer.WriteStartElement(KeyNodeName);
    //            KeySerializer.Serialize(writer, kvp.Key);
    //            writer.WriteEndElement();
    //            writer.WriteStartElement(ValueNodeName);
    //            ValueSerializer.Serialize(writer, kvp.Value);
    //            writer.WriteEndElement();
    //            writer.WriteEndElement();
    //        }
    //        //writer.WriteEndElement();
    //    }

    //    void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
    //    {
    //        if (reader.IsEmptyElement)
    //        {
    //            return;
    //        }

    //        // Move past container
    //        if (!reader.Read())
    //        {
    //            throw new XmlException("Error in Deserialization of Dictionary");
    //        }

    //        //reader.ReadStartElement(DictionaryNodeName);
    //        while (reader.NodeType != XmlNodeType.EndElement)
    //        {
    //            reader.ReadStartElement(ItemNodeName);
    //            reader.ReadStartElement(KeyNodeName);
    //            TKey key = (TKey)KeySerializer.Deserialize(reader);
    //            reader.ReadEndElement();
    //            reader.ReadStartElement(ValueNodeName);
    //            TVal value = (TVal)ValueSerializer.Deserialize(reader);
    //            reader.ReadEndElement();
    //            reader.ReadEndElement();
    //            this.Add(key, value);
    //            reader.MoveToContent();
    //        }
    //        //reader.ReadEndElement();

    //        reader.ReadEndElement(); // Read End Element to close Read of containing node
    //    }

    //    System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
    //    {
    //        return null;
    //    }

    //    #endregion
    //    #region Private Properties
    //    protected XmlSerializer ValueSerializer
    //    {
    //        get
    //        {
    //            if (valueSerializer == null)
    //            {
    //                valueSerializer = new XmlSerializer(typeof(TVal));
    //            }
    //            return valueSerializer;
    //        }
    //    }

    //    private XmlSerializer KeySerializer
    //    {
    //        get
    //        {
    //            if (keySerializer == null)
    //            {
    //                keySerializer = new XmlSerializer(typeof(TKey));
    //            }
    //            return keySerializer;
    //        }
    //    }
    //    #endregion
    //    #region Private Members
    //    private XmlSerializer keySerializer = null;
    //    private XmlSerializer valueSerializer = null;
    //    #endregion
    //}
}