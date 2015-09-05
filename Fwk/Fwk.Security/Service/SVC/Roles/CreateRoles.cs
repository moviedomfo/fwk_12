using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using Fwk.Security.BE;
using Fwk.Security.Common;

namespace Fwk.Security.ISVC.CreateRole
{
	
	[Serializable]
    public class CreateRoleReq : Request<Param>
	{
        public CreateRoleReq()
		{
            this.ServiceName = "CreateRoleService";
		}
	}

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        Fwk.Security.Common.Rol _Rol = new Rol ();

        public Fwk.Security.Common.Rol Rol
        {
            get { return _Rol; }
            set { _Rol = value; }
        }
    }


	[Serializable]
    public class CreateRoleRes : Response<Result>
	{
		
	}

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
      

    }
}
       