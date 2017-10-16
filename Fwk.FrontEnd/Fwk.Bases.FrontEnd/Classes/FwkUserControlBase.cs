using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Fwk.Bases;

namespace Fwk.Bases.FrontEnd
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class FwkUserControlBase : UserControl
    {

        #region UserControlBase Properties

      

        private IBaseEntity _EntityResult = null;

        /// <summary>
        /// 
        /// </summary>
        public IBaseEntity EntityResult
        {
            get { return _EntityResult; }
            set { _EntityResult = value; }
        }
        private IBaseEntity _EntityParam = null;

        /// <summary>
        /// 
        /// </summary>
        public IBaseEntity EntityParam
        {
            get { return _EntityParam; }
            set { _EntityParam = value; }
        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        public FwkUserControlBase()
        {
            InitializeComponent();
            
        }

        





        
    }
}
