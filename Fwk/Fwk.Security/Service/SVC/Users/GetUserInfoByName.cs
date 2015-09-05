using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Fwk.Security.Common;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace Fwk.Security.ISVC.GetUserInfoByParams
{
    [Serializable]
    public class GetUserInfoByParamsReq : Request<Param>
    {
        public GetUserInfoByParamsReq()
        {
            this.ServiceName = "GetUserInfoByParams";
        }
    }

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        /// <summary>
        /// No utilizado para la llamada al servicio solo se pone
        /// por que se debe utilizar si o si una clase en el request.
        /// </summary>
        string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        int? _UserId;

        public int? UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
    }


    [Serializable]
    public class GetUserInfoByParamsRes : Response<Result>
    { }
    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
       
        private Fwk.Security.Common.RolList _RolList;
        private User _UserInfo;


		public User UserInfo
		{
			get
			{
				return _UserInfo;
			}
			set
			{
				_UserInfo = value;
			}
		}

		public Fwk.Security.Common.RolList RolList
		{
			get
			{
				return _RolList;
			}
			set
			{
				_RolList = value;
			}
		}

    
    }
}

