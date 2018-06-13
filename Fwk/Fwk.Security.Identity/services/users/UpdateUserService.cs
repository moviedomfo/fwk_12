using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.Identity.ISVC.UpdateUser;


using Fwk.Security.Identity;
using System.Linq;

namespace Fwk.Security.Identity.SVC
{

    /// <summary>
    /// Este servicio permite: 
    /// 1 - Actualizar informacion del usuario en las memberships
    /// 2 - Cambiar la clave del usuario
    /// </summary>
    public class UpdateUserService : BusinessService<UpdateUserReq, UpdateUserRes>
    {
        public override UpdateUserRes Execute(UpdateUserReq req)
        {
            UpdateUserRes wRes = new UpdateUserRes();
            // UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.AppId, pServiceRequest.SecurityProviderName);

            if (string.IsNullOrEmpty(req.BusinessData.UserName))
                req.BusinessData.UserName = req.BusinessData.UsersBE.UserName;

            //ChangePassword != null indica la intencion de cambio de clave
            if (req.BusinessData.ChangePassword != null)
            {
                SecurityManager.User_ChangePassword(req.BusinessData.UsersBE.UserName, req.BusinessData.ChangePassword.Old, req.BusinessData.ChangePassword.New);
            }
            SecurityUser usersBE = null;
            //Si PasswordOnly = true pasa por alto la actuaizacion del usuario
            if (req.BusinessData.PasswordOnly == false)
            {

                usersBE = new SecurityUser();
                usersBE.UserName = req.BusinessData.UsersBE.UserName;
                usersBE.Email = req.BusinessData.UsersBE.Email;
                usersBE.Id = (Guid)req.BusinessData.UsersBE.ProviderId;

                SecurityManager.User_Update(usersBE, req.BusinessData.UserName);
            }

            if (req.BusinessData.RolList != null)
            {
                if (req.BusinessData.RolList.Count != 0)
                {

                    SecurityManager.User_RemoveRoles(usersBE.Id);
                    AssignRolesToUserModel model = new AssignRolesToUserModel();
                    model = new AssignRolesToUserModel();

                    model.userName = usersBE.UserName;
                    req.BusinessData.RolList.ToList().ForEach(p =>
                    {
                   
                        model.roles.Add(p.RolName);

                    });

                    SecurityManager.User_AsignRoles(model);
                }

            }

            return wRes;
        }
    }
}
