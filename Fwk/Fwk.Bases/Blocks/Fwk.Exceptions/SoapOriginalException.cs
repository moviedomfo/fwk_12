using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.Services.Protocols;
using System.Xml;

namespace Fwk.Exceptions
{
	/// <summary>
	/// Used to represent the original exception that was the cause 
	/// of a <see cref="SoapException"/>.  If the original exception 
	/// was successfully serialized, it can be directly accessed 
	/// via the InnerException property.
	/// </summary>
	public class SoapOriginalException : Exception
	{
		/// <summary>
		/// Creates a new <see cref="SoapOriginalException"/> instance.
		/// </summary>
		/// <param name="exception"></param>
		public SoapOriginalException(SoapException exception) : base(GetNodeText(exception.Detail, "Message"), DeserializeException(exception.Detail))
		{
			if(exception.Detail != null)
			{
				_type = GetNodeText(exception.Detail, "Type");
				_stackTrace = GetNodeText(exception.Detail, "StackTrace");
			}
		}

		/// <summary>
		/// Gets the type.
		/// </summary>
		/// <value></value>
		public string Type
		{
			get { return _type; }
		}
		string _type;

		/// <summary>
		/// Gets the stack trace.
		/// </summary>
		/// <value></value>
		public override string StackTrace
		{
			get { return _stackTrace; }
		}

		string _stackTrace;

		static string GetNodeText(XmlNode parent, string nodeName)
		{
			XmlNode node = parent.SelectSingleNode(nodeName);
			if(node != null)
			{
				return node.InnerText;
			}
			return string.Empty;
		}

		static Exception DeserializeException(XmlNode detailNode)
		{
			string serialized = GetNodeText(detailNode, "Serialized");
			if(serialized != null && serialized.Length > 0)
			{
				IFormatter formatter = new BinaryFormatter();
				byte[] buffer = Convert.FromBase64String(serialized);
				MemoryStream stream = new MemoryStream(buffer);
				return formatter.Deserialize(stream) as Exception;
			}
			return null;
		}
	}
}
