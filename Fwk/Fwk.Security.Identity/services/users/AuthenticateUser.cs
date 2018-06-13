using System;
using Fwk.Bases;
using Fwk.Security.Identity;

namespace Fwk.Security.Identity.ISVC.AuthenticateUser
{
    
    public class AuthenticateUserReq : Request<Params>
    {
        public AuthenticateUserReq()
        {
            this.ServiceName = "AuthenticateUserService";
        }
    }

    
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
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string SecurityProviderName { get; set; }


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
        
       


    }

    [Serializable]
    public class AuthenticateUserRes : Response<Result>
    {
    }

    public class Result : Entity
    {
        public AuthenticationTicketResult Ticket { get; set; }
    }
}

