using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using Fwk.Bases.FrontEnd.Controls.FwkCombo.Design;


namespace Fwk.Bases.FrontEnd.Controls
{
    public delegate void BorderChangeHandler(object sender, FlatBoxEventArgs e);
    partial class  FwkFlatComboBox
    {
        private ErrorProvider errorProvider1;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // FwkFlatComboBox
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.FormattingEnabled = true;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FwkFlatComboBox_KeyPress);
            this.Validating += new CancelEventHandler(FwkFlatComboBox_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT)
            {
                //Definimos el rectángulo que abarca 
                //la caja de texto y el botón
                Graphics g = this.CreateGraphics();
                Rectangle wCliente = this.ClientRectangle;

                //Establecemos los colores
                if (_IAmOn)
                {
                    _BorderColor = _ActiveBorderColor;
                    _ArrowColor = _ActiveArrowColor;
                    _ButtonColor = _ActiveButtonColor;
                }
                else
                {
                    _BorderColor = _InactiveBorderColor;
                    _ArrowColor = _InactiveArrowColor;
                    _ButtonColor = _InactiveButtonColor;
                }

                //Pintamos el control entero de blanco para eliminar todo rastro de tres dimensiones
                g.FillRectangle(new SolidBrush(SystemColors.Window), wCliente);

                //Dibujamos el borde de todo el control
                g.DrawRectangle(new Pen(_BorderColor), 0, 0, wCliente.Width, wCliente.Height - 1);

                //Definimos la localización y el tamaño del botón
                Point wPunto = new Point(wCliente.Width - 18, 0);
                Size wArea = new Size(wCliente.Width - wPunto.X, wCliente.Height - wPunto.Y);

                Rectangle Boton = new Rectangle(wPunto, wArea);

                //y lo pintamos
                g.FillRectangle(new SolidBrush(_ButtonColor), Boton);

                //Movemos el eje de coordenadas a la esquina del botón
                //para dibujar más cómodamente
                g.TranslateTransform(Boton.X, Boton.Y);

                //Dibujamos el borde del botón
                g.DrawRectangle(new Pen(_BorderColor), 0, 0, Boton.Width - 1, Boton.Height - 1);

                //Definimos un GraphicsPath que contendrá el dibujo de la flecha
                GraphicsPath wFlecha = new GraphicsPath();

                PointF NO = new PointF(Boton.Width / 4, 9 * Boton.Height / 24);
                PointF NE = new PointF(3 * Boton.Width / 4, NO.Y);
                PointF SU = new PointF(Boton.Width / 2, 15 * Boton.Height / 24);

                wFlecha.AddLine(NO, NE);
                wFlecha.AddLine(NE, SU);

                //suavizamos los bordes en lo posible
                g.SmoothingMode = SmoothingMode.AntiAlias;

                //y dibujamos la flecha
                g.FillPath(new SolidBrush(_ArrowColor), wFlecha);

                g.Dispose();


                if (BorderChange != null)
                {
                    BorderChange(this, new FlatBoxEventArgs(_BorderColor, _IAmOn));
                }


            }
        }

        void ComboPropertiesSet()
        {
            if (_ReadOnly)
            {
                this.BackColor = _ReadOnlyColor;

            }
            else
            {

                this.BackColor = _BackColor;

            }

            base.Enabled = !_ReadOnly;
        }

        private bool ValidateValue()
        {
            errorProvider1.RightToLeft = _ErrorIconRightToLeft;
            if (_Required)
            {
                if (String.IsNullOrEmpty(this.Text))
                {
                    errorProvider1.SetError(this, _RequiredErrorText);
                    return false;

                }
            }
          
            errorProvider1.Clear();
            return true;
        }

        void FwkFlatComboBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateValue();
        }

        private void FwkFlatComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_ReadOnly)
            {
                e.Handled = true;
            }
            else
            {
                if (_AutoComplete && _KeysEnabledToAutoComplete)
                {
                    e.Handled = true;

                    //Añadimos al texto del control el carácter nuevo
                    string Texto = this.Text.Substring(0, this.Text.Length - this.SelectedText.Length) + e.KeyChar;

                    //Lo buscamos en la lista y si lo encontramos 
                    //permitimos que se una al texto

                    if (this.FindString(Texto) >= 0)
                    {
                        e.Handled = false;
                    }
                    else
                    {

                        //base.OnKeyPress(e);
                    }
                }
            }
        }
    }
}
