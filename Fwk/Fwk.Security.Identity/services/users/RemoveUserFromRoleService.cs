using System;
using System.Data;

using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.Identity.ISVC.RemoveUserFromRole;
using Fwk.Security.Identity;

namespace Fwk.Security.Identity.SVC
{
    public class RemoveUserFromRoleService : BusinessService<RemoveUserFromRoleReq, RemoveUserFromRoleRes>
    {
        public override RemoveUserFromRoleRes Execute(RemoveUserFromRoleReq pServiceRequest)
        {
            RemoveUserFromRoleRes wRes = new RemoveUserFromRoleRes();

            //if (string.IsNullOrEmpty(pServiceRequest.BusinessData.ApplicationName))
            //    pServiceRequest.BusinessData.ApplicationName = Membership.ApplicationName;


            //FwkMembership.RemoveUserFromRole(pServiceRequest.BusinessData.UserName, pServiceRequest.BusinessData.RolName, pServiceRequest.SecurityProviderName);
            SecurityManager.User_RemoveFromRole(pServiceRequest.BusinessData.UserName, pServiceRequest.BusinessData.RolName);
            return wRes;
        }
    }
}
