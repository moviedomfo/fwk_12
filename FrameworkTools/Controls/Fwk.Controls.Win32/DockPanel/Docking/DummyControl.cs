using System;
using System.Windows.Forms;

namespace Fwk.Controls.Win32
{
	internal class DummyControl : Control
	{
		public DummyControl()
		{
			SetStyle(ControlStyles.Selectable, false);
		}
	}
}
