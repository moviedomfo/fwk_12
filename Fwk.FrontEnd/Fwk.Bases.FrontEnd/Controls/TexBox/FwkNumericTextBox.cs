using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Fwk.HelperFunctions;

namespace Fwk.Bases.FrontEnd.Controls
{
    public partial class FwkNumericTextBox : UserControl
        
    {
        object mo_Value = null;
        public static Double MaxAsoluteMoney = Math.Pow(2, 63);
        public object Value
        {
            get { return mo_Value; }
        }

        private NumericTypeEnum _NumericType = NumericTypeEnum.Int;
        public NumericTypeEnum NumericType
        {
            get
            {
                return _NumericType;
            }
            set { _NumericType = value; }
        }
        public HorizontalAlignment TextBoxTextAlign
        {
            get { return txtTextBox.TextAlign; }
            set { txtTextBox.TextAlign = value; }
        }
        public Font TextBoxFont
        {
            get { return txtTextBox.Font; }
            set { txtTextBox.Font = value; }
        }
        public Color TextBoxForeColor
        {
            get { return txtTextBox.ForeColor; }
            set { txtTextBox.ForeColor = value; }
        }
        public BorderStyle TextBoxBorderStyle
        {
            get { return txtTextBox.BorderStyle; }
            set { txtTextBox.BorderStyle = value; }
        }
        public bool TextBoxEnabled
        {
            get { return txtTextBox.Enabled; }
            set { txtTextBox.Enabled = value; }
        }
        public string TextBoxText
        {
            get
            {
                return txtTextBox.Text;
            }
            set
            {
                txtTextBox.Text = value;
                ValidateValue();
            }
        }

        public enum NumericTypeEnum
        {
            Int = 0,
            Decimal = 1,
            Double = 2,
            Money = 3

        }

        public FwkNumericTextBox()
        {
            InitializeComponent();
            txtTextBox.Text = "0";
        }

        private void txtTextBox_Validating(object sender, CancelEventArgs e)
        {

            

            e.Cancel = !ValidateValue();


        }
        bool ValidateValue()
        {
            if (_NumericType == NumericTypeEnum.Money)
            {
                Decimal wVal = 0;
                if (!Decimal.TryParse(txtTextBox.Text, out wVal))
                {
                    errorProvider1.SetError(txtTextBox, "Ingrece valores numéricos validos");
                    return false;

                }

                //if ((double)wVal > Math.Pow(2, 63) || (double)wVal < -Math.Pow(2, 63))
                if ((double)wVal > MaxAsoluteMoney || (double)wVal < -MaxAsoluteMoney)
                {
                    errorProvider1.SetError(txtTextBox, "Monto demaciado grande");
                    return false;
                }

                mo_Value = wVal;
            }
            if (_NumericType == NumericTypeEnum.Int)
            {
                int wVal = 0;
                if (!Int32.TryParse(txtTextBox.Text, out wVal))
                {
                    errorProvider1.SetError(txtTextBox, "Ingrece valores enteros");
                    return false;
                    
                }
                mo_Value = wVal;
            }
            if (_NumericType == NumericTypeEnum.Decimal)
            {
                Decimal wVal = 0;
                if (!Decimal.TryParse(txtTextBox.Text, out wVal))
                {
                    errorProvider1.SetError(txtTextBox, "Ingrece valores decimales");
                    return false;
                }
                mo_Value = wVal;
            }
            if (_NumericType == NumericTypeEnum.Double)
            {
                Double wVal = 0;
                if (!Double.TryParse(txtTextBox.Text, out wVal))
                {
                    errorProvider1.SetError(txtTextBox, "Ingrece valores decimales");
                    
                    return false;
                }
                mo_Value = wVal;
            }
           
            errorProvider1.Clear();
            return true;
        }
        private void txtTextBox_MouseEnter(object sender, EventArgs e)
        {
            txtTextBox.SelectAll();
        }

        private void txtTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == EnvironmentFunctions.Dot || e.KeyChar == EnvironmentFunctions.Coma)
            {
                e.Handled = !EnvironmentFunctions.IsValidDecimalSeparator(e.KeyChar.ToString());
                return;
            }
        }
    }
}
