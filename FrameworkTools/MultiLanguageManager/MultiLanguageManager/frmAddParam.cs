using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MultiLanguageManager
{
    public partial class frmAddParam : DevExpress.XtraEditors.XtraForm
    {
        ParamCampaing  _Param;
        public ParamCampaing Param
        {
            get { return _Param; }
        }
       
        public frmAddParam()
        {
            InitializeComponent();
        }
        public frmAddParam(string related)
        {

            InitializeComponent();
            lblGroup.Text = related;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (String.IsNullOrEmpty(txtKey.Text))
            {
                errorProvider1.SetError(txtKey, "Ingrese el nobre de la clave");
                return;
            }
            int res =0;
            Int32.TryParse(txtCode.Text.Trim(), out res);
            if (res == 0)
            {
                errorProvider1.SetError(txtCode, "Ingrese solo valores numericos para el codigo EJ: 1000, 2001, 89, etc ");
                return;
            }
            _Param = new ParamCampaing();
            _Param.ParamCapaingId = res;
            _Param.Name = txtKey.Text;
            _Param.Remarks = txtRemark.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}