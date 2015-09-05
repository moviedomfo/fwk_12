using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Principal;

using System.Windows.Forms;
using System.Web.Security;


namespace Fwk.Security.Common
{

    /// <summary>
    /// 
    /// </summary>
    public sealed class WaitCursorHelper : IDisposable
    {
        
        private Control owner;
        private Cursor previousCursor;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        public WaitCursorHelper(Control owner)
        {
            this.owner = owner;
            this.previousCursor = this.owner.Cursor;
            this.owner.Cursor = Cursors.WaitCursor;
        }

        void IDisposable.Dispose()
        {
            this.owner.Cursor = this.previousCursor;
        }
    }
}
