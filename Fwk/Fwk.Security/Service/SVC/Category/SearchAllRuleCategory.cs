
        
using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using Fwk.Security.BE;

namespace Fwk.Security.ISVC.SearchAllRulesCategory
{

    [Serializable]
    public class SearchAllRulesCategoryReq : Request<DummyContract>
    {
        public SearchAllRulesCategoryReq()
        {
            this.ServiceName = "SearchAllRulesCategoryService";
        }
    }




    [Serializable]
    public class SearchAllRulesCategoryRes : Response<FwkCategoryList>
    {
    }
}
        