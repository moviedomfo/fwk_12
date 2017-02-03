namespace Fwk.Logging.Test
{
    partial class frmLoggingTest
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
            this.components = new System.ComponentModel.Container();
            this.primitivesRemoveButton = new System.Windows.Forms.Button();
            this.btnCount = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.primitivesAddRandomButton = new System.Windows.Forms.Button();
            this.nudItemsCount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCacheMannagerSettingName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.primitivesResultsTextBox = new System.Windows.Forms.TextBox();
            this.primitivesFlushCacheButton = new System.Windows.Forms.Button();
            this.primitivesReadButton = new System.Windows.Forms.Button();
            this.primitivesAddButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnClearWarning = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnInfo = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNoStaticResult = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.viewFileButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.loadingResultsTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button10 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilePrefix = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.ExceptionView = new Fwk.Bases.FrontEnd.Controls.FwkExceptionViewComponent(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnAudit = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemsCount)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // primitivesRemoveButton
            // 
            this.primitivesRemoveButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.primitivesRemoveButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.primitivesRemoveButton.Location = new System.Drawing.Point(19, 235);
            this.primitivesRemoveButton.Name = "primitivesRemoveButton";
            this.primitivesRemoveButton.Size = new System.Drawing.Size(154, 37);
            this.primitivesRemoveButton.TabIndex = 2;
            this.primitivesRemoveButton.Text = "R&emove item from the cache";
            // 
            // btnCount
            // 
            this.btnCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCount.Location = new System.Drawing.Point(529, 3);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(154, 28);
            this.btnCount.TabIndex = 12;
            this.btnCount.Text = "Count";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.primitivesAddRandomButton);
            this.groupBox2.Controls.Add(this.nudItemsCount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(11, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 91);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Multiple";
            // 
            // primitivesAddRandomButton
            // 
            this.primitivesAddRandomButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.primitivesAddRandomButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.primitivesAddRandomButton.Location = new System.Drawing.Point(13, 19);
            this.primitivesAddRandomButton.Name = "primitivesAddRandomButton";
            this.primitivesAddRandomButton.Size = new System.Drawing.Size(154, 33);
            this.primitivesAddRandomButton.TabIndex = 10;
            this.primitivesAddRandomButton.Text = "Add multiple item to cache";
            // 
            // nudItemsCount
            // 
            this.nudItemsCount.Location = new System.Drawing.Point(59, 65);
            this.nudItemsCount.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudItemsCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudItemsCount.Name = "nudItemsCount";
            this.nudItemsCount.Size = new System.Drawing.Size(89, 20);
            this.nudItemsCount.TabIndex = 8;
            this.nudItemsCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudItemsCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(10, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Count";
            // 
            // cmbCacheMannagerSettingName
            // 
            this.cmbCacheMannagerSettingName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCacheMannagerSettingName.ItemHeight = 13;
            this.cmbCacheMannagerSettingName.Items.AddRange(new object[] {
            "CacheManager_Sales",
            "CacheManager_Clients",
            "CacheManager_Products",
            "CacheManager_Default"});
            this.cmbCacheMannagerSettingName.Location = new System.Drawing.Point(24, 343);
            this.cmbCacheMannagerSettingName.Name = "cmbCacheMannagerSettingName";
            this.cmbCacheMannagerSettingName.Size = new System.Drawing.Size(170, 21);
            this.cmbCacheMannagerSettingName.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(21, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Select cache setting";
            // 
            // label3
            // 
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(11, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(672, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Los elementos con los que trabaja el ejemplo son del tipo ClienteCollectionBE()";
            // 
            // primitivesResultsTextBox
            // 
            this.primitivesResultsTextBox.Location = new System.Drawing.Point(205, 40);
            this.primitivesResultsTextBox.Multiline = true;
            this.primitivesResultsTextBox.Name = "primitivesResultsTextBox";
            this.primitivesResultsTextBox.ReadOnly = true;
            this.primitivesResultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.primitivesResultsTextBox.Size = new System.Drawing.Size(494, 320);
            this.primitivesResultsTextBox.TabIndex = 4;
            // 
            // primitivesFlushCacheButton
            // 
            this.primitivesFlushCacheButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.primitivesFlushCacheButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.primitivesFlushCacheButton.Location = new System.Drawing.Point(19, 282);
            this.primitivesFlushCacheButton.Name = "primitivesFlushCacheButton";
            this.primitivesFlushCacheButton.Size = new System.Drawing.Size(154, 36);
            this.primitivesFlushCacheButton.TabIndex = 3;
            this.primitivesFlushCacheButton.Text = "&Flush the cache";
            // 
            // primitivesReadButton
            // 
            this.primitivesReadButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.primitivesReadButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.primitivesReadButton.Location = new System.Drawing.Point(19, 190);
            this.primitivesReadButton.Name = "primitivesReadButton";
            this.primitivesReadButton.Size = new System.Drawing.Size(154, 39);
            this.primitivesReadButton.TabIndex = 1;
            this.primitivesReadButton.Text = "&Read item from cache";
            // 
            // primitivesAddButton
            // 
            this.primitivesAddButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.primitivesAddButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.primitivesAddButton.Location = new System.Drawing.Point(19, 40);
            this.primitivesAddButton.Name = "primitivesAddButton";
            this.primitivesAddButton.Size = new System.Drawing.Size(154, 31);
            this.primitivesAddButton.TabIndex = 0;
            this.primitivesAddButton.Text = "&Add item to cache";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.logoPictureBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(857, 83);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label2.ForeColor = System.Drawing.Color.SlateGray;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(19, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(355, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fwk Loggin";
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.logoPictureBox.Location = new System.Drawing.Point(614, 25);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(69, 50);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.ItemSize = new System.Drawing.Size(98, 24);
            this.tabControl1.Location = new System.Drawing.Point(4, 100);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(826, 620);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnClearWarning);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.btnInfo);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtNoStaticResult);
            this.tabPage1.Controls.Add(this.button8);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(818, 588);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "No Static use";
            // 
            // btnClearWarning
            // 
            this.btnClearWarning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearWarning.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClearWarning.Location = new System.Drawing.Point(283, 66);
            this.btnClearWarning.Name = "btnClearWarning";
            this.btnClearWarning.Size = new System.Drawing.Size(65, 25);
            this.btnClearWarning.TabIndex = 19;
            this.btnClearWarning.Text = "Remove";
            this.btnClearWarning.Click += new System.EventHandler(this.btnClearWarning_Click);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(584, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 20);
            this.label12.TabIndex = 17;
            this.label12.Text = "_Log.Information (...)";
            // 
            // btnInfo
            // 
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInfo.Location = new System.Drawing.Point(462, 60);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(100, 31);
            this.btnInfo.TabIndex = 15;
            this.btnInfo.Text = "Information";
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(174, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 20);
            this.label10.TabIndex = 14;
            this.label10.Text = "_Log.Audit (...)";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(174, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "_Log.Warning (...)";
            // 
            // txtNoStaticResult
            // 
            this.txtNoStaticResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoStaticResult.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtNoStaticResult.Location = new System.Drawing.Point(16, 145);
            this.txtNoStaticResult.Multiline = true;
            this.txtNoStaticResult.Name = "txtNoStaticResult";
            this.txtNoStaticResult.ReadOnly = true;
            this.txtNoStaticResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNoStaticResult.Size = new System.Drawing.Size(786, 440);
            this.txtNoStaticResult.TabIndex = 12;
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button8.Location = new System.Drawing.Point(283, 97);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(86, 25);
            this.button8.TabIndex = 11;
            this.button8.Text = "Open Log";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button7.Location = new System.Drawing.Point(283, 37);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(65, 25);
            this.button7.TabIndex = 10;
            this.button7.Text = "Open Log";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button5.Location = new System.Drawing.Point(14, 97);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(154, 30);
            this.button5.TabIndex = 1;
            this.button5.Text = "Audit";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button6.Location = new System.Drawing.Point(16, 34);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(154, 31);
            this.button6.TabIndex = 0;
            this.button6.Text = "Warning";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(11, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(397, 131);
            this.label7.TabIndex = 5;
            this.label7.Text = "TargetType = XmlTarget";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(439, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(363, 131);
            this.label11.TabIndex = 18;
            this.label11.Text = "TargetType = DatabseTarget";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.viewFileButton);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.loadingResultsTextBox);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(818, 588);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "No static  use Error Log";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(4, 161);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 32);
            this.button2.TabIndex = 9;
            this.button2.Text = "Open Log";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(4, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 37);
            this.button1.TabIndex = 8;
            this.button1.Text = "Error";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // viewFileButton
            // 
            this.viewFileButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.viewFileButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.viewFileButton.Location = new System.Drawing.Point(16, 332);
            this.viewFileButton.Name = "viewFileButton";
            this.viewFileButton.Size = new System.Drawing.Size(154, 25);
            this.viewFileButton.TabIndex = 6;
            this.viewFileButton.Text = "&Edit master data";
            // 
            // label8
            // 
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(10, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(672, 31);
            this.label8.TabIndex = 1;
            this.label8.Text = "Reactive caching retrieves data from the master source when the application reque" +
    "sts it,  and retains it in the cache for future requests.";
            // 
            // loadingResultsTextBox
            // 
            this.loadingResultsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingResultsTextBox.Location = new System.Drawing.Point(192, 104);
            this.loadingResultsTextBox.Multiline = true;
            this.loadingResultsTextBox.Name = "loadingResultsTextBox";
            this.loadingResultsTextBox.ReadOnly = true;
            this.loadingResultsTextBox.Size = new System.Drawing.Size(678, 209);
            this.loadingResultsTextBox.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(10, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(672, 39);
            this.label9.TabIndex = 0;
            this.label9.Text = "Proactive caching retrieves all of the required state from the master source, usu" +
    "ally when the application starts, and retains it in the cache for the lifetime o" +
    "f that application.";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button10);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.txtFilePrefix);
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Controls.Add(this.button9);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(818, 588);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Static Loguer";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button10.Location = new System.Drawing.Point(506, 54);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(154, 31);
            this.button10.TabIndex = 16;
            this.button10.Text = "Warning (No config)";
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "FilePrefix";
            // 
            // txtFilePrefix
            // 
            this.txtFilePrefix.Location = new System.Drawing.Point(135, 12);
            this.txtFilePrefix.Name = "txtFilePrefix";
            this.txtFilePrefix.Size = new System.Drawing.Size(208, 20);
            this.txtFilePrefix.TabIndex = 14;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(16, 150);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(857, 227);
            this.textBox2.TabIndex = 13;
            // 
            // button9
            // 
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button9.Location = new System.Drawing.Point(213, 54);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(130, 25);
            this.button9.TabIndex = 11;
            this.button9.Text = "Open Log (AppSetting)";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button4.Location = new System.Drawing.Point(16, 101);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(154, 31);
            this.button4.TabIndex = 2;
            this.button4.Text = "Clear logs";
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button3.Location = new System.Drawing.Point(16, 51);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(154, 31);
            this.button3.TabIndex = 1;
            this.button3.Text = "Warning (AppSetting)";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ExceptionView
            // 
            this.ExceptionView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ExceptionView.TextMessageColor = System.Drawing.Color.White;
            this.ExceptionView.TextMessageForeColorColor = System.Drawing.SystemColors.WindowText;
            this.ExceptionView.Title = "FrmTechnicalMsg";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnAudit);
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(818, 588);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnAudit
            // 
            this.btnAudit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAudit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAudit.Location = new System.Drawing.Point(332, 279);
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Size = new System.Drawing.Size(154, 31);
            this.btnAudit.TabIndex = 2;
            this.btnAudit.Text = "Audit";
            this.btnAudit.Click += new System.EventHandler(this.btnAudit_Click);
            // 
            // frmLoggingTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 727);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmLoggingTest";
            this.Text = "Test";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudItemsCount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button primitivesRemoveButton;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button primitivesAddRandomButton;
        private System.Windows.Forms.NumericUpDown nudItemsCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCacheMannagerSettingName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox primitivesResultsTextBox;
        private System.Windows.Forms.Button primitivesFlushCacheButton;
        private System.Windows.Forms.Button primitivesReadButton;
        private System.Windows.Forms.Button primitivesAddButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button viewFileButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox loadingResultsTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox txtNoStaticResult;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilePrefix;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private Fwk.Bases.FrontEnd.Controls.FwkExceptionViewComponent ExceptionView;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnClearWarning;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnAudit;
    }
}

