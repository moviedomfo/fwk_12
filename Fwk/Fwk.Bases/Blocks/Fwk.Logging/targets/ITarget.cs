using System;
using System.Collections.Generic;
namespace Fwk.Logging.Targets
{
    /// <summary>
    /// Interfaz comun a todos los <see cref="Target"/> de logueo del fwk.-
    /// </summary>
    public interface ITarget
    {
        /// <summary>
        /// Busca eventos bajo los parametros indicadosdesde el origen de datos 
        /// que puede ser un Xml o una bas d edatos .-
        /// No es aplicable a eventos provenientes de visor de evento
        /// </summary>
        /// <param name="pEvent">Event como parametro de filtros</param>
        /// <returns>Lista de eventos</returns>
        Events SearchByParam(Fwk.Logging.Event pEvent);
      
        /// <summary>
        /// Tipo de evento
        /// </summary>
        /// <returns><see cref="TargetType"/></returns>
        Fwk.Logging.Targets.TargetType Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEvent"></param>
        void Write(Fwk.Logging.Event pEvent);
        /// <summary>
        /// Busca eventos bajo los parametros indicadosdesde el origen de datos 
        /// que puede ser un Xml o una bas d edatos .-
        /// No es aplicable a eventos provenientes de visor de evento
        /// </summary>
        /// <param name="pEvent">Event como parametro de filtros</param>
        /// <param name="pEndDate">Fecha limite de fin de busqueda</param>
        /// <returns>Lista de eventos</returns>
        Events SearchByParam(Fwk.Logging.Event pEvent, DateTime pEndDate);

        /// <summary>
        /// Elimina del origen de logueo una lista de eventos por medio de su guid
        /// </summary>
        /// <param name="eventIdList">Lista de guids de los eventos a eliminar</param>
        void Remove(List<string> eventIdList);

        /// <summary>
        /// Elimina del origen de logueo una lista de eventos por medio de su guid
        /// </summary>
        /// <param name="eventIdList">Lista de guids de los eventos a eliminar</param>
        void Remove(List<Guid> eventIdList);
    }
}
