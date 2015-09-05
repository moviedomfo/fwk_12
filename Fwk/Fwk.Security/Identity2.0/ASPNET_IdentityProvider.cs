using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
namespace Fwk.Security.Identity
{
    public class ASPNET_Identity2:Fwk.Security.Common.IFwkSecurityManageProvider
    {
        public string ProviderName { get; set; }
     
        public void AssignRolesToUser(Common.RolList rolList, string userName)
        {
            //string userId = User.Identity.GetUserId();
            //ApplicationDbContext db = new ApplicationDbContext();
            //var role = (from r in db.Roles where r.Name.Contains("Admin") select r).FirstOrDefault();
            //var users = db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id)).ToList();
            //if (users.Find(x => x.Id == userId) != null)
            //{
            //    // User is in the Admin Role
            //}
            //else
            //{

            //    //User is not in the Admin Role
            //}
        }

        public bool ChangeUserPassword(string userName, string pOldPassword, string pNewPassword)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(string userName, string password, string email)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string userName)
        {
            throw new NotImplementedException();
        }

        public List<Common.User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Common.User GetUserAnRoles(string userName)
        {
            throw new NotImplementedException();
        }

        public List<Common.User> GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

     

        public void RemoveUserFromRole(string userName, string roleName)
        {
            throw new NotImplementedException();
        }

        public void RemoveUserFromRoles(string userName, Common.RolList rolList)
        {
            throw new NotImplementedException();
        }

        public void RemoveUsersFromRole(string[] usersName, string roleName)
        {
            throw new NotImplementedException();
        }

        public void RemoveUsersFromRoles(string[] usersName, Common.RolList rolList)
        {
            throw new NotImplementedException();
        }

        public string ResetUserPassword(string userName)
        {
            throw new NotImplementedException();
        }

        public bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(Common.User user, string userName)
        {
            throw new NotImplementedException();
        }

        public bool UserExist(string userName)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUser(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
