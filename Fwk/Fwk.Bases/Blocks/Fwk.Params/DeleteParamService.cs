using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;
using Fwk.Params.Back;
using Fwk.Params.BE;
using Fwk.Params.Isvc.DeleteParam;


namespace Fwk.Params.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteParametroService : BusinessService<DeleteParamReq, DeleteParamRes>
    {
        public override DeleteParamRes Execute(DeleteParamReq pServiceRequest)
        {
            DeleteParamRes wRes = new DeleteParamRes();

            ParamDAC.Delete(pServiceRequest.BusinessData.ParamId,pServiceRequest.BusinessData.ParentId, pServiceRequest.BusinessData.CnnStringName);
            return wRes;
        }

       
    }
}

namespace Fwk.Params.Isvc.DeleteParam
{
    [Serializable]
    public class DeleteParamReq : Fwk.Bases.Request<Params>
    {

        public DeleteParamReq()
        {
            base.ServiceName = "DeleteParamService";
        }
    }

    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Entity
    {
      

        /// <summary>
        /// 
        /// </summary>
        public int? ParamId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CnnStringName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? ParentId { get; set; }
    }



    [Serializable]
    public class DeleteParamRes : Fwk.Bases.Response<DummyContract>
    {
    }

}