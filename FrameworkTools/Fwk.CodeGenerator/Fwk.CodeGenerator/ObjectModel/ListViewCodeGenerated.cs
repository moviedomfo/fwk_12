using System;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Fwk.HelperFunctions;


namespace Fwk.CodeGenerator
{

    public delegate void StoredProcedureCodeGeneratedSelectHandler(String pTextCode,String pEntityName,String pParentKey);
    public delegate void DACCodeGeneratedSelectHandler(String pTextCode, String pEntityName, String pParentKey);
    public delegate void TDGCodeGeneratedSelectHandler(String pTextCode, String pEntityName, String pParentKey);
    public delegate void BECodeGeneratedSelectHandler(String pTextCode, String pEntityName, String pParentKey);
    public delegate void ServiceCodeGeneratedSelectHandler(String pTextCode, String pClassName);

    public partial class ListViewCodeGenerated : UserControl
    {
        #region <-- Events -->
        private event ServiceCodeGeneratedSelectHandler _ServiceCodeGeneratedSelectEvent = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        private void OnServiceCodeGeneratedSelectEvent(String pTextCode, String pEntityName)
        {

            if (_ServiceCodeGeneratedSelectEvent != null)
                _ServiceCodeGeneratedSelectEvent(pTextCode, pEntityName);//, pParentKey);
        }
        /// <summary>
        /// 
        /// </summary>
        public event ServiceCodeGeneratedSelectHandler ServiceCodeGeneratedSelectEvent
        {
            add
            {
                _ServiceCodeGeneratedSelectEvent = (ServiceCodeGeneratedSelectHandler)Delegate.Combine(_ServiceCodeGeneratedSelectEvent, value);
            }
            remove
            {
                _ServiceCodeGeneratedSelectEvent = (ServiceCodeGeneratedSelectHandler)Delegate.Remove(_ServiceCodeGeneratedSelectEvent, value);
            }
        }

        private event StoredProcedureCodeGeneratedSelectHandler _StoredProcedureCodeGeneratedSelectEvent = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        private void OnStoredProcedureCodeGeneratedSelectEvent(String pTextCode, String pEntityName, String pParentKey)
        {

            if (_StoredProcedureCodeGeneratedSelectEvent != null)
                _StoredProcedureCodeGeneratedSelectEvent(pTextCode, pEntityName, pParentKey);
        }
        /// <summary>
        /// 
        /// </summary>
        public event StoredProcedureCodeGeneratedSelectHandler StoredProcedureCodeGeneratedSelectEvent
        {
            add
            {
                _StoredProcedureCodeGeneratedSelectEvent = (StoredProcedureCodeGeneratedSelectHandler)Delegate.Combine(_StoredProcedureCodeGeneratedSelectEvent, value);
            }
            remove
            {
                _StoredProcedureCodeGeneratedSelectEvent = (StoredProcedureCodeGeneratedSelectHandler)Delegate.Remove(_StoredProcedureCodeGeneratedSelectEvent, value);
            }
        }



        private event DACCodeGeneratedSelectHandler _DACCodeGeneratedSelectEvent = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        private void OnDACCodeGeneratedSelectEvent(String pTextCode, String pEntityName, String pParentKey)
        {

            if (_DACCodeGeneratedSelectEvent != null)
                _DACCodeGeneratedSelectEvent(pTextCode, pEntityName, pParentKey);
        }
        /// <summary>
        /// 
        /// </summary>
        public event DACCodeGeneratedSelectHandler DACCodeGeneratedSelectEvent
        {
            add
            {
                _DACCodeGeneratedSelectEvent = (DACCodeGeneratedSelectHandler)Delegate.Combine(_DACCodeGeneratedSelectEvent, value);
            }
            remove
            {
                _DACCodeGeneratedSelectEvent = (DACCodeGeneratedSelectHandler)Delegate.Remove(_DACCodeGeneratedSelectEvent, value);
            }
        }

