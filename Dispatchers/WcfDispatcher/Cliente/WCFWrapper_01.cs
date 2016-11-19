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
    /// Wrapper espesializado para una conexión a travez de RemotingConfiguration
    /// </summary>
    [Serializable]
    public class WCFWrapper_01 : WCFRrapperBase<NetTcpBinding>
    {
        public override TResponse ExecuteService<TRequest, TResponse>(TRequest req)
        {
            return base.ExecuteService<TRequest, TResponse>(req);

          
        }
        /// <summary>
        /// 
        /// </summary>
        public override void InitilaizeBinding()
        {
            if (binding == null)
            {
                //El tamaño de los mensajes que se pueden recibir durante la conexión a los servicios mediante BasicHttpBinding
                this.binding = new NetTcpBinding();

                binding.Name = "tcp";
                binding.MaxReceivedMessageSize = System.Int32.MaxValue;
                binding.MaxBufferSize *= factorSize;
                //openTimeout as the name implies is the amount of time you're willing to wait when you open the connection to your WCF service.
                //closeTimeout is the amount of time when you close the connection (dispose the client proxy) that you'll wait before an exception is thrown
                //binding.CloseTimeout = new TimeSpan(0,0,35);
                //binding.OpenTimeout = new TimeSpan(0, 0, 35);
                //specify how long the client will wait for a RESPONSE from WCF-Service
                //in this case it wait 10 min
                binding.SendTimeout = new TimeSpan(0, 0, 5);
                //receiveTimeout is a bit like a mirror for the sendTimeout. Is the amount of time you'll give you client to receive and process the response from the server.
                binding.ReceiveTimeout = new TimeSpan(0, 0, 5);
                binding.MaxBufferPoolSize *= factorSize;
                binding.ReaderQuotas.MaxDepth = System.Int32.MaxValue;
                binding.ReaderQuotas.MaxNameTableCharCount = System.Int32.MaxValue;
                binding.ReaderQuotas.MaxStringContentLength = System.Int32.MaxValue;
                binding.ReaderQuotas.MaxArrayLength = System.Int32.MaxValue;
                binding.ReaderQuotas.MaxBytesPerRead = System.Int32.MaxValue;
                address = new EndpointAddress(this.SourceInfo);
            }
        }
    }
}
