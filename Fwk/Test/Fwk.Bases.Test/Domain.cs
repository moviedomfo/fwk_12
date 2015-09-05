using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using System.Xml.Serialization;

namespace Fwk.Bases.Test
{
    [XmlInclude(typeof(Domain)),Serializable]
    public class Domain:Entity
    {
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        string iD;

        public string Id
        {
            get { return iD; }
            set { iD = value; }
        }
        string parentID;

        public string ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }

        int? domainId;

        public int?  DomainId
        {
            get { return domainId; }
            set { domainId = value; }
        }

        int? hierarchy;

        public int? Hierarchy
        {
            get { return hierarchy; }
            set { hierarchy = value; }
        }
        int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        bool inMesh = false;
        public bool InMesh
        {
            get { return inMesh; }
            set { inMesh = value; }
        }
    }

    [XmlRoot("DomainList"), SerializableAttribute]
    public class DomainList : Entities<Domain>
    { 

    }


    [Serializable]
    public class DomainAux : Entity
    {
        int? cuentaid;

        public int? CuentaId
        {
            get { return cuentaid; }
            set { cuentaid = value; }
        }
        int? subareaid;

        public int? SubareaId
        {
            get { return subareaid; }
            set { subareaid = value; }
        }
      
        int? cargoId;

        public int? CargoId
        {
            get { return cargoId; }
            set { cargoId = value; }
        }
        int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
    }

   
    
}
