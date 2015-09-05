using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fwk.Security.ActiveDirectory;
using Fwk.Exceptions;
using Fwk.CentralizedSecurity.Contracts;

namespace Fwk.CentralizedSecurity.Service
{
    public class ActiveDirectoryService
    {
       public static string CnnStringName =  "ActiveDirectory";
       static bool  performCustomWindowsContextImpersonalization= false;
       static ActiveDirectoryService()
       {
           //if (System.Configuration.ConfigurationManager.AppSettings["FwkImpersonate"]!=null)
           // performCustomWindowsContextImpersonalization =Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["FwkImpersonate"]);
       }

        internal static LoogonUserResult User_Logon(string userName, string password, string domain)
        {
            LoogonUserResult loogonUserResult = new LoogonUserResult();
            loogonUserResult.Autenticated = false;
            try
            {
                LDAPHelper _ADHelper = new LDAPHelper(domain, ActiveDirectoryService.CnnStringName, true, false);
                TechnicalException logError = null;

                loogonUserResult.LogResult = _ADHelper.User_Logon(userName, password, out logError).ToString();

                if (logError != null)
                    loogonUserResult.ErrorMessage = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(logError);
                else
                {
                    loogonUserResult.ErrorMessage = string.Empty;
                    loogonUserResult.Autenticated = true;
                }


            }
            catch (Exception ex)
            {
                loogonUserResult.ErrorMessage = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);


            }
            return loogonUserResult;
        }

        internal static ActiveDirectoryGroup[] GetGroupsFromUser(string userName, string domain)
        {
            ADHelper ad = new ADHelper(domain, ActiveDirectoryService.CnnStringName);
     
            List<ADGroup> list = ad.User_SearchGroupList(userName);
            ad.Dispose();
            if (list.Count != 0)
            {
                var activeDirectoryGroupList = from g in list select new ActiveDirectoryGroup(g);

                return activeDirectoryGroupList.ToArray<ActiveDirectoryGroup>();
            }
            else
                return null;
        }


        internal static ActiveDirectoryUser[] GetUsersFromGroup(string groupName, string domain)
        {
            ADHelper ad = new ADHelper(domain, ActiveDirectoryService.CnnStringName);

            List<ADUser> list = ad.Users_SearchByGroupName(groupName);

            ad.Dispose();
            if (list.Count != 0)
            {
                var userList = from u in list select new ActiveDirectoryUser(u);

                return userList.ToArray<ActiveDirectoryUser>();
            }
            else
                return null;
        }


        internal static bool UserExist(string userName, string domain)
        {
            ADHelper ad = new ADHelper(domain, ActiveDirectoryService.CnnStringName, performCustomWindowsContextImpersonalization);

            bool exist= ad.User_Exists(userName);

            ad.Dispose();

            return exist;
        }

        internal static ActiveDirectoryGroup[] GetGroups(string domain)
        {
            ADHelper ad = new ADHelper(domain, ActiveDirectoryService.CnnStringName, performCustomWindowsContextImpersonalization);
     
            List<ADGroup> list = ad.Groups_GetAll();

            ad.Dispose();

            if (list.Count != 0)
            {
                var userList = from u in list select new ActiveDirectoryGroup(u);

                return userList.ToArray<ActiveDirectoryGroup>();
            }
            else
                return null;
        }

       

        internal static void User_Unlock(string userName, string domain)
        {
            ADHelper ad = new ADHelper(domain, ActiveDirectoryService.CnnStringName, performCustomWindowsContextImpersonalization);
            
            //ad.User_SetLockedStatus(userName, false);
            ad.User_Unlock(userName);

            ad.Dispose();
        }

        internal static void User_Lock(string userName, string domain)
        {
            ADHelper ad = new ADHelper(domain, ActiveDirectoryService.CnnStringName, performCustomWindowsContextImpersonalization);

            ad.User_SetLockedStatus(userName,true);
        }


        internal static ActiveDirectoryUser User_Info(string userName, string domain)
        {
            ADHelper ad = new ADHelper(domain, ActiveDirectoryService.CnnStringName, performCustomWindowsContextImpersonalization);

          ADUser usr =  ad.User_Get_ByName(userName);
          if (usr != null)
              return null;
          return new ActiveDirectoryUser(usr);
        }

        internal static void User_SetActivation(string userName, bool disabled, string domain)
        {
            ADHelper ad = new ADHelper(domain, ActiveDirectoryService.CnnStringName, performCustomWindowsContextImpersonalization);

             ad.User_SetActivation(userName, disabled);
             ad.Dispose();
        }

        internal static void User_Reset_Password(string userName, string newPassword, string domain)
        {
            ADHelper ad = new ADHelper(domain, ActiveDirectoryService.CnnStringName, performCustomWindowsContextImpersonalization);

            ad.User_ResetPwd(userName, newPassword ,true);

            ad.Dispose();
        }





        internal static Fwk.CentralizedSecurity.Contracts.DomainsUrl[] GetAllDomainsUrl()
        {


            List<DomainUrlInfo> auxlist = ADHelper.DomainsUrl_GetList2(System.Configuration.ConfigurationManager.ConnectionStrings[ActiveDirectoryService.CnnStringName].ConnectionString);

            if (auxlist.Count != 0)
            {
                var list = from d in auxlist select new Fwk.CentralizedSecurity.Contracts.DomainsUrl(d);

                return list.ToArray<Fwk.CentralizedSecurity.Contracts.DomainsUrl>();
            }
            else
                return null;


        }

    }

    
}
