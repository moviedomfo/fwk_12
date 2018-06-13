namespace  Fwk.Security.Identity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SecurityRulesCategory")]
    public partial class SecurityRulesCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SecurityRulesCategory()
        {
            SecurityRules = new HashSet<SecurityRule>();
        }

        [Key]
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public Guid? ParentCategoryId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SecurityRule> SecurityRules { get; set; }
    }
}
