using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;





namespace Fwk.CodeGenerator
{
    public partial class Main : Form
    {
        private WorkSpace _WorkSpace = new WorkSpace();
        private TemplateSettingObject _TemplateSettingObject  = null;
        private frm_DACGenerator ofrmDACGenerator = null;
        //frm_DataEntityGenerator ofrmDataEntityGenerator = null;
        //frm_ServicesGenerator ofrmServicesGenerator = null;
        private LastAccessStorage _LastAccessStorage = null;

        public Main()
        {
            InitializeComponent();
            //En el constructor mismo se inicializa el Storage
            _LastAccessStorage = new LastAccessStorage();
            InitTemplateSettingObject();
            this.Text = string.Concat(this.Text, " v.", Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }

        private void toolStripMenuItemDAC_Click(object sender, EventArgs e)
        {
            ShowBackEndForm();
        }

       

        private void toolStripMenuItemEntity_Click(object sender, EventArgs e)
        {
            //ShowEntityForm();
        }

       

        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ShowServiceForm();
        }

       

        private void textToStringBuilderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"ExternalTools\TextToStringBuilder\TextToStringBuilder.exe");
        }

        private void ConfigurationLibrariesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"ExternalTools\ConfigurationApp\ConfigurationApp.exe");
        }


        /// <summary>
        /// Abre el formulario para personalizar los templates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customizeTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTemplateSetting _FrmTemplateSetting = new FrmTemplateSetting();

            _FrmTemplateSetting.PropertyChange += new PropertyChangeHandler(_FrmTemplateSetting_PropertyChange);

            if (!String.IsNullOrEmpty(_LastAccessStorage.LastAccess.LastTemplateSettingFileName))
                _FrmTemplateSetting.FullFileName = _LastAccessStorage.LastAccess.LastTemplateSettingFileName;

            _TemplateSettingObject = _FrmTemplateSetting.TemplateSettingObject.Clone();


            _FrmTemplateSetting.Show(dockPanel1, Fwk.Controls.Win32.DockState.Document);
        }

        /// <summary>
        /// Carga TemplateSettingObject sin mostrar el formulario FrmTemplateSetting
        /// Esto se hace al iniciar la aplicacion para cargar el ultimo setteing del usuario.
        /// </summary>
        void InitTemplateSettingObject()
        {
            FrmTemplateSetting _FrmTemplateSetting = new FrmTemplateSetting();


            if (!String.IsNullOrEmpty(_LastAccessStorage.LastAccess.LastTemplateSettingFileName))
            {
                _FrmTemplateSetting.FullFileName = _LastAccessStorage.LastAccess.LastTemplateSettingFileName;
                _FrmTemplateSetting.Refresh();
            }

            _TemplateSettingObject = _FrmTemplateSetting.TemplateSettingObject.Clone();
            _FrmTemplateSetting.Close();
            _FrmTemplateSetting.Dispose();
        }


        /// <summary>
        /// Ocurre cuando una propiedad del template cambia pero ademas el usuario preciono almacenar los cambios.-
        /// </summary>
        /// <param name="pTemplateSettingObjec"></param>
        void _FrmTemplateSetting_PropertyChange(TemplateSettingObject pTemplateSettingObjec)
        {
            _TemplateSettingObject = pTemplateSettingObjec.Clone();
            _LastAccessStorage.LastAccess.LastTemplateSettingFileName = _TemplateSettingObject.FullFileName;

            if (ofrmDACGenerator != null)
                ofrmDACGenerator.TemplateSettingObject = _TemplateSettingObject;
            //if (ofrmDataEntityGenerator != null)
            //    ofrmDataEntityGenerator.TemplateSettingObject = _TemplateSettingObject;
            //if (ofrmServicesGenerator != null)
            //    ofrmServicesGenerator.TemplateSettingObject = _TemplateSettingObject;

            _LastAccessStorage.Save();
            
        }

       


        void ShowFrm(FrmBase pFrmBase)
        {


            pFrmBase.Show(dockPanel1, Fwk.Controls.Win32.DockState.Document);
        }

        private void backEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowBackEndForm();
        }

        private void entitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ShowEntityForm();
        }

        private void servicesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //ShowServiceForm();
        }

        private void ShowBackEndForm()
        {
            if(_WorkSpace.Contains(CodeGeneratorCommon.GeneratorsType.BackEnd)) return;
            
            

            try
            {
                ofrmDACGenerator = new frm_DACGenerator();
                ofrmDACGenerator.Closing += new CancelEventHandler(ofrmDACGenerator_Closing);
                ofrmDACGenerator.LastAccessStorage = _LastAccessStorage;
                ofrmDACGenerator.TemplateSettingObject = _TemplateSettingObject;

                ofrmDACGenerator.MdiParent = this;
                _WorkSpace.Add(ofrmDACGenerator, CodeGeneratorCommon.GeneratorsType.BackEnd);
                
                ShowFrm(ofrmDACGenerator);
            }
            catch (Exception ex)
            {
                MessageView ofrmMessageView = new MessageView();
                ofrmMessageView.MdiParent = this;
                ofrmMessageView.Message = ex.Message;
                ofrmMessageView.Show();
            }
        }

        void ofrmDACGenerator_Closing(object sender, CancelEventArgs e)
        {
            _WorkSpace.Remove(CodeGeneratorCommon.GeneratorsType.BackEnd);
        }

        //private void ShowEntityForm()
        //{
        //    if (_WorkSpace.Contains(GeneratorsType.Entities)) return;

        //     ofrmDataEntityGenerator = new frm_DataEntityGenerator();
        //    ofrmDataEntityGenerator.Closing += new CancelEventHandler(ofrmDataEntityGenerator_Closing);
        //    ofrmDataEntityGenerator.LastAccessStorage = _LastAccessStorage;
        //    ofrmDataEntityGenerator.TemplateSettingObject = _TemplateSettingObject;

        //    ofrmDataEntityGenerator.MdiParent = this;
        //    _WorkSpace.Add(ofrmDataEntityGenerator, GeneratorsType.Entities);
        //    ShowFrm(ofrmDataEntityGenerator);
        //}

        void ofrmDataEntityGenerator_Closing(object sender, CancelEventArgs e)
        {
            _WorkSpace.Remove(CodeGeneratorCommon.GeneratorsType.Entities);
        }
        //private void ShowServiceForm()
        //{
        //    //if (_WorkSpace.Contains(GeneratorsType.Services)) return;
        //    // ofrmServicesGenerator = new frm_ServicesGenerator();
        //    //ofrmServicesGenerator.Closing += new CancelEventHandler(ofrmServicesGenerator_Closing);
        //    //ofrmServicesGenerator.LastAccessStorage = _LastAccessStorage;
        //    //ofrmServicesGenerator.TemplateSettingObject = _TemplateSettingObject;
        //    //ofrmServicesGenerator.MdiParent = this;
        //    //_WorkSpace.Add(ofrmServicesGenerator,GeneratorsType.Services);
        //    //ShowFrm(ofrmServicesGenerator);
        //}

        //void ofrmServicesGenerator_Closing(object sender, CancelEventArgs e)
        //{
        //    _WorkSpace.Remove(GeneratorsType.Services);
        //}
    }
}