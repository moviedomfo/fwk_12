using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fwk.Security.ActiveDirectory;
using System.Runtime.Serialization;
namespace CentralizedSecurity.wcf.Contracts
{
    [DataContract]
    public class DomainsUrl
    {
        [DataMember]
        /// <summary>
        /// Nombre de dominio
        /// </summary>
        public string DomainName
        {
            get;
            set;
        }
        [DataMember]
        /// <summary>
        /// Url del dominio
        /// </summary>
        public string LDAPPath
        {
            get;
            set;
        }
        [DataMember]
        /// <summary>
        /// Usuario de impersonalizacion
        /// </summary>
        public string Usr
        {
            get;
            set;
        }

        /// <summary>
        /// Password
        /// </summary>
        [DataMember]
        public string Pwd
        {
            get;
            set;
        }
        [DataMember]
        public int Id
        {
            get;
            set;
        }
        [DataMember]
        public string SiteName
        {
            get;
            set;
        }

        [DataMember]
        public string DomainDN
        {
            get;
            set;
        }

        public DomainsUrl()
        { }
        public DomainsUrl(DomainUrlInfo domainInfo)
        {
            this.DomainDN = domainInfo.DomainDN;
            this.DomainName = domainInfo.DomainName;
            this.LDAPPath = domainInfo.LDAPPath;
            this.Pwd = domainInfo.Pwd;
            this.Usr = domainInfo.Usr;
        }
    }
}
