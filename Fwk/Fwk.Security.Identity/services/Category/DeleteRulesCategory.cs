
        //------------------------------------------------------------------------------
        // <auto-generated>
          //     This code was generated by a Fwk Code Generator.
          //     Runtime Version:1.0
          //
          //     Changes to this file may cause incorrect behavior and will be lost if
          //     the code is regenerated.
          //
        //</auto-generated>
        //------------------------------------------------------------------------------
        
         using System;
        using System.Collections.Generic;
        using Fwk.Bases;
        using System.Xml.Serialization;

namespace Fwk.Security.Identity.ISVC.DeleteRulesCategory
{

    [Serializable]
    public class DeleteRulesCategoryReq : Request<Param>
    {
        public DeleteRulesCategoryReq()
        {
            this.ServiceName = "DeleteRulesCategoryService";
        }
    }

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {



        Guid _CategoryId;

        /// <summary>
        /// 
        /// </summary>
        public Guid CategoryId
        {
            get
            {
                return _CategoryId;
            }
            set
            {
                _CategoryId = value;
            }
        }


    }
    [Serializable]
    public class DeleteRulesCategoryRes : Response<DummyContract>
    {
    }



     
}
        