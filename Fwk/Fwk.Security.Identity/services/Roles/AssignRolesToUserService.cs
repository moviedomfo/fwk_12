using System;
using System.Linq;
using Fwk.Bases;
using Fwk.Security.Identity.ISVC.AssignRolesToUser;
using Fwk.Security.BC;
using Fwk.Security.Identity;
using System.Collections.Generic;

namespace Fwk.Security.Identity.SVC
{

    public class AssignRolesToUserService : BusinessService<AssignRolesToUserReq, AssignRolesToUserRes>
    {
        public override AssignRolesToUserRes Execute(AssignRolesToUserReq req)
        {
            AssignRolesToUserRes wRes = new AssignRolesToUserRes();
            
           
            
            AssignRolesToUserModel model = new AssignRolesToUserModel();
            model.userName = req.BusinessData.Username;
            model.roles = new List<string>();
            req.BusinessData.RolList.ToList().ForEach(p =>
            {
                model.roles.Add(p.RolName);

            });

            SecurityManager.User_AsignRoles(model,req.SecurityProviderName);
            //Implement your code here
            return wRes;
        }
    }
}