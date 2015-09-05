using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using System.Xml.Serialization;
namespace Fwk.Configuration.Common
{
    /// <summary>
    /// 
    /// </summary>
    [XmlInclude(typeof(ConfigFileRegistry)), Serializable]
    public class ConfigFileRegistry :Entity
    {
        string _name;
        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        string _CurrentVersion;
        /// <summary>
        /// 
        /// </summary>
        public string CurrentVersion
        {
            get { return _CurrentVersion; }
            set { _CurrentVersion = value; }
        }
        bool _Available = true;

        /// <summary>
        /// 
        /// </summary>
        public bool Available
        {
            get { return _Available; }
            set { _Available = value; }
        }
        int _TTL = 0;

        public int TTL
        {
            get { return _TTL; }
            set { _TTL = value; }
        }
        bool _Encrypt = false;

        public bool Encrypt
        {
            get { return _Encrypt; }
            set { _Encrypt = value; }
        }
        bool _ForceUpdate = true;

        public bool ForceUpdate
        {
            get { return _ForceUpdate; }
            set { _ForceUpdate = value; }
        }
       
        bool _BaseConfigFile = true;

        public bool BaseConfigFile
        {
            get { return _BaseConfigFile; }
            set { _BaseConfigFile = value; }
        }


    }

    [XmlRoot("ConfigFileRegistrys"), SerializableAttribute]
    public class ConfigFileRegistrys : Entities<ConfigFileRegistry>
    {
        public ConfigFileRegistry GetFirstByName(string pName)
        {
            return this.First(p => p.Name == pName);
        }
    }

}
