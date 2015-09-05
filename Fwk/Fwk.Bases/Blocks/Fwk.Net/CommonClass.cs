using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Net
{
    /// <summary>
    /// Clase generica que representa la data de coneccion a cualquier socket
    /// </summary>
    [Serializable]
    public class SocketClient
    {
        string password;
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        string user;
        /// <summary>
        /// 
        /// </summary>
        public string User
        {
            get { return user; }
            set { user = value; }
        }
        string _Server;
        /// <summary>
        /// 
        /// </summary>
        public string Server
        {
            get { return _Server; }
            set { _Server = value; }
        }
        string _Port;
        /// <summary>
        /// 
        /// </summary>
        public string Port
        {
            get { return _Port; }
            set { _Port = value; }
        }



    }
}
