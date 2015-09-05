using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.ISVC.UpdateRules;

using Fwk.Security.BE;
using Fwk.Security;


namespace Fwk.Security.SVC
{
    /// <summary>
    /// Actualiza una coleccion de reglas
    /// </summary>
    public class UpdateRulesService : BusinessService<UpdateRulesReq, UpdateRulesRes>
    {
        public override UpdateRulesRes Execute(UpdateRulesReq pServiceRequest)
        {
            UpdateRulesRes wRes = new UpdateRulesRes();
            pServiceRequest.BusinessData.FwkAuthorizationRuleList.ForEach(r=>FwkMembership.UpdateRule(r, pServiceRequest.SecurityProviderName));
            return wRes;
        }
    }
}
