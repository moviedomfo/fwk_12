
namespace Fwk.CodeGenerator
{
    partial class FrmTemplateSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Fwk.CodeGenerator.TemplateSettingObject templateSettingObject1 = new Fwk.CodeGenerator.TemplateSettingObject();
            Fwk.CodeGenerator.Entities entities1 = new Fwk.CodeGenerator.Entities();
            Fwk.CodeGenerator.Methods methods1 = new Fwk.CodeGenerator.Methods();
            Fwk.CodeGenerator.MethodsName methodsName1 = new Fwk.CodeGenerator.MethodsName();
            Fwk.CodeGenerator.Project namespacesPattern1 = new Fwk.CodeGenerator.Project();
            Fwk.CodeGenerator.Others others1 = new Fwk.CodeGenerator.Others();
            Fwk.CodeGenerator.StoreProceduresPattern storeProceduresPattern1 = new Fwk.CodeGenerator.StoreProceduresPattern();
            this.genTemplateSetting1 = new Fwk.CodeGenerator.TemplateSettingControl();
            this.SuspendLayout();
            // 
            // genTemplateSetting1
            // 
            this.genTemplateSetting1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.genTemplateSetting1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.genTemplateSetting1.FullFileName = global::Fwk.CodeGenerator.Properties.Resources.AppIcon;
            this.genTemplateSetting1.Location = new System.Drawing.Point(0, 0);
            this.genTemplateSetting1.Name = "genTemplateSetting1";
            this.genTemplateSetting1.Size = new System.Drawing.Size(806, 721);
            this.genTemplateSetting1.TabIndex = 0;
            entities1.BusinessDataCollectionSufix = "List";
            entities1.BusinessDataSufix = "Collection";
            entities1.CollectionsSufix = "List";
            entities1.EntitySufix = "BE";
            templateSettingObject1.Entities = entities1;
            templateSettingObject1.FullFileName = "TemplateSetting.cgt";
            methods1.GenerateBatch = true;
            methods1.IncludeDelete = true;
         
            methods1.IncludeSearchByParam = true;
 
            methods1.IncludeInsert = true;
            methods1.IncludeUpdate = true;
            templateSettingObject1.Methods = methods1;
            methodsName1.Delete = "Delete";
   
            methodsName1.SearchByParam = "SearchByParam";
            methodsName1.Insert = "Insert";
            methodsName1.Update = "Update";
            templateSettingObject1.MethodsName = methodsName1;
          
    
 
         
            templateSettingObject1.Project = namespacesPattern1;
            others1.ConnectionStringKey = "ConnectionStringKey";
            templateSettingObject1.OthersSettings = others1;
            storeProceduresPattern1.DeleteSufix = "_d";
    
            storeProceduresPattern1.InsertSufix = "_i";
            storeProceduresPattern1.UpdateSufix = "_u";
            templateSettingObject1.StoreProcedures = storeProceduresPattern1;
            this.genTemplateSetting1.TemplateSettingObject = templateSettingObject1;
            this.genTemplateSetting1.PropertyChange += new Fwk.CodeGenerator.PropertyChangeHandler(this.genTemplateSetting1_PropertyChange);
            // 
            // FrmTemplateSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 721);
            this.Controls.Add(this.genTemplateSetting1);
            this.Name = "FrmTemplateSetting";
            this.TabText = "Template Setting";
            this.Text = "Template Setting";
            this.ResumeLayout(false);

        }

        #endregion

        private TemplateSettingControl genTemplateSetting1;
    }
}