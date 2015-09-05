using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Fwk.Security.Admin
{
    public class RuleObjetoSource
    {
        private List<FwkAuthorizationRule> _RuleList;
        private object _Source;

        public RuleObjetoSource(object pSource, List<FwkAuthorizationRule> pRuleList)
        {
            _RuleList = pRuleList;
            _Source = pSource;
        }

        public List<Fwk.Security.FwkAuthorizationRule> RuleList
        {
            get { return _RuleList; }
            set { _RuleList = value; }
        }

        public object Source
        {
            get { return _Source; }
            set { _Source = value; }
        }

    }
}
