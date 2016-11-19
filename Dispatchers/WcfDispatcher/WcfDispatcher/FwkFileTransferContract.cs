using Fwk.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfDispatcher.Service
{
    [ServiceContract]
    public interface IFileTransfer
    {
        [OperationContract]
        UploadFileResponse UploadFile(UploadFileRequest fileToPush);

        [OperationContract]
        DownloadFileResponse DownloadFile(DownloadFileRequest fileToGet);
    }

    /// <summary>
    /// Transfer Request Object
    /// </summary>
    ///
    [DataContract]
    public class UploadFileRequest
    {
        [DataMember]
        /// <summary>
        /// Gets or sets File Name
        /// </summary>
        public string FileName { get; set; }

        [DataMember]
        public byte[] Content { get; set; }

        [DataMember]
        public string ServerPath { get; set; }
    }

    /// <summary>
    /// File Response Object
    /// </summary>    
    public class UploadFileResponse
    {
        [DataMember]
        /// <summary>
        /// Gets or sets File Name
        /// </summary>
        public string FileName { get; set; }

        [DataMember]
        /// <summary>
        /// Gets or sets Created at
        /// </summary>
        public DateTime CreateAt { get; set; }


        [DataMember]
        public ServiceError Error { get; set; }

    }

    [DataContract]
    public class DownloadFileRequest
    {
        [DataMember]
        public string FileName { get; set; }
    }
    [DataContract]
    public class DownloadFileResponse
    {
        [DataMember]
        public string FileName { get; set; }
        [DataMember]
        public byte[] Content { get; set; }
        [DataMember]
        public ServiceError Error { get; set; }

    }
}
