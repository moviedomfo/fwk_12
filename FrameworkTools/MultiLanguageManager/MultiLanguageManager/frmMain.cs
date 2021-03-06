﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.ConfigSection;
using Fwk.Configuration.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Runtime.Remoting.Messaging;
using Fwk.Exceptions;
using System.Reflection;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace ParamsManager
{
    public delegate void DelegateWithOutAndRefParameters(out Exception ex);
    public partial class frmMain : Fwk.UI.Forms.FormBase
    {
        GridHitInfo _GridHitInfo = null;
       
        ConfigMannagerGridList _ConfigMannagerGridList = new ConfigMannagerGridList();
        DataTable _configPivotDtt = null;
       
        DataRow _fwk_ConfigManager;
       
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            
            PopulateAsync();
            string product = string.Empty;

            // Get all Product attributes on this assembly
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            // If there aren't any Product attributes, return an empty string
            if (attributes.Length != 0)
                product = ((AssemblyProductAttribute)attributes[0]).Product;

            this.Text = String.Concat(product, " version ", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
        }


        void buildgrid()
        {
            //ucManageParams.Init();
            //ConfigManagerGrid p;

            //StringBuilder providerColumns = new StringBuilder();
            //for (int i = 0; i < Fwk.Configuration.ConfigurationManager.ConfigProvider.Providers.Count; i++)
            //{
            //    providerColumns.Append(string.Concat("[", Fwk.Configuration.ConfigurationManager.ConfigProvider.Providers[i].Name, "]"));
            //    if (i < Fwk.Configuration.ConfigurationManager.ConfigProvider.Providers.Count - 1)
            //        providerColumns.Append(",");
         
            //}
            //_configPivotDtt = MultilanguageDAC.RetrivePivotedConfigs(providerColumns.ToString()).Tables[0];
            //_paramsPivotDtt = MultilanguageDAC.RetrivePivotedParams(providerColumns.ToString()).Tables[0];

        }
        
        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
            string language = e.Column.ToString();
            string key = gridView_config.GetDataRow(e.RowHandle)["key"].ToString();
            string group = gridView_config.GetDataRow(e.RowHandle)["group"].ToString();


            try
            {
                MultilanguageDAC.CreateORUpdateKey(language, group, key, e.Value.ToString().Trim());
            }
            catch (Exception ex)
            {
                this.ExceptionViewer.Show(ex);
            }


        }

        private void gridView2_MouseDown(object sender, MouseEventArgs e)
        {
            _GridHitInfo = gridView_config.CalcHitInfo(new Point(e.X, e.Y));
            _fwk_ConfigManager = gridView_config.GetDataRow(_GridHitInfo.RowHandle);
            if (_GridHitInfo.RowHandle < 0)
            {
                addNewKeyToolStripMenuItem.Enabled = true;
                removeSelectedsToolStripMenuItem.Enabled = false;
            }
            else
            {
                removeSelectedsToolStripMenuItem.Enabled = true;
                addNewKeyToolStripMenuItem.Enabled = true;
            }

        }
       
        
       


        #region PopulateSync

        /// <summary>
        /// Carga de manera asincrona los Dominios relacionados entre si en la grilla.-
        /// </summary>
        public void PopulateAsync()
        {
           ucManageParams1.Init();
            //Cursor.Current = Cursors.WaitCursor;
            //Exception ex = null;
            //DelegateWithOutAndRefParameters s = new DelegateWithOutAndRefParameters(Populate);

            //s.BeginInvoke(out ex, new AsyncCallback(EndPopulate), null);
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

                    MessageBox.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
                    return;
                }
                gridControl_config.DataSource = _configPivotDtt;
                gridControl_config.RefreshDataSource();
                gridView_config.RefreshData();

                gridView_config.Columns[0].OptionsColumn.AllowEdit = false;
                gridView_config.Columns[0].OptionsColumn.ReadOnly = false;
                gridView_config.Columns[1].OptionsColumn.AllowEdit = false;
                gridView_config.Columns[1].OptionsColumn.ReadOnly = false;


                gridView_config.Columns[0].AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                gridView_config.Columns[0].AppearanceCell.ForeColor = System.Drawing.Color.SteelBlue;
                gridView_config.Columns[0].AppearanceCell.Options.UseBackColor = true;
                gridView_config.Columns[0].AppearanceCell.Options.UseFont = true;
                gridView_config.Columns[0].AppearanceCell.Options.UseForeColor = true;

                gridView_config.Columns[0].GroupIndex = 0;
                gridView_config.Columns[1].AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                gridView_config.Columns[1].AppearanceCell.ForeColor = System.Drawing.Color.SteelBlue;
                gridView_config.Columns[1].AppearanceCell.Options.UseBackColor = true;
                gridView_config.Columns[1].AppearanceCell.Options.UseFont = true;
                gridView_config.Columns[1].AppearanceCell.Options.UseForeColor = true;


         
                Cursor.Current = Cursors.Default;
                int rowHandler = 0;
                if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
                {
                    //if (_GridHitInfoParam != null)
                    //{
                    //    if (_GridHitInfoParam.RowHandle < 0)
                    //        rowHandler = _GridHitInfoParam.RowHandle;
                    //    else
                    //        rowHandler = gridView_Params.GetParentRowHandle(_GridHitInfoParam.RowHandle);
                    //    gridView_Params.ExpandGroupRow(rowHandler);
                    //}

                }
                if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
                {
                    if (_GridHitInfo != null)
                    {
                        if (_GridHitInfo.RowHandle < 0)
                            rowHandler = _GridHitInfo.RowHandle;
                        else
                            rowHandler = gridView_config.GetParentRowHandle(_GridHitInfo.RowHandle);
                        gridView_config.ExpandGroupRow(rowHandler);
                    }
                }
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
                buildgrid();

            }
            catch (Exception err)
            {
                err.Source = "Origen de datos";
                ex = err;
            }
        }

        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            buildgrid();
        }

 
        
        private void removeSelectedsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_fwk_ConfigManager != null)
            {
                string key = _fwk_ConfigManager["key"].ToString();
                string group = _fwk_ConfigManager["group"].ToString();

                MultilanguageDAC.Remove(group, key);
            }
            this.PopulateAsync();
        }

        
       
        private void addNewKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string group = _fwk_ConfigManager["group"].ToString();
            using (frmAdd frm = new frmAdd(group))
            {
              
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string key  = frm.Key;
                    string errMsg=string.Empty; 
                    try
                    {
                        MultilanguageDAC.CreateNewKey(group, key, out errMsg);
                        this.MessageViewer.Show(errMsg);
                       
                    }
                    catch (Exception ex)
                    {
                        this.ExceptionViewer.Show(ex);
                    }
                    this.PopulateAsync();
                }
            }
        }


        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == System.Windows.Forms.Keys.F5)
            {
                PopulateAsync();
            }
        }

      
       
    }
}
