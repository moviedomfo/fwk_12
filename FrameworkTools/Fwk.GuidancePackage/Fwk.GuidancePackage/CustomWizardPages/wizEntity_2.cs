using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.WizardFramework;
using Fwk.DataBase;
using System.ComponentModel.Design;
using Microsoft.SqlServer.Management.Smo;
using Fwk.CodeGenerator;
using Fwk.Guidance.Core;


namespace Fwk.GuidPk
{
    public partial class wizEntity_2 : CustomWizardPage
    {
        CodeGeneratorCommon.SelectedObject _SelectedObject = CodeGeneratorCommon.SelectedObject.Tables;

        CnnString _cnn = new CnnString();

        public wizEntity_2(WizardForm parent)
            : base(parent)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            ctrlTreeViewTables1.SelectElementHandler += new SelectElementHandler(ctrlTreeViewTables1_SelectElementHandler);
            ctrlTreeViewViews1.SelectElementHandler += new SelectElementHandler(ctrlTreeViewTables1_SelectElementHandler);
        }
        List<GeneratedCode> _GeneratedCodeList;

        [RecipeArgument]
        public GeneratedCode[] GeneratedCodeList
        {
            set
            {
                if (value != null)
                    _GeneratedCodeList.AddRange(value);
                else
                    _GeneratedCodeList = null;

            }
        }
        //[RecipeArgument]
        //public string TargetNamespace
        //{
        //    set
        //    {
        //        if (value != null)
        //        {

        //            txtTargetNamespace.Text = value;
        //        }
        //        else
        //        {
        //            txtTargetNamespace.Text = string.Empty;
        //        }
        //    }
        //}


        //[RecipeArgument]
        //public string EntityName
        //{
        //    set
        //    {
        //        if (value != null)
        //        {

        //            txtEntityName.Text = value;
        //        }
        //        else
        //        {
        //            txtEntityName.Text = string.Empty;
        //        }
        //    }
        //}

        //[RecipeArgument]
        //public string TableName
        //{
        //    set
        //    {
        //        if (value != null) { }

        //    }
        //}



        void ctrlTreeViewTables1_SelectElementHandler(object e)
        {


            //IDictionaryService dictionaryService = GetService(typeof(IDictionaryService)) as IDictionaryService;
            //if (e == null)
            //{

   
            //    dictionaryService.SetValue("TableName", null);
            //}
            //else
            //{
            //    //if(_SelectedObject == CodeGeneratorCommon.SelectedObject.Tables)
            //    TableViewBase selTable = (TableViewBase)e;


            //    dictionaryService.SetValue("TableName", selTable.Name);

            //    txtEntityName.Text = selTable.Name;
            //}


        }

        //private void txtEntityName_TextChanged(object sender, EventArgs e)
        //{
        //    IDictionaryService dictionaryService = GetService(typeof(IDictionaryService)) as IDictionaryService;
        //    if (string.IsNullOrEmpty(txtEntityName.Text.ToString()))
        //        dictionaryService.SetValue("EntityName", null);
        //    else
        //        dictionaryService.SetValue("EntityName", txtEntityName.Text);
        //}

        private void wizEntity_2_Load(object sender, EventArgs e)
        {
            LoadDatabaseObjects();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDatabaseObjects();
        }

