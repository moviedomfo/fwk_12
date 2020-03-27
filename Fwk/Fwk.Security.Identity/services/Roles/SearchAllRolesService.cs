
using System;
using System.Data;

using System.Collections.Generic;
using Fwk.Bases;
using Fwk.Security;
using Fwk.Security.BE;
using Fwk.Security.Identity.ISVC.SearchAllRoles;
using Fwk.Security.Common;

namespace Fwk.Security.Identity.SVC
{
    public class SearchAllRolesService : BusinessService<SearchAllRolesReq, SearchAllRolesRes>
    {
        public override SearchAllRolesRes Execute(SearchAllRolesReq pServiceRequest)
        {
            SearchAllRolesRes wRes = new SearchAllRolesRes();

             wRes.BusinessData = new Result();
            
            wRes.BusinessData.RolList = SecurityManager.Role_getAll(pServiceRequest.BusinessData.InstitutionId, pServiceRequest.SecurityProviderName);
           

                
            return wRes;
        }
    }
}
