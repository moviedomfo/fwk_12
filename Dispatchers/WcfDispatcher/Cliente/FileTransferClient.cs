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
using Cliente.FwkFileTransfer;

namespace Cliente
{
    public class FileTransfer
    {
        NetTcpBinding binding = null;
        EndpointAddress address = null;
        FileTransferClient svcProxy = null;
        JsonSerializerSettings settings = null;

        public  UploadFileResponse UploadFile(UploadFileRequest req)
        {
            InitHost();
            UploadFileResponse res= null;
            if (svcProxy == null)
            {
                svcProxy = new FileTransferClient(binding, address);
                svcProxy.Open();
         
            }
            res = svcProxy.UploadFile(req);
            return res;
        }
        public DownloadFileResponse DownloadFile(DownloadFileRequest req)
        {
            InitHost();
            DownloadFileResponse res = null;
            if (svcProxy == null)
            {
                svcProxy = new FileTransferClient(binding, address);
                svcProxy.Open();

            }
            res = svcProxy.DownloadFile(req);
            return res;
        }
         string _URL = string.Empty;
        public string SourceInfo
        {
            get { return _URL; }
            set { _URL = value; }
        }
        const int factorSize = 5;
         void InitHost()
        {
            
            if (binding == null)
            {
                //El tamaño de los mensajes que se pueden recibir durante la conexión a los servicios mediante BasicHttpBinding
                this.binding = new NetTcpBinding();

                binding.Name = "tcp";
                binding.TransferMode = TransferMode.Streamed;
                binding.MaxReceivedMessageSize *= factorSize;
                binding.MaxBufferSize *= factorSize;
                binding.MaxBufferPoolSize *= factorSize;
                binding.ReaderQuotas.MaxStringContentLength = 2147483647;
                binding.ReaderQuotas.MaxArrayLength = 2147483647;
                binding.ReaderQuotas.MaxBytesPerRead = 2147483647;
                address = new EndpointAddress(_URL);
            }
        }

    }
}
