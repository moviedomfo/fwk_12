
using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.ISVC.ResetUserPassword;
using System.Web.Security;
using Fwk.Security.Common;
using Fwk.Security.BC;
using System.Xml.Serialization;


namespace Fwk.Security.SVC
{

    /// <summary>
    /// Este servicio permite resetear la clave de un usuario 
    /// </summary>
    public class ResetUserPasswordService : BusinessService<ResetUserPasswordReq, ResetUserPasswordRes>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pServiceRequest"></param>
        /// <returns></returns>
        public override ResetUserPasswordRes Execute(ResetUserPasswordReq pServiceRequest)
        {
            ResetUserPasswordRes wRes = new ResetUserPasswordRes();
            UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.AppId, pServiceRequest.SecurityProviderName);
            wUserBC.ResetPassword(pServiceRequest.BusinessData.UserName, pServiceRequest.BusinessData.NewPassword);
            return wRes;
        }
    }
}

namespace Fwk.Security.ISVC.ResetUserPassword
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ResetUserPasswordReq : Request<Param>
    {
        /// <summary>
        /// 
        /// </summary>
        public ResetUserPasswordReq()
        {
            this.ServiceName = "ResetUserPasswordService";
        }
    }

    /// <summary>
    /// Parametros de reseteo
    /// </summary>
    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        /// <summary>
        /// Nombre de usuario al que se le resseteara la password
        /// </summary>
        public String UserName { get; set; }

        /// <summary>
        /// Buevo valor de la password
        /// </summary>
        public String NewPassword { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ResetUserPasswordRes : Response<DummyContract>
    {
    }




}