        private void wizEntity_2_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                LoadDatabaseObjects();
            }

        }




        //private void txtTargetNamespace_TextChanged(object sender, EventArgs e)
        //{
        //    IDictionaryService dictionaryService = GetService(typeof(IDictionaryService)) as IDictionaryService;
        //    if (string.IsNullOrEmpty(txtTargetNamespace.Text.ToString()))
        //        dictionaryService.SetValue("TargetNamespace", null);
        //    else
        //        dictionaryService.SetValue("TargetNamespace", txtTargetNamespace.Text);
        //}

        //private void txtTargetNamespace_Enter(object sender, EventArgs e)
        //{
        //    txtTargetNamespace.SelectAll();
        //}

        //private void txtEntityName_Enter(object sender, EventArgs e)
        //{
        //    txtEntityName.SelectAll();
        //}

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            _SelectedObject = (CodeGeneratorCommon.SelectedObject)
                Enum.Parse(typeof(CodeGeneratorCommon.SelectedObject), tabControl1.SelectedTab.Tag.ToString());

            if(_SelectedObject == CodeGeneratorCommon.SelectedObject.Views)
                ctrlTreeViewViews1.Populate(_cnn);
        }


        void LoadDatabaseObjects()
        {
            IDictionaryService dictionaryService = GetService(typeof(IDictionaryService)) as IDictionaryService;

            string connectionString = dictionaryService.GetValue("ConnectionString").ToString();

            if (!string.IsNullOrEmpty(connectionString))
            {
                _cnn = new CnnString("c1", connectionString);

                RefreshDataObject();
            }


           // txtTargetNamespace.Text = dictionaryService.GetValue("TargetNamespace").ToString();
        }

        private void RefreshDataObject()
        {

            try
            {
                //base._SelectedObject = (CodeGeneratorCommon.SelectedObject)tabControl1.SelectedTab.Tag;
                //if (!base.RefreshMetadata()) return;


                //Esta seleccionado Tables
                if (_SelectedObject == CodeGeneratorCommon.SelectedObject.Views)
                {
                    ctrlTreeViewViews1.Populate(_cnn);
                }

                //Esta seleccionado Tables
                if (_SelectedObject == CodeGeneratorCommon.SelectedObject.Tables)
                {
                    ctrlTreeViewTables1.Populate(_cnn);

                }
                //Esta seleccionado StoreProcedures
                if (_SelectedObject == CodeGeneratorCommon.SelectedObject.StoreProcedures)
                {
                    //treeViewStoreProcedures1.StoreProcedures = base.Metadata.StoreProcedures;
                    //treeViewStoreProcedures1.LoadTreeView();
                }



                //this.lblServer.Text = "Server:" + " [" + base.ServerName + "]";
                //this.lblDatabase.Text = "Database:" + " [" + base.DataBaseName + "]";
            }
            catch (Exception ex)
            {

                MessageBox.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
            }
        }



        public void Generate()
        {
            StringBuilder logs = new StringBuilder();
            logs.AppendLine("Following class will be generated:");
            Metadata _metadata = new Metadata(_cnn);
            _metadata.LoadUserDefinedTypes();
            _metadata.RefreshConnection();


       

            FwkGeneratorHelper.UserDefinedTypes = _metadata.UserDefinedTypes;
            Fwk.CodeGenerator.FwkGeneratorHelper.TemplateSetting = FwkGenerator.TemplateSettingFactoty();

            TreeNode entities = null;

            switch (_SelectedObject)
            {
                case CodeGeneratorCommon.SelectedObject.Tables:
                    {

                        entities = BEGenerator.GenCode(ctrlTreeViewTables1.CheckedTables);
                        break;
                    }
                case CodeGeneratorCommon.SelectedObject.Views:
                    {


                        entities = BEGenerator.GenCode(ctrlTreeViewViews1.CheckedTables);
                        break;
                    }

            }
            _GeneratedCodeList = new List<GeneratedCode>();

            GeneratedCode wGeneratedCode = null;

            foreach (TreeNode nodeDac in entities.Nodes)
            {
                wGeneratedCode = (GeneratedCode)nodeDac.Tag;

                _GeneratedCodeList.Add(wGeneratedCode);

                logs.AppendLine(string.Concat(wGeneratedCode.Id, "DAC"));
            }

            IDictionaryService dictionaryService = GetService(typeof(IDictionaryService)) as IDictionaryService;
            dictionaryService.SetValue("GeneratedCodeList", _GeneratedCodeList.ToArray());
            txtGenerationResult.Text = logs.ToString();

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataObject();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Generate();
        }
    }
}

