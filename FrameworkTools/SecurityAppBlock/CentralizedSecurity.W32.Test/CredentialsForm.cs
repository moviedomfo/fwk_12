//===============================================================================
// Microsoft patterns & practices Enterprise Library
// Security Application Block QuickStart
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.Drawing;
using System.Collections;

using System.Windows.Forms;
using Fwk.CentralizedSecurity.Service;
using Fwk.Security.ActiveDirectory;
using CentralizedSecurity.W32.Test;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Text;
using CentralizedSecurity.W32.Test.ServiceReference1;
using System.Collections.Generic;

namespace SecurityAppBlock.Use
{
	/// <summary>
	/// Used to create new users and authenticate existing ones.
	/// </summary>
    public partial class CredentialsForm : System.Windows.Forms.Form
	{

        Fwk.Caching.FwkSimpleStorageBase<TestSettings> _Storage = new Fwk.Caching.FwkSimpleStorageBase<TestSettings>();
		public CredentialsForm()
		{
			InitializeComponent();
		}


		


	

	

        void Init()
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory());
            _Storage.Load();
            usernameTextBox.Text = _Storage.StorageObject.user;
            passwordTextBox.Text = _Storage.StorageObject.pwd;

            cmbAllDomains.Text = _Storage.StorageObject.Domain;

            List<Fwk.Security.ActiveDirectory.DomainUrlInfo> wDomainUrlInfoList = new List<Fwk.Security.ActiveDirectory.DomainUrlInfo>();
            try
            {
                var d2 = ActiveDirectoryService.GetAllDomainsUrl();

                foreach (Fwk.CentralizedSecurity.Contracts.DomainsUrl domainUrlItem in d2)
                {
                    Fwk.Security.ActiveDirectory.DomainUrlInfo item = new Fwk.Security.ActiveDirectory.DomainUrlInfo();
                    item.DomainDN = domainUrlItem.DomainDN;
                    item.DomainName = domainUrlItem.DomainName;
                    item.LDAPPath = domainUrlItem.LDAPPath;
                    item.Id = domainUrlItem.Id;
                    item.Pwd = domainUrlItem.Pwd;
                    item.Usr = domainUrlItem.Usr;
                    item.SiteName = domainUrlItem.SiteName;

                    wDomainUrlInfoList.Add(item);
                }
                string cnnString = System.Configuration.ConfigurationManager.ConnectionStrings[ActiveDirectoryService.CnnStringName].ConnectionString;
                txtCnnString.Text = cnnString;
                //List<DomainUrlInfo>
                //  var d = DirectoryServicesBase.DomainsUrl_Get_FromSp_all(ActiveDirectoryService.CnnStringName);
                cmbAllDomains.DataSource = wDomainUrlInfoList;
                cmbAllDomains.SelectedIndex = 0;



            }
            catch (Exception ex)
            {
                txtErr.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);

            }
         


        }
        private void btnAutenticate2_Click(object sender, EventArgs e)
        {
            try
            {
                string domainName = "";
                var dom = ((Fwk.Security.ActiveDirectory.DomainUrlInfo)(cmbAllDomains.SelectedItem));
                if (dom != null)
                {

                    domainName = dom.DomainName;
                }
                else
                {
                    domainName = cmbAllDomains.Text;
                }

                Fwk.CentralizedSecurity.Contracts.LoogonUserResult res = ActiveDirectoryService.User_Logon2(usernameTextBox.Text, passwordTextBox.Text, domainName);
                if(res.Autenticated)
                    txtErr.Text = LoginResult.LOGIN_OK.ToString();
                else
                txtErr.Text = res.ErrorMessage;
            }
            catch (Exception ex)
            {
                txtErr.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);

            }

        }

        private void btnAutenticate1_Click(object sender, EventArgs e)
        {
            try
            {
                string domainName = "";
                var dom = ((Fwk.Security.ActiveDirectory.DomainUrlInfo)(cmbAllDomains.SelectedItem));
                if (dom != null)
                {

                    domainName = dom.DomainName;
                }
                else
                {
                    domainName = cmbAllDomains.Text;
                }





              var res =  ActiveDirectoryService.User_Logon(usernameTextBox.Text, passwordTextBox.Text, domainName);
                if(res.LogResult!=null)
                    txtErr.Text = res.LogResult;
                else
                    txtErr.Text = res.ErrorMessage;
            }
            catch (Exception ex)
            {
                txtErr.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);

            }

        }
       

        private void btnResset_Click(object sender, EventArgs e)
        {
            try
            {
                string domainName="";
                var dom = ((Fwk.Security.ActiveDirectory.DomainUrlInfo)(cmbAllDomains.SelectedItem));
                if (dom != null)
                {
           
                    domainName = dom.DomainName;
                }
                else
                {
                    domainName = cmbAllDomains.Text;
                }
               

               


                ActiveDirectoryService.User_Reset_Password(usernameTextBox.Text, passwordTextBox.Text, domainName);
            }
            catch (Exception ex)
            {
                txtErr.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
 
            }
        }

        private void CredentialsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
          _Storage.StorageObject.user =    usernameTextBox.Text;
             _Storage.StorageObject.pwd=passwordTextBox.Text ;
             _Storage.StorageObject.Domain = cmbAllDomains.Text ;
            _Storage.Save();
        }

        private void CredentialsForm_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void cmbAllDomains_SelectedIndexChanged(object sender, EventArgs e)
        {
            string domainName = "";
            var dom = ((Fwk.Security.ActiveDirectory.DomainUrlInfo)(cmbAllDomains.SelectedItem));
            if (dom != null)
            {

                domainName = dom.DomainName;
            }
            else
            {
                domainName = cmbAllDomains.Text;
            }
               
            var domainUrlInfo = DirectoryServicesBase.DomainsUrl_Get_FromSp("ActiveDirectory", domainName);
            StringBuilder str = new StringBuilder();
            str.AppendLine("DomainName: " + domainUrlInfo.DomainName);
            str.AppendLine("Usr: " + domainUrlInfo.Usr);
            str.AppendLine("pwd: " + domainUrlInfo.Pwd);

            txtLDAPUser.Text = str.ToString();
        }

        private void btnGetUserInfo_Click(object sender, EventArgs e)
        {

            try
            {
                string domainName = "";

     
                var dom = ((Fwk.Security.ActiveDirectory.DomainUrlInfo)(cmbAllDomains.SelectedItem));
                if (dom != null)
                {

                    domainName = dom.DomainName;
                }
                else
                {
                    domainName = cmbAllDomains.Text;
                }





                var res = ActiveDirectoryService.User_Info(usernameTextBox.Text, domainName);
                //if (res.LogResult != null)
                //    txtErr.Text = res.LogResult;
                //else
                //    txtErr.Text = res.ErrorMessage;
            }
            catch (Exception ex)
            {
                txtErr.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);

            }

        }

        
	}
}
