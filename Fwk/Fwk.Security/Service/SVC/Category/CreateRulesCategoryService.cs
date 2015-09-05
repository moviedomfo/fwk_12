
using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.ISVC.CreateRulesCategory;
using Fwk.Security.BC;

namespace Fwk.Security.SVC
{

    /// <summary>
    /// Servicio de creacion de nueva categoria
    /// </summary>
    public class CreateRulesCategoryService : BusinessService<CreateRulesCategoryReq, CreateRulesCategoryRes>
    {
        public override CreateRulesCategoryRes Execute(CreateRulesCategoryReq pServiceRequest)
        {
            CreateRulesCategoryRes wRes = new CreateRulesCategoryRes();

            FwkMembership.CreateCategory(pServiceRequest.BusinessData, pServiceRequest.SecurityProviderName);
            wRes.BusinessData.Id=  pServiceRequest.BusinessData.CategoryId;
            return wRes;
        }
    }
}
        