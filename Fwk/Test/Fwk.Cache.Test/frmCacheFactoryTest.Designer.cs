namespace Fwk.Cache.Test
{
    partial class frmCacheFactoryTest
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCacheMannagerSettingName = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.primitivesRemoveButton = new System.Windows.Forms.Button();
            this.btnCount = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.primitivesAddRandomButton = new System.Windows.Forms.Button();
            this.nudItemsCount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.primitivesResultsTextBox = new System.Windows.Forms.TextBox();
            this.primitivesFlushCacheButton = new System.Windows.Forms.Button();
            this.primitivesReadButton = new System.Windows.Forms.Button();
            this.primitivesAddButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.viewFileButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.proactiveButton = new System.Windows.Forms.Button();
            this.flushCacheButton = new System.Windows.Forms.Button();
            this.reactiveButton = new System.Windows.Forms.Button();
            this.loadingResultsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.btnGetFromCache = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbTimeMessure = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemsCount)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.logoPictureBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbCacheMannagerSettingName);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(745, 83);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label2.ForeColor = System.Drawing.Color.SlateGray;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(19, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(355, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fwk Cache Factory";
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.logoPictureBox.Location = new System.Drawing.Point(614, 18);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(69, 50);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            // 
            // label5
            // 
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(377, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Select cache setting";
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
            this.cmbCacheMannagerSettingName.Location = new System.Drawing.Point(380, 43);
            this.cmbCacheMannagerSettingName.Name = "cmbCacheMannagerSettingName";
            this.cmbCacheMannagerSettingName.Size = new System.Drawing.Size(170, 21);
            this.cmbCacheMannagerSettingName.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.ItemSize = new System.Drawing.Size(98, 24);
            this.tabControl1.Location = new System.Drawing.Point(6, 92);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(739, 422);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.primitivesRemoveButton);
            this.tabPage1.Controls.Add(this.btnCount);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.primitivesResultsTextBox);
            this.tabPage1.Controls.Add(this.primitivesFlushCacheButton);
            this.tabPage1.Controls.Add(this.primitivesReadButton);
            this.tabPage1.Controls.Add(this.primitivesAddButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(731, 390);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Caching Operations";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.primitivesRemoveButton.Click += new System.EventHandler(this.primitivesRemoveButton_Click);
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
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
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
            this.primitivesAddRandomButton.Click += new System.EventHandler(this.primitivesAddRandomButton_Click);
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
            this.primitivesFlushCacheButton.Click += new System.EventHandler(this.primitivesFlushCacheButton_Click);
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
            this.primitivesReadButton.Click += new System.EventHandler(this.primitivesReadButton_Click);
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
            this.primitivesAddButton.Click += new System.EventHandler(this.primitivesAddButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.viewFileButton);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.proactiveButton);
            this.tabPage2.Controls.Add(this.flushCacheButton);
            this.tabPage2.Controls.Add(this.reactiveButton);
            this.tabPage2.Controls.Add(this.loadingResultsTextBox);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(731, 390);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Loading the Cache";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // viewFileButton
            // 
            this.viewFileButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.viewFileButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.viewFileButton.Location = new System.Drawing.Point(512, 336);
            this.viewFileButton.Name = "viewFileButton";
            this.viewFileButton.Size = new System.Drawing.Size(154, 46);
            this.viewFileButton.TabIndex = 6;
            this.viewFileButton.Text = "&Edit master data";
            this.viewFileButton.Click += new System.EventHandler(this.viewFileButton_Click);
            // 
            // label4
            // 
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(10, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(672, 31);
            this.label4.TabIndex = 1;
            this.label4.Text = "Reactive caching retrieves data from the master source when the application reque" +
                "sts it,  and retains it in the cache for future requests.";
            // 
            // proactiveButton
            // 
            this.proactiveButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.proactiveButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.proactiveButton.Location = new System.Drawing.Point(24, 111);
            this.proactiveButton.Name = "proactiveButton";
            this.proactiveButton.Size = new System.Drawing.Size(154, 46);
            this.proactiveButton.TabIndex = 2;
            this.proactiveButton.Text = "&Proactively load cache";
            // 
            // flushCacheButton
            // 
            this.flushCacheButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.flushCacheButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.flushCacheButton.Location = new System.Drawing.Point(24, 222);
            this.flushCacheButton.Name = "flushCacheButton";
            this.flushCacheButton.Size = new System.Drawing.Size(154, 46);
            this.flushCacheButton.TabIndex = 4;
            this.flushCacheButton.Text = "&Flush Cache";
            // 
            // reactiveButton
            // 
            this.reactiveButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.reactiveButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.reactiveButton.Location = new System.Drawing.Point(24, 166);
            this.reactiveButton.Name = "reactiveButton";
            this.reactiveButton.Size = new System.Drawing.Size(154, 46);
            this.reactiveButton.TabIndex = 3;
            this.reactiveButton.Text = "&Reactively load data";
            // 
            // loadingResultsTextBox
            // 
            this.loadingResultsTextBox.Location = new System.Drawing.Point(192, 104);
            this.loadingResultsTextBox.Multiline = true;
            this.loadingResultsTextBox.Name = "loadingResultsTextBox";
            this.loadingResultsTextBox.ReadOnly = true;
            this.loadingResultsTextBox.Size = new System.Drawing.Size(480, 216);
            this.loadingResultsTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(672, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proactive caching retrieves all of the required state from the master source, usu" +
                "ally when the application starts, and retains it in the cache for the lifetime o" +
                "f that application.";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.btnGetFromCache);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.cmbTimeMessure);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.numericUpDown1);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(731, 390);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Expitration tieme";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(14, 283);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 31);
            this.button2.TabIndex = 15;
            this.button2.Text = "Remove item to cache";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnGetFromCache
            // 
            this.btnGetFromCache.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGetFromCache.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGetFromCache.Location = new System.Drawing.Point(14, 231);
            this.btnGetFromCache.Name = "btnGetFromCache";
            this.btnGetFromCache.Size = new System.Drawing.Size(154, 31);
            this.btnGetFromCache.TabIndex = 14;
            this.btnGetFromCache.Text = "Get item to cache";
            this.btnGetFromCache.Click += new System.EventHandler(this.btnGetFromCache_Click);
            // 
            // label8
            // 
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(11, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "Expiration time";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(220, 35);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(494, 168);
            this.textBox1.TabIndex = 12;
            // 
            // cmbTimeMessure
            // 
            this.cmbTimeMessure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimeMessure.ItemHeight = 13;
            this.cmbTimeMessure.Items.AddRange(new object[] {
            "FromDays",
            "FromHours",
            "FromMinutes",
            "FromSeconds"});
            this.cmbTimeMessure.Location = new System.Drawing.Point(14, 133);
            this.cmbTimeMessure.Name = "cmbTimeMessure";
            this.cmbTimeMessure.Size = new System.Drawing.Size(170, 21);
            this.cmbTimeMessure.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(11, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Time messure";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(14, 80);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(89, 20);
            this.numericUpDown1.TabIndex = 11;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(14, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "&Add item to cache";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button6);
            this.tabPage4.Controls.Add(this.button5);
            this.tabPage4.Controls.Add(this.textBox2);
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Controls.Add(this.button3);
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(731, 390);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Services";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(210, 32);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(494, 320);
            this.textBox2.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button4.Location = new System.Drawing.Point(14, 125);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(177, 31);
            this.button4.TabIndex = 2;
            this.button4.Text = "Get cache data from service";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button3.Location = new System.Drawing.Point(14, 78);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(154, 31);
            this.button3.TabIndex = 1;
            this.button3.Text = "Execute service";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button5.Location = new System.Drawing.Point(14, 277);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(154, 31);
            this.button5.TabIndex = 6;
            this.button5.Text = "&Add item to cache";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button6.Location = new System.Drawing.Point(14, 314);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(177, 31);
            this.button6.TabIndex = 7;
            this.button6.Text = "Get cache";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // frmCacheFactoryTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 526);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCacheFactoryTest";
            this.Text = "Test Fwk.HelperFunctions.Cache";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudItemsCount)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button primitivesRemoveButton;
        private System.Windows.Forms.TextBox primitivesResultsTextBox;
        private System.Windows.Forms.Button primitivesFlushCacheButton;
        private System.Windows.Forms.Button primitivesReadButton;
        private System.Windows.Forms.Button primitivesAddButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button viewFileButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button proactiveButton;
        private System.Windows.Forms.Button flushCacheButton;
        private System.Windows.Forms.Button reactiveButton;
        private System.Windows.Forms.TextBox loadingResultsTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCacheMannagerSettingName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudItemsCount;
        private System.Windows.Forms.Button primitivesAddRandomButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbTimeMessure;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnGetFromCache;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}

