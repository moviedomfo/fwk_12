//using System;
//using System.IO;
//using System.Windows.Forms;


//namespace Fwk.CodeGenerator
//{
//    public partial class frm_DataEntityGenerator : CodeGenerator.FrmBase 
//    {
//        BakcEndGenController wDACGenController = null;
//        private string LastParentKey = string.Empty;
//        private string LastEntityName = string.Empty;

//        public frm_DataEntityGenerator()
//        {

//            InitializeComponent();
//            base.InitializeLastAccessSource();
//            InitializeLastSchema();
//            SchemaControlsVisibles(false);
//        }

//        private void tvwSchema_AfterSelect(object sender, TreeViewEventArgs e)
//        {
//            if (this.tvwSchema.SelectedNode != null)
//            {
//                this.ctlProperties.SelectedObject = this.tvwSchema.SelectedNode.Tag;
//            }
//        }

//        private void InitializeLastSchema()
//        {
//            if (base.SchemaPath.Trim() == string.Empty)
//                return;

//            FileInfo info = new FileInfo(base.SchemaPath);

//            if(info.Exists)
//                if (info.Extension.ToLower() == ".xsd")
//                {
//                    this.txtSchemPath1.Text = base.SchemaPath;
//                    tvwSchema.LoadSchemaByName(base.SchemaPath);
//                    tvwSchema.ImageList = this.imgImages;
//                }
           

//        }

     

      
//        private void DataEntityGenerator_FormClosing(object sender, FormClosingEventArgs e)
//        {
//            if (CodeGeneratorCommon.ValidateFileByExtencion("xsd", txtSchemPath1.Text))
//                base.SchemaPath = txtSchemPath1.Text;

//        }

//        private void SchemaControlsVisibles(bool Visible)
//        {
//            txtSchemPath1.Visible = Visible;
//            btnSearchSchema.Visible = Visible;
//            btnConnect.Enabled = !Visible;
//        }

      

//        private void tabControl1_Click(object sender, EventArgs e)
//        {
//            _SelectedObject = (CodeGeneratorCommon.SelectedObject)Enum.Parse(typeof(CodeGeneratorCommon.SelectedObject), tabControl1.SelectedTab.Tag.ToString());

//            if (_SelectedObject == CodeGeneratorCommon.SelectedObject.Tables || _SelectedObject == CodeGeneratorCommon.SelectedObject.StoreProcedures)
//                SchemaControlsVisibles(false);
//            else
//                SchemaControlsVisibles(true);

//        }

//        private void DataEntityGenerator_DragDrop(object sender, DragEventArgs e)
//        {

//            if (e.Data.GetDataPresent(DataFormats.FileDrop))
//            {
//                string str = ((string[])e.Data.GetData(DataFormats.FileDrop, true))[0];
//                base.SchemaPath = str;
//                InitializeLastSchema();

//            }
//        }

//        private void DataEntityGenerator_DragEnter(object sender, DragEventArgs e)
//        {
//            if (e.Data.GetDataPresent(DataFormats.FileDrop))
//                e.Effect = DragDropEffects.Copy;
//        }

//        private void btnSearchSchema_Click(object sender, EventArgs e)
//        {
//            OpenFileDialog wSchemaDialog = new OpenFileDialog();
//            wSchemaDialog.DefaultExt = "xsd";
//            wSchemaDialog.CheckFileExists = true;
//            wSchemaDialog.Filter = "XSD Files (*.xsd)|*.xsd|All Files (*.*)|*.*";

//            if (wSchemaDialog.ShowDialog() == DialogResult.OK)
//            {
//                try
//                {
//                    tvwSchema.LoadSchemaByName(wSchemaDialog.FileName);
//                    tvwSchema.ImageList = this.imgImages;
//                    txtSchemPath1.Text = wSchemaDialog.FileName;
//                    base.SchemaPath = txtSchemPath1.Text;

//                }
//                catch (Exception err)
//                {
//                    textCodeEditor1.Text = err.ToString();
//                }
//            }
//        }

