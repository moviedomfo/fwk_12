using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Fwk.Security.Identity
{
    // Models used as parameters to AccountController actions.

    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }

    public class ChangePasswordBindingModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterBindingModel
    {
        [Required]
        [Display(Name = "email")]
        public string email { get; set; }
        [Required]
        [Display(Name = "userName")]
        public string userName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "password")]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        public string confirmPassword { get; set; }
    }

    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class RemoveLoginBindingModel
    {
        [Required]
        [Display(Name = "Login provider")]
        public string LoginProvider { get; set; }

        [Required]
        [Display(Name = "Provider key")]
        public string ProviderKey { get; set; }
    }

    public class SetPasswordBindingModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }



    public class AssignRolesToUserModel
    {
        public AssignRolesToUserModel()
        {
            roles = new List<string>();
        }
        [Required]
        [Display(Name = "userName")]
        public string userName { get; set; }

        
        //[Display(Name = "roles")]
        //public List<Guid> roles { get; set; }

        
        [Display(Name = "roles")]
        public List<string> roles { get; set; }

        public Guid InstitutionId { get; set; }
    }
    public class AssignRolesToRuleModel
    {
        public AssignRolesToRuleModel()
        {
            roles = new List<string>();
        }
        [Required]
        [Display(Name = "ruleName")]
        public string ruleName { get; set; }

        [Required]
        [Display(Name = "roles")]
        public List<string> roles { get; set; }


        public Guid InstitutionId { get; set; }
    }

    public class AssignRulesToRoleModel
    {
        public AssignRulesToRoleModel()
        {
            rules = new List<string>();
        }

        [Required]
        [Display(Name = "roleName")]
        public string roleName { get; set; }

        [Required]
        [Display(Name = "rules")]
        public List<string> rules { get; set; }


        public Guid InstitutionId { get; set; }
    }

    public class AssignRulesToCategoryModel
    {
        public AssignRulesToCategoryModel()
        {
            rules = new List<Guid>();
        }
        [Required]
        [Display(Name = "categoryId")]
        public Guid categoryId { get; set; }

        [Required]
        [Display(Name = "rules")]
        public List<Guid> rules { get; set; }


        public Guid InstitutionId { get; set; }
    }
}
