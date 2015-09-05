using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Fwk.Security.Identity
{
    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public ApplicationDbContext()
    //        : base("DefaultConnection", throwIfV1Schema: false)
    //    {
    //    }

    //    static ApplicationDbContext()
    //    {
    //        // Set the database intializer which is run once during application start
    //        // This seeds the database with admin user credentials and admin role
    //        Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
    //    }

    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext();
    //    }
    //}
    //// This is useful if you do not want to tear down the database each time you run the application.
    //// public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    //// This example shows you how to create a new database if the Model changes
    //public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    //{
    //    protected override void Seed(ApplicationDbContext context)
    //    {
    //        InitializeIdentityForEF(context);
    //        base.Seed(context);
    //    }

    //    //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
    //    public static void InitializeIdentityForEF(ApplicationDbContext db)
    //    {
    //        var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
    //        var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
    //        const string name = "admin@example.com";
    //        const string password = "Admin@123456";
    //        const string roleName = "Admin";

    //        //Create Role Admin if it does not exist
    //        var role = roleManager.FindByName(roleName);
    //        if (role == null)
    //        {
    //            role = new IdentityRole(roleName);
    //            var roleresult = roleManager.Create(role);
    //        }

    //        var user = userManager.FindByName(name);
    //        if (user == null)
    //        {
    //            user = new ApplicationUser { UserName = name, Email = name };
    //            var result = userManager.Create(user, password);
    //            result = userManager.SetLockoutEnabled(user.Id, false);
    //        }

    //        // Add user admin to Role Admin if not already added
    //        var rolesForUser = userManager.GetRoles(user.Id);
    //        if (!rolesForUser.Contains(role.Name))
    //        {
    //            var result = userManager.AddToRole(user.Id, role.Name);
    //        }
    //    }
    //}
    //public class ApplicationUser : IdentityUser
    //{
    //    public string Address { get; set; }
    //    public string City { get; set; }
    //    public string State { get; set; }

    //    // Use a sensible display name for views:
        
    //    public string PostalCode { get; set; }

    //    public string DisplayAddress
    //    {
    //        get
    //        {
    //            string dspAddress =
    //                string.IsNullOrWhiteSpace(this.Address) ? "" : this.Address;
    //            string dspCity =
    //                string.IsNullOrWhiteSpace(this.City) ? "" : this.City;
    //            string dspState =
    //                string.IsNullOrWhiteSpace(this.State) ? "" : this.State;
    //            string dspPostalCode =
    //                string.IsNullOrWhiteSpace(this.PostalCode) ? "" : this.PostalCode;

    //            return string
    //                .Format("{0} {1} {2} {3}", dspAddress, dspCity, dspState, dspPostalCode);
    //        }
    //    }
    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    //    {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }

    //}


    //// Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    //public class ApplicationUserManager : UserManager<ApplicationUser>
    //{
    //    public ApplicationUserManager(IUserStore<ApplicationUser> store)
    //        : base(store)
    //    {
    //    }

    //    public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
    //        IOwinContext context)
    //    {
    //        var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
    //        // Configure validation logic for usernames
    //        manager.UserValidator = new UserValidator<ApplicationUser>(manager)
    //        {
    //            AllowOnlyAlphanumericUserNames = false,
    //            RequireUniqueEmail = true
    //        };
    //        // Configure validation logic for passwords
    //        manager.PasswordValidator = new PasswordValidator
    //        {
    //            RequiredLength = 6,
    //            RequireNonLetterOrDigit = true,
    //            RequireDigit = true,
    //            RequireLowercase = true,
    //            RequireUppercase = true,
    //        };
    //        // Configure user lockout defaults
    //        manager.UserLockoutEnabledByDefault = true;
    //        manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
    //        manager.MaxFailedAccessAttemptsBeforeLockout = 5;
    //        // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
    //        // You can write your own provider and plug in here.
    //        manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<ApplicationUser>
    //        {
    //            MessageFormat = "Your security code is: {0}"
    //        });
    //        manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<ApplicationUser>
    //        {
    //            Subject = "SecurityCode",
    //            BodyFormat = "Your security code is {0}"
    //        });
    //        manager.EmailService = new EmailService();
    //        manager.SmsService = new SmsService();
    //        var dataProtectionProvider = options.DataProtectionProvider;
    //        if (dataProtectionProvider != null)
    //        {
    //            manager.UserTokenProvider =
    //                new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
    //        }
    //        return manager;
    //    }
    //}

    //// Configure the RoleManager used in the application. RoleManager is defined in the ASP.NET Identity core assembly
    //public class ApplicationRoleManager : RoleManager<IdentityRole>
    //{
    //    public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore)
    //        : base(roleStore)
    //    {
    //    }

    //    public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
    //    {
    //        return new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
    //    }
    //}
}
