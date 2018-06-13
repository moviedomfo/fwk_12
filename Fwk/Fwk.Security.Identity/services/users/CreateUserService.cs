
using System;
using System.Linq;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.Identity.ISVC.CreateUsers;
using Fwk.Security.BC;
using Fwk.Security.Identity;
using Microsoft.AspNet.Identity;

namespace Fwk.Security.Identity.SVC
{
    /// <summary>
    /// Servicio que crea un usuario en las memberships
    /// </summary>
    public class CreateUserService : BusinessService<CreateUserReq, CreateUserRes>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pServiceRequest"></param>
        /// <returns></returns>
        public override CreateUserRes Execute(CreateUserReq req)
        {
            CreateUserRes wRes = new CreateUserRes();
            SecurityUser user = new SecurityUser();
            user.UserName = req.BusinessData.User.UserName;
            user.Id = (Guid)req.BusinessData.User.ProviderId;
            user.Email = req.BusinessData.User.Email;
            user.PhoneNumber = req.BusinessData.User.UserName;
            user.UserName = req.BusinessData.User.UserName;
            
            //UserBC wUserBC = new UserBC(req.ContextInformation.AppId, req.SecurityProviderName);
            var identityResult = SecurityManager.User_Create(user, req.BusinessData.User.Password);

            if (identityResult.Succeeded)
            {
                //UsersDAC.Create(pUser, CustomParameters, _ProviderName, pCustomUserTable);
                // Se insertan los roles
                if (req.BusinessData.User.Roles != null)
                {
                    AssignRolesToUserModel model = new AssignRolesToUserModel();
                    model.userName = user.UserName;
                    req.BusinessData.User.Roles.ToList().ForEach(p =>
                    {
                        model.roles.Add(p);

                    });


                    SecurityManager.User_AsignRoles(model);

                }

            }
            wRes.BusinessData.UserId = req.BusinessData.User.UserId.Value;


            return wRes;
        }
    }
}
