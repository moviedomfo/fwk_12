using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;

using Fwk.Cache.Test;

namespace Fwk.Cache.Test
{
    [Serializable]
    public class SearchColaboratorsByParamsResponse : Response<Result>
    {

    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
        #region [Fields]

        private List<ColaboratorData> _ColaboratorDataList;

        #endregion


        #region [Properties]

        public List<ColaboratorData> ColaboratorDataList
        {
            get { return _ColaboratorDataList; }
            set { _ColaboratorDataList = value; }
        }

        #endregion
    }
}