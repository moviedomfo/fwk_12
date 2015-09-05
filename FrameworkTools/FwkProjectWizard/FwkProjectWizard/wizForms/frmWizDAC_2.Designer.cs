namespace Fwk.Wizard
{
    partial class frmWizDAC_2
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
            this.wizTablesTreeSelector1 = new Fwk.Wizard.wizTablesTreeSelector();
            this.chkInsert = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSearchByParams = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkBatch = new System.Windows.Forms.CheckBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizTablesTreeSelector1
            // 
            this.wizTablesTreeSelector1.Button_Back_Visible = true;
            this.wizTablesTreeSelector1.Button_Cancel_Visible = true;
            this.wizTablesTreeSelector1.Button_Next_Visible = false;
            this.wizTablesTreeSelector1.Button_OK_Visible = true;
            this.wizTablesTreeSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizTablesTreeSelector1.Location = new System.Drawing.Point(0, 0);
            this.wizTablesTreeSelector1.Name = "wizTablesTreeSelector1";
            this.wizTablesTreeSelector1.Size = new System.Drawing.Size(734, 496);
            this.wizTablesTreeSelector1.TabIndex = 0;
            this.wizTablesTreeSelector1.Title = "Fwk DAC item";
            this.wizTablesTreeSelector1.OnWizardButtonClickEvent += new Fwk.Wizard.OnWizardButtonClickHandler(this.wizTablesTreeSelector1_OnWizardButtonClickEvent);
            // 
            // chkInsert
            // 
            this.chkInsert.AutoSize = true;
            this.chkInsert.Checked = true;
            this.chkInsert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInsert.Location = new System.Drawing.Point(29, 32);
            this.chkInsert.Name = "chkInsert";
            this.chkInsert.Size = new System.Drawing.Size(52, 17);
            this.chkInsert.TabIndex = 1;
            this.chkInsert.Text = "Insert";
            this.chkInsert.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkDelete);
            this.groupBox1.Controls.Add(this.chkSearchByParams);
            this.groupBox1.Controls.Add(this.chkUpdate);
            this.groupBox1.Controls.Add(this.chkBatch);
            this.groupBox1.Controls.Add(this.chkInsert);
            this.groupBox1.Location = new System.Drawing.Point(289, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 243);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Metodos a generar";
            // 
            // chkSearchByParams
            // 
            this.chkSearchByParams.AutoSize = true;
            this.chkSearchByParams.Checked = true;
            this.chkSearchByParams.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSearchByParams.Location = new System.Drawing.Point(29, 138);
            this.chkSearchByParams.Name = "chkSearchByParams";
            this.chkSearchByParams.Size = new System.Drawing.Size(111, 17);
            this.chkSearchByParams.TabIndex = 4;
            this.chkSearchByParams.Text = "Search by params";
            this.chkSearchByParams.UseVisualStyleBackColor = true;
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Checked = true;
            this.chkUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdate.Location = new System.Drawing.Point(29, 64);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(61, 17);
            this.chkUpdate.TabIndex = 3;
            this.chkUpdate.Text = "Ubdate";
            this.chkUpdate.UseVisualStyleBackColor = true;
            // 
            // chkBatch
            // 
            this.chkBatch.AutoSize = true;
            this.chkBatch.Checked = true;
            this.chkBatch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBatch.Location = new System.Drawing.Point(191, 32);
            this.chkBatch.Name = "chkBatch";
            this.chkBatch.Size = new System.Drawing.Size(100, 17);
            this.chkBatch.TabIndex = 2;
            this.chkBatch.Text = "Generate batch";
            this.chkBatch.UseVisualStyleBackColor = true;
            
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Checked = true;
            this.chkDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDelete.Location = new System.Drawing.Point(29, 101);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(57, 17);
            this.chkDelete.TabIndex = 5;
            this.chkDelete.Text = "Delete";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // frmWizDAC_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 496);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.wizTablesTreeSelector1);
            this.Name = "frmWizDAC_2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private wizTablesTreeSelector wizTablesTreeSelector1;
        private System.Windows.Forms.CheckBox chkInsert;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.CheckBox chkBatch;
        private System.Windows.Forms.CheckBox chkSearchByParams;
        private System.Windows.Forms.CheckBox chkDelete;

    }
}