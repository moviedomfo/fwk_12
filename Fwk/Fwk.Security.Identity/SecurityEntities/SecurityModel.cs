namespace Fwk.Security.Identity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Fwk.Security.Identity;

    public partial class SecurityModelContext : DbContext
    {
        public SecurityModelContext()
            : base("name=defaultCnnString")
        {
        }

        public virtual DbSet<SecurityClient> SecurityClients { get; set; }
        public virtual DbSet<SecurityRefreshToken> SecurityRefreshTokens { get; set; }
        public virtual DbSet<SecurityRole> SecurityRoles { get; set; }
        public virtual DbSet<SecurityRule> SecurityRules { get; set; }
        public virtual DbSet<SecurityRulesCategory> SecurityRulesCategories { get; set; }
        public virtual DbSet<SecuritytUserLogin> SecuritytUserLogins { get; set; }
        public virtual DbSet<SecurityUserClaim> SecurityUserClaims { get; set; }
        public virtual DbSet<SecurityUser> SecurityUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SecurityRole>()
                .HasMany(e => e.SecurityRules)
                .WithMany(e => e.SecurityRoles)
                .Map(m => m.ToTable("SecurityRolesInRules").MapLeftKey("RolId").MapRightKey("RuleId"));

            modelBuilder.Entity<SecurityRole>()
                .HasMany(e => e.SecurityUsers)
                .WithMany(e => e.SecurityRoles)
                .Map(m => m.ToTable("SecurityUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<SecurityRule>()
                .HasMany(e => e.SecurityRulesCategories)
                .WithMany(e => e.SecurityRules)
                .Map(m => m.ToTable("SecurityRulesInCategory").MapLeftKey("RuleId").MapRightKey("CategoryId"));

            modelBuilder.Entity<SecurityUser>()
                .HasMany(e => e.SecuritytUserLogins)
                .WithRequired(e => e.SecurityUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<SecurityUser>()
                .HasMany(e => e.SecurityUserClaims)
                .WithRequired(e => e.SecurityUser)
                .HasForeignKey(e => e.UserId);
        }
    }
}
