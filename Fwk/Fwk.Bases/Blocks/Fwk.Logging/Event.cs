using System;
using System.Xml;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Xml;
using Fwk.Bases;
using System.Linq;

namespace Fwk.Logging
{
    /// <summary>
    /// Clase que modela el evento a loguear.
    /// </summary>
    /// <date>200609/02</date>
    /// <author>moviedo</author>
    [XmlInclude(typeof(Event)), Serializable]
    public class Event : Fwk.Bases.Entity
    {
        #region <private members>
        private String _AppId = string.Empty;
        private String _Source = string.Empty;
        private EventType _LogType;
        private Guid _Id;
        private string _UserLoginName = string.Empty;
        private string _Machine = string.Empty;
        private CData _Message = new CData();
        private DateTime _LogDate;
        #endregion

        #region <constructor>
        /// <summary>
        /// Constructor de Event que inicializa todos los atributos como nulos o empty 
        /// Valor por defecto:  
        ///  Id es autogenerado
        /// </summary>
        public Event()
        {
            _Id = Guid.NewGuid();
            _LogDate = Fwk.HelperFunctions.DateFunctions.NullDateTime;
            _LogType = EventType.None;
        }
        /// <summary>
        /// Constructor de Event.
        /// Valor por defecto:     
        ///   Id es autogenerado 
        ///   Machine = Environment.MachineName;
        ///   UserLoginName = Environment.UserName;
        ///   LogDate = DateTime.Now;
        /// </summary>
        /// <param name="pType">Tipo de evento.</param>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pMessage">Mensaje descriptivo del evento.</param>
        public Event(EventType pType, string pSource, string pMessage)
        {
            _Id = Guid.NewGuid();
            _LogType = pType;
            _Source = pSource;
            _Message.Text = pMessage;
            _Machine = Environment.MachineName;
            _UserLoginName = Environment.UserName;
            _LogDate = DateTime.Now;
        }

        /// <summary>
        /// Constructor de Event.
        /// Valor por defecto:     
        ///   Id es autogenerado
        ///   LogDate = DateTime.Now;
        /// </summary>
        /// <param name="pType">Tipo de evento.</param>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pMessage">Mensaje descriptivo del evento.</param>
        /// <param name="pMachine">Equipo donde se origina el evento.</param>
        /// <param name="pUserName">Usuario que origina el evento.</param>
        public Event(EventType pType, string pSource, string pMessage, string pMachine, string pUserName)
        {
            _Id = Guid.NewGuid();
            _LogType = pType;
            _Source = pSource;
            _Message.Text = pMessage;
            _Machine = pMachine;
            _UserLoginName = pUserName;
            _LogDate = DateTime.Now;
        }

        /// <summary>
        ///  Constructor de Event. 
        /// Valor por defecto:     
        ///   Id es autogenerado
        ///   LogDate = DateTime.Now;
        /// </summary>
        /// <param name="pType">Tipo de evento.</param>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pMessage">Mensaje descriptivo del evento.</param>
        /// <param name="pMachine">Equipo donde se origina el evento.</param>
        /// <param name="pUserName">Usuario que origina el evento.</param>
        /// <param name="appId">Identificador de la aplicación que genera el log</param>
        public Event(EventType pType, string pSource, string pMessage, string pMachine, string pUserName, string appId)
        {
            _Id = Guid.NewGuid();
            _AppId = appId;
            _LogType = pType;

            _Source = pSource;
            _Message.Text = pMessage;
            _Machine = pMachine;
            _UserLoginName = pUserName;
            _LogDate = DateTime.Now;
        }

        #endregion

