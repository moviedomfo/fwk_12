using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Exceptions;
using Fwk.Bases;
using back.BackEnd.DAC;
using back.Common.BE;

using System.Data.Common;
using System.Data;
using System.Collections;

namespace back.BackEnd.BC
{

    public class SampleBC : BaseBC
    {

        public SampleBC(string x)
            : base(x)
        { }

        public SalesOrderDetailList SearchSalesOrderDetail(out Measures pTimes)
        {
            double sqlCallTime;
            double mappingTime;
            Hashtable htStats;
            SalesOrderDetailList wSalesOrderDetailList = SampleDAC.Search(base.CompanyId, out mappingTime, out sqlCallTime, out htStats);

            pTimes = new Measures();
            // StringBuilder s = new StringBuilder();
            foreach (string stat in htStats.Keys)
            {
                //s.AppendLine("- " + stat + " = " + htStats[stat].ToString());
                pTimes.Add(stat, Convert.ToDecimal(htStats[stat]));
            }
            pTimes.Add("Sql_Exec_Query_Time", Convert.ToDecimal(sqlCallTime));
            pTimes.Add("Sql_To_Entity_Mapping_Time", Convert.ToDecimal(mappingTime));

            return wSalesOrderDetailList;
        }
    }
}
