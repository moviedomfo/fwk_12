using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fwk.Transaction;
using Fwk.ServiceManagement;
using Fwk.Bases;
namespace Fwk.ServiceManagement.Tools.Win32
{
    internal partial class frmEdit : Form
    {

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <date>2007-07-13T00:00:00</date>
        /// <author>moviedo</author>
        internal frmEdit()
        {
            InitializeComponent();


        }

        /// <summary>
        ///  Muestra el formulario configurado para crear una nueva configuración de servicio.
        /// </summary>
        /// <param name="pServiceConfiguration"><see cref="ServiceConfiguration"/></param>
        /// <returns>DialogResult</returns>
        /// <date>2007-07-13T00:00:00</date>
        /// <author>moviedo</author>
        internal static DialogResult ShowNew(ref ServiceConfiguration pServiceConfiguration)
        {
            using (frmEdit wfrmEdit = new frmEdit())
            {
                wfrmEdit.ctrlService1.ShowAction = Action.New;
                wfrmEdit.ctrlService1.EntityParam = pServiceConfiguration;
                wfrmEdit.ctrlService1.Populate();
                wfrmEdit.btnSearchFile.Enabled = true;
                wfrmEdit.Text = wfrmEdit.ctrlService1.Text;
                wfrmEdit.ShowDialog();
                pServiceConfiguration = (ServiceConfiguration)wfrmEdit.ctrlService1.EntityResult;
                return wfrmEdit.DialogResult;
            }
        }

        /// <summary>
        /// Muestra el formulario configurado para editar una configuración de servicio.
        /// </summary>
        /// <param name="pServiceConfiguration">Configuración de servicio a editar.</param>
        /// <date>2007-07-13T00:00:00</date>
        /// <author>moviedo</author>
        internal static DialogResult ShowEdit(ServiceConfiguration pServiceConfiguration)
        {
            using (frmEdit wfrmEdit = new frmEdit())
            {
                wfrmEdit.ctrlService1.ShowAction = Action.Edit;
                wfrmEdit.ctrlService1.EntityParam = pServiceConfiguration;
                wfrmEdit.ctrlService1.Populate();
                wfrmEdit.btnSearchFile.Enabled = false;
                wfrmEdit.Text = wfrmEdit.ctrlService1.Text;
                wfrmEdit.ShowDialog();

                return wfrmEdit.DialogResult;
            }
        }

        /// <summary>
        /// Modo consulta
        /// </summary>
        /// <param name="pServiceConfiguration"><see cref="ServiceConfiguration"/></param>
        /// <returns></returns>
        internal static DialogResult ShowQuery(ServiceConfiguration pServiceConfiguration)
        {
            using (frmEdit wfrmEdit = new frmEdit())
            {
                wfrmEdit.ctrlService1.ShowAction = Action.Query;
                wfrmEdit.ctrlService1.EntityParam = pServiceConfiguration;
                wfrmEdit.ctrlService1.Populate();
                wfrmEdit.btnSearchFile.Enabled = false;
                wfrmEdit.ShowDialog();
                wfrmEdit.Text = wfrmEdit.ctrlService1.Text;
                return wfrmEdit.DialogResult;

            }
        }
        #region < Event handlers >
        private void btnOk_Click(object sender, EventArgs e)
        {
            ctrlService1.FillServiceConfiguration();
            this.DialogResult = DialogResult.OK;

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }
        #endregion

        #region < Private methods >

        private ServiceConfiguration SetServiceConfiguration()
        {
            ctrlService1.FillServiceConfiguration();
            ServiceConfiguration wServiceConfiguration = (ServiceConfiguration)ctrlService1.EntityResult;

            return wServiceConfiguration;

        }




        private void Cancel()
        {
            this.DialogResult = DialogResult.Cancel;
        }

        #endregion

        private void btnSearchFile_Click(object sender, EventArgs e)
        {
            frmAssemblyExplorer wfrmAssemblyExplorer = new frmAssemblyExplorer();
            if (wfrmAssemblyExplorer.ShowDialog() == DialogResult.OK)
            {
                if (wfrmAssemblyExplorer.SelectedServiceConfiguration != null)
                {
                    ServiceConfiguration wServiceConfiguration = wfrmAssemblyExplorer.SelectedServiceConfiguration;
                    wServiceConfiguration.IsolationLevel = Fwk.Transaction.IsolationLevel.ReadCommitted;
                    if (ctrlService1.ShowAction == Action.New)
                    {

                        //Este codigo realiza la supociciobn de que si el servicio es CRUD se realizata transaccional.-
                        if (wServiceConfiguration.Name.Contains("Update") || wServiceConfiguration.Name.Contains("Create") || wServiceConfiguration.Name.Contains("Delete"))
                        {
                            wServiceConfiguration.TransactionalBehaviour = TransactionalBehaviour.RequiresNew;
                        }
                        else
                        {
                            wServiceConfiguration.TransactionalBehaviour = TransactionalBehaviour.Suppres;
                        }
                    }
                    ctrlService1.EntityParam = wServiceConfiguration;
                    ctrlService1.Populate();
                }
            }
        }

    }
}