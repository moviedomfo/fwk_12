using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Bases.Test
{
    public partial class frmUndoRedoEntitiesTest : Form
    {
        ClienteCollectionBE _ClienteCollectionBE = null;
        ClienteCollectionBE_2 _ClienteCollectionBE_2 = null;
        public frmUndoRedoEntitiesTest()
        {
            InitializeComponent();
        

            intObjects();
            initLabels();

        }

        private void intObjects()
        {
            #region crear objetos
            _ClienteCollectionBE = new ClienteCollectionBE();
            ClienteBE wCli = new ClienteBE();
            
            wCli.Nombre = "Marcelo";
            wCli.Apellido = "Oviedo";
            wCli.Edad = 32;
            wCli.FechaNacimiento = Convert.ToDateTime("1974-10-18T00:00:00");

            wCli.Direccion.Altura = 9000;
            wCli.Direccion.Calle = "Ilia y chacabuco";
            #endregion
            _ClienteCollectionBE.Add(wCli);
            bindingSource1.DataSource = _ClienteCollectionBE[0];

            bindingSource1.CurrentChanged += new EventHandler(bindingSource1_CurrentChanged);
            bindingSource1.CurrentItemChanged += new EventHandler(bindingSource1_CurrentItemChanged);


            #region crear objetos
            _ClienteCollectionBE_2 = new ClienteCollectionBE_2();
            ClienteBE_2 wCli_2 = new ClienteBE_2();

            wCli_2.Nombre = "Marcelo";
            wCli_2.Apellido = "Oviedo";
            wCli_2.Edad = 32;
            wCli_2.FechaNacimiento = Convert.ToDateTime("1974-10-18T00:00:00");
            #endregion
            _ClienteCollectionBE.Add(wCli);

            _ClienteCollectionBE[0].SetHistory();
        }


        #region Multiple o de clace completa 
        void bindingSource1_CurrentItemChanged(object sender, EventArgs e)
        {
          
        }

        void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

       
       

        private void btnUndo_Click(object sender, EventArgs e)
        {
            _ClienteCollectionBE[0].Undo();
            SetValues();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            _ClienteCollectionBE[0].Redo();
            SetValues();
        }

        /// <summary>
        /// Mapea el objeto al text box
        /// </summary>
        private void SetValues()
        {
            textBox1.Text = _ClienteCollectionBE[0].Nombre;
            textBox2.Text = _ClienteCollectionBE[0].Apellido;
            if (_ClienteCollectionBE[0].Edad != null)
                textBox3.Text = _ClienteCollectionBE[0].Edad.Value.ToString();
            else
                textBox3.Text = null;
            //bindingSource1.DataSource = _ClienteCollectionBE[0];
            btnUndo.Enabled = _ClienteCollectionBE[0].CanUndo();
            btnRedo.Enabled = _ClienteCollectionBE[0].CanRedo();

        }

        #endregion

        void initLabels()
        { 
        
         System.Text.StringBuilder sb = new System.Text.StringBuilder(5000);
         sb.Append(@"[FwkHistoryAttribute(""FechaNacimiento"")]");
         sb.Append(Environment.NewLine);
         sb.Append(@"public DateTime? FechaNacimiento");
         sb.Append(Environment.NewLine);
         sb.Append(@" {");
         sb.Append(Environment.NewLine);
         sb.Append(@" get { return _FechaNacimiento; }");
         sb.Append(Environment.NewLine);
         sb.Append(@" set { _FechaNacimiento = value;}");
         sb.Append(Environment.NewLine);
         sb.Append(@"}");



         label14.Text = sb.ToString();


            sb = new System.Text.StringBuilder(5000);
         sb.Append(@"public string Nombre");
         sb.Append(Environment.NewLine);
         sb.Append(@" {");
         sb.Append(Environment.NewLine);
         sb.Append(@" get { return _Nombre; }");
         sb.Append(Environment.NewLine);
         sb.Append(@" set {");
         sb.Append(Environment.NewLine);
  

         sb.Append(@"       base.AddHistory(""Nombre"", value);");
         sb.Append(Environment.NewLine);
         sb.Append(@"       _Nombre = value;");
         sb.Append(Environment.NewLine);
         sb.Append(@"  }");
         sb.Append(Environment.NewLine);
         sb.Append(@"        }");
         label7.Text = sb.ToString();
        
        }

        private void btnSetHistory_Click(object sender, EventArgs e)
        {
            _ClienteCollectionBE[0].SetHistory();
            btnUndo.Enabled = _ClienteCollectionBE[0].CanUndo();
            btnRedo.Enabled = _ClienteCollectionBE[0].CanRedo();
        }
    }
}
