

using System;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace Fwk.Controls.Win32
{
	internal class ResourceHelper
	{
		private static ResourceManager m_resourceManager;

		static ResourceHelper()
		{
			m_resourceManager = new ResourceManager("Fwk.Controls.Win32.Strings", typeof(DockPanel).Assembly);
		}
	
		public static Bitmap LoadBitmap(string name)
		{
			Assembly assembly = typeof(ResourceHelper).Assembly;
			string fullNamePrefix = "Fwk.Controls.Win32.Resources.";
			return new Bitmap(assembly.GetManifestResourceStream(fullNamePrefix + name));
		}

		public static string GetString(string name)
		{
			return m_resourceManager.GetString(name);
		}
	}
}
