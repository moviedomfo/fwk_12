using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.CodeGenerator;

namespace Fwk.Wizard
{
    public partial class ctrlNewService : wizBase
    {
        

        public string ServiceName
        {
            get { return txtServiceName.Text; }
            set
            {
                string cs;
                if (value.Length > 3)
                {
                    cs = value.Substring(value.Length - 3);
                    if (cs.Equals(".cs"))
                        value = value.Substring(0, value.Length - 3);
                }
                txtServiceName.Text = value;
            }
           
        }
        string svcCode;

        public string SvcCode
        {
            get { return svcCode; }
            set { svcCode = value; }
        }
        string isvcCode;

        public string IsvcCode
        {
            get { return isvcCode; }
            set { isvcCode = value; }
        }

        public string Req
        {
            get { return txtReq.Text; }
           
        }
        public string Res
        {
            get { return txtRes.Text; }

        }
        public string Svc
        {
            get { return txtBE.Text; }
        }
        string _ProjectName;
        public string ProjectName
        {
            get { return _ProjectName; }
            set { _ProjectName = value; }
        }

        string _ProjectSvcName;
        public string ProjectSvcName
        {
            get { return _ProjectSvcName; }
            set { _ProjectSvcName = value; }
        }
        string _ProjectISvcName;
        public string ProjectISvcName
        {
            get { return _ProjectISvcName; }
            set { _ProjectISvcName = value; }
        }
        public ctrlNewService()
        {
            InitializeComponent();
        }

        

        private void txtServiceName_TextChanged(object sender, EventArgs e)
        {
            txtBE.Text = string.Concat(txtServiceName.Text, @"Service.cs");
            txtReq.Text = string.Concat(txtServiceName.Text, @"Req.cs");
            txtRes.Text = string.Concat(txtServiceName.Text, @"Res.cs");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtServiceName.Text))
            {
                MessageBox.Show("Ingrece el nombre del servicio.-");
                return;
            }

            try
            {
                isvcCode = GenSVC.Generate_ISVC(txtServiceName.Text.Trim(), _ProjectName);
                svcCode = GenSVC.Generate_SVC(txtServiceName.Text.Trim(), _ProjectName);


                base.DoEvent(null, WizardButton.Ok);
            }
            catch (Exception ex)
            { 
                MessageBox.Show(HelperFunctions.GetAllMessageException(ex));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DoEvent(null, WizardButton.Cancel);
        }

       
    }
}
