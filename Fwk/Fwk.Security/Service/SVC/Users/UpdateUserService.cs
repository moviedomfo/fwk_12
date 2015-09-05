using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.ISVC.UpdateUser;
using System.Web.Security;
using Fwk.Security.Common;
using Fwk.Security.BC;


namespace Fwk.Security.SVC
{

    /// <summary>
    /// Este servicio permite: 
    /// 1 - Actualizar informacion del usuario en las memberships
    /// 2 - Cambiar la clave del usuario
    /// </summary>
    public class UpdateUserService : BusinessService<UpdateUserReq, UpdateUserRes>
    {
        public override UpdateUserRes Execute(UpdateUserReq pServiceRequest)
        {
            UpdateUserRes wRes = new UpdateUserRes();
            UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.AppId, pServiceRequest.SecurityProviderName);
           
            if (string.IsNullOrEmpty(pServiceRequest.BusinessData.UserName))
                pServiceRequest.BusinessData.UserName = pServiceRequest.BusinessData.UsersBE.UserName;

            //ChangePassword != null indica la intencion de cambio de clave
            if (pServiceRequest.BusinessData.ChangePassword != null)
            {                
                wUserBC.ChangePassword(pServiceRequest.BusinessData.UsersBE.UserName, pServiceRequest.BusinessData.ChangePassword.Old, pServiceRequest.BusinessData.ChangePassword.New);
            }

            //Si PasswordOnly = true pasa por alto la actuaizacion del usuario
            if (pServiceRequest.BusinessData.PasswordOnly == false)
            {
                wUserBC.Update(pServiceRequest.BusinessData.UsersBE,pServiceRequest.BusinessData.UserName);                
            }

            return wRes;
        }
    }
}
