using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Caching;
using System.Net;


namespace Fwk.Net.Ftp
{
    /// <summary>
    /// 
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// cache de <see cref="SocketClient"/> 
        /// </summary>
        public static FwkSimpleStorageBase<SocketClient> storage = new FwkSimpleStorageBase<SocketClient>();

        const string CRLF = "\r\n";



        static ServerFileData ParseDosDirLine(string line)
        {
            ServerFileData sfd = new ServerFileData();


            try
            {
                string[] parsed = new string[3];
                int index = 0;
                int position = 0;

                // Parse out the elements
                position = line.IndexOf(' ');
                while (index < parsed.Length)
                {
                    parsed[index] = line.Substring(0, position);
                    line = line.Substring(position);
                    line = line.Trim();
                    index++;
                    position = line.IndexOf(' ');
                }
                sfd.FileName = line;

                if (parsed[2] != "<DIR>")
                    sfd.Size = Convert.ToInt32(parsed[2]);

                sfd.Date = parsed[0] + ' ' + parsed[1];
                sfd.IsDirectory = parsed[2] == "<DIR>";
            }
            catch
            {
                sfd = null;
            }
            return sfd;
        }


        static ServerFileData ParseUnixDirLine(string line)
        {
            ServerFileData sfd = new ServerFileData();

            try
            {
                string[] parsed = new string[8];
                int index = 0;
                int position;

                // Parse out the elements
                position = line.IndexOf(' ');
                while (index < parsed.Length)
                {
                    parsed[index] = line.Substring(0, position);
                    line = line.Substring(position);
                    line = line.Trim();
                    index++;
                    position = line.IndexOf(' ');
                }
                sfd.FileName = line;

                sfd.Permission = parsed[0];
                sfd.Owner = parsed[2];
                sfd.Group = parsed[3];
                sfd.Size = Convert.ToInt32(parsed[4]);
                sfd.Date = parsed[5] + ' ' + parsed[6] + ' ' + parsed[7];
                sfd.IsDirectory = sfd.Permission[0] == 'd';
            }
            catch
            {
                sfd = null;
            }
            return sfd;
        }

        /// <summary>
        /// Convierte una linea retornada atraves del comando FTP LIST a un objeto tipificado.-
        /// Ejemplo: linea proveniente de un server Unix
        /// -rwxrwxr--   1 andrw    video     3621773 Jan 31  2003 2FOR GOOD - You And Me.MP3
        /// </summary>
        /// <param name="fileLine">Es una linea que retorna de las que retorna el comando LIST</param>
        internal static ServerFileData ParseUnixDirList(string fileLine)
        {

            try
            {

                fileLine = fileLine.Replace("\r", string.Empty);


                ServerFileData sfd = null;
                int autodetect = 0;


                if (autodetect == 0)
                {
                    sfd = ParseDosDirLine(fileLine);
                    if (sfd == null)
                    {
                        sfd = ParseUnixDirLine(fileLine);
                        autodetect = 2;
                    }
                    else
                        autodetect = 1;
                }
                else
                    if (autodetect == 1)
                        sfd = ParseDosDirLine(fileLine);
                    else
                        if (autodetect == 2)
                            sfd = ParseUnixDirLine(fileLine);



                return sfd;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }

    /// <summary>
    /// Representa una linea retornada por el comando LIST. 
    /// </summary>
    public class ServerFileData
    {
        private bool isDirectory;

        /// <summary>
        /// 
        /// </summary>
        public bool IsDirectory
        {
            get { return isDirectory; }
            set { isDirectory = value; }
        }
        private string fileName;

        /// <summary>
        /// 
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        private int size;

        /// <summary>
        /// 
        /// </summary>
        public int Size
        {
            get { return size; }
            set { size = value; }
        }
        private string type;

        /// <summary>
        /// 
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private string date;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        private string permission;

        /// <summary>
        /// 
        /// </summary>
        public string Permission
        {
            get { return permission; }
            set { permission = value; }
        }
        private string owner;

        /// <summary>
        /// 
        /// </summary>
        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        private string group;
        /// <summary>
        /// 
        /// </summary>
        public string Group
        {
            get { return group; }
            set { group = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public ServerFileData()
        {
        }
    }

    public class UploadData
    {
        
        string _Message;

        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        FTPComponent _ftpComponent;

        public FTPComponent FtpComponent
        {
            get { return _ftpComponent; }
            set { _ftpComponent = value; }
        }
    }

}