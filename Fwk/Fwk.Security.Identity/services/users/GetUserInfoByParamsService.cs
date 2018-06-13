using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Fwk.Security.Identity.ISVC.GetUserInfoByParams;
using Fwk.Security.Common;
using Fwk.Security.Identity;

namespace Fwk.Security.Identity.SVC
{
    /// <summary>
    /// Obtiene info del usuario :
    /// Retorna User y User.Roles
    /// intenta obtener el usuario en la membership 
    /// </summary>
    public class GetUserInfoByParamsService : BusinessService<GetUserInfoByParamsReq, GetUserInfoByParamsRes>
    {
        public override GetUserInfoByParamsRes Execute(GetUserInfoByParamsReq pServiceRequest)
        {
            GetUserInfoByParamsRes wRes = new GetUserInfoByParamsRes();
            SecurityUser secUser = SecurityManager.User_FindByName(pServiceRequest.BusinessData.UserName, true);

            wRes.BusinessData.UserInfo = MappingHelper.Map_SecurityUser_to_UserInfo(secUser);

            return wRes;
        }
    }
}