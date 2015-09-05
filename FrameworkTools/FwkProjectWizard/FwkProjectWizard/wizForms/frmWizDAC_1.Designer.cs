namespace Fwk.Wizard
{
    partial class frmWizDAC_1
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
            Fwk.Wizard.CnnString cnnString1 = new Fwk.Wizard.CnnString();
            this.wizDBSelect1 = new Fwk.Wizard.wizDBSelect();
            this.SuspendLayout();
            // 
            // wizDBSelect1
            // 
            this.wizDBSelect1.Button_Back_Visible = false;
            this.wizDBSelect1.Button_Cancel_Visible = true;
            this.wizDBSelect1.Button_Next_Visible = true;
            this.wizDBSelect1.Button_OK_Visible = false;
            cnnString1.DataSource = "";
            cnnString1.InitialCatalog = "";
            cnnString1.Name = "Server: DB: ";
            cnnString1.Password = null;
            cnnString1.User = null;
            cnnString1.WindowsAutentification = false;
            this.wizDBSelect1.Cnn = cnnString1;
            this.wizDBSelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizDBSelect1.Location = new System.Drawing.Point(0, 0);
            this.wizDBSelect1.Name = "wizDBSelect1";
            this.wizDBSelect1.Size = new System.Drawing.Size(734, 496);
            this.wizDBSelect1.TabIndex = 0;
            this.wizDBSelect1.Title = "Fwk DAC item";
            this.wizDBSelect1.OnWizardButtonClickEvent += new Fwk.Wizard.OnWizardButtonClickHandler(this.wizDBSelect1_OnWizardButtonClickEvent);
            // 
            // frmWizDAC_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 496);
            this.Controls.Add(this.wizDBSelect1);
            this.Name = "frmWizDAC_1";
            
            this.ResumeLayout(false);

        }

        #endregion

        private wizDBSelect wizDBSelect1;
    }
}