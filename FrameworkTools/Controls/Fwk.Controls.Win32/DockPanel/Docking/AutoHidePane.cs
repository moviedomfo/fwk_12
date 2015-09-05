
using System;
using System.Drawing;

namespace Fwk.Controls.Win32 {
  /// <include file='CodeDoc/AutoHidePane.xml' path='//CodeDoc/Class[@name="AutoHidePane"]/ClassDef/*'/>
  public class AutoHidePane : IDisposable {
    private DockPane m_dockPane;

    /// <include file='CodeDoc/AutoHidePane.xml' path='//CodeDoc/Class[@name="AutoHidePane"]/Construct[@name="(DockPane)"]/*'/>
    public AutoHidePane(DockPane pane) {
      m_dockPane = pane;
      m_tabs = new AutoHideTabCollection(DockPane);
    }

    /// <exclude/>
    ~AutoHidePane() {
      Dispose(false);
    }

    /// <include file='CodeDoc/AutoHidePane.xml' path='//CodeDoc/Class[@name="AutoHidePane"]/Property[@name="DockPane"]/*'/>
    public DockPane DockPane {
      get { return m_dockPane; }
    }

    private AutoHideTabCollection m_tabs;
    /// <include file='CodeDoc/AutoHidePane.xml' path='//CodeDoc/Class[@name="AutoHidePane"]/Property[@name="Tabs"]/*'/>
    public AutoHideTabCollection Tabs {
      get { return m_tabs; }
    }

    /// <include file='CodeDoc/AutoHidePane.xml' path='//CodeDoc/Class[@name="AutoHidePane"]/Method[@name="Dispose"]/*'/>
    /// <include file='CodeDoc/AutoHidePane.xml' path='//CodeDoc/Class[@name="AutoHidePane"]/Method[@name="Dispose()"]/*'/>
    public void Dispose() {
      Dispose(true);
    }

    /// <include file='CodeDoc/AutoHidePane.xml' path='//CodeDoc/Class[@name="AutoHidePane"]/Method[@name="Dispose(bool)"]/*'/>
    protected virtual void Dispose(bool disposing) {
    }
  }
}
