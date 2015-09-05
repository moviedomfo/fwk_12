using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fwk.ConfigData;
using System.Data.Linq;

namespace VivaldiSite.DAC
{
    public class DataCoreDAC
    {
       
        internal static void Dispatcher_Create(fwk_ServiceDispatcher disp)
        {
            using(Fwk.ConfigData.FwkDatacontext dc = new Fwk.ConfigData.FwkDatacontext   ())
            {

                dc.fwk_ServiceDispatchers.InsertOnSubmit(disp);
                dc.SubmitChanges();
            }
        
        }

        internal static bool Dispatcher_Exist(string dispName, string url)
        {
            using (Fwk.ConfigData.FwkDatacontext dc = new Fwk.ConfigData.FwkDatacontext())
            {
                if (!string.IsNullOrEmpty(dispName))
                    return dc.fwk_ServiceDispatchers.Any(
                        p=>p.InstanseName.Equals(dispName));


                if (!string.IsNullOrEmpty(url))
                    return dc.fwk_ServiceDispatchers.Any(
                        p => p.InstanseName.Equals(url));
            }
            return true;
        }

        internal static void Dispatcher_Update(fwk_ServiceDispatcher disp)
        {

            using (Fwk.ConfigData.FwkDatacontext dc = new Fwk.ConfigData.FwkDatacontext())
            {
                var disp_db = dc.fwk_ServiceDispatchers.Where(p => p.InstanseName.Equals(disp.InstanseId)).FirstOrDefault();

                disp_db.AuditMode = disp.AuditMode;
                disp_db.CompanyName = disp.CompanyName;
                disp_db.HostIp = disp.HostIp;
                disp_db.HostName = disp.HostName;
                disp_db.InstanseName = disp.InstanseName;
                disp_db.Logo = disp.Logo;
                disp_db.Port = disp.Port;
                disp_db.Url_URI = disp.Url_URI;

                dc.SubmitChanges();
            }
        }

        internal static fwk_ServiceDispatcher Dispatcher_Get(string pInstanseName)
        {
            using (Fwk.ConfigData.FwkDatacontext dc = new Fwk.ConfigData.FwkDatacontext())
            {
                return dc.fwk_ServiceDispatchers.Where(p => p.InstanseName.Equals(pInstanseName)).FirstOrDefault();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal static List<fwk_ServiceDispatcher> Dispatcher_List()
        {
            using (Fwk.ConfigData.FwkDatacontext dc = new Fwk.ConfigData.FwkDatacontext())
            {
                return dc.fwk_ServiceDispatchers.ToList < fwk_ServiceDispatcher>();
            }
        }
    }
}