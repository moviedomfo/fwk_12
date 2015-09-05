using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fwk.Security.Common;

namespace Fwk.Security.Membership
{
    /// <summary>
    /// Implements Asp Net Membership provider
    /// </summary>
    public class FwkMembershipProvider : Fwk.Security.Common.IFwkSecurityManageProvider
    {
        public string ProviderName { get; set; }

        public Boolean ValidateUser(string userName, string password)
        {
            return FwkMembership.ValidateUser(userName, password, ProviderName);
        }

        public MembershipEnums CheckUserStatus(string userName, string password)
        {
            return FwkMembership.CheckUserStatus(userName, password, ProviderName);
        }

        public void CreateUser(string userName, string password, string email)
        {
            if (String.IsNullOrEmpty(email))
                FwkMembership.CreateUser(userName, password, email, ProviderName);
            else
                FwkMembership.CreateUser(userName, password, ProviderName);
        }


        public void DeleteUser(String userName)
        {
            FwkMembership.DeleteUser(userName, ProviderName);
        }

        public void UpdateUser(User user, string userName)
        {
            FwkMembership.UpdateUser(user, userName, ProviderName);
        }

        public List<User> GetAllUsers()
        {
            return FwkMembership.GetAllUsers(ProviderName);
        }




        public User GetUserAnRoles(String userName)
        {
            return FwkMembership.GetUserAnRoles(userName, ProviderName);
        }

        public  Boolean UserExist(String userName)
        {
            return FwkMembership.UserExist(userName, ProviderName);
        }
        public bool UnlockUser(String userName)
        {
            return FwkMembership.UnlockUser(userName, ProviderName);
        }
        public String ResetUserPassword(String userName)
        {
            return FwkMembership.ResetUserPassword(userName, ProviderName);
        }
        public Boolean ChangeUserPassword(String userName, String pOldPassword, String pNewPassword)
        {
            return FwkMembership.ChangeUserPassword(userName, pOldPassword, pNewPassword, ProviderName);
        }
        public List<User> GetUsersInRole(String roleName)
        {
            return FwkMembership.GetUsersInRole(roleName, ProviderName);
        }
        public void AssignRolesToUser(RolList rolList, String userName)
        {
            FwkMembership.CreateRolesToUser(rolList, userName, ProviderName);
        }

        public void RemoveUserFromRole(String userName, String roleName)
        {
            FwkMembership.RemoveUserFromRole(userName, roleName, ProviderName);
        }

        public void RemoveUserFromRoles(String userName, RolList rolList)
        {
            FwkMembership.RemoveUserFromRoles(userName, rolList, ProviderName);
        }

        public void RemoveUsersFromRole(String[] usersName, String roleName)
        {
            FwkMembership.RemoveUsersFromRole(usersName, roleName, ProviderName);
        }

        public void RemoveUsersFromRoles(String[] usersName, RolList rolList)
        {
            FwkMembership.RemoveUsersFromRoles(usersName, rolList, ProviderName);
        }

    }
}
