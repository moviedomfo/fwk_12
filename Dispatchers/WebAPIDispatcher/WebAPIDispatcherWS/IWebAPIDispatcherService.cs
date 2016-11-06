using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebAPIDispatcherWS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWebAPIDispatcherService" in both code and config file together.
    [ServiceContract]
    public interface IWebAPIDispatcherService
    {

     

        [OperationContract]
        WebAPIDispatcherRes RegistrarLlamada(WebAPIDispatcherReq req);

     
       
        [OperationContract]
        [WebInvoke(UriTemplate = "/RegistrarLlamadaPost",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST", 
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        WebAPIDispatcherRes RegistrarLlamadaPost(WebAPIDispatcherReq req);

    }

    [DataContract]
    public class WebAPIDispatcherRes
    {
        [DataMember]
        public Int32 IDLead { get; set; }

        [DataMember]
        public String Error { get; set; }
    }
    [DataContract]
    public class WebAPIDispatcherReq
        {       /// <summary>
            /// url landing   (campo texto)
            /// </summary>
        [DataMember]
        public String CodigoOrigen { get; set; }
        [DataMember]
        public String CodigoCampania { get; set; }
        /// <summary>
        /// Texto que explique de qué landing/campaña viene (campo texto tamaño ?)
        /// </summary>
        [DataMember]
        public String Texto { get; set; }
        [DataMember]
        public String Fecha { get; set; }
        /// <summary>
        /// Teléfonos en formato ANI
        /// </summary>
        [DataMember]
        public String Telefonos { get; set; }
        /// <summary>
        ///dentro de horario, 0 fuera de horario
        /// </summary>
        [DataMember]
        public bool Horario { get; set; }
    }
  
}
