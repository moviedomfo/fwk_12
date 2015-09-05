using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CentralizedSecurity.wcf.Contracts;
using System.ServiceModel.Activation;

namespace CentralizedSecurity.wcf
{
    
    [ServiceContract]
    public interface ICoreSecurity
    {
        [OperationContract]
        LoogonUserResult Authenticate(string userName, string password, string domain);

        [OperationContract]
        String GetDomainNames();



        [OperationContract]
        String Test();

    }

   

}
