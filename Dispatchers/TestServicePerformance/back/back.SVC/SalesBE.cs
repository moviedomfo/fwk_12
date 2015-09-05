using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Fwk.Bases;

namespace back.Common.BE
{

 
  

        [XmlRoot("SalesOrderDetailList"), SerializableAttribute]
        public class SalesOrderDetailList : Entities<SalesOrderDetail>
        { }

        [XmlInclude(typeof(SalesOrderDetail)), Serializable]
        public class SalesOrderDetail : Entity
        {
            #region [Private Members]
            private System.Int32 _SalesOrderID;

            private System.Int32 _SalesOrderDetailID;

            private System.String _CarrierTrackingNumber;

            private System.Int32 _OrderQty;

            private System.Int32 _ProductID;

            private System.Int32 _SpecialOfferID;

            private System.Double _UnitPrice;

            private System.Double _UnitPriceDiscount;

            private System.Int32 _LineTotal;

            private Guid _rowguid;

            private System.DateTime _ModifiedDate;


            #endregion

            #region [Properties]
            #region [SalesOrderID]
            public System.Int32 SalesOrderID
            {
                get { return _SalesOrderID; }
                set { _SalesOrderID = value; }
            }
            #endregion


            #region [SalesOrderDetailID]
            public System.Int32 SalesOrderDetailID
            {
                get { return _SalesOrderDetailID; }
                set { _SalesOrderDetailID = value; }
            }
            #endregion


            #region [CarrierTrackingNumber]
            public System.String CarrierTrackingNumber
            {
                get { return _CarrierTrackingNumber; }
                set { _CarrierTrackingNumber = value; }
            }
            #endregion


            #region [OrderQty]
            public System.Int32 OrderQty
            {
                get { return _OrderQty; }
                set { _OrderQty = value; }
            }
            #endregion


            #region [ProductID]
            public System.Int32 ProductID
            {
                get { return _ProductID; }
                set { _ProductID = value; }
            }
            #endregion


            #region [SpecialOfferID]
            public System.Int32 SpecialOfferID
            {
                get { return _SpecialOfferID; }
                set { _SpecialOfferID = value; }
            }
            #endregion


            #region [UnitPrice]
            public System.Double UnitPrice
            {
                get { return _UnitPrice; }
                set { _UnitPrice = value; }
            }
            #endregion


            #region [UnitPriceDiscount]
            public System.Double UnitPriceDiscount
            {
                get { return _UnitPriceDiscount; }
                set { _UnitPriceDiscount = value; }
            }
            #endregion


            #region [LineTotal]
            public System.Int32 LineTotal
            {
                get { return _LineTotal; }
                set { _LineTotal = value; }
            }
            #endregion


            #region [rowguid]
            public Guid rowguid
            {
                get { return _rowguid; }
                set { _rowguid = value; }
            }
            #endregion


            #region [ModifiedDate]
            public System.DateTime ModifiedDate
            {
                get { return _ModifiedDate; }
                set { _ModifiedDate = value; }
            }
            #endregion



            #endregion

        }


    }





