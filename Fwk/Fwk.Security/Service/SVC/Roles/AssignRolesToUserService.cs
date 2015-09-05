using System;
using System.Data;
using System.Web.Security;
using System.Security.Principal;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.ISVC.AssignRolesToUser;
using Fwk.Security.Common;
using Fwk.Security.BC;



namespace Fwk.Security.SVC
{

    public class AssignRolesToUserService : BusinessService<AssignRolesToUserReq, AssignRolesToUserRes>
    {
        public override AssignRolesToUserRes Execute(AssignRolesToUserReq pServiceRequest)
        {
            AssignRolesToUserRes wRes = new AssignRolesToUserRes();
            UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.AppId, pServiceRequest.SecurityProviderName);
           
            if (string.IsNullOrEmpty(pServiceRequest.BusinessData.ApplicationName))
                pServiceRequest.BusinessData.ApplicationName = System.Web.Security.Membership.ApplicationName;

            FwkMembership.CreateRolesToUser(pServiceRequest.BusinessData.RolList, pServiceRequest.BusinessData.Username, pServiceRequest.SecurityProviderName);

            //Implement your code here
            return wRes;
        }
    }
}