using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.DirectoryServices.ActiveDirectory;

namespace Fwk.Security.ActiveDirectory
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDirectoryService
    {
        /// <summary>
        /// Ej: 
        /// LDAP://domain/DC=xxx,DC=com
        /// LDAP://CORRSF71NT13.Datacom.org/DC=Datacom,DC=org
        /// LDAP://Pc1.alcoDatacom.com.ar/OU=Datacom Sabattini,dc=alcoDatacom,dc=com,dc=ar
        /// </summary>
        String LDAPPath { get; }
        /// <summary>
        /// LDAPUser property
        /// </summary>
        String LDAPUser { get; }
        /// <summary>
        /// LDAPPassword property
        /// This property is reading the LDAP Password from the config file.
        /// </summary>
        String LDAPPassword { get; }
        /// <summary>
        /// Dominio
        /// </summary>
        String LDAPDomain { get; }
        /// <summary>
        /// Obtiene un usuario por nombre sin tener en cuenta las credenciales del usuario
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        ADUser User_Get_ByName(String userName);
        /// <summary>
        /// Verifica si el usuario existe.- 
        /// </summary>
        /// <param name="userName">Nombre de loging de usuario</param>
        /// <returns></returns>
        bool User_Exists(string userName);
        /// <summary>
        /// Retorna los grupos a los que pertenece el usuario .-
        /// </summary>
        /// <param name="userName">Nombre completo del usuario</param>
        /// <returns></returns>
        List<ADGroup> User_SearchGroupList(String userName);
        /// <summary>
        /// Retorna la lista de usuarios pertenecientes a un determinado grupo
        /// </summary>
        /// <param name="groupName">Nombre del grupo</param>
        /// <returns></returns>
        LoginResult User_CheckLogin(string userName, string pPassword);
        /// <summary>
        /// Obtiene un ADGroup que representa un grupo 
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        ADGroup Group_GetByName(String pName);
        /// <summary>
        /// Obtiene todo los grupos pertenecientes al dominio.-
        /// </summary>
        List<ADGroup> Groups_GetAll();


        

    }
}
