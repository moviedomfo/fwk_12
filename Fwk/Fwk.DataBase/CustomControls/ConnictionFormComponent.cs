using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.DataBase.CustomControls
{
    public partial class ConnictionFormComponent : Component
    {
        ConnectionForm _ConnectionForm;
        [CategoryAttribute("Factory Tools"), Description("Configura la apariencia del conector")]
        public CnnDataBaseForm ConnectionAparience
        {
            get { return _ConnectionForm.cnnDataBaseForm1; }
            set { _ConnectionForm.cnnDataBaseForm1 = value; }
        }

        public Boolean ConnectionOK
        {
            get { return this._ConnectionForm.ConnectionOK; }

        }
        public Boolean CnnStringChange
        {
            get { return this._ConnectionForm.CnnStringChange; }

        }

        public CnnString CnnString
        {
            get { return this._ConnectionForm.CnnString; }
        }
        public ConnictionFormComponent()
        {
            InitializeComponent(); 
            _ConnectionForm = new ConnectionForm();
        }

        public ConnictionFormComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            _ConnectionForm = new ConnectionForm();
        }

     


        /// <summary>
        /// Muestra el mensaje
        /// </summary>
        /// <param name="pMessage">Mensaje a mostrar</param>
        /// <returns>DialogResult</returns>
        public DialogResult Show()
        {
             _ConnectionForm.ShowDialog();
             if (_ConnectionForm.ConnectionOK)
                 return DialogResult.OK;
             else
                 return DialogResult.Cancel;
        }

    }
}
