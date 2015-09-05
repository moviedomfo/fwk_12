using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fwk.Bases.Blocks.Fwk.BusinessFacades
{
    public class HostContext
    {
        private string _HostName;
        private string _HostIP;

        /// <summary>
        /// Indica el host que inicio la peticion del servicio .-
        /// </summary>
        public string HostName
        {
            get { return _HostName; }
            set { _HostName = value; }
        }

        /// <summary>
        /// Indica la IP del host que inicio la peticion del servicio .-
        /// </summary>
        public string HostIp
        {
            get { return _HostIP; }
            set { _HostIP = value; }
        }
    }
}
