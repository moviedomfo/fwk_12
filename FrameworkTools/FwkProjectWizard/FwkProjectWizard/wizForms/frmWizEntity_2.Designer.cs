namespace Fwk.Wizard
{
    partial class frmWizEntity_2
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
            this.lstCheckedTables = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // wizTablesTreeSelector1
            // 
            this.wizTablesTreeSelector1.Button_Back_Visible = true;
            this.wizTablesTreeSelector1.Button_Cancel_Visible = true;
            this.wizTablesTreeSelector1.Button_Next_Visible = false;
            this.wizTablesTreeSelector1.Button_OK_Visible = true;
            this.wizTablesTreeSelector1.CheckBoxes = true;
            this.wizTablesTreeSelector1.Location = new System.Drawing.Point(2, 2);
            this.wizTablesTreeSelector1.Name = "wizTablesTreeSelector1";
            this.wizTablesTreeSelector1.Size = new System.Drawing.Size(689, 489);
            this.wizTablesTreeSelector1.TabIndex = 0;
            this.wizTablesTreeSelector1.Title = "Seleccione la tabla";
            this.wizTablesTreeSelector1.OnWizardButtonClickEvent += new Fwk.Wizard.OnWizardButtonClickHandler(this.wizTablesTreeSelector1_OnWizardButtonClickEvent);
            // 
            // lstCheckedTables
            // 
            this.lstCheckedTables.FormattingEnabled = true;
            this.lstCheckedTables.Location = new System.Drawing.Point(368, 116);
            this.lstCheckedTables.Name = "lstCheckedTables";
            this.lstCheckedTables.Size = new System.Drawing.Size(216, 303);
            this.lstCheckedTables.TabIndex = 1;
            // 
            // frmWizEntity_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 503);
            this.Controls.Add(this.lstCheckedTables);
            this.Controls.Add(this.wizTablesTreeSelector1);
            this.Name = "frmWizEntity_2";
            this.Text = "frmWizEntity_2";
            this.ResumeLayout(false);

        }

        #endregion

        private Fwk.Wizard.wizTablesTreeSelector wizTablesTreeSelector1;
        private System.Windows.Forms.ListBox lstCheckedTables;
    }
}