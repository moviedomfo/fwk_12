using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DispatcherClientChecker.wrappers
{
    /// <summary>
    /// When configured for Transport security, WCF uses a secure communication protocol.Transport security
    ///encrypts all communication on the channel and thus provides for integrity, privacy,
    ///and mutual authentication
    /// </summary>
    public class WCFRrapper_WsHttpBinding_transport : WCFWrapper_WsHttpBinding
    {

        
        public override void InitilaizeBinding()
        {
            if (binding == null)
            {
                base.InitilaizeBinding();
                //base.binding.Security.Mode = SecurityMode.TransportWithMessageCredential;
                //base.binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
                //base.binding.Security.Message.ClientCredentials.UserName.UserName = "username";
                //serviceClient.ClientCredentials.UserName.Password = "password";
            }
        }

    }
}
