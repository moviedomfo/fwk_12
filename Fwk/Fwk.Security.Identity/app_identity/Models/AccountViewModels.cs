using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace  Fwk.Security.Identity
{
    // Models returned by AccountController actions.
    public class LoginModel
    {
        [Required]
        [Display(Name = "userName")]
        //[EmailAddress]
        public string userName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "password")]
        public string password { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "email")]
        public string email { get; set; }

        
        [Display(Name = "Remember me?")]
        public bool rememberMe { get; set; }
    }
    public class LoginResultError
    {

        public string error { get; set; }
        public string error_description { get; set; }
    }
    public class AuthenticationTicketResult
    {
        public string Status { get; set; }
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string refresh_token { get; set; }

        public string client_id { get; set; }

         public string userName { get; set; }
        public Guid userId { get; set; }
        public string email { get; set; }
        
        public DateTime LastLogInDate { get; set; }
        

        public DateTime issued { get; set; }
        public DateTime expires { get; set; }

        //public SecurityUserBE user { get; set; }
        public string roles { get; set; }
        public string Message { get; set; }
        public SecuritySignInStatus StatusEnum()
        {
            return (SecuritySignInStatus)Enum.Parse(typeof(SecuritySignInStatus), this.Status);
        }
        public List<string> GetRoles()
        {
            return roles.Split(',').ToList();
        }
    }
    public class LoginResult
    {
        public string Status { get; set; }
        public string Message { get; set; }
        //public string token { get; set; }
        public SecurityUser User { get; set; }
        //public SecuritySignInStatus StatusEnum()
        //{
        //    return (SecuritySignInStatus)Enum.Parse(typeof(SecuritySignInStatus), this.Status);
        //}

    }    
    
    //
    // Summary:
    //     Possible results from a sign in attempt
    public enum SecuritySignInStatus
    {
        //
        // Summary:
        //     Sign in was successful
        Success = 0,
        //
        // Summary:
        //     User is locked out
        LockedOut = 1,
        //
        // Summary:
        //     Sign in requires addition verification (i.e. two factor)
        RequiresVerification = 2,
        //
        // Summary:
        //     Sign in failed
        Failure = 3
    }
    public class ExternalLoginViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string State { get; set; }
    }

    public class ManageInfoViewModel
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
    }

    public class UserInfoViewModel
    {
        public string Email { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
    }

    public class UserLoginInfoViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}
