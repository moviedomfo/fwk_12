using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;

namespace Fwk.Security.ActiveDirectory
{
    /// <summary>
    /// Reprecenta la configuracion de un dominino de active directory.- Esta ta entidad  tiene el esquema de una tabpl de sql server. Esta tabla tiene la informacion de los dominios de la 
    /// empresa 
    /// El script de la tabla se encuentra en el archivo DomainsUrlScript.txt
    /// </summary>    
    [Serializable]
    public class DomainUrlInfo : Entity
    {

        string domainName;

        /// <summary>
        /// Nombre de dominio
        /// </summary>
        public string DomainName
        {
            get { return domainName; }
            set { domainName = value; }
        }
        string lDAPPath;

        /// <summary>
        /// Url del dominio
        /// </summary>
        public string LDAPPath
        {
            get { return lDAPPath; }
            set { lDAPPath = value; }
        }
        string usr;

        /// <summary>
        /// Usuario de impersonalizacion
        /// </summary>
        public string Usr
        {
            get { return usr; }
            set { usr = value; }
        }
        string pwd;

        /// <summary>
        /// Password
        /// </summary>
        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        int _Id;
        /// <summary>
        /// 
        /// </summary>
        public string SiteName
        {
            get { return _SiteName; }
            set { _SiteName = value; }
        }
        string _SiteName;
        /// <summary>
        /// 
        /// </summary>
        public string DomainDN
        {
            get { return _DomainDN; }
            set { _DomainDN = value; }
        }
        string _DomainDN;
    }
}
