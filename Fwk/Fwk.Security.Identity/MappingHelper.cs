using Fwk.Security.Common;
using Fwk.Security.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fwk.Security.Identity
{
    public class MappingHelper
    {
        /// <summary>
        /// Mapea el usuario y los roles del mismo
        /// </summary>
        /// <param name="secUser"></param>
        /// <returns></returns>
        public static User Map_SecurityUser_to_UserInfo(SecurityUser secUser)
        {

            User userInfo = new User();
            userInfo.ProviderId = secUser.Id;
            userInfo.UserName = secUser.UserName;
            userInfo.Email = secUser.Email;
            userInfo.CreationDate = secUser.CreatedDate;
            userInfo.Roles = secUser.GetRolesArray().ToArray();
            //RolList roles = new RolList();
            //if (secUser.SecurityRoles != null)
            //{
            //    secUser.SecurityRoles.ToList().ForEach(item => {
            //        roles.Add(new Rol { RolName = item.Name, Description = item.Description });
            //    });
            //}
            return userInfo;
        }
        public static SecurityUser Map_UserInfo_to_SecurityUser(User userInfo)
        {
            SecurityUser secUser = new SecurityUser();
            if (userInfo.ProviderId != null)
                secUser.Id = (Guid)userInfo.ProviderId;
            secUser.UserName = userInfo.UserName;
            secUser.Email = userInfo.Email;
            secUser.CreatedDate = userInfo.CreationDate.Value;

            
            if (userInfo.Roles != null)
            {

                userInfo.Roles.ToList().ForEach(item =>
                {
                    secUser.SecurityRoles.Add(new SecurityRole { Name = item });
                });
            }
            return secUser;
        }
    }
}
