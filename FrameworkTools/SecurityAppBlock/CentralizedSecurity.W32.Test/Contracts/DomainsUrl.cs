using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fwk.Security.ActiveDirectory;
namespace Fwk.CentralizedSecurity.Contracts
{
    [Serializable]
    public class DomainsUrl
    {

        /// <summary>
        /// Nombre de dominio
        /// </summary>
        public string DomainName
      {
            get; 
            set ;
        }

        /// <summary>
        /// Url del dominio
        /// </summary>
        public string LDAPPath
     {
            get; 
            set ;
        }

        /// <summary>
        /// Usuario de impersonalizacion
        /// </summary>
        public string Usr
    {
            get; 
            set ;
        }

        /// <summary>
        /// Password
        /// </summary>
        public string Pwd
        {
            get;
            set;
        }

        public int Id
     {
            get; 
            set ;
        }

        public string SiteName
     {
            get; 
            set ;
        }
    

        public string DomainDN
        {
            get; 
            set ;
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
