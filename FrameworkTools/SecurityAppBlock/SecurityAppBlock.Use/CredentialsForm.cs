//===============================================================================
// Microsoft patterns & practices Enterprise Library
// Security Application Block QuickStart
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.Drawing;
using System.Collections;

using System.Windows.Forms;

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
			if (this.usernameTextBox.Text.CompareTo("")==0 ||
				this.passwordTextBox.Text.CompareTo("")==0)
			{
				MessageBox.Show("Please enter a user name and a password",
					"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
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

		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated (e);

			this.usernameTextBox.Clear();
			this.passwordTextBox.Clear();

			this.usernameTextBox.Focus();
		}
	}
}
