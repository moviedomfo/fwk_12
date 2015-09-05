using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiLanguageManager
{
    public class ConfigMannagerGridList : Fwk.Bases.BaseEntities<ConfigManagerGrid>
    { }
    [Serializable]
    public class ConfigManagerGrid : Fwk.Bases.BaseEntity
    {
        public string Provider { get; set; }
        public string Group { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

    }
}
