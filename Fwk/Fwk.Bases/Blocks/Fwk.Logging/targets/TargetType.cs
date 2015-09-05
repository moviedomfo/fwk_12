using System;
using System.Collections.Generic;
using System.Text;

namespace Fwk.Logging.Targets
{
    /// <summary>
    /// Tipo de destino.
    /// </summary>
    public enum TargetType
    {
        /// <summary>
        /// Representa un archivo .log.
        /// </summary>
        File,
        /// <summary>
        /// Representa un archivo .Xml.
        /// </summary>
        Xml,
        /// <summary>
        /// Representa una base de datos.
        /// </summary>
        Database,
        /// <summary>
        /// Representa un evento de Windows.
        /// </summary>
        WindowsEvent,
        /// <summary>
        /// Representa una Consola.
        /// </summary>
        //Console,
        /// <summary>
        /// Representa la ausencia del tipo de destino.
        /// </summary>
        None
    }
}
