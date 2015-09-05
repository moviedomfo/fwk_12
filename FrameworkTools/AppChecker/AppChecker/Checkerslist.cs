using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Reflection;
using AppChecker.core;

namespace AppChecker
{
    [XmlInclude(typeof(CheckersAssem)), Serializable]
    public class CheckersAssem
    {
        string _Assembly;

        public string Assembly
        {
            get { return _Assembly; }
            set { _Assembly = value; }
        }
        bool _Enabled = false;

        public bool Enabled
        {
            get { return _Enabled; }
            set { _Enabled = value; }
        }

    }
    [XmlRoot("CheckersAssemlist"), SerializableAttribute]
    public  class CheckersAssemlist : List<CheckersAssem>
    {
        internal static CheckersAssemlist Load()
        {
            string str;
            if (!File.Exists("checkers.xml")) return null;
            {
                str = Helper.OpenTextFile("checkers.xml");
                if (string.IsNullOrEmpty(str))
                {
                    return null;
                }
            }
            try
            {
                return (CheckersAssemlist)Helper.DeserializeFromXml(typeof(CheckersAssemlist), str);
            }
            catch (Exception)
            {
                return null;
            }
        }


    }


}
