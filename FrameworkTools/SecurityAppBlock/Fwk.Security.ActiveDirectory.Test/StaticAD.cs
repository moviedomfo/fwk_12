using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Security.ActiveDirectory.Test
{
    internal class StaticAD
    {
        //static Fwk.Bases.SingletonFactory<ADWrapper> factory = null;

        static ADWrapper _ADWrapper;

        internal static ADWrapper ADWrapper
        {
            get
            {
                return _ADWrapper;
            }
            set
            {
                 _ADWrapper = value;
            }
        }

        internal static void LoadDomain(string domainName)
        {

            _ADWrapper = new ADWrapper(domainName, "SqlServices");

        }
    }
}
