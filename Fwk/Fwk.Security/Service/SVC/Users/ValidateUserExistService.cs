using System;
using System.Data;
using System.Web.Security;
using System.Security.Principal;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security.ISVC.ValidateUserExist;
using Fwk.Security.Common;
using Fwk.Security;
using Fwk.Security.BC;

  

namespace Fwk.Security.SVC
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidateUserExistService : BusinessService<ValidateUserExistReq, ValidateUserExistRes>
    {
        public override ValidateUserExistRes Execute(ValidateUserExistReq pServiceRequest)
        {
            ValidateUserExistRes wRes = new ValidateUserExistRes();
            UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.AppId, pServiceRequest.SecurityProviderName);
            //solo para case AuthenticationModeEnum.ASPNETMemberShips:
            wRes.BusinessData.Exist = wUserBC.Exist(pServiceRequest.BusinessData.UserName);

            return wRes;
        }
    }


}
