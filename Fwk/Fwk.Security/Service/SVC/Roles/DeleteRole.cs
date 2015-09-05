
        using System;
        using System.Collections.Generic;
        using Fwk.Bases;
        using System.Xml.Serialization;


namespace Fwk.Security.ISVC.DeleteRole
{

    [Serializable]
    public class DeleteRoleReq : Request<Param>
    {
        public DeleteRoleReq()
        {
            this.ServiceName = "DeleteRoleService";
        }
    }
    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        string  _RolName;

        public string  RolName
        {
            get { return _RolName; }
            set { _RolName = value; }
        }

      
    }

    [Serializable]
    public class DeleteRoleRes : Request<Result>
    {
      
    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {

    }

}
        