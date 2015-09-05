using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
namespace Fwk.Bases.FrontEnd.Controls
{
    /// <summary>
    /// FlatComboBox que se autocompleta
    /// y admite entradas nuevas 
    /// </summary>
    [ToolboxBitmap(@"D:\Desarrollo\Fwk\SourceCode\Fwk.FrontEnd\Fwk.Bases.FrontEnd.Controls\Resources\Control_ComboBox.bmp")]
    public class FwkAutoComboBox : FwkFlatComboBox
    {
     

        public FwkAutoComboBox()
            : base()
        {
            base.DropDownStyle = ComboBoxStyle.DropDown;
        }

       

        [BrowsableAttribute(true)]
        new public ComboBoxStyle DropDownStyle
        {
            get { return base.DropDownStyle; }
            set { base.DropDownStyle = value; }
        }

        //protected override void OnKeyDown(KeyEventArgs e)
        //{
        //    //No aplicamos el autocompletado 
        //    //si las teclas pulsadas son Suprimir o Borrar
        //     _ComboProperties.AutoComplete = ((e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back));
        //    base.OnKeyDown(e);
            
        //}


        



   

        #region --[ Properties]--

        

        /// <summary>
        /// Devuelve y setea el valor actual del combo.
        /// </summary>
        public new object SelectedValue
        {
            set { base.SelectedValue = value; }
            get
            {
                if (this.Text == "")
                {
                    return null;
                }
                else
                {
                    return base.SelectedValue;
                }
            }
        }


        #endregion


        #region --[ Publics ]--
        /// <summary>
        /// Setea el valor a mostrar en el combo y determina si se muestra o no el primer valor encontrado.
        /// </summary>
        public new string DisplayMember
        {
            set
            {
                base.DisplayMember = value;

                if (HasItems())
                {
                    this.Text = String.Empty;

                }
                else
                {
                    if (base.Required)
                    {
                        this.ReadOnly = true;
                        this.BackColor = System.Drawing.Color.FromArgb(230, 231, 253);
                    }
                    else
                    {
                        this.ReadOnly = false;
                        this.BackColor = System.Drawing.SystemColors.Window;
                    }
                }
            }
        }

        /// <summary>
        /// Obtiene el contenido de la columna valueMember del combo
        /// </summary>
        /// <returns>string</returns>
        public string SelectedValueToString()
        {
            return SelectedValueToString(ValueMember);
        }
        /// <summary>
        /// Obtiene el contenido de una columna del item seleccionado
        /// </summary>
        /// <param name="psz_Columna"></param>
        /// <returns>string</returns>
        public string SelectedValueToString(string psz_Column)
        {
            if (!(SelectedItem == null))
            {
                DataRowView wdrItem;

                wdrItem = (DataRowView)SelectedItem;
                return wdrItem.Row[psz_Column].ToString();
            }
            else
                return String.Empty;
        }

        /// <summary>
        /// Posiciona el combo  de acuerdo al texto pasado por parametros.
        /// </summary>
        /// <param name="pDisplayText"></param>
        public new  void PosicionarCombo(string pDisplayText)
        {
            int wiIndex;

            wiIndex = this.FindStringExact(pDisplayText);

            if (wiIndex > -1)
            {
                this.SelectedIndex = wiIndex;
                this.Text = pDisplayText;
            }
            else
            {
                this.Text = String.Empty;

            }
        }

        /// <summary>
        /// Posiciona el combo de acuerdo al valor pasado por parametros.
        /// </summary>
        /// <param name="pValue"></param>
        public void PosicionarCombo(object pValue)
        {
            this.SelectedValue = pValue;

        }

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AutoComboBox
            // 
            this.ActiveBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.InactiveBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.ResumeLayout(false);

        }


    }

}