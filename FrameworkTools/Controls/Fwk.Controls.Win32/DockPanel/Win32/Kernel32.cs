

using System;
using System.Drawing;
using System.Runtime.InteropServices;


namespace Fwk.Controls.Win32
{
    internal class Kernel32
    {
		[DllImport("Kernel32.dll", CharSet=CharSet.Auto)]
		public static extern int GetCurrentThreadId();
	}
}