//using Fwk.CodeGenerator.Common;
//namespace Fwk.CodeGenerator
//{
//    partial class frm_ServicesGenerator
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
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ServicesGenerator));
//            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
//            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
//            this.txtSchemPath = new System.Windows.Forms.ToolStripTextBox();
//            this.btnSearchSchema = new System.Windows.Forms.ToolStripButton();
//            this.toolStripButtonGenerate = new System.Windows.Forms.ToolStripButton();
//            this.listViewCodeGenerated1 = new ListViewCodeGenerated();
//            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
//            this.tabCtrlCodeParameters = new System.Windows.Forms.TabControl();
//            this.tabPageParams = new System.Windows.Forms.TabPage();
//            this.tabControlSchemas = new System.Windows.Forms.TabControl();
//            this.tabPageREQ = new System.Windows.Forms.TabPage();
//            this.tvwSchemaREQ = new XSDTreeView();
//            this.tabPageRES = new System.Windows.Forms.TabPage();
//            this.tvwSchemaRES = new XSDTreeView();
//            this.groupBox2 = new System.Windows.Forms.GroupBox();
//            this.lblResponce = new System.Windows.Forms.Label();
//            this.txtResponce = new System.Windows.Forms.TextBox();
//            this.lblRequest = new System.Windows.Forms.Label();
//            this.txtRequest = new System.Windows.Forms.TextBox();
//            this.lblServiceName = new System.Windows.Forms.Label();
//            this.txtServiceName = new System.Windows.Forms.TextBox();
//            this.tabPageCode = new System.Windows.Forms.TabPage();
//            this.textCodeEditor1 = new Fwk.Controls.Win32.TextCodeEditor();
//            this.imgImages = new System.Windows.Forms.ImageList(this.components);
//            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
//            this.toolStrip1.SuspendLayout();
//            this.splitContainer1.Panel1.SuspendLayout();
//            this.splitContainer1.Panel2.SuspendLayout();
//            this.splitContainer1.SuspendLayout();
//            this.tabCtrlCodeParameters.SuspendLayout();
//            this.tabPageParams.SuspendLayout();
//            this.tabControlSchemas.SuspendLayout();
//            this.tabPageREQ.SuspendLayout();
//            this.tabPageRES.SuspendLayout();
//            this.groupBox2.SuspendLayout();
//            this.tabPageCode.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // toolStrip1
//            // 
//            this.toolStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
//            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.btnRefresh,
//            this.txtSchemPath,
//            this.btnSearchSchema,
//            this.toolStripButtonGenerate});
//            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
//            this.toolStrip1.Name = "toolStrip1";
//            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
//            this.toolStrip1.Size = new System.Drawing.Size(953, 25);
//            this.toolStrip1.TabIndex = 33;
//            this.toolStrip1.Text = "toolStrip1";
//            // 
//            // btnRefresh
//            // 
//            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
//            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
//            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
//            this.btnRefresh.Name = "btnRefresh";
//            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
//            this.btnRefresh.ToolTipText = "Refresh connection";
//            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
//            // 
//            // txtSchemPath
//            // 
//            this.txtSchemPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
//            this.txtSchemPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
//            this.txtSchemPath.Name = "txtSchemPath";
//            this.txtSchemPath.Size = new System.Drawing.Size(300, 25);
//            this.txtSchemPath.Leave += new System.EventHandler(this.txtSchemPath1_Leave);
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
//            // toolStripButtonGenerate
//            // 
//            this.toolStripButtonGenerate.BackColor = System.Drawing.Color.Transparent;
//            this.toolStripButtonGenerate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
//            this.toolStripButtonGenerate.ForeColor = System.Drawing.Color.Black;
//            this.toolStripButtonGenerate.Image = global::Fwk.CodeGenerator.Properties.Resources.servicerunning;
//            this.toolStripButtonGenerate.ImageTransparentColor = System.Drawing.Color.Transparent;
//            this.toolStripButtonGenerate.Name = "toolStripButtonGenerate";
//            this.toolStripButtonGenerate.Size = new System.Drawing.Size(80, 22);
//            this.toolStripButtonGenerate.Text = "Generate";
//            this.toolStripButtonGenerate.ToolTipText = "Generate code ..";
//            this.toolStripButtonGenerate.Click += new System.EventHandler(this.toolStripButtonGenerate_Click);
//            // 
//            // listViewCodeGenerated1
//            // 
//            this.listViewCodeGenerated1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//                        | System.Windows.Forms.AnchorStyles.Left)
//                        | System.Windows.Forms.AnchorStyles.Right)));
//            this.listViewCodeGenerated1.ForeColorBE = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
//            this.listViewCodeGenerated1.ForeColorDAC = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
//            this.listViewCodeGenerated1.ForeColorSP = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
//            this.listViewCodeGenerated1.ForeColorSVC = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
//            this.listViewCodeGenerated1.ForeColorTDG = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
//            this.listViewCodeGenerated1.NodeBE = null;
//            this.listViewCodeGenerated1.Location = new System.Drawing.Point(3, -1);
//            this.listViewCodeGenerated1.Name = "listViewCodeGenerated1";
//            this.listViewCodeGenerated1.NodeCustomSVC = null;
//            this.listViewCodeGenerated1.NodeDAC = null;
//            this.listViewCodeGenerated1.NodeSP = null;
//            this.listViewCodeGenerated1.NodeSVC = null;
//            this.listViewCodeGenerated1.NodeTDG = null;
//            this.listViewCodeGenerated1.Size = new System.Drawing.Size(244, 399);
//            this.listViewCodeGenerated1.TabIndex = 0;
//            this.listViewCodeGenerated1.ServiceCodeGeneratedSelectEvent += new ServiceCodeGeneratedSelectHandler(this.listViewCodeGenerated1_ServiceCodeGeneratedSelectEvent);
//            // 
//            // splitContainer1
//            // 
//            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//                        | System.Windows.Forms.AnchorStyles.Left)
//                        | System.Windows.Forms.AnchorStyles.Right)));
//            this.splitContainer1.Location = new System.Drawing.Point(12, 28);
//            this.splitContainer1.Name = "splitContainer1";
//            // 
//            // splitContainer1.Panel1
//            // 
//            this.splitContainer1.Panel1.Controls.Add(this.tabCtrlCodeParameters);
//            // 
//            // splitContainer1.Panel2
//            // 
//            this.splitContainer1.Panel2.Controls.Add(this.listViewCodeGenerated1);
//            this.splitContainer1.Size = new System.Drawing.Size(929, 402);
//            this.splitContainer1.SplitterDistance = 679;
//            this.splitContainer1.TabIndex = 37;
//            // 
//            // tabCtrlCodeParameters
//            // 
//            this.tabCtrlCodeParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//                        | System.Windows.Forms.AnchorStyles.Left)
//                        | System.Windows.Forms.AnchorStyles.Right)));
//            this.tabCtrlCodeParameters.Controls.Add(this.tabPageParams);
//            this.tabCtrlCodeParameters.Controls.Add(this.tabPageCode);
//            this.tabCtrlCodeParameters.Location = new System.Drawing.Point(4, 7);
//            this.tabCtrlCodeParameters.Name = "tabCtrlCodeParameters";
//            this.tabCtrlCodeParameters.SelectedIndex = 0;
//            this.tabCtrlCodeParameters.Size = new System.Drawing.Size(672, 395);
//            this.tabCtrlCodeParameters.TabIndex = 37;
//            // 
//            // tabPageParams
//            // 
//            this.tabPageParams.BackColor = System.Drawing.SystemColors.ButtonHighlight;
//            this.tabPageParams.Controls.Add(this.tabControlSchemas);
//            this.tabPageParams.Controls.Add(this.groupBox2);
//            this.tabPageParams.Location = new System.Drawing.Point(4, 22);
//            this.tabPageParams.Name = "tabPageParams";
//            this.tabPageParams.Padding = new System.Windows.Forms.Padding(3);
//            this.tabPageParams.Size = new System.Drawing.Size(664, 369);
//            this.tabPageParams.TabIndex = 0;
//            this.tabPageParams.Text = "Parameters";
//            // 
//            // tabControlSchemas
//            // 
//            this.tabControlSchemas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//                        | System.Windows.Forms.AnchorStyles.Left)
//                        | System.Windows.Forms.AnchorStyles.Right)));
//            this.tabControlSchemas.Controls.Add(this.tabPageREQ);
//            this.tabControlSchemas.Controls.Add(this.tabPageRES);
//            this.tabControlSchemas.Location = new System.Drawing.Point(6, 118);
//            this.tabControlSchemas.Multiline = true;
//            this.tabControlSchemas.Name = "tabControlSchemas";
//            this.tabControlSchemas.SelectedIndex = 0;
//            this.tabControlSchemas.ShowToolTips = true;
//            this.tabControlSchemas.Size = new System.Drawing.Size(596, 248);
//            this.tabControlSchemas.TabIndex = 38;
//            // 
//            // tabPageREQ
//            // 
//            this.tabPageREQ.BackColor = System.Drawing.Color.SteelBlue;
//            this.tabPageREQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//            this.tabPageREQ.Controls.Add(this.tvwSchemaREQ);
//            this.tabPageREQ.Location = new System.Drawing.Point(4, 22);
//            this.tabPageREQ.Name = "tabPageREQ";
//            this.tabPageREQ.Padding = new System.Windows.Forms.Padding(3);
//            this.tabPageREQ.Size = new System.Drawing.Size(588, 222);
//            this.tabPageREQ.TabIndex = 0;
//            this.tabPageREQ.Tag = "0";
//            this.tabPageREQ.Text = "Request";
//            this.tabPageREQ.UseVisualStyleBackColor = true;
//            // 
//            // tvwSchemaREQ
//            // 
//            this.tvwSchemaREQ.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//                        | System.Windows.Forms.AnchorStyles.Left)
//                        | System.Windows.Forms.AnchorStyles.Right)));
//            this.tvwSchemaREQ.Location = new System.Drawing.Point(-1, 2);
//            this.tvwSchemaREQ.Name = "tvwSchemaREQ";
//            this.tvwSchemaREQ.ShowNodeToolTips = true;
//            this.tvwSchemaREQ.Size = new System.Drawing.Size(585, 208);
//            this.tvwSchemaREQ.TabIndex = 17;
//            // 
//            // tabPageRES
//            // 
//            this.tabPageRES.BackColor = System.Drawing.Color.SteelBlue;
//            this.tabPageRES.Controls.Add(this.tvwSchemaRES);
//            this.tabPageRES.Location = new System.Drawing.Point(4, 22);
//            this.tabPageRES.Name = "tabPageRES";
//            this.tabPageRES.Padding = new System.Windows.Forms.Padding(3);
//            this.tabPageRES.Size = new System.Drawing.Size(588, 222);
//            this.tabPageRES.TabIndex = 1;
//            this.tabPageRES.Tag = "1";
//            this.tabPageRES.Text = "Response";
//            this.tabPageRES.UseVisualStyleBackColor = true;
//            // 
//            // tvwSchemaRES
//            // 
//            this.tvwSchemaRES.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//                        | System.Windows.Forms.AnchorStyles.Left)
//                        | System.Windows.Forms.AnchorStyles.Right)));
//            this.tvwSchemaRES.Location = new System.Drawing.Point(4, 6);
//            this.tvwSchemaRES.Name = "tvwSchemaRES";
//            this.tvwSchemaRES.ShowNodeToolTips = true;
//            this.tvwSchemaRES.Size = new System.Drawing.Size(581, 190);
//            this.tvwSchemaRES.TabIndex = 15;
//            // 
//            // groupBox2
//            // 
//            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
//                        | System.Windows.Forms.AnchorStyles.Right)));
//            this.groupBox2.Controls.Add(this.lblResponce);
//            this.groupBox2.Controls.Add(this.txtResponce);
//            this.groupBox2.Controls.Add(this.lblRequest);
//            this.groupBox2.Controls.Add(this.txtRequest);
//            this.groupBox2.Controls.Add(this.lblServiceName);
//            this.groupBox2.Controls.Add(this.txtServiceName);
//            this.groupBox2.ForeColor = System.Drawing.SystemColors.Desktop;
//            this.groupBox2.Location = new System.Drawing.Point(6, 6);
//            this.groupBox2.Name = "groupBox2";
//            this.groupBox2.Size = new System.Drawing.Size(596, 106);
//            this.groupBox2.TabIndex = 37;
//            this.groupBox2.TabStop = false;
//            // 
//            // lblResponce
//            // 
//            this.lblResponce.AutoSize = true;
//            this.lblResponce.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.lblResponce.ForeColor = System.Drawing.SystemColors.Desktop;
//            this.lblResponce.Location = new System.Drawing.Point(7, 79);
//            this.lblResponce.Name = "lblResponce";
//            this.lblResponce.Size = new System.Drawing.Size(56, 13);
//            this.lblResponce.TabIndex = 7;
//            this.lblResponce.Text = "Responce";
//            // 
//            // txtResponce
//            // 
//            this.txtResponce.Enabled = false;
//            this.txtResponce.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.txtResponce.Location = new System.Drawing.Point(97, 76);
//            this.txtResponce.Name = "txtResponce";
//            this.txtResponce.Size = new System.Drawing.Size(473, 20);
//            this.txtResponce.TabIndex = 6;
//            // 
//            // lblRequest
//            // 
//            this.lblRequest.AutoSize = true;
//            this.lblRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.lblRequest.ForeColor = System.Drawing.SystemColors.Desktop;
//            this.lblRequest.Location = new System.Drawing.Point(7, 49);
//            this.lblRequest.Name = "lblRequest";
//            this.lblRequest.Size = new System.Drawing.Size(47, 13);
//            this.lblRequest.TabIndex = 3;
//            this.lblRequest.Text = "Request";
//            // 
//            // txtRequest
//            // 
//            this.txtRequest.Enabled = false;
//            this.txtRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.txtRequest.Location = new System.Drawing.Point(97, 46);
//            this.txtRequest.Name = "txtRequest";
//            this.txtRequest.Size = new System.Drawing.Size(473, 20);
//            this.txtRequest.TabIndex = 2;
//            // 
//            // lblServiceName
//            // 
//            this.lblServiceName.AutoSize = true;
//            this.lblServiceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
//            this.lblServiceName.ForeColor = System.Drawing.SystemColors.Desktop;
//            this.lblServiceName.Location = new System.Drawing.Point(6, 15);
//            this.lblServiceName.Name = "lblServiceName";
//            this.lblServiceName.Size = new System.Drawing.Size(72, 13);
//            this.lblServiceName.TabIndex = 1;
//            this.lblServiceName.Text = "Service name";
//            // 
//            // txtServiceName
//            // 
//            this.txtServiceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.txtServiceName.Location = new System.Drawing.Point(97, 12);
//            this.txtServiceName.Name = "txtServiceName";
//            this.txtServiceName.Size = new System.Drawing.Size(473, 20);
//            this.txtServiceName.TabIndex = 0;
//            this.txtServiceName.Leave += new System.EventHandler(this.txtServiceName_Leave);
//            this.txtServiceName.Validating += new System.ComponentModel.CancelEventHandler(this.txtServiceName_Validating);
//            // 
//            // tabPageCode
//            // 
//            this.tabPageCode.Controls.Add(this.textCodeEditor1);
//            this.tabPageCode.Location = new System.Drawing.Point(4, 22);
//            this.tabPageCode.Name = "tabPageCode";
//            this.tabPageCode.Padding = new System.Windows.Forms.Padding(3);
//            this.tabPageCode.Size = new System.Drawing.Size(664, 369);
//            this.tabPageCode.TabIndex = 1;
//            this.tabPageCode.Text = "Code";
//            this.tabPageCode.UseVisualStyleBackColor = true;
//            // 
//            // textCodeEditor1
//            // 
//            this.textCodeEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//                        | System.Windows.Forms.AnchorStyles.Left)
//                        | System.Windows.Forms.AnchorStyles.Right)));
//            this.textCodeEditor1.Location = new System.Drawing.Point(-18, 3);
//            this.textCodeEditor1.Name = "textCodeEditor1";
//            this.textCodeEditor1.Size = new System.Drawing.Size(676, 366);
//            this.textCodeEditor1.TabIndex = 36;
//            this.textCodeEditor1.TitleText = "";
//            this.textCodeEditor1.TitleVisible = false;
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
//            // errorProvider1
//            // 
//            this.errorProvider1.ContainerControl = this;
//            // 
//            // frm_ServicesGenerator
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = System.Drawing.Color.GhostWhite;
//            this.ClientSize = new System.Drawing.Size(953, 463);
//            this.Controls.Add(this.splitContainer1);
//            this.Controls.Add(this.toolStrip1);
//            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
//            this.Name = "frm_ServicesGenerator";
//            this.TabText = "Services :.";
//            this.Text = "Services ";
//            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ServicesGenerator_DragDrop);
//            this.toolStrip1.ResumeLayout(false);
//            this.toolStrip1.PerformLayout();
//            this.splitContainer1.Panel1.ResumeLayout(false);
//            this.splitContainer1.Panel2.ResumeLayout(false);
//            this.splitContainer1.ResumeLayout(false);
//            this.tabCtrlCodeParameters.ResumeLayout(false);
//            this.tabPageParams.ResumeLayout(false);
//            this.tabControlSchemas.ResumeLayout(false);
//            this.tabPageREQ.ResumeLayout(false);
//            this.tabPageRES.ResumeLayout(false);
//            this.groupBox2.ResumeLayout(false);
//            this.groupBox2.PerformLayout();
//            this.tabPageCode.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private System.Windows.Forms.ToolStrip toolStrip1;
//        private System.Windows.Forms.ToolStripButton btnRefresh;
//        private System.Windows.Forms.ToolStripTextBox txtSchemPath;
//        private System.Windows.Forms.ToolStripButton btnSearchSchema;
//        private System.Windows.Forms.ToolStripButton toolStripButtonGenerate;
//        private  ListViewCodeGenerated listViewCodeGenerated1;
//        private System.Windows.Forms.SplitContainer splitContainer1;
//        private System.Windows.Forms.TabControl tabCtrlCodeParameters;
//        private System.Windows.Forms.TabPage tabPageParams;
//        private System.Windows.Forms.GroupBox groupBox2;
//        private System.Windows.Forms.Label lblResponce;
//        private System.Windows.Forms.TextBox txtResponce;
//        private System.Windows.Forms.Label lblRequest;
//        private System.Windows.Forms.TextBox txtRequest;
//        private System.Windows.Forms.Label lblServiceName;
//        private System.Windows.Forms.TextBox txtServiceName;
//        private System.Windows.Forms.TabPage tabPageCode;
//        private Fwk.Controls.Win32.TextCodeEditor textCodeEditor1;
//        private System.Windows.Forms.ImageList imgImages;
//        private System.Windows.Forms.TabControl tabControlSchemas;
//        private System.Windows.Forms.TabPage tabPageREQ;
//        private XSDTreeView tvwSchemaREQ;
//        private System.Windows.Forms.TabPage tabPageRES;
//        private XSDTreeView tvwSchemaRES;
//        private System.Windows.Forms.ErrorProvider errorProvider1;

//    }
//}