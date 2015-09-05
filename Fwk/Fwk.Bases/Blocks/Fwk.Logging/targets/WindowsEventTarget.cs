using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;

namespace Fwk.Logging.Targets
{
    /// <summary>
    /// Destino de tipo visor de sucesos de Windows.
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public class WindowsEventTarget : Target
    {
        #region <constructor>
        /// <summary>
        /// Constructor de WindowsEventTarget.
        /// </summary>
        public WindowsEventTarget()
        {
            this.Type = TargetType.WindowsEvent;
        }
        #endregion

        #region <public overrides>
        /// <summary>
        /// Implementación de la escritura del log del evento
        /// en el visor de sucesos de Windows.
        /// </summary>
        /// <param name="pEvent">Evento a loguear.</param>
        public override void Write(Event pEvent)
        {
            if (string.IsNullOrEmpty(pEvent.Source))
                pEvent.Source = "Fwk.Logging.Targets";
            EventLog.WriteEntry(pEvent.Source, pEvent.ToString(), GetWindowsEventType(pEvent.LogType));
        }

        /// <summary>
        /// No se implementa SearchByParam en un evento proveniente del visor de evento de windows
        /// </summary>
        /// <param name="pEvent"></param>
        /// <returns></returns>
        public override Events SearchByParam(Event pEvent)
        {
            throw new NotImplementedException("No se implementa SearchByParam en un evento de windows. Utilice para ello la herramienta WindowsLogViewer del framework");
        }
        /// <summary>
        /// No se implementa SearchByParam en un evento proveniente del visor de evento de windows
        /// </summary>
        /// <param name="pEvent"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public override Events SearchByParam(Event pEvent, DateTime t)
        {
            throw new NotImplementedException("No se implementa SearchByParam en un evento de windows. Utilice para ello la herramienta WindowsLogViewer del framework");
        }

        /// <summary>
        /// No se implementa Remove en un evento proveniente del visor de evento de windows. Utilice para ello la herramienta WindowsLogViewer del framework
        /// </summary>
        /// <param name="eventIdList"></param>
        public override void Remove(List<string> eventIdList)
        {
            throw new NotImplementedException("No se implementa Remove en un evento  de windows. Utilice para ello la herramienta WindowsLogViewer del framework");
        }

        /// <summary>
        /// No se implementa Remove en un evento proveniente un archivo comun.- Solo de xml y database
        /// </summary>
        /// <param name="eventIdList"></param>
        public override void Remove(List<Guid> eventIdList)
        {
            throw new NotImplementedException("No se implementa Remove en un evento de windows.- Solo de xml y database");
        }
        #endregion

        #region <private methods>
        /// <summary>
        /// Establece una correspondencia entre Fwk.Logging.EventType 
        /// y System.Diagnostics.EventLogEntryType.
        /// </summary>
        /// <param name="pEventType">Fwk.Logging.EventType.</param>
        /// <returns>System.Diagnostics.EventLogEntryType.</returns>
        private EventLogEntryType GetWindowsEventType(EventType pEventType)
        {
            switch (pEventType)
            {
                case EventType.Audit:
                    {
                        return EventLogEntryType.FailureAudit;
                    }
                case EventType.Error:
                case EventType.None:
                    {
                        return EventLogEntryType.Error;
                    }
                case EventType.Information:
                    {
                        return EventLogEntryType.Information;
                    }
                case EventType.Warning:
                    {
                        return EventLogEntryType.Warning;
                    }
            }
            return EventLogEntryType.Error;
        }
        #endregion
       
    }
}
