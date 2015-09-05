using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Fwk.Security.ActiveDirectory;
using System.Xml.Serialization;

namespace Fwk.Security.ISVC.SearchDomainsUrls
{
    [Serializable]
    public class SearchDomainsUrlsRequest : Request<Params>
    {
        public SearchDomainsUrlsRequest()
        {
            this.ServiceName = "SearchDomainsUrlsService";
        }
    }

    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Entity
    {
        String _ConnectionString;

        public String ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }

    }

    [Serializable]
    public class SearchDomainsUrlsResponse : Response<Result>
    {
    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entities<DomainUrlInfo>
    {
        List<String> _DomainsNameList;

        public List<String> DomainsNameList
        {
            get { return _DomainsNameList; }
            set { _DomainsNameList = value; }
        }

    }


    
}
