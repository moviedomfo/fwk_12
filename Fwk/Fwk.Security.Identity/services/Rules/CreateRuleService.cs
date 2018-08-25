
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
using System.Data;
using Fwk.Bases;
using  Fwk.Security.Identity.ISVC.CreateRules;
using Fwk.Security.Identity;

namespace Fwk.Security.Identity.SVC
{
    /// <summary>
    /// Servicio que crea una nueva regla
    /// </summary>
    public class CreateRuleService : BusinessService<CreateRuleReq, CreateRuleRes>
    {
        public override CreateRuleRes Execute(CreateRuleReq pServiceRequest)
        {
            CreateRuleRes wRes = new CreateRuleRes();
            SecurityRule secTule = new SecurityRule();
            secTule.Name = pServiceRequest.BusinessData.Name;
            secTule.Description = pServiceRequest.BusinessData.Description;
            
            SecurityManager.Rule_Create (secTule, pServiceRequest.SecurityProviderName);  
            return wRes;
        }
    }
}
