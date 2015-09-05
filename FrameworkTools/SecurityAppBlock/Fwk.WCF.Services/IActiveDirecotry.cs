using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CentralizedSecurity.wcf.Contracts;

namespace CentralizedSecurity.wcf
{
    
    [ServiceContract]
    public interface IActiveDirecotry
    {
        /// <summary>
        /// Autentica contra un dominio las credenciales del usuario
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        LoogonUserResult Autenticate(string userName, string password, string domain);

        /// <summary>
        /// Verifica si existe un usuario en un dominio
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        [OperationContract]
        bool User_Exist(string userName, string domain);

        /// Verifica si existe un usuario en un dominio
        [OperationContract]
        ActiveDirectoryUser Retrive_User_ByName(string userName, string domain);

        /// Retorna todos los grupos de un determinado usuario
        [OperationContract]
        ActiveDirectoryGroup[] Retrive_User_Groups(string userName, string domain);

        /// Retorna todos los usuarios de un determinado grupo
        [OperationContract]
        ActiveDirectoryUser[] Retrive_Group_Users(string groupName, string domain);

        /// Retorna todos los usuarios de un determinado grupo
        [OperationContract]
        ActiveDirectoryGroup[] Retrive_Groups(string domain);

        /// Lista de dominios y su informacion LDAP
        [OperationContract]
        CentralizedSecurity.wcf.Contracts.DomainsUrl[] Retrive_DomainsUrl();

        [OperationContract]
        bool User_Reset_Password(string userName, string newPassword, string domain);
        [OperationContract]
        bool User_SetActivation(string userName, bool disabled, string domain);
        [OperationContract]
        bool User_Unlock(string userName, string domain);
        [OperationContract]
        bool User_Lock(string userName, string domain);
        [OperationContract]
        string Test();
    }




}
