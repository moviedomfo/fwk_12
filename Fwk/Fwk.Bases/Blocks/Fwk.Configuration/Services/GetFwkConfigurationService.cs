using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Fwk.Configuration.ISVC;

using System.Xml.Serialization;
using Fwk.Configuration.Common;

namespace Fwk.Configuration.SVC
{
    /// <summary>
    /// Obtiene info del usuario :
    /// 
    /// intenta obtener el usuario en la membership 
    /// </summary>
    public class GetFwkConfigurationService : BusinessService<GetFwkConfigurationReq, GetFwkConfigurationRes>
    {
        public override GetFwkConfigurationRes Execute(GetFwkConfigurationReq pServiceRequest)
        {
            GetFwkConfigurationRes wRes = new GetFwkConfigurationRes();

           wRes.BusinessData = ConfigurationManager.GetConfigurationFile(pServiceRequest.BusinessData.ConfigProviderName);
         
            
            return wRes;
        }
    }
}


namespace Fwk.Configuration.ISVC
{
    [Serializable]
    public class GetFwkConfigurationReq : Request<Param>
    {
        public GetFwkConfigurationReq()
        {
            this.ServiceName = "GetFwkConfigurationService";
        }
    }

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
      
        string configProvider;
        /// <summary>
        /// Nombe del provedor de configuracion del lado del Dispatcher
        /// </summary>
        public string ConfigProviderName
        {
            get { return configProvider; }
            set { configProvider = value; }
        }

       
    }


    [Serializable]
    public class GetFwkConfigurationRes : Response<ConfigurationFile>
    { }
   
}