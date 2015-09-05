using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace CentralizedSecurity.wcf.Contracts
{
    [DataContract]
    public class LoogonUserResult
    {
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public string LogResult { get; set; }
        [DataMember]
        public bool Autenticated { get; set; }
    }


}
