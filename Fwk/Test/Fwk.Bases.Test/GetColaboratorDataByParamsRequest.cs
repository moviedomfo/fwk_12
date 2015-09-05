using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;


namespace Fwk.Bases.Test
{

    [Serializable]
    public class GetColaboratorDataByParamsRequest : Request<Param>
    {
        public GetColaboratorDataByParamsRequest()
        {
            this.ServiceName = "GetColaboratorDataByParamsService";
        }
    }

    #region [BussinesData]

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        #region [Private Members]

        private System.String _UserName;

        #endregion


        #region [Properties]

        public System.String UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        #endregion
    }

    #endregion

}
