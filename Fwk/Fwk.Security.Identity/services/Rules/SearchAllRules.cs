using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using Fwk.Security.BE;
using Fwk.Security.Identity;

namespace Fwk.Security.Identity.ISVC.SearchAllRules
{
    [Serializable]
    public class SearchAllRulesReq : Request<DummyContract>
    {
        public SearchAllRulesReq()
		{
            this.ServiceName = "SearchAllRulesService";
		}
    }

   

    [Serializable]
    public class SearchAllRulesRes : Response<SecurityRuleBEList>
    {
    }

   
}
