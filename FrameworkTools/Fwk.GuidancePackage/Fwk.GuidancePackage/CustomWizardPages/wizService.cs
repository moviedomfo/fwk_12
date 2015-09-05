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
using Fwk.DataBase;
using Microsoft.Practices.WizardFramework;
using System.ComponentModel.Design;
using Microsoft.Practices.RecipeFramework.Services;
using Microsoft.Practices.RecipeFramework.Library;
using Microsoft.Practices.RecipeFramework.VisualStudio;
using EnvDTE;

namespace Fwk.GuidPk
{

    public partial class wizService : CustomWizardPage
    {


        [RecipeArgument]
        public string ServiceName
        {
            set
            {
                if (value != null)
                   txtServiceName.Text = value;
                else
                    txtServiceName.Text = string.Empty;

            }
        }
        
       

        public wizService()
        {
            InitializeComponent();
        }

        public wizService(WizardForm parent)
            : base(parent)
        {
            InitializeComponent();

    
        }

   

       

       
        public void setIDictionaryService()
        {
            IDictionaryService dictionaryService = GetService(typeof(IDictionaryService)) as IDictionaryService;

            if (string.IsNullOrEmpty(txtServiceName.Text))
            {
                dictionaryService.SetValue("ServiceName", null);
                
                
            }
            else
            {
                dictionaryService.SetValue("ServiceName", txtServiceName.Text);
            }


        }
        

      

   
    
      
       


        public bool Test()
        {
           
            try
            {

                EnvDTE.DTE dte = (EnvDTE.DTE)GetService(typeof(EnvDTE.DTE));
                IAssetReferenceService referenceService = (IAssetReferenceService)GetService(typeof(IAssetReferenceService));
                object item = DteHelper.GetTarget(dte);
                //MessageBox.Show("Coneccion exitosa.- a " + _Server.Information.Product.ToString(),  Fwk.GuidPk.Properties.Resources.ProductTitle);


                //templateFilename = new Uri(templateFilename).LocalPath;
                StringBuilder items= new StringBuilder ();
                //VsBoundReference vsTarget = null;
                if (item is Project)
                {
                    foreach (ProjectItem i in ((Project)item).ProjectItems)
                    {
                        items.AppendLine(i.Name);
                    }
                    //vsTarget = new ProjectReference(templateFilename, (Project)item);
                }

                MessageBox.Show(items.ToString(), Fwk.GuidPk.Properties.Resources.ProductTitle);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Fwk.CodeGenerator.HelperFunctions.GetAllMessageException(ex), Fwk.GuidPk.Properties.Resources.ProductTitle);
                return false;
            }
            return true;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            Test();
        }

        private void txtServiceName_TextChanged(object sender, EventArgs e)
        {
            setIDictionaryService();

            txtBE.Text = string.Concat(txtServiceName.Text, @"Service.cs");
            txtReq.Text = string.Concat(txtServiceName.Text, @"Req.cs");
            txtRes.Text = string.Concat(txtServiceName.Text, @"Res.cs");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
     
        }

        private void wizService_Load(object sender, EventArgs e)
        {
           // IAssetReferenceService referenceService = (IAssetReferenceService)GetService(typeof(IAssetReferenceService));

            IDictionaryService dictionaryService = GetService(typeof(IDictionaryService)) as IDictionaryService;
            //Project prj = (Project)dictionaryService.GetValue("selctedproject");
            string nms = dictionaryService.GetValue("TargetNamespace").ToString();
            nms = nms.Replace(".Backend", String.Empty);
            nms = nms.Replace(".Contract", String.Empty);
            nms = nms.Replace(".backend", String.Empty);
            nms = nms.Replace(".common", String.Empty);

            dictionaryService.SetValue("RootNamespace", nms);
        }

      





       

    }
}
