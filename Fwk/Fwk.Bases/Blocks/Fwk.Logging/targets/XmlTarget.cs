using System;
using System.Linq;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using Fwk.Xml;
using Fwk.Exceptions;

namespace Fwk.Logging.Targets
{
    /// <summary>
    /// Destino de tipo archivo .Xml.
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public class XmlTarget : Target
    {
        /// <summary>
        /// Listado de eventos de logueo correspondientes a este Target.-
        /// </summary>
        public static Events Logs;
       
        #region <constructor>
        /// <summary>
        /// Constructor de XmlTarget.
        /// </summary>
        public XmlTarget()
        {
            this.Type = TargetType.Xml;
        }
        #endregion

        #region <public overrides>
        /// <summary>
        /// Implementación de la escritura del log del evento
        /// en archivo .Xml.
        /// </summary>
        /// <param name="pEvent">Evento a loguear.</param>
        public override void Write(Event pEvent)
        {

            if (XmlTarget.Logs == null) 
                XmlTarget.Logs = OpenLogsFromFile();
            XmlTarget.Logs.Add(pEvent);
            //TODO: Falta analisis para ejectuar el append
            Fwk.HelperFunctions.FileFunctions.SaveTextFile(this.FileName, XmlTarget.Logs.GetXml(), false);
          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventIdList"></param>
        public override void Remove(List<string> eventIdList)
        {

            if (XmlTarget.Logs == null)
                XmlTarget.Logs = OpenLogsFromFile();
            foreach(string strGuid in eventIdList)
            {
                Event eventToRemove = XmlTarget.Logs.Get_ByID(new Guid(strGuid));
                XmlTarget.Logs.Remove(eventToRemove);
            }
            Fwk.HelperFunctions.FileFunctions.SaveTextFile(this.FileName, XmlTarget.Logs.GetXml(), false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventIdList"></param>
        public override void Remove(List<Guid> eventIdList)
        {

            if (XmlTarget.Logs == null)
                XmlTarget.Logs = OpenLogsFromFile();
            foreach (Guid guid in eventIdList)
            {
                Event eventToRemove = XmlTarget.Logs.Get_ByID(guid);
                XmlTarget.Logs.Remove(eventToRemove);
            }
            Fwk.HelperFunctions.FileFunctions.SaveTextFile(this.FileName, XmlTarget.Logs.GetXml(), false);
        }
        #endregion

        #region <private methods>

       
        /// <summary>
        /// Retorna un Logs asociado al archivo especificado
        /// en la propiedad FileName, si es que este existe. En caso
        /// contrario, retorna un 'nuevo' Logs.
        /// </summary>
        /// <returns>Logs.</returns>
         Events OpenLogsFromFile()
        {
            #region validacion
            if (this.FileName.Trim().Length == 0)
            {
                TechnicalException te = new TechnicalException("Debe especificar un nombre de archivo para guardar el log.");
                te.Assembly = "Fwk.Logging";
                te.Class = "XmlTarget";
                te.ErrorId = "9000";
                te.Namespace = "Fwk.Logging";
                te.UserName = Environment.UserName;
                te.Machine = Environment.MachineName;
                throw te;
            }
            #endregion

            Events wLog = new Events ();

            if (!File.Exists(this.FileName))
            {
                return wLog;
            }
            
            wLog = Events.GetFromXml<Events>(Fwk.HelperFunctions.FileFunctions.OpenTextFile(this.FileName));
            return wLog;
        }

        #endregion

        /// <summary>
        /// Busca directamente en el archivo. No busca por Id
        /// </summary>
        /// <param name="pEvent"></param>
        /// <returns></returns>
         public override Events SearchByParam(Event pEvent)
         {
             Events list = null;
             try
             {
                 list = (Events)Fwk.Logging.Events.GetFromXml<Events>(Fwk.HelperFunctions.FileFunctions.OpenTextFile(FileName));
                 var lisToReturn = from s in list
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

       
                 Fwk.HelperFunctions.TypeFunctions.SetEntitiesFromIenumerable <Events,Event>(list2,lisToReturn);

                 list = null;
                 return list2;
           
             }
             catch (Exception ex)
             {
               
                 throw ex;

             }
         }

        /// <summary>
         ///Busca directamente en el archivo. No busca por Id. Este método realiza ademas de la busqueda por cada uno de los parámetros de Event, un between entre pEvent.LogDate y pEndDate
         ///para cualquier envento con LogDate entre este rango. 
        /// </summary>
        /// <param name="pEvent">Event como parametro para buscqueda. </param>
        /// <param name="pEndDate">Fecha fin para busqueda.. </param>
        /// <returns></returns>
         public override Events SearchByParam(Event pEvent, DateTime pEndDate)
         {
             Events list = null;
             try
             {
                 list = (Events)Fwk.Logging.Events.GetFromXml<Events>(Fwk.HelperFunctions.FileFunctions.OpenTextFile(FileName));
                 var lisToReturn = from s in list
                                   where
                                       (String.IsNullOrEmpty(pEvent.Machine) || s.Machine.StartsWith(pEvent.Machine))
                                       &&
                                       (String.IsNullOrEmpty(pEvent.User) || s.Machine.StartsWith(pEvent.User))
                                       &&
                                       (pEvent.LogType == EventType.None || s.LogType == pEvent.LogType)
                                       &&
                                       (s.LogDate >= pEvent.LogDate || s.LogDate <= pEvent.LogDate) // Fdesde >= Fecha <= FHasta

                                   select s;
                 Events list2 = new Events();


                 Fwk.HelperFunctions.TypeFunctions.SetEntitiesFromIenumerable<Events, Event>(list2, lisToReturn);

                 list = null;
                 return list2;

             }
             catch (Exception ex)
             {

                 throw ex;

             }
         }
    }
}
