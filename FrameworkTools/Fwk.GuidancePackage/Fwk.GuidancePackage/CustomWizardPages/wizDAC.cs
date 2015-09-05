using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Fwk.DataBase;
using Microsoft.Practices.WizardFramework;
using System.ComponentModel.Design;
using Microsoft.Practices.RecipeFramework.Services;
using Microsoft.Practices.RecipeFramework.Library;
using Microsoft.Practices.RecipeFramework.VisualStudio;
using EnvDTE;
using Fwk.CodeGenerator;
using System.Reflection;
using Fwk.Guidance.Core;

namespace Fwk.GuidPk
{

    public partial class wizDAC : CustomWizardPage
    {

        CnnString _cnn = new CnnString();
        
        List<GeneratedCode> _GeneratedCodeList;
        
        [RecipeArgument]
        public GeneratedCode[] GeneratedCodeList
        {
            set
            {
                if (value != null)
                    _GeneratedCodeList.AddRange( value);
                else
                    _GeneratedCodeList = null;

            }
        }


        

        public wizDAC()
        {
            InitializeComponent();
        }

        public wizDAC(WizardForm parent)
            : base(parent)
        {
            InitializeComponent();

            ctrlTreeViewTables1.SelectElementHandler += new SelectElementHandler(ctrlTreeViewTables1_SelectElementHandler);
        }

        internal void LoadCnn(string cnnString)
        {
            _cnn = new CnnString("c1", cnnString.ToString());
            ctrlTreeViewTables1.Populate(_cnn);
        }

        void LoadTables()
        {
            IDictionaryService dictionaryService = GetService(typeof(IDictionaryService)) as IDictionaryService;

            string connectionString = dictionaryService.GetValue("ConnectionString").ToString();

            if (!string.IsNullOrEmpty(connectionString))
                LoadCnn(connectionString);
       }


        public void Generate()
        {
            StringBuilder logs = new StringBuilder();
            logs.AppendLine("Following class will be generated:");
            GeneratedCode wGeneratedCode = null;
             _GeneratedCodeList = new List<GeneratedCode>();
             Fwk.CodeGenerator.FwkGeneratorHelper.TemplateSetting = FwkGenerator.TemplateSettingFactoty();

            TreeNode dacs = Fwk.CodeGenerator.DACGenerator.GenCode(ctrlTreeViewTables1.CheckedTables);
            IDictionaryService dictionaryService = GetService(typeof(IDictionaryService)) as IDictionaryService;
            foreach (TreeNode nodeDac in dacs.Nodes)
            {
                wGeneratedCode = (GeneratedCode)nodeDac.Tag;
                
                _GeneratedCodeList.Add(wGeneratedCode);
                
                logs.AppendLine(string.Concat(wGeneratedCode.Id,"DAC") );
            }

            dictionaryService.SetValue("GeneratedCodeList", _GeneratedCodeList.ToArray());
            txtGenerationResult.Text = logs.ToString();
        }
    
      
       



        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            Generate();
        }











        //Table selTable = null;
        void ctrlTreeViewTables1_SelectElementHandler(object e)
        {


            //if (e != null)
            //{
            //     selTable = (Table)e;
            //    txtGenerationResult.Text = selTable.Name;
            //}



        }

        private void wizDAC_Load(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void wizDAC_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                LoadTables();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Generate();
        }
   
    }

}