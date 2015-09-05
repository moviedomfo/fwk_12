using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Security.ActiveDirectory.Test
{
    internal class StaticAD
    {
        //static Fwk.Bases.SingletonFactory<ADHelper> factory = null;

        static ADHelper _ADHelper;

        internal static ADHelper ADHelper
        {
            get
            {
                return _ADHelper;
            }
            set
            {
                 _ADHelper = value;
            }
        }

        internal static void LoadDomain(string domainName)
        {

            _ADHelper = new ADHelper(domainName, "SqlServices");

        }
    }
}
