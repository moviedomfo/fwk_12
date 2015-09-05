namespace Fwk.DataBase.CustomControls
{
    partial class ConnectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionForm));
            this.cnnDataBaseForm1 = new Fwk.DataBase.CustomControls.CnnDataBaseForm();
            this.SuspendLayout();
            // 
            // cnnDataBaseForm1
            // 
            this.cnnDataBaseForm1.BackColor = System.Drawing.Color.White;
            this.cnnDataBaseForm1.ButtonsBackColor = System.Drawing.Color.White;
            this.cnnDataBaseForm1.ButtonsFlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cnnDataBaseForm1.ButtonsFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cnnDataBaseForm1.ButtonsForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cnnDataBaseForm1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cnnDataBaseForm1.LabelsForeColor = System.Drawing.Color.ForestGreen;
            this.cnnDataBaseForm1.Location = new System.Drawing.Point(-1, -1);
            this.cnnDataBaseForm1.Name = "cnnDataBaseForm1";
            this.cnnDataBaseForm1.Size = new System.Drawing.Size(375, 197);
            this.cnnDataBaseForm1.TabIndex = 0;
            this.cnnDataBaseForm1.TestBottonVisible = true;
            this.cnnDataBaseForm1.Load += new System.EventHandler(this.cnnDataBaseForm1_Load);
            this.cnnDataBaseForm1.AceptEvent += new Fwk.DataBase.CustomControls.AceptHandler(this.cnnDataBaseForm1_AceptEvent);
            this.cnnDataBaseForm1.CancelEvent += new Fwk.DataBase.CustomControls.CancelHandler(this.cnnDataBaseForm1_CancelEvent);
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(380, 186);
            this.Controls.Add(this.cnnDataBaseForm1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(388, 220);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(388, 220);
            this.Name = "ConnectionForm";
            this.Text = "Connection";
            this.ResumeLayout(false);

        }

        #endregion

        public CnnDataBaseForm cnnDataBaseForm1;


    }
}