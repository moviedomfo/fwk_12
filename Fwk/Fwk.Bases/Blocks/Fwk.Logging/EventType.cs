using System;
using System.Collections.Generic;
using System.Text;

namespace Fwk.Logging
{
    /// <summary>
    /// Tipo de evento (Event).
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public enum EventType
    {
      
        /// <summary>
        /// Representa mensajes de información.
        /// </summary>
        Information,
        /// <summary>
        /// Representa mensajes de advertencia.
        /// </summary>
        Warning,
        /// <summary>
        /// Representa mensajes de error.
        /// </summary>
        Error,
        /// <summary>
        /// Representa la ausencia de tipo de evento.
        /// </summary>
        None,
        /// <summary>
        /// Representa la ausencia de tipo de evento.
        /// </summary>
        Audit
    }
}
