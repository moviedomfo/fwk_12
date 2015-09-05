using System;
using System.Xml;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using Fwk.Xml;
using System.Xml.Serialization;
using Fwk.Logging;

namespace Fwk.Bases.Test
{
    /// <summary>
    /// Clase que modela el evento a loguear.
    /// </summary>
    /// <date>200609/02</date>
    /// <author>moviedo</author>
    [XmlInclude(typeof(Event)), Serializable]
    public class Event:Entity
    {
        #region <private members>
        private String _Source;
        private EventType _Type;
        private Guid _Id;
        private string _User;
        private string _Machine;
        private string _Message;
        private DateTime _DateAndTime;
        #endregion

        #region <constructor>
        /// <summary>
        /// Constructor de Event.
        /// </summary>
        public Event(){}

        #endregion

        #region <public properties>
        /// <summary>
        /// Mensaje descriptivo del evento.
        /// </summary>
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        /// <summary>
        /// Fecha y hora en la que se produce el evento.
        /// </summary>
        [XmlAttribute("DateAndTime")]
        public DateTime DateAndTime
        {
            get { return _DateAndTime; }
            set { _DateAndTime = value; }
        }
        /// <summary>
        /// Equipo donde se origina el evento.
        /// </summary>
        [XmlAttribute("Machine")]
        public string Machine
        {
            get { return _Machine; }
            set { _Machine = value; }
        }

        /// <summary>
        /// Usuario que origina el evento.
        /// </summary>
        [XmlAttribute("User")]
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }

        /// <summary>
        /// Identificador único del evento.
        /// </summary>
        [XmlAttribute("Id")]
        public Guid Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        /// <summary>
        /// Tipo de evento.
        /// </summary>
        [XmlAttribute("Type")]
        public EventType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        /// <summary>
        /// Origen del evento.
        /// </summary>
        [XmlAttribute("Source")]
        public String Source
        {
            get { return _Source; }
            set { _Source = value; }
        }

       
        #endregion

        #region <public methods>
        /// <summary>
        /// Recopila la información de todos los atributos y 
        /// genera una cadena de texto con ella.
        /// </summary>
        /// <returns>Cadena de texto.</returns>
        public override string ToString()
        {
            StringBuilder wStringBuilder = new StringBuilder();            
            wStringBuilder.Append("Log Id: ");
            wStringBuilder.Append(this._Id);
            wStringBuilder.Append(" | Date: ");
            wStringBuilder.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff", CultureInfo.InvariantCulture));
            wStringBuilder.Append(" | Type: ");
            wStringBuilder.Append(this._Type.ToString().ToUpper());
            wStringBuilder.Append(" | Message: ");
            wStringBuilder.Append(this._Message);
            wStringBuilder.Append(" | Source: ");
            wStringBuilder.Append(this._Source);
            wStringBuilder.Append(" | User: ");
            wStringBuilder.Append(this._User);
            wStringBuilder.Append(" | Machine: ");
            wStringBuilder.Append(this._Machine);
            return wStringBuilder.ToString();
        }

        /// <summary>
        /// Recopila la información de todos los atributos y
        /// genera un nodo Xml con ella.
        /// </summary>
        /// <returns>Nodo Xml.</returns>
        public XmlNode ToXml()
        {
            XmlDocument wDocument = new XmlDocument();
            XmlElement wElement = Element.ElementCreateAndAdd(wDocument, "Log");
            NodeAttribute.AttributeCreateAndSet(wDocument, wElement, "id", this._Id.ToString());
            NodeAttribute.AttributeCreateAndSet(wDocument, wElement, "dateTime", this._DateAndTime.ToString("yyyy-MM-dd HH:mm:ss.ffff", CultureInfo.InvariantCulture));
            NodeAttribute.AttributeCreateAndSet(wDocument, wElement, "type", this._Type.ToString().ToUpper());
            NodeAttribute.AttributeCreateAndSet(wDocument, wElement, "source", this._Source);
            NodeAttribute.AttributeCreateAndSet(wDocument, wElement, "user", this._User);
            NodeAttribute.AttributeCreateAndSet(wDocument, wElement, "machine", this._Machine);
            CData.CDATASectionCreateAndAdd(Node.NodeCreateAndAdd(wElement, "Message"), this.Message);
            return wElement;
        }
       
        #endregion
    }
}
