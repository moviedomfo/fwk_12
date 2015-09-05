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
    /// Wrapper espesializado para una conexión TCP a NetTcpBinding
    /// </summary>
    [Serializable]
    public class WCFWrapper_NetTcpBinding : WCFRrapperBase<NetTcpBinding>
         

    {
        public override TResponse ExecuteService<TRequest, TResponse>(TRequest req)
        {
            return base.ExecuteService<TRequest, TResponse>(req);

            //InitilaizeBinding();

            //req.InitializeHostContextInformation();

            //ExecuteServiceBinRequest wcfReq = new ExecuteServiceBinRequest();
            //ExecuteServiceBinResponse wcfRes = null;

            //wcfReq.req = new  WCFRequet();
            //wcfReq.req.ServiceName = req.ServiceName;
            //wcfReq.req.ProviderName = this.ServiceMetadataProviderName;
            //wcfReq.req.ContextInformation = req.ContextInformation;


            //wcfReq.req.BusinessData = req.IEntity;

            //var channelFactory = new ChannelFactory<IFwkService>(binding, address);

            //IFwkService client = null;
            //try
            //{
            //    client = channelFactory.CreateChannel();
            //    wcfRes = client.ExecuteServiceBin(wcfReq);
            //    ((ICommunicationObject)client).Close();
            //}
            //catch (Exception ex)
            //{
            //    if (client != null)
            //    {
            //        ((ICommunicationObject)client).Abort();
            //    } throw ex;
            //}



            //TResponse response = (TResponse)wcfRes.ExecuteServiceBinResult.BusinessData;

            //response.InitializeHostContextInformation();
            //return response;
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
