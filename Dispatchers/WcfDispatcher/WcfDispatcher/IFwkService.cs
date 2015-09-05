using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Fwk.Bases;
using Fwk.Caching;
using Fwk.ConfigSection;

//http://msdn.microsoft.com/en-us/library/ee939340.aspx
namespace WcfDispatcher.Service
{
    //Single(Singleton) - If WCF service is configured as “Single” then for all the clients only one service instance will be created and this service instance will common for all the clients. This is like “[Application]” object in ASP.Net. For this implementation you have to set InstanceContextMode attribute like this-

    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IFwkService
    {
        [OperationContract]
        String ExecuteService(String providerName, String serviceName, String jsonRequets);

        [OperationContract]
        WCFResponse ExecuteServiceBin( WCFRequet req);

        [OperationContract]
        String GetServiceConfiguration(string providerName, string serviceName);

        [OperationContract]
        String GetServicesList(string providerName, Boolean ViewAsXml);

        [OperationContract]
        Fwk.ConfigSection.DispatcherInfo RetriveDispatcherInfo();

        [OperationContract]
        List<String> GetAllApplicationsId(string providerName);

        [OperationContract]
        MetadataProvider GetProviderInfo(string providerName);
        
    }


    [DataContract]
    public class CompositeType
    {
 
        private ContextInformation _ContextField;
        private String ServiceName { get; set; }
        private String _JsonBusinesData;
        
        [DataMember(IsRequired = false, Name = "Context", Order = 0)]
        public ContextInformation Context
        {
            get { return _ContextField; }
            set { _ContextField = value; }
        }


        [DataMember()]
        public String JsonBusinesData
        {
            get { return _JsonBusinesData; }
            set { _JsonBusinesData = value; }
        }
       
    }
}
