using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.Identity;
using Fwk.Security.BE;
using Fwk.Security.Identity.ISVC.UpdateRules;


namespace Fwk.Security.Identity.SVC
{
    /// <summary>
    /// Actualiza una coleccion de reglas
    /// </summary>
    public class UpdateRulesService : BusinessService<UpdateRulesReq, UpdateRulesRes>
    {
        public override UpdateRulesRes Execute(UpdateRulesReq pServiceRequest)
        {
            UpdateRulesRes wRes = new UpdateRulesRes();
            pServiceRequest.BusinessData.AuthorizationRuleList.ForEach(
                securityRule =>
                {
                    SecurityManager.Rule_Update(securityRule, pServiceRequest.SecurityProviderName);
                }

                );
            return wRes;
        }
    }
}
