using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using Fwk.Security.Common;

namespace Fwk.Security.ISVC.SearchRolesForUser
{

    [Serializable]
    public class SearchRolesForUserReq : Request<Param>
    {
        public SearchRolesForUserReq()
        {
            this.ServiceName = "SearchRolesForUserService";
        }
    }
    [Serializable]
    public class SearchRolesForUserRes : Response<Result>
    {

    }

    #region [BussinesData]
    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        private System.String _Username;
        #region [Username]

        public System.String Username
        {
            get { return _Username; }
            set { _Username = value; }
        }
        #endregion

        private System.String _ApplicationName;
        #region [ApplicationName]
        public System.String ApplicationName
        {
            get
            {
                return _ApplicationName;
            }
            set
            {
                _ApplicationName = value;
            }
        }
        #endregion

    }
    [XmlInclude(typeof(Param)), Serializable]
    public class Result : Entity
    {
        #region [Private Members]
      
        private RolList _RolList = new RolList();

        


        #endregion

        #region [Properties]

       


        public RolList RolList
        {
            get { return _RolList; }
            set { _RolList = value; }
        }

       

        #endregion



    }

    #endregion




}
       