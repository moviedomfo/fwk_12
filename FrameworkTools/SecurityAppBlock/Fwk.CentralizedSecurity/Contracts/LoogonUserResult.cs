using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fwk.CentralizedSecurity.Contracts
{
    [Serializable]
    public class LoogonUserResult
    {
        public string ErrorMessage { get; set; }
        public string LogResult { get; set; }
        public bool Autenticated { get; set; }
    }


}
