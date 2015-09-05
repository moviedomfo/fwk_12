using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Fwk.CentralizedSecurity.Contracts;
using Fwk.CentralizedSecurity.Service;

namespace Fwk.CentralizedSecurity
{
    /// <summary>
    /// Summary description for Security
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]

    public class CoreSecurity : System.Web.Services.WebService
    {

        [WebMethod]
        public LoogonUserResult Authenticate(string userName, string password, string domain)
        {
            return ActiveDirectoryService.User_Logon(userName, password, domain);
        }

        [WebMethod(Description = "Retorna informacion sobre dominios de la empresa")]
        public string Retrive_DomainsUrl()
        {
            Fwk.CentralizedSecurity.Contracts.DomainsUrl[] domains= ActiveDirectoryService.GetAllDomainsUrl();
            var list = from d in domains select d.DomainName ;

            return string.Join(",",list);
        }

        [WebMethod]
        public String Test()
        {
            return "Hi wellcome to Core Security web service " + System.DateTime.Now.ToString();
        }
    }
}
