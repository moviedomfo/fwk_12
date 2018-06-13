using System;
using System.Data;
using System.Collections.Generic;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.Identity.ISVC.SearchAllRulesCategory;
using Fwk.Security.Identity;

namespace Fwk.Security.Identity.SVC
{
    /// <summary>
    /// Busca todas las cateegorias de un provider
    /// Por cada categoria tambien trae las reglas asociadas
    /// </summary>
    public class SearchAllRulesCategoryService : BusinessService<SearchAllRulesCategoryReq, SearchAllRulesCategoryRes>
    {
        public override SearchAllRulesCategoryRes Execute(SearchAllRulesCategoryReq pServiceRequest)
        {
            SearchAllRulesCategoryRes wRes = new SearchAllRulesCategoryRes();
        
            wRes.BusinessData = SecurityManager.RulesCategory_getAll();
        
            return wRes;
        }
    }
}
        