using System;
namespace TestDataBases
{
    partial class Form2
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
            this.treeViewTables1 = new Fwk.DataBase.CustomControls.TreeViewTables();
            this.SuspendLayout();
            // 
            // treeViewTables1
            // 
            this.treeViewTables1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.treeViewTables1.Location = new System.Drawing.Point(61, 34);
            this.treeViewTables1.Name = "treeViewTables1";
            this.treeViewTables1.SelectedTable = null;
            this.treeViewTables1.SelectedTableName = String.Empty;
            this.treeViewTables1.Size = new System.Drawing.Size(458, 404);
            this.treeViewTables1.TabIndex = 0;
            this.treeViewTables1.Tablas = null;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 467);
            this.Controls.Add(this.treeViewTables1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private Fwk.DataBase.CustomControls.TreeViewTables treeViewTables1;
    }
}