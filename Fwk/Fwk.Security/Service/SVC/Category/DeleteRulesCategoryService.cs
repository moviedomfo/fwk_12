


using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security.ISVC.DeleteRulesCategory;
using Fwk.Security;
using Fwk.Security.BC;

namespace Fwk.Security.SVC
{
    /// <summary>
    /// Elimina una categoriua y sus subvategorias asocoadas de forma recursiva
    /// </summary>
    public class DeleteRulesCategoryService : BusinessService<DeleteRulesCategoryReq, DeleteRulesCategoryRes>
    {
        public override DeleteRulesCategoryRes Execute(DeleteRulesCategoryReq pServiceRequest)
        {
            DeleteRulesCategoryRes wRes = new DeleteRulesCategoryRes();

            FwkMembership.RemoveCategory(pServiceRequest.BusinessData.CategoryId, pServiceRequest.SecurityProviderName);  

            return wRes;
        }
    }
}
        