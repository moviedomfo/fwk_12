namespace Fwk.Bases.Test
{
    partial class frmEntitiesTest
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
            this.btnCrarCLienteBE = new System.Windows.Forms.Button();
            this.txtEntidadSimple = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.txtCollection = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button11 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.txtServiceConfigurationName = new System.Windows.Forms.TextBox();
            this.lblServiceName = new System.Windows.Forms.Label();
            this.btnDeSerializeServiceConfiguration = new System.Windows.Forms.Button();
            this.btnDeserializeServiceConfigurationManager = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.button12 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCrarCLienteBE
            // 
            this.btnCrarCLienteBE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCrarCLienteBE.Location = new System.Drawing.Point(6, 6);
            this.btnCrarCLienteBE.Name = "btnCrarCLienteBE";
            this.btnCrarCLienteBE.Size = new System.Drawing.Size(195, 22);
            this.btnCrarCLienteBE.TabIndex = 0;
            this.btnCrarCLienteBE.Text = "Llenar y usar .GetXml()";
            this.btnCrarCLienteBE.UseVisualStyleBackColor = false;
            this.btnCrarCLienteBE.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtEntidadSimple
            // 
            this.txtEntidadSimple.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtEntidadSimple.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtEntidadSimple.Location = new System.Drawing.Point(11, 239);
            this.txtEntidadSimple.Multiline = true;
            this.txtEntidadSimple.Name = "txtEntidadSimple";
            this.txtEntidadSimple.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEntidadSimple.Size = new System.Drawing.Size(334, 202);
            this.txtEntidadSimple.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 21);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ver Cliente BE (DataSet)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(223, 21);
            this.button2.TabIndex = 4;
            this.button2.Text = "Request.GetXML()";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 446);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(734, 142);
            this.dataGridView1.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(207, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(266, 21);
            this.button3.TabIndex = 6;
            this.button3.Text = "Deserialize con helper.SerializationFunctions";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtCollection
            // 
            this.txtCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCollection.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtCollection.Location = new System.Drawing.Point(351, 239);
            this.txtCollection.Multiline = true;
            this.txtCollection.Name = "txtCollection";
            this.txtCollection.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCollection.Size = new System.Drawing.Size(413, 202);
            this.txtCollection.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(348, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "XML de la Collection";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "XML de Simple Entity";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(251, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(157, 21);
            this.button4.TabIndex = 10;
            this.button4.Text = " Request.SetRequestXml()";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 33);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(157, 21);
            this.button5.TabIndex = 11;
            this.button5.Text = "&Deserialize  Request";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(11, 61);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(753, 147);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button11);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.btnCrarCLienteBE);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(745, 121);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Entidades";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(6, 88);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(195, 21);
            this.button11.TabIndex = 8;
            this.button11.Text = "Find Entidad From Collection";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 61);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(195, 21);
            this.button6.TabIndex = 7;
            this.button6.Text = "Get Entidad FromXM ";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button12);
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Controls.Add(this.button7);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(745, 121);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Servicios";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(16, 80);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(157, 21);
            this.button8.TabIndex = 13;
            this.button8.Text = "Call Web Service";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(251, 33);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(157, 21);
            this.button7.TabIndex = 12;
            this.button7.Text = "&Serialize  Request";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button10);
            this.tabPage3.Controls.Add(this.button9);
            this.tabPage3.Controls.Add(this.txtServiceConfigurationName);
            this.tabPage3.Controls.Add(this.lblServiceName);
            this.tabPage3.Controls.Add(this.btnDeSerializeServiceConfiguration);
            this.tabPage3.Controls.Add(this.btnDeserializeServiceConfigurationManager);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(745, 121);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ServiceConfigurationManager";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(314, 66);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(154, 21);
            this.button10.TabIndex = 18;
            this.button10.Text = "Set ServiceConfiguration";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(314, 6);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(157, 21);
            this.button9.TabIndex = 17;
            this.button9.Text = "Get ServiceConfiguration";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click_1);
            // 
            // txtServiceConfigurationName
            // 
            this.txtServiceConfigurationName.Location = new System.Drawing.Point(391, 34);
            this.txtServiceConfigurationName.Name = "txtServiceConfigurationName";
            this.txtServiceConfigurationName.Size = new System.Drawing.Size(211, 20);
            this.txtServiceConfigurationName.TabIndex = 16;
            this.txtServiceConfigurationName.Text = "BuscarSpotPlanilladosPorAuditorService";
            // 
            // lblServiceName
            // 
            this.lblServiceName.AutoSize = true;
            this.lblServiceName.Location = new System.Drawing.Point(311, 37);
            this.lblServiceName.Name = "lblServiceName";
            this.lblServiceName.Size = new System.Drawing.Size(74, 13);
            this.lblServiceName.TabIndex = 15;
            this.lblServiceName.Text = "Service Name";
            // 
            // btnDeSerializeServiceConfiguration
            // 
            this.btnDeSerializeServiceConfiguration.Location = new System.Drawing.Point(6, 33);
            this.btnDeSerializeServiceConfiguration.Name = "btnDeSerializeServiceConfiguration";
            this.btnDeSerializeServiceConfiguration.Size = new System.Drawing.Size(266, 21);
            this.btnDeSerializeServiceConfiguration.TabIndex = 14;
            this.btnDeSerializeServiceConfiguration.Text = "DeSerialize ServiceConfiguration";
            this.btnDeSerializeServiceConfiguration.UseVisualStyleBackColor = true;
            this.btnDeSerializeServiceConfiguration.Click += new System.EventHandler(this.btnDeSerializeServiceConfiguration_Click);
            // 
            // btnDeserializeServiceConfigurationManager
            // 
            this.btnDeserializeServiceConfigurationManager.Location = new System.Drawing.Point(6, 6);
            this.btnDeserializeServiceConfigurationManager.Name = "btnDeserializeServiceConfigurationManager";
            this.btnDeserializeServiceConfigurationManager.Size = new System.Drawing.Size(266, 21);
            this.btnDeserializeServiceConfigurationManager.TabIndex = 13;
            this.btnDeserializeServiceConfigurationManager.Text = "Serialize ServiceConfiguration";
            this.btnDeserializeServiceConfigurationManager.UseVisualStyleBackColor = true;
            this.btnDeserializeServiceConfigurationManager.Click += new System.EventHandler(this.btnDeserializeServiceConfigurationManager_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.logoPictureBox);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(767, 217);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label3.ForeColor = System.Drawing.Color.SlateGray;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(582, 36);
            this.label3.TabIndex = 1;
            this.label3.Text = "Fwk Bases ";
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.logoPictureBox.Location = new System.Drawing.Point(686, 9);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(69, 50);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(475, 6);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(223, 21);
            this.button12.TabIndex = 14;
            this.button12.Text = "RES.GetXML()";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // frmEntitiesTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 604);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCollection);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtEntidadSimple);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmEntitiesTest";
            this.Text = "Entities test";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrarCLienteBE;
        private System.Windows.Forms.TextBox txtEntidadSimple;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtCollection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button btnDeserializeServiceConfigurationManager;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnDeSerializeServiceConfiguration;
        private System.Windows.Forms.Label lblServiceName;
        private System.Windows.Forms.TextBox txtServiceConfigurationName;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Button button12;
    }
}

