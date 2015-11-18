using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralizedSecurity.W32.Test
{
    [Serializable]
    public class TestSettings
    {
        public string Domain { get; set; }
        public string user { get; set; }
        public string pwd { get; set; }
    }
}
