using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;


namespace Fwk.Bases.Test
{

    [Serializable]
    public class GetColaboratorDataByParamsResponse : Response<Result>
    {

    }

    [Serializable]
    public class Result : Entity
    {
        #region [Fields]

        private ColaboratorData _ColaboratorData;
        
        #endregion


        #region [Properties]

        public ColaboratorData ColaboratorData
        {
            get { return _ColaboratorData; }
            set { _ColaboratorData = value; }
        }

        #endregion
    }
}