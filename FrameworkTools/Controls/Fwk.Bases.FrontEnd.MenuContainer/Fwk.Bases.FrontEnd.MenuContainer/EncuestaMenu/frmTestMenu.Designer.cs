namespace Fwk.Bases.FrontEnd.MenuContainer.EncuestaMenu
{
    partial class frmTestMenu
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.treeListMenuControl1 = new Fwk.Bases.FrontEnd.MenuContainer.EncuestaMenu.TreeListMenuControl();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(427, 40);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(113, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "View selected ";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // treeListMenuControl1
            // 
            this.treeListMenuControl1.DisplayTextCaption = "";
            this.treeListMenuControl1.Location = new System.Drawing.Point(13, 30);
            this.treeListMenuControl1.MenuItemEncuestaList = null;
            this.treeListMenuControl1.MenuItemSelected = null;
            this.treeListMenuControl1.Name = "treeListMenuControl1";
            this.treeListMenuControl1.Size = new System.Drawing.Size(313, 445);
            this.treeListMenuControl1.TabIndex = 2;
            this.treeListMenuControl1.TypeImageCaption = "Imagen";
            this.treeListMenuControl1.MenuItemClick += new Fwk.Bases.FrontEnd.MenuContainer.EncuestaMenu.MenuItemClickHandler(this.treeListMenuControl1_MenuItemClick);
            // 
            // frmTestMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 569);
            this.Controls.Add(this.treeListMenuControl1);
            this.Controls.Add(this.simpleButton1);
            this.Name = "frmTestMenu";
            this.Text = "frmTestMenu";
            this.ResumeLayout(false);

        }

        #endregion


        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private TreeListMenuControl treeListMenuControl1;
    }
}