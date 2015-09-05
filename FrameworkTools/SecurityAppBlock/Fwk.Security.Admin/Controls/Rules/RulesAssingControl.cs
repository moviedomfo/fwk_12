using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.Common;
using Fwk.Security;
using System.Web.Security;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Fwk.Security.Admin.Controls
{
    [ToolboxItem(true)]
    [DefaultEvent("NewSecurityInfoCreated")]
    public partial class RulesAssingControl : SecurityControlBase
    {

        /// <summary>
        /// Representa la informacion del tipo de control a instanciar 
        /// 
        /// </summary>
        public override string AssemblySecurityControl
        {
            get
            {
                return typeof(RulesAssingControl).AssemblyQualifiedName;
            }
        }
        public event NewSecurityInfoCreatedHandler NewSecurityInfoCreated;
        protected void NewSecurityInfoCreatedHandler()
        {
            if (NewSecurityInfoCreated != null)
                NewSecurityInfoCreated(this);
        }
        public bool ButtonSaveVisible
        {
            get{return btnCreateRule.Visible;}
            set { btnCreateRule.Visible=value; }
        }
        Rol _SelectedRol = null;
        User _SelectedUser = null;

        UserList _ExcludeUserList = new UserList();
        RolList _AssignedRolList = new RolList();
        internal FwkAuthorizationRule _CurrentRule = null;
        List<Rol> selectedRoles = new List<Rol>();
        public RulesAssingControl()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            txtRuleName.Focus();
            using (new WaitCursorHelper(this))
            {
                try
                {
                    userBindingSource.DataSource = FwkMembership.GetAllUsers(frmAdmin.Provider.Name);
                    rolBindingSource.DataSource = FwkMembership.GetAllRoles(frmAdmin.Provider.Name);

                    if (userBindingSource.Count == 0) throw new Exception(string .Concat("La aplicaión ", frmAdmin.Provider.ApplicationName, " no contiene usuarios.-"));
                    if (rolBindingSource.Count == 0) throw new Exception(string .Concat("La aplicaión ", frmAdmin.Provider.ApplicationName, " no contiene roles.-"));
                }
                catch (Exception es)
                {
             
                    throw es;
                }

            }

            if (this.State == Bases.EntityUpdateEnum.UPDATED)
            {
                label3.Text = "Update bussiness rule";
                //txtRuleName.Enabled = false;
            }
            
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruleName"></param>
        public void Populate(string ruleName)
        {
            txtRuleName.Text = ruleName;

            _CurrentRule = FwkMembership.GetRule(ruleName, frmAdmin.Provider.Name);

            txtRuleExpression.Text = _CurrentRule.Expression;

            _AssignedRolList = new RolList();
            _ExcludeUserList = new UserList();
            FwkMembership.BuildRolesAndUsers_FromRuleExpression(_CurrentRule.Expression, out _AssignedRolList, out _ExcludeUserList);


            txtRuleExpression.Text = FwkMembership.BuildRuleExpression(_AssignedRolList, _ExcludeUserList);
            grdAssignedRoles.DataSource = null;
            grdAssignedRoles.DataSource = _AssignedRolList;
            grdUserExcluded.DataSource = null;
            grdUserExcluded.DataSource = _AssignedRolList;
            grdUserExcluded.Refresh();
            grdAssignedRoles.Refresh();
        }

        private void grdAllRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdAllRoles.CurrentRow == null) return;
            _SelectedRol = ((Rol)grdAllRoles.CurrentRow.DataBoundItem);

        }


        public bool AceptChanges()
        {
            if (string.IsNullOrEmpty(txtRuleName.Text))
            {
                errorProvider1.SetError(txtRuleName, "Rule name must not be empty");
                return false;
            }
           

            try
            {
                if (_CurrentRule == null)
                    _CurrentRule = new FwkAuthorizationRule();
               
                _CurrentRule.Expression = txtRuleExpression.Text;

                if (base.State == Bases.EntityUpdateEnum.NEW)
                {
                    _CurrentRule.Name = txtRuleName.Text;
                    if (FwkMembership.ExistRule(txtRuleName.Text.Trim(), frmAdmin.Provider.Name))
                    {
                        MessageViewInfo.Show(String.Format("The rule {0} exist", txtRuleName.Text));
                        txtRuleName.Focus();
                        return false;
                    }
                    FwkMembership.CreateRule(_CurrentRule, frmAdmin.Provider.Name);

                    MessageViewInfo.Show(String.Format(Properties.Resources.RuleCreatedMessage, txtRuleName.Text));

                    this.btnCreateRule.Enabled = false;

                }
                if (base.State == Bases.EntityUpdateEnum.UPDATED)
                {
                    //Si Cambio el nombre
                    if (_CurrentRule.Name.Trim().CompareTo(txtRuleName.Text.Trim()) != 0)
                    {
                        FwkMembership.UpdateRuleAndRuleName(_CurrentRule, txtRuleName.Text.Trim(), frmAdmin.Provider.Name);

                    }
                    else
                    {

                        FwkMembership.UpdateRule(_CurrentRule, frmAdmin.Provider.Name);
                    }

                    MessageViewInfo.Show(String.Format(Properties.Resources.RuleUpdatedMessage, txtRuleName.Text));
                }
                NewSecurityInfoCreatedHandler();
            }
            catch (Exception ex)
            {
                MessageViewInfo.Show(ex);
                return false;
            }
            return true;
 
        }
        private void btnAddRol_Click(object sender, EventArgs e)
        {
         
            FillSelectedRoles();
            foreach (Rol selectedRol in selectedRoles)
            {

                if (!_AssignedRolList.Any<Rol>(rol => rol.RolName.Equals(selectedRol.RolName, StringComparison.OrdinalIgnoreCase)))
                {
                    _AssignedRolList.Add(new Rol(selectedRol.RolName));

                    grdAssignedRoles.DataSource = null;
                    grdAssignedRoles.DataSource = _AssignedRolList;
                }
            }
            txtRuleExpression.Text = FwkMembership.BuildRuleExpression(_AssignedRolList, _ExcludeUserList);
            NewSecurityInfoCreatedHandler();
        }
        


        void FillSelectedRoles()
        {
            selectedRoles.Clear();
            foreach (DataGridViewRow row in grdAllRoles.SelectedRows)
            {
                selectedRoles.Add(((Rol)row.DataBoundItem));
            }

        }
        private void grdAllUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdAllUser.CurrentRow == null) return;
            _SelectedUser = ((User)grdAllUser.CurrentRow.DataBoundItem);
        }

     
       
       



        private void btnCreateRule_Click(object sender, EventArgs e)
        {
            AceptChanges();

        }

        private void textRuleName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtRuleName.Text))
            {
                errorProvider1.SetError(txtRuleName, "Rule name must not be empty");
            }
            else
            {
                errorProvider1.SetError(txtRuleName, string.Empty);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_SelectedUser != null)
            {
                var s = from usr in _ExcludeUserList where usr.UserName == _SelectedUser.UserName select usr;
                if (!s.Any())
                {
                    _ExcludeUserList.Add(new User(_SelectedUser.UserName));

                    grdUserExcluded.DataSource = null;
                    grdUserExcluded.DataSource = _ExcludeUserList;
                }

            }

            txtRuleExpression.Text = FwkMembership.BuildRuleExpression(_AssignedRolList, _ExcludeUserList);
        }

        private void removeSelectedsToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
            foreach (DataGridViewRow row in grdAssignedRoles.SelectedRows)
            {
               _AssignedRolList.Remove(((Rol)row.DataBoundItem));
            }
            grdAssignedRoles.DataSource = null;
            grdAssignedRoles.DataSource = _AssignedRolList;
            grdAssignedRoles.Refresh();
            txtRuleExpression.Text = FwkMembership.BuildRuleExpression(_AssignedRolList, _ExcludeUserList);
        }
       
        private void grdAssignedRoles_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                grdAssignedRoles.ClearSelection();
                DataGridView.HitTestInfo hit = grdAssignedRoles.HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.Cell)
                {
                    grdAssignedRoles.Rows[hit.RowIndex].Selected = true;
                    //clickedCell = grdAssignedRoles.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
            
                }
            }
        }

       
       
    }
}
