namespace MailAgentTest
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnAuth = new System.Windows.Forms.Button();
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.fwkMailAgent1 = new Fwk.Mail.FwkMailAgent(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(444, 31);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 1;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 132);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(597, 238);
            this.listBox1.TabIndex = 2;
            // 
            // btnAuth
            // 
            this.btnAuth.Location = new System.Drawing.Point(525, 31);
            this.btnAuth.Name = "btnAuth";
            this.btnAuth.Size = new System.Drawing.Size(84, 23);
            this.btnAuth.TabIndex = 3;
            this.btnAuth.Text = "Authentication";
            this.btnAuth.UseVisualStyleBackColor = true;
            this.btnAuth.Click += new System.EventHandler(this.btnAuth_Click);
            // 
            // fwkMailAgent1
            // 
            this.fwkMailAgent1.Provider = null;
            this.fwkMailAgent1.LoginResponse += new System.EventHandler<Fwk.Mail.LoginEventArgs>(this.fwkMailAgent1_LoginResponse);
            this.fwkMailAgent1.RequireAuthentication += new System.EventHandler<System.EventArgs>(this.fwkMailAgent1_RequireAuthentication);
            this.fwkMailAgent1.NewReceivedMail += new System.EventHandler<Fwk.Mail.NewReceivedMailEventArgs>(this.fwkMailAgent1_NewReceivedMail);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 392);
            this.Controls.Add(this.btnAuth);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnAuth;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private Fwk.Mail.FwkMailAgent fwkMailAgent1;
    }
}

