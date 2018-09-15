using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.Identity.ISVC.SearchAllUsers;
using Fwk.Security.Common;

using Fwk.Security.Identity;

namespace Fwk.Security.Identity.SVC
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchAllUsersService : BusinessService<SearchAllUsersReq, SearchAllUsersRes>
    {
        public override SearchAllUsersRes Execute(SearchAllUsersReq pServiceRequest)
        {
            SearchAllUsersRes wRes = new SearchAllUsersRes();
            // UserBC wBC = new UserBC(pServiceRequest.ContextInformation.AppId, pServiceRequest.SecurityProviderName);

            //if (string.IsNullOrEmpty(pServiceRequest.BusinessData.ApplicationName))
            //    pServiceRequest.BusinessData.ApplicationName = Membership.ApplicationName;

            //wRes.BusinessData.UserList = wBC.GetAllUser();
            wRes.BusinessData.UserList = new UserList();
            User wUser = new User();
            var users = SecurityManager.User_getAll(pServiceRequest.SecurityProviderName);
            users.ToList().ForEach(u=>{

                wUser.ProviderId = u.Id;
                wUser.UserName = u.UserName;
                wUser.Email = u.Email;
                wUser.LastActivityDate = u.LastLogInDate;
                wUser.CreationDate = u.CreatedDate;

                wRes.BusinessData.UserList.Add(wUser);
            });
            return wRes;
        }
    }
}