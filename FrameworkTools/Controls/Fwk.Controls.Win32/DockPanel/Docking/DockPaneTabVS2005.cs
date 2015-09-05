// *****************************************************************************
// 
//  Copyright 2004, Weifen Luo
//  All rights reserved. The software and associated documentation 
//  supplied hereunder are the proprietary information of Weifen Luo
//  and are supplied subject to licence terms.
// 
//  WinFormsUI Library Version 1.0
//  
//  Updated by Carlos A. Leguizam�n
//  Update Introducing a VS2005 VisualStyles.
//  Update Date: 12-02-2007
// *****************************************************************************
using System;
using System.Drawing;

namespace Fwk.Controls.Win32 {
  internal class DockPaneTabVS2005 : DockPaneTab {
    internal DockPaneTabVS2005(IDockContent content)
      : base(content) {
    }

    private int m_tabX;
    protected internal int TabX {
      get { return m_tabX; }
      set { m_tabX = value; }
    }

    private int m_tabWidth;
    protected internal int TabWidth {
      get { return m_tabWidth; }
      set { m_tabWidth = value; }
    }

    private int m_maxWidth;
    protected internal int MaxWidth {
      get { return m_maxWidth; }
      set { m_maxWidth = value; }
    }

    private bool m_flag;
    protected internal bool Flag {
      get { return m_flag; }
      set { m_flag = value; }
    }
  }
}
