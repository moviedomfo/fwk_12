using System;
using Fwk.Security;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CentralizedSecurity.wcf.Contracts;
using CentralizedSecurity.wcf.Service;
using System.ServiceModel.Activation;
using Fwk.WCF.Services;

namespace CentralizedSecurity.wcf
{
    [ServiceContract(Namespace = "CoreSecurity")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CoreSecurityAspnet : ICoreSecurityAspnet
    {
        public LoogonUserResult Autenticate(string userName, string password, string domain)
        {
            return ActiveDirectoryService.User_Logon(userName, password, domain);
        }

        public String GetDomainNames()
        {
            CentralizedSecurity.wcf.Contracts.DomainsUrl[] domains = ActiveDirectoryService.GetAllDomainsUrl();
            var list = from d in domains select d.DomainName;

            return string.Join(",", list);
        }
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public String Test()
        {
            return "Hi wellcome to CentralizedSecurity.wcf a " + System.DateTime.Now.ToString();
        }
    }
}