        private event BECodeGeneratedSelectHandler _BECodeGeneratedSelectEvent = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        private void OnBECodeGeneratedSelectEvent(String pTextCode, String pEntityName, String pParentKey)
        {

            if (_BECodeGeneratedSelectEvent != null)
                _BECodeGeneratedSelectEvent(pTextCode, pEntityName, pParentKey);
        }
        /// <summary>
        /// 
        /// </summary>
        public event BECodeGeneratedSelectHandler BECodeGeneratedSelectEvent
        {
            add
            {
                _BECodeGeneratedSelectEvent = (BECodeGeneratedSelectHandler)Delegate.Combine(_BECodeGeneratedSelectEvent, value);
            }
            remove
            {
                _BECodeGeneratedSelectEvent = (BECodeGeneratedSelectHandler)Delegate.Remove(_BECodeGeneratedSelectEvent, value);
            }
        }

        private event TDGCodeGeneratedSelectHandler _TDGCodeGeneratedSelectEvent = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        private void OnTDGCodeGeneratedSelectEvent(String pTextCode, String pEntityName, String pParentKey)
        {

            if (_TDGCodeGeneratedSelectEvent != null)
                _TDGCodeGeneratedSelectEvent(pTextCode, pEntityName, pParentKey);
        }
        /// <summary>
        /// 
        /// </summary>
        public event TDGCodeGeneratedSelectHandler TDGCodeGeneratedSelectEvent
        {
            add
            {
                _TDGCodeGeneratedSelectEvent = (TDGCodeGeneratedSelectHandler)Delegate.Combine(_TDGCodeGeneratedSelectEvent, value);
            }
            remove
            {
                _TDGCodeGeneratedSelectEvent = (TDGCodeGeneratedSelectHandler)Delegate.Remove(_TDGCodeGeneratedSelectEvent, value);
            }
        }
        #endregion

        #region <-- Color -->
        public Color ForeColorBE
        {
            get { return trvCodeGenerated.Nodes["BE"].ForeColor; }
            set { trvCodeGenerated.Nodes["BE"].ForeColor = value; }
        }
        public Color ForeColorDAC
        {
            get { return trvCodeGenerated.Nodes["DAC"].ForeColor; }
            set { trvCodeGenerated.Nodes["DAC"].ForeColor = value; }
        }
       
        public Color ForeColorSP
        {
            get { return trvCodeGenerated.Nodes["SP"].ForeColor; }
            set { trvCodeGenerated.Nodes["SP"].ForeColor = value; }
        }
        public Color ForeColorSVC
        {
            get { return trvCodeGenerated.Nodes["SVC"].ForeColor; }
            set { trvCodeGenerated.Nodes["SVC"].ForeColor = value; }
        }
        #endregion

        #region <-- List<GeneratedCode> -->


        private TreeNode _NodeSP = null;
        private TreeNode _NodeDAC = null;
        private TreeNode _NodeTDG = null;
        private TreeNode _NodeBE= null;
        private TreeNode _NodeCustomSVC = null;
        private TreeNode _NodeSVC;

        public TreeNode NodeSVC
        {
            get { return _NodeSVC; }
            set { _NodeSVC = value; }
        }
        public TreeNode NodeSP
        {
            get { return _NodeSP; }
            set { _NodeSP = value; }
        }
        public TreeNode NodeDAC
        {
            get { return _NodeDAC; }
            set { _NodeDAC = value; }
        }
        public TreeNode NodeTDG
        {
            get { return _NodeTDG; }
            set { _NodeTDG = value; }
        }

        public TreeNode NodeBE
        {
            get { return _NodeBE; }
            set{_NodeBE = value;}
        }
        public TreeNode NodeCustomSVC
        {
            get { return _NodeCustomSVC; }
            set { _NodeCustomSVC = value; }
        }
        #endregion

        public ListViewCodeGenerated()
        {
            InitializeComponent();
            
        }

