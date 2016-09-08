using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.ActiveDirectory;
using Fwk.Bases;

using System.Security.Cryptography.X509Certificates;
using Fwk.Exceptions;

namespace Fwk.Security.AD.TestLogin
{
    public partial class frmDinamic : Form
    {
        LDAPHelper _ADHelper;
        ADWrapper _ADWrapper;
        //IDirectoryService _ADHelperSecure;
        List<DomainUrlInfo> urls = new List<DomainUrlInfo> ();

        public frmDinamic()
        {
            InitializeComponent();
            //DomainUrlInfo d = new DomainUrlInfo();
            //d.DomainDN = "testaa";
            //d.DomainName = "testaa";
            //d.LDAPPath = "LDAP://172.22.14.40/DC=testaa,DC=ar   ";
            //d.Usr = "Conexion";
            //d.Pwd = "UhtUDxCRO6fILkoToU9T6g==";
            //urls.Add(d);
            
//            var str = Newtonsoft.Json.JsonConvert.SerializeObject(urls);
              var str =Fwk.HelperFunctions.FileFunctions.OpenTextFile("domainsurl.json");


              urls = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DomainUrlInfo>>(str);
              domainUrlInfoBindingSource.DataSource = urls;
              cmbDomains.SelectedIndex = 0;
              _DomainUrlInfo = (DomainUrlInfo)cmbDomains.SelectedItem;
              lblURL.Text = _DomainUrlInfo.LDAPPath;
              
        }

        private void btnAutenticate_Click(object sender, EventArgs e)
        {

            lblCheckResult.Clear();
            txtError.Clear();
            try
            {
                if (SetAD(false))
                {
                    TechnicalException logError = null;
                    
                    lblCheckResult.Text = _ADHelper.User_Logon(txtLoginName.Text, txtPassword.Text, out logError).ToString();

                    if (logError != null)
                        txtError.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(logError);
                    //_ADHelper.User_CheckLogin2(txtLoginName.Text, txtPassword.Text);

                }
            }
            catch (Exception ex)
            {
                txtError.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);


            }
        }

        bool SetAD(Boolean pSecure)
        {
            if (_DomainUrlInfo == null)
            {
                lblCheckResult.Text = "Nombre de dominio incorrecto";
                return false;
            }
            //_ADHelper = new ADHelper(wDomainUrlInfo.LDAPPath, wDomainUrlInfo.Usr, wDomainUrlInfo.Pwd);
            _ADHelper = new LDAPHelper(_DomainUrlInfo);
            //_ADHelper = new LDAPHelper(wDomainUrlInfo.DomainName, "testActiveDirectory", pSecure);

            return true;
        }

        void init()
        {

            try
            {
                urls = ADWrapper.DomainsUrl_GetList("ActiveDirectory");//@"Data Source=SANTANA\SQLEXPRESS;Initial Catalog=Logs;Integrated Security=True");

                domainUrlInfoBindingSource.DataSource = urls;
                cmbDomains.SelectedIndex = 1;

                lblURL.Text = ((DomainUrlInfo)cmbDomains.SelectedItem).LDAPPath;
            }
            catch (Exception ex)
            {
                lblCheckResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
                btnAutenticate.Enabled = false;
            }
          


        }
        private void btnRetriveDomains_Click(object sender, EventArgs e)
        {
            init();
        }
        DomainUrlInfo _DomainUrlInfo;
        private void cmbDomains_SelectedIndexChanged(object sender, EventArgs e)
        {
            _DomainUrlInfo = (DomainUrlInfo)cmbDomains.SelectedItem;//urls.Find(p => p.DomainName.Equals(txtDomain.Text,StringComparison.CurrentCultureIgnoreCase));
            if (_DomainUrlInfo == null) return;
            lblURL.Text = _DomainUrlInfo.LDAPPath;

        }
       
        private void frmDinamic_Load(object sender, EventArgs e)
        {
           // lblURL.Text = _DomainUrlInfo.LDAPPath;// ((DomainUrlInfo)cmbDomains.SelectedItem).LDAPPath;
        }

        private void ResetPwd_Click(object sender, EventArgs e)
        {
            try
            {
                if (SetAD(true))
                {
                    String Pwd = null;
                    if (!String.IsNullOrEmpty(txtPassword.Text))
                        Pwd = txtPassword.Text;
                    //_ADHelper.ResetPwd(txtLoginName.Text, Pwd, ForceChange.Checked, UnLock.Checked);
                    lblCheckResult.Text = "Clave Reseteada";
                }
            }
            catch (Exception ex)
            {
                lblCheckResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddRootCert("PelsoftCerts/RootAC.cer");
            AddRootCert("PelsoftCerts/RootPelsoftArgent.cer");
            AddRootCert("PelsoftCerts/RootPelsoftZZ.cer");
        }

        void AddRootCert(String pCertFilePath)
        {
            X509Certificate2 wCertificate = new X509Certificate2(pCertFilePath);
            X509Store wStore = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
            wStore.Open(OpenFlags.ReadWrite);
            wStore.Add(wCertificate);
            wStore.Close();

        }

       

     


    }


}
