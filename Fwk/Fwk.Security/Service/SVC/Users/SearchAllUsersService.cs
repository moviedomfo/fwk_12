using System;
using System.Data;
using System.Web.Security;
using System.Collections.Generic;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.ISVC.SearchAllUsers;
using Fwk.Security.Common;
using Fwk.Security.BC;


namespace Fwk.Security.SVC
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchAllUsersService : BusinessService<SearchAllUsersReq, SearchAllUsersRes>
    {
        public override SearchAllUsersRes Execute(SearchAllUsersReq pServiceRequest)
        {
            SearchAllUsersRes wRes = new SearchAllUsersRes();
            UserBC wBC = new UserBC(pServiceRequest.ContextInformation.AppId, pServiceRequest.SecurityProviderName);

            //if (string.IsNullOrEmpty(pServiceRequest.BusinessData.ApplicationName))
            //    pServiceRequest.BusinessData.ApplicationName = Membership.ApplicationName;

            wRes.BusinessData.UserList = wBC.GetAllUser();


            return wRes;
        }
    }
}