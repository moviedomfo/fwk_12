using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Net;

namespace CentralizedSecurity.W32.Test
{
    public partial class Form1 : Form
    {
        Fwk.Caching.FwkSimpleStorageBase<Cache> storage = new Fwk.Caching.FwkSimpleStorageBase<Cache>();
        string usr = "moviedo";
        string pwd = "Lincelin5";
        public Form1()
        {
            InitializeComponent();
            
        }
       

        string GetLoogonUserResult(CentralizedSecurity.W32.Test.ServiceReference1.LoogonUserResult loogonRes)
        {
            StringBuilder s = new StringBuilder(loogonRes.LogResult.ToString());
            s.AppendLine();
            s.AppendLine(loogonRes.ErrorMessage);
            return s.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {

           
            //try
            //{

            //    SecurityReference.SecuritySoap proxy = null;
            //    //Creo el ChannelFactory
            //    var cf = new ChannelFactory<SecurityReference.SecuritySoap>("SecuritySoap");

            //    //Tomo los elementos del Binding y seteo IncludeTimestamp en false
            //    BindingElementCollection elements = cf.Endpoint.Binding.CreateBindingElements();
            //    //elements.Find<SecurityBindingElement>().IncludeTimestamp = false;
            //    // Creo un nuevo binding con los elementos modificados
            //    CustomBinding newBinding = new CustomBinding(elements);
            //    //Asigno el nuevo binding al Endpoint
            //    cf.Endpoint.Binding = newBinding;
            //    cf.Credentials.UserName.UserName = usr;
            //    cf.Credentials.UserName.Password = pwd;
            //    EndpointAddress endpoint = new EndpointAddress("http://localhost/CentralizedSecurity/security.asmx?");
            //    proxy = cf.CreateChannel(endpoint);
            //    SecurityReference.Retrive_DomainsUrlRequest req = new SecurityReference.Retrive_DomainsUrlRequest();

            //    CentralizedSecurity.W32.Test.SecurityReference.Retrive_DomainsUrlResponse res = proxy.Retrive_DomainsUrl(req);
            //    MessageBox.Show(res.Body.Retrive_DomainsUrlResult);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //try
            //{

            //    using (SecurityReference.SecuritySoapClient clientProxy = new SecurityReference.SecuritySoapClient())
            //    {
            //        BasicHttpBinding basicHttpBinding = new BasicHttpBinding();

            //        basicHttpBinding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;

            //        basicHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;

            //        //EndpointAddress endpoint = new EndpointAddress("http://localhost/CentralizedSecurity/security.asmx?");
            //        clientProxy.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.None;

            //        //clientProxy.ChannelFactory.Credentials.Windows.ClientCredential = System.Net.CredentialCache.DefaultNetworkCredentials;
            //        clientProxy.ChannelFactory.Credentials.Windows.ClientCredential.UserName = usr;
            //        clientProxy.ChannelFactory.Credentials.Windows.ClientCredential.Password = pwd;
            //        clientProxy.ChannelFactory.Credentials.Windows.ClientCredential.Domain = "allus-ar";

            //        //clientProxy.ClientCredentials.Windows.ClientCredential.UserName = "moviedo";
            //        //clientProxy.ClientCredentials.Windows.ClientCredential.Password = "Lincelin4";
            //        //clientProxy.ClientCredentials.Windows.ClientCredential.Domain = "allus-ar";
            //        MessageBox.Show(clientProxy.Retrive_DomainsUrl());
            //    }
            //}
            //catch (Exception t)
            //{
            //    MessageBox.Show(t.Message);
            //}


            //try
            //{
            //    using (SecurityReference.SecuritySoapClient clientProxy = new SecurityReference.SecuritySoapClient())
            //    {
            //        //Creo el ChannelFactory
            //        clientProxy.ClientCredentials.Windows.ClientCredential.UserName = usr;

            //        clientProxy.ClientCredentials.Windows.ClientCredential.Password = pwd;
            //        clientProxy.ClientCredentials.Windows.ClientCredential.Domain = "allus-ar";
            //        //System.Net.NetworkCredential cr = new System.Net.NetworkCredential("moviedo", "3");
            //        //clientProxy.InnerChannel.cre.ClientCertificate.Certificate = certificado;
            //        MessageBox.Show(clientProxy.Retrive_DomainsUrl());


            //    }
            //}
            //catch (Exception t)
            //{
            //    MessageBox.Show(t.Message);
            //}
        }
        //SecurityReference.SecuritySoapClient client = new SecurityReference.SecuritySoapClient();
     
        void Retrive_DomainsUrlCallback(IAsyncResult result)
        {
            txtResult.Text = string.Empty;
            ServiceReference1.CoreSecurityClient clientProxy = new ServiceReference1.CoreSecurityClient("wcf_iis");
            try
            {
                AuthenticateService(clientProxy);
                txtResult.Text=clientProxy.GetDomainNames();
                clientProxy.Close();
            }
            catch (FaultException fx)
            {
                txtResult.Text = "FaultException\r\n" + Fwk.Exceptions.ExceptionHelper.GetAllMessageException(fx);
                clientProxy.Abort();

            }
            catch (Exception err)
            {

                txtResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(err);
                clientProxy.Abort();
            }


            
        }

        private void Authenticate_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
            ServiceReference1.CoreSecurityClient clientProxy = null;
            try
            {
                clientProxy = new ServiceReference1.CoreSecurityClient("wcf_iis");
                AuthenticateService(clientProxy);



                CentralizedSecurity.W32.Test.ServiceReference1.LoogonUserResult loogonRes =
                    clientProxy.Authenticate(txtAuthenticate_UserName.Text,
                    txtAuthenticate_Password.Text,
                    txtAuthenticate_Domain.Text);
                string x = GetLoogonUserResult(loogonRes);
                //                    string x = clientProxy.Test();
                txtResult.Text = x;

                clientProxy.Close();
            }
            catch (FaultException fx)
            {
                txtResult.Text = "FaultException\r\n" + Fwk.Exceptions.ExceptionHelper.GetAllMessageException(fx);
                if (clientProxy != null)
                    clientProxy.Abort();

            }
            catch (Exception err)
            {

                txtResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(err);
                if (clientProxy != null)
                    clientProxy.Abort();
            }
        }

