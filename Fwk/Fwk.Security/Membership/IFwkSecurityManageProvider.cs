using System;
namespace Fwk.Security.Common
{
    public interface IFwkSecurityManageProvider
    {
        void AssignRolesToUser(Fwk.Security.Common.RolList rolList, string userName);
        bool ChangeUserPassword(string userName, string pOldPassword, string pNewPassword);
        //MembershipEnums CheckUserStatus(string userName, string password);
        void CreateUser(string userName, string password, string email);
        void DeleteUser(string userName);
        System.Collections.Generic.List<Fwk.Security.Common.User> GetAllUsers();
        Fwk.Security.Common.User GetUserAnRoles(string userName);
        System.Collections.Generic.List<Fwk.Security.Common.User> GetUsersInRole(string roleName);
        string ProviderName { get; set; }
        void RemoveUserFromRole(string userName, string roleName);
        void RemoveUserFromRoles(string userName, Fwk.Security.Common.RolList rolList);
        void RemoveUsersFromRole(string[] usersName, string roleName);
        void RemoveUsersFromRoles(string[] usersName, Fwk.Security.Common.RolList rolList);
        string ResetUserPassword(string userName);
        bool UnlockUser(string userName);
        void UpdateUser(Fwk.Security.Common.User user, string userName);
        bool UserExist(string userName);
        bool ValidateUser(string userName, string password);
    }
}
