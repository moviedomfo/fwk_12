using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Fwk.CentralizedSecurity.Contracts;
using Fwk.CentralizedSecurity.Service;
using System.Web.Services.Protocols;

namespace Fwk.CentralizedSecurity
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ActiveDirectory : System.Web.Services.WebService
    {

        [WebMethod]
        public LoogonUserResult Authenticate(string userName, string password, string domain)
        {
            return ActiveDirectoryService.User_Logon(userName, password, domain);
        }

        
        [WebMethod(Description = "Verifica si existe un usuario en un dominio")]
        public bool User_Exist(string userName, string domain)
        {
            return ActiveDirectoryService.UserExist(userName,  domain);
        }
        
        [WebMethod(Description = "Retorna un usuarios por nombre")]
        public ActiveDirectoryUser Retrive_User_ByName(string userName, string domain)
        {
            return ActiveDirectoryService.User_Info(userName, domain);
        }

        
        [WebMethod(Description = "Retorna todos los gripos de un determinado Usuario")]
        public ActiveDirectoryGroup[] Retrive_User_Groups(string userName, string domain)
        {
            return ActiveDirectoryService.GetGroupsFromUser(userName, domain);
        }



        [WebMethod(Description = "Retorna todos los usuarios de un determinado Grupo")]
        public ActiveDirectoryUser[] Retrive_Group_Users(string groupName,string domain)
        {
            return ActiveDirectoryService.GetUsersFromGroup(groupName,domain);
        }


        [WebMethod(Description="Retorna todos los grupos de un determinado dominio")]
        public ActiveDirectoryGroup[] Retrive_Groups(string domain)
        {
            return ActiveDirectoryService.GetGroups( domain);
        }


       

        [WebMethod(Description="Retorna informacion sobre dominios de la empresa")]
        public Fwk.CentralizedSecurity.Contracts.DomainsUrl[] Retrive_DomainsUrl()
        {
            return ActiveDirectoryService.GetAllDomainsUrl();
        }

        [WebMethod]
        [SoapDocumentMethod(OneWay = false)]
        public bool User_Reset_Password(string userName,string newPassword,string domain)
        {
            ActiveDirectoryService.User_Reset_Password(userName, newPassword, domain);
            return true;
        }
        //[WebMethod]
        //public bool User_Reset_Password_test(string userName,string newPassword,string domain)
        //{
        //    ActiveDirectoryService.User_Reset_Password(userName, newPassword, domain);
        //    return true;
        //}
        

        [WebMethod]
        public bool User_SetActivation(string userName, bool disabled, string domain)
        {
            ActiveDirectoryService.User_SetActivation(userName, disabled, domain);
            return true;
        }

        [WebMethod]
        public bool User_Unlock(string userName, string domain)
        {
            ActiveDirectoryService.User_Unlock(userName, domain);
            return true;
       
        }

        [WebMethod]
        public bool User_Lock(string userName, string domain)
        {
            ActiveDirectoryService.User_Lock(userName, domain);
            return true;
        }
        [WebMethod(Description = "Metodo solo para test.")]
        public string Test()
        {
            return "El servicio funciona correctamente";
        }

    }
}
