using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VivaldiSite.DAC;
using Fwk.ConfigData;
using Fwk.ConfigSection;
using System.Web.UI.HtmlControls;

namespace VivaldiSite
{
    public partial class disp_main : System.Web.UI.Page
    {
        private const int _firstEditCellIndex = 2;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsCallback)
                return;
            if (Request.QueryString["disp_inst"] == null)
            {
                Response.Redirect(WebUserControlsConstants.NavigateUrl_Home);
            }
            string disp_inst = Request.QueryString["disp_inst"].ToString();

            if (!this.IsPostBack)
            {

                //string disp_inst = "Healt_Disp_Test";
                DoWork(disp_inst);
            }            
        }
        public string dire;
        public string instanceName;
        public void DoWork(string disp_inst)
        {


            if (DataCoreDAC.Dispatcher_Exist(disp_inst, null))
            {
                int index = 0;
                fwk_ServiceDispatcher disp = DataCoreDAC.Dispatcher_Get(disp_inst);

                //Fwk.Bases.Connector.WebServiceWrapper wrapper = new Fwk.Bases.Connector.WebServiceWrapper();
                //wrapper.SourceInfo = disp.Url_URI;

                instanceName = disp.InstanseName;
                txtInstanceName.Text = disp.InstanseName;
                txtIp.Text = disp.HostIp;
                txtPort.Text = disp.Port.ToString();
                txtServerName.Text = disp.HostName;
                txtUrl.Text = disp.Url_URI;
                txtCompany.Text = disp.CompanyName;
                //string pageUrl = string.Concat(Helper.BaseURL, Helper.VirtualFolder.Equals("/"), "Modules/usr_reg/user_prof_create.aspx?t={0}");
                dire = String.Concat("disp_main_services.aspx?disp_inst=", disp.InstanseName);
                ListItem item = cmbAuditMode.Items.FindByValue(disp.AuditMode.ToString());
                if (item != null)
                {
                    index = cmbAuditMode.Items.IndexOf(item);
                    cmbAuditMode.SelectedIndex = index;
                }
                else
                {
                    cmbAuditMode.SelectedIndex = 0;
                }

                if (disp.Port == null)
                {
                    cmbWrapperType.SelectedIndex = 0; // web service
                }
                else
                {
                    cmbAuditMode.SelectedIndex = 1; // remoting
                }

                DispatcherInfo wDispatcherInfo = GetDispatcherInfo(disp.Url_URI);
                if (wDispatcherInfo != null)
                {
                    grid_ServerSettings.DataSource = wDispatcherInfo.AppSettings;
                    grid_ServerSettings.DataBind();

                    grid_CnnStrings.DataSource = wDispatcherInfo.CnnStringSettings;
                    grid_CnnStrings.DataBind();
                }
            }
        }
        #region GridView

        protected void grid_ServerSettings_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Get the LinkButton control in the first cell
                LinkButton _singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
                // Get the javascript which is assigned to this LinkButton
                string _jsSingle = ClientScript.GetPostBackClientHyperlink(
                    _singleClickButton, "");

                // Add events to each editable cell
                for (int columnIndex = _firstEditCellIndex; columnIndex < e.Row.Cells.Count; columnIndex++)
                {
                    // Add the column index as the event argument parameter
                    string js = _jsSingle.Insert(_jsSingle.Length - 2,
                        columnIndex.ToString());
                    // Add this javascript to the onclick Attribute of the cell
                    e.Row.Cells[columnIndex].Attributes["onclick"] = js;
                    // Add a cursor style to the cells
                    e.Row.Cells[columnIndex].Attributes["style"] +=
                        "cursor:pointer;cursor:hand;";
                }
            }
        }

        protected void grid_ServerSettings_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridView _gridView = (GridView)sender;

            switch (e.CommandName)
            {
                case ("SingleClick"):
                    // Get the row index
                    int _rowIndex = int.Parse(e.CommandArgument.ToString());
                    // Parse the event argument (added in RowDataBound) to get the selected column index
                    int _columnIndex = int.Parse(Request.Form["__EVENTARGUMENT"]);
                    // Set the Gridview selected index
                    _gridView.SelectedIndex = _rowIndex;

                    DispatcherInfo wDispatcherInfo = GetDispatcherInfo(txtUrl.Text);
                    // Bind the Gridview
                    _gridView.DataSource = wDispatcherInfo.AppSettings;
                    _gridView.DataBind();

                    // Write out a history if the event
                    this.Message.Text += "Single clicked GridView row at index " + _rowIndex.ToString()
                        + " on column index " + _columnIndex + "<br />";

                    // Get the display control for the selected cell and make it invisible
                    Control _displayControl = _gridView.Rows[_rowIndex].Cells[_columnIndex].Controls[1];
                    _displayControl.Visible = false;
                    // Get the edit control for the selected cell and make it visible
                    Control _editControl = _gridView.Rows[_rowIndex].Cells[_columnIndex].Controls[3];
                    _editControl.Visible = true;
                    // Clear the attributes from the selected cell to remove the click event
                    _gridView.Rows[_rowIndex].Cells[_columnIndex].Attributes.Clear();

                    // Set focus on the selected edit control
                    ScriptManager.RegisterStartupScript(this, GetType(), "SetFocus",
                        "document.getElementById('" + _editControl.ClientID + "').focus();", true);
                    // If the edit control is a dropdownlist set the
                    // SelectedValue to the value of the display control
                    //if (_editControl is DropDownList && _displayControl is Label)
                    //{
                    //    ((DropDownList)_editControl).SelectedValue = ((Label)_displayControl).Text;
                    //}
                    // If the edit control is a textbox then select the text
                    if (_editControl is TextBox)
                    {
                        ((TextBox)_editControl).Attributes.Add("onfocus", "this.select()");
                    }
                    // If the edit control is a checkbox set the
                    // Checked value to the value of the display control
                    //if (_editControl is CheckBox && _displayControl is Label)
                    //{
                    //    ((CheckBox)_editControl).Checked = bool.Parse(((Label)_displayControl).Text);
                    //}

                    break;
            }
        }

        /// <summary>
        /// Update the sample data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_ServerSettings_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridView _gridView = (GridView)sender;

            if (e.RowIndex > -1)
            {
                // Loop though the columns to find a cell in edit mode
                for (int i = _firstEditCellIndex; i < _gridView.Columns.Count; i++)
                {
                    // Get the editing control for the cell
                    Control _editControl = _gridView.Rows[e.RowIndex].Cells[i].Controls[3];
                    if (_editControl.Visible)
                    {
                        int _dataTableColumnIndex = i - 1;

                        try
                        {
                            // Get the id of the row
                            Label idLabel = (Label)_gridView.Rows[e.RowIndex].FindControl("IdLabel");
                            int id = int.Parse(idLabel.Text);
                            // Get the value of the edit control and update the DataTable
                           
                          
                          
                            //if (_editControl is TextBox)
                            //{
                            //    dr[_dataTableColumnIndex] = ((TextBox)_editControl).Text;
                            //}
                            //else if (_editControl is DropDownList)
                            //{
                            //    dr[_dataTableColumnIndex] = ((DropDownList)_editControl).SelectedValue;
                            //}
                            //else if (_editControl is CheckBox)
                            //{
                            //    dr[_dataTableColumnIndex] = ((CheckBox)_editControl).Checked;
                            //}
                            //dr.EndEdit();

                            //// Save the updated DataTable
                            //_sampleData = dt;

                            // Clear the selected index to prevent 
                            // another update on the next postback
                            _gridView.SelectedIndex = -1;

                            DispatcherInfo wDispatcherInfo = GetDispatcherInfo(txtUrl.Text);
                            // Bind the Gridview
                            _gridView.DataSource = wDispatcherInfo.AppSettings;
                            _gridView.DataBind();
                        }
                        catch (ArgumentException)
                        {
                            this.Message.Text += "Error updating GridView row at index "
                                + e.RowIndex + "<br />";
                            DispatcherInfo wDispatcherInfo = GetDispatcherInfo(txtUrl.Text);
                            // Repopulate the Gridview
                            _gridView.DataSource = wDispatcherInfo.AppSettings;
           
                            _gridView.DataBind();
                        }
                    }
                }
            }
        }


        DispatcherInfo GetDispatcherInfo(string url_URI)
        {
            Fwk.Bases.Connector.WebServiceWrapper wrapper = new Fwk.Bases.Connector.WebServiceWrapper();
            wrapper.SourceInfo = url_URI;
            
            DispatcherInfo wDispatcherInfo = null;
            #region retrive info from server
            try
            {
                wDispatcherInfo = wrapper.RetriveDispatcherInfo();
                UpdatePanel1.Visible = false;
            }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;

                UpdatePanel1.Visible = true;
                return null;
            }
            #endregion

            if (wDispatcherInfo == null)
            {
                msgError.Text = "No fue posible establecer conexión con el dispatcher intentelo mas tarde o pongace en contacto con el administrador del mismo";
                UpdatePanel1.Visible = true;

                return null;
            }
            return wDispatcherInfo;
        }

        void Set_AppSetting( string key ,string values)
        {
            Fwk.Bases.Connector.WebServiceWrapper wrapper = new Fwk.Bases.Connector.WebServiceWrapper();
            wrapper.SourceInfo = txtUrl.Text;

            
        }
        #endregion

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            DoWork("Healt_Disp_Test");
        }

        protected void frm_btGrisNegrita_Click(object sender, EventArgs e)
        {
            fwk_ServiceDispatcher disp = DataCoreDAC.Dispatcher_Get(txtInstanceName.Text);



            disp.InstanseName = txtInstanceName.Text;
            disp.HostIp= txtIp.Text;
     
            disp.HostName=txtServerName.Text;
            disp.Url_URI=txtUrl.Text  ;
            disp.CompanyName=txtCompany.Text ;
            disp.AuditMode = Convert.ToInt16(cmbAuditMode.SelectedValue);

            if(Convert.ToInt16(cmbWrapperType.SelectedValue)== 1)
            {
                Int16 val = 0;
                Int16.TryParse(txtPort.Text, out val);
                disp.Port = val;
            }
            DataCoreDAC.Dispatcher_Update(disp);
        }
    }
}