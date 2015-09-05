
using System;
using System.Data;
using System.Web.Security;
using System.Collections.Generic;
using Fwk.Bases;
using Fwk.Security;
using Fwk.Security.BE;
using Fwk.Security.ISVC.SearchAllRoles;




namespace Fwk.Security.SVC
{
    public class SearchAllRolesService : BusinessService<SearchAllRolesReq, SearchAllRolesRes>
    {
        public override SearchAllRolesRes Execute(SearchAllRolesReq pServiceRequest)
        {
            SearchAllRolesRes wRes = new SearchAllRolesRes();

       

             wRes.BusinessData = new Result();

            if(string.IsNullOrEmpty( pServiceRequest.BusinessData.UserName))
                wRes.BusinessData.RolList = FwkMembership.GetAllRoles_FullInfo(pServiceRequest.SecurityProviderName);
            else
                wRes.BusinessData.RolList = FwkMembership.GetAllRoles_FullInfo(pServiceRequest.BusinessData.UserName, pServiceRequest.SecurityProviderName);



            return wRes;
        }
    }
}
