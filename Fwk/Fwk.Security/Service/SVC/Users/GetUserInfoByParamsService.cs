using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Fwk.Security.ISVC.GetUserInfoByParams;

using Fwk.Security;
using Fwk.Security.BC;
using Fwk.Security.Common;

namespace Fwk.Security.SVC
{
    /// <summary>
    /// Obtiene info del usuario :
    /// Retorna User y Roles
    /// intenta obtener el usuario en la membership 
    /// </summary>
    public class GetUserInfoByParamsService : BusinessService<GetUserInfoByParamsReq, GetUserInfoByParamsRes>
    {
        public override GetUserInfoByParamsRes Execute(GetUserInfoByParamsReq pServiceRequest)
        {
            GetUserInfoByParamsRes wRes = new GetUserInfoByParamsRes();

            UserBC userBC = new UserBC(pServiceRequest.ContextInformation.AppId, pServiceRequest.SecurityProviderName);


            RolList wRolList = new RolList();
            User wUser = new User();

            userBC.GetUserByParams(pServiceRequest.BusinessData.UserName, out wUser, out wRolList);

            wRes.BusinessData.UserInfo = wUser;
            wRes.BusinessData.RolList = wRolList;
         
            
            return wRes;
        }
    }
}