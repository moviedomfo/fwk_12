using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Fwk.Exceptions;

namespace WcfDispatcher.Service
{
    
    [DataContract]
    //[ServiceKnownType("GetKnownTypes", typeof(FwkKnownTypesProvider))]
    //[KnownType("GetKnownTypes")]
    public class WCFRequet
    {
        [DataMember]
        public String ProviderName { get; set; }
       [DataMember]
         public String ServiceName { get; set; }
        [DataMember]
        public Object BusinessData { get; set; }

        [DataMember]
        public  Fwk.Bases.ContextInformation ContextInformation{ get; set; }
        //public static Type[] GetKnownTypes()
        //{
        //    System.Collections.Generic.List<System.Type> knownTypes = new System.Collections.Generic.List<System.Type>();

        //    String type = "Health.Isvc.SearchParametroByParams.SearchParametroByParamsReq, Health.SVC";

        //    knownTypes.Add(Type.GetType(type));

        //    knownTypes.Add(Type.GetType("Health.Isvc.SearchParametroByParams.SearchParametroByParamsRes, Health.SVC"));
        //    knownTypes.Add(Type.GetType("Health.Isvc.SearchParametroByParams.Params, Health.SVC"));
            
        //    knownTypes.Add(typeof(Fwk.Bases.Entity));
        //    knownTypes.Add(typeof(Fwk.Bases.IEntity));
        //    // Add any types to include here.
        //    //Properties.Settings.Default.KnowTypes.Cast<string>().ToList().ForEach(type =>
        //    //{
        //    //    knownTypes.Add(Type.GetType(type));
        //    //});

        //    return knownTypes.ToArray();
        //}
    }

    [DataContract]
    public class WCFResponse
    {
   

        [DataMember]
        public Object BusinessData { get; set; }

        [DataMember]
        public ServiceError Error { get; set; }

    }

    //internal static class FwkKnownTypesProvider
    //{
    //    public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
    //    {
    //        System.Collections.Generic.List<System.Type> knownTypes =  new System.Collections.Generic.List<System.Type>();

    //        String type = "Health.Isvc.SearchParametroByParams.SearchParametroByParamsReq, Health.SVC";

    //        knownTypes.Add(Type.GetType(type));

    //        knownTypes.Add(Type.GetType("Health.Isvc.SearchParametroByParams.SearchParametroByParamsRes, Health.SVC"));
    //        knownTypes.Add(typeof(Fwk.Bases.Entity));
    //        knownTypes.Add(typeof(Fwk.Bases.IEntity));
    //        // Add any types to include here.
    //        //Properties.Settings.Default.KnowTypes.Cast<string>().ToList().ForEach(type =>
    //        //{
    //        //    knownTypes.Add(Type.GetType(type));
    //        //});

    //        return knownTypes;
    //    }
    //}
}
