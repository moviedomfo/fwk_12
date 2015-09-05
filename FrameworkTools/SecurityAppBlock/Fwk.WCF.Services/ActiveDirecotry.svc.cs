using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CentralizedSecurity.wcf.Service;
using CentralizedSecurity.wcf.Contracts;

namespace CentralizedSecurity.wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ActiveDirecotry" in code, svc and config file together.
    public class ActiveDirecotry : IActiveDirecotry
    {


        #region IActiveDirecotry Members


        public LoogonUserResult Autenticate(string userName, string password, string domain)
        {
            return ActiveDirectoryService.User_Logon(userName, password, domain);
        }



        public bool User_Exist(string userName, string domain)
        {
            return ActiveDirectoryService.UserExist(userName, domain);
        }


        public ActiveDirectoryUser Retrive_User_ByName(string userName, string domain)
        {
            return ActiveDirectoryService.User_Info(userName, domain);
        }


        
        public ActiveDirectoryGroup[] Retrive_User_Groups(string userName, string domain)
        {
            return ActiveDirectoryService.GetGroupsFromUser(userName, domain);
        }



        
        public ActiveDirectoryUser[] Retrive_Group_Users(string groupName, string domain)
        {
            return ActiveDirectoryService.GetUsersFromGroup(groupName, domain);
        }


        
        public ActiveDirectoryGroup[] Retrive_Groups(string domain)
        {
            return ActiveDirectoryService.GetGroups(domain);
        }




        public DomainsUrl[] Retrive_DomainsUrl()
        {
            return ActiveDirectoryService.GetAllDomainsUrl();
        }

       
        
        public bool User_Reset_Password(string userName, string newPassword, string domain)
        {
            ActiveDirectoryService.User_Reset_Password(userName, newPassword, domain);
            return true;
        }
        


       
        public bool User_SetActivation(string userName, bool disabled, string domain)
        {
            ActiveDirectoryService.User_SetActivation(userName, disabled, domain);
            return true;
        }

       
        public bool User_Unlock(string userName, string domain)
        {
            ActiveDirectoryService.User_Unlock(userName, domain);
            return true;

        }

       
        public bool User_Lock(string userName, string domain)
        {
            ActiveDirectoryService.User_Lock(userName, domain);
            return true;
        }
        
        public string Test()
        {
            return "El servicio funciona correctamente";
        }


        #endregion
    }
}
