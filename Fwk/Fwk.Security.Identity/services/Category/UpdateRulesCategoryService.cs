
        
using System;
using System.Data;
using Fwk.Bases;
using  Fwk.Security.Identity.ISVC.UpdateRulesCategory;

using Fwk.Security.BE;
using Fwk.Exceptions;

namespace Fwk.Security.Identity.SVC
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateRulesCategoryService : BusinessService<UpdateRulesCategoryReq, UpdateRulesCategoryRes>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pServiceRequest"></param>
        /// <returns></returns>
        public override UpdateRulesCategoryRes Execute(UpdateRulesCategoryReq pServiceRequest)
        {
            UpdateRulesCategoryRes wRes = new UpdateRulesCategoryRes();
            //TOD0: terminar desarrollor de UpdateRulesCategoryService 
            // RulesCategoryBE wRC = new RulesCategoryBE();
            //wRC = RulesCategoryBE.GetFromXml < RulesCategoryBE>(pServiceRequest.BusinessData.GetXml());
            throw new FunctionalException("Este servicio no esta implementado para  Fwk.Security.Identity");
            return wRes;
        }
    }
}
        