using System;
using System.Data;
using System.Collections.Generic;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.Identity.ISVC.SearchRulesCategoryByParam;
using Fwk.Exceptions;

namespace Fwk.Security.Identity.SVC
{
    /// <summary>
    /// Busca todas las cateegorias de un provider
    /// Por cada categoria tambien trae las reglas asociadas
    /// </summary>
    [Obsolete("Por el momento no es utilizado este servicio")]
    public class SearchRulesCategoryByParamService : BusinessService<SearchRulesCategoryByParamReq, SearchRulesCategoryByParamRes>
    {
        public override SearchRulesCategoryByParamRes Execute(SearchRulesCategoryByParamReq pServiceRequest)
        {
            SearchRulesCategoryByParamRes wRes = new SearchRulesCategoryByParamRes();

            //wRes.BusinessData = FwkMembership.GetAllCategories(pServiceRequest.SecurityProviderName);
            throw new FunctionalException("Este servicio no esta implementado para  Fwk.Security.Identity");

            return wRes;
        }
    }
}
        