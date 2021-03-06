﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DispatcherClientChecker.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IFwkService")]
    public interface IFwkService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFwkService/ExecuteService", ReplyAction="http://tempuri.org/IFwkService/ExecuteServiceResponse")]
        string ExecuteService(string providerName, string serviceName, string jsonRequets);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFwkService/ExecuteService", ReplyAction="http://tempuri.org/IFwkService/ExecuteServiceResponse")]
        System.Threading.Tasks.Task<string> ExecuteServiceAsync(string providerName, string serviceName, string jsonRequets);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFwkService/ExecuteServiceBin", ReplyAction="http://tempuri.org/IFwkService/ExecuteServiceBinResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(string[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Fwk.Exceptions.ServiceError))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Fwk.Bases.Connector.WCFServiceReference.WCFResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Fwk.Bases.ContextInformation))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Fwk.Bases.BaseEntity))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Fwk.ConfigSection.DispatcherInfo))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Fwk.ConfigSection.DictionarySetting[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Fwk.ConfigSection.DictionarySetting))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Fwk.ConfigSection.MetadataProvider[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Fwk.ConfigSection.MetadataProvider))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Fwk.Bases.Connector.WCFServiceReference.WCFRequet))]
        Fwk.Bases.Connector.WCFServiceReference.WCFResponse ExecuteServiceBin(Fwk.Bases.Connector.WCFServiceReference.WCFRequet req);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFwkService/ExecuteServiceBin", ReplyAction="http://tempuri.org/IFwkService/ExecuteServiceBinResponse")]
        System.Threading.Tasks.Task<Fwk.Bases.Connector.WCFServiceReference.WCFResponse> ExecuteServiceBinAsync(Fwk.Bases.Connector.WCFServiceReference.WCFRequet req);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFwkService/GetServiceConfiguration", ReplyAction="http://tempuri.org/IFwkService/GetServiceConfigurationResponse")]
        string GetServiceConfiguration(string providerName, string serviceName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFwkService/GetServiceConfiguration", ReplyAction="http://tempuri.org/IFwkService/GetServiceConfigurationResponse")]
        System.Threading.Tasks.Task<string> GetServiceConfigurationAsync(string providerName, string serviceName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFwkService/GetServicesList", ReplyAction="http://tempuri.org/IFwkService/GetServicesListResponse")]
        string GetServicesList(string providerName, bool ViewAsXml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFwkService/GetServicesList", ReplyAction="http://tempuri.org/IFwkService/GetServicesListResponse")]
        System.Threading.Tasks.Task<string> GetServicesListAsync(string providerName, bool ViewAsXml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFwkService/RetriveDispatcherInfo", ReplyAction="http://tempuri.org/IFwkService/RetriveDispatcherInfoResponse")]
        Fwk.ConfigSection.DispatcherInfo RetriveDispatcherInfo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFwkService/RetriveDispatcherInfo", ReplyAction="http://tempuri.org/IFwkService/RetriveDispatcherInfoResponse")]
        System.Threading.Tasks.Task<Fwk.ConfigSection.DispatcherInfo> RetriveDispatcherInfoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFwkService/GetAllApplicationsId", ReplyAction="http://tempuri.org/IFwkService/GetAllApplicationsIdResponse")]
        string[] GetAllApplicationsId(string providerName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFwkService/GetAllApplicationsId", ReplyAction="http://tempuri.org/IFwkService/GetAllApplicationsIdResponse")]
        System.Threading.Tasks.Task<string[]> GetAllApplicationsIdAsync(string providerName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFwkService/GetProviderInfo", ReplyAction="http://tempuri.org/IFwkService/GetProviderInfoResponse")]
        Fwk.ConfigSection.MetadataProvider GetProviderInfo(string providerName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFwkService/GetProviderInfo", ReplyAction="http://tempuri.org/IFwkService/GetProviderInfoResponse")]
        System.Threading.Tasks.Task<Fwk.ConfigSection.MetadataProvider> GetProviderInfoAsync(string providerName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFwkServiceChannel : DispatcherClientChecker.ServiceReference1.IFwkService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FwkServiceClient : System.ServiceModel.ClientBase<DispatcherClientChecker.ServiceReference1.IFwkService>, DispatcherClientChecker.ServiceReference1.IFwkService {
        
        public FwkServiceClient() {
        }
        
        public FwkServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FwkServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FwkServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FwkServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string ExecuteService(string providerName, string serviceName, string jsonRequets) {
            return base.Channel.ExecuteService(providerName, serviceName, jsonRequets);
        }
        
        public System.Threading.Tasks.Task<string> ExecuteServiceAsync(string providerName, string serviceName, string jsonRequets) {
            return base.Channel.ExecuteServiceAsync(providerName, serviceName, jsonRequets);
        }
        
        public Fwk.Bases.Connector.WCFServiceReference.WCFResponse ExecuteServiceBin(Fwk.Bases.Connector.WCFServiceReference.WCFRequet req) {
            return base.Channel.ExecuteServiceBin(req);
        }
        
        public System.Threading.Tasks.Task<Fwk.Bases.Connector.WCFServiceReference.WCFResponse> ExecuteServiceBinAsync(Fwk.Bases.Connector.WCFServiceReference.WCFRequet req) {
            return base.Channel.ExecuteServiceBinAsync(req);
        }
        
        public string GetServiceConfiguration(string providerName, string serviceName) {
            return base.Channel.GetServiceConfiguration(providerName, serviceName);
        }
        
        public System.Threading.Tasks.Task<string> GetServiceConfigurationAsync(string providerName, string serviceName) {
            return base.Channel.GetServiceConfigurationAsync(providerName, serviceName);
        }
        
        public string GetServicesList(string providerName, bool ViewAsXml) {
            return base.Channel.GetServicesList(providerName, ViewAsXml);
        }
        
        public System.Threading.Tasks.Task<string> GetServicesListAsync(string providerName, bool ViewAsXml) {
            return base.Channel.GetServicesListAsync(providerName, ViewAsXml);
        }
        
        public Fwk.ConfigSection.DispatcherInfo RetriveDispatcherInfo() {
            return base.Channel.RetriveDispatcherInfo();
        }
        
        public System.Threading.Tasks.Task<Fwk.ConfigSection.DispatcherInfo> RetriveDispatcherInfoAsync() {
            return base.Channel.RetriveDispatcherInfoAsync();
        }
        
        public string[] GetAllApplicationsId(string providerName) {
            return base.Channel.GetAllApplicationsId(providerName);
        }
        
        public System.Threading.Tasks.Task<string[]> GetAllApplicationsIdAsync(string providerName) {
            return base.Channel.GetAllApplicationsIdAsync(providerName);
        }
        
        public Fwk.ConfigSection.MetadataProvider GetProviderInfo(string providerName) {
            return base.Channel.GetProviderInfo(providerName);
        }
        
        public System.Threading.Tasks.Task<Fwk.ConfigSection.MetadataProvider> GetProviderInfoAsync(string providerName) {
            return base.Channel.GetProviderInfoAsync(providerName);
        }
    }
}
