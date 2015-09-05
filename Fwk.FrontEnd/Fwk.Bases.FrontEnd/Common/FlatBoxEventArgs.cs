using System;
using System.Drawing;

	/// <summary>
	/// Información del evento que se dispara 
	/// cuando cambia el color del borde o el foco
	/// </summary>
	public class FlatBoxEventArgs : EventArgs
	{
		public readonly Color BorderColor;
		public readonly bool GotFocus;

		public FlatBoxEventArgs(Color BorderColor, bool GotFocus)
		{
			this.BorderColor = BorderColor;
			this.GotFocus = GotFocus;
		}
	}