        public void LoadTtreeView()
        {

            if (_NodeBE != null)
                LoadGeneratedCode(CodeGeneratorCommon.ComponentLayer.BE, _NodeBE);
              
            

            if (_NodeDAC != null)
                LoadGeneratedCode(CodeGeneratorCommon.ComponentLayer.DAC, _NodeDAC);
   


            if (_NodeCustomSVC != null)
                LoadGeneratedCode(CodeGeneratorCommon.ComponentLayer.SVC, _NodeCustomSVC);
               


            if (_NodeSP != null)
                LoadGeneratedCodeSP(trvCodeGenerated.Nodes["SP"]);


            if (_NodeSVC != null)
                LoadSVCTreeNode();



            _NodeDAC = null;
            _NodeSP = null;
            _NodeBE = null;
            _NodeSVC = null;
            _NodeCustomSVC = null;

        }

        void LoadGeneratedCodeSP(TreeNode pNode)
        {
            trvCodeGenerated.Nodes["SP"].Nodes.Clear();
            foreach (TreeNode node in _NodeSP.Nodes)
            {
                trvCodeGenerated.Nodes["SP"].Nodes.Add((TreeNode) node.Clone());
            }

            ListViewCodeGen.ImageToBackendSP(trvCodeGenerated.Nodes["SP"]);
        }

        void LoadGeneratedCode(CodeGeneratorCommon.ComponentLayer pComponentLayer, TreeNode pNodeToClone)
        {
            String wNodeKey = Enum.GetName(typeof(CodeGeneratorCommon.ComponentLayer), pComponentLayer);

            trvCodeGenerated.Nodes[wNodeKey].Nodes.Clear();
            foreach (TreeNode node in pNodeToClone.Nodes)
            {
                trvCodeGenerated.Nodes[wNodeKey].Nodes.Add((TreeNode)node.Clone());
                
            }
           
            ListViewCodeGen.ImageToBackend(trvCodeGenerated.Nodes[wNodeKey]);
        }

        /// <summary>
        /// Carga los servicios generados automaticamente. Son los servicios standares.
        /// </summary>
        void LoadSVCTreeNode()
        {
            trvCodeGenerated.Nodes["SVC"].Nodes.Clear();
            foreach (TreeNode node in _NodeSVC.Nodes)
            {
                trvCodeGenerated.Nodes["SVC"].Nodes.Add((TreeNode) node.Clone());
            }
            
            ListViewCodeGen.ImageToServiceNode(trvCodeGenerated.Nodes["SVC"]);
        }

        #region expand
        public void ExpandServices()
        {
            trvCodeGenerated.Nodes["SVC"].Expand();
        }

        public void ExpandBE()
        {
            trvCodeGenerated.Nodes["BE"].Expand();
        }

        #endregion

        public String GetLastSelectedEntityCode(String pParentKey, String pEntityName)
        {

            foreach (TreeNode wNode in trvCodeGenerated.Nodes[pParentKey].Nodes)
            {
                if (wNode.Text == pEntityName)return wNode.Tag.ToString();
            }

            return String.Empty;
        }

        /// <summary>
        /// Genera fisicamente los archivos corespondientes al codigo 
        /// Para cada modulo crea una carpata una carpeta con su nombre.-
        /// Para los SP ademas genera una subfolder con el nombre de la entidad y dentro de ella 
        /// graba un archivo *.spl por cada metodo.-
        /// </summary>
        /// <param name="pzsPath">Ruta raiz </param>
        private void SaveGeneratedCodeFiles(string pzsPath)
        {


            SaveGeneratedCodeFiles(pzsPath, CodeGeneratorCommon.ComponentLayer.BE);
            SaveGeneratedCodeFiles(pzsPath, CodeGeneratorCommon.ComponentLayer.DAC);
            
            SaveGeneratedCodeFiles(pzsPath, CodeGeneratorCommon.ComponentLayer.SP);
            SaveGeneratedCodeFiles(pzsPath, CodeGeneratorCommon.ComponentLayer.SVC);
            Boolean wPublicOnCitryx = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("PublicOnCitryx"));
            if (!wPublicOnCitryx)
                System.Diagnostics.Process.Start("explorer.exe", pzsPath);
        }

