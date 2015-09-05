using System;



namespace Fwk.CodeGenerator
{
    public partial class FrmTemplateSetting : Fwk.Controls.Win32.DockContent
    {
        #region <-- Events -->
        //private  event PropertyChangeHandler _PropertyChangeEvent = null;
        public event PropertyChangeHandler PropertyChange = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        private void OnPropertyChangeEvent()
        {
            if (PropertyChange != null)
                PropertyChange(this.genTemplateSetting1.TemplateSettingObject);
        }
       
        #endregion
        public TemplateSettingObject TemplateSettingObject
        {
            get { return this.genTemplateSetting1.TemplateSettingObject; }
        }
        public String FullFileName
        {
            get { return this.genTemplateSetting1.FullFileName; }
            set { this.genTemplateSetting1.FullFileName = value; }
        }

        /// <summary>
        /// Reinicia los settings templates
        /// </summary>
        public override void Refresh()
        {
           genTemplateSetting1.Refresh(); 
        }
        public FrmTemplateSetting()
        {
            InitializeComponent();
           
        }

        
        private void genTemplateSetting1_PropertyChange(TemplateSettingObject pTemplateSettingObjec)
        {
            OnPropertyChangeEvent();

        }

        
    }
}