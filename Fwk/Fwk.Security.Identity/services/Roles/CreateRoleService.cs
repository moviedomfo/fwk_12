using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.Identity.ISVC.CreateRole;



namespace Fwk.Security.Identity.SVC
{
    public class CreateRoleService : BusinessService<CreateRoleReq, CreateRoleRes>
    {
        public override CreateRoleRes Execute(CreateRoleReq pServiceRequest)
        {
            CreateRoleRes wRes = new CreateRoleRes();
            //if (string.IsNullOrEmpty(pServiceRequest.BusinessData.ApplicationName))
            //    pServiceRequest.BusinessData.ApplicationName = Membership.ApplicationName;

            SecurityRole secRole = new SecurityRole();

            secRole.Description = pServiceRequest.BusinessData.Rol.Description;
            secRole.Name = pServiceRequest.BusinessData.Rol.RolName;
            secRole.Description = pServiceRequest.BusinessData.Rol.Description;
            SecurityManager.Role_Create(secRole, pServiceRequest.SecurityProviderName);
           
            return wRes;
        }
    }
}
