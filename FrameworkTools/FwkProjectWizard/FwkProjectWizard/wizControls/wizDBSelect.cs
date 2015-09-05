using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;


using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Fwk.CodeGenerator;
namespace Fwk.Wizard
{
    
    public partial class wizDBSelect : wizBase
    {
        bool onInitServerCollection = true;
        CnnString _cnn = new CnnString();

        public CnnString Cnn
        {
            get { return _cnn; }
            set { _cnn = value; }
        }

        DataTable _AvailableSqlServers;
        Server _Server;
        
        public wizDBSelect()
        {
            InitializeComponent();
        }



      


        void InitServers()
        {

            onInitServerCollection = true;

            if (_AvailableSqlServers == null)
            {
                _AvailableSqlServers = SmoApplication.EnumAvailableSqlServers(false);
                cmbServer.DataSource = _AvailableSqlServers;
                cmbServer.DisplayMember = "Name";


            }
            onInitServerCollection = false;
        }

        /// <summary>
        /// Carga las bses de datos del server
        /// </summary>
        /// <param name="pCnnString"></param>
        void FillDatabaseCombo(CnnString pCnnString)
        {
            if (onInitServerCollection) return;


            SqlConnection sqlConnection = new SqlConnection(pCnnString.ToString());

            ServerConnection serverConnection = new ServerConnection(sqlConnection);

            try
            {
                _Server = new Server(serverConnection);
                cmbDataBases.Items.Clear();
                foreach (Database db in _Server.Databases)
                {
                    cmbDataBases.Items.Add(db.Name);
                }
                cmbDataBases.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(HelperFunctions.GetAllMessageException(ex));
            }
        }


        

        private void cmbServer_Click(object sender, EventArgs e)
        {
            InitServers();
        }



        private void cmbDataBases_Click(object sender, EventArgs e)
        {
            if (_cnn == null)
                _cnn = GetAuxiliarCnnString();

            if (!_cnn.DataSource.Equals(cmbServer.Text.Trim()) || cmbDataBases.Items.Count == 0)
            {
                _cnn.DataSource = cmbServer.Text.Trim();
                FillDatabaseCombo(_cnn);
            }
        }

      

        private void WindowsAutentificaction_CheckedChanged(object sender, EventArgs e)
        {
            if (WindowsAutentificaction.Checked)
            {
                txtPassword.Enabled = false;
                txtUserName.Enabled = false;
            }
            else
            {
                txtPassword.Enabled = true;
                txtUserName.Enabled = true;
            }
        }
      

        private CnnString GetAuxiliarCnnString()
        {
            CnnString wCnnString = new CnnString();


            wCnnString.InitialCatalog = cmbDataBases.Text.Trim();
            wCnnString.DataSource = cmbServer.Text.Trim();

            if (WindowsAutentificaction.Checked)
            {
                wCnnString.User = String.Empty;
                wCnnString.Password = String.Empty;

            }
            else
            {
                wCnnString.User = txtUserName.Text.Trim();
                wCnnString.Password = txtPassword.Text.Trim();
            }

            wCnnString.WindowsAutentification = WindowsAutentificaction.Checked;

            return wCnnString;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            _cnn = GetAuxiliarCnnString();

            if (string.IsNullOrEmpty(_cnn.DataSource))
            {
                MessageBox.Show("Ingrese servidor de SQL.-", "Fwk wizard");
                cmbServer.Focus();
                return;
            }

            if (string.IsNullOrEmpty(_cnn.InitialCatalog))
            {
                MessageBox.Show("Seleccione o ingrese una base de datos.-","Fwk wizard");
                cmbDataBases.Focus();
                return;
            }

           

            if (!_cnn.WindowsAutentification)
            {
                if (string.IsNullOrEmpty(_cnn.User))
                {
                    MessageBox.Show("Ingrese usuario.-", "Fwk wizard");
                    txtUserName.Focus();
                    return;
                }
            }
            SqlConnection sqlConnection = new SqlConnection(_cnn.ToString());

            Microsoft.SqlServer.Management.Common.ServerConnection serverConnection =
              new Microsoft.SqlServer.Management.Common.ServerConnection(sqlConnection);

            try
            {
                _Server = new Server(serverConnection);
               
               
                ////iterate over all Databases
                foreach (Database db in _Server.Databases)
                {
                    MessageBox.Show("Coneccion exitosa.-", "Fwk wizard");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(HelperFunctions.GetAllMessageException(ex), "Fwk wizard");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            UserDefinedTypesBack wUserDefinedTypesBack = new UserDefinedTypesBack(_cnn);
            FwkGeneratorHelper.UserDefinedTypes = wUserDefinedTypesBack.UserDefinedTypes;
            _cnn = GetAuxiliarCnnString();
            base.DoEvent(_cnn, WizardButton.Ok);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DoEvent(null, WizardButton.Cancel);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
           
             _cnn = GetAuxiliarCnnString();
             UserDefinedTypesBack wUserDefinedTypesBack = new UserDefinedTypesBack(_cnn);
             FwkGeneratorHelper.UserDefinedTypes = wUserDefinedTypesBack.UserDefinedTypes;
            base.DoEvent(null, WizardButton.Next);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            base.DoEvent(null, WizardButton.Back);
        }




        public void test()
        {
            cmbDataBases.Text = "AdventureWorks";
            cmbServer.Text = @"SANTANA\SQLEXPRESS";
        }

        private void wizDBSelect_Load(object sender, EventArgs e)
        {
            //TODO: eliminar despues en produccion
            //test();
        }


        internal void LoadCnn(CnnString cnn)
        {
            cmbDataBases.Text = cnn.InitialCatalog;
            cmbServer.Text = cnn.DataSource ;
            WindowsAutentificaction.Checked = cnn.WindowsAutentification;
        }
    }
}
