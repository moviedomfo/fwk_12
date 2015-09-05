//using System;
//using System.IO;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;
//using Fwk.CodeGenerator.Common;
//using Fwk.DataBase.DataEntities;


//namespace Fwk.CodeGenerator
//{
//    public partial class frm_ServicesGenerator : FrmBase

//    {
//        ServiceControlle _ServiceControlle = null;

//        public frm_ServicesGenerator()
//        {
//            InitializeComponent();
//            base.InitializeLastAccessSource();
//            InitializeLastSchema();
//            SchemaControlsVisibles(true);


//        }

     

//        private void btnSearchSchema_Click(object sender, EventArgs e)
//        {
//            OpenFileDialog wSchemaDialog = new OpenFileDialog();
//            wSchemaDialog.DefaultExt = "xsd";
//            wSchemaDialog.CheckFileExists = true;
//            wSchemaDialog.Filter = "XSD Files (*.xsd)|*.xsd|All Files (*.*)|*.*";
            
//            if (wSchemaDialog.ShowDialog() == DialogResult.OK)
//            {
//                txtSchemPath.Text = wSchemaDialog.FileName;
//                FileInfo f = new FileInfo(wSchemaDialog.FileName);
                
//                try
//                {

//                    if (Convert.ToInt32( tabControlSchemas.SelectedTab.Tag) == 0)
//                    {
//                        base.XSDREQ = txtSchemPath.Text;
//                        tvwSchemaREQ.LoadSchemaByName(base.XSDREQ);
//                        tvwSchemaREQ.ImageList = this.imgImages;
//                        txtRequest.Text = f.Name.Replace(".xsd","");

//                        txtServiceName.Text = f.Name.Replace("REQ", "");
//                    }
//                    else
//                    {
//                        base.XSDRES = txtSchemPath.Text;
//                        tvwSchemaRES.LoadSchemaByName(base.XSDRES);
//                        tvwSchemaRES.ImageList = this.imgImages;
//                        txtResponce.Text = f.Name.Replace(".xsd", "");
//                        txtServiceName.Text = txtResponce.Text.Replace("RES", "");
//                    }

                    
                   

//                }
//                catch (Exception err)
//                {
                    
//                    MessageView wMessageView = new MessageView();
//                    wMessageView.Message = err.Message;
//                    wMessageView.ShowDialog();
//                    wMessageView.Dispose();
                    
//                }
                
//            }
            
//        }

    

      

//        private void InitializeLastSchema()
//        {
//            if (base.XSDREQ.Trim().Length == 0)
//                return;

//            FileInfo wFileInfo = new FileInfo(base.XSDREQ);

//            if (wFileInfo.Exists)
//            {
//                if (wFileInfo.Extension.ToLower() == ".xsd")
//                {
//                    this.txtSchemPath.Text = base.XSDREQ;

//                    tvwSchemaREQ.LoadSchemaByName(base.XSDREQ);
//                    tvwSchemaREQ.ImageList = this.imgImages;
//                    txtRequest.Text = wFileInfo.Name.Replace(".xsd","");

                    
//                    txtServiceName.Text = txtRequest.Text.Substring(0, txtRequest.Text.Length - 3);
//                }
//            }

//            if (base.XSDRES.Trim().Length == 0)
//                return;
//            wFileInfo = new FileInfo(base.XSDRES);
//            if (wFileInfo.Exists)
//            {
//                if (wFileInfo.Extension.ToLower() == ".xsd")
//                {
//                    tvwSchemaRES.LoadSchemaByName(base.XSDRES);
//                    tvwSchemaRES.ImageList = this.imgImages;
//                    txtResponce.Text = wFileInfo.Name.Replace(".xsd", ""); ;

//                    if (txtServiceName.Text.Length ==0)
//                        txtServiceName.Text = txtRequest.Text.Replace("RES", "");
//                }
//            }


//        }

//        private void txtSchemPath1_Leave(object sender, EventArgs e)
//        {
//            LoadSchemPath();
            
//        }

        


//        private void SchemaControlsVisibles(bool Visible)
//        {
//            txtSchemPath.Visible = Visible;
//            btnSearchSchema.Visible = Visible;

//        }

      

//        private void ServicesGenerator_DragDrop(object sender, DragEventArgs e)
//        {
//            if (e.Data.GetDataPresent(DataFormats.FileDrop))
//            {
//                string str = ((string[])e.Data.GetData(DataFormats.FileDrop, true))[0];
//                base.SchemaPath = str;
//                InitializeLastSchema();

//            }
//        }

//        private void toolStripButtonGenerate_Click(object sender, EventArgs e)
//        {
            

//            _ServiceControlle = new   ServiceControlle();
            

//            _ServiceControlle.TemplateSettingObject = base.TemplateSettingObject;
//            _ServiceControlle.ServiceName = txtServiceName.Text;

//            textCodeEditor1.Text = String.Empty;

//            if (tvwSchemaRES.Nodes.Count > 0)
//            {
//                _ServiceControlle.GlobalElementComplexTypeRES = this.tvwSchemaRES.GetComplexTypes();
//                _ServiceControlle.GlobalElementComplexTypeREQ = this.tvwSchemaREQ.GetComplexTypes();

//                //listViewCodeGenerated1.NodeCustomSVC = _ServiceControlle.GenerateCode();
//            }
            
//            listViewCodeGenerated1.LoadTtreeView();
//            listViewCodeGenerated1.ExpandServices();
//        }

//        private void listViewCodeGenerated1_ServiceCodeGeneratedSelectEvent(string pTextCode, string pClassName)
//        {
//            tabCtrlCodeParameters.SelectTab(tabPageCode);
            
//            textCodeEditor1.Text = pTextCode;

//            textCodeEditor1.TitleText = pClassName;
//        }

//        private void btnRefresh_Click(object sender, EventArgs e)
//        {
//            LoadSchemPath();
//        }
//        void LoadSchemPath()
//        {
//            if (String.IsNullOrEmpty(txtSchemPath.Text)) return;
//            FileInfo info = new FileInfo(txtSchemPath.Text);
//            if (info.Extension.Trim().ToLower() == ".xsd")
//            {
//                if (tabControlSchemas.SelectedIndex == 0)
//                {
//                    base.XSDREQ = txtSchemPath.Text;
//                    tvwSchemaREQ.LoadSchemaByName(base.XSDREQ);
//                }

//                if (tabControlSchemas.SelectedIndex == 1)
//                {
//                    base.XSDRES = txtSchemPath.Text;
//                    tvwSchemaRES.LoadSchemaByName(base.XSDRES);
//                }
//            }
//        }

//        private void txtServiceName_Leave(object sender, EventArgs e)
//        {
//            txtServiceName.Text = txtServiceName.Text.Replace(" ", String.Empty);
//        }

//        private void txtServiceName_Validating(object sender, CancelEventArgs e)
//        {
//            if (txtServiceName.Text.Trim().Length == 0)
//            {
//                errorProvider1.SetError(txtServiceName, "Service name can not be empty");
                
//                e.Cancel = true;
//            }

            

//            txtServiceName.Text = txtServiceName.Text.Replace(" ", String.Empty);
//        }
   

        

     

//    }
//}