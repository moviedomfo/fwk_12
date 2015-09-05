namespace Fwk.Wizard
{
    partial class wizTablesTreeSelector
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlTreeViewTables1 = new Fwk.Wizard.ctrlTreeViewTables();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(708, 75);
            this.lblTitle.Text = "Seleccione la tabla";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(590, 447);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(475, 447);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(399, 357);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(360, 447);
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ctrlTreeViewTables1
            // 
            this.ctrlTreeViewTables1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ctrlTreeViewTables1.CheckBoxes = true;
            this.ctrlTreeViewTables1.Location = new System.Drawing.Point(20, 97);
            this.ctrlTreeViewTables1.Name = "ctrlTreeViewTables1";
            this.ctrlTreeViewTables1.Size = new System.Drawing.Size(233, 335);
            this.ctrlTreeViewTables1.TabIndex = 69;
            this.ctrlTreeViewTables1.AfterCheckEvent += new Fwk.Wizard.AfterCheckHandler(this.ctrlTreeViewTables1_AfterCheckEvent);
            // 
            // wizTablesTreeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Button_Next_Visible = false;
            this.Controls.Add(this.ctrlTreeViewTables1);
            this.Name = "wizTablesTreeSelector";
            this.Size = new System.Drawing.Size(708, 474);
            this.Title = "Seleccione la tabla";
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnBack, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.ctrlTreeViewTables1, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlTreeViewTables ctrlTreeViewTables1;
    }
}
