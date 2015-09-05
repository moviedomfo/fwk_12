//using Fwk.CodeGenerator.Common;
//namespace Fwk.CodeGenerator
//{
//    partial class frm_DataEntityGenerator
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DataEntityGenerator));
//            this.getXSDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.imgImages = new System.Windows.Forms.ImageList(this.components);
//            this.ctlProperties = new System.Windows.Forms.PropertyGrid();
//            this.tabControl1 = new System.Windows.Forms.TabControl();
//            this.tabPage1 = new System.Windows.Forms.TabPage();
//            this.treeViewTables1 = new Fwk.DataBase.CustomControls.TreeViewTables();
//            this.tabPage2 = new System.Windows.Forms.TabPage();
            
//            this.tabPage3 = new System.Windows.Forms.TabPage();
//            this.treeViewStoreProcedures1 = new Fwk.DataBase.CustomControls.TreeViewStoreProcedures();
//            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
//            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
//            this.btnConnect = new System.Windows.Forms.ToolStripButton();
//            this.lblServerName = new System.Windows.Forms.ToolStripLabel();
//            this.lblDatabaseName = new System.Windows.Forms.ToolStripLabel();
//            this.Refresh1 = new System.Windows.Forms.ToolStripButton();
//            this.txtSchemPath1 = new System.Windows.Forms.ToolStripTextBox();
//            this.btnSearchSchema = new System.Windows.Forms.ToolStripButton();
//            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
//            this.toolStripButtonGenerate = new System.Windows.Forms.ToolStripButton();
//            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
//            this.textCodeEditor1 = new Fwk.Controls.Win32.TextCodeEditor();
//            this.listViewCodeGenerated1 = new ListViewCodeGenerated();
//            this.tabControl1.SuspendLayout();
//            this.tabPage1.SuspendLayout();
//            this.tabPage2.SuspendLayout();
//            this.tabPage3.SuspendLayout();
//            this.toolStrip1.SuspendLayout();
//            this.splitContainer1.Panel1.SuspendLayout();
//            this.splitContainer1.Panel2.SuspendLayout();
//            this.splitContainer1.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // getXSDToolStripMenuItem
//            // 
//            this.getXSDToolStripMenuItem.Name = "getXSDToolStripMenuItem";
//            this.getXSDToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
//            // 
//            // imgImages
//            // 
//            this.imgImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgImages.ImageStream")));
//            this.imgImages.TransparentColor = System.Drawing.Color.Transparent;
//            this.imgImages.Images.SetKeyName(0, "unknown.bmp");
//            this.imgImages.Images.SetKeyName(1, "element.bmp");
//            this.imgImages.Images.SetKeyName(2, "simpleType.bmp");
//            this.imgImages.Images.SetKeyName(3, "complexType.bmp");
//            this.imgImages.Images.SetKeyName(4, "a.bmp");
//            this.imgImages.Images.SetKeyName(5, "d.bmp");
//            this.imgImages.Images.SetKeyName(6, "i.bmp");
//            this.imgImages.Images.SetKeyName(7, "aa.bmp");
//            this.imgImages.Images.SetKeyName(8, "ff.bmp");
//            this.imgImages.Images.SetKeyName(9, "Values.ico");
//            this.imgImages.Images.SetKeyName(10, "foldergr.ico");
//            this.imgImages.Images.SetKeyName(11, "150_14.ico");
//            this.imgImages.Images.SetKeyName(12, "152_4.ico");
//            this.imgImages.Images.SetKeyName(13, "164_6.ico");
//            this.imgImages.Images.SetKeyName(14, "165_8.ico");
//            this.imgImages.Images.SetKeyName(15, "168.ico");
//            this.imgImages.Images.SetKeyName(16, "383.ico");
//            this.imgImages.Images.SetKeyName(17, "384.ico");
//            this.imgImages.Images.SetKeyName(18, "fldropen.ico");
//            this.imgImages.Images.SetKeyName(19, "fldropn2.ico");
//            this.imgImages.Images.SetKeyName(20, "fldropn3.ico");
//            // 
//            // ctlProperties
//            // 
//            this.ctlProperties.CategoryForeColor = System.Drawing.Color.White;
//            this.ctlProperties.CommandsDisabledLinkColor = System.Drawing.Color.Blue;
//            this.ctlProperties.HelpBackColor = System.Drawing.Color.SteelBlue;
//            this.ctlProperties.HelpForeColor = System.Drawing.Color.White;
//            this.ctlProperties.LineColor = System.Drawing.Color.SteelBlue;
//            this.ctlProperties.Location = new System.Drawing.Point(2, 360);
//            this.ctlProperties.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
//            this.ctlProperties.Name = "ctlProperties";
//            this.ctlProperties.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
//            this.ctlProperties.Size = new System.Drawing.Size(216, 128);
//            this.ctlProperties.TabIndex = 16;
//            this.ctlProperties.ToolbarVisible = false;
//            this.ctlProperties.ViewForeColor = System.Drawing.Color.Black;
//            // 
//            // tabControl1
//            // 
//            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//                        | System.Windows.Forms.AnchorStyles.Left)));
//            this.tabControl1.Controls.Add(this.tabPage1);
//            this.tabControl1.Controls.Add(this.tabPage2);
//            this.tabControl1.Controls.Add(this.tabPage3);
//            this.tabControl1.Location = new System.Drawing.Point(5, 28);
//            this.tabControl1.Multiline = true;
//            this.tabControl1.Name = "tabControl1";
//            this.tabControl1.SelectedIndex = 0;
//            this.tabControl1.ShowToolTips = true;
//            this.tabControl1.Size = new System.Drawing.Size(222, 438);
//            this.tabControl1.TabIndex = 20;
//            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
//            // 
//            // tabPage1
//            // 
//            this.tabPage1.BackColor = System.Drawing.Color.SteelBlue;
//            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//            this.tabPage1.Controls.Add(this.treeViewTables1);
//            this.tabPage1.Location = new System.Drawing.Point(4, 40);
//            this.tabPage1.Name = "tabPage1";
//            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
//            this.tabPage1.Size = new System.Drawing.Size(214, 394);
//            this.tabPage1.TabIndex = 0;
//            this.tabPage1.Tag = "0";
//            this.tabPage1.Text = "From tables";
//            this.tabPage1.UseVisualStyleBackColor = true;
//            // 
//            // treeViewTables1
//            // 
//            this.treeViewTables1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//                        | System.Windows.Forms.AnchorStyles.Left)
//                        | System.Windows.Forms.AnchorStyles.Right)));
//            this.treeViewTables1.BackColor = System.Drawing.SystemColors.ActiveCaption;
//            this.treeViewTables1.Location = new System.Drawing.Point(3, 2);
//            this.treeViewTables1.Name = "treeViewTables1";
//            this.treeViewTables1.SelectedTable = null;
//            this.treeViewTables1.SelectedTableName = "";
//            this.treeViewTables1.Size = new System.Drawing.Size(203, 387);
//            this.treeViewTables1.TabIndex = 1;
//            this.treeViewTables1.Tablas = null;
//            this.treeViewTables1.SelectObjectEvent += new Fwk.DataBase.CustomControls.SelectObjectHandler(this.treeViewTables1_SelectObjectEvent);
//            // 
//            // tabPage2
//            // 
//            this.tabPage2.BackColor = System.Drawing.Color.SteelBlue;
//            this.tabPage2.Controls.Add(this.ctlProperties);
//            this.tabPage2.Controls.Add(this.tvwSchema);
//            this.tabPage2.Location = new System.Drawing.Point(4, 40);
//            this.tabPage2.Name = "tabPage2";
//            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
//            this.tabPage2.Size = new System.Drawing.Size(214, 394);
//            this.tabPage2.TabIndex = 1;
//            this.tabPage2.Tag = "2";
//            this.tabPage2.Text = "From XSD Schema";
//            this.tabPage2.UseVisualStyleBackColor = true;
//            // 
//            // tvwSchema
//            // 
//            this.tvwSchema.Location = new System.Drawing.Point(4, 6);
//            this.tvwSchema.Name = "tvwSchema";
//            this.tvwSchema.ShowNodeToolTips = true;
//            this.tvwSchema.Size = new System.Drawing.Size(210, 347);
//            this.tvwSchema.TabIndex = 15;
//            this.tvwSchema.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwSchema_AfterSelect);
//            // 
//            // tabPage3
//            // 
//            this.tabPage3.Controls.Add(this.treeViewStoreProcedures1);
//            this.tabPage3.Location = new System.Drawing.Point(4, 40);
//            this.tabPage3.Name = "tabPage3";
//            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
//            this.tabPage3.Size = new System.Drawing.Size(214, 394);
//            this.tabPage3.TabIndex = 2;
//            this.tabPage3.Tag = "1";
//            this.tabPage3.Text = "From store procedures";
//            this.tabPage3.UseVisualStyleBackColor = true;
//            // 
//            // treeViewStoreProcedures1
//            // 
//            this.treeViewStoreProcedures1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//                        | System.Windows.Forms.AnchorStyles.Left)
//                        | System.Windows.Forms.AnchorStyles.Right)));
//            this.treeViewStoreProcedures1.BackColor = System.Drawing.SystemColors.ActiveCaption;
//            this.treeViewStoreProcedures1.Location = new System.Drawing.Point(-1, 6);
//            this.treeViewStoreProcedures1.Name = "treeViewStoreProcedures1";
//            this.treeViewStoreProcedures1.SelectedStoreProcedure = null;
//            this.treeViewStoreProcedures1.SelectedStoreProcedureName = "";
//            this.treeViewStoreProcedures1.Size = new System.Drawing.Size(215, 379);
//            this.treeViewStoreProcedures1.StoreProcedures = null;
//            this.treeViewStoreProcedures1.TabIndex = 1;
//            // 
//            // toolTip1
//            // 
//            this.toolTip1.StripAmpersands = true;
//            this.toolTip1.ToolTipTitle = "Select xsd file";
//            // 
//            // toolStrip1
//            // 
//            this.toolStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
//            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.btnConnect,
//            this.lblServerName,
//            this.lblDatabaseName,
//            this.Refresh1,
//            this.txtSchemPath1,
//            this.btnSearchSchema,
//            this.toolStripLabel1,
//            this.toolStripButtonGenerate});
//            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
//            this.toolStrip1.Name = "toolStrip1";
//            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
//            this.toolStrip1.Size = new System.Drawing.Size(862, 25);
//            this.toolStrip1.TabIndex = 27;
//            this.toolStrip1.Text = "toolStrip1";
//            // 
//            // btnConnect
//            // 
//            this.btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
//            this.btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.Image")));
//            this.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
//            this.btnConnect.Name = "btnConnect";
//            this.btnConnect.Size = new System.Drawing.Size(23, 22);
//            this.btnConnect.Text = "Connect";
//            this.btnConnect.ToolTipText = "Connect to database";
//            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
//            // 
//            // lblServerName
//            // 
//            this.lblServerName.Name = "lblServerName";
//            this.lblServerName.Size = new System.Drawing.Size(49, 22);
//            this.lblServerName.Text = "Server : ";
//            // 
//            // lblDatabaseName
//            // 
//            this.lblDatabaseName.Name = "lblDatabaseName";
//            this.lblDatabaseName.Size = new System.Drawing.Size(60, 22);
//            this.lblDatabaseName.Text = "Database: ";
//            // 
//            // Refresh1
//            // 
//            this.Refresh1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
//            this.Refresh1.Image = ((System.Drawing.Image)(resources.GetObject("Refresh1.Image")));
//            this.Refresh1.ImageTransparentColor = System.Drawing.Color.Magenta;
//            this.Refresh1.Name = "Refresh1";
//            this.Refresh1.Size = new System.Drawing.Size(23, 22);
//            this.Refresh1.ToolTipText = "Refresh connection";
//            this.Refresh1.Click += new System.EventHandler(this.Refresh1_Click);
//            // 
//            // txtSchemPath1
//            // 
//            this.txtSchemPath1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
//            this.txtSchemPath1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
//            this.txtSchemPath1.Name = "txtSchemPath1";
//            this.txtSchemPath1.Size = new System.Drawing.Size(300, 25);
//            this.txtSchemPath1.Leave += new System.EventHandler(this.txtSchemPath1_Leave);
//            // 
//            // btnSearchSchema
//            // 
//            this.btnSearchSchema.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
//            this.btnSearchSchema.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchSchema.Image")));
//            this.btnSearchSchema.ImageTransparentColor = System.Drawing.Color.Magenta;
//            this.btnSearchSchema.Name = "btnSearchSchema";
//            this.btnSearchSchema.Size = new System.Drawing.Size(23, 22);
//            this.btnSearchSchema.Text = "Select XSD schema";
//            this.btnSearchSchema.Click += new System.EventHandler(this.btnSearchSchema_Click);
//            // 
//            // toolStripLabel1
//            // 
//            this.toolStripLabel1.Name = "toolStripLabel1";
//            this.toolStripLabel1.Size = new System.Drawing.Size(47, 22);
//            this.toolStripLabel1.Text = "..........";
//            // 
//            // toolStripButtonGenerate
//            // 
//            this.toolStripButtonGenerate.BackColor = System.Drawing.Color.LightSteelBlue;
//            this.toolStripButtonGenerate.Image = global::Fwk.CodeGenerator.Properties.Resources.servicerunning;
//            this.toolStripButtonGenerate.ImageTransparentColor = System.Drawing.Color.Magenta;
//            this.toolStripButtonGenerate.Name = "toolStripButtonGenerate";
//            this.toolStripButtonGenerate.Size = new System.Drawing.Size(72, 22);
//            this.toolStripButtonGenerate.Text = "Generate";
//            this.toolStripButtonGenerate.ToolTipText = "Generate code ..";
//            this.toolStripButtonGenerate.Click += new System.EventHandler(this.toolStripButtonGenerate_Click);
//            // 
//            // splitContainer1
//            // 
//            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//                        | System.Windows.Forms.AnchorStyles.Left)
//                        | System.Windows.Forms.AnchorStyles.Right)));
//            this.splitContainer1.Location = new System.Drawing.Point(229, 32);
//            this.splitContainer1.Name = "splitContainer1";
//            // 
//            // splitContainer1.Panel1
//            // 
//            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
//            this.splitContainer1.Panel1.Controls.Add(this.textCodeEditor1);
//            // 
//            // splitContainer1.Panel2
//            // 
//            this.splitContainer1.Panel2.Controls.Add(this.listViewCodeGenerated1);
//            this.splitContainer1.Size = new System.Drawing.Size(633, 435);
//            this.splitContainer1.SplitterDistance = 497;
//            this.splitContainer1.TabIndex = 33;
//            // 
//            // textCodeEditor1
//            // 
//            this.textCodeEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//                        | System.Windows.Forms.AnchorStyles.Left)
//                        | System.Windows.Forms.AnchorStyles.Right)));
//            this.textCodeEditor1.Location = new System.Drawing.Point(6, 3);
//            this.textCodeEditor1.Name = "textCodeEditor1";
//            this.textCodeEditor1.Size = new System.Drawing.Size(487, 427);
//            this.textCodeEditor1.TabIndex = 31;
//            this.textCodeEditor1.TitleText = "";
//            this.textCodeEditor1.TitleVisible = true;
//            // 
//            // listViewCodeGenerated1
//            // 
//            this.listViewCodeGenerated1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//                        | System.Windows.Forms.AnchorStyles.Left)
//                        | System.Windows.Forms.AnchorStyles.Right)));
//            this.listViewCodeGenerated1.ForeColorBE = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
//            this.listViewCodeGenerated1.ForeColorDAC = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
//            this.listViewCodeGenerated1.ForeColorSP = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
//            this.listViewCodeGenerated1.ForeColorSVC = System.Drawing.Color.Empty;
            
