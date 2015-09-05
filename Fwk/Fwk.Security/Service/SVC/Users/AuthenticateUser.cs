using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Fwk.Security.BE;
using System.Xml.Serialization;
using System.Data.SqlClient;
using Fwk.Security.Common;



namespace Fwk.Security.ISVC.AuthenticateUser
{
    [Serializable]
    public class AuthenticateUserReq : Request<Params>
    {
        public AuthenticateUserReq()
        {
            this.ServiceName = "AuthenticateUserService";
        }
    }

    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Entity
    {
        /// <summary>
        /// No utilizado para la llamada al servicio solo se pone
        /// por que se debe utilizar si o si una clase en el request.
        /// </summary>
        string _Name;
        string _Password;
        AuthenticationModeEnum _AuthenticationMode;
        bool _IsEnvironmentUser;
        string _Domain;
        private List<SqlParameter> _CustomParameters;
        private String _CustomStoredProcedure;
        

        public string UserName
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }
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
        public bool IsEnvironmentUser
        {
            get
            {
                return _IsEnvironmentUser;
            }
            set
            {
                _IsEnvironmentUser = value;
            }
        }
        public string Domain
        {
            get
            {
                return _Domain;
            }
            set
            {
                _Domain = value;
            }
        }
        
        public List<SqlParameter> CustomParameters
        {
            get { return _CustomParameters; }
            set { _CustomParameters = value; }
        }

        public String CustomStoredProcedure
        {
            get { return _CustomStoredProcedure; }
            set { _CustomStoredProcedure = value; }
        }


    }

    [Serializable]
    public class AuthenticateUserRes : Response<Result>
    {
    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {        

        private System.Boolean _IsAuthenticated;
        private System.Data.DataSet _UserCustomInfo;
        private Fwk.Security.Common.RolList _RolList;
        private User _UserInfo;
  


		 

        public User UserInfo
        {
            get
            {
                return _UserInfo;
            }
            set
            {
                _UserInfo = value;
            }
        }

        public Fwk.Security.Common.RolList RolList
        {
            get
            {
                return _RolList;
            }
            set
            {
                _RolList = value;
            }
        }

        public System.Data.DataSet UserCustomInfo
        {
            get
            {
                return _UserCustomInfo;
            }
            set
            {
                _UserCustomInfo = value;
            }
        }
        
        public bool IsAuthenticated
        {
            get { return _IsAuthenticated; }
            set { _IsAuthenticated = value; }
        }

    }
}

