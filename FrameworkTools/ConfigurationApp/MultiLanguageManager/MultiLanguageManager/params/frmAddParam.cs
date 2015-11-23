using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Globalization;

namespace MultiLanguageManager
{
    public partial class frmAddParam : DevExpress.XtraEditors.XtraForm
    {
        fwk_Param   _Param;
        fwk_Param _Parent;
        public fwk_Param Param
        {
            get { return _Param; }
        }
       
        public frmAddParam()
        {
            InitializeComponent();
        }
        public frmAddParam(fwk_Param parent)
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
                lblPArentName.Text = "";
                lblParentId.Text = "Parametro sin  padre";
            }
            FillCulture();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (String.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.SetError(txtName, "Ingrese el nobre de la clave");
                return;
            }
            int res =0;
            Int32.TryParse(txtParamId.Text.Trim(), out res);
            if (res == 0)
            {
                errorProvider1.SetError(txtParamId, "Ingrese solo valores numericos para el codigo EJ: 1000, 2001, 89, etc ");
                return;
            }
            _Param = new fwk_Param();
            _Param.ParamId = res;
            if (_Parent != null)
            {
                _Param.ParentId = _Parent.ParamId;
            }
            _Param.Name = txtName.Text;
            _Param.Description = txtDescription.Text;
            String culture = comboBoxEdit1.Text.Trim().Split(',')[0];
            if (String.IsNullOrEmpty(culture))
                culture = "es-AR";
            _Param.Culture = culture.Trim();
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