using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.Identity;

namespace Fwk.Security.Identity.ISVC.UpdateRules
{
    [Serializable]
    public class UpdateRulesReq : Request<Param>
    {
        public UpdateRulesReq()
		{
            this.ServiceName = "UpdateRulesService";

		}
    }



    #region [BussinesData]
    [XmlInclude(typeof(Param)), Serializable]
    public class Param:Entity
    {
        SecurityRuleBEList _Rules = new SecurityRuleBEList();

        public SecurityRuleBEList AuthorizationRuleList
        {
            get { return _Rules; }
            set { _Rules = value; }
        }

    }
    

    #endregion


    [Serializable]
    public class UpdateRulesRes : Response<DummyContract>
    {

    }
    
}
