


using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security.Identity.ISVC.DeleteRulesCategory;
using Fwk.Security;
using Fwk.Security.BC;
using Fwk.Exceptions;

namespace Fwk.Security.Identity.SVC
{
    /// <summary>
    /// Elimina una categoriua y sus subvategorias asocoadas de forma recursiva
    /// </summary>
    public class DeleteRulesCategoryService : BusinessService<DeleteRulesCategoryReq, DeleteRulesCategoryRes>
    {
        public override DeleteRulesCategoryRes Execute(DeleteRulesCategoryReq pServiceRequest)
        {
            DeleteRulesCategoryRes wRes = new DeleteRulesCategoryRes();
            throw new FunctionalException("Este servicio no esta implementado para  Fwk.Security.Identity");
            SecurityManager.Category_Removee(pServiceRequest.BusinessData.CategoryId, pServiceRequest.SecurityProviderName);  

            return wRes;
        }
    }
}
        