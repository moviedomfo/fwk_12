using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Globalization;

namespace ParamsManager
{
    public partial class frmParamInfo : DevExpress.XtraEditors.XtraForm
    {
        
        fwk_Param _Parent;
      
        public frmParamInfo()
        {
            InitializeComponent();
        }
        public frmParamInfo(fwk_Param parent, fwk_Param param)
        {
            _Parent= parent;
            InitializeComponent();
            if (_Parent != null)
            {
                lblPArentName.Text = parent.Name;
                lblParentId.Text = parent.ParamId.ToString();
            }
            else
            {
                lblPArentName.Text = "NA";
                lblParentId.Text = "NA";
            }
            txtDescription.Text = param.Description;
            txtName.Text = param.Name;
            txtParamId.Text = param.ParamId.ToString();
            comboBoxEdit1.Text = param.Culture;

            FillCulture();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
           
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }


        void FillCulture()
        {
            List<string> list = new List<string>();
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                string specName = "(none)";
                try {
                    specName = CultureInfo.CreateSpecificCulture(ci.Name).Name;
                    
                }
                    
                catch { 
                
                }
                //list.Add(String.Format("{0,-12}{1,-12}{2}", ci.Name, specName, ci.EnglishName));
                list.Add(String.Format("{0,-12},{1}",  specName, ci.EnglishName));
             
            }
            comboBoxEdit1.Properties.Items.AddRange(list.ToArray());

        }
    }
}