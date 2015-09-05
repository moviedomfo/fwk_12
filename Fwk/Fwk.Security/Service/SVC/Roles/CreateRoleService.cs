using System;
using System.Data;
using System.Web.Security;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.ISVC.CreateRole;



namespace Fwk.Security.SVC
{
    public class CreateRoleService : BusinessService<CreateRoleReq, CreateRoleRes>
    {
        public override CreateRoleRes Execute(CreateRoleReq pServiceRequest)
        {
            CreateRoleRes wRes = new CreateRoleRes();
            //if (string.IsNullOrEmpty(pServiceRequest.BusinessData.ApplicationName))
            //    pServiceRequest.BusinessData.ApplicationName = Membership.ApplicationName;

            FwkMembership.CreateRole(pServiceRequest.BusinessData.Rol.RolName,
                pServiceRequest.BusinessData.Rol.Description, 
                pServiceRequest.SecurityProviderName);
            return wRes;
        }
    }
}
