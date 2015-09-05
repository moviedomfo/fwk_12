using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Bases.FrontEnd.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmMsgBase : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private string _Message = String.Empty;

        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public FrmMsgBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FrmMsgBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


    }
}