using System;
using System.Collections.Generic;
using System.Text;
using Fwk.Bases;
using Fwk.Exceptions;
using System.Runtime.Remoting;
using Fwk.Remoting;
using Fwk.BusinessFacades.Utils;
using Fwk.ConfigSection;
using System.ServiceModel;
using Fwk.Bases.Connector.WCFServiceReference;
using Newtonsoft.Json;

namespace Fwk.Bases.Connector
{
    /// <summary>
    /// Wrapper espesializado para una conexión TCP a NetTcpBinding por defecto
    /// </summary>
    [Serializable]
    public class WCFWrapper_BasicHttpBinding : WCFRrapperBase<BasicHttpBinding>
         
    {
        /// <summary>
        /// Si inicializa BasicHttpBinding
        /// </summary>
        public override void InitilaizeBinding()
        {
            if (binding == null)
            {
                //El tamaño de los mensajes que se pueden recibir durante la conexión a los servicios mediante BasicHttpBinding
                this.binding = new BasicHttpBinding();
                //binding.Security.Mode = BasicHttpSecurityMode.Transport;
                //binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
                binding.Name = "iis";

                binding.MaxReceivedMessageSize = System.Int32.MaxValue;
                //binding.MaxBufferSize *= factorSize;
                //binding.MaxBufferPoolSize *= factorSize;
                binding.ReaderQuotas.MaxStringContentLength = System.Int32.MaxValue;
                binding.ReaderQuotas.MaxArrayLength = System.Int32.MaxValue;
                binding.ReaderQuotas.MaxBytesPerRead = System.Int32.MaxValue;
                address = new EndpointAddress(this.SourceInfo);
            }
        }



   
    }
}
