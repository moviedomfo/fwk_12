namespace Fwk.Wizard
{
    partial class frmWizService
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
            this.ctrlNewService1 = new Fwk.Wizard.ctrlNewService();
            this.SuspendLayout();
            // 
            // ctrlNewService1
            // 
            this.ctrlNewService1.Button_Back_Visible = false;
            this.ctrlNewService1.Button_Cancel_Visible = true;
            this.ctrlNewService1.Button_Next_Visible = false;
            this.ctrlNewService1.Button_OK_Visible = true;
            this.ctrlNewService1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlNewService1.IsvcCode = null;
            this.ctrlNewService1.Location = new System.Drawing.Point(0, 0);
            this.ctrlNewService1.Name = "ctrlNewService1";
            
            this.ctrlNewService1.ServiceName = "";
            this.ctrlNewService1.Size = new System.Drawing.Size(734, 496);
            this.ctrlNewService1.SvcCode = null;
            this.ctrlNewService1.TabIndex = 0;
            this.ctrlNewService1.Title = "Nuevo servicio SVC";
            this.ctrlNewService1.OnWizardButtonClickEvent += new Fwk.Wizard.OnWizardButtonClickHandler(this.ctrlNewService1_OnWizardButtonClickEvent);
            // 
            // frmWizService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 496);
            this.Controls.Add(this.ctrlNewService1);
            this.Name = "frmWizService";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlNewService ctrlNewService1;





    }
}