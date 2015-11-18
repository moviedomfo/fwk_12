using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.Common;

namespace Fwk.Security.ActiveDirectory.Test
{
    public delegate void DomainGroupChangeHandler(ADGroup pGroup);

    [DefaultEvent("DomainGroupChangeEvent")]
    public partial class DomainGoups : UserControl
    {
        //FwkActyveDirectory _FwkActyveDirectory;
        //ADHelper _ADHelper;
        public event DomainGroupChangeHandler DomainGroupChangeEvent;

        void OnObjectDomainChange()
        {
            if (DomainGroupChangeEvent != null)
                DomainGroupChangeEvent(_CurrentGroup);
        }
        List<ADGroup> _DomainGoups;
        ADGroup _CurrentGroup;

        public DomainGoups()
        {
            InitializeComponent();
            //_ADHelper = StaticAD.ADHelper;
          
        }


        public void Initialize(String domainName)
        {
         
            StaticAD.LoadDomain(domainName);
            //_ADHelper = StaticAD.ADHelper;
        }

        public void Populate()
        {
            if (_CurrentGroup == null)
            {
                //throw new Exception("El dominio no fue inicializado.");
            }

            //_DomainGoups = _FwkActyveDirectory.GetAllGroups();
            _DomainGoups = StaticAD.ADHelper.Groups_GetAll();
            objectDomainGroupBindingSource.DataSource = _DomainGoups;

        }
        public void Populate(List<ADGroup> pGroup)
        {
            _DomainGoups = pGroup;
            objectDomainGroupBindingSource.DataSource = _DomainGoups;
        }
        private void grdDomainGroups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DomainGroupChangeEvent == null) return;
            if (grdDomainGroups.CurrentRow == null) return;
            if (grdDomainGroups.CurrentRow.DataBoundItem == null) return;

            _CurrentGroup = ((ADGroup)grdDomainGroups.CurrentRow.DataBoundItem);
            OnObjectDomainChange();
        }

        private void btnFilterGroup_Click(object sender, EventArgs e)
        {
            using (new WaitCursorHelper(this))
            {
                objectDomainGroupBindingSource.DataSource = ADGroup.FilterByName(txtDomainGroupName.Text, _DomainGoups);
            }
        }

        private void txtDomainGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (new WaitCursorHelper(this))
                {
                    objectDomainGroupBindingSource.DataSource = ADGroup.FilterByName(txtDomainGroupName.Text, _DomainGoups);
                }
            }
        }



        internal void Initialize(string path, string user, string pwd)
        {

            StaticAD.ADHelper = new ADWrapper(path, user, pwd);
        }
    }
}
