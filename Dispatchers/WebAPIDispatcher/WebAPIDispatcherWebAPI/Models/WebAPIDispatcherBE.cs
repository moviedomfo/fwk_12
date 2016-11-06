using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDispatcher
{
    public class WebAPIDispatcherRes
    {

        public Int32 IDLead { get; set; }


        public String Error { get; set; }
    }
    public class WebAPIDispatcherReq
    {       /// <summary>
            /// url landing   (campo texto)
            /// </summary>
        public String CodigoOrigen { get; set; }
        public String CodigoCampania { get; set; }
        /// <summary>
        /// Texto que explique de qué landing/campaña viene (campo texto tamaño ?)
        /// </summary>
        public String Texto { get; set; }
        public String Fecha { get; set; }
        /// <summary>
        /// Teléfonos en formato ANI
        /// </summary>
        public String Telefonos { get; set; }
        /// <summary>
        ///dentro de horario, 0 fuera de horario
        /// </summary>
        public bool Horario { get; set; }

        public int IDLead { get; set; }
    }
}