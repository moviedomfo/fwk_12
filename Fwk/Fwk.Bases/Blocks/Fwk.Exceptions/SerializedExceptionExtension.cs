using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web.Services.Protocols;
using System.Xml;


namespace Fwk.Exceptions
{
    /// <summary>
    /// Extension used to inject a serialized exception into the Detail 
    /// node of a soap fault.
    /// </summary>
    public class SerializedExceptionExtension : SoapExtension
    {
        Stream _oldStream;
        Stream _newStream;

        /// <summary>
        /// Saves the stream in a local buffer and returns a new 
        /// Memory stream.
        /// </summary>
        /// <param name="stream">Stream.</param>
        /// <returns></returns>
        public override Stream ChainStream(Stream stream)
        {
            _oldStream = stream;
            _newStream = new MemoryStream();
            return _newStream;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public override void ProcessMessage(SoapMessage message)
        {
            if (message.Stage == SoapMessageStage.AfterSerialize)
            {
                _newStream.Position = 0;

                if (message.Exception != null && message.Exception.InnerException != null)
                {
                    InsertDetailIntoOldStream(message.Exception.InnerException);
                }
                else
                {
                    CopyStream(_newStream, _oldStream);
                }
            }
            else if (message.Stage == SoapMessageStage.BeforeDeserialize)
            {
                CopyStream(_oldStream, _newStream);
                _newStream.Position = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        void CopyStream(Stream from, Stream to)
        {
            TextReader reader = new StreamReader(from);
            TextWriter writer = new StreamWriter(to);
            writer.WriteLine(reader.ReadToEnd());
            writer.Flush();
        }

        void InsertDetailIntoOldStream(Exception exception)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(_newStream);
            XmlNode detailNode = doc.SelectSingleNode("//detail");
            try
            {
                detailNode.InnerXml = GetXmlExceptionInformation(exception);
            }
            catch (Exception exc)
            {
                detailNode.InnerXml = exc.Message;
            }

            XmlWriter writer = new XmlTextWriter(_oldStream, Encoding.UTF8);
            doc.WriteTo(writer);
            writer.Flush();
        }

        string GetXmlExceptionInformation(Exception exception)
        {
            string format = "<Message>{0}</Message>"
                + "<Type>{1}</Type>"
                + "<StackTrace>{2}</StackTrace>"
                + "<Serialized>{3}</Serialized>";
            return string.Format(format, exception.Message, exception.GetType().FullName, exception.StackTrace, SerializeException(exception));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        string SerializeException(Exception exception)
        {
            MemoryStream stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, exception);
            stream.Position = 0;
            return Convert.ToBase64String(stream.ToArray());
        }

        /// <summary>
        /// Given a <see cref="SoapException"/> raised using a <see cref="SerializedExceptionExtension"/>, 
        /// this class will examine the Detail node and return an instance of 
        /// <see cref="SoapOriginalException"/> which contains details about the original exception. 
        /// If possible, it even contains the original exception as a property .
        /// </summary>
        /// <param name="exception">Exception.</param>
        /// <returns></returns>
        public static SoapOriginalException GetOriginalException(SoapException exception)
        {
            return new SoapOriginalException(exception);
        }

        #region Not Used
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public override object GetInitializer(Type serviceType)
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="initializer"></param>
        public override void Initialize(object initializer)
        {
        }
        #endregion
    }


    /// <summary>
    /// Attribute applied to a WebMethod to indicate any 
    /// exceptions should be serialized within the detail 
    /// node using the <see cref="SerializedExceptionExtension"/> class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class SerializedExceptionExtensionAttribute : SoapExtensionAttribute
    {

        /// <summary>
        /// 
        /// </summary>
        public override Type ExtensionType
        {
            get
            {
                return typeof(SerializedExceptionExtension);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override int Priority
        {
            get { return 0; }
            set { }
        }
    }
}
