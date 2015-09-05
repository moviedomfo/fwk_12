using System;
using System.Collections.Generic;
using System.Text;
using DataBaseObject = Fwk.DataBase.DataEntities;
using Fwk.Bases;
using System.Windows.Forms;

namespace Fwk.DataBase.CustomControls
{
    /// <summary>
    /// 
    /// </summary>
    public delegate void SelectObjectHandler();

    /// <summary>
    /// Clase base de los tree view controls
    /// </summary>
    public class TreeViewBase : UserControl
    {
        #region Eventos
        private event SelectObjectHandler _SelectObjectEvent;
        /// <summary>
        /// 
        /// </summary>
        internal void OnSelectObjectEvent()
        {

            if (_SelectObjectEvent != null)
                _SelectObjectEvent();
        }
        /// <summary>
        /// 
        /// </summary>
        public event SelectObjectHandler SelectObjectEvent
        {
            add
            {
                _SelectObjectEvent = (SelectObjectHandler)Delegate.Combine(_SelectObjectEvent, value);
            }
            remove
            {
                _SelectObjectEvent = (SelectObjectHandler)Delegate.Remove(_SelectObjectEvent, value);
            }
        }
        #endregion

         
    }
}
