
using System;
using System.Data;

using System.Collections.Generic;
using Fwk.Bases;
using Fwk.Security;
using Fwk.Security.BE;
using Fwk.Security.ISVC.SearchAllRules;





namespace Fwk.Security.SVC
{

    /// <summary>
    /// 
    /// </summary>
    public class SearchAllRulesService : BusinessService<SearchAllRulesReq, SearchAllRulesRes>
    {
        
        public override SearchAllRulesRes Execute(SearchAllRulesReq pServiceRequest)
        {
            SearchAllRulesRes wRes = new SearchAllRulesRes();

            FwkAuthorizationRuleList rules = FwkMembership.GetRulesAuxList(pServiceRequest.SecurityProviderName);



            wRes.BusinessData = rules;
         
            return wRes;
        }
    }
}