        #region <public properties>
        /// <summary>
        /// Mensaje descriptivo del evento.
        /// </summary>
        [XmlElement("Message", Type = typeof(Fwk.Xml.CData))]
        public CData Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        /// <summary>
        /// Fecha y hora en la que se produce el evento.
        /// </summary>
        [XmlAttribute("Date")]
        public DateTime LogDate
        {
            get { return _LogDate; }
            set { _LogDate = value; }
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
            get { return _UserLoginName; }
            set { _UserLoginName = value; }
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
        [XmlAttribute("LogType")]
        public EventType LogType
        {
            get { return _LogType; }
            set { _LogType = value; }
        }

        /// <summary>
        /// Origen del evento.
        /// </summary>
        [XmlAttribute("Source")]
        public String Source
        {
            get
            {
                if (string.IsNullOrEmpty(_Source))
                    _Source = ConfigurationsHelper.HostApplicationName;

                return _Source;
            }
            set { _Source = value; }
        }
        /// <summary>
        /// Identificador de la aplicacion o sistema qhe genera el log.-
        /// </summary>
        [XmlAttribute("AppId")]
        public String AppId
        {
            get { return _AppId; }
            set { _AppId = value; }
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
            wStringBuilder.Append(string.Concat("Log Id: ", this._Id));
            wStringBuilder.AppendLine();
            wStringBuilder.Append(" | Date: ");
            wStringBuilder.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff", CultureInfo.InvariantCulture));
            wStringBuilder.AppendLine(string.Concat(" Type: ", _LogType.ToString().ToUpper()));

            wStringBuilder.AppendLine("Message: ");
            wStringBuilder.AppendLine(this._Message.Text);
            wStringBuilder.AppendLine(" Source: ");
            wStringBuilder.Append(this._Source);
            wStringBuilder.AppendLine(" User: ");
            wStringBuilder.Append(this._UserLoginName);
            wStringBuilder.AppendLine(" Machine: ");
            wStringBuilder.Append(this._Machine);
            wStringBuilder.AppendLine(" Applcation Id: ");
            wStringBuilder.Append(_AppId);
            return wStringBuilder.ToString();
        }


        #endregion
    }



    /// <summary>
    /// Lista de eventos logs
    /// </summary>
    [XmlRoot("Events"), SerializableAttribute]
    public class Events : Fwk.Bases.Entities<Event>
    {
        /// <summary>
        /// Obtiene el primer contacto donde Id EndsWith jid.Bare
        /// </summary>
        /// <param name="jid"></param>
        /// <returns></returns>
        public Event Get_ByID(Guid id)
        {
            if (this.Exist(id))
            {
                var n = from e in this where (e.Id == id) select e;
                return n.FirstOrDefault<Event>();
            }
            else
            {
                return null;
            }
        }

        public bool Exist(Guid id)
        {
            return this.Count<Event>(e => e.Id == id) > 0;
        }


        public Events SearchByParams(EventType type)
        {
            Events lisToReturn = new Events();
            var list = from item in this where item.LogType == type select item;

            lisToReturn.AddRange(list.ToArray<Event>());
            return lisToReturn;
        }

        public  Events SearchByParam(Event pEvent)
        {


            var lisToReturn = from s in this
                                  where
                                      (String.IsNullOrEmpty(pEvent.Machine) || s.Machine.StartsWith(pEvent.Machine))
                                      &&
                                      (String.IsNullOrEmpty(pEvent.User) || s.Machine.StartsWith(pEvent.User))
                                      &&
                                      (pEvent.LogType == EventType.None || s.LogType == pEvent.LogType)
                                      &&
                                      (pEvent.LogDate == HelperFunctions.DateFunctions.NullDateTime || s.LogDate >= pEvent.LogDate)
                                  select s;
                Events list2 = new Events();


                Fwk.HelperFunctions.TypeFunctions.SetEntitiesFromIenumerable<Events, Event>(list2, lisToReturn);

                
                return list2;

          
        }


         /// <summary>
        /// 
        /// </summary>
        /// <param name="eventIdList"></param>
        public void Remove(List<Guid> eventIdList)
        {
            foreach (Guid guid in eventIdList)
            {
                Event eventToRemove = this.Get_ByID(guid);
                this.Remove(eventToRemove);
            }
        }
    }
}
