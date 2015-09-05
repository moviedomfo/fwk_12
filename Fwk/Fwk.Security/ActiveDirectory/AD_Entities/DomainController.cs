using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Security.ActiveDirectory
{
    class DomainController
    {
        Int32 _Id;
        Int32 _DomainId;
        String _HostName;
        String _Ip;

        public Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
        public Int32 DomainId
        {
            get
            {
                return _DomainId;
            }
            set
            {
                _DomainId = value;
            }
        }
        public String HostName
        {
            get
            {
                return _HostName;
            }
            set
            {
                _HostName = value;
            }
        }
        public String Ip
        {
            get
            {
                return _Ip;
            }
            set
            {
                _Ip = value;
            }
        }

    }
}
