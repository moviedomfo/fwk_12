using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Fwk.Controls.Win32;


namespace Fwk.CodeGenerator
{

    public delegate void PropertyChangeHandler(TemplateSettingObject pTemplateSettingObjec);
    public partial class TemplateSettingControl : UserControl
    {
        #region <-- Events -->
        public event PropertyChangeHandler PropertyChange = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        private void OnPropertyChangeEvent()
        {
            if (PropertyChange != null)
                PropertyChange(_TemplateSettingObject);
        }

        #endregion

        private TemplateSettingObject _TemplateSettingObject = null;

        public TemplateSettingObject TemplateSettingObject
        {
            get { return _TemplateSettingObject; }
            set { _TemplateSettingObject = value; }
        }
        private String _TemplateSettingObjectFullFileName = String.Empty;
        public String FullFileName
        {
            get { return _TemplateSettingObjectFullFileName; }
            set { _TemplateSettingObjectFullFileName = value; }
        }

        /// <summary>
        /// The list with all properties
        /// </summary>
        private GenericPropertyCollection_CustomTypeDescriptor properties;

        public TemplateSettingControl()
        {
            InitializeComponent();


        }




        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            String wszFileName = NewFile();
            _TemplateSettingObject = new TemplateSettingObject();
            _TemplateSettingObject.FullFileName = wszFileName;
            _TemplateSettingObjectFullFileName = wszFileName;
            String wszContent =
               Fwk.HelperFunctions.SerializationFunctions.SerializeToXml(_TemplateSettingObject);

            Fwk.HelperFunctions.FileFunctions.SaveTextFile(_TemplateSettingObject.FullFileName, wszContent);

            RefreshProperties();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            String wFullFileName = OpenFile();
            if (string.IsNullOrEmpty(wFullFileName.Trim())) return;

            String wszContent = Fwk.HelperFunctions.FileFunctions.OpenTextFile(wFullFileName);
            _TemplateSettingObject =
                (TemplateSettingObject)
                Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(TemplateSettingObject), wszContent);

            RefreshProperties();
            OnPropertyChangeEvent();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            String wszContent =
               Fwk.HelperFunctions.SerializationFunctions.SerializeToXml(_TemplateSettingObject);
            try
            {

                Fwk.HelperFunctions.FileFunctions.SaveTextFile(_TemplateSettingObject.FullFileName,
                                                                                wszContent);
            }
            catch (Exception )
            {
                MessageBox.Show(string.Format("No se puede guardar el archivo {0}", _TemplateSettingObject.FullFileName));
            }

            OnPropertyChangeEvent();
        }

        private void SaveAstoolStripButton_Click(object sender, EventArgs e)
        {
            String wFullFileName = NewFile();
            if (string.IsNullOrEmpty(wFullFileName.Trim())) return;

            _TemplateSettingObject.FullFileName = wFullFileName;

            String wszContent = Fwk.HelperFunctions.SerializationFunctions.SerializeToXml(_TemplateSettingObject);

            try
            {
                Fwk.HelperFunctions.FileFunctions.SaveTextFile(_TemplateSettingObject.FullFileName, wszContent);
            }
            catch (Exception )
            {
                MessageBox.Show(string.Format("No se puede guardar el archivo {0}", _TemplateSettingObject.FullFileName));
            }
            RefreshProperties();
            OnPropertyChangeEvent();
        }

        #region Private helpper methods

        public override void Refresh()
        {
           
            if (String.IsNullOrEmpty(_TemplateSettingObjectFullFileName) ||  System.IO.File.Exists(_TemplateSettingObjectFullFileName) == false)
            {
                _TemplateSettingObject = new TemplateSettingObject();

                _TemplateSettingObject.FullFileName = "TemplateSetting.cgt";
            }
            else
            {
                String wszContent = Fwk.HelperFunctions.FileFunctions.OpenTextFile(_TemplateSettingObjectFullFileName);
                _TemplateSettingObject =
                    (TemplateSettingObject)
                    Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(TemplateSettingObject), wszContent);
            }

            RefreshProperties();
        }


        /// <summary>
        /// Muestra dialog box para abrir el archivo de configuracion
        /// </summary>
        /// <returns>String con el nombre del archivo</returns>
        private static String OpenFile()
        {
            OpenFileDialog wDialog = new OpenFileDialog();
            wDialog.DefaultExt = "cgt";
            wDialog.CheckFileExists = true;
            wDialog.Filter = "Template setting  (*.cgt)|*.cgt|All Files (*.*)|*.*";


            if (wDialog.ShowDialog() == DialogResult.OK) return wDialog.FileName;
            else return String.Empty;
        }

        /// <summary>
        /// Crea uhn nuevo template
        /// </summary>
        /// <returns>FullFileName</returns>
        private static String NewFile()
        {
            SaveFileDialog wDialog = new SaveFileDialog();
            wDialog.DefaultExt = "cgt";
            wDialog.Filter = "Template setting (*.cgt)|*.cgt|All Files (*.*)|*.*";
            if (wDialog.ShowDialog() != DialogResult.OK)
                return String.Empty;





            return wDialog.FileName;
        }

        private void RefreshProperties()
        {

            lblTemplate.Text = _TemplateSettingObject.FileName;

            properties = new GenericPropertyCollection_CustomTypeDescriptor();

            properties.AddProperty(new GenericProperty("Projects", _TemplateSettingObject.Project, "1- Projects", ""));

            properties.AddProperty(new GenericProperty("Others", _TemplateSettingObject.OthersSettings, "2- Back", ""));
            properties.AddProperty(new GenericProperty("Methods", _TemplateSettingObject.Methods, "2- Back", ""));
            properties.AddProperty(new GenericProperty("MethodsName", _TemplateSettingObject.MethodsName, "2- Back", ""));
            properties.AddProperty(new GenericProperty("StoreProcedures", _TemplateSettingObject.StoreProcedures, "2- Back", ""));
            properties.AddProperty(new GenericProperty("Entities", _TemplateSettingObject.Entities, "3- Common", ""));






            PropertyGridTempleteSetting.SelectedObject = properties;
            PropertyGridTempleteSetting.ExpandAllGridItems();

            




        }
        #endregion

        private void GenTemplateSetting_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void PropertyGridTempleteSetting_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {

            string label = e.ChangedItem.Label; //((System.Windows.Forms.PropertyGridInternal.PropertyDescriptorGridEntry)e.ChangedItem).Label;

            if (label.Equals("ProjectName", StringComparison.OrdinalIgnoreCase))
            {
                PropertyGridTempleteSetting.SelectedObject = properties;
                PropertyGridTempleteSetting.ExpandAllGridItems();
            }
        }







    }
}
