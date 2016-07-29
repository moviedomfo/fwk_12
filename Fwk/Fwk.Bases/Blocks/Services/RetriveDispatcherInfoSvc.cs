
using Fwk.Bases;
using Fwk.Bases.ISVC;
using Fwk.ConfigSection;
using Fwk.ServiceManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;





namespace Fwk.Bases.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class RetriveDispatcherInfoSvc : BusinessService<RetriveDispatcherInfoReq, RetriveDispatcherInfoRes>
    {
        public override RetriveDispatcherInfoRes Execute(RetriveDispatcherInfoReq pServiceRequest)
        {
            var res = new RetriveDispatcherInfoRes();

            DispatcherInfoBE dispatcherInfo = new DispatcherInfoBE();
            if (pServiceRequest.BusinessData.IncludeMetadata)
            {
                dispatcherInfo.MetadataProviders = new List<MetadataProvider>();
                foreach (ServiceProviderElement providerElement in ServiceMetadata.ProviderSection.Providers)
                {
                    dispatcherInfo.MetadataProviders.Add(new MetadataProvider(providerElement));
                }
                
            }

            if (pServiceRequest.BusinessData.IncludeCnnstSrings)
            {
                dispatcherInfo.Cnnstrings = new CnnstringBEList();
                foreach (ConnectionStringSettings cnn in System.Configuration.ConfigurationManager.ConnectionStrings)
                {
                    dispatcherInfo.Cnnstrings.Add(new CnnstringBE(cnn));
                }
            }

            dispatcherInfo.ServiceDispatcherConnection = System.Configuration.ConfigurationManager.AppSettings["ServiceDispatcherConnection"];
            dispatcherInfo.ServiceDispatcherName = System.Configuration.ConfigurationManager.AppSettings["ServiceDispatcherName"];
            if (pServiceRequest.BusinessData.IncludeAppSettings)
            {
                dispatcherInfo.AppSettings= new DictionarySettingList() ;
                foreach (string key in System.Configuration.ConfigurationManager.AppSettings)
                {
                    dispatcherInfo.AppSettings.Add(key, System.Configuration.ConfigurationManager.AppSettings[key.ToString()].ToString());
                }
            }
            dispatcherInfo.ServiceDate = System.DateTime.Now;
            try
            {
                dispatcherInfo.MachineIp = Fwk.HelperFunctions.EnvironmentFunctions.GetMachineIp();
            }
            catch (Exception e)
            {
                dispatcherInfo.MachineIp = e.Message;
            }
            res.BusinessData = dispatcherInfo;
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public  DispatcherInfo RetriveDispatcherInfo()
        {
            DispatcherInfo dispatcherInfo = new DispatcherInfo();
            try
            {
                dispatcherInfo.MachineIp = Fwk.HelperFunctions.EnvironmentFunctions.GetMachineIp();
            }
            catch (Exception e)
            {
                dispatcherInfo.MachineIp = e.Message;
            }
            List<MetadataProvider> list = new List<MetadataProvider>();
            foreach (ServiceProviderElement providerElement in ServiceMetadata.ProviderSection.Providers)
            {
                list.Add(new MetadataProvider(providerElement));
            }
            dispatcherInfo.MetadataProviders = list;


            dispatcherInfo.ServiceDispatcherConnection = System.Configuration.ConfigurationManager.AppSettings["ServiceDispatcherConnection"];
            dispatcherInfo.ServiceDispatcherName = System.Configuration.ConfigurationManager.AppSettings["ServiceDispatcherName"];

            foreach (string key in System.Configuration.ConfigurationManager.AppSettings)
            {
                dispatcherInfo.AppSettings.Add(key, System.Configuration.ConfigurationManager.AppSettings[key.ToString()].ToString());
            }

            foreach (System.Configuration.ConnectionStringSettings cnnStringSetting in System.Configuration.ConfigurationManager.ConnectionStrings)
            {
                dispatcherInfo.CnnStringSettings.Add(cnnStringSetting.Name, cnnStringSetting.ConnectionString);
            }

            //MembershipSection wMembershipSection = (MembershipSection)System.Configuration.ConfigurationManager.GetSection("system.web/membership");


            return dispatcherInfo;
        }

    }
}
