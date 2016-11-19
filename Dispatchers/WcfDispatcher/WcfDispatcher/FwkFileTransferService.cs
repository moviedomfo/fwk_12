using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Diagnostics;
using Fwk.Bases.Blocks.Fwk.BusinessFacades;
using System.ServiceModel.Channels;
using System.Net;
using Fwk.BusinessFacades;
using Fwk.Bases;
using System.IO;
using Fwk.Exceptions;


namespace WcfDispatcher.Service
{
     [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Single)]
    public class FwkFileTransferService : IFileTransfer
    {
        /// <summary>
        /// Push File to the client
        /// </summary>
        /// <param name="fileToPush">file you want to Push</param>
        /// <returns>a file transfer Response</returns>
         public UploadFileResponse UploadFile(UploadFileRequest fileToPush)
        {
            UploadFileResponse res = this.CheckFileTransferRequest(fileToPush);
            if (res.Error == null)
            {
                try
                {
                   
                    this.SaveFileStream(System.IO.Path.Combine( fileToPush.ServerPath , fileToPush.FileName), new MemoryStream(fileToPush.Content));

                    return new UploadFileResponse
                    {
                        CreateAt = DateTime.Now,
                        FileName = fileToPush.FileName
                    };
                }
                catch (Exception ex)
                {
                    return new UploadFileResponse
                    {
                        CreateAt = DateTime.Now,
                        FileName = fileToPush.FileName,
                        Error = GetError(ex.Message,"5000")
                    };
                }
            }

            return res;
        }


         public DownloadFileResponse DownloadFile(DownloadFileRequest fileToGet)
         {
             DownloadFileResponse res = CheckFileTransferDownload(fileToGet);

             if (res.Error == null)
             {
                 try
                 {


                     System.IO.File.ReadAllBytes(fileToGet.FileName);

                     return new DownloadFileResponse
                         {
                             FileName = fileToGet.FileName
                         };
                 }
                 catch (Exception ex)
                 {
                     return new DownloadFileResponse
                     {

                         FileName = fileToGet.FileName,
                         Error = GetError(ex.Message, "5000")
                         //Error = GetError(String.Format("The File {0} could Not Be Found", fileToGet.FileName), "5000")
                     };
                 }
             }

             return res;
         }

         

        /// <summary>
        /// Check From file Transfer Object is not null 
        /// and all properties is set
        /// </summary>
        /// <param name="fileToPush">file to check</param>
        /// <returns>File Transfer Response</returns>
         UploadFileResponse CheckFileTransferRequest(UploadFileRequest fileToPush)
         {
             if (fileToPush != null)
             {
                 return new UploadFileResponse
                 {
                     //Error = GetError("UploadFileRequest Can't be Null", "5000")
                     Error = GetError("UploadFileRequest no puede ser nulo", "5000")
                 };
             }

             if (string.IsNullOrEmpty(fileToPush.FileName))
             {
                 return new UploadFileResponse
                 {
                     //Error = GetError("The filename can't be null or empty", "5003")
                     Error = GetError("El nombre del archivo no puede ser nulo o vacio", "5003")
                 };
                
             }
             if (fileToPush.Content != null)
             {
                 return new UploadFileResponse
                 {
                     //Error = GetError("Content File  Can't be Null", "5004")
                     Error = GetError("El contenido del archivo no puede ser nulo", "5004")
                 };
             }
             
             return new UploadFileResponse
             {
                 CreateAt = DateTime.Now,
                 FileName = fileToPush.FileName,

             };

           
         }

         /// <summary>
         /// Check From file Transfer Object is not null 
         /// and all properties is set
         /// </summary>
         /// <param name="fileToGet">file to check</param>
         /// <returns>File Transfer Response</returns>
         DownloadFileResponse CheckFileTransferDownload(DownloadFileRequest fileToGet)
         {
             if (fileToGet != null)
             {
                 return new DownloadFileResponse
                 {
                     //Error = GetError("DownloadFileRequest Can't be Null", "5000")
                     Error = GetError("DownloadFileRequest no puede ser nulo", "5000")
                 };
             }

             if (string.IsNullOrEmpty(fileToGet.FileName))
             {
                 return new DownloadFileResponse
                 {
                     //Error = GetError("The filename can't be null or empty", "5003")
                     Error = GetError("El nombre del archivo no puede ser nulo o vacio", "5003")
                 };

             }

             if (System.IO.File.Exists(fileToGet.FileName) == false)
                 return new DownloadFileResponse
                 {

                     FileName = fileToGet.FileName,
                     //Error = GetError(String.Format("The File {0} could Not Be Found", fileToGet.FileName), "5002")
                     Error = GetError(String.Format("El archivo {0} no se encontro", fileToGet.FileName), "5002")
                 };
         

             return new DownloadFileResponse
             {
                
                 FileName = fileToGet.FileName,

             };


         }
         ServiceError GetError(String message,String errorId)
         {
             ServiceError error = new ServiceError();
             error.Message = message;
             error.ErrorId = "";
             error.Machine = Environment.MachineName;
             error.Type = "TechnicalException";

             return error;
         }

        /// <summary>
        /// Write the Stream in the hard drive
        /// </summary>
        /// <param name="filePath">path to write the file in</param>
        /// <param name="stream">stream to write</param>
         void SaveFileStream(string filePath, Stream stream)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                stream.CopyTo(fileStream);
                fileStream.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
    }
}