//        private void btnConnect_Click(object sender, EventArgs e)
//        {
//            base.ShowConnection();
//            if (base.ConnectionOk)
//            {

//                if (base.CnnStringChange)
//                {
//                    treeViewTables1.Clear();
//                    treeViewStoreProcedures1.Clear();
//                }
              
//                base.RefreshMetadata();

               
//                //Tables 
//                if (_SelectedObject == CodeGeneratorCommon.SelectedObject.Tables)
//                    treeViewTables1.Tablas = base.Metadata.Tables;


//                //Procedimientos Almacenados
//                if (_SelectedObject == CodeGeneratorCommon.SelectedObject.StoreProcedures)
//                    treeViewStoreProcedures1.StoreProcedures = base.Metadata.StoreProcedures;

//                this.lblServerName.Text = "Server:" + " [" + base.ServerName + "]";
//                this.lblDatabaseName.Text = "Database:" + " [" + base.DataBaseName + "]";
       
//            }
//        }

//        private void Refresh1_Click(object sender, EventArgs e)

//        {
//            try
//            {
//                base.RefreshMetadata();

//                if (_SelectedObject == CodeGeneratorCommon.SelectedObject.Tables)
//                {
//                    treeViewTables1.Tablas = base.Metadata.Tables;
//                    treeViewTables1.LoadTreeView();
//                }

//                if (_SelectedObject == CodeGeneratorCommon.SelectedObject.StoreProcedures)
//                {
//                    treeViewStoreProcedures1.StoreProcedures = base.Metadata.StoreProcedures;
//                    treeViewStoreProcedures1.LoadTreeView();
//                }
    
//                this.lblServerName.Text = "Server:" + " [" + base.ServerName + "]";
//                this.lblDatabaseName.Text = "Database:" + " [" + base.DataBaseName + "]";
//            }
//            catch (Exception ex)
//            {
//                //Common.WriteEntryEventLog("Error al cargar Objetos de base de datos. Puede que no este bien formado el archivo DataBaseConfig.xml", ex, 1001, System.Diagnostics.EventLogEntryType.Error);
//                MessageView wMessageView = new MessageView();
//                wMessageView.Message = ex.Message;
//                wMessageView.ShowDialog();
//            }
//        }

//        private void btnRefreshSchema_Click(object sender, EventArgs e)
//        {
//            InitializeLastSchema();
//        }

//        private void listViewCodeGenerated1_BECodeGeneratedSelectEvent(string pTextCode, string pEntityName, string pParentKey)
//        {
//            textCodeEditor1.Text = pTextCode;
//            textCodeEditor1.TitleText = "Business Entity from: " + pEntityName;
//            LastEntityName = pEntityName;
//            LastParentKey = pParentKey;
//        }


     

//        private void toolStripButtonGenerate_Click(object sender, EventArgs e)
//        {
           

//            wDACGenController = new BakcEndGenController();
//            FwkGeneratorHelper.TemplateSetting = base.TemplateSettingObject;
          
//            //wDACGenController.UserDefinedTypes = base.Metadata.UserDefinedTypes;
//            wDACGenController.SelectedObject = Enum.GetName (typeof(CodeGeneratorCommon.SelectedObject), _SelectedObject);
//            wDACGenController.ListViewCodeGenerated = listViewCodeGenerated1;


//            switch (_SelectedObject)
//            {
//                case CodeGeneratorCommon.SelectedObject.Tables:
//                    {
//                        if (treeViewTables1.SelectedTable != null)
//                        {
//                            //wDACGenController.Tables = treeViewTables1.GetSelectedTables();

//                            wDACGenController.GenerateBEOnly();
//                        }
//                        break;
//                    }

//                case CodeGeneratorCommon.SelectedObject.StoreProcedures:
//                    {
//                        if (treeViewStoreProcedures1.SelectedStoreProcedure == null) return;
//                        //wDACGenController.StoreProcedures = treeViewStoreProcedures1.GetSelectedStoreProcedures();
//                        wDACGenController.GenerateBEOnly();
//                        break;
//                    }
//                case CodeGeneratorCommon.SelectedObject.Schema:
//                    {
                        
