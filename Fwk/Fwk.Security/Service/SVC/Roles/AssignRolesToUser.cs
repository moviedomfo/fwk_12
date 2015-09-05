using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using Fwk.Security.Common;

namespace Fwk.Security.ISVC.AssignRolesToUser
{

    [Serializable]
    public class AssignRolesToUserReq : Request<Param>
    {
        public AssignRolesToUserReq()
        {
            this.ServiceName = "AssignRolesToUserService";
        }
    }


    #region [BussinesData]

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        #region [Private Members]
        private System.String _Username;
        private RolList _RolList = new RolList ();
      
        private System.String _ApplicationName;
 

        #endregion

        #region [Properties]

        #region [Username]

        public System.String Username
        {
            get { return _Username; }
            set { _Username = value; }
        }
        #endregion
      

        public RolList RolList
        {
            get { return _RolList; }
            set { _RolList = value; }
        }
       
        
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
     

        #endregion

     

    }

    #endregion


    [Serializable]
    public class AssignRolesToUserRes : Response<Result>
    {
       
    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {

    }
}