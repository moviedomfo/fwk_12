using System;
using System.Xml.Serialization;
using Fwk.Bases;


namespace Fwk.Security.BE
{
    /// <summary>
    /// Colección de UserInfo
    /// </summary>
    [XmlRoot("UserInfoList"), SerializableAttribute]
    public class UserInfoList : Entities<UserInfo>
    {
        #region [Methods]
        /// <summary>
        /// Metodo estatico que retorna un objeto UsersList apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>UsersList</returns>
        public static UserInfoList GetUsersListFromXml(String pXml)
        {
            return GetFromXml<UserInfoList>(pXml);
        }
        #endregion
    }

    /// <summary>
    /// Clase ReadOnlyque contiene 
    /// información breve sobre un usuario.
    /// </summary>
    [XmlInclude(typeof(UserInfo)), Serializable]
    public class UserInfo : Entity
    {
        #region [Private Members]

        private Int32? _userId = 0;
        private String _name;
        private string _fullName;
        private Boolean _ActiveFlag;
        string[] _Roles;
        private bool _MustChangePassword;
        private AuthenticationModeEnum _AuthenticationMode;
        #endregion

        #region [Properties]

        #region [UserId]
        /// <summary>
        /// Identificador del usuario.
        /// </summary>
        public Int32? UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        #endregion

        #region [Name]
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion

        #region [FullName]
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public String FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        #endregion

        #region [ActiveFlag]
        /// <summary>
        /// Obtiene o establece si el usuario esta activo.
        /// </summary>
        public Boolean ActiveFlag
        {
            get { return _ActiveFlag; }
            set { _ActiveFlag = value; }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public string[] Roles
        {
            get { return _Roles; }
            set { _Roles = value; }
        }

        public bool MustChangePassword
        {
            get { return _MustChangePassword; }
            set { _MustChangePassword = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public AuthenticationModeEnum AuthenticationMode
        {
            get
            {
                return _AuthenticationMode;
            }
            set
            {
                _AuthenticationMode = value;
            }
        }
        #endregion

        #region [Constructors]

        /// <summary>
        /// Inicializa una nueva instancia de la clase UserInfo
        /// con valores por defecto (vacios).
        /// </summary>
        public UserInfo()
        {
            _userId = -1;
            _name = string.Empty;
            _fullName = string.Empty;

        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase UserInfo
        /// </summary>
        /// <param name="userId">Identificador del usuario</param>
        /// <param name="userName">Nombre del usuario</param>
        /// <param name="fullName">Nombre completo del usuario</param>
        public UserInfo(Int32 userId, string userName, string fullName)
        {
            _userId = userId;
            _name = userName;
            _fullName = fullName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        public UserInfo(Int32 userId, string userName)
        {
            _userId = userId;
            _name = userName;
            _fullName = string.Empty;
        }

        #endregion

        #region [Methods]
        /// <summary>
        /// Metodo estatico que retorna un objeto UsersBE apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>UsersBE</returns>
        public static UserInfo GetUserInfoFromXml(String pXml)
        {
            return (UserInfo)Entity.GetFromXml<UserInfo>( pXml);
        }
        #endregion
    }
}
