using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Fwk.Security.BE;
using System.Xml.Serialization;
using System.Data.SqlClient;
using Fwk.Security.Common;



namespace Fwk.Security.ISVC.ValidateUserExist
{
    [Serializable]
    public class ValidateUserExistReq : Request<Params>
    {
        public ValidateUserExistReq()
        {
            this.ServiceName = "ValidateUserExistService";
        }
    }

    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Entity
    {
    
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
       
       
        //public AuthenticationModeEnum AuthenticationMode
        //{
        //    get
        //    {
        //        return _AuthenticationMode;
        //    }
        //    set
        //    {
        //        _AuthenticationMode = value;
        //    }
        //}
        //public bool IsEnvironmentUser
        //{
        //    get
        //    {
        //        return _IsEnvironmentUser;
        //    }
        //    set
        //    {
        //        _IsEnvironmentUser = value;
        //    }
        //}
        //public string Domain
        //{
        //    get
        //    {
        //        return _Domain;
        //    }
        //    set
        //    {
        //        _Domain = value;
        //    }
        //}

   

    }

    [Serializable]
    public class ValidateUserExistRes : Response<Result>
    {
    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {

        

        public bool Exist{get;set;}
        

    }
}

