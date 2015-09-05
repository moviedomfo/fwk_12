namespace Fwk.Security.Admin.Controls
{
    partial class RulesCheckControl
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
            this.authorizationResultsTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.authorizeUsingIdentityRoleRulesButton = new System.Windows.Forms.Button();
            this.identityTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rulesComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fwkMessageViewInfo = new Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // authorizationResultsTextBox
            // 
            this.authorizationResultsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.authorizationResultsTextBox.Location = new System.Drawing.Point(0, 143);
            this.authorizationResultsTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.authorizationResultsTextBox.Multiline = true;
            this.authorizationResultsTextBox.Name = "authorizationResultsTextBox";
            this.authorizationResultsTextBox.ReadOnly = true;
            this.authorizationResultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.authorizationResultsTextBox.Size = new System.Drawing.Size(695, 381);
            this.authorizationResultsTextBox.TabIndex = 39;
            this.authorizationResultsTextBox.TabStop = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(21, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 65);
            this.label7.TabIndex = 38;
            this.label7.Text = "Determine if user is authorized to perform a task";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // authorizeUsingIdentityRoleRulesButton
            // 
            this.authorizeUsingIdentityRoleRulesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.authorizeUsingIdentityRoleRulesButton.Image = global::Fwk.Security.Admin.Properties.Resources.Button_ok;
            this.authorizeUsingIdentityRoleRulesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.authorizeUsingIdentityRoleRulesButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.authorizeUsingIdentityRoleRulesButton.Location = new System.Drawing.Point(238, 103);
            this.authorizeUsingIdentityRoleRulesButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.authorizeUsingIdentityRoleRulesButton.Name = "authorizeUsingIdentityRoleRulesButton";
            this.authorizeUsingIdentityRoleRulesButton.Size = new System.Drawing.Size(92, 32);
            this.authorizeUsingIdentityRoleRulesButton.TabIndex = 37;
            this.authorizeUsingIdentityRoleRulesButton.Text = "Check";
            this.authorizeUsingIdentityRoleRulesButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.authorizeUsingIdentityRoleRulesButton.Click += new System.EventHandler(this.authorizeUsingIdentityRoleRulesButton_Click);
            // 
            // identityTextBox
            // 
            this.identityTextBox.Location = new System.Drawing.Point(20, 43);
            this.identityTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.identityTextBox.Name = "identityTextBox";
            this.identityTextBox.Size = new System.Drawing.Size(195, 23);
            this.identityTextBox.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(385, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(303, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Enter the rule to be used to check authorization";
            // 
            // label4
            // 
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(385, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 32;
            this.label4.Text = "Rule";
            // 
            // rulesComboBox
            // 
            this.rulesComboBox.DisplayMember = "Name";
            this.rulesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rulesComboBox.ItemHeight = 16;
            this.rulesComboBox.Location = new System.Drawing.Point(436, 43);
            this.rulesComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rulesComboBox.Name = "rulesComboBox";
            this.rulesComboBox.Size = new System.Drawing.Size(251, 24);
            this.rulesComboBox.TabIndex = 33;
            this.rulesComboBox.ValueMember = "Expression";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = global::Fwk.Security.Admin.Properties.Resources.User;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(16, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 28);
            this.label2.TabIndex = 40;
            this.label2.Text = "Enter user name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // RulesCheckControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.authorizationResultsTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.authorizeUsingIdentityRoleRulesButton);
            this.Controls.Add(this.identityTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rulesComboBox);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "RulesCheckControl";
            this.Size = new System.Drawing.Size(701, 554);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox authorizationResultsTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button authorizeUsingIdentityRoleRulesButton;
        private System.Windows.Forms.TextBox identityTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox rulesComboBox;
        private System.Windows.Forms.Label label2;
        private Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent fwkMessageViewInfo;
    }
}
