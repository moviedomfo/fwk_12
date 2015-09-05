namespace Fwk.Security.Cryptography.Test
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoCifrado = new System.Windows.Forms.TextBox();
            this.btnDEncrypt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCifrado = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.txtValorOriginal = new System.Windows.Forms.TextBox();
            this.btnKey = new System.Windows.Forms.Button();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Valor inicial";
            // 
            // txtNoCifrado
            // 
            this.txtNoCifrado.AcceptsReturn = true;
            this.txtNoCifrado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoCifrado.Location = new System.Drawing.Point(40, 296);
            this.txtNoCifrado.Multiline = true;
            this.txtNoCifrado.Name = "txtNoCifrado";
            this.txtNoCifrado.Size = new System.Drawing.Size(652, 94);
            this.txtNoCifrado.TabIndex = 12;
            // 
            // btnDEncrypt
            // 
            this.btnDEncrypt.Location = new System.Drawing.Point(237, 406);
            this.btnDEncrypt.Name = "btnDEncrypt";
            this.btnDEncrypt.Size = new System.Drawing.Size(81, 38);
            this.btnDEncrypt.TabIndex = 11;
            this.btnDEncrypt.Text = "Desencriptar";
            this.btnDEncrypt.UseVisualStyleBackColor = true;
            this.btnDEncrypt.Click += new System.EventHandler(this.btnDEncrypt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Valor encriptado";
            // 
            // txtCifrado
            // 
            this.txtCifrado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCifrado.Location = new System.Drawing.Point(40, 179);
            this.txtCifrado.Multiline = true;
            this.txtCifrado.Name = "txtCifrado";
            this.txtCifrado.Size = new System.Drawing.Size(652, 95);
            this.txtCifrado.TabIndex = 9;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(63, 406);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(81, 38);
            this.btnEncrypt.TabIndex = 8;
            this.btnEncrypt.Text = "Encriptar";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // txtValorOriginal
            // 
            this.txtValorOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValorOriginal.Location = new System.Drawing.Point(40, 73);
            this.txtValorOriginal.Multiline = true;
            this.txtValorOriginal.Name = "txtValorOriginal";
            this.txtValorOriginal.Size = new System.Drawing.Size(652, 57);
            this.txtValorOriginal.TabIndex = 14;
            // 
            // btnKey
            // 
            this.btnKey.Location = new System.Drawing.Point(116, 13);
            this.btnKey.Name = "btnKey";
            this.btnKey.Size = new System.Drawing.Size(169, 22);
            this.btnKey.TabIndex = 15;
            this.btnKey.Text = "Create key file";
            this.btnKey.UseVisualStyleBackColor = true;
            this.btnKey.Click += new System.EventHandler(this.btnKey_Click);
            // 
            // txtReference
            // 
            this.txtReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReference.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtReference.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.txtReference.Location = new System.Drawing.Point(40, 37);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(565, 20);
            this.txtReference.TabIndex = 16;
            this.txtReference.Text = "c:\\allus_key.key";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Kye file";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 477);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKey);
            this.Controls.Add(this.txtValorOriginal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNoCifrado);
            this.Controls.Add(this.btnDEncrypt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCifrado);
            this.Controls.Add(this.btnEncrypt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNoCifrado;
        private System.Windows.Forms.Button btnDEncrypt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCifrado;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.TextBox txtValorOriginal;
        private System.Windows.Forms.Button btnKey;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