//            this.listViewCodeGenerated1.NodeBE = null;
//            this.listViewCodeGenerated1.Location = new System.Drawing.Point(-2, -3);
//            this.listViewCodeGenerated1.Name = "listViewCodeGenerated1";
//            this.listViewCodeGenerated1.NodeCustomSVC = null;
//            this.listViewCodeGenerated1.NodeDAC = null;
//            this.listViewCodeGenerated1.NodeSP = null;
//            this.listViewCodeGenerated1.NodeSVC = null;
//            this.listViewCodeGenerated1.NodeTDG = null;
//            this.listViewCodeGenerated1.Size = new System.Drawing.Size(135, 442);
//            this.listViewCodeGenerated1.TabIndex = 0;
//            this.listViewCodeGenerated1.BECodeGeneratedSelectEvent += new BECodeGeneratedSelectHandler(this.listViewCodeGenerated1_BECodeGeneratedSelectEvent);
//            // 
//            // frm_DataEntityGenerator
//            // 
//            this.AllowDrop = true;
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = System.Drawing.Color.WhiteSmoke;
//            this.ClientSize = new System.Drawing.Size(862, 499);
//            this.Controls.Add(this.splitContainer1);
//            this.Controls.Add(this.toolStrip1);
//            this.Controls.Add(this.tabControl1);
//            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
//            this.MinimizeBox = false;
//            this.Name = "frm_DataEntityGenerator";
//            this.TabText = "Entities :.";
//            this.Text = "Entities code generator";
//            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.DataEntityGenerator_DragDrop);
//            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataEntityGenerator_FormClosing);
//            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.DataEntityGenerator_DragEnter);
//            this.tabControl1.ResumeLayout(false);
//            this.tabPage1.ResumeLayout(false);
//            this.tabPage2.ResumeLayout(false);
//            this.tabPage3.ResumeLayout(false);
//            this.toolStrip1.ResumeLayout(false);
//            this.toolStrip1.PerformLayout();
//            this.splitContainer1.Panel1.ResumeLayout(false);
//            this.splitContainer1.Panel2.ResumeLayout(false);
//            this.splitContainer1.ResumeLayout(false);
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private System.Windows.Forms.ToolStripMenuItem getXSDToolStripMenuItem;
//        private System.Windows.Forms.ImageList imgImages;
      
