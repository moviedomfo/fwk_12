using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.AvalonEdit;
using AvalonEdit.Sample;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using System.IO;
using System.Xml;
using System.Reflection;

namespace Fwk.Controls.Win32.TextCodeEditor
{
    public partial class TextCodeEditor : UserControl
    {
        public TextCodeEditor()
        {
           
          
            this.InitializeComponent();

            
           
        }

        public void HostControl()
        {
            this.textCodeEditorHost1.HostControl();
        }

        [DesignOnly(false), Browsable(true), Category("Text Control"), Description("Texto enriqucido del control text code editor.-")]
        public override string Text
        {
            get
            {
                return textCodeEditorHost1.Text;
                //this.textEditor.Refresh();
                //return this.textEditor.Document.TextBufferStrategy.GetText(0, this.textEditor.Document.TextLength);
            }
            set
            {
                //this.textEditor.Refresh();
                this.textCodeEditorHost1.Text = value;
                //textEditor.Load(currentFileName);
              
            }
        }
 

 



        [Browsable(true), Category("Propertie"),
        Description("Titulo del text code editor"),
        Bindable(true)]
        public string TitleText
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }


        [Bindable(true), Category("Text Control"), Description("Determina si se muestra el titulo del control"), Browsable(true)]
        public bool TitleVisible
        {
            get
            {
                return this.lblTitle.Visible;
            }
            set
            {
                int x = 0;
                int y = 0x10;
                if (value)
                {
                    y = 0x10;
                }
                else
                {
                    y = 0;
                }
                Point point = new Point(x, y);
                this.textCodeEditorHost1.Location = point;
                this.lblTitle.Visible = value;
            }
        }
 








  

    }
}
