
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a Fwk Code Generator.
//     Runtime Version:1.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
//</auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data;

using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.Identity.ISVC.SearchRolesForUser;


namespace Fwk.Security.Identity.SVC
{
    public class SearchRolesForUserService : BusinessService<SearchRolesForUserReq, SearchRolesForUserRes>
    {
        public override SearchRolesForUserRes Execute(SearchRolesForUserReq pServiceRequest)
        {
            SearchRolesForUserRes wRes = new SearchRolesForUserRes();
     

            wRes.BusinessData.RolList = FwkMembership.GetRolesForUser(pServiceRequest.BusinessData.Username, pServiceRequest.SecurityProviderName); 
            //Implement your code here
            return wRes;
        }
    }
}
        