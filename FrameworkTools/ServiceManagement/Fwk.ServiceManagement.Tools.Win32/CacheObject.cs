using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Caching;
using System.Windows.Forms;
using System.Reflection;

namespace Fwk.ServiceManagement.Tools.Win32
{
    
    [Serializable]
    class Storage
    {
        private string _AssemblyPath;

        public string AssemblyPath
        {
            get { return _AssemblyPath; }
            set { _AssemblyPath = value; }
        }
    }
}
