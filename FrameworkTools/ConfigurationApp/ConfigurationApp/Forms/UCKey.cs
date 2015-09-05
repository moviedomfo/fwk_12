using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Configuration.Common;
using Fwk.Bases.FrontEnd;

namespace ConfigurationApp.Forms
{

    public partial class UCConfigElement : FwkUserControlBase
    {
        Key _Key;
        Group _Group;
        public UCConfigElement()
        {
            InitializeComponent();
        }
        void RefreshData() 
        {
             _Key = null;
             _Group = null;
             
             groupKey.Visible = false;
        }

        /// <summary>
        /// Poblado de Key
        /// </summary>
        /// <param name="pKey"></param>
        /// <param name="fileName"></param>
        /// <param name="grName"></param>
        public void Populate(Key pKey,string fileName,string grName)
        {
            RefreshData();
            groupKey.Visible = true;
       
            lblFileName.Text = fileName;
            txtGroupName.Text = grName;
            _Key = new Key();
            _Key.Name = pKey.Name;
            _Key.Encrypted = pKey.Encrypted;
            _Key.Value.Text = pKey.Value.Text;

            txtNewValue.Text = _Key.Value.Text;
            txtNewKeyName.Text = _Key.Name;

      
        
        }

        /// <summary>
        /// Poblado de grupo
        /// </summary>
        /// <param name="pGroup"></param>
        /// <param name="fileName"></param>
        public void Populate(Group pGroup, string fileName)
        {
            RefreshData();
            
            lblFileName.Text = fileName;
            txtGroupName.Text = pGroup.Name;
       
           _Group = pGroup.Clone<Group>();

            
        }

        public Fwk.Bases.BaseEntity Get()
        {
            if(_Key !=null)
                return _Key;

            if (_Group != null)
                return _Group;

            return null;
        }

        private void txtNewValue_TextChanged(object sender, EventArgs e)
        {
            _Key.Value.Text = txtNewValue.Text;
        }



        internal void Populate(string fileName)
        {
            RefreshData();

            lblFileName.Text = fileName;
        }

        private void txtNewKeyName_TextChanged(object sender, EventArgs e)
        {
            _Key.Name = txtNewKeyName.Text;
        }

        private void txtGroupName_TextChanged(object sender, EventArgs e)
        {
            if (_Group != null)
            _Group.Name = txtGroupName.Text;
        }
    }
}
