using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Cache.Test
{
    public partial class frmAddItem : Form
    {
        ClienteCollectionBE _ClienteCollectionBE = null;
        string _Id;

        public string Id
        {
            get { return _Id; }
          
        }
        public ClienteCollectionBE ClienteCollectionBE
        {
            get { return _ClienteCollectionBE; }
            
        }

        public frmAddItem()
        {
            InitializeComponent();
            _ClienteCollectionBE = Helper.GetClienteCollection();
            primitivesResultsTextBox.Text = _ClienteCollectionBE.GetXml();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool Load()
        {
            try
            {
                frmSelectItem  selectItemForm = new frmSelectItem();
                if (selectItemForm.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(selectItemForm.ItemKey))
                    {
                        MessageBox.Show("Debe ingresar un identificador para el item");
                        return false;
                    }
                    _Id = selectItemForm.ItemKey;
                    _ClienteCollectionBE = ClienteCollectionBE.GetClienteCollectionBE(primitivesResultsTextBox.Text);
                    return true;
                }
                else
                {
                    
                    return false;
                }
                
            }
            catch
            {
                MessageBox.Show("El xml no permite la serializacion del onjeto ClienteCollectionBE..sera regenerado");
                _ClienteCollectionBE = Helper.GetClienteCollection();
                primitivesResultsTextBox.Text = _ClienteCollectionBE.GetXml();
                return false;
            }
        
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (Load())
            {
                this.DialogResult = DialogResult.OK;

                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