//        private System.Windows.Forms.PropertyGrid ctlProperties;
//        private System.Windows.Forms.TabControl tabControl1;
//        private System.Windows.Forms.TabPage tabPage1;
//        private System.Windows.Forms.TabPage tabPage2;
//        private System.Windows.Forms.ToolTip toolTip1;
//        private System.Windows.Forms.ToolStrip toolStrip1;
//        private System.Windows.Forms.ToolStripButton btnConnect;
//        private System.Windows.Forms.ToolStripLabel lblServerName;
//        private System.Windows.Forms.ToolStripLabel lblDatabaseName;
//        private System.Windows.Forms.ToolStripButton Refresh1;
//        private System.Windows.Forms.ToolStripTextBox txtSchemPath1;
//        private System.Windows.Forms.ToolStripButton btnSearchSchema;
//        private Fwk.DataBase.CustomControls.TreeViewTables treeViewTables1;
//        private System.Windows.Forms.SplitContainer splitContainer1;
//        private ListViewCodeGenerated listViewCodeGenerated1;
//        private System.Windows.Forms.TabPage tabPage3;
//        private Fwk.DataBase.CustomControls.TreeViewStoreProcedures treeViewStoreProcedures1;
//        private System.Windows.Forms.ToolStripButton toolStripButtonGenerate;
//        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
//        private Fwk.Controls.Win32.TextCodeEditor textCodeEditor1;
//    }
//}

