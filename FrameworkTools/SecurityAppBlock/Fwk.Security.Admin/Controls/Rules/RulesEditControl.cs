using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.Common;
using System.Web.Security;
using System.Runtime.Remoting.Messaging;
using DevExpress.XtraTreeList;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTreeList.Nodes;

namespace Fwk.Security.Admin.Controls
{
    public partial class RulesEditControl : SecurityControlBase
    {
        CategoryTree _CurrentCategory = null;


        UserList _ExcludeUserList = new UserList();
        RolList _AssignedRolList = new RolList();
        FwkCategoryList _CategoryList;
        CategoryTreeList _CategoryTreeList;
        CategoryTree _ParentFwkCategory;

        List<FwkAuthorizationRule> _AllRuleList;
        FwkAuthorizationRule _CurrentRule;
        /// <summary>
        /// Representa la informacion del tipo de control a instanciar 
        /// 
        /// </summary>
        public override string AssemblySecurityControl
        {
            get
            {
                return typeof(RulesEditControl).AssemblyQualifiedName;
            }
        }
        Cursor moveCursor;
        public override void Initialize()
        {
            //txtRuleName.Focus();
            using (new WaitCursorHelper(this))
            {

                _AllRuleList = FwkMembership.GetRulesAuxList(frmAdmin.Provider.Name);
                fwkAuthorizationRuleBindingSource.DataSource = _AllRuleList;
                grdAllRules.RefreshDataSource();

                _CategoryList = FwkMembership.GetAllCategories(frmAdmin.Provider.Name);
                _CategoryTreeList = CategoryTreeList.Retrive_CategoryTreeList(_CategoryList);
                treeList1.BeginUnboundLoad();

                this.categoryTreeBindingSource.DataSource = _CategoryTreeList;
                treeList1.RefreshDataSource();
                treeList1.EndUnboundLoad();
                treeList1.ExpandAll();

                moveCursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Fwk.Security.Admin.Resources.move_16.ico"));
            }
        }
        public RulesEditControl()
        {
            InitializeComponent();
        }


        #region Async
        public delegate void DelegateWithOutAndRefParameters(out Exception ex);
        /// <summary>
        /// Carga de manera asincrona los Dominios relacionados entre si en la grilla.-
        /// </summary>
        public void PopulateAsync()
        {
            Exception ex = null;
            DelegateWithOutAndRefParameters s = new DelegateWithOutAndRefParameters(Populate);

            s.BeginInvoke(out ex, new AsyncCallback(EndPopulate), null);


        }
        /// <summary>
        /// Fin de el metodo populate que fue llamado de forma asincrona
        /// </summary>
        /// <param name="res"></param>
        void EndPopulate(IAsyncResult res)
        {
            Exception ex;
            if (this.InvokeRequired)
            {
                AsyncCallback d = new AsyncCallback(EndPopulate);
                this.Invoke(d, new object[] { res });

            }
            else
            {
                AsyncResult result = (AsyncResult)res;


                DelegateWithOutAndRefParameters del = (DelegateWithOutAndRefParameters)result.AsyncDelegate;
                del.EndInvoke(out ex, res);
                if (ex != null)
                {
                    throw ex;
                }
                treeList1.BeginUnboundLoad();
                this.categoryTreeBindingSource.DataSource = _CategoryTreeList;
                treeList1.RefreshDataSource();
                treeList1.EndUnboundLoad();
                treeList1.ExpandAll();

                _AllRuleList = FwkMembership.GetRulesAuxList(frmAdmin.Provider.Name);
                fwkAuthorizationRuleBindingSource.DataSource = _AllRuleList;
                grdAllRules.RefreshDataSource();

            }
        }

