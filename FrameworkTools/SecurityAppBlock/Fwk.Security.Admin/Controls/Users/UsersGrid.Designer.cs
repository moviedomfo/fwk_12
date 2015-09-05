namespace Fwk.Security.Admin
{
    partial class UsersGrid
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
            this.components = new System.ComponentModel.Container();
            this.userByAppBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastActivityDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsLockedOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsApproved = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userByAppBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // userByAppBindingSource
            // 
            this.userByAppBindingSource.DataSource = typeof(Fwk.Security.Common.User);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.userByAppBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(7, 34);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(785, 511);
            this.gridControl1.TabIndex = 20;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserName,
            this.colFirstName,
            this.colLastName,
            this.colLastActivityDate,
            this.colIsLockedOut,
            this.colIsApproved});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowVertLines = false;
            this.gridView1.RowHeight = 30;
            this.gridView1.RowSeparatorHeight = 1;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // colUserName
            // 
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.OptionsColumn.AllowEdit = false;
            this.colUserName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colUserName.OptionsColumn.AllowMove = false;
            this.colUserName.OptionsColumn.ReadOnly = true;
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 0;
            this.colUserName.Width = 127;
            // 
            // colFirstName
            // 
            this.colFirstName.FieldName = "FirstName";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.OptionsColumn.AllowEdit = false;
            this.colFirstName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colFirstName.OptionsColumn.AllowMove = false;
            this.colFirstName.OptionsColumn.ReadOnly = true;
            this.colFirstName.Visible = true;
            this.colFirstName.VisibleIndex = 1;
            this.colFirstName.Width = 127;
            // 
            // colLastName
            // 
            this.colLastName.FieldName = "LastName";
            this.colLastName.Name = "colLastName";
            this.colLastName.OptionsColumn.AllowEdit = false;
            this.colLastName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colLastName.OptionsColumn.AllowMove = false;
            this.colLastName.OptionsColumn.ReadOnly = true;
            this.colLastName.Visible = true;
            this.colLastName.VisibleIndex = 2;
            this.colLastName.Width = 127;
            // 
            // colLastActivityDate
            // 
            this.colLastActivityDate.FieldName = "LastActivityDate";
            this.colLastActivityDate.Name = "colLastActivityDate";
            this.colLastActivityDate.OptionsColumn.AllowEdit = false;
            this.colLastActivityDate.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colLastActivityDate.OptionsColumn.AllowMove = false;
            this.colLastActivityDate.OptionsColumn.ReadOnly = true;
            this.colLastActivityDate.Visible = true;
            this.colLastActivityDate.VisibleIndex = 5;
            this.colLastActivityDate.Width = 180;
            // 
            // colIsLockedOut
            // 
            this.colIsLockedOut.FieldName = "IsLockedOut";
            this.colIsLockedOut.Name = "colIsLockedOut";
            this.colIsLockedOut.OptionsColumn.AllowEdit = false;
            this.colIsLockedOut.OptionsColumn.ReadOnly = true;
            this.colIsLockedOut.Visible = true;
            this.colIsLockedOut.VisibleIndex = 3;
            this.colIsLockedOut.Width = 127;
            // 
            // colIsApproved
            // 
            this.colIsApproved.FieldName = "IsApproved";
            this.colIsApproved.Name = "colIsApproved";
            this.colIsApproved.OptionsColumn.AllowEdit = false;
            this.colIsApproved.OptionsColumn.ReadOnly = true;
            this.colIsApproved.Visible = true;
            this.colIsApproved.VisibleIndex = 4;
            this.colIsApproved.Width = 79;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Image = global::Fwk.Security.Admin.Properties.Resources.Users;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(4, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 28);
            this.label9.TabIndex = 18;
            this.label9.Text = "Users";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UsersGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.label9);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "UsersGrid";
            this.Size = new System.Drawing.Size(814, 548);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userByAppBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource userByAppBindingSource;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastActivityDate;
        private DevExpress.XtraGrid.Columns.GridColumn colIsLockedOut;
        private DevExpress.XtraGrid.Columns.GridColumn colIsApproved;
        private System.Windows.Forms.Label label9;
    }
}
