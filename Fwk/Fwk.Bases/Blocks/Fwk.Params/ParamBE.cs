using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Fwk.Params.BE
{

    
    public class ParamList : Fwk.Bases.Entities<ParamBE> { }

    
    public partial class ParamBE : Fwk.Bases.Entity
    {
        #region Primitive Properties
        /// <summary>
        /// 
        /// </summary>
        public global::System.Int32 Id
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
        private global::System.Int32 _Id;
        /// <summary>
        /// 
        /// </summary>
        public global::System.Int32 ParamId
        {
            get
            {
                return _ParamId;
            }
            set
            {
                _ParamId = value;
            }
        }

        private global::System.Int32 _ParamId;


        /// <summary>
        /// 
        /// </summary>
        public global::System.String Culture
        {
            get
            {
                return _Culture;
            }
            set
            {
                _Culture = value;
            }
        }

        private global::System.String _Culture;


        /// <summary>
        /// 
        /// </summary>
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        private global::System.String _Name;



        /// <summary>
        /// 
        /// </summary>
        /// 
        [Obsolete("Utilizar ParentId")]
        public Nullable<global::System.Int32> ParamTypeId
        {
            get
            {
                return _ParamTypeId;
            }
            set
            {
                _ParamTypeId = value;
            }
        }

        private Nullable<global::System.Int32> _ParamTypeId;



        /// <summary>
        /// 
        /// </summary>
        public Nullable<global::System.Int32> ParentId
        {
            get
            {
                return _ParentId;
            }
            set
            {
                _ParentId = value;
            }
        }

        private Nullable<global::System.Int32> _ParentId;



        /// <summary>
        /// 
        /// </summary>
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        private global::System.String _Description;



        /// <summary>
        /// 
        /// </summary>
        public global::System.Boolean Enabled
        {
            get
            {
                return _Enabled;
            }
            set
            {
                _Enabled = value;
            }
        }

        private global::System.Boolean _Enabled;



        /// <summary>
        /// 
        /// </summary>
        public Nullable<global::System.Guid> UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
            }
        }

        private Nullable<global::System.Guid> _UserId;



       



        #endregion


        /// <summary>
        /// Empty Constructor
        /// </summary>
        public ParamBE() { }

  


      
    }


    
    
    
}
