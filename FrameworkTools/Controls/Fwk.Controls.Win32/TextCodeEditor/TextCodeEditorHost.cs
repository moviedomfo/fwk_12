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
using System.Windows.Forms.Integration;
//using CSharpBinding.FormattingStrategy;
//using ICSharpCode.TextEditor.Document;

namespace Fwk.Controls.Win32.TextCodeEditor
{
    public partial class TextCodeEditorHost : UserControl
    {
        private ElementHost host;
        public TextCodeEditorHost()
        {
            IHighlightingDefinition customHighlighting;
            System.Reflection.Assembly _assembly = Assembly.GetExecutingAssembly();
            using (Stream s = _assembly.GetManifestResourceStream("Fwk.Controls.Win32.CustomHighlighting.xshd"))
            {
                if (s == null)
                    throw new InvalidOperationException("Could not find embedded resource");
                using (XmlReader reader = new XmlTextReader(s))
                {
                    customHighlighting = ICSharpCode. AvalonEdit.Highlighting.Xshd.
                        HighlightingLoader.Load(reader, HighlightingManager.Instance);
                }
            }
            // and register it in the HighlightingManager
            HighlightingManager.Instance.RegisterHighlighting("Custom Highlighting", new string[] { ".cool" }, customHighlighting);
          
            this.InitializeComponent();
            
            host = new System.Windows.Forms.Integration.ElementHost();
            this.host.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(this.host);
            this.textEditor = new ICSharpCode.AvalonEdit.TextEditor();
        
            this.Controls.Add(this.host);
            this.host.Child = this.textEditor;

            textEditor.FontFamily = new System.Windows.Media.FontFamily("Consolas");
            textEditor.FontSize = 12.75f;
            
            textEditor.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.CSharp.CSharpIndentationStrategy(textEditor.Options);
   
            this.IndentLines();


            Set_CSharpMode();
          
        }

        public void HostControl()
        {
          
             this.host.Dock = System.Windows.Forms.DockStyle.Fill;
            
     
            
           
            this.Controls.Add(this.host);
            this.host.Child = this.textEditor;
           
        }
        private void Set_CSharpMode()
        {
            string dir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"xshd\");


            if (File.Exists(dir + "CSharp-Mode.xshd"))
            {
                Stream xshd_stream = File.OpenRead(dir + "CSharp-Mode.xshd");
                XmlTextReader xshd_reader = new XmlTextReader(xshd_stream);
                // Apply the new syntax highlighting definition.
                textEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.Xshd.HighlightingLoader.Load(xshd_reader, ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance);
                xshd_reader.Close();
                xshd_stream.Close();
            }
 
        }
        #region --[PROPIEDADES]--

        // <summary>
        /// Supported Languages.
        /// </summary>
        public enum TipoLenguaje
        {

            CSHARP = 2,
            C64CHARP = 3,
            CPP = 4,
            HTML = 5,
            JAVA = 6,
            JAVASCRIPT = 7,

            Text = 9,
            VBNET = 10,
            VBSCRIPT = 11,
            XML = 12
        }


        private TipoLenguaje m_Lenguaje = TipoLenguaje.C64CHARP;

        [DesignOnly(false), Browsable(true), Category("Text Control"), Description("Texto enriqucido del control text code editor.-")]
        public override string Text
        {
            get
            {
                return textEditor.Document.Text;
                //this.textEditor.Refresh();
                //return this.textEditor.Document.TextBufferStrategy.GetText(0, this.textEditor.Document.TextLength);
            }
            set
            {
                //this.textEditor.Refresh();
                this.textEditor.Document.Text = value;
                //textEditor.Load(currentFileName);
                this.IndentLines();
            }
        }
 

 




 






        #endregion

        #region --[METODOS]--


        private void IndentLines()
        {
            foldingStrategy = new BraceFoldingStrategy();
            if (foldingStrategy != null)
            {
                if (foldingManager == null)
                    foldingManager = FoldingManager.Install(textEditor.TextArea);
                foldingStrategy.UpdateFoldings(foldingManager, textEditor.Document);
            }
            else
            {
                if (foldingManager != null)
                {
                    FoldingManager.Uninstall(foldingManager);
                    foldingManager = null;
                }
            }
        }
        #endregion

  

    }
}
