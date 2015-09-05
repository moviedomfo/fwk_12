//----------------------------
// 
//----------------------------

using System;
using System.Data;
using System.Collections.Generic;
using Fwk.Bases;
using back.Common.BE;
using back.BackEnd.BC;
using back.Common.ISVC.SearchSalesOrderDetail;
using System.Collections;




namespace back.BackEnd.SVC
{
    public class SearchSalesOrderDetailService : BusinessService<SearchSalesOrderDetailReq, SearchSalesOrderDetailRes>
    {
        public override SearchSalesOrderDetailRes Execute(SearchSalesOrderDetailReq req)
        {
            SearchSalesOrderDetailRes res = new SearchSalesOrderDetailRes();


           // SampleBC BC = new SampleBC(req.ContextInformation.AppId);
            Measures m = new Measures ();
        
        
            
            res.BusinessData.SalesOrderDetailList = new SalesOrderDetailList();//BC.SearchSalesOrderDetail(out m );

            SalesOrderDetail wSalesOrderDetail = new SalesOrderDetail();
            wSalesOrderDetail.CarrierTrackingNumber = "9000000";
            wSalesOrderDetail.LineTotal = 13;
            wSalesOrderDetail.OrderQty = 3333333;
            wSalesOrderDetail.ProductID = 9000;

            wSalesOrderDetail.rowguid = Guid.NewGuid();
            wSalesOrderDetail.SalesOrderID = 23;
            res.BusinessData.SalesOrderDetailList.Add(wSalesOrderDetail);

            wSalesOrderDetail = new SalesOrderDetail();
            wSalesOrderDetail.CarrierTrackingNumber = "3456234";
            wSalesOrderDetail.LineTotal = 23;
            wSalesOrderDetail.OrderQty = 4321;
            wSalesOrderDetail.ProductID = 9864;

            wSalesOrderDetail.rowguid = Guid.NewGuid();
            wSalesOrderDetail.SalesOrderID = 236;
            res.BusinessData.SalesOrderDetailList.Add(wSalesOrderDetail);

            res.BusinessData.Times = m;
            return res;
        }
    }
}
