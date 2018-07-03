using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Drawing;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

namespace Fwk.Net.Ftp
{
    public delegate void DebugHandler(string msg);
    public delegate void ErrorHandler(Exception ex);
    public delegate void ObjectHandler(object sender, Exception ex);
    

    public delegate void FileListResivedHandler(string mask, String[] files, Exception ex);

    public delegate void ObjectHandlerAsync(out Exception ex);
    public delegate void FileListResivedHandlerAsync(string mask, out String[] files, out Exception ex);

    /// <summary>
    /// Componente cliente FTP 
    /// </summary>
    /// <param name="dir">Directorio remoto</param>
    /// <param name="destPath">Directorio local</param>
    /// <param name="recursive">Aplica recursividad para descarga</param>
    /// <param name="ex">Error en caso de que se porduzca</param>
    public delegate void DowloadAllDirHandlerAsync(string dir, out string destPath,bool recursive, out Exception ex);
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(FTPComponent), "Resources.db5.png")]
    public partial class FTPComponent : Component
    {
        #region events
        public event DebugHandler OnDebugEvent;
        public event ErrorHandler OnErrorEvent;
        public event ObjectHandler OnCloseEvent;
        public event ObjectHandler OnLoginEvent;
        public event ObjectHandler OnUploadEvent;
        /// <summary>
        /// Evento que se lanza cundo se finaliza BeginDowloadAllDirAsync
        /// </summary>
        public event ObjectHandler EndDowloadAllDirEvent;
        public event FileListResivedHandler OnFileListResivedEvent;


     

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        void SendDebug(string msg)
        {
            if (debug)
                if (OnDebugEvent != null)
                    OnDebugEvent(msg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        void SendErrorEvent(Exception e)
        {
            if (OnErrorEvent != null)
                OnErrorEvent(e);
        }
        #endregion

        #region properties
        private char[] seperator = { '\n' };
        private string ftpServer=string.Empty;
        private string mes;

        private string ftpUser = "anonymous";
        private string ftpPath = ".";
        private string ftpPass = string.Empty;
        private int ftpPort = 21;
        private int bytes;
        private int retValue;
        private Boolean debug = false;
        private Boolean logined;

        //[Browsable(false)]
        //public Boolean Logined
        //{
        //    get { return logined; }
        //    set { logined = value; }
        //}
        private string reply;
        Byte[] buffer = new Byte[512];
        private Socket clientSocket;
        /// <summary>
        /// Password para conectarce al servidor ftp.- Si es anonymous, no se establece este valor
        /// </summary>
        [Browsable(true)]
        [Category("Fwk.factory"), Description("Password para conectarce al servidor ftp.- Si es anonymous, no se establece este valor")]
        public string FTPPass
        {
            get { return ftpPass; }
            set { ftpPass = value; }
        }
        /// <summary>
        /// Usuario ftp.- Por defecto es anonymous
        /// </summary>
        [Browsable(true)]
        [Category("Fwk.factory"),  Description("Usuario ftp.- Por defecto es anonymous")]
        public string FTPUser
        {
            get { return ftpUser; }
            set { ftpUser = value; }
        }
        /// <summary>
        /// Ruta del servidor remoto
        /// </summary>
        [Browsable(true)]
        [Category("Fwk.factory"),  Description("Ruta del servidor remoto")]
        public string FTPPath
        {
            get { return ftpPath; }
            set { ftpPath = value; }
        }

        /// <summary>
        /// Direccion IP o Nombre del servidor remoto de ftp.- 
        /// </summary>
        [Browsable(true)]
        [Category("Fwk.factory"),  Description("Direccion IP o Nombre del servidor remoto de ftp.- ")]
        public string FTPServer
        {
            get { return ftpServer; }
            set { ftpServer = value; }
        }


        /// <summary>
        /// Puerto ftp del server remoto, en general es 21
        /// </summary>
        [Browsable(true)]
        [Category("Fwk.factory"),  Description("Puerto ftp del server remoto, en general es 21")]
        public int FTPPort
        {
            get { return ftpPort; }
            set { ftpPort = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        [Browsable(true)]
        [Category("Fwk.factory"), DefaultValue(false), Description("")]
        public Boolean Debug
        {
            get { return debug; }
            set { debug = value; }
        }


        #endregion

        /// <summary>
        /// 
        /// </summary>
        public FTPComponent()
        {
            InitializeComponent();
            logined = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public FTPComponent(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            logined = false;
        }

        #region  Files
        /// <summary>
        /// Comienza a recivir archivos
        /// </summary>
        /// <param name="mask">Filtro ej *.*</param>
        public void BeginGetFileListAsync(string mask)
        {
            Exception ex = null;
            String[] mess = null;
            FileListResivedHandlerAsync x = new FileListResivedHandlerAsync(GetFileList);
            x.BeginInvoke(mask, out mess, out ex, new AsyncCallback(EndGetFileListAsync), null);
        }
        void EndGetFileListAsync(IAsyncResult res)
        {
            AsyncResult result = (AsyncResult)res;
            Exception ex;
            String[] mess = null;
            FileListResivedHandlerAsync del = (FileListResivedHandlerAsync)result.AsyncDelegate;
            del.EndInvoke(out mess, out ex, res);

            //mess = (String[])del.Method.ReturnParameter.DefaultValue;
            if (OnFileListResivedEvent != null)
                OnFileListResivedEvent(this.ftpPath, mess, ex);
        }
        void GetFileList(string mask, out String[] files, out Exception ex)
        {
            ex = null;
            files = null;
            try
            {
                files = GetFileList(mask);
            }
            catch (Exception err)
            {
                err.Source = "Origen de datos";
                ex = err;
            }

        }

        /// <summary>
        /// Retorna un string[] con la lista de arhivos remotos.-
        /// </summary>
        /// <param name="mask"></param>
        /// <returns></returns>
        public string[] GetFileList(string mask)
        {
            if (!logined)
            {
                Conect();
            }
            Socket cSocket = CreateDataSocket();

            SendCommand("LIST ");

            //SendCommand("NLST " + mask);

            if (!(retValue == 150 || retValue == 125))
               throw new IOException(reply.Substring(4));
            

            mes = string.Empty;

            while (true)
            {
                int bytes = cSocket.Receive(buffer, buffer.Length, 0);
                mes += Encoding.ASCII.GetString(buffer, 0, bytes);
                if (bytes == 0)
                    break;
            }

            string[] mess = mes.Split(seperator);

            cSocket.Close();

            ReadReply();

            if (retValue != 226)
            {
                throw new IOException(reply.Substring(4));

            }
            return mess;


        }

        /// <summary>
        /// Retorna el tamaño de un archivo que se encuentra en la ruta actual
        /// </summary>
        /// <param name="fileName">Nombre del archivo remoto</param>
        /// <returns>long : tamaño del del archivo</returns>
        public long GetFileSize(string fileName)
        {

            if (!logined)
            {
                Conect();
            }

            SendCommand("SIZE " + fileName);
            long size = 0;

            if (retValue == 213)
            {
                size = Int64.Parse(reply.Substring(4));
            }
            else
            {
                SendErrorEvent(new IOException(reply.Substring(4)));

            }

            return size;

        }

        

        #region Download

        /// <summary>
        /// Comienza la descarga de forma asincrona
        /// </summary>
        /// <param name="dir">Directorio remoto</param>
        /// <param name="destPath">Directorio local</param>
        /// <param name="recursive">Recursividad</param>
        public void BeginDowloadAllDirAsync(string dir, string destPath, bool recursive)
        {
            Exception ex = null;
            DowloadAllDirHandlerAsync x = new DowloadAllDirHandlerAsync(DowloadAllDir);
            x.BeginInvoke(dir,out destPath,recursive, out ex, new AsyncCallback(EndDowloadAllDirAsync), null);
        }

        /// <summary>
        /// fin de la descarga completa del directorio
        /// Fin de DowloadAllDirAsync
        /// </summary>
        /// <param name="res"></param>
         void EndDowloadAllDirAsync(IAsyncResult res)
        {
            AsyncResult result = (AsyncResult)res;
            Exception ex;
            string destPath;
            DowloadAllDirHandlerAsync del = (DowloadAllDirHandlerAsync)result.AsyncDelegate;
            del.EndInvoke(out destPath,out ex, res);

       
            if (EndDowloadAllDirEvent != null)
                EndDowloadAllDirEvent(destPath, ex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="destPath"></param>
        /// <param name="recursive"></param>
        /// <param name="ex"></param>
        void DowloadAllDir (string dir,out  string destPath,bool recursive,out Exception ex)
        {
            ex = null;
             destPath=null;
            try
            {
                DowloadAllDir(dir,out destPath,recursive,out ex);
            }
            catch (Exception err)
            {
                ex = err;
            }
        }
        public void DowloadAllDir(string dir, string destPath,bool recursive)
        {
            if (!logined)
                Conect();

            if (!System.IO.Directory.Exists(destPath))
                System.IO.Directory.CreateDirectory(destPath);
            //if(!dir.Equals(this.FTPPath))
                

            //busco todos los archivos y carpetas del directorio
            string[]  files = GetFileList("*.*");
            List<ServerFileData> wServerFileDataList = ParseLSTCommandResponse(files);

            #region bajo todos los archivos primero
            IEnumerable<ServerFileData> filesList = from f in wServerFileDataList where f.IsDirectory == false select f;

            foreach (ServerFileData d in filesList)
            {
                if (d != null)
                      Download(d.FileName, System.IO.Path.Combine(destPath, d.FileName));
                    
            }
            #endregion
            if (recursive)
            {
                IEnumerable<ServerFileData> dirLis = from f in wServerFileDataList where f.IsDirectory select f;
                foreach (ServerFileData d in dirLis)
                {
                    if (d != null)
                    {
                        //dir = System.IO.Path.GetDirectoryName(dir);
                        ChangeDir(d.FileName);
                        DowloadAllDir(d.FileName, System.IO.Path.Combine(destPath, d.FileName), recursive);
                    }

                }
                //suvo un nivel
                //Change the remote machine working directory to the parent of		 the current remote machine working directory
                SendCommand("CDUP");
                //if (retValue != 350)
                //{
          
                //}
            
            }
        }

        /// <summary>
        /// Descarga el archivo remoto. 
        /// </summary>
        /// <param name="remFileName">Nombre del archivo remoto</param>
        /// <param name="fullLocalFileName">Nombre del archivo destino, Ruta+Nombre La ruta debe existir y el archivo sera creado.</param>
        public void Download(string remFileName, string fullLocalFileName)
        {
            Download(remFileName, fullLocalFileName, false);
        }



        /// <summary>
        /// Descarga el archivo remoto, el archivo sera creado o sobreescrito
        /// <summary>
        /// <param name="remFileName">Nombre del archivo remoto</param>
        /// <param name="fullLocalFileName">Nombre del archivo destino, Ruta+Nombre
        /// La ruta debe existir y el archivo sera creado o sobreescrito.</param>param>
        /// <param name="resume">Llama al comando REST: Reiniciar cargas y descargas de FTP y despues RETR
        /// Las descargas se pueden reiniciar emitiendo primero un comando rest con el desplazamiento deseado y, 
        /// a continuación, emitiendo el comando retr.
        /// </summary>
        /// <param name="remFileName"></param>
        /// <param name="fullLocalFileName"></param>
        /// <param name="resume"></param>
        public void Download(string remFileName, string fullLocalFileName, Boolean resume)
        {


            if (!logined)
            {
                Conect();
            }

            SetBinaryMode(true);

            SendDebug(string.Concat("Downloading file ", remFileName, " from ", ftpServer, "/", ftpPath));

            if (fullLocalFileName.Equals(string.Empty))
            {
                fullLocalFileName = remFileName;
            }

            if (!File.Exists(fullLocalFileName))
            {
                Stream st = File.Create(fullLocalFileName);
                st.Close();
            }

            FileStream output = new FileStream(fullLocalFileName, FileMode.Open);

            Socket cSocket = cSocket = CreateDataSocket(); 
          
            long offset = 0;

            if (resume)
            {
                offset = output.Length;
                if (offset > 0)
                {
                    SendCommand("REST " + offset);
                    if (retValue != 350)
                    {
                        offset = 0;
                    }
                }
                if (offset > 0)
                {
                    if (debug)
                    {
                        SendDebug("seeking to " + offset);
                    }
                    long npos = output.Seek(offset, SeekOrigin.Begin);
                }
            }

           
            SendCommand("RETR " + remFileName);
             

            if (!(retValue == 150 || retValue == 125))
            {
   
                SendErrorEvent(new IOException(reply.Substring(4)));
                throw new IOException(reply.Substring(4));
            }

            while (true)
            {

                bytes = cSocket.Receive(buffer, buffer.Length, 0);
                output.Write(buffer, 0, bytes);

                if (bytes <= 0)
                {
                    break;
                }
            }

            output.Close();
            if (cSocket.Connected)
            {
                cSocket.Close();
            }

            ReadReply();

            if (!(retValue == 226 || retValue == 250))
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
                throw new IOException(reply.Substring(4));
            }
 
                SendDebug(string.Concat("File ",remFileName," must successfully downloaded from ",ftpServer ,"/", ftpPath));
        }

        #endregion

        #region Upload
        /// <summary>
        /// Sube un archivo al servidor remoto.-
        /// </summary>
        /// <param name="fileName">Nombre del archivo a subir</param>
        public void Upload(string fileName)
        {
            Upload(fileName, false);
        }

        /// <summary>
        /// Sube un archivo al servidor remoto.-
        /// </summary>
        /// <param name="fileName">Nombre del archivo a subir</param>
        /// <param name="resume">Llama al comando REST: Reiniciar cargas y descargas de FTP y despues RETR
        /// Las descargas se pueden reiniciar emitiendo primero un comando rest con el desplazamiento deseado y, 
        /// a continuación, emitiendo el comando retr.
        /// </param>
        public void Upload(string fileName, Boolean resume)
        {

            if (!logined)
            {
                Conect();
            }
            Socket cSocket = null;
            try
            {
                cSocket = CreateDataSocket();
            }
            catch (IOException ex)
            {
             
                SendErrorEvent(ex);
                throw ex;
            }
            long offset = 0;

            if (resume)
            {

                try
                {
                    SetBinaryMode(true);
                    offset = GetFileSize(fileName);
                }
                catch (Exception)
                {
                    offset = 0;
                }
            }

            if (offset > 0)
            {
                SendCommand("REST " + offset);
                if (retValue != 350)
                {
                    //throw new IOException(reply.Substring(4));
                    offset = 0;
                }
            }

            SendCommand("STOR " + Path.GetFileName(fileName));

            if (!(retValue == 125 || retValue == 150))
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
                throw new IOException(reply.Substring(4));
               
            }

            // Abre el stream de enrtada para leer el archivo de origen
            FileStream input = new FileStream(fileName, FileMode.Open);

            if (offset != 0)
            {
             
                input.Seek(offset, SeekOrigin.Begin);
            }

            SendDebug(string.Concat("Uploading file ", fileName, " to " + ftpPath));

            while ((bytes = input.Read(buffer, 0, buffer.Length)) > 0)
            {

                cSocket.Send(buffer, bytes, 0);

            }
            input.Close();


            if (cSocket.Connected)
            {
                cSocket.Close();
            }

            ReadReply();
            if (!(retValue == 226 || retValue == 250))
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
                throw new IOException(reply.Substring(4));
            }
    

            SendDebug(string.Concat("File ", fileName, " must successfully uploaded to ", ftpServer, "/", ftpPath));
            if (OnUploadEvent != null)
            {
                UploadData data = new UploadData();
                data.FtpComponent = this;
                data.Message = string.Concat("File ", fileName, " must successfully uploaded to ", ftpServer, "/", ftpPath);
                OnUploadEvent(data, null);
            }
        }

        #endregion

        /// <summary>
        /// elimina un archivo
        /// </summary>
        /// <param name="fileName">Archivo a eliminar</param>
        public void DeleteRemoteFile(string fileName)
        {

            if (!logined)
            {
                Conect();
            }

            SendCommand("DELE " + fileName);

            if (retValue != 250)
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
                throw new IOException(reply.Substring(4));
            }
           
            SendDebug(string.Concat("File ", fileName, " must successfully removed from ", ftpServer, "/", ftpPath));
        }


        /// <summary>
        /// Renombrado de archivo en el servidor remoto
        /// </summary>
        /// <param name="oldFileName">Nombre viejo del archivo</param>
        /// <param name="newFileName">Nuevo nombre</param>
        public void RenameRemoteFile(string oldFileName, string newFileName)
        {

            if (!logined)
            {
                Conect();
            }

            SendCommand("RNFR " + oldFileName);

            if (retValue != 350)
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
                throw new IOException(reply.Substring(4));
            }

            //  known problem
            //  rnto will not take care of existing file.
            //  i.e. It will overwrite if newFileName exist
            SendCommand("RNTO " + newFileName);
            if (retValue != 250)
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
                throw new IOException(reply.Substring(4));
            }

            SendDebug(string.Concat("File ", oldFileName, " must successfully renamed to ", newFileName, " on ", ftpServer, "/", ftpPath));


        }
        #endregion

        #region Connect & close
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cb"></param>
        public void BeginConnectAsync(ObjectHandler cb)
        {
            Exception ex = null;
            ObjectHandlerAsync x = new ObjectHandlerAsync(Conect);
            x.BeginInvoke(out ex, new AsyncCallback(EndConnectAsync), cb);

        }
        public void BeginConnectAsync()
        {
            Exception ex = null;
            ObjectHandlerAsync x = new ObjectHandlerAsync(Conect);
            x.BeginInvoke(out ex, new AsyncCallback(EndConnectAsync), null);

        }
        void EndConnectAsync(IAsyncResult res)
        {
            AsyncResult result = (AsyncResult)res;

            Exception ex;
            //ObjectHandler d = (ObjectHandler)res.AsyncState;
            ObjectHandlerAsync del = (ObjectHandlerAsync)result.AsyncDelegate;
            del.EndInvoke(out ex, res);
            //if (d != null)
            //    d.Invoke(this, ex);
            //else
            if (OnLoginEvent != null)
                OnLoginEvent(this, ex);
        }

        void Conect(out Exception ex)
        {
            ex = null;
            try
            {
                Conect();
            }
            catch (Exception err)
            {
                err.Source = "Origen de datos";
                ex = err;
            }
        }

        /// <summary>
        /// Se concta al servidor remoto
        /// </summary>
        public void Conect()
        {
            if (string.IsNullOrEmpty(ftpServer))
                throw new IOException("El valor FTPServer no puede ser nulo");
            if (ftpPort == 0)
                ftpPort = 21;
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(Dns.GetHostEntry(ftpServer).AddressList[0], ftpPort);

        
            clientSocket.Connect(ep);
           

            ReadReply();
            if (retValue != 220)
            {
                Close();
                SendErrorEvent(new IOException(reply.Substring(4)));
                throw new IOException(reply.Substring(4));
            }


            SendCommand("USER " + ftpUser);

            if (!(retValue == 331 || retValue == 230))
            {
                Cleanup();
                SendErrorEvent(new IOException(reply.Substring(4)));
                throw new IOException(reply.Substring(4));
            }

            if (retValue != 230)
            {

                SendCommand("PASS " + ftpPass);
                if (!(retValue == 230 || retValue == 202))
                {
                    Cleanup();
                    SendErrorEvent(new IOException(reply.Substring(4)));
                    throw new IOException(reply.Substring(4));
                }
            }

            logined = true;
            SendDebug("Connected to " + ftpServer);
            ChangeDir(ftpPath);

        }

        /// <summary>
        /// Cierra la conexion FTP.-
        /// </summary>
        public void Close()
        {
            if (clientSocket != null)
            {
                SendCommand("QUIT");
            }
            Cleanup();
            SendDebug("Closing...");
        }
        #endregion


        /// <summary>
        /// True = modo bunario para descargas
        /// False, Modo Ascii para descargas.
        /// </summary>
        /// <param name="mode">true o false</param>
        public void SetBinaryMode(Boolean mode)
        {
            if (mode)
                SendCommand("TYPE I");
            else
                SendCommand("TYPE A");

            if (retValue != 200)
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
                throw new IOException(reply.Substring(4));
            }

        }

        #region Directories
        /// <summary>
        /// Crea un directorio en el servidor remoto
        /// </summary>
        /// <param name="dirName">directorio romoto crear</param>
        public void CreateDir(string dirName)
        {

            if (!logined)
            {
                Conect();
            }

            SendCommand("MKD " + dirName);

            if (retValue != 250)
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
                throw new IOException(reply.Substring(4));
            }

        }

        /// <summary>
        /// Elimina un directorio en el servidor remoto
        /// </summary>
        /// <param name="dirName">Directorio remoto a eliminar</param>
        public void RemoveDir(string dirName)
        {

            if (!logined)
            {
                Conect();
            }

            SendCommand("RMD " + dirName);

            if (retValue != 250)
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
                throw new IOException(reply.Substring(4));
            }
        }

        /// <summary>
        /// Cambia el actual directorio en el servidor remoto
        /// </summary>
        /// <param name="dirName">Nombre del directorio al que se quiere cambiar</param>
        public void ChangeDir(string dirName)
        {
            if (dirName.Equals("."))
                return;

            if (!logined)
                Conect();

            SendCommand("CWD " + dirName);

            if (retValue != 250)
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
                throw new IOException(reply.Substring(4));
            }

            this.ftpPath = GetCurrentDir();

        }

        /// <summary>
        /// Obtiene la ruta actual
        /// </summary>
        /// <returns></returns>
        private string GetCurrentDir()
        {
            SendCommand("PWD");
            if (retValue != 257)
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
                throw new IOException(reply.Substring(4));
            }

            string currentPath = (mes.Split(' ')[1]).Replace("\"", String.Empty);
            return currentPath;
        }

        [Obsolete("NO USAR: METODO en ENDESARROLLO")]
        public void Chdir_cn(string dirName)
        {
            if (dirName.Equals("."))
                return;

            if (!logined)
                Conect();

            dirName = dirName.Replace(@"\",@"/");
            SendCommand("CWD " + dirName);

            if (retValue != 250)
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
                throw new IOException(reply.Substring(4));
            }
            
            this.ftpPath = dirName;

        }
        #endregion

        #region private methods

        /// <summary>
        /// Calcula
        /// retValue
        /// mes
        /// reply
        /// </summary>
        private void ReadReply()
        {
            mes = string.Empty;
            reply = ReadLine();
            retValue = Int32.Parse(reply.Substring(0, 3));
        }

        /// <summary>
        /// Cierra el socket. Es decir la conexion con el server FTP
        /// </summary>
        private void Cleanup()
        {
            if (clientSocket != null)
            {
                clientSocket.Close();
                clientSocket = null;
            }
            logined = false;
            if (OnCloseEvent != null)
                OnCloseEvent(this, null);
        }

        /// <summary>
        /// Lee el buffer del socket del cliente.- 
        /// </summary>
        /// <returns></returns>
        private string ReadLine()
        {
            while (true)
            {
                bytes = clientSocket.Receive(buffer, buffer.Length, 0);
                mes += Encoding.ASCII.GetString(buffer, 0, bytes);
                if (bytes < buffer.Length)
                {
                    break;
                }
            }
            string[] mess = mes.Split(seperator);

            if (mes.Length > 2)
            {
                mes = mess[mess.Length - 2];
            }
            else
            {
                mes = mess[0];
            }

            if (!mes.Substring(3, 1).Equals(" "))
            {
                return ReadLine();
            }

            return mes;
        }

        /// <summary>
        /// Envia un comando FTP
        /// </summary>
        /// <param name="command"></param>
        private void SendCommand(String command)
        {

            Byte[] cmdBytes = Encoding.ASCII.GetBytes((command + "\r\n").ToCharArray());
            clientSocket.Send(cmdBytes, cmdBytes.Length, 0);
            ReadReply();
        }

        /// <summary>
        /// Crea el socket FTP al puerto 21
        /// </summary>
        /// <returns></returns>
        private Socket CreateDataSocket()
        {

            SendCommand("PASV");

            if (retValue != 227)
                throw new IOException(reply.Substring(4));
            

            int index1 = reply.IndexOf('(');
            int index2 = reply.IndexOf(')');
            string ipData = reply.Substring(index1 + 1, index2 - index1 - 1);
            int[] parts = new int[6];

            int len = ipData.Length;
            int partCount = 0;
            string buf = string.Empty;

            for (int i = 0; i < len && partCount <= 6; i++)
            {
                char ch = Char.Parse(ipData.Substring(i, 1));

                if (Char.IsDigit(ch))
                    buf += ch;
                else if (ch != ',')
                    throw new IOException(string.Concat("Malformed PASV reply: " + reply));
                

                if (ch == ',' || i + 1 == len)
                {
                    try
                    {
                        parts[partCount++] = Int32.Parse(buf);
                        buf = string.Empty;
                    }
                    catch (Exception)
                    {
                        throw new IOException(string.Concat("Malformed PASV reply: " + reply));
                    }
                }
            }

            string ipAddress = string.Concat(parts[0], ".", parts[1] + ".", parts[2] + ".", parts[3]);

            int port = (parts[4] << 8) + parts[5];
            
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(Dns.GetHostEntry(ipAddress).AddressList[0], port);

            try
            {
                s.Connect(ep);
            }
            catch (Exception ex)
            {
                throw new IOException(string.Concat("Can't connect to remote server " + ex.Message));


            }

            return s;
        }
        #endregion

        /// <summary>
        /// Retorna una lista de ServerFileData parseada de una lista LSTI
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<ServerFileData> ParseLSTCommandResponse(String[] list)
        {

            List<ServerFileData> listServerFileData = new List<ServerFileData>();
             ServerFileData d =null;
            foreach (string file in list)
            {
                if (!String.IsNullOrEmpty(file))
                {
                    d = Util.ParseUnixDirList(file);
                    listServerFileData.Add(d);
                }
            }

            return listServerFileData;
        }
    }
}
