using Fwk.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fwk.Security.Identity
{
    public class SecurityRuleBEList : BaseEntities<SecurityRuleBE>
    {

    }
    public class SecurityRuleBE : BaseEntity
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        //public Guid InstitutionId { get; set; }
        
    }
    public class SecurityRulesCategoryBEList : BaseEntities<SecurityRulesCategoryBE>
    { }
        public class SecurityRulesCategoryBE: BaseEntity
    {
        public Guid CategoryId { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public String Name { get; set; }
        //public Guid InstitutionId { get; set; }
    }

    public class SecurityRulesInCategoryBE : BaseEntity
    {
        public Guid CategoryId { get; set; }
        public Guid RuleId { get; set; }
        //public Guid InstitutionId { get; set; }
    }
}
