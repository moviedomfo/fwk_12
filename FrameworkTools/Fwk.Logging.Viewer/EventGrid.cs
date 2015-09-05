using System;
using System.Xml;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Xml;
using Fwk.Bases;
using System.Linq;
using System.Drawing;

namespace Fwk.Logging.Viewer
{
    /// <summary>
    /// Clase que modela el evento a loguear.
    /// </summary>
    /// <date>200609/02</date>
    /// <author>moviedo</author>
    [Serializable]
    public class EventGrid : Fwk.Bases.Entity
    {
        #region <private members>
        private String _AppId;
        private String _Source;
        private EventType _LogType;
        private Guid _Id;
        private string _UserLoginName;
        private string _Machine;
        private CData _Message = new CData();
        private DateTime _LogDate;
        private Image _LogImage;
        private Message _FormatedMessage;

        public Message FormatedMessage
        {
            get { return _FormatedMessage; }
            set { _FormatedMessage = value; }
        }
        public Image LogImage
        {
            get { return _LogImage; }
            //set { _LogImage = value; }
        }
        #endregion

        #region <constructor>

        public EventGrid()
        {
         
        }
        /// <summary>
        /// Constructor de EventGrid.
        /// </summary>
        public EventGrid(Event pEvent)
        {

            _Id = pEvent.Id;
            _LogType = pEvent.LogType;
            _Source = pEvent.Source;
            _Message = pEvent.Message;
            _Machine = pEvent.Machine;
            _UserLoginName = pEvent.User;
            _LogDate = pEvent.LogDate;
            _AppId = pEvent.AppId;
            _LogImage = GetImageByType(_LogType);
        }
     

        #endregion

        #region <public properties>
        /// <summary>
        /// Mensaje descriptivo del evento.
        /// </summary>
        public CData Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        /// <summary>
        /// Fecha y hora en la que se produce el evento.
        /// </summary>
        public DateTime LogDate
        {
            get { return _LogDate; }
            set { _LogDate = value; }
        }
        /// <summary>
        /// Equipo donde se origina el evento.
        /// </summary>
        public string Machine
        {
            get { return _Machine; }
            set { _Machine = value; }
        }

        /// <summary>
        /// Usuario que origina el evento.
        /// </summary>
        public string User
        {
            get { return _UserLoginName; }
            set { _UserLoginName = value; }
        }

        /// <summary>
        /// Identificador único del evento.
        /// </summary>
        public Guid Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        /// <summary>
        /// Tipo de evento.
        /// </summary>
        public EventType LogType
        {
            get { return _LogType; }
            set { _LogType = value; }
        }

        /// <summary>
        /// Origen del evento.
        /// </summary>
        
        public String Source
        {
            get { return _Source; }
            set { _Source = value; }
        }
        /// <summary>
        /// Identificador de la aplicacion o sistema qhe genera el log.-
        /// </summary>
       
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
        static Image GetImageByType(EventType pEventType)
        {
            switch (pEventType)
            {
                case EventType.Error:
                    {
                        return Fwk.Logging.Viewer.Properties.Resources.Error;
                    }
                case EventType.Information:
                    {
                        return Fwk.Logging.Viewer.Properties.Resources.Information;
                    }
                case EventType.Warning:
                    {
                        return Fwk.Logging.Viewer.Properties.Resources.Warning;
                    }

                case EventType.Audit:
                    {
                        return Fwk.Logging.Viewer.Properties.Resources.audit;
                    }
            }
            return Fwk.Logging.Viewer.Properties.Resources.Information;
        }
    }

    /// <summary>
    /// Lista de eventos logs
    /// </summary>
    [XmlRoot("EventGridList"), SerializableAttribute]
    public class EventGridList : Fwk.Bases.Entities<EventGrid>
    {
        /// <summary>
        /// Obtiene el primer contacto donde Id EndsWith jid.Bare
        /// </summary>
        /// <param name="jid"></param>
        /// <returns></returns>
        public EventGrid Get_ByID(Guid id)
        {
            if (this.Exist(id))
            {
                var n = from e in this where (e.Id == id) select e;
                return n.FirstOrDefault<EventGrid>();
            }
            else
            {
                return null;
            }
        }

        public bool Exist(Guid id)
        {
            return this.Count<EventGrid>(e => e.Id == id) > 0;
        }


        public EventGridList SearchByParams(EventType type)
        {
            EventGridList lisToReturn = new EventGridList();
            var list = from item in this where item.LogType == type select item;

            lisToReturn.AddRange(list.ToArray<EventGrid>());
            return lisToReturn;
        }

        public EventGridList SearchByParam(EventGrid pEvent)
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
            EventGridList list2 = new EventGridList();


            Fwk.HelperFunctions.TypeFunctions.SetEntitiesFromIenumerable<EventGridList, EventGrid>(list2, lisToReturn);


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
                EventGrid eventToRemove = this.Get_ByID(guid);
                this.Remove(eventToRemove);
            }
        }
    }
}
