
using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.Identity.ISVC.CreateRulesCategory;
using Fwk.Security.BC;
using Fwk.Security.Identity;

namespace Fwk.Security.Identity.SVC
{

    /// <summary>
    /// Servicio de creacion de nueva categoria
    /// </summary>
    public class CreateRulesCategoryService : BusinessService<CreateRulesCategoryReq, CreateRulesCategoryRes>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pServiceRequest"></param>
        /// <returns></returns>
        public override CreateRulesCategoryRes Execute(CreateRulesCategoryReq pServiceRequest)
        {
            CreateRulesCategoryRes wRes = new CreateRulesCategoryRes();
            SecurityRulesCategory ruleCategory = new SecurityRulesCategory();
            ruleCategory.Name = pServiceRequest.BusinessData.Name;
            ruleCategory.ParentCategoryId = pServiceRequest.BusinessData.ParentCategoryId;

            SecurityManager.RuleCategory_Create(ruleCategory, pServiceRequest.SecurityProviderName);
            wRes.BusinessData.Id=  pServiceRequest.BusinessData.CategoryId;
            return wRes;
        }
    }
}
        