
        
         using System;
        using System.Collections.Generic;
        using Fwk.Bases;
        using System.Xml.Serialization;

namespace Fwk.Security.ISVC.RemoveUserFromRole
{

    [Serializable]
    public class RemoveUserFromRoleReq : Request<Param>
    {
        public RemoveUserFromRoleReq()
        {
            this.ServiceName = "RemoveUserFromRoleSerivice";
        }
    }
    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        string _RolName;

        public string RolName
        {
            get { return _RolName; }
            set { _RolName = value; }
        }
        string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

    }

    
    [Serializable]
    public class RemoveUserFromRoleRes : Request<Result>
    {

    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {

    }

}
        