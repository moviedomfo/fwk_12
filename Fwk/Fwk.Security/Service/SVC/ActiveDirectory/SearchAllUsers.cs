using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using Fwk.Security.BE;
using System.Data;
using Fwk.Security.Common;
using System.Data.SqlClient;
using Fwk.Security.ActiveDirectory;


namespace Fwk.Security.ISVC.SearchAllUsers_AD_Req
{

    [Serializable]
    public class SearchAllUsers_AD_Req : Request<Param>
    {
        public SearchAllUsers_AD_Req()
        {
            this.ServiceName = "SearchAllUsers_AD_ReqService";
        }
    }

    #region [BussinesData]



    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
   
        private string _DomainName;

        public string DomainName
        {
            get { return _DomainName; }
            set { _DomainName = value; }
        }
      
    }


    #endregion


    [Serializable]
    public class SearchAllUsersRes : Response<Result>
    {

    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
         private List<ADUser> _UserList;
        


        public List<ADUser> UserList
        {
            get { return _UserList; }
            set { _UserList = value; }
        }
    }
}
        