using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SomeCompany.BE
{
    
    public class AccountBE: Fwk.Bases.IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public String TypeName { get; set; }
        public DateTime CreatedRow { get; set; }

        public System.Data.DataSet GetDataSet()
        {
            throw new NotImplementedException();
        }

        public string GetXml()
        {
            throw new NotImplementedException();
        }

        public void SetXml(string pXmlData)
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
