using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Exceptions;
using Fwk.HelperFunctions;
using Fwk.Caching;
using Fwk.Bases;
using back.Common.ISVC.SearchSalesOrderDetail;
using back.Common.BE;

namespace TestServicePerformance
{

    public class ControllerTest
    {
        public static FwkSimpleStorageBase<Store> Storage = new FwkSimpleStorageBase<Store>();


        public static SearchSalesOrderDetailRes SearchSalesOrderDetailRes()
        {
            SearchSalesOrderDetailReq wRequest = new SearchSalesOrderDetailReq();

            return wRequest.ExecuteService<SearchSalesOrderDetailReq, SearchSalesOrderDetailRes>(wRequest);


        }

      
    }
}
