using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using Fwk.Security.BE;
using Fwk.Security.Identity;

namespace Fwk.Security.Identity.ISVC.CheckAuthRule
{
    [Serializable]
    public class CheckAuthRuleReq : Request<Param>
    {
        public CheckAuthRuleReq()
		{
            this.ServiceName = "CheckAuthRuleService";
		}
    }

    public class Param:BaseEntity
    {
        public RulesAtuorizacionDictionary rulesDictionary { get; set; }

        public string UserName { get; set; }
        public string ruleName { get; set; }
    }
    public class RulesAtuorizacionDictionary : BaseEntities<RulesAtuorizacion>
    { }
    public class RulesAtuorizacion: BaseEntity
    {
        public string ruleName { get; set; }
        public bool isAtuh { get; set; }
    }

    [Serializable]
    public class CheckAuthRuleRes : Response<Result>
    {
    }

    public class Result : BaseEntity
    {
        public Boolean IsAuthorized { get; set; }
        
    }
}
