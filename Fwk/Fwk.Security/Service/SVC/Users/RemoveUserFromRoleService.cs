using System;
using System.Data;
using System.Web.Security;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.ISVC.RemoveUserFromRole;




namespace Fwk.Security.SVC
{
    public class RemoveUserFromRoleService : BusinessService<RemoveUserFromRoleReq, RemoveUserFromRoleRes>
    {
        public override RemoveUserFromRoleRes Execute(RemoveUserFromRoleReq pServiceRequest)
        {
            RemoveUserFromRoleRes wRes = new RemoveUserFromRoleRes();

            //if (string.IsNullOrEmpty(pServiceRequest.BusinessData.ApplicationName))
            //    pServiceRequest.BusinessData.ApplicationName = Membership.ApplicationName;


            FwkMembership.RemoveUserFromRole(pServiceRequest.BusinessData.UserName, pServiceRequest.BusinessData.RolName, pServiceRequest.SecurityProviderName);

            return wRes;
        }
    }
}
