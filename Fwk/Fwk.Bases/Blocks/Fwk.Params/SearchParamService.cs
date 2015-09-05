using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;
using Fwk.Params.Back;
using Fwk.Params.BE;
using Fwk.Params.Isvc.SearchParams;

namespace Fwk.Params.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchParamsService : BusinessService<SearchParamsReq, SearchParamsRes>
    {
        public override SearchParamsRes Execute(SearchParamsReq pServiceRequest)
        {
            SearchParamsRes wRes = new SearchParamsRes();


            wRes.BusinessData = ParamDAC.RetriveByParams(
                pServiceRequest.BusinessData.ParentId, pServiceRequest.BusinessData.Enabled,pServiceRequest.BusinessData.Culture,
                pServiceRequest.ContextInformation.AppId);
            return wRes;
        }

    }
}

namespace Fwk.Params.Isvc.SearchParams
{
    [Serializable]
    public class SearchParamsReq : Fwk.Bases.Request<Params>
    {

        public SearchParamsReq()
        {
            base.ServiceName = "SearchParamsService";
        }
    }

    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        public bool? Enabled { get; set; }


        
        /// <summary>
        /// Param de referencia. Referencia a un parametro padre
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// Culture
        /// </summary>
        public string Culture { get; set; }
    }


    [Serializable]
    public class SearchParamsRes : Fwk.Bases.Response<ParamList>
    {
    }

}
