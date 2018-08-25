
using System;
using System.Data;
using System.Collections.Generic;
using Fwk.Bases;
using Fwk.Security;
using Fwk.Security.BE;
using Fwk.Security.Identity.ISVC.CheckAuthRule;
using Fwk.Security.Identity;

namespace Fwk.Security.Identity.SVC
{
    /// <summary>
    /// 
    /// </summary>
    public class CheckAuthRuleService : BusinessService<CheckAuthRuleReq, CheckAuthRuleRes>
    {
        
        public override CheckAuthRuleRes Execute(CheckAuthRuleReq req)
        {
            CheckAuthRuleRes res = new CheckAuthRuleRes();

            // FwkAuthorizationRuleList rules = FwkMembership.GetRulesAuxList(pServiceRequest.SecurityProviderName);
            res.BusinessData = new Result();
            res.BusinessData.IsAuthorized = SecurityManager.Rule_check(req.BusinessData.ruleName, req.BusinessData.UserName, req.SecurityProviderName);
           
            return res;
        }
    }
}