        /// <summary>
        /// Genera fisicamente los archivos corespondientes al codigo 
        /// Para cada modulo crea una carpata una carpeta con su nombre.-
        /// Para los SP ademas genera una subfolder con el nombre de la entidad y dentro de ella 
        /// graba un archivo *.spl por cada metodo.-
        /// </summary>
        /// <param name="pzsPath">Ruta raiz </param>
        /// <param name="pComponentLayer">Modulo (BE,DAC,TDG SVC, SP)</param>
        /// <param name="pGeneratedCodeList">Coleccion de GeneratedCodes</param>
        private void SaveGeneratedCodeFiles(string pzsPath, CodeGeneratorCommon.ComponentLayer pComponentLayer)
        {
            //if (pGeneratedCodeList.Count == 0) return;
            GeneratedCode wGeneratedCode = null;
            DirectoryInfo wdiModule = null;
            string wzsFile = String.Empty;

            if(pComponentLayer != CodeGeneratorCommon.ComponentLayer.SVC)
                wdiModule = Directory.CreateDirectory(pzsPath + Path.DirectorySeparatorChar + Enum.GetName(typeof(CodeGeneratorCommon.ComponentLayer), pComponentLayer));
            else
             wdiModule = Directory.CreateDirectory(pzsPath + Path.DirectorySeparatorChar );
            
            #region BE, DAC y TDG
            if (pComponentLayer != CodeGeneratorCommon.ComponentLayer.SP && pComponentLayer != CodeGeneratorCommon.ComponentLayer.SVC)
            {


                foreach (TreeNode wNode in trvCodeGenerated.Nodes[Enum.GetName(typeof(CodeGeneratorCommon.ComponentLayer), pComponentLayer)].Nodes)
                {
                    wGeneratedCode = (GeneratedCode) wNode.Tag;

                    wzsFile = wdiModule.FullName + Path.DirectorySeparatorChar + wGeneratedCode.Id + Enum.GetName(typeof(CodeGeneratorCommon.ComponentLayer), pComponentLayer) + ".cs";
                    FileFunctions.SaveTextFile(wzsFile, wGeneratedCode.Code.ToString());
                }
            }
            #endregion

            #region StoredProcedures
            if (pComponentLayer == CodeGeneratorCommon.ComponentLayer.SP)
            {
                DirectoryInfo wdiEntity = null;
                string wzsAux = string.Empty;
                foreach (TreeNode wNodeTable in trvCodeGenerated.Nodes[Enum.GetName(typeof(CodeGeneratorCommon.ComponentLayer), pComponentLayer)].Nodes)
                {
                    foreach (TreeNode wNodeMethod in wNodeTable.Nodes)
                    {
                        wGeneratedCode = (GeneratedCode)wNodeMethod.Tag;

                        if (wzsAux != wGeneratedCode.Id)
                        {
                            wdiEntity = Directory.CreateDirectory(wdiModule.FullName + Path.DirectorySeparatorChar + wGeneratedCode.Id);
                        }

                        wzsFile = wdiEntity.FullName + Path.DirectorySeparatorChar + wGeneratedCode.Id + "_" + wGeneratedCode.MethodActionType.ToString() + ".sql";
                        FileFunctions.SaveTextFile(wzsFile, wGeneratedCode.Code.ToString());
                    }
                    
                }
            
            }
            #endregion

            if (pComponentLayer == CodeGeneratorCommon.ComponentLayer.SVC)
            {


                DirectoryInfo wdiSVC = Directory.CreateDirectory(wdiModule.FullName + Path.DirectorySeparatorChar + Enum.GetName(typeof(CodeGeneratorCommon.ComponentLayer), pComponentLayer));
                DirectoryInfo wdiISVC = Directory.CreateDirectory(wdiModule.FullName + Path.DirectorySeparatorChar + Enum.GetName(typeof(CodeGeneratorCommon.ComponentLayer), CodeGeneratorCommon.ComponentLayer.ISVC));


                TreeNode wNodeService =
                    trvCodeGenerated.Nodes[Enum.GetName(typeof(CodeGeneratorCommon.ComponentLayer), pComponentLayer)];

                if (wNodeService.Nodes.Count == 0)
                    return;

                if (wNodeService.Nodes[0].Name != "ServiceTable")
                {
                    ///Custom Serivices (SVC) & interfases(SVC)
                    foreach (TreeNode wNodeClass in wNodeService.Nodes)
                    {
                        wGeneratedCode = (GeneratedCode) wNodeClass.Tag;

                        if (wGeneratedCode.Id.Substring(wGeneratedCode.Id.Length - 10, 10) == "Service.cs")
                        {
                            wzsFile = wdiSVC.FullName + Path.DirectorySeparatorChar + wGeneratedCode.Id;
                        }
                        else
                        {
                            wzsFile = wdiISVC.FullName + Path.DirectorySeparatorChar + wGeneratedCode.Id;
                        }

                        FileFunctions.SaveTextFile(wzsFile, wGeneratedCode.Code.ToString());
                    }
                }
                if (wNodeService.Nodes[0].Name == "ServiceTable")
                {
                    foreach (TreeNode wNodeServiceTable in wNodeService.Nodes)
                    {
                        foreach (TreeNode wNodeMethod in wNodeServiceTable.Nodes)
                        {
                            foreach (TreeNode wNodeClasses in wNodeMethod.Nodes)
                            {
                                wGeneratedCode = (GeneratedCode)wNodeClasses.Tag;

                                if (wGeneratedCode.Id.Substring(wGeneratedCode.Id.Length - 10, 10) == "Service.cs")
                                {
                                    wzsFile = wdiSVC.FullName + Path.DirectorySeparatorChar + wGeneratedCode.Id;
                                }
                                else
                                {
                                    wzsFile = wdiISVC.FullName + Path.DirectorySeparatorChar + wGeneratedCode.Id;
                                }

                                FileFunctions.SaveTextFile(wzsFile, wGeneratedCode.Code.ToString());
                            }
                        }
                    }
                }

               




             


            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            //string tag = trvCodeGenerated.SelectedNode.Tag.ToString();
            SaveGeneratedCodeFiles(folderBrowserDialog1.SelectedPath);

        }
        private void trvCodeGenerated_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node.Level == 0) return;
            GeneratedCode gen = null;
            switch (e.Node.Level)
            {
                case 1:
                    {
                        if (e.Node.Parent.Tag.ToString() == "DAC")
                        {
                            gen = (GeneratedCode)e.Node.Tag;
                            OnDACCodeGeneratedSelectEvent(gen.Code.ToString(), e.Node.Text, e.Node.Parent.Tag.ToString());
                        }
                        if (e.Node.Parent.Tag.ToString() == "TDG")
                        {
                            gen = (GeneratedCode)e.Node.Tag;
                            OnTDGCodeGeneratedSelectEvent(gen.Code.ToString(), e.Node.Text, e.Node.Parent.Tag.ToString());
                        }
                        if (e.Node.Parent.Tag.ToString() == "BE")
                        {
                            gen = (GeneratedCode)e.Node.Tag;
                            OnBECodeGeneratedSelectEvent(gen.Code.ToString(), e.Node.Text, e.Node.Parent.Tag.ToString());
                        }

                        if (e.Node.Parent.Tag.ToString() == "SVC")
                        {
                            if (e.Node.Tag != null)
                            {
                                if (e.Node.Tag.GetType() != typeof (GeneratedCode)) break;
                                gen = (GeneratedCode) e.Node.Tag;
                                OnServiceCodeGeneratedSelectEvent(gen.Code.ToString(), e.Node.Text);
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        if(e.Node.Parent.Tag != null)
                            if (e.Node.Parent.Tag.ToString() == "EntitySP")
                            {
                                gen = (GeneratedCode) e.Node.Tag;
                                OnStoredProcedureCodeGeneratedSelectEvent(gen.Code.ToString(), e.Node.Parent.Text,
                                                                          e.Node.Parent.Parent.Name.ToString());
                            }


                        break;
                    }
                case 3:
                    {
                        if (e.Node.Parent.Name == "ServiceTableMethod")
                        {
                            gen = (GeneratedCode)e.Node.Tag;
                            OnServiceCodeGeneratedSelectEvent(gen.Code.ToString(),gen.Id);
                        }
                        break;
                    }
            }




        }
    }
}
