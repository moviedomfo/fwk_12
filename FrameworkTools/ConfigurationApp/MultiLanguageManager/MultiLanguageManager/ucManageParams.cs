using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace MultiLanguageManager
{
    [ToolboxItem(true)]
    public partial class ucManageParams : Fwk.UI.Controls.UC_UserControlBase
    {
        List<fwk_Param> _AllParams = null;
        fwk_Param _param;
        GridHitInfo _GridHitInfoParam = null;
        public ucManageParams()
        {
            InitializeComponent();
        }

        private void ucManageParams_Load(object sender, EventArgs e)
        {


        }

        private void iRemoveParameter_Click(object sender, EventArgs e)
        {
            if (_param != null)
            {
               
                this.Init();
            }
            try
            {
                MultilanguageDAC.Param_ValidateRemove(_param);
                MultilanguageDAC.Param_Remove(_param.ParamId);
                Init();
            }
            catch (Exception ex)
            {
                this.ExceptionViewer.Show(ex);

            }

        }
          private void agregarHijoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fwk_Param parent = null;
            //if (_param.ParentId.HasValue)
            //{
            //    parent = _AllParams.Where(p => p.ParamId.Equals(_param.ParentId.Value)).FirstOrDefault<fwk_Param>();
            //}
            using (frmAddParam frm = new frmAddParam(_param))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        //TODO: Latter
                        MultilanguageDAC.Param_CreateNew(frm.Param);
                    }
                    catch (Exception ex)
                    {
                        this.ExceptionViewer.Show(ex);
                    }
                    this.Init();
                }
            }

        }
        private void iAddParameter_Click(object sender, EventArgs e)
        {

            fwk_Param parent = null;
            if (_param.ParentId.HasValue)
            {
                parent = _AllParams.Where(p => p.ParamId.Equals(_param.ParentId.Value)).FirstOrDefault<fwk_Param>();
            }

            using (frmAddParam frm = new frmAddParam(parent))
            {

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {


                    try
                    {
                        //TODO: Latter
                        MultilanguageDAC.Param_CreateNew(frm.Param);


                    }
                    catch (Exception ex)
                    {
                        this.ExceptionViewer.Show(ex);
                    }
                    this.Init();
                }
            }

        }
        

        private void gridView_Params_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //_param = ((fwk_Param)gridView_Params.GetRow(e.RowHandle));
            //if (_param == null) return;

            //try
            //{
            //    MultilanguageDAC.Param_ValidateUpdate(_param);
            //    e.Valid = true;
            //}
            //catch (Exception ex)
            //{

            //    e.ErrorText = "Error";//             ex.Message;
            //    e.Valid = false;
            //}
            
            
            
        }

        private void gridView_Params_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            _param = ((fwk_Param)gridView_Params.GetRow(e.RowHandle));

           
            if (_param == null) return;

            try
            {
                MultilanguageDAC.Param_ValidateUpdate(_param);
                MultilanguageDAC.Param_Update(_param);
                Init();
            }
            catch (Exception ex)
            {
                this.ExceptionViewer.Show(ex);

            }
           
        }
        private void gridView_Params_MouseDown(object sender, MouseEventArgs e)
        {
            _GridHitInfoParam = gridView_Params.CalcHitInfo(new Point(e.X, e.Y));

            _param = ((fwk_Param)gridView_Params.GetRow(_GridHitInfoParam.RowHandle));
            if (_param == null) return;


            if (_GridHitInfoParam.RowHandle < 0)
            {
                addNewKeyToolStripMenuItem.Enabled = true;
                //removeSelectedsToolStripMenuItem.Enabled = false;
            }
            else
            {
                //removeSelectedsToolStripMenuItem.Enabled = true;
                addNewKeyToolStripMenuItem.Enabled = true;
            }
        }
        public void Init()
        {
            Cursor.Current = Cursors.WaitCursor;


            var tareas = Task.WhenAll(LoadParamsAsync()).ContinueWith(res =>
            {

                _AllParams = res.Result[0];
                if (InvokeRequired)
                    this.Invoke((MethodInvoker)(() =>
                                {
                                    gridControl_Params.DataSource = _AllParams;
                                    gridControl_Params.RefreshDataSource();
                                    gridView_Params.RefreshData();


                                    colName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                                    colName.AppearanceCell.ForeColor = System.Drawing.Color.SteelBlue;
                                    colName.AppearanceCell.Options.UseBackColor = true;
                                    colName.AppearanceCell.Options.UseFont = true;
                                    colName.AppearanceCell.Options.UseForeColor = true;

                                    Cursor.Current = Cursors.Default;

                                }));


            });


        }
        public Task<List<fwk_Param>> LoadParamsAsync()
        {
            Task<List<fwk_Param>> task = Task<List<fwk_Param>>.Run(() => MultilanguageDAC.Params_Retrive());
            return task;
        }

      

      
       

     
    }



}
