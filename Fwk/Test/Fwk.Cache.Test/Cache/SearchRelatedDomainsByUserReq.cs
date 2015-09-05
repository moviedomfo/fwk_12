using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;


namespace Fwk.Cache.Test
{
    [Serializable]
    public class SearchRelatedDomainsByUserReq : Request<Params>
    {
        public SearchRelatedDomainsByUserReq()
        {
            this.ServiceName = "SearchRelatedDomainsByUserService";
        }
    }

    #region [BussinesData]

    [XmlInclude(typeof(Param)), Serializable]
    public class Params : Entity
    {
        #region [Private Members]

        private ColaboratorData _ColaboratorData = new ColaboratorData ();

        #endregion


        #region [Properties]

        public ColaboratorData ColaboratorData
        {
            get { return _ColaboratorData; }
            set { _ColaboratorData = value; }
        }

        #endregion
    }

    #endregion
}