
using System;
using System.Data;
using Fwk.Bases;
using Fwk.Blocking.ISVC;



namespace Fwk.Blocking.SVC
{
    /// <summary>
    /// Servicio que crea un usuario en las memberships
    /// </summary>
    public class ClearBlockingMarksService : BusinessService<ClearBlockingMarksReq, ClearBlockingMarksRes>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pServiceRequest"></param>
        /// <returns></returns>
        public override ClearBlockingMarksRes Execute(ClearBlockingMarksReq pServiceRequest)
        {

            ClearBlockingMarksRes res = new ClearBlockingMarksRes();


            BlockingEngineBase.ClearBlockingMarks();
            

            return res;
        }
    }
}