        void AuthenticateService(CentralizedSecurity.W32.Test.ServiceReference1.CoreSecurityClient proxyClient)
        {
            proxyClient.ClientCredentials.UserName.UserName = txtUser.Text.Trim();
            proxyClient.ClientCredentials.UserName.Password =  txtPwd.Text.Trim();
            
            proxyClient.ClientCredentials.Windows.ClientCredential.UserName = txtUser.Text.Trim();
            proxyClient.ClientCredentials.Windows.ClientCredential.Password = txtPwd.Text.Trim();
            proxyClient.ClientCredentials.Windows.ClientCredential.Domain = txtDomain.Text.Trim();
            if (chkUseProxy.Checked)
            {
                WebProxy proxy = new WebProxy(storage.StorageObject.ProxyAddress, false);
                proxy.Credentials = new NetworkCredential(storage.StorageObject.ProxyUser, storage.StorageObject.ProxyPassword, storage.StorageObject.ProxyDomain);
                WebRequest.DefaultWebProxy = proxy;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            storage.Load();
            chkUseProxy.Checked = storage.StorageObject.UseProxy;
            txtUserProxy.Text = storage.StorageObject.ProxyUser;
            txtPwdProxy.Text = storage.StorageObject.ProxyPassword;
            cmbDomain.Text = storage.StorageObject.ProxyDomain;
            txtProxyAddress.Text = storage.StorageObject.ProxyAddress;

            txtUser.Text = storage.StorageObject.WCFUser;
            txtPwd.Text = storage.StorageObject.WCFPassword;
            txtDomain.Text = storage.StorageObject.WCFDomain;


            txtAuthenticate_UserName.Text = storage.StorageObject.AuthUser;
            txtAuthenticate_Password.Text = storage.StorageObject.AuthPassword;
            txtAuthenticate_Domain.Text = storage.StorageObject.AuthDomain;


        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            SaveStorage();
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            SaveStorage();
            base.OnClosing(e);
        }

        bool SaveStorage()
        {
            try
            {
                storage.StorageObject.UseProxy = chkUseProxy.Checked;
                storage.StorageObject.ProxyUser = txtUserProxy.Text;
                storage.StorageObject.ProxyPassword = txtPwdProxy.Text;
                storage.StorageObject.ProxyDomain = cmbDomain.Text;
                storage.StorageObject.ProxyAddress = txtProxyAddress.Text;



                storage.StorageObject.WCFUser = txtUser.Text;
                storage.StorageObject.WCFPassword = txtPwd.Text;
                storage.StorageObject.WCFDomain = txtDomain.Text;


                storage.StorageObject.AuthUser = txtAuthenticate_UserName.Text;
                storage.StorageObject.AuthPassword = txtAuthenticate_Password.Text;
                storage.StorageObject.AuthDomain = txtAuthenticate_Domain.Text;

                storage.Save();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
                return false;
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (SaveStorage())
                MessageBox.Show("Settings was successfully saved");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
