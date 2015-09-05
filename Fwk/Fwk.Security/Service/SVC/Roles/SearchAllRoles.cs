using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;


namespace Fwk.Security.ISVC.SearchAllRoles
{
    [Serializable]
    public class SearchAllRolesReq : Request<Param>
    {
        public SearchAllRolesReq()
		{
            this.ServiceName = "SearchAllRolesService";
		}
    }

    #region [BussinesData]

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        
    private System.String _UserName;

    public System.String UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
       
        
                

    }

    #endregion

    [Serializable]
    public class SearchAllRolesRes : Response<Result>
    {
    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
        Fwk.Security.Common.RolList _RolList;

        public Fwk.Security.Common.RolList RolList
        {
            get { return _RolList; }
            set { _RolList = value; }
        }

    }
}
