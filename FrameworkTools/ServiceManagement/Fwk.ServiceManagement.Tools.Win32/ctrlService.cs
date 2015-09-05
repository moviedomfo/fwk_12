using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Bases.FrontEnd;
using Fwk.Bases;
using System.Data;
using Fwk.Bases.FrontEnd.Controls;
using Fwk.ServiceManagement;
using Fwk.Transaction;

namespace Fwk.ServiceManagement.Tools.Win32
{
    [ToolboxItem(true)]
    public partial class ctrlService : FwkUserControlBase
    {

        /// <summary>
        /// Almacena la acción a realizar por el formulario
        /// </summary>
        Action _ShowAction = Action.Query;

        /// <summary>
        /// Recupera y setea la acción a realizar por el formulario
        /// </summary>
        /// <date>2007-07-13T00:00:00</date>
        /// <author>moviedo</author>
        public Action ShowAction
        {
            get { return _ShowAction; }
            set
            {
                _ShowAction = value;
                String wTitle = String.Empty;
                switch (_ShowAction)
                {
                    case Action.Edit:
                        {
                            wTitle = "Service updating";
                            EnableControls(true);
                            break;
                        }
                    case Action.New:
                        {
                            wTitle = "Service creating";
                            EnableControls(true);
                            break;
                        }
                    case Action.Query:
                        {
                            wTitle = "Service consulting";
                            EnableControls(false);
                            break;
                        }
                }

                lblTitle.Text = wTitle;
                this.Text = wTitle;
            }
        }




        /// <summary>
        /// 
        /// </summary>
        public ctrlService()
        {

            InitializeComponent();
            if (!Fwk.HelperFunctions.EnvironmentFunctions.IsInDesigntime())
                Init();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Populate()
        {
            if (this.EntityParam == null) return;
            Fwk.Bases.ServiceConfiguration wServiceConfiguration = (Fwk.Bases.ServiceConfiguration)this.EntityParam;
            bindingSourceService.DataSource = wServiceConfiguration;




            int index = cboIsolationLevel.FindStringExact(Enum.GetName(typeof(Fwk.Transaction.IsolationLevel), wServiceConfiguration.IsolationLevel));
            cboIsolationLevel.SelectedIndex = index;
            index = cboTransactionalBehaviour.FindStringExact(Enum.GetName(typeof(Fwk.Transaction.TransactionalBehaviour), wServiceConfiguration.TransactionalBehaviour));
            cboTransactionalBehaviour.SelectedIndex = index;
        }

        /// <summary>
        /// 
        /// </summary>
        public void FillServiceConfiguration()
        {
            Fwk.Bases.ServiceConfiguration wServiceConfiguration = new Fwk.Bases.ServiceConfiguration();
            wServiceConfiguration = (Fwk.Bases.ServiceConfiguration)bindingSourceService.DataSource;
            wServiceConfiguration.IsolationLevel = (Fwk.Transaction.IsolationLevel)Enum.Parse(typeof(Fwk.Transaction.IsolationLevel), cboIsolationLevel.Text);
            wServiceConfiguration.TransactionalBehaviour = (Fwk.Transaction.TransactionalBehaviour)Enum.Parse(typeof(Fwk.Transaction.TransactionalBehaviour), cboTransactionalBehaviour.Text);

            this.EntityResult = wServiceConfiguration;
        }

        /// <summary>
        /// 
        /// </summary>
        void Init()
        {
            String wTitle = String.Empty;
            foreach (string wName in Enum.GetNames(typeof(Fwk.Transaction.TransactionalBehaviour)))
            {
                cboTransactionalBehaviour.Items.Add(wName);
            }

            foreach (string wName in Enum.GetNames(typeof(Fwk.Transaction.IsolationLevel)))
            {
                cboIsolationLevel.Items.Add(wName);
            }

            cboTransactionalBehaviour.SelectedIndex = 0;
            cboIsolationLevel.SelectedIndex = 0;



        }

        void EnableControls(Boolean pEnable)
        {
            txtName.Enabled = pEnable;
            txtDescription.Enabled = pEnable;
            txtHandler.Enabled = pEnable;
            txtRequest.Enabled = pEnable;
            txtResponse.Enabled = pEnable;

            txtApplicationId.Enabled = pEnable;

            ckbAvailable.Enabled = pEnable;
            ckbAudit.Enabled = pEnable;

            cboTransactionalBehaviour.Enabled = pEnable;
            cboIsolationLevel.Enabled = pEnable;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearControls()
        {
            cboIsolationLevel.SelectedIndex = 0;
            cboIsolationLevel.SelectedIndex = 0;
            txtDescription.Text = String.Empty;
            txtName.Text = String.Empty;
            txtHandler.Text = String.Empty;
            txtRequest.Text = String.Empty;
            txtResponse.Text = String.Empty;
            txtApplicationId.Text = String.Empty;

            ckbAudit.Checked = false;
            ckbAvailable.Checked = false;
        }


    }





    /// <summary>
    /// Enumeración que define la accion a realizar por el formulario.
    /// </summary>
    /// <date>2007-07-13T00:00:00</date>
    /// <author>moviedo</author>
    public enum Action
    {

        /// <summary>
        /// Indica que se creará una nueva configuración de servicio.
        /// </summary>
        New,
        /// <summary>
        /// Indica que se editará una configuración de servicio existente.
        /// </summary>
        Edit,
        /// <summary>
        /// Modo consulta.
        /// </summary>
        Query
    }
}
