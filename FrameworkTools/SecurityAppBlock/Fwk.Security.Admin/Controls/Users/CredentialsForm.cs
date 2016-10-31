
//===============================================================================

using System;
using System.Drawing;
using System.Collections;

using System.Windows.Forms;
using Fwk.Security;
using Fwk.Security.Admin;

namespace SecurityAppBlock.Use
{
	/// <summary>
	/// Used to create new users and authenticate existing ones.
	/// </summary>
    public partial class CredentialsForm : System.Windows.Forms.Form
	{
	

		public CredentialsForm()
		{
			InitializeComponent();
		}


		

		/// <summary>
		/// Entered user name
		/// </summary>
		public string Username
		{
			get { return this.usernameTextBox.Text; }
		}

		/// <summary>
		/// Entered user password
		/// </summary>
		public string Password
		{
			get { return this.passwordTextBox.Text; }
		}

		/// <summary>
		/// Accepts user input
		/// </summary>
		/// <param name="sender">Event sender</param>
		/// <param name="e">Event arguments</param>
        private void okButton_Click(object sender, System.EventArgs e)
        {

          

            try
            {

                if (FwkMembership.ValidateUser(this.usernameTextBox.Text, this.passwordTextBox.Text, frmAdmin.Provider.Name))
                {
                    MessageBox.Show("User authenticated");
                 
                }
                else
                {
                    MessageBox.Show("Contraseña de usuario anterior no válida");
                }

            }
            catch (Exception ex)
            {
              
                MessageBox.Show(ex.Message);


            }

        }

		/// <summary>
		/// Discards user input
		/// </summary>
		/// <param name="sender">Event sender</param>
		/// <param name="e">Event arguments</param>
		private void cancelButton_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		
	}
}
