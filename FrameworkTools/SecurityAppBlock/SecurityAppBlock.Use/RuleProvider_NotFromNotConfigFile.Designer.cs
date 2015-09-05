namespace SecurityAppBlock.Use
{
    partial class RuleProvider_NotFromNotConfigFile
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.authorizationResultsTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.authorizeUsingIdentityRoleRulesButton = new System.Windows.Forms.Button();
            this.identityTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rulesComboBox = new System.Windows.Forms.ComboBox();
            this.fwkMessageViewInfo = new Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent(this.components);
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(26, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Enter user name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // authorizationResultsTextBox
            // 
            this.authorizationResultsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.authorizationResultsTextBox.Location = new System.Drawing.Point(12, 176);
            this.authorizationResultsTextBox.Multiline = true;
            this.authorizationResultsTextBox.Name = "authorizationResultsTextBox";
            this.authorizationResultsTextBox.ReadOnly = true;
            this.authorizationResultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.authorizationResultsTextBox.Size = new System.Drawing.Size(596, 215);
            this.authorizationResultsTextBox.TabIndex = 47;
            this.authorizationResultsTextBox.TabStop = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(40, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 38);
            this.label7.TabIndex = 46;
            this.label7.Text = "Determine if user is authorized to perform a task";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // authorizeUsingIdentityRoleRulesButton
            // 
            this.authorizeUsingIdentityRoleRulesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.authorizeUsingIdentityRoleRulesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.authorizeUsingIdentityRoleRulesButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.authorizeUsingIdentityRoleRulesButton.Location = new System.Drawing.Point(208, 107);
            this.authorizeUsingIdentityRoleRulesButton.Name = "authorizeUsingIdentityRoleRulesButton";
            this.authorizeUsingIdentityRoleRulesButton.Size = new System.Drawing.Size(79, 24);
            this.authorizeUsingIdentityRoleRulesButton.TabIndex = 45;
            this.authorizeUsingIdentityRoleRulesButton.Text = "Check";
            this.authorizeUsingIdentityRoleRulesButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.authorizeUsingIdentityRoleRulesButton.Click += new System.EventHandler(this.authorizeUsingIdentityRoleRulesButton_Click);
            // 
            // identityTextBox
            // 
            this.identityTextBox.Location = new System.Drawing.Point(29, 35);
            this.identityTextBox.Name = "identityTextBox";
            this.identityTextBox.Size = new System.Drawing.Size(168, 20);
            this.identityTextBox.TabIndex = 44;
            this.identityTextBox.Text = "moviedo";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(342, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Enter the rule to be used to check authorization";
            // 
            // label4
            // 
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(342, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Rule";
            // 
            // rulesComboBox
            // 
            this.rulesComboBox.DisplayMember = "Name";
            this.rulesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rulesComboBox.ItemHeight = 13;
            this.rulesComboBox.Location = new System.Drawing.Point(386, 35);
            this.rulesComboBox.Name = "rulesComboBox";
            this.rulesComboBox.Size = new System.Drawing.Size(216, 21);
            this.rulesComboBox.TabIndex = 43;
            this.rulesComboBox.ValueMember = "Expression";
            // 
            // fwkMessageViewInfo
            // 
            this.fwkMessageViewInfo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.fwkMessageViewInfo.IconSize = Fwk.Bases.FrontEnd.Controls.IconSize.Small;
            this.fwkMessageViewInfo.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.fwkMessageViewInfo.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Information;
            this.fwkMessageViewInfo.TextMessageColor = System.Drawing.Color.White;
            this.fwkMessageViewInfo.TextMessageForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.fwkMessageViewInfo.Title = "Security admin";
            // 
            // RuleProvider_NotFromNotConfigFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 403);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.authorizationResultsTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.authorizeUsingIdentityRoleRulesButton);
            this.Controls.Add(this.identityTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rulesComboBox);
            this.Name = "RuleProvider_NotFromNotConfigFile";
            this.Text = "RuleProvider_NotFromNotConfigFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox authorizationResultsTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button authorizeUsingIdentityRoleRulesButton;
        private System.Windows.Forms.TextBox identityTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox rulesComboBox;
        private Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent fwkMessageViewInfo;
    }
}