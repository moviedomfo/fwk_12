using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CentralizedSecurity.wcf.Contracts;
using System.ServiceModel.Activation;
namespace Fwk.WCF.Services
{
    [ServiceContract]
    public interface ICoreSecurityAspnet
    {
        [OperationContract]
        LoogonUserResult Autenticate(string userName, string password, string domain);

        [OperationContract]
        String GetDomainNames();



        [OperationContract]
        String Test();
    }
}
