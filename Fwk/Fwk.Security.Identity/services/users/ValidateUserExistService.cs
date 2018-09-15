
using Fwk.Bases;
using Fwk.Security.Identity.ISVC.ValidateUserExist;
using Fwk.Security.Identity;


namespace Fwk.Security.Identity.SVC
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidateUserExistService : BusinessService<ValidateUserExistReq, ValidateUserExistRes>
    {
        public override ValidateUserExistRes Execute(ValidateUserExistReq pServiceRequest)
        {
            ValidateUserExistRes wRes = new ValidateUserExistRes();
            
            //solo para case AuthenticationModeEnum.ASPNETMemberShips:
  
            wRes.BusinessData.Exist = SecurityManager.User_Exist(pServiceRequest.BusinessData.UserName, pServiceRequest.SecurityProviderName);
            return wRes;
        }
    }


}
