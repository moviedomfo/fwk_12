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

                int paramCampaingId = Convert.ToInt32(_param);

                MultilanguageDAC.Param_Remove(paramCampaingId);
            }
            this.Init();

        }

        private void iAddParameter_Click(object sender, EventArgs e)
        {
            int wParentId = Convert.ToInt32(_param.ParentId);



            using (frmAddParam frm = new frmAddParam(wParentId))
            {

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frm.Param.ParentId = wParentId;
                    string errMsg = string.Empty;
                    try
                    {
                        //TODO: Latter
                        MultilanguageDAC.Param_CreateNew(frm.Param, string.Empty, out errMsg);
                        this.MessageViewer.Show(errMsg);

                    }
                    catch (Exception ex)
                    {
                        this.ExceptionViewer.Show(ex);
                    }
                    this.Init();
                }
            }

        }
        private void gridView_Params_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string culture = e.Column.ToString();
            //int wParamCampaingIdRelated = Convert.ToInt32(gridView_Params.GetDataRow(e.RowHandle)["ParamCampaingIdRelated"]);
            //int wParamCampaingId = Convert.ToInt32(gridView_Params.GetDataRow(e.RowHandle)["codigo"]);

            if (_param == null) return;

            try
            {
                MultilanguageDAC.Param_CreateORUpdate(culture, _param.ParentId.Value, _param.ParamId, e.Value.ToString().Trim());
                //PopulateAsync();
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



            //label1.Text = string.Concat(_GridHitInfoParam.RowHandle.ToString(), 
            //    " InGroupPanel: ", _GridHitInfoParam.InGroupPanel.ToString(),
            //    " InGroupColumn: ", _GridHitInfoParam.InGroupColumn.ToString());

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
            List<fwk_Param> wParams = null;

            var tareas = Task.WhenAll(LoadParamsAsync()).ContinueWith(res =>
            {

                wParams = res.Result[0];
                if (InvokeRequired)
                    this.Invoke((MethodInvoker)(() =>
                                {
                                    gridControl_Params.DataSource = wParams;
                                    gridControl_Params.RefreshDataSource();
                                    gridView_Params.RefreshData();

                                    //ParamCapaingId ParamCampaingIdRelated Tipo  
                   
                         

                                  colName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                                  colName.AppearanceCell.ForeColor = System.Drawing.Color.SteelBlue;
                                    colName.AppearanceCell.Options.UseBackColor = true;
                                    colName.AppearanceCell.Options.UseFont = true;
                                    colName.AppearanceCell.Options.UseForeColor = true;

                                    //gridView_Params.Columns[2].GroupIndex = 0;
                                    //gridView_Params.Columns[2].AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                                    //gridView_Params.Columns[2].AppearanceCell.ForeColor = System.Drawing.Color.SteelBlue;
                                    //gridView_Params.Columns[2].AppearanceCell.Options.UseBackColor = true;
                                    //gridView_Params.Columns[2].AppearanceCell.Options.UseFont = true;
                                    //gridView_Params.Columns[2].AppearanceCell.Options.UseForeColor = true;
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
