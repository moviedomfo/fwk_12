using System;
using System.Data;
using System.Collections.Generic;
using System.Web.Security;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.ISVC.DeleteRole;
using Fwk.Exceptions;
using Fwk.Security.Common;


namespace Fwk.Security.SVC
{
    public class DeleteRoleService : BusinessService<DeleteRoleReq, DeleteRoleRes>
    {
        public override DeleteRoleRes Execute(DeleteRoleReq pServiceRequest)
        {
            Rol wRol;
            DeleteRoleRes wRes = new DeleteRoleRes();
       
            //Elimina el rol: Este componente si el rol tiene o no asociado usuarios
            //FwkMembership.DeleteRole(pServiceRequest.BusinessData.RolName, pServiceRequest.SecurityProviderName);

            if (FwkMembership.GetUsersInRole(pServiceRequest.BusinessData.RolName, pServiceRequest.SecurityProviderName).Count != 0)
            {
                throw new FunctionalException(string.Format("El rol {0} contiene usuarios asociados.-", pServiceRequest.BusinessData.RolName));
            }

            //Elimino todas las asociciones de las reglas al rol.- Se modificara el valor Expression de la regla
            List<FwkAuthorizationRule> ruleListAux = FwkMembership.GetRulesByRole(pServiceRequest.BusinessData.RolName, pServiceRequest.SecurityProviderName);

            //TODO: Revisar este codigo e actualizacion de reglas si esta bien
            foreach (FwkAuthorizationRule rule in ruleListAux)
            {
                wRol = new Rol(pServiceRequest.BusinessData.RolName);
                FwkMembership.RemoveRol_From_Rule(wRol, rule);

                FwkMembership.UpdateRule(rule, pServiceRequest.SecurityProviderName);
            }

            FwkMembership.DeleteRole(pServiceRequest.BusinessData.RolName, pServiceRequest.SecurityProviderName);
            return wRes;
        }
    }
}
