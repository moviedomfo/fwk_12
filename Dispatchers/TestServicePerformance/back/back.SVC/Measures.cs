using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using System.Xml.Serialization;

namespace back.Common.BE
{

    [XmlRoot("Measures"), SerializableAttribute]
    public class Measures :BaseEntities<Measure>
    {
        public Measures()
        { }
        public void Add(string key, decimal val)
        {
            this.Add(new Measure(key, val));
        }
        public void Add(string key, decimal val, bool isTime)
        {
            this.Add(new Measure(key, val, isTime));
        }
    }
    [XmlInclude(typeof(Measure)), Serializable]
    public class Measure:BaseEntity
    {
        public Measure()
        { }
        bool _IsTime = true;
        public Measure(string key, decimal val)
        {
            _MeasureName = key;
            _value = val;
        }

        public Measure(string key, decimal val, bool isTime)
        {
            _MeasureName = key;
            _value = val;
             _IsTime = isTime;

        }
        string _MeasureName;

        public string MeasureName
        {
            get { return _MeasureName; }
            set { _MeasureName = value; }
        }
        decimal _value;

        public decimal Value
        {
            get { return _value; }
            set { _value = value; }
        }
        decimal _CalculatedValue;
        public decimal CalculatedValue
        {
            get { return GetCalculatedValue(); }
           
        }

        decimal GetCalculatedValue()
        {
            if (_IsTime)
            {
                return _value / 1000;
            }
            else
            {
                return _value / 1024/1024;
            }
        }

    }

    [XmlInclude(typeof(TestRes)), Serializable]
    public class TestRes:BaseEntity
    {
        Measures time;

        public Measures Times
        {
            get { return time; }
            set { time = value; }
        }
        Measures sizes;

        public Measures Sizes
        {
            get { return sizes; }
            set { sizes = value; }
        }

    }
}
