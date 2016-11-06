using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.ActiveDirectory;
using System.Collections.Specialized;
using System.DirectoryServices.ActiveDirectory;
namespace Fwk.Security.ActiveDirectory.Test
{
    public partial class frmTestLDAPconnections : Form
    {
        ADWrapper adADWrapper;
        public frmTestLDAPconnections()
        {
            InitializeComponent();
            StringBuilder str = new StringBuilder();
            str.Append("Prueba de AD Helper como instancia.-");
            str.Append("Es ncesario ingresar los datos debajo para crear un objeto autenticado de AD Helper");
            label2.Text = str.ToString();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            lblResult.Text = string.Empty;
            try
            {
                adADWrapper = new ADWrapper(txtPath.Text, txtLoginName.Text, txtPassword.Text);
                lstDomains.DataSource = adADWrapper.Domain_GetList1();

               
                label4.Text = adADWrapper.LDAPPath;
            }
            catch (Exception ex)
            {
                lblResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lblResult.Text =  string.Empty;
            try
            {
                //ImpersonateLogin wImpersonation = new ImpersonateLogin();
                //wImpersonation.domain = txtDomainName.Text;
                //wImpersonation.user= txtLoginName.Text;
                //wImpersonation.password= txtPassword.Text;
                adADWrapper = new ADWrapper(txtPath2.Text, txtLoginName.Text, txtPassword.Text);
                //adADWrapper.LDAPDomainName = txtDomainName.Text;
                lstDomains.DataSource = adADWrapper.Domain_GetList1();
                label4.Text = adADWrapper.LDAPPath;
            }
            catch (Exception ex)
            {
                lblResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lblResult.Text = string.Empty;
            try
            {
                adADWrapper = new ADWrapper(txtPath3.Text, txtLoginName.Text, txtPassword.Text);
                lstDomains.DataSource = adADWrapper.Domain_GetList1();
                label4.Text = adADWrapper.LDAPPath;
            }
            catch (Exception ex)
            {
                lblResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
        }

       

        private void button5_Click(object sender, EventArgs e)
        {
            lblResult.Text = string.Empty;
            //try
            //{
            //    _ADHelper = new ADHelper(txtDomain.Text);
            //    lstDomains.DataSource = _ADHelper.Domain_GetList1();
            //    label4.Text = _ADHelper.LDAPPath;
            //}
            //catch (Exception ex)
            //{
            //    lblResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
         FwkGlobalCatalog wFwkGlobalCatalog = new FwkGlobalCatalog ();
         List<FwkGlobalCatalog> list = new List<FwkGlobalCatalog>();
         GlobalCatalogCollection cataloglist = null;

         try
         {
              cataloglist = adADWrapper.GlobalCatalogs(txtDomainC.Text);
         }
         catch (Exception ex)
         {
             lblResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
             return;
         }
         foreach (GlobalCatalog gc in cataloglist)
         { 
             wFwkGlobalCatalog = new FwkGlobalCatalog ();
             wFwkGlobalCatalog.IPAddress = gc.IPAddress;
             wFwkGlobalCatalog.Name = gc.Name;
             wFwkGlobalCatalog.DomainName = gc.Domain.Name;
             
             list.Add(wFwkGlobalCatalog);
         }
         
         dataGridView1.DataSource = list;
         dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnUser_Get_ByName_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();
            ADUser user = adADWrapper.User_Get_ByName(txtUserName.Text);
            if (user!=null)
            {
                str.AppendLine(user.LoginName);
                str.AppendLine("UserAccountControl: " + user.UserAccountControl);
                str.AppendLine("FullName: " + user.FirstName + " " + user.LastName);
                str.AppendLine("LoginResult: " + user.LoginResult);
                lblResult.Text = str.ToString(); 
            }
            else
                lblResult.Text = "No se encuentra el usuario " + txtUserName.Text + " en " + adADWrapper.LDAPDomainName;

            adADWrapper.Person_Get(txtUserName.Text);
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          string s1 =  adADWrapper.GetRootProperty(ADProperties.DESCRIPTION);
          string s2 = adADWrapper.GetRootProperty(ADProperties.DISPLAYNAME);
           s2 = adADWrapper.GetRootProperty(ADProperties.DISTINGUISHEDNAME);
           s2 = adADWrapper.GetRootProperty(ADProperties.DISPLAYNAME);

        }
    }

    public class FwkGlobalCatalog
    {
        string _IPAddress;

        public string IPAddress
        {
            get { return _IPAddress; }
            set { _IPAddress = value; }
        }
        string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        string _DomainName;

        public string DomainName
        {
            get { return _DomainName; }
            set { _DomainName = value; }
        }
       
    }
}
