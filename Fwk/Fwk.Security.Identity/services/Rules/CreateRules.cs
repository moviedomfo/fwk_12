using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using Fwk.Security.BE;
using Fwk.Security;

namespace Fwk.Security.Identity.ISVC.CreateRules
{
	
	[Serializable]
    public class CreateRuleReq : Request<FwkAuthorizationRule>
	{
        public CreateRuleReq()
		{
			this.ServiceName = "CreateRuleService";
		}
	}
    [Serializable]
    public class CreateRuleRes : Response<DummyContract>
    {
    }



    
	
	
}
       