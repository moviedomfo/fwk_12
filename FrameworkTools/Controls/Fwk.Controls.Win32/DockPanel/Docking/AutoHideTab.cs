
using System;
using System.Drawing;

namespace Fwk.Controls.Win32
{
	/// <include file='CodeDoc/AutoHideTab.xml' path='//CodeDoc/Class[@name="AutoHideTab"]/ClassDef/*'/>
	public class AutoHideTab : IDisposable
	{
		private IDockContent m_content;

		/// <include file='CodeDoc/AutoHideTab.xml' path='//CodeDoc/Class[@name="AutoHideTab"]/Construct[@name="(IDockContent)"]/*'/>
		public AutoHideTab(IDockContent content)
		{
			m_content = content;
		}

		/// <exclude/>
		~AutoHideTab()
		{
			Dispose(false);
		}

		/// <include file='CodeDoc/AutoHideTab.xml' path='//CodeDoc/Class[@name="AutoHideTab"]/Property[@name="Content"]/*'/>
		public IDockContent Content
		{
			get	{	return m_content;	}
		}

		/// <include file='CodeDoc/AutoHideTab.xml' path='//CodeDoc/Class[@name="AutoHideTab"]/Method[@name="Dispose"]/*'/>
		/// <include file='CodeDoc/AutoHideTab.xml' path='//CodeDoc/Class[@name="AutoHideTab"]/Method[@name="Dispose()"]/*'/>
		public void Dispose()
		{
			Dispose(true);
		}

		/// <include file='CodeDoc/AutoHideTab.xml' path='//CodeDoc/Class[@name="AutoHideTab"]/Method[@name="Dispose(bool)"]/*'/>
		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
