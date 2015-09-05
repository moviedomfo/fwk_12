using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fwk.Bases;
using Fwk.HelperFunctions;

namespace Fwk.Bases.Debug
{
    /// <summary>
    /// Formulario lanzado por <see cref="IEntityVisualizer"/> para las clases <see cref="IEntity"/>
    /// </summary>
    /// <Author>Marcelo .F. Oviedo</Author>
    public partial class IEntityVisualizerForm : Form
    {

         IEntity _IEntity;


        /// <summary>
        /// 
        /// </summary>
         public IEntity EntityToVisualize
         {
             get { return _IEntity; }
             set
             {
                 _IEntity = value;

                 FillControls();
             }
         }
       

       
        /// <summary>
        /// 
        /// </summary>
        public IEntityVisualizerForm()
        {
            InitializeComponent();
            
           
        }

        void FillControls()
        {
            txtXml.Text = _IEntity.GetXml();
            txtNamespace.Text = _IEntity.GetType().FullName;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

           
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            
           
            
            try
            {
                FileFunctions.OpenFileDialog_New(_IEntity.GetType().Name, _IEntity.GetXml(), FileFunctions.OpenFilterEnums.OpenXmlFilter, true);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(_IEntity.GetXml(), true);
        }

        private void mnuMail_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:?body=" + _IEntity.GetXml());
        }

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}