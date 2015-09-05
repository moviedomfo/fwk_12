using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Bases
{
    /// <summary>
    /// 
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Property,Inherited=true)]
    public class FwkHistoryAttribute : System.Attribute
    {
        #region  History
        

        //Entity _Parent;
        string _Name = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        public FwkHistoryAttribute(string pName)
        {
            object x = this.TypeId;
         
            _Name = pName;
           
        }

        #endregion
    }

   
}
