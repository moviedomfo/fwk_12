using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;


namespace Fwk.Security.Identity.ISVC.SearchAllRoles
{
    
    public class SearchAllRolesReq : Request<Param>
    {
        public SearchAllRolesReq()
		{
            this.ServiceName = "SearchAllRolesService";
		}
    }

    #region [BussinesData]


    public class Param : Entity
    {

        private System.String _UserName;

        public System.String UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public Guid? InstitutionId { get; set; }



    }

    #endregion

    [Serializable]
    public class SearchAllRolesRes : Response<Result>
    {
    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
      

        public SecurityRoleBEList RolList { get; set; }
      

    }
}
