using Fwk.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fwk.Security.Identity
{
    public class SecurityRoleBEList : BaseEntities<SecurityRoleBE>
    {

    }


    public class SecurityRoleBE : BaseEntity
    {
        public Guid Id { get; set; }
        public String Description { get; set; }
        public String Name { get; set; }
        public Guid? InstitutionId { get; set; }
    }
    public class SecurityUserRoleBE
    {
        public Guid UserId { get; set; }
        public Guid RolId { get; set; }
    }

    public class SecurityRolesInRulesBE
    {
        public Guid RolId { get; set; }
        public Guid RuleId { get; set; }
        
    }
}
