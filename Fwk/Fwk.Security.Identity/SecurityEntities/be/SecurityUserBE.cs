using Fwk.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fwk.Security.Identity
{
    public class SecurityUserBE: BaseEntity
    {
        //
        // Resumen:
        //     User ID (Primary Key)
        public Guid Id { get; set; }
        //
        // Resumen:
        //     User name
        public string UserName { get; set; }

        //
        // Resumen:
        //     Email
        public virtual string Email { get; set; }
        //
        // Resumen:
        //     True if the email is confirmed, default is false
        public bool EmailConfirmed { get; set; }
        //
        // Resumen:
        //     The salted/hashed form of the user password
        public virtual string PasswordHash { get; set; }
        //
        // Resumen:
        //     A random value that should change whenever a users credentials have changed (password
        //     changed, login removed)
        public string SecurityStamp { get; set; }

        // Resumen:
        //     True if the phone number is confirmed, default is false
        public bool PhoneNumberConfirmed { get; set; }
        //
        // Resumen:
        //     Is two factor enabled for the user
        public bool TwoFactorEnabled { get; set; }
        //
        // Resumen:
        //     DateTime in UTC when lockout ends, any time in the past is considered not locked
        //     out.
        public DateTime? LockoutEndDateUtc { get; set; }
        //
        // Resumen:
        //     Is lockout enabled for this user
        public bool LockoutEnabled { get; set; }
        //
        // Resumen:
        //     Used to record failures for the purposes of lockout
        public int AccessFailedCount { get; set; }

          public DateTime? LastLogInDate { get; set; }
        
        //
        // Resumen:
        //     Navigation property for user roles
        public List<String> Roles { get; set; }
        ////
        //// Resumen:
        ////     Navigation property for user claims
        //public ICollection<SecurityClaim> Claims { get; }
        ////
        //// Resumen:
        ////     Navigation property for user logins
        //public virtual ICollection<SecurityLogin> Logins { get; }

    }


}
