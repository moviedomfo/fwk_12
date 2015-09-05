using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentralizedSecurity.W32.Test
{
   [Serializable]
    public class Cache
    {
        public string ProxyUser { get;set;}
        public string ProxyPassword { get; set; }
        public string ProxyDomain { get; set; }

        public string ProxyUrl { get; set; }

        //public int ProxyPort { get; set; }

        public string WCFUser { get; set; }
        public string WCFPassword { get; set; }
        public string WCFDomain { get; set; }

        public bool UseProxy { get; set; }

        public string ProxyAddress { get; set; }


        public string AuthUser { get; set; }
        public string AuthPassword { get; set; }
        public string AuthDomain { get; set; }
    }
}
