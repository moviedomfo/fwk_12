using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Fwk.Bases;
using back.Common.BE;
using System.Collections;

namespace back.Common.ISVC.SearchSalesOrderDetail
{

    #region [Request]
    [Serializable]
    public class SearchSalesOrderDetailReq : Request<Params>
    {
        public SearchSalesOrderDetailReq()
        {
            base.ServiceName = "SearchSalesOrderDetailService";
        }
    }

    #region [BussinesData]
    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Entity
    {
    }

    #endregion
    #endregion

    #region [Response]
    [Serializable]
    public class SearchSalesOrderDetailRes : Response<Result>
    {
    }
    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
        SalesOrderDetailList _SalesOrderDetailList;

        public SalesOrderDetailList SalesOrderDetailList
        {
            get { return _SalesOrderDetailList; }
            set { _SalesOrderDetailList = value; }
        }

        Measures _Times;

        public Measures Times
        {
            get { return _Times; }
            set { _Times = value; }
        }

    }
    
    #endregion
}