        /// <summary>
        /// Carga Dominios relacionados entre al objeto _RelatedDomains que esta bindiado a la grilla
        /// </summary>
        void Populate(out Exception ex)
        {
            ex = null;

            try
            {

                _CategoryList = FwkMembership.GetAllCategories(frmAdmin.Provider.Name);
                _CategoryTreeList = CategoryTreeList.Retrive_CategoryTreeList(_CategoryList);
            }
            catch (Exception err)
            {
                err.Source = "Origen de datos";
                ex = err;
            }



        }

        #endregion












        private void mAddNewCategory_Click(object sender, EventArgs e)
        {
            using (frmAddName frm = new frmAddName())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(frm.Tag.ToString()) && _CurrentCategory != null)
                        if (FwkMembership.ExistCategory(frm.Tag.ToString().Trim(), Convert.ToInt32(_CurrentCategory.Id), frmAdmin.Provider.Name))
                        {
                            MessageViewInfo.Show(string.Format("Category {0} already exist", frm.Tag.ToString()));
                            return;
                        }
                        else
                            Create_Categoty(frm.Tag.ToString());
                }
            }


        }

        private void addRootcategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmAddName frm = new frmAddName())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(frm.Tag.ToString()))
                        if (FwkMembership.ExistCategory(frm.Tag.ToString().Trim(), 0, frmAdmin.Provider.Name))
                        {
                            MessageViewInfo.Show(string.Format("Category {0} already exist", frm.Tag.ToString()));
                            return;
                        }
                        else
                        {
                            _CurrentCategory = null;
                            Create_Categoty(frm.Tag.ToString());
                        }
                }
            }
        }

        void Create_Categoty(string name)
        {
            FwkCategory wFwkCategory = new FwkCategory();

            wFwkCategory.Name = name;
            if (_CurrentCategory != null)
                wFwkCategory.ParentId = Convert.ToInt32(_CurrentCategory.Id);
            else
                wFwkCategory.ParentId = 0;

            try
            {
                FwkMembership.CreateCategory(wFwkCategory, frmAdmin.Provider.Name);
                MessageViewInfo.Show("Category was successfully created");
                PopulateAsync();
            }
            catch (Exception ex)
            { throw ex; }

        }

        private void mRemove_Click(object sender, EventArgs e)
        {
            if (_CurrentCategory.IsCategory == false)
            {
                //Obtengo el padre
                _ParentFwkCategory = _CategoryTreeList.Where(p => p.Id.Equals(_CurrentCategory.ParentId)).FirstOrDefault<CategoryTree>();
                _ParentFwkCategory.RemoveRule(_CurrentCategory.Name);
                _CategoryTreeList.RemoveItem(_CurrentCategory.Id);//No es necesario ya que se ejecurara luego --> PopulateAsync
                try
                {
                    FwkMembership.CreateRuleInCategory(_ParentFwkCategory.FwkCategory, frmAdmin.Provider.Name);
                    MessageViewInfo.Show("Rule was successfully removed from category");
                    PopulateAsync();
                }
                catch (Exception ex)
                { throw ex; }
            }
            else
            {
                DialogResult r = MessageBox.Show("Will have to delete the category and recursively all its subcategories", "Rules mannager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    try
                    {
                        FwkMembership.RemoveCategory(_CurrentCategory.FwkCategory.CategoryId, frmAdmin.Provider.Name);
                        MessageViewInfo.Show("Category was successfully removed ");
                        PopulateAsync();
                    }
                    catch (Exception ex)
                    { throw ex; }
                }

            }
        }


        private void treeList1_KeyDown(object sender, KeyEventArgs e)
        {
            TreeList tl = sender as TreeList;
            if (tl.FocusedNode != null)
            {
                if (e.KeyCode == Keys.Right)
                {
                    if (!tl.FocusedNode.Expanded && tl.FocusedNode.HasChildren)
                        tl.FocusedNode.Expanded = true;
                    else tl.MoveNextVisible();
                }
                if (e.KeyCode == Keys.Left)
                {
                    if (tl.FocusedNode.Expanded)
                        tl.FocusedNode.Expanded = false;
                    else tl.MovePrevVisible();
                }
            }
        }

        private void treeList1_MouseClick(object sender, MouseEventArgs e)
        {
            //TreeList tl = sender as TreeList;
            //if (tl.FocusedNode != null)
            //    if (tl.FocusedNode.HasChildren)
            //        tl.FocusedNode.Expanded = !tl.FocusedNode.Expanded;
        }
        TreeListHitInfo _HitInfo = null;
        private void treeList1_MouseDown(object sender, MouseEventArgs e)
        {

            _HitInfo = treeList1.CalcHitInfo(new Point(e.X, e.Y));
            if (_HitInfo.Node == null) return;
            _CurrentCategory = (CategoryTree)treeList1.GetDataRecordByNode(_HitInfo.Node);
            lblCurrentCategory.Text = _CurrentCategory.Name;

            mAddNewCategory.Enabled = _CurrentCategory.IsCategory;
            if (_CurrentCategory.IsCategory)
                mRemove.Text = "Remove category";
            else
                mRemove.Text = "Remove rule";
            treeList1.SetFocusedNode(_HitInfo.Node);

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {

                treeList1.DoDragDrop(_CurrentCategory, DragDropEffects.Move);
            }
        }

        #region (Tree List) Eventos y Métodos Drag hacia otro componente

        private void treeList1_DragDrop(object sender, DragEventArgs e)
        {
            FwkAuthorizationRule rule = null;
            CategoryTree wCategoryTree_ToMove = null;
            TreeListHitInfo wHitInfo = treeList1.CalcHitInfo(treeList1.PointToClient(new Point(e.X, e.Y)));
            if (wHitInfo.Node == null)
                return;

            rule = e.Data.GetData(typeof(FwkAuthorizationRule)) as FwkAuthorizationRule;

            if (rule == null)
            {
                wCategoryTree_ToMove = e.Data.GetData(typeof(CategoryTree)) as CategoryTree;
            }
            //List<FwkAuthorizationRule> wRuleList = e.Data.GetData(typeof(List<FwkAuthorizationRule>)) as List<FwkAuthorizationRule>;
            //FwkAuthorizationRule rule = e.Data.GetData(typeof(FwkAuthorizationRule)) as FwkAuthorizationRule;
            #region Move rule
            if (rule != null)
            {

                _CurrentCategory = (CategoryTree)treeList1.GetDataRecordByNode(wHitInfo.Node);
                lblCurrentCategory.Text = _CurrentCategory.Name;
                if (_CurrentCategory.IsCategory == false)
                {
                    //Obtengo el padre
                    _ParentFwkCategory = _CategoryTreeList.Where(p => p.Id.Equals(_CurrentCategory.ParentId)).FirstOrDefault<CategoryTree>();
                    _CurrentCategory = _ParentFwkCategory;
                }

                #region Add Rules to Category

                if (!_CurrentCategory.AnyRule(rule.Name))
                {

                    _CurrentCategory.AddRule(rule);
                    FwkMembership.CreateRuleInCategory(_CurrentCategory.FwkCategory, frmAdmin.Provider.Name);
                }

                #endregion

                PopulateAsync();
            }

            #endregion


            if (wCategoryTree_ToMove != null)
            {
                if (wCategoryTree_ToMove.Id == _CurrentCategory.Id)
                {
                    Cursor = Cursors.Default;
                    return;
                }

                #region Mueve una categoria
                if (wCategoryTree_ToMove.IsCategory)
                {
                    if (_CurrentCategory.IsCategory == false)
                    {
                        //Obtengo el padre de la categoria destino 
                        _ParentFwkCategory = _CategoryTreeList.Where(p => p.Id.Equals(_CurrentCategory.ParentId)).FirstOrDefault<CategoryTree>();
                        _CurrentCategory = _ParentFwkCategory;
                    }
                    if (wCategoryTree_ToMove.ParentId == _CurrentCategory.Id)
                    {
                        Cursor = Cursors.Default;
                        return;
                    }

                    FwkMembership.UpdateParentCategory(
                        wCategoryTree_ToMove.FwkCategory.CategoryId,
                        wCategoryTree_ToMove.FwkCategory.ParentId.Value,
                        _CurrentCategory.FwkCategory.CategoryId,
                        frmAdmin.Provider.Name);
                }
                #endregion

                #region Mueve una regla a otra categoria
                if (wCategoryTree_ToMove.IsCategory == false)
                {
                    if (_CurrentCategory.IsCategory == false)
                    {
                        //Obtengo el padre de la categoria destino 
                        _CurrentCategory = _CategoryTreeList.Where(p => p.Id.Equals(_CurrentCategory.ParentId)).FirstOrDefault<CategoryTree>();

                    }
                    if (wCategoryTree_ToMove.ParentId == _CurrentCategory.Id)
                    {
                        Cursor = Cursors.Default;
                        return;
                    }

                    if (!_CurrentCategory.AnyRule(wCategoryTree_ToMove.Name))
                    {

                        _CurrentCategory.AddRule(wCategoryTree_ToMove.FwkAuthorizationRule);
                        FwkMembership.CreateRuleInCategory(_CurrentCategory.FwkCategory, frmAdmin.Provider.Name);

                        //Obtengo el padre de la regla a mover para eliminarle la regla
                        _ParentFwkCategory = _CategoryTreeList.Where(p => p.Id.Equals(wCategoryTree_ToMove.ParentId)).FirstOrDefault<CategoryTree>();
                        _ParentFwkCategory.RemoveRule(wCategoryTree_ToMove.Name);
                        FwkMembership.CreateRuleInCategory(_ParentFwkCategory.FwkCategory, frmAdmin.Provider.Name);

                    }


                }
                #endregion

                PopulateAsync();
            }
            Cursor = Cursors.Default;
        }

        private void treeList1_DragOver(object sender, DragEventArgs e)
        {

            TreeListHitInfo hi = treeList1.CalcHitInfo(treeList1.PointToClient(new Point(e.X, e.Y)));
            _CurrentCategory = (CategoryTree)treeList1.GetDataRecordByNode(hi.Node);
            if (_CurrentCategory == null)
                e.Effect = DragDropEffects.None;
            if (_CurrentCategory != null)
            {
                lblCurrentCategory.Text = _CurrentCategory.Name;

                e.Effect = DragDropEffects.Move;
            }


            SetDragCursor(DragDropEffects.Move);
        }


        private void treeList1_DragLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }


        private void SetDragCursor(DragDropEffects e)
        {
            // return;
            if (e == DragDropEffects.Move)
                Cursor = moveCursor;//new Cursor(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Fwk.Security.Admin.Resources.move_16.ico"));
            if (e == DragDropEffects.Copy)
                Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Fwk.Security.Admin.Resources.copy_24.ico"));
            if (e == DragDropEffects.None)
                Cursor = Cursors.No;

        }
        #endregion

        #region (Grilla) Eventos y Métodos Drag hacia otro componente
        GridHitInfo _GridHitInfo = null;
        private void gridView_AllRules_MouseDown(object sender, MouseEventArgs e)
        {
            _GridHitInfo = gridView_AllRules.CalcHitInfo(new Point(e.X, e.Y));
            _CurrentRule = ((FwkAuthorizationRule)gridView_AllRules.GetRow(_GridHitInfo.RowHandle));
            if (_CurrentRule != null)
                lblSelectedRule.Text = _CurrentRule.Name;

        }

        private void gridView_AllRules_MouseMove(object sender, MouseEventArgs e)
        {
            if (_GridHitInfo == null || e.Button != MouseButtons.Left || _GridHitInfo.HitTest == GridHitTest.RowIndicator)
                return;
            //_CurrentRule = ((FwkAuthorizationRule)gridView_AllRules.GetRow(_GridHitInfo.RowHandle));

            if (_GridHitInfo.InRowCell)
            {
                //FwkAuthorizationRule rule = null;
                //List<FwkAuthorizationRule> wRuleList = new List<FwkAuthorizationRule>();
                //Recorro todas las filas seleccionadas y obtengo el UserId y el Name y los agrego a la lista de usuarios
                //foreach (int wFila in gridView_AllRules.GetSelectedRows())
                //{
                //    rule = (FwkAuthorizationRule)(gridView_AllRules.GetRow(wFila));
                //    wRuleList.Add(rule.Clone());
                //}

                grdAllRules.DoDragDrop(_CurrentRule, DragDropEffects.Move);
                lblSelectedRule.Text = _CurrentRule.Name;

                SetDragCursor(DragDropEffects.Move);

            }

        }

        private void grdAllRules_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            SetDragCursor(DragDropEffects.Move);
        }

        #endregion

        private void treeList1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }

        private void btnAddNewRule_Click(object sender, EventArgs e)
        {
            using (frmRulesAdmin frm = new frmRulesAdmin())
            {

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _AllRuleList = FwkMembership.GetRulesAuxList(frmAdmin.Provider.Name);
                    fwkAuthorizationRuleBindingSource.DataSource = _AllRuleList;
                    grdAllRules.RefreshDataSource();
                }
            }
        }


        private void treeList1_GetStateImage(object sender, GetStateImageEventArgs e)
        {
            e.NodeImageIndex = e.Node.Expanded ? 1 : 0;
        }





        private void treeList1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void gridView_AllRules_DoubleClick(object sender, EventArgs e)
        {
            if (_CurrentRule == null) return;
            using (frmRulesAdmin frm = new frmRulesAdmin(_CurrentRule.Name))
            {

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _AllRuleList = FwkMembership.GetRulesAuxList(frmAdmin.Provider.Name);
                    fwkAuthorizationRuleBindingSource.DataSource = _AllRuleList;
                    grdAllRules.RefreshDataSource();
                }
            }
        }

        private void mUpdateRule_Click(object sender, EventArgs e)
        {
            if (_CurrentRule == null) return;
            using (frmRulesAdmin frm = new frmRulesAdmin(_CurrentRule.Name))
            {

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _AllRuleList = FwkMembership.GetRulesAuxList(frmAdmin.Provider.Name);
                    fwkAuthorizationRuleBindingSource.DataSource = _AllRuleList;
                    grdAllRules.RefreshDataSource();
                }
            }
        }

        private void mDeleteRule_Click(object sender, EventArgs e)
        {
            if (_CurrentRule == null) return;
            DialogResult res = DialogResult.No;
            res = MessageBox.Show(string.Concat("Are you shure to remove ", _CurrentRule.Name, " ?"), "Security ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                foreach (CategoryTree category in _CategoryTreeList.Where(p => p.IsCategory))
                {

                    if (category.AnyRule(_CurrentRule.Name))
                    {
                        res = MessageBox.Show(string.Concat(_CurrentRule.Name, " is in ", category.Name, "\r\n Are you shure remove it ?"), "Security ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (res == DialogResult.Yes)
                        {
                            category.RemoveRule(_CurrentRule.Name);
                            FwkMembership.CreateRuleInCategory(category.FwkCategory, frmAdmin.Provider.Name);
                        }
                    }

                }
            }
            if (res == DialogResult.Yes)
            {

                FwkMembership.DeleteRule(_CurrentRule.Name, frmAdmin.Provider.Name);
            }

            PopulateAsync();
        }

        private void mCreateRuele_Click(object sender, EventArgs e)
        {
            using (frmRulesAdmin frm = new frmRulesAdmin())
            {

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _AllRuleList = FwkMembership.GetRulesAuxList(frmAdmin.Provider.Name);
                    fwkAuthorizationRuleBindingSource.DataSource = _AllRuleList;
                    grdAllRules.RefreshDataSource();
                }
            }
        }
    }
}
