namespace Fwk.Security.Admin.Controls
{
    partial class RulesAssingControl
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
            this.rolAssignedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rolBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userExcludedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtRuleExpression = new System.Windows.Forms.TextBox();
            this.btnCreateRule = new DevExpress.XtraEditors.SimpleButton();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRuleName = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.grdUserExcluded = new System.Windows.Forms.DataGridView();
            this.userNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdAllUser = new System.Windows.Forms.DataGridView();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbltitle = new System.Windows.Forms.Label();
            this.btnAsignarRoles = new System.Windows.Forms.Button();
            this.grdAssignedRoles = new System.Windows.Forms.DataGridView();
            this.rolNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeSelectedsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grdAllRoles = new System.Windows.Forms.DataGridView();
            this.rolNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolAssignedBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userExcludedBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserExcluded)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllUser)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAssignedRoles)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllRoles)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rolAssignedBindingSource
            // 
            this.rolAssignedBindingSource.DataSource = typeof(Fwk.Security.Common.Rol);
            // 
            // rolBindingSource
            // 
            this.rolBindingSource.DataSource = typeof(Fwk.Security.Common.Rol);
            // 
            // userExcludedBindingSource
            // 
            this.userExcludedBindingSource.DataSource = typeof(Fwk.Security.Common.User);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(Fwk.Security.Common.User);
            // 
            // txtRuleExpression
            // 
            this.txtRuleExpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRuleExpression.Location = new System.Drawing.Point(12, 645);
            this.txtRuleExpression.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRuleExpression.Multiline = true;
            this.txtRuleExpression.Name = "txtRuleExpression";
            this.txtRuleExpression.ReadOnly = true;
            this.txtRuleExpression.Size = new System.Drawing.Size(812, 64);
            this.txtRuleExpression.TabIndex = 20;
            // 
            // btnCreateRule
            // 
            this.btnCreateRule.Appearance.BackColor = System.Drawing.Color.White;
            this.btnCreateRule.Appearance.Options.UseBackColor = true;
            this.btnCreateRule.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnCreateRule.Image = global::Fwk.Security.Admin.Properties.Resources.save_16;
            this.btnCreateRule.Location = new System.Drawing.Point(482, 62);
            this.btnCreateRule.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreateRule.Name = "btnCreateRule";
            this.btnCreateRule.Size = new System.Drawing.Size(112, 28);
            this.btnCreateRule.TabIndex = 19;
            this.btnCreateRule.Text = "Save";
            this.btnCreateRule.Click += new System.EventHandler(this.btnCreateRule_Click);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(2, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(161, 20);
            this.label11.TabIndex = 17;
            this.label11.Text = "Enter the rule name";
            // 
            // txtRuleName
            // 
            this.txtRuleName.Location = new System.Drawing.Point(170, 62);
            this.txtRuleName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRuleName.Name = "txtRuleName";
            this.txtRuleName.Size = new System.Drawing.Size(221, 23);
            this.txtRuleName.TabIndex = 0;
            this.txtRuleName.Validating += new System.ComponentModel.CancelEventHandler(this.textRuleName_Validating);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.grdUserExcluded);
            this.tabPage3.Controls.Add(this.grdAllUser);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Size = new System.Drawing.Size(814, 486);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Excludes Users";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(808, 42);
            this.label2.TabIndex = 19;
            this.label2.Text = "Add excluded users";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Fwk.Security.Admin.Properties.Resources.impt_24;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(365, 164);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 39);
            this.button1.TabIndex = 18;
            this.button1.Text = "Exclude user";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grdUserExcluded
            // 
            this.grdUserExcluded.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdUserExcluded.AutoGenerateColumns = false;
            this.grdUserExcluded.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUserExcluded.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn1,
            this.appNameDataGridViewTextBoxColumn1});
            this.grdUserExcluded.DataSource = this.userExcludedBindingSource;
            this.grdUserExcluded.Location = new System.Drawing.Point(492, 49);
            this.grdUserExcluded.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdUserExcluded.Name = "grdUserExcluded";
            this.grdUserExcluded.ReadOnly = true;
            this.grdUserExcluded.RowTemplate.Height = 24;
            this.grdUserExcluded.Size = new System.Drawing.Size(295, 421);
            this.grdUserExcluded.TabIndex = 14;
            // 
            // userNameDataGridViewTextBoxColumn1
            // 
            this.userNameDataGridViewTextBoxColumn1.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn1.HeaderText = "UserName";
            this.userNameDataGridViewTextBoxColumn1.Name = "userNameDataGridViewTextBoxColumn1";
            this.userNameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // appNameDataGridViewTextBoxColumn1
            // 
            this.appNameDataGridViewTextBoxColumn1.DataPropertyName = "AppName";
            this.appNameDataGridViewTextBoxColumn1.HeaderText = "AppName";
            this.appNameDataGridViewTextBoxColumn1.Name = "appNameDataGridViewTextBoxColumn1";
            this.appNameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // grdAllUser
            // 
            this.grdAllUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdAllUser.AutoGenerateColumns = false;
            this.grdAllUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAllUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn,
            this.appNameDataGridViewTextBoxColumn});
            this.grdAllUser.DataSource = this.userBindingSource;
            this.grdAllUser.Location = new System.Drawing.Point(17, 49);
            this.grdAllUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdAllUser.Name = "grdAllUser";
            this.grdAllUser.ReadOnly = true;
            this.grdAllUser.RowTemplate.Height = 24;
            this.grdAllUser.Size = new System.Drawing.Size(341, 426);
            this.grdAllUser.TabIndex = 13;
            this.grdAllUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAllUser_CellClick);
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "UserName";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // appNameDataGridViewTextBoxColumn
            // 
            this.appNameDataGridViewTextBoxColumn.DataPropertyName = "AppName";
            this.appNameDataGridViewTextBoxColumn.HeaderText = "AppName";
            this.appNameDataGridViewTextBoxColumn.Name = "appNameDataGridViewTextBoxColumn";
            this.appNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbltitle);
            this.tabPage2.Controls.Add(this.btnAsignarRoles);
            this.tabPage2.Controls.Add(this.grdAssignedRoles);
            this.tabPage2.Controls.Add(this.grdAllRoles);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(814, 486);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Includes roles";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbltitle
            // 
            this.lbltitle.BackColor = System.Drawing.Color.White;
            this.lbltitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbltitle.Location = new System.Drawing.Point(3, 4);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(808, 42);
            this.lbltitle.TabIndex = 18;
            this.lbltitle.Text = "Add roles ";
            this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAsignarRoles
            // 
            this.btnAsignarRoles.BackColor = System.Drawing.Color.White;
            this.btnAsignarRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarRoles.Image = global::Fwk.Security.Admin.Properties.Resources.impt_24;
            this.btnAsignarRoles.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignarRoles.Location = new System.Drawing.Point(317, 165);
            this.btnAsignarRoles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAsignarRoles.Name = "btnAsignarRoles";
            this.btnAsignarRoles.Size = new System.Drawing.Size(104, 39);
            this.btnAsignarRoles.TabIndex = 17;
            this.btnAsignarRoles.Text = "Add Roles";
            this.btnAsignarRoles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignarRoles.UseVisualStyleBackColor = false;
            this.btnAsignarRoles.Click += new System.EventHandler(this.btnAddRol_Click);
            // 
            // grdAssignedRoles
            // 
            this.grdAssignedRoles.AllowUserToDeleteRows = false;
            this.grdAssignedRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdAssignedRoles.AutoGenerateColumns = false;
            this.grdAssignedRoles.BackgroundColor = System.Drawing.Color.White;
            this.grdAssignedRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdAssignedRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rolNameDataGridViewTextBoxColumn1});
            this.grdAssignedRoles.DataSource = this.rolAssignedBindingSource;
            this.grdAssignedRoles.Location = new System.Drawing.Point(440, 49);
            this.grdAssignedRoles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdAssignedRoles.Name = "grdAssignedRoles";
            this.grdAssignedRoles.ReadOnly = true;
            this.grdAssignedRoles.RowHeadersVisible = false;
            this.grdAssignedRoles.RowHeadersWidth = 250;
            this.grdAssignedRoles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdAssignedRoles.RowTemplate.ContextMenuStrip = this.contextMenuStrip1;
            this.grdAssignedRoles.RowTemplate.Height = 40;
            this.grdAssignedRoles.Size = new System.Drawing.Size(349, 410);
            this.grdAssignedRoles.TabIndex = 11;
            this.grdAssignedRoles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdAssignedRoles_MouseDown);
            // 
            // rolNameDataGridViewTextBoxColumn1
            // 
            this.rolNameDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.rolNameDataGridViewTextBoxColumn1.DataPropertyName = "RolName";
            this.rolNameDataGridViewTextBoxColumn1.HeaderText = "Assigned roles";
            this.rolNameDataGridViewTextBoxColumn1.Name = "rolNameDataGridViewTextBoxColumn1";
            this.rolNameDataGridViewTextBoxColumn1.ReadOnly = true;
            this.rolNameDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.rolNameDataGridViewTextBoxColumn1.Width = 118;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSelectedsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 26);
            // 
            // removeSelectedsToolStripMenuItem
            // 
            this.removeSelectedsToolStripMenuItem.Name = "removeSelectedsToolStripMenuItem";
            this.removeSelectedsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.removeSelectedsToolStripMenuItem.Text = "Remove selecteds";
            this.removeSelectedsToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedsToolStripMenuItem_Click);
            // 
            // grdAllRoles
            // 
            this.grdAllRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdAllRoles.AutoGenerateColumns = false;
            this.grdAllRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAllRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rolNameDataGridViewTextBoxColumn});
            this.grdAllRoles.DataSource = this.rolBindingSource;
            this.grdAllRoles.Location = new System.Drawing.Point(7, 49);
            this.grdAllRoles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdAllRoles.Name = "grdAllRoles";
            this.grdAllRoles.ReadOnly = true;
            this.grdAllRoles.RowTemplate.Height = 24;
            this.grdAllRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAllRoles.Size = new System.Drawing.Size(303, 410);
            this.grdAllRoles.TabIndex = 10;
            this.grdAllRoles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAllRoles_CellClick);
            
            // 
            // rolNameDataGridViewTextBoxColumn
            // 
            this.rolNameDataGridViewTextBoxColumn.DataPropertyName = "RolName";
            this.rolNameDataGridViewTextBoxColumn.HeaderText = "RolName";
            this.rolNameDataGridViewTextBoxColumn.Name = "rolNameDataGridViewTextBoxColumn";
            this.rolNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Location = new System.Drawing.Point(7, 95);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(822, 515);
            this.tabControl2.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(13, 619);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Expression";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(848, 42);
            this.label3.TabIndex = 22;
            this.label3.Text = "Create new bussiness rule";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RulesAssingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRuleExpression);
            this.Controls.Add(this.btnCreateRule);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.txtRuleName);
            this.Controls.Add(this.label11);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "RulesAssingControl";
            this.Size = new System.Drawing.Size(848, 716);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolAssignedBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userExcludedBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUserExcluded)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllUser)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAssignedRoles)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAllRoles)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRuleName;
        private System.Windows.Forms.BindingSource rolAssignedBindingSource;
        private System.Windows.Forms.BindingSource rolBindingSource;
        private System.Windows.Forms.BindingSource userExcludedBindingSource;
        private System.Windows.Forms.BindingSource userBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnCreateRule;
        private System.Windows.Forms.TextBox txtRuleExpression;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Button btnAsignarRoles;
        private System.Windows.Forms.DataGridView grdAssignedRoles;
        private System.Windows.Forms.DataGridView grdAllRoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView grdUserExcluded;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn appNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView grdAllUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn appNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedsToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolNameDataGridViewTextBoxColumn1;
    }
}