//                        //textCodeEditor1.Text = string.Empty;
//                        //if (tvwSchema.Nodes.Count > 0)
//                        //{
//                        //    //List<GlobalElementComplexType> wGlobalElementComplexTypeList = this.tvwSchema.GetComplexTypes();
//                        //    wDACGenController.GlobalElementComplexTypeList = this.tvwSchema.GetComplexTypes();

//                        //    //wEntityGenerationInfo.Entities = DACControllers.GenerateEntityInfo(wGlobalElementComplexTypeList, null, string.Empty);//SchemEntityGenEngine.GeneratesSchemaCode(wListTables);
//                        //    //textCodeEditor1.Text = ServiceControlle.BEFromSchemaGenerator_GenerateCode(wEntityGenerationInfo);
//                        //    wDACGenController.GlobalElementComplexTypeList = this.tvwSchema.GetComplexTypes();
//                        //    textCodeEditor1.Text = wDACGenController.GenerateBEFromSchema();
//                        //}
//                        break;
//                    }

//            }

//            //if (this.tabControl1.SelectedIndex == 0)
//            //{
//            //    if (treeViewTables1.SelectedTable != null)
//            //    {
//            //        Tables wTablesSelected = treeViewTables1.GetSelectedTables();
//            //        wEntityGenerationInfo.Entities = DACControllers.GenerateEntityInfo(wTablesSelected, false);
//            //        listViewCodeGenerated1.GeneratedBECodeList = DACControllers.BEFromTableGenerator_GenerateCode(wEntityGenerationInfo);
//            //    }
//            //}

//            //if (this.tabControl1.SelectedIndex == 2)
//            //{
//            //    if (treeViewStoreProcedures1.SelectedStoreProcedure != null)
//            //    {
//            //        StoreProcedures wStoreProceduresSelected = treeViewStoreProcedures1.GetSelectedStoreProcedures();
//            //        wEntityGenerationInfo.Entities = DACControllers.GenerateEntityInfo(wStoreProceduresSelected, false);

//            //        listViewCodeGenerated1.GeneratedBECodeList = DACControllers.BEFromTableGenerator_GenerateCode(wEntityGenerationInfo);
//            //    }
//            //}

//            //if (this.tabControl1.SelectedIndex == 1)
//            //{
//            //    textCodeEditor1.Text = string.Empty;
//            //    if (tvwSchema.Nodes.Count > 0)
//            //    {
//            //        List<GlobalElementComplexType> wGlobalElementComplexTypeList = this.tvwSchema.GetComplexTypes();

//            //        wEntityGenerationInfo.Entities = DACControllers.GenerateEntityInfo(wGlobalElementComplexTypeList,null,string.Empty);//SchemEntityGenEngine.GeneratesSchemaCode(wListTables);
//            //        textCodeEditor1.Text = DACControllers.BEFromSchemaGenerator_GenerateCode(wEntityGenerationInfo);
//            //    }
//            //}
//            if (this.tabControl1.SelectedIndex != 1)
//            {
//                if (LastEntityName.Length != 0)
//                {
//                    textCodeEditor1.Text = listViewCodeGenerated1.GetLastSelectedEntityCode(LastParentKey, LastEntityName);
//                }
//                else
//                {
//                    textCodeEditor1.Text = String.Empty;
//                    textCodeEditor1.TitleText = String.Empty;
//                }
//            }
//        }

      

//        private void txtSchemPath1_Leave(object sender, EventArgs e)
//        {
//            if (File.Exists(txtSchemPath1.Text))
//            {
//                FileInfo info = new FileInfo(txtSchemPath1.Text);
//                if (info.Extension.Trim().ToLower() == ".xsd")
//                {
//                    base.SchemaPath = txtSchemPath1.Text;
//                    InitializeLastSchema();
//                }
//            }
//        }

//        private void treeViewTables1_SelectObjectEvent()
//        {
//            if (treeViewStoreProcedures1.SelectedStoreProcedure != null)
//                textCodeEditor1.Text = treeViewStoreProcedures1.SelectedStoreProcedure.Text;
//        }
//    }
//}