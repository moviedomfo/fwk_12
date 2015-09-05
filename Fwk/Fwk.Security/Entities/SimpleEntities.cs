using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Principal;

using System.Windows.Forms;
using System.Web.Security;
using System.Xml.Serialization;
using Fwk.Bases;


namespace Fwk.Security.Common
{
    /// <summary>
    /// 
    /// </summary>
    [XmlInclude(typeof(User)), Serializable]
    public class User
    {

        string[] _Roles;

        public object ProviderId { get; set; }

        AuthenticationModeEnum _AuthenticationMode = AuthenticationModeEnum.WindowsIntegrated;



        public string DNI { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? ModifiedByUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? MustChangePassword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string _FirstName;

        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string[] Roles
        {
            get { return _Roles; }
            set { _Roles = value; }
        }
        /// <summary>
        /// Identificador de usuario int 32. No es la clave GUID. 
        /// Este valor es para comp'atibilidad con sistenmas existentes
        /// 
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Answer security password
        /// </summary>
        public string AnswerPassword { get; set; }

        /// <summary>
        /// Question security password
        /// </summary>
        public string QuestionPassword { get; set; }

        /// <summary>
        /// User Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// User comment or description
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Application name
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Last user activity
        /// </summary>
        public DateTime LastActivityDate { get; set; }

        /// <summary>
        /// Get User Lock
        /// </summary>
        public bool IsLockedOut { get; set; }

        /// <summary>
        /// User Approved 
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        /// User Email
        /// </summary>
        public String Email { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public AuthenticationModeEnum AuthenticationMode
        {
            get { return _AuthenticationMode; }
            set { _AuthenticationMode = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pMembershipUser"></param>
        public User(MembershipUser pMembershipUser)
        {
            UserId = 0;
            ProviderId = pMembershipUser.ProviderUserKey;
            UserName = pMembershipUser.UserName;
            LastActivityDate = pMembershipUser.LastActivityDate;
            IsLockedOut = pMembershipUser.IsLockedOut;
            IsApproved = pMembershipUser.IsApproved;
            Email = pMembershipUser.Email;
            Comment = pMembershipUser.Comment;
            QuestionPassword = pMembershipUser.PasswordQuestion;
            CreationDate = pMembershipUser.CreationDate;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pUserName"></param>
        public User(string pUserName)
        {
            UserId = 0;
            UserName = pUserName;

        }

        /// <summary>
        /// 
        /// </summary>
        public User()
        { UserId = 0; }
        /// <summary>
        /// Crea el array de roles.- Eleimina los qe exuisten 
        /// </summary>
        /// <param name="rolList"><see cref="RolList"/></param>
        public void AddRoles(RolList rolList)
        {
            _Roles = new String[rolList.Count];
            int i = 0;
            foreach (Rol r in rolList)
            {
                _Roles[i] = r.RolName;
                i++;
            }
        }

        /// <summary>
        /// Obtiene la lista de roles de usuarios en formato de RolList
        /// </summary>
        /// <returns></returns>
        public RolList GetRolList()
        {
            RolList lst = new RolList();
            foreach (string r in _Roles)
            {
                lst.Add(new Rol(r));
            }
            return lst;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [XmlRoot("UserList"), SerializableAttribute]
    public class UserList : List<User>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String[] GetArraNames()
        {
            StringBuilder list = new StringBuilder(); ;
            foreach (User r in this)
            {
                list.Append(r.UserName);
                list.Append(",");
            }
            list.Remove(list.Length - 1, list.Length);
            return list.ToString().Split(',');
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [XmlInclude(typeof(Rol)), Serializable]
    public class Rol
    {
        /// <summary>
        /// 
        /// </summary>
        public Rol() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        public Rol(string pname)
        {
            _RolName = pname;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public Rol(string name, string description)
        {
            _RolName = name;
            _Description = description;
        }
        String _RolName;
        /// <summary>
        /// 
        /// </summary>
        public String RolName
        {
            get { return _RolName; }
            set { _RolName = value; }
        }
        String _Description;
        /// <summary>
        /// 
        /// </summary>
        public String Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _RolName;
        }

    }
    [XmlRoot("RolList"), SerializableAttribute]
    public class RolList : List<Rol>
    {
        /// <summary>
        /// retorna los roles separados por coma
        /// </summary>
        /// <returns></returns>
        public String[] GetArrayNames()
        {

            StringBuilder list = new StringBuilder();
            if (this == null || this.Count == 0)
            {
                return new String[] { };
            }
            foreach (Rol r in this)
            {
                list.Append(r.RolName);
                list.Append(",");
            }

            list.Remove(list.Length - 1, 1);
            return list.ToString().Split(',');
        }
    }

}
